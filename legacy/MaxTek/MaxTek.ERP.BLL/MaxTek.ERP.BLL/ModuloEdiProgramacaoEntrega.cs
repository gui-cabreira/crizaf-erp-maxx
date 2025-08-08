using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MaxTek.GPS.BLL;
using MaxTek.GPS.BLL.EDI.ProgramacaoEntrega.RND001V6;

namespace MaxTek.ERP.BLL;

public static class ModuloEdiProgramacaoEntrega
{
	private static int codigoCliente;

	private static IList<TarifaProduto> _tarifas;

	private static IList<TarifaProduto> Tarifa(int CodigoCliente)
	{
		if (codigoCliente != CodigoCliente || _tarifas == null || _tarifas.Count == 0)
		{
			_tarifas = ModuloProduto.ObterTodosTarifaProduto(1, CodigoCliente);
			codigoCliente = CodigoCliente;
		}
		return _tarifas;
	}

	public static decimal QuantidadeEntregueAposNotaCorte(int pedidoVenda, int itemPedidoVenda, int notaCorte)
	{
		decimal num = default(decimal);
		return ModuloNotaFiscal.ObterNotaFiscalNotasFiscaisItensPedidoVenda(pedidoVenda, itemPedidoVenda, notaCorte)?.Select((NotaFiscalNotasFiscaisItens c) => c.Quantidade).Sum() ?? num;
	}

	public static ITP CarregarRND001V6(string PathArquivo)
	{
		ITP iTP = new ITP();
		string nomeArquivo = PathArquivo.Split('\\').Last();
		string[] array = File.ReadAllLines(PathArquivo);
		int num = 0;
		try
		{
			ITP iTP2 = new ITP(array[0], nomeArquivo);
			string seq = iTP2.Seq02;
			int seq2 = iTP2.Seq03;
			if (seq == "001")
			{
				int num2 = -1;
				int num3 = -1;
				PE1[] array2 = new PE1[array.Length];
				PE3[] array3 = new PE3[array.Length];
				try
				{
					for (int i = 0; i < array.Length; i++)
					{
						switch (array[i].Substring(0, 3))
						{
						case "ITP":
							iTP = new ITP(array[i], nomeArquivo);
							break;
						case "PE1":
						{
							num++;
							num3 = -1;
							PE1 pE = new PE1(array[i]);
							num2++;
							array2[num2] = new PE1(array[i]);
							iTP.Pe1s.Add(array2[num2]);
							break;
						}
						case "PE2":
						{
							PE2 item5 = new PE2(array[i]);
							array2[num2].Pe2s.Add(item5);
							break;
						}
						case "PE3":
							num3++;
							array3[num3] = new PE3(array[i]);
							array2[num2].Pe3s.Add(array3[num3]);
							break;
						case "PE4":
						{
							PE4 item4 = new PE4(array[i]);
							array2[num2].Pe4s.Add(item4);
							break;
						}
						case "PE5":
						{
							PE5 item3 = new PE5(array[i]);
							array3[num3].Pe5s.Add(item3);
							break;
						}
						case "TE1":
						{
							TE1 item2 = new TE1(array[i]);
							array2[num2].Te1s.Add(item2);
							break;
						}
						case "FTP":
						{
							FTP item = new FTP(array[i]);
							iTP.Ftps.Add(item);
							break;
						}
						}
					}
				}
				catch (Exception ex)
				{
					string message = ex.Message;
				}
			}
		}
		catch (Exception ex2)
		{
			string message2 = ex2.Message;
		}
		int num4 = num;
		return iTP;
	}

	public static bool ChecarContratos(ITP itp, out string sucesso, out string erro)
	{
		bool result = true;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		EntidadeGPS entidadeGPS = ModuloEntidadesGPS.ObterEntidadeCadastradaNoCnpj(1, itp.Seq06);
		IList<TarifaProduto> source = Tarifa(entidadeGPS.Codigo);
		foreach (PE1 pe in itp.Pe1s)
		{
			string entrega = pe.Seq10;
			string seq = pe.Seq02;
			string seq2 = pe.Seq03;
			DateTime seq3 = pe.Seq04;
			string seq4 = pe.Seq05;
			string codigoItem = pe.Seq07;
			string tipoVenda = pe.Seq14;
			TarifaProduto tarifaProduto = source.Where((TarifaProduto c) => c.CodigoProdutoEntidade == codigoItem && (c.TipoVenda == tipoVenda || string.IsNullOrEmpty(c.TipoVenda)) && (c.PortaoEntrega == entrega || string.IsNullOrEmpty(c.PortaoEntrega))).FirstOrDefault();
			if (tarifaProduto != null && string.IsNullOrEmpty(tarifaProduto.TipoVenda) && !string.IsNullOrWhiteSpace(tipoVenda))
			{
				tarifaProduto.TipoVenda = tipoVenda;
				ModuloProduto.SalvarTarifaProduto(tarifaProduto);
			}
			if (tarifaProduto != null && string.IsNullOrEmpty(tarifaProduto.PortaoEntrega) && !string.IsNullOrWhiteSpace(entrega))
			{
				tarifaProduto.PortaoEntrega = entrega;
				ModuloProduto.SalvarTarifaProduto(tarifaProduto);
			}
			if (tarifaProduto != null && string.IsNullOrEmpty(tarifaProduto.CodigoContratoEntrega) && !string.IsNullOrWhiteSpace(pe.Seq09) && !(pe.Seq09.ToUpper() == "FORECAST"))
			{
				tarifaProduto.CodigoContratoEntrega = pe.Seq09;
				ModuloProduto.SalvarTarifaProduto(tarifaProduto);
			}
			if (tarifaProduto != null && tarifaProduto.CodigoPlanoEmbalagem == 0)
			{
				stringBuilder.AppendFormat("Informativo: PLANO DE EMBALAGEM NÃO ENCONTRADO. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3}", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega).AppendLine();
			}
			if (tarifaProduto == null)
			{
				if (pe.QdeProxMeses[0] > 0)
				{
					stringBuilder.AppendFormat("ERRO: Contrato Não Encontrado. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3} - Qde Prox 30 dias = {4}", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega, pe.QdeProxMeses[0]).AppendLine();
					result = false;
				}
				else if (pe.QdeProxMeses[1] > 0)
				{
					stringBuilder.AppendFormat("ERRO: Contrato Não Encontrado. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3} - Qde Prox 60 dias = {4}", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega, pe.QdeProxMeses[1]).AppendLine();
					result = false;
				}
				else if (pe.QdeProxMeses[2] > 0)
				{
					stringBuilder.AppendFormat("ERRO: Contrato Não Encontrado. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3} - Qde Prox 90 dias = {4}", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega, pe.QdeProxMeses[2]).AppendLine();
					result = false;
				}
				else if (pe.QdeProxMeses[3] > 0)
				{
					stringBuilder.AppendFormat("Atenção: Contrato Não Encontrado. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3} - Qde Prox 120 dias = {4}", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega, pe.QdeProxMeses[3]).AppendLine();
				}
				else if (pe.QdeProxMeses[4] > 0)
				{
					stringBuilder.AppendFormat("Atenção: Contrato Não Encontrado. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3} - Qde Após 120 dias = {4}", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega, pe.QdeProxMeses[4]).AppendLine();
				}
				else
				{
					stringBuilder.AppendFormat("Informativo: Contrato Não Encontrado. Cliente: {0} - Peça {1} - Tipo Venda: {2} - Portão: {3} - Sem Programação de Entrega", entidadeGPS.CodigoNomeFantasia, codigoItem, tipoVenda, entrega).AppendLine();
				}
			}
			else
			{
				IList<PedidoVendaItemGPS> list = ModuloVendasGPS.ObterItensPedidoEdi(entidadeGPS.Codigo, tarifaProduto.CodigoProdutoEntidade, tarifaProduto.PortaoEntrega, tarifaProduto.TipoVenda);
				if (list == null || list.Count == 0)
				{
					stringBuilder2.AppendFormat("ATENÇÃO: Contrato Encontrado. Cliente: {0} - Peça {1} {2} Portão: {3} Tipo Venda {4} - Plano Embalagem: {5} - {6} Pçs/Emb - PEDIDO NÃO ENCONTRADO.", entidadeGPS.CodigoNomeFantasia, codigoItem, tarifaProduto.DescricaoProdutoEntidade, tarifaProduto.PortaoEntrega, tarifaProduto.TipoVenda, tarifaProduto.CodigoEmbalagem, tarifaProduto.QdeProdutoEmbalagem).AppendLine();
				}
				else if (list != null && list.Count > 0)
				{
					int codigoPedido = list[0].CodigoPedido;
					int codigoItemPedido = list[0].CodigoItemPedido;
					stringBuilder2.AppendFormat("SUCESSO: Contrato Encontrado. Cliente: {0} - Peça {1} {2} Portão: {3} Tipo Venda {4} - Plano Embalagem: {5} - {6} Pçs/Emb - Pedido Venda: {7}/{8}-{9}", entidadeGPS.CodigoNomeFantasia, codigoItem, tarifaProduto.DescricaoProdutoEntidade, tarifaProduto.PortaoEntrega, tarifaProduto.TipoVenda, tarifaProduto.CodigoEmbalagem, tarifaProduto.QdeProdutoEmbalagem, codigoPedido, codigoItemPedido, tarifaProduto.TipoVenda).AppendLine();
				}
				else
				{
					stringBuilder2.AppendFormat("SUCESSO: Contrato Encontrado. Cliente: {0} - Peça {1} {2} Portão: {3} Tipo Venda {4} - Plano Embalagem: {5} - {6} Pçs/Emb - PEDIDO NÃO ENCONTRADO.", entidadeGPS.CodigoNomeFantasia, codigoItem, tarifaProduto.DescricaoProdutoEntidade, tarifaProduto.PortaoEntrega, tarifaProduto.TipoVenda, tarifaProduto.CodigoEmbalagem, tarifaProduto.QdeProdutoEmbalagem).AppendLine();
				}
			}
		}
		erro = stringBuilder.ToString();
		sucesso = stringBuilder2.ToString();
		return result;
	}

	public static IList<EdiRelease> GerarEdiRelease(ITP itp, out string sucesso, out string erro, out Dictionary<int, List<int>> programasTratado)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		erro = string.Empty;
		sucesso = string.Empty;
		bool flag = false;
		programasTratado = new Dictionary<int, List<int>>();
		IList<EdiRelease> list = new List<EdiRelease>();
		if (!ChecarContratos(itp, out sucesso, out erro))
		{
			stringBuilder.AppendFormat("ERRO na Checagem de Contratos").AppendLine();
			stringBuilder.AppendFormat(erro);
		}
		else
		{
			stringBuilder2.AppendFormat("SUCESSO na Checagem de Contratos").AppendLine();
			stringBuilder2.AppendFormat(sucesso).AppendLine().AppendLine();
		}
		stringBuilder2.AppendLine("----------------------------------------------------").AppendLine().AppendLine();
		stringBuilder2.AppendFormat("INÍCIO TRATAMENTO PROGRAMA").AppendLine();
		EntidadeGPS entidadeGPS = ModuloEntidadesGPS.ObterEntidadeCadastradaNoCnpj(1, itp.Seq06);
		flag = entidadeGPS.CodigoTipoTratamentoEdi > EnumTipoTratamentoEDI.Diferencial;
		EnumTipoTratamentoEDI codigoTipoTratamentoEdi = entidadeGPS.CodigoTipoTratamentoEdi;
		IList<TarifaProduto> source = Tarifa(entidadeGPS.Codigo);
		foreach (PE1 pe in itp.Pe1s)
		{
			string seq = pe.Seq02;
			string seq2 = pe.Seq03;
			DateTime seq3 = pe.Seq04;
			string seq4 = pe.Seq05;
			string codigoItem = pe.Seq07;
			if (pe.Seq07 == "941009060405")
			{
				string text = "";
			}
			string entrega = pe.Seq10;
			string tipoVenda = pe.Seq14;
			string seq5 = pe.Seq09;
			TarifaProduto tarifa = source.Where((TarifaProduto c) => c.CodigoProdutoEntidade == codigoItem && c.TipoVenda == tipoVenda && c.PortaoEntrega == entrega).FirstOrDefault();
			if (tarifa == null)
			{
				continue;
			}
			string seq6 = pe.Seq08;
			string seq7 = pe.Seq11;
			string seq8 = pe.Seq12;
			int seq9 = pe.Seq13;
			string seq10 = pe.Seq14;
			bool isPedidoNovo = false;
			if (!(seq5 == "FORECAST") && tarifa.CodigoContratoEntrega != seq5)
			{
				stringBuilder.AppendFormat("Contrato Entrega Peça: {0} Ajustado de {1} para {2}", codigoItem, tarifa.CodigoContratoEntrega, seq5).AppendLine();
				tarifa.CodigoContratoEntrega = seq5;
				tarifa.CodigoContratoEntregaItem = 0;
				ModuloProduto.SalvarTarifaProduto(tarifa);
			}
			if (!string.IsNullOrWhiteSpace(entrega) && string.IsNullOrWhiteSpace(tarifa.PortaoEntrega) && !tarifa.PortaoEntrega.Equals(entrega))
			{
				tarifa.PortaoEntrega = entrega;
				ModuloProduto.SalvarTarifaProduto(tarifa);
			}
			IList<PedidoVendaItemGPS> list2 = ModuloVendasGPS.ObterItensPedidoEdi(entidadeGPS.Codigo, tarifa.CodigoProdutoEntidade, tarifa.PortaoEntrega, tarifa.TipoVenda);
			PedidoVendaItemGPS itemPv = new PedidoVendaItemGPS();
			if (list2 == null || list2.Count == 0)
			{
				IList<PedidoVendaGPS> source2 = ModuloVendasGPS.ObterPedidosVendaporCliente(entidadeGPS.Codigo);
				PedidoVendaGPS pedidoVendaGPS = (from c in source2
					where c.DocaEntrega == tarifa.PortaoEntrega && (c.IsEdi || c.Descricao == "EDI")
					orderby c.CodigoPedidoVenda descending
					select c).FirstOrDefault();
				if (pedidoVendaGPS == null)
				{
					pedidoVendaGPS = new PedidoVendaGPS();
					pedidoVendaGPS.EntidadeRef = entidadeGPS;
					pedidoVendaGPS.DataCriacao = DateTime.Today;
					pedidoVendaGPS.DataPedido = DateTime.Today;
					pedidoVendaGPS.DocaEntrega = entrega;
					pedidoVendaGPS.Descricao = "EDI";
					pedidoVendaGPS.ReferenciaPedido = pe.Seq09;
					pedidoVendaGPS.IsEdi = true;
					ModuloVendasGPS.InserirPedidoVenda(pedidoVendaGPS);
					stringBuilder.AppendFormat("Pedido Não Encontrado, Cadastrado novo pedido venda. Cliente: {0} - Pedido {1}", entidadeGPS.CodigoNomeFantasia, pedidoVendaGPS.CodigoPedidoVenda).AppendLine();
				}
				else if (!pedidoVendaGPS.IsEdi)
				{
					pedidoVendaGPS.IsEdi = true;
					ModuloVendasGPS.AlterarPedidoVenda(pedidoVendaGPS, pedidoVendaGPS.PropriedadesModificadas);
				}
				PedidoVendaItemGPS pedidoVendaItemGPS = new PedidoVendaItemGPS();
				isPedidoNovo = true;
				pedidoVendaItemGPS.CodigoPedido = pedidoVendaGPS.CodigoPedidoVenda;
				pedidoVendaItemGPS.CodigoItemPedido = pedidoVendaGPS.ProximoNumeroItem;
				pedidoVendaItemGPS.CodigoClientePedido = pedidoVendaGPS.CodigoEntidade;
				pedidoVendaItemGPS.TipoVenda = tipoVenda;
				pedidoVendaItemGPS.EstoqueRef = tarifa.EstoqueRef;
				pedidoVendaItemGPS.Comentario = tarifa.EstoqueRef.Comentario;
				pedidoVendaItemGPS.ClassificacaoFiscal = tarifa.EstoqueRef.ClassificacaoFiscal;
				if (string.IsNullOrEmpty(pedidoVendaItemGPS.ComentarioAdicionalItem) && !string.IsNullOrEmpty(tarifa.EstoqueRef.ComentarioLongo))
				{
					pedidoVendaItemGPS.ComentarioAdicionalItem = tarifa.EstoqueRef.ComentarioLongo;
				}
				pedidoVendaItemGPS.TarifaRef = tarifa;
				pedidoVendaItemGPS.CodigoPecaExterno = tarifa.CodigoProdutoEntidade;
				pedidoVendaItemGPS.DescricaoPecaExterna = tarifa.DescricaoProdutoEntidade;
				pedidoVendaItemGPS.PrecoUnitarioBruto = tarifa.PrecoTarifaCatalogo;
				pedidoVendaItemGPS.ValorUnitarioFaturamento = tarifa.ValorUnitarioFaturamento;
				pedidoVendaItemGPS.CodigoImpostoVenda = tarifa.CodigoCfopInterna;
				pedidoVendaItemGPS.ItensPorEmbalagem = ((tarifa.QdeProdutoEmbalagem > 0) ? tarifa.QdeProdutoEmbalagem : 0);
				pedidoVendaItemGPS.CodigoEmbalagem = tarifa.CodigoEmbalagem;
				pedidoVendaItemGPS.ChaveEmbalagemRef = tarifa.ChaveEmbalagemRef;
				pedidoVendaItemGPS.GaragemEntregaEdi = entrega;
				pedidoVendaItemGPS.SiglaFaturamento = tarifa.SiglaUnidadeFaturamento;
				if (tarifa.CodigoUnidadeComprado > 0)
				{
					pedidoVendaItemGPS.Unidade = tarifa.CodigoUnidadeComprado;
					UnidadePedido unidadePedido = ModuloProduto.ObterUnidadePedido(2, tarifa.CodigoUnidadeComprado);
					if (unidadePedido != null)
					{
						pedidoVendaItemGPS.CoeficienteProdução = unidadePedido.Coeficiente;
					}
				}
				pedidoVendaGPS.Itens.Add(pedidoVendaItemGPS);
				ModuloVendasGPS.SalvarPedidoVendaItem(pedidoVendaItemGPS);
				itemPv = pedidoVendaItemGPS;
				stringBuilder.AppendFormat("Item Pedido Não Encontrado, Cadastrado Novo. Cliente: {0} - Pedido {1}/{2} - {3}", entidadeGPS.CodigoNomeFantasia, pedidoVendaGPS.CodigoPedidoVenda, pedidoVendaItemGPS.CodigoItemPedido, pedidoVendaItemGPS.CodigoProduto).AppendLine();
			}
			else if (list2 != null && list2.Count > 0)
			{
				itemPv = list2[0];
			}
			if (flag)
			{
				if (!programasTratado.ContainsKey(itemPv.CodigoPedido))
				{
					programasTratado.Add(itemPv.CodigoPedido, new List<int>());
				}
				programasTratado[itemPv.CodigoPedido].Add(itemPv.CodigoItemPedido);
			}
			EdiRelease ediRelease = new EdiRelease();
			bool flag2 = false;
			if (seq5.ToUpper() == "FORECAST")
			{
				EdiRelease ediRelease2 = list.Where((EdiRelease c) => c.CodigoPedido == itemPv.CodigoPedido && c.CodigoPedidoItem == itemPv.CodigoItemPedido).FirstOrDefault();
				if (ediRelease2 != null)
				{
					ediRelease = ediRelease2;
					flag2 = true;
				}
			}
			ediRelease.DataCadastro = seq3;
			ediRelease.CodigoCliente = entidadeGPS.Codigo;
			ediRelease.CodigoPedido = itemPv.CodigoPedido;
			ediRelease.CodigoPedidoItem = itemPv.CodigoItemPedido;
			ediRelease.CodigoRelease = seq2;
			ediRelease.NotaFiscalCorte = 0;
			ediRelease.CodigoContrato = seq5;
			ediRelease.DescricaoPeca = tarifa.DescricaoProdutoEntidade;
			ediRelease.NomeArquivo = itp.NomeArquvio;
			ediRelease.IsPedidoNovo = isPedidoNovo;
			foreach (PE2 pe2 in pe.Pe2s)
			{
				ediRelease.DataNotaCorte = pe2.Seq02;
				ediRelease.NotaFiscalCorte = pe2.Seq03;
				ediRelease.QuantidadeEntregueNotaCorte = (int)pe2.Seq06;
				ediRelease.QuantidadeAcumuladaAposNotaCorte = (int)QuantidadeEntregueAposNotaCorte(ediRelease.CodigoPedido, ediRelease.CodigoPedidoItem, ediRelease.NotaFiscalCorte);
				int num = (int)pe2.Seq07;
				string seq11 = pe2.Seq18;
			}
			foreach (PE3 itemP3 in pe.Pe3s)
			{
				EdiReleaseCadencia ediReleaseCadencia = null;
				if (itemP3.Seq04 > 0)
				{
					ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq02).FirstOrDefault();
					if (ediReleaseCadencia == null)
					{
						ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = seq5;
						ediReleaseCadencia.DataEntrega = itemP3.Seq02;
						ediReleaseCadencia.Quantidade = itemP3.Seq04;
						if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
						{
							ediReleaseCadencia.IsFirme = true;
						}
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
						{
							ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq04;
						}
						if (ediReleaseCadencia.Quantidade > 0)
						{
							ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						}
					}
					else
					{
						ediReleaseCadencia.Quantidade += itemP3.Seq04;
					}
				}
				if (itemP3.Seq07 > 0)
				{
					ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq05).FirstOrDefault();
					if (ediReleaseCadencia == null)
					{
						ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = seq5;
						ediReleaseCadencia.DataEntrega = itemP3.Seq05;
						ediReleaseCadencia.Quantidade = itemP3.Seq07;
						if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
						{
							ediReleaseCadencia.IsFirme = true;
						}
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
						{
							ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq07;
						}
						if (ediReleaseCadencia.Quantidade > 0)
						{
							ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						}
					}
					else
					{
						ediReleaseCadencia.Quantidade += itemP3.Seq07;
					}
				}
				if (itemP3.Seq10 > 0)
				{
					ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq08).FirstOrDefault();
					if (ediReleaseCadencia == null)
					{
						ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = seq5;
						ediReleaseCadencia.DataEntrega = itemP3.Seq08;
						ediReleaseCadencia.Quantidade = itemP3.Seq10;
						if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
						{
							ediReleaseCadencia.IsFirme = true;
						}
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
						{
							ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq10;
						}
						if (ediReleaseCadencia.Quantidade > 0)
						{
							ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						}
					}
					else
					{
						ediReleaseCadencia.Quantidade += itemP3.Seq10;
					}
					ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq11).FirstOrDefault();
				}
				if (itemP3.Seq13 > 0)
				{
					if (ediReleaseCadencia == null)
					{
						ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = seq5;
						ediReleaseCadencia.DataEntrega = itemP3.Seq11;
						ediReleaseCadencia.Quantidade = itemP3.Seq13;
						if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
						{
							ediReleaseCadencia.IsFirme = true;
						}
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
						{
							ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq13;
						}
						if (ediReleaseCadencia.Quantidade > 0)
						{
							ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						}
					}
					else
					{
						ediReleaseCadencia.Quantidade += itemP3.Seq13;
					}
				}
				if (itemP3.Seq16 > 0)
				{
					ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq14).FirstOrDefault();
					if (ediReleaseCadencia == null)
					{
						ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = seq5;
						ediReleaseCadencia.DataEntrega = itemP3.Seq14;
						ediReleaseCadencia.Quantidade = itemP3.Seq16;
						if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
						{
							ediReleaseCadencia.IsFirme = true;
						}
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
						{
							ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq16;
						}
						if (ediReleaseCadencia.Quantidade > 0)
						{
							ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						}
					}
					else
					{
						ediReleaseCadencia.Quantidade += itemP3.Seq16;
					}
				}
				if (itemP3.Seq19 > 0)
				{
					ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq17).FirstOrDefault();
					if (ediReleaseCadencia == null)
					{
						ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = seq5;
						ediReleaseCadencia.DataEntrega = itemP3.Seq17;
						ediReleaseCadencia.Quantidade = itemP3.Seq19;
						if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
						{
							ediReleaseCadencia.IsFirme = true;
						}
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
						{
							ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq19;
						}
						if (ediReleaseCadencia.Quantidade > 0)
						{
							ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						}
					}
					else
					{
						ediReleaseCadencia.Quantidade += itemP3.Seq19;
					}
				}
				if (itemP3.Seq22 <= 0)
				{
					continue;
				}
				ediReleaseCadencia = ediRelease.CadenciasRef.Where((EdiReleaseCadencia c) => c.DataEntrega == itemP3.Seq20).FirstOrDefault();
				if (ediReleaseCadencia == null)
				{
					ediReleaseCadencia = new EdiReleaseCadencia();
					ediReleaseCadencia.ContratoEntrega = seq5;
					ediReleaseCadencia.DataEntrega = itemP3.Seq20;
					ediReleaseCadencia.Quantidade = itemP3.Seq22;
					if (ediReleaseCadencia.DataEntrega < seq3.AddDays(30.0))
					{
						ediReleaseCadencia.IsFirme = true;
					}
					ediReleaseCadencia.IdRelease = ediRelease.Id;
					if (itemP3.Pe5s != null && itemP3.Pe5s.Count > 0)
					{
						ediReleaseCadencia.ChamadaKanban = itemP3.Pe5s[0].Seq22;
					}
					if (ediReleaseCadencia.Quantidade > 0)
					{
						ediRelease.CadenciasRef.Add(ediReleaseCadencia);
					}
				}
				else
				{
					ediReleaseCadencia.Quantidade += itemP3.Seq22;
				}
			}
			ModuloEdiProgEntrega.SalvarEdiRelease(ediRelease);
			if (!flag2)
			{
				list.Add(ediRelease);
			}
		}
		stringBuilder2.AppendFormat("FIM TRATAMENTO PROGRAMA").AppendLine();
		erro = stringBuilder.ToString();
		sucesso = stringBuilder2.ToString();
		if (codigoTipoTratamentoEdi == EnumTipoTratamentoEDI.ProgramaCompleto)
		{
			foreach (KeyValuePair<int, List<int>> item in programasTratado)
			{
				PedidoVendaGPS pedidoVendaGPS2 = ModuloVendasGPS.ObterPedidoVenda(item.Key);
				IList<int> value = item.Value;
				foreach (PedidoVendaItemGPS iten in pedidoVendaGPS2.Itens)
				{
					if (!value.Contains(iten.CodigoItemPedido))
					{
						EdiRelease ediRelease3 = new EdiRelease();
						ediRelease3.DataCadastro = DateTime.Today;
						ediRelease3.CodigoCliente = pedidoVendaGPS2.CodigoEntidade;
						ediRelease3.CodigoPedido = iten.CodigoPedido;
						ediRelease3.CodigoPedidoItem = iten.CodigoItemPedido;
						ediRelease3.CodigoRelease = "";
						ediRelease3.NotaFiscalCorte = 0;
						ediRelease3.CodigoContrato = "";
						ediRelease3.DescricaoPeca = iten.DescricaoPecaExterna;
						ediRelease3.NomeArquivo = "Não Programado";
						ediRelease3.IsPedidoNovo = false;
						EdiReleaseCadencia ediReleaseCadencia2 = new EdiReleaseCadencia();
						ediReleaseCadencia2.ContratoEntrega = "";
						ediReleaseCadencia2.DataEntrega = DateTime.Today;
						ediReleaseCadencia2.Quantidade = 0;
						ediReleaseCadencia2.IdRelease = ediRelease3.Id;
						ediRelease3.CadenciasRef.Add(ediReleaseCadencia2);
						ModuloEdiProgEntrega.SalvarEdiRelease(ediRelease3);
						list.Add(ediRelease3);
					}
				}
			}
			programasTratado.Clear();
		}
		return list;
	}

	public static void TratarProgramaEDI(EdiRelease release)
	{
		PedidoVendaItemGPS pedidoVendaItemGPS = ModuloVendasGPS.ObterPedidoVendaItem(release.CodigoPedido, release.CodigoPedidoItem);
		if (pedidoVendaItemGPS == null)
		{
			return;
		}
		int num = (release.QuantidadeAcumuladaAposNotaCorte = (int)QuantidadeEntregueAposNotaCorte(release.CodigoPedido, release.CodigoPedidoItem, release.NotaFiscalCorte));
		IList<PedidoVendaItemCadenciaGPS> cadenciasAEntregar = pedidoVendaItemGPS.CadenciasAEntregar;
		IDictionary<DateTime, int> dictionary = new Dictionary<DateTime, int>();
		foreach (PedidoVendaItemCadenciaGPS item in cadenciasAEntregar)
		{
			int num3 = item.QuantidadeFaltaEntregar * -1;
			if (dictionary.ContainsKey(item.DataEntrega))
			{
				dictionary[item.DataEntrega] += num3;
			}
			else
			{
				dictionary.Add(item.DataEntrega, num3);
			}
			if (item.QuantidadeEntregue == 0)
			{
				item.IsExcluir = true;
			}
			else
			{
				item.QuantidadeCadencia = item.QuantidadeEntregue;
			}
		}
		pedidoVendaItemGPS.DataMateria2 = DateTime.Today;
		ModuloVendasGPS.SalvarPedidoVendaItem(pedidoVendaItemGPS);
		foreach (EdiReleaseCadencia item2 in release.CadenciasRef)
		{
			if (num > 0)
			{
				if (num > item2.Quantidade)
				{
					num -= item2.Quantidade;
					item2.Quantidade = 0;
					item2.IsExcluir = true;
				}
				else
				{
					item2.Quantidade -= num;
					num = 0;
					if (item2.Quantidade <= 0)
					{
						item2.IsExcluir = true;
					}
				}
			}
			if (item2.Quantidade > 0)
			{
				if (dictionary.ContainsKey(item2.DataEntrega))
				{
					dictionary[item2.DataEntrega] += item2.Quantidade;
				}
				else
				{
					dictionary.Add(item2.DataEntrega, item2.Quantidade);
				}
				PedidoVendaItemCadenciaGPS pedidoVendaItemCadenciaGPS = new PedidoVendaItemCadenciaGPS();
				pedidoVendaItemCadenciaGPS.DataCadastro = release.DataCadastro;
				pedidoVendaItemCadenciaGPS.DataCriacao = DateTime.Today;
				pedidoVendaItemCadenciaGPS.DataEntrega = item2.DataEntrega;
				pedidoVendaItemCadenciaGPS.CodigoContrato = item2.ContratoEntrega;
				pedidoVendaItemCadenciaGPS.ReferenciaChamadaKanban = item2.ChamadaKanban;
				pedidoVendaItemCadenciaGPS.QuantidadeCadencia = item2.Quantidade;
				pedidoVendaItemCadenciaGPS.Necessidade = 1m;
				pedidoVendaItemCadenciaGPS.DataPreparacao = DateTime.Today;
				pedidoVendaItemCadenciaGPS.EdiPedidoFirme = item2.IsFirme;
				pedidoVendaItemGPS.Cadencias.Add(pedidoVendaItemCadenciaGPS);
			}
		}
		ModuloVendasGPS.SalvarPedidoVendaItem(pedidoVendaItemGPS);
		foreach (KeyValuePair<DateTime, int> item3 in dictionary)
		{
			EdiReleaseTratamento ediReleaseTratamento = new EdiReleaseTratamento();
			ediReleaseTratamento.DataAjuste = item3.Key;
			ediReleaseTratamento.IdRelease = release.Id;
			if (item3.Value > 0)
			{
				ediReleaseTratamento.QuantidadeAdicionada = item3.Value;
			}
			else
			{
				ediReleaseTratamento.QuantidadeRemovida = item3.Value * -1;
			}
			release.TratamentoRef.Add(ediReleaseTratamento);
		}
		release.IsTratado = true;
		ModuloEdiProgEntrega.SalvarEdiRelease(release);
	}

	public static void TratarProgramaEDI(IList<EdiRelease> releases, Dictionary<int, List<int>> programasTratado)
	{
		if (releases == null)
		{
			return;
		}
		if (programasTratado != null && programasTratado.Count > 0)
		{
			foreach (KeyValuePair<int, List<int>> item in programasTratado)
			{
				PedidoVendaGPS pedidoVendaGPS = ModuloVendasGPS.ObterPedidoVenda(item.Key);
				IList<int> value = item.Value;
				foreach (PedidoVendaItemGPS iten in pedidoVendaGPS.Itens)
				{
					if (!value.Contains(iten.CodigoItemPedido))
					{
						EdiRelease ediRelease = new EdiRelease();
						ediRelease.DataCadastro = DateTime.Today;
						ediRelease.CodigoCliente = pedidoVendaGPS.CodigoEntidade;
						ediRelease.CodigoPedido = iten.CodigoPedido;
						ediRelease.CodigoPedidoItem = iten.CodigoItemPedido;
						ediRelease.CodigoRelease = "";
						ediRelease.NotaFiscalCorte = 0;
						ediRelease.CodigoContrato = "";
						ediRelease.DescricaoPeca = iten.DescricaoPecaExterna;
						ediRelease.NomeArquivo = "Não Programado";
						ediRelease.IsPedidoNovo = false;
						EdiReleaseCadencia ediReleaseCadencia = new EdiReleaseCadencia();
						ediReleaseCadencia.ContratoEntrega = "";
						ediReleaseCadencia.DataEntrega = DateTime.Today;
						ediReleaseCadencia.Quantidade = 0;
						ediReleaseCadencia.IdRelease = ediRelease.Id;
						ediRelease.CadenciasRef.Add(ediReleaseCadencia);
						ModuloEdiProgEntrega.SalvarEdiRelease(ediRelease);
						releases.Add(ediRelease);
					}
				}
			}
		}
		IList<int> list = new List<int>();
		foreach (EdiRelease release in releases)
		{
			if (!list.Contains(release.CodigoPedido))
			{
				list.Add(release.CodigoPedido);
			}
			TratarProgramaEDI(release);
		}
		foreach (int item2 in list)
		{
			PedidoVendaGPS pedidoVenda = ModuloVendasGPS.ObterPedidoVenda(item2);
			ModuloVendasGPS.SalvarPedidoVenda(pedidoVenda);
		}
	}

	public static IList<EdiRelease> TratamentoAutomaticoEDI(out string sucesso, out string erro)
	{
		sucesso = string.Empty;
		erro = string.Empty;
		IList<EdiRelease> list = new List<EdiRelease>();
		string valor = ModuloParametros.ObterGestaoServicos(905).Valor01;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder.AppendLine("****************************************************************");
		stringBuilder.AppendLine("Inicio Tratamento Programas EDI");
		stringBuilder.AppendLine(DateTime.Now.ToString());
		stringBuilder.AppendLine("****************************************************************");
		IList<EdiRelease> list2 = new List<EdiRelease>();
		if (Directory.Exists(valor))
		{
			string[] directories = Directory.GetDirectories(valor);
			string[] array = directories;
			foreach (string text in array)
			{
				if (text.Contains("Relatorios"))
				{
					continue;
				}
				Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
				list2 = new List<EdiRelease>();
				string text2 = $"{text}\\Importados";
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				IOrderedEnumerable<string> orderedEnumerable = from f in Directory.GetFiles(text)
					orderby f
					select f;
				foreach (string item in orderedEnumerable)
				{
					stringBuilder.AppendLine($"Lendo arquivo: {item.Split('\\').Last()}");
					try
					{
						ITP iTP = CarregarRND001V6(item);
						if (iTP == null)
						{
							continue;
						}
						string sucesso2;
						string erro2;
						Dictionary<int, List<int>> programasTratado;
						IList<EdiRelease> list3 = GerarEdiRelease(iTP, out sucesso2, out erro2, out programasTratado);
						if (!string.IsNullOrWhiteSpace(erro2))
						{
							stringBuilder2.AppendLine($"Falta tratando arquivo: {item}");
							stringBuilder2.AppendLine(erro2).AppendLine();
						}
						stringBuilder.AppendLine(sucesso2);
						if (list3 != null && list3.Count > 0)
						{
							foreach (EdiRelease item2 in list3)
							{
								list2.Add(item2);
							}
						}
						if (programasTratado.Count > 0)
						{
							foreach (KeyValuePair<int, List<int>> item3 in programasTratado)
							{
								if (!dictionary.ContainsKey(item3.Key))
								{
									dictionary.Add(item3.Key, item3.Value);
									continue;
								}
								foreach (int item4 in item3.Value)
								{
									if (!dictionary[item3.Key].Contains(item4))
									{
										dictionary[item3.Key].Add(item4);
									}
								}
							}
						}
						string text3 = item.Replace(text, text2);
						if (File.Exists(text3))
						{
							File.Delete(item);
						}
						else
						{
							File.Move(item, text3);
						}
					}
					catch
					{
						stringBuilder2.AppendLine($"Erro Lendo arquivo: {item}");
					}
				}
				TratarProgramaEDI(list2, dictionary);
				List<EdiRelease> list4 = (from c in list2
					where c.PossuiDadosRelatorio
					orderby c.CodigoPedido, c.CodigoPedidoItem, c.CodigoRelease
					select c).ToList();
				orderedEnumerable = null;
				text2 = null;
				stringBuilder.AppendLine("****************************************************************");
				stringBuilder.AppendLine("Termino Tratamento Programas EDI");
				stringBuilder.AppendLine("****************************************************************");
				sucesso = stringBuilder.ToString();
				erro = stringBuilder2.ToString();
				foreach (EdiRelease item5 in list4)
				{
					list.Add(item5);
				}
			}
			return list;
		}
		stringBuilder2.AppendLine($"Diretório {valor} não encontrado");
		sucesso = stringBuilder.ToString();
		erro = stringBuilder2.ToString();
		return null;
	}

	public static bool AnaliseAutomaticoEDI(out string sucesso, out string erro)
	{
		bool result = true;
		sucesso = string.Empty;
		erro = string.Empty;
		string valor = ModuloParametros.ObterGestaoServicos(905).Valor01;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder.AppendLine("****************************************************************");
		stringBuilder.AppendLine("Inicio Tratamento Programas EDI");
		stringBuilder.AppendLine(DateTime.Now.ToString());
		stringBuilder.AppendLine("****************************************************************");
		IList<EdiRelease> list = new List<EdiRelease>();
		if (Directory.Exists(valor))
		{
			string[] directories = Directory.GetDirectories(valor);
			string[] array = directories;
			foreach (string path in array)
			{
				IOrderedEnumerable<string> orderedEnumerable = from f in Directory.GetFiles(path)
					orderby f
					select f;
				foreach (string item in orderedEnumerable)
				{
					stringBuilder.AppendLine($"Lendo arquivo: {item.Split('\\').Last()}");
					try
					{
						ITP iTP = CarregarRND001V6(item);
						if (iTP != null)
						{
							if (!ChecarContratos(iTP, out var sucesso2, out var erro2))
							{
								result = false;
							}
							if (!string.IsNullOrWhiteSpace(erro2))
							{
								stringBuilder2.AppendLine($"Falta tratando arquivo: {item}");
								stringBuilder2.AppendLine(erro2).AppendLine();
							}
							stringBuilder.AppendLine(sucesso2);
						}
					}
					catch
					{
						stringBuilder2.AppendLine($"Erro Lendo arquivo: {item}");
					}
				}
				orderedEnumerable = null;
				stringBuilder.AppendLine("****************************************************************");
				stringBuilder.AppendLine("Termino Analisando Programas EDI");
				stringBuilder.AppendLine("****************************************************************");
				sucesso = stringBuilder.ToString();
				erro = stringBuilder2.ToString();
			}
		}
		else
		{
			stringBuilder2.AppendLine($"Diretório {valor} não encontrado");
			sucesso = stringBuilder.ToString();
			erro = stringBuilder2.ToString();
		}
		return result;
	}
}
