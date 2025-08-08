using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;
using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloBussinessInteligenceERP
{
	private static IBussinessInteligence _bussinessDao = AcessoDados.BussinessInteligenceDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ERPDataQuantidadeValor> ObterBI_NF_Data_Quantidade_Valor(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<ERPDataQuantidadeValor>((IList)_bussinessDao.ObterBI_NF_Data_Quantidade_Valor(dataInicio, dataFim));
	}

	public static void CalcularRelatorioCustos(DateTime DataInicio, DateTime DataFim)
	{
		IList<FichaExpedicao> list = ModuloExpedicao.ObterTodosFichaExpedicaoCalcularCusto(DataInicio, DataFim);
		foreach (FichaExpedicao item in list)
		{
			if (item.StatusFichaExpedicao != EnumStatusFichaExpedicao.Faturado)
			{
				continue;
			}
			NotaFiscalNotasFiscais notaFiscalNotasFiscais = null;
			if (item.CodigoNotaFiscal > 0)
			{
				notaFiscalNotasFiscais = ModuloNotaFiscal.ObterNotaFiscalNotasFiscais(item.CodigoSociedade, item.CodigoNotaFiscal, 3);
			}
			foreach (FichaExpedicaoItem iten in item.Itens)
			{
				RelatorioCustos relatorioCustos = new RelatorioCustos();
				if (notaFiscalNotasFiscais != null)
				{
					relatorioCustos.DataFaturamento = notaFiscalNotasFiscais.DataEnvioNFE;
				}
				else
				{
					relatorioCustos.DataFaturamento = item.DataEntrega;
				}
				relatorioCustos.CodigoCliente = item.CodigoEntidade;
				relatorioCustos.NomeCliente = item.EntidadeRef.NomeFantasia;
				relatorioCustos.CodigoFichaExpedicao = item.Codigo;
				relatorioCustos.CodigoFichaExpedicaoItem = iten.ItemFichaExpedicao;
				relatorioCustos.CodigoNotaFiscal = iten.CodigoNotaFiscal;
				relatorioCustos.CodigoNotaFiscalItem = iten.ItemNotaFiscal;
				relatorioCustos.Contrato = iten.Contrato;
				relatorioCustos.ChaveEstoqurRef = iten.ChaveEstoqueRef;
				relatorioCustos.CodigoPedidoVenda = iten.CodigoPedido;
				relatorioCustos.CodigoPedidoVendaItem = iten.ItemPedido;
				relatorioCustos.CodigoOrdemFabricacao = iten.OrdemFabricacaoProduto;
				relatorioCustos.CodigoCadencia = iten.CodigoCadencia;
				relatorioCustos.DescricaoProduto = iten.DescricaoProduto;
				if (string.IsNullOrEmpty(relatorioCustos.Contrato) && item.PedidoVenda != null)
				{
					relatorioCustos.Contrato = item.PedidoVenda.ReferenciaPedido;
				}
				relatorioCustos.Spool = iten.Spool;
				if (!item.IsReagruparFaturamento && (iten.ItensFaturamentoRef == null || iten.ItensFaturamentoRef.Count == 0) && iten.CodigoNotaFiscal > 0 && iten.ItemNotaFiscal > 0)
				{
					NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = ModuloNotaFiscal.ObterNotaFiscalNotasFiscaisItens(item.CodigoSociedade, iten.CodigoNotaFiscal, iten.ItemNotaFiscal, 3);
					if (notaFiscalNotasFiscaisItens != null)
					{
						relatorioCustos.ContaContabilAnalitica = notaFiscalNotasFiscaisItens.ContaContabilAnalitica;
						relatorioCustos.ValorVenda = notaFiscalNotasFiscaisItens.ValorTotalFreteSeguroOutrosDesconto;
						relatorioCustos.ValorIPI = notaFiscalNotasFiscaisItens.ValorIPI;
						relatorioCustos.ValorIcms = notaFiscalNotasFiscaisItens.ValorICMSTotal;
						relatorioCustos.ValorPis = notaFiscalNotasFiscaisItens.ValorPIS;
						relatorioCustos.ValorCofins = notaFiscalNotasFiscaisItens.ValorCofins;
					}
					else
					{
						string empty = string.Empty;
					}
				}
				else if (relatorioCustos.ValorVenda == 0m && iten.PedidoVendaItemRef != null)
				{
					relatorioCustos.ValorVenda = iten.PedidoVendaItemRef.PrecoUnitarioBruto * iten.QuantidadeEntregue;
					if (iten.PedidoVendaItemRef.ImpostoVendaRef.ValorPis == 0m || iten.PedidoVendaItemRef.ImpostoVendaRef.ValorIcms == 0m)
					{
						CalcularImposto(iten.PedidoVendaItemRef.PedidoVenda, iten.PedidoVendaItemRef);
						ModuloVendasGPS.AlterarPedidoVendaItem(iten.PedidoVendaItemRef, iten.PedidoVendaItemRef.PropriedadesModificadas);
					}
					relatorioCustos.ValorIcms = iten.PedidoVendaItemRef.ImpostoVendaRef.ValorIcms / (decimal)iten.PedidoVendaItemRef.Quantidade * iten.QuantidadeEntregue;
					relatorioCustos.ValorPis = iten.PedidoVendaItemRef.ImpostoVendaRef.ValorPis / (decimal)iten.PedidoVendaItemRef.Quantidade * iten.QuantidadeEntregue;
					relatorioCustos.ValorCofins = iten.PedidoVendaItemRef.ImpostoVendaRef.ValorCofins / (decimal)iten.PedidoVendaItemRef.Quantidade * iten.QuantidadeEntregue;
					relatorioCustos.ValorIPI = iten.PedidoVendaItemRef.ImpostoVendaRef.ValorIpi / (decimal)iten.PedidoVendaItemRef.Quantidade * iten.QuantidadeEntregue;
					if (iten.IdContaContabil > 0)
					{
						PlanoConta planoConta = ModuloFiscal.ObterPlanoContaEstatico(iten.IdContaContabil);
						if (planoConta != null)
						{
							relatorioCustos.NomeContaContabil = planoConta.Descricao;
							relatorioCustos.ContaContabilAnalitica = planoConta.Conta;
						}
					}
				}
				else if (relatorioCustos.ValorVenda == 0m)
				{
					relatorioCustos.ValorVenda = iten.ValorFaturamento;
					relatorioCustos.ValorIcms = relatorioCustos.ValorVenda * 0.012m;
					relatorioCustos.ValorPis = relatorioCustos.ValorVenda * 0.0165m;
					relatorioCustos.ValorCofins = relatorioCustos.ValorVenda * 0.076m;
					relatorioCustos.ValorIPI = Math.Round(0.05m * relatorioCustos.ValorVenda, 2);
				}
				else
				{
					string empty2 = string.Empty;
				}
				relatorioCustos.ValorVendaLiquido = relatorioCustos.ValorVenda - relatorioCustos.ValorIcms - relatorioCustos.ValorPis - relatorioCustos.ValorCofins;
				relatorioCustos.ValorVendaIPI = relatorioCustos.ValorVenda + relatorioCustos.ValorIPI;
				if (string.IsNullOrEmpty(relatorioCustos.NomeContaContabil) && !string.IsNullOrWhiteSpace(relatorioCustos.ContaContabilAnalitica))
				{
					PlanoConta planoConta2 = ModuloFiscal.ObterPlanoContaEstatico(relatorioCustos.ContaContabilAnalitica);
					if (planoConta2 != null)
					{
						relatorioCustos.NomeContaContabil = planoConta2.Descricao;
					}
				}
				if (iten.OrdemFabricacaoProduto > 0 && iten.OrdemFabricacaoProdutoRef != null)
				{
					decimal num = iten.QuantidadeEntregue / ((iten.OrdemFabricacaoProdutoRef.QuantidadeBoa == 0) ? iten.QuantidadeEntregue : ((decimal)iten.OrdemFabricacaoProdutoRef.QuantidadeBoa));
					relatorioCustos.CustoMateriaPrima = iten.OrdemFabricacaoProdutoRef.CustoTotalRealMateriais * num;
					relatorioCustos.CustoComponentes = iten.OrdemFabricacaoProdutoRef.CustoTotalRealComponentes * num;
					relatorioCustos.CustoTerceiros = iten.OrdemFabricacaoProdutoRef.CustoTotalRealTerceiros * num;
					relatorioCustos.Horas = iten.OrdemFabricacaoProdutoRef.HorasTotalRealProducao * num;
					relatorioCustos.ValorHoraProduzido = iten.OrdemFabricacaoProdutoRef.CustoTotalMaoObra * num;
					relatorioCustos.CustoTeoricoMateriaPrima = iten.OrdemFabricacaoProdutoRef.CustoTotalPrevistoMateriais * num;
					relatorioCustos.CustoTeoricoComponentes = iten.OrdemFabricacaoProdutoRef.CustoTotalPrevistoComponentes * num;
					relatorioCustos.CustoTeoricoTerceiros = iten.OrdemFabricacaoProdutoRef.CustoTotalPrevistoTerceiros * num;
					relatorioCustos.HorasTeroricas = iten.OrdemFabricacaoProdutoRef.HorasTotalPrevistoProducao * num;
					relatorioCustos.ValorTeoricoMaoObra = (iten.OrdemFabricacaoProdutoRef.CustoTotalPrevistoPreparacao + iten.OrdemFabricacaoProdutoRef.CustoTotalPrevistoProducao + iten.OrdemFabricacaoProdutoRef.CustoTotalPrevistoControle) * num;
					if (relatorioCustos.CustoMateriaPrima == 0m)
					{
						string empty3 = string.Empty;
						relatorioCustos.Comentario = "OF não reportada";
					}
					int codigoPedido = iten.CodigoPedido;
					int ordemFabricacaoProduto = iten.OrdemFabricacaoProduto;
					IList<OrdemFabricacaoProduto> list2 = ModuloProducao.ObterTodosOrdemFabricacaoProduto(codigoPedido, ordemFabricacaoProduto);
					IList<OrdemFabricacaoMateria> list3 = ModuloProducao.ObterTodosOrdemFabricacaoMateria(codigoPedido, ordemFabricacaoProduto);
					IList<OrdemFabricacaoFase> list4 = ModuloProducao.ObterTodosOrdemFabricacaoFase(codigoPedido, ordemFabricacaoProduto);
					foreach (OrdemFabricacaoMateria item2 in list3)
					{
						if (!item2.IsSistema)
						{
							RelatorioCustoDetalhes relatorioCustoDetalhes = new RelatorioCustoDetalhes();
							relatorioCustoDetalhes.ChaveEstoqueRef = item2.ChaveEstoqueRef;
							relatorioCustoDetalhes.TipoCusto = EnumTipoCustoDetalhe.MatériaPrima;
							relatorioCustoDetalhes.Comentario = "";
							relatorioCustoDetalhes.Descricao = item2.DescricaoMateria;
							relatorioCustoDetalhes.NecessidadePrevista = item2.QuantidadeNecessidadeTotal;
							relatorioCustoDetalhes.NecessidadeReal = item2.QuantidadeSaiu;
							relatorioCustoDetalhes.Unidade = item2.Unidade.ObterDescricaoEnum();
							relatorioCustoDetalhes.ValorPrevisto = item2.CustoTotalPrevisto;
							relatorioCustoDetalhes.ValorReal = item2.CustoTotalReal;
							relatorioCustos.RelatorioCustoDetalhes.Add(relatorioCustoDetalhes);
						}
					}
					foreach (OrdemFabricacaoProduto item3 in list2)
					{
						if (item3.TipoProdutoEnum == EnumTipoComponentesEstrutura.Comprado)
						{
							RelatorioCustoDetalhes relatorioCustoDetalhes2 = new RelatorioCustoDetalhes();
							relatorioCustoDetalhes2.ChaveEstoqueRef = item3.ChavePrimariaEstoque;
							relatorioCustoDetalhes2.TipoCusto = EnumTipoCustoDetalhe.Componente;
							relatorioCustoDetalhes2.Comentario = "";
							relatorioCustoDetalhes2.Descricao = item3.Descricao;
							relatorioCustoDetalhes2.NecessidadePrevista = item3.QuantidadeLancadaBruta;
							relatorioCustoDetalhes2.NecessidadeReal = item3.QuantidadeJaSaiu;
							relatorioCustoDetalhes2.Unidade = "Peças";
							relatorioCustoDetalhes2.ValorPrevisto = item3.CustoComponentesPrevisto;
							relatorioCustoDetalhes2.ValorReal = item3.CustoComponentesReal;
							relatorioCustos.RelatorioCustoDetalhes.Add(relatorioCustoDetalhes2);
						}
					}
					foreach (OrdemFabricacaoFase item4 in list4)
					{
						RelatorioCustoDetalhes relatorioCustoDetalhes3 = new RelatorioCustoDetalhes();
						if (item4.TipoOperacao == EnumTipoOperacao.Interna)
						{
							relatorioCustoDetalhes3.TipoCusto = EnumTipoCustoDetalhe.OperacaoInterna;
							relatorioCustoDetalhes3.Comentario = "";
							relatorioCustoDetalhes3.CodigoProduto = item4.CodigoProduto;
							relatorioCustoDetalhes3.Descricao = item4.RecursoOrdemFabricacao;
							relatorioCustoDetalhes3.NecessidadePrevista = item4.TempoTotalPrevisto;
							relatorioCustoDetalhes3.NecessidadeReal = item4.TempoRealizado;
							relatorioCustoDetalhes3.Unidade = "Horas";
							relatorioCustoDetalhes3.ValorPrevisto = item4.CustoPrevisto;
							relatorioCustoDetalhes3.ValorReal = item4.CustoReal;
							relatorioCustos.RelatorioCustoDetalhes.Add(relatorioCustoDetalhes3);
						}
						else
						{
							relatorioCustoDetalhes3.TipoCusto = EnumTipoCustoDetalhe.OperacaoExterna;
							relatorioCustoDetalhes3.Comentario = "";
							relatorioCustoDetalhes3.CodigoProduto = item4.CodigoProduto;
							relatorioCustoDetalhes3.Descricao = item4.RecursoOrdemFabricacao;
							relatorioCustoDetalhes3.NecessidadePrevista = item4.Necessidade * item4.QuantidadeLancada;
							relatorioCustoDetalhes3.NecessidadeReal = item4.Necessidade * (decimal)item4.QuantidadeTerminada;
							relatorioCustoDetalhes3.Unidade = item4.Unidade.ToString();
							relatorioCustoDetalhes3.ValorPrevisto = item4.CustoTeorico * item4.QuantidadeLancada;
							relatorioCustoDetalhes3.ValorReal = item4.CustoReal * (decimal)item4.QuantidadeTerminada;
							relatorioCustos.RelatorioCustoDetalhes.Add(relatorioCustoDetalhes3);
						}
					}
				}
				else
				{
					string empty4 = string.Empty;
					relatorioCustos.Comentario = "OF não encontrada";
				}
				relatorioCustos.ValorCustoSemMaoObra = relatorioCustos.CustoMateriaPrima + relatorioCustos.CustoComponentes + relatorioCustos.CustoTerceiros;
				relatorioCustos.ValorCustoComMaoObra = relatorioCustos.ValorCustoSemMaoObra + relatorioCustos.ValorHoraVendida;
				relatorioCustos.ValorTeoricoCustoSemMaoObra = relatorioCustos.CustoTeoricoMateriaPrima + relatorioCustos.CustoTeoricoComponentes + relatorioCustos.CustoTeoricoTerceiros;
				relatorioCustos.ValorTeoricoCustoComMaoObra = relatorioCustos.ValorTeoricoCustoSemMaoObra + relatorioCustos.ValorTeoricoMaoObra;
				relatorioCustos.ValorAgregado = relatorioCustos.ValorVendaLiquido - relatorioCustos.ValorCustoSemMaoObra;
				relatorioCustos.ValorMargemContribuicao = relatorioCustos.ValorVendaLiquido - relatorioCustos.ValorCustoComMaoObra;
				relatorioCustos.ValorCustoTeoricoAgregado = relatorioCustos.ValorVendaLiquido - relatorioCustos.ValorTeoricoCustoSemMaoObra;
				relatorioCustos.ValorTeroricoMargem = relatorioCustos.ValorVendaLiquido - relatorioCustos.ValorTeoricoCustoComMaoObra;
				if (relatorioCustos.ValorVendaLiquido > 0m)
				{
					relatorioCustos.PercentualAgregado = relatorioCustos.ValorAgregado / relatorioCustos.ValorVendaLiquido * 100m;
					relatorioCustos.PercentualMargemContribuicao = relatorioCustos.ValorMargemContribuicao / relatorioCustos.ValorVendaLiquido * 100m;
					relatorioCustos.PercentualTeoricoCustoAgregado = relatorioCustos.ValorCustoTeoricoAgregado / relatorioCustos.ValorVendaLiquido * 100m;
					relatorioCustos.PercentualTeoricoMargemContribuicao = relatorioCustos.ValorTeroricoMargem / relatorioCustos.ValorVendaLiquido * 100m;
				}
				if (relatorioCustos.Horas > 0m)
				{
					relatorioCustos.ValorHoraVendida = relatorioCustos.ValorAgregado / relatorioCustos.Horas;
				}
				relatorioCustos.DataCalculo = DateTime.Now;
				ModuloControladoria.SalvarRelatorioCustos(relatorioCustos);
			}
			item.IsCustoCalculado = true;
			ModuloExpedicao.AlterarFichaExpedicao(item, item.PropriedadesModificadas);
		}
	}

	public static void CalcularImposto(PedidoVendaGPS pedidoVenda, PedidoVendaItemGPS itemPedidoVenda)
	{
		if (pedidoVenda == null || itemPedidoVenda == null)
		{
			return;
		}
		NotaFiscalCFOPs notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(itemPedidoVenda.CodigoImpostoVenda);
		if (notaFiscalCFOPs == null)
		{
			return;
		}
		try
		{
			itemPedidoVenda.ImpostoVendaRef.CodigoModalidadeIcms = notaFiscalCFOPs.ModalidadeICMS.ToString();
			itemPedidoVenda.ImpostoVendaRef.CodigoOrigemProduto = notaFiscalCFOPs.OrigemProduto;
			itemPedidoVenda.ImpostoVendaRef.IsConsumidorFinal = pedidoVenda.IsConsumidorFinal;
			itemPedidoVenda.ImpostoVendaRef.IsCsll = notaFiscalCFOPs.IsCSLL;
			itemPedidoVenda.ImpostoVendaRef.IsIcmsInterestadual = false;
			itemPedidoVenda.ImpostoVendaRef.NomeCfop = MetodosUteis.LimpaNro(notaFiscalCFOPs.NumeracaoCFOP);
			itemPedidoVenda.ImpostoVendaRef.PercentualBaseAgregadaIcmsSt = 0m;
			itemPedidoVenda.ImpostoVendaRef.PercentualBaseReducaoIcms = notaFiscalCFOPs.ReducaoICMS;
			itemPedidoVenda.ImpostoVendaRef.PercentualCofins = notaFiscalCFOPs.ValorCofins;
			itemPedidoVenda.ImpostoVendaRef.PercentualCreditoIcms = notaFiscalCFOPs.PercentualCreditoIcms;
			itemPedidoVenda.ImpostoVendaRef.PercentualCsll = notaFiscalCFOPs.ValorCSLL;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcms = notaFiscalCFOPs.PadraoICMS;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsInterestadualFundoPobreza = 0m;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsInterestadualUfDestino = 0m;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsInterestadualUfEnvolvidas = 0m;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsStAgregado = 0m;
			itemPedidoVenda.ImpostoVendaRef.PercentualIpi = notaFiscalCFOPs.PadraoIPI;
			itemPedidoVenda.ImpostoVendaRef.PercentualPis = notaFiscalCFOPs.PadraoPIS;
			itemPedidoVenda.ImpostoVendaRef.PercentualRetencaoCofins = notaFiscalCFOPs.PercentualRetencaoCofins;
			itemPedidoVenda.ImpostoVendaRef.PercentualRetencaoPis = notaFiscalCFOPs.PercentualRetencaoPis;
			itemPedidoVenda.ImpostoVendaRef.PercentualISS = notaFiscalCFOPs.ValorISS;
			itemPedidoVenda.ImpostoVendaRef.PercentualIR = notaFiscalCFOPs.ValorIR;
			itemPedidoVenda.ImpostoVendaRef.PercentualINSS = notaFiscalCFOPs.ValorINSS;
			itemPedidoVenda.ImpostoVendaRef.IsPrefeitura = notaFiscalCFOPs.IsPrefeitura;
			itemPedidoVenda.ImpostoVendaRef.Tipo = 2;
			itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaIcms = ModuloNotaFiscal.ObterNotaFiscalTipoIncidencia(notaFiscalCFOPs.IncideICMS).TipoIncidencia;
			itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaIpi = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaIPI(notaFiscalCFOPs.IncideIPI).CodigoIncidencia;
			itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaPis = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaImpostosFederais(notaFiscalCFOPs.IncidePIS).CodigoIncidencia;
			itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaCofins = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaImpostosFederais(notaFiscalCFOPs.IncideCofins).CodigoIncidencia;
			itemPedidoVenda.CodigoCFOP = int.Parse(FuncoesUteis.LimparNro(notaFiscalCFOPs.NumeracaoCFOP));
			if (pedidoVenda.EntidadeRef != null && pedidoVenda.EntidadeRef.UfRef != null && pedidoVenda.EntidadeRef.UfRef.Id != pedidoVenda.SociedadeRef.CodigoUF && notaFiscalCFOPs.UsarIcmsEstadoFederacao && !notaFiscalCFOPs.IsPrefeitura)
			{
				itemPedidoVenda.ImpostoVendaRef.PercentualIcms = pedidoVenda.EntidadeRef.UfRef.PercentualIcms;
				itemPedidoVenda.CodigoCFOP += 1000;
			}
			if (itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaIcms == "201" || itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaIcms == "202" || itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaIcms == "10")
			{
				itemPedidoVenda.ImpostoVendaRef.CodigoModalidadeIcmsSt = notaFiscalCFOPs.CodigoModalidadeICMSST;
				string codigoCest = string.Empty;
				string ncm = string.Empty;
				if (itemPedidoVenda.EstoqueRef != null)
				{
					codigoCest = itemPedidoVenda.EstoqueRef.Cest;
					ncm = itemPedidoVenda.EstoqueRef.ClassificacaoFiscal;
				}
				NotaFiscalCest notaFiscalCest = ModuloNotaFiscal.ObterNotaFiscalCest(codigoCest, ncm, pedidoVenda.EntidadeRef.CodigoUf);
				if (notaFiscalCFOPs.IsUsarTabelaCest && notaFiscalCest != null)
				{
					itemPedidoVenda.ImpostoVendaRef.PercentualBaseAgregadaIcmsSt = notaFiscalCest.ValorMva;
					itemPedidoVenda.ImpostoVendaRef.PercentualIcmsStAgregado = notaFiscalCest.PercentualIcmsSt;
				}
				else
				{
					itemPedidoVenda.ImpostoVendaRef.PercentualBaseAgregadaIcmsSt = notaFiscalCFOPs.PercentualBaseAgragadaICMSST;
					itemPedidoVenda.ImpostoVendaRef.PercentualIcmsStAgregado = notaFiscalCFOPs.PercentualICMSST;
				}
			}
			itemPedidoVenda.ImpostoVendaRef.IsIcmsInterestadual = notaFiscalCFOPs.IsICMSInterestadual;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsInterestadualFundoPobreza = notaFiscalCFOPs.PercentualIcmsInterestadualFundoPobreza;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsInterestadualUfDestino = notaFiscalCFOPs.PercentualIcmsInterestadualUfDestino;
			itemPedidoVenda.ImpostoVendaRef.PercentualIcmsInterestadualUfEnvolvidas = notaFiscalCFOPs.PercentualIcmsInterestadualUfEnvolvidas;
			itemPedidoVenda.ImpostoVendaRef.CodigoSituacaoTributaria = $"{notaFiscalCFOPs.OrigemProduto}{itemPedidoVenda.ImpostoVendaRef.TipoIncidenciaIcms}";
			itemPedidoVenda.ImpostoVendaRef.Quantidade = itemPedidoVenda.QuantidadeNaUnidadeVenda;
			itemPedidoVenda.ImpostoVendaRef.ValorDiversos = itemPedidoVenda.CustoDiverso;
			itemPedidoVenda.ImpostoVendaRef.ValorFrete = itemPedidoVenda.ValorFrete;
			itemPedidoVenda.ImpostoVendaRef.ValorSeguro = itemPedidoVenda.ValorSeguro;
			itemPedidoVenda.ImpostoVendaRef.ValorUnitario = itemPedidoVenda.PrecoNet;
			itemPedidoVenda.ImpostoVendaRef.CalcularImposto();
			itemPedidoVenda.PercentualCOFINS = itemPedidoVenda.ImpostoVendaRef.PercentualCofins;
			itemPedidoVenda.PercentualICMS = itemPedidoVenda.ImpostoVendaRef.PercentualIcms;
			itemPedidoVenda.PercentualIPI = itemPedidoVenda.ImpostoVendaRef.PercentualIpi;
			itemPedidoVenda.PercentualPIS = itemPedidoVenda.ImpostoVendaRef.PercentualPis;
			itemPedidoVenda.ValorIPI = itemPedidoVenda.ImpostoVendaRef.ValorIpi;
			itemPedidoVenda.ValorCOFINS = itemPedidoVenda.ImpostoVendaRef.ValorCofins;
			itemPedidoVenda.ValorICMS = itemPedidoVenda.ImpostoVendaRef.ValorIcms;
			itemPedidoVenda.ValorPIS = itemPedidoVenda.ImpostoVendaRef.ValorPis;
			itemPedidoVenda.IsPrefeitura = itemPedidoVenda.ImpostoVendaRef.IsPrefeitura;
			itemPedidoVenda.PercentualISS = itemPedidoVenda.ImpostoVendaRef.PercentualISS;
			itemPedidoVenda.PercentualIR = itemPedidoVenda.ImpostoVendaRef.PercentualIR;
			itemPedidoVenda.PercentualCSLL = itemPedidoVenda.ImpostoVendaRef.PercentualCsll;
			itemPedidoVenda.PercentualINSS = itemPedidoVenda.ImpostoVendaRef.PercentualINSS;
			itemPedidoVenda.ValorISS = itemPedidoVenda.ImpostoVendaRef.ValorISS;
			itemPedidoVenda.ValorIR = itemPedidoVenda.ImpostoVendaRef.ValorIR;
			itemPedidoVenda.ValorCSLL = itemPedidoVenda.ImpostoVendaRef.ValorCsll;
		}
		catch
		{
		}
	}
}
