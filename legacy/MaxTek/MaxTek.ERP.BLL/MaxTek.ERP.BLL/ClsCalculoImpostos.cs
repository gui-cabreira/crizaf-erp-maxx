using System;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

public class ClsCalculoImpostos
{
	private EnumFinalidadeNotaFiscal Finalidade { get; set; }

	private string CodigoModalidadeIcms { get; set; }

	private bool IsConsumidorFinal { get; set; }

	private decimal ValorUnitario { get; set; }

	private decimal Quantidade { get; set; }

	private decimal ValorSeguro { get; set; }

	private decimal ValorFrete { get; set; }

	private decimal ValorOutros { get; set; }

	private decimal ValorTotal { get; set; }

	private decimal ValorFatura { get; set; }

	private decimal PercentualII { get; set; }

	private decimal ValorBaseCalculoImpostoImportacao { get; set; }

	private decimal ValorImpostoImportacao { get; set; }

	private decimal ValorBaseCalculoPis { get; set; }

	private decimal ValorPIS { get; set; }

	private decimal AliquotaPis { get; set; }

	private string TipoIncidenciaPis { get; set; }

	private decimal ValorRetencaoPis { get; set; }

	private decimal PercentualRetencaoPis { get; set; }

	private decimal ValorBaseCalculoCofins { get; set; }

	private decimal ValorCofins { get; set; }

	private decimal AliquotaCofins { get; set; }

	private string TipoIncidenciaCofins { get; set; }

	private decimal ValorRetencaoCofins { get; set; }

	private decimal PercentualRetencaoCofins { get; set; }

	private decimal ValorBaseCalculoIpi { get; set; }

	private decimal ValorIPI { get; set; }

	private decimal AliquotaIPI { get; set; }

	private string TipoIncidenciaIpi { get; set; }

	private decimal ValorBaseICMS { get; set; }

	private decimal ValorSiscomex { get; set; }

	private decimal ValorMarinhaMercante { get; set; }

	private decimal AliquotaICMS { get; set; }

	private decimal PercentualBaseReducaoIcms { get; set; }

	private decimal ValorICMS { get; set; }

	private decimal ValorBaseReducaoSemFrete { get; set; }

	private decimal PercentualCreditoIcms { get; set; }

	private decimal ValorCreditoIcms { get; set; }

	private decimal ValorBaseAgragadaICMSST { get; set; }

	private decimal PercentualReducaoBaseCalculoICMSST { get; set; }

	private decimal PercentualBaseAgragadaICMSST { get; set; }

	private decimal PercentualICMSSTAgregado { get; set; }

	private decimal ValorICMSSTAgregado { get; set; }

	private bool IsICMSInterestadual { get; set; }

	private decimal ValorIcmsInterestadualFundoPobreza { get; set; }

	private decimal PercentualIcmsInterestadualFundoPobreza { get; set; }

	private decimal ValorIcmsInterestadualUfDestino { get; set; }

	private decimal ValorIcmsInterestadualUfEnvolvidas { get; set; }

	private decimal PercentualIcmsInterestadualUfDestino { get; set; }

	private decimal PercentualIcmsInterestadualUfEnvolvidas { get; set; }

	private int CodigoModalidadeICMSST { get; set; }

	private decimal ValorCsll { get; set; }

	private decimal PercentualCsll { get; set; }

	private string CodigoSituacaoTributaria { get; set; }

	private string NomeCfop { get; set; }

	private string CodigoOrigemProduto { get; set; }

	private string TipoIncidenciaIcms { get; set; }

	private bool IsGeraDuplicata { get; set; }

	private bool IsCsll { get; set; }

	public ClsCalculoImpostos(NotaFiscalNotasFiscaisItens itenNotaFiscal)
	{
		Finalidade = EnumFinalidadeNotaFiscal.Normal;
		IsConsumidorFinal = itenNotaFiscal.IsConsumidorFinal;
		ValorUnitario = itenNotaFiscal.ValorUnitario;
		Quantidade = itenNotaFiscal.Quantidade;
		ValorSeguro = itenNotaFiscal.ValorSeguro;
		ValorFrete = itenNotaFiscal.ValorFrete;
		ValorOutros = itenNotaFiscal.ValorOutros;
		ValorTotal = itenNotaFiscal.ValorTotal;
		ValorFatura = itenNotaFiscal.ValorFatura;
		PercentualII = itenNotaFiscal.PercentualII;
		ValorBaseCalculoImpostoImportacao = itenNotaFiscal.ValorBaseCalculoImpostoImportacao;
		ValorImpostoImportacao = itenNotaFiscal.ValorImpostoImportacao;
		ValorBaseCalculoPis = itenNotaFiscal.ValorBaseCalculoPis;
		ValorPIS = itenNotaFiscal.ValorPIS;
		AliquotaPis = itenNotaFiscal.AliquotaPis;
		TipoIncidenciaPis = itenNotaFiscal.TipoIncidenciaPis;
		ValorRetencaoPis = itenNotaFiscal.ValorRetencaoPis;
		PercentualRetencaoPis = itenNotaFiscal.PercentualRetencaoPis;
		ValorBaseCalculoCofins = itenNotaFiscal.ValorBaseCalculoCofins;
		ValorCofins = itenNotaFiscal.ValorCofins;
		AliquotaCofins = itenNotaFiscal.AliquotaCofins;
		TipoIncidenciaCofins = itenNotaFiscal.TipoIncidenciaCofins;
		ValorRetencaoCofins = itenNotaFiscal.ValorRetencaoCofins;
		PercentualRetencaoCofins = itenNotaFiscal.PercentualRetencaoCofins;
		ValorBaseCalculoIpi = itenNotaFiscal.ValorBaseCalculoIpi;
		ValorIPI = itenNotaFiscal.ValorIPI;
		AliquotaIPI = itenNotaFiscal.AliquotaIPI;
		ValorBaseICMS = itenNotaFiscal.ValorBaseICMS;
		ValorSiscomex = itenNotaFiscal.ValorSiscomex;
		ValorMarinhaMercante = itenNotaFiscal.ValorMarinhaMercante;
		AliquotaICMS = itenNotaFiscal.AliquotaICMS;
		PercentualBaseReducaoIcms = itenNotaFiscal.PercentualBaseReducaoIcms;
		ValorICMS = itenNotaFiscal.ValorICMS;
		ValorBaseReducaoSemFrete = itenNotaFiscal.ValorBaseReducaoSemFrete;
		PercentualCreditoIcms = itenNotaFiscal.PercentualCreditoIcms;
		ValorCreditoIcms = itenNotaFiscal.ValorCreditoIcms;
		ValorBaseAgragadaICMSST = itenNotaFiscal.ValorBaseAgragadaICMSST;
		PercentualBaseAgragadaICMSST = itenNotaFiscal.PercentualBaseAgragadaICMSST;
		PercentualReducaoBaseCalculoICMSST = itenNotaFiscal.PercentualReducaoBaseCalculoICMSST;
		PercentualICMSSTAgregado = itenNotaFiscal.PercentualICMSSTAgregado;
		ValorICMSSTAgregado = itenNotaFiscal.ValorICMSSTAgregado;
		IsICMSInterestadual = itenNotaFiscal.IsICMSInterestadual;
		ValorIcmsInterestadualFundoPobreza = itenNotaFiscal.ValorIcmsInterestadualFundoPobreza;
		PercentualIcmsInterestadualFundoPobreza = itenNotaFiscal.PercentualIcmsInterestadualFundoPobreza;
		ValorIcmsInterestadualUfDestino = itenNotaFiscal.ValorIcmsInterestadualUfDestino;
		ValorIcmsInterestadualUfEnvolvidas = itenNotaFiscal.ValorIcmsInterestadualUfEnvolvidas;
		PercentualIcmsInterestadualUfDestino = itenNotaFiscal.PercentualIcmsInterestadualUfDestino;
		PercentualIcmsInterestadualUfEnvolvidas = itenNotaFiscal.PercentualIcmsInterestadualUfEnvolvidas;
		ValorCsll = itenNotaFiscal.ValorCsll;
		PercentualCsll = itenNotaFiscal.PercentualCsll;
		CodigoSituacaoTributaria = itenNotaFiscal.CodigoSituacaoTributaria;
		NomeCfop = itenNotaFiscal.NomeCfop;
		CodigoOrigemProduto = itenNotaFiscal.CodigoOrigemProduto;
		TipoIncidenciaIcms = itenNotaFiscal.TipoIncidenciaIcms;
		IsGeraDuplicata = itenNotaFiscal.IsGeraDuplicata;
		IsCsll = itenNotaFiscal.IsCsll;
	}

	public void CalcularImposto(PedidoVendaItemGPS pedidoVendaItemGPS, EntidadeGPS cliente)
	{
		NotaFiscalCFOPs notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(pedidoVendaItemGPS.CodigoCFOP);
		if (notaFiscalCFOPs == null)
		{
			return;
		}
		CodigoModalidadeIcms = notaFiscalCFOPs.ModalidadeICMS.ToString();
		AliquotaICMS = notaFiscalCFOPs.PadraoICMS;
		AliquotaIPI = notaFiscalCFOPs.PadraoIPI;
		AliquotaCofins = notaFiscalCFOPs.ValorCofins;
		AliquotaPis = notaFiscalCFOPs.PadraoPIS;
		PercentualBaseReducaoIcms = notaFiscalCFOPs.ReducaoICMS;
		CodigoOrigemProduto = notaFiscalCFOPs.OrigemProduto.ToString();
		TipoIncidenciaIcms = ModuloNotaFiscal.ObterNotaFiscalTipoIncidencia(notaFiscalCFOPs.IncideICMS).TipoIncidencia;
		TipoIncidenciaIpi = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaIPI(notaFiscalCFOPs.IncideIPI).CodigoIncidencia;
		TipoIncidenciaPis = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaImpostosFederais(notaFiscalCFOPs.IncidePIS).CodigoIncidencia;
		TipoIncidenciaCofins = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaImpostosFederais(notaFiscalCFOPs.IncideCofins).CodigoIncidencia;
		PercentualRetencaoPis = notaFiscalCFOPs.PercentualRetencaoPis;
		PercentualRetencaoCofins = notaFiscalCFOPs.PercentualRetencaoCofins;
		PercentualIcmsInterestadualFundoPobreza = 0m;
		PercentualIcmsInterestadualUfDestino = 0m;
		PercentualIcmsInterestadualUfEnvolvidas = 0m;
		IsCsll = notaFiscalCFOPs.IsCSLL;
		PercentualCsll = notaFiscalCFOPs.ValorCSLL;
		PercentualII = notaFiscalCFOPs.PercentualII;
		IsConsumidorFinal = notaFiscalCFOPs.IsConsumidorFinal;
		IsGeraDuplicata = notaFiscalCFOPs.IsGeraDuplicata;
		NomeCfop = MetodosUteis.LimpaNro(notaFiscalCFOPs.NumeracaoCFOP);
		PercentualCreditoIcms = notaFiscalCFOPs.PercentualCreditoIcms;
		if (TipoIncidenciaIcms == "201" || TipoIncidenciaIcms == "202" || TipoIncidenciaIcms == "10")
		{
			CodigoModalidadeICMSST = notaFiscalCFOPs.CodigoModalidadeICMSST;
			string codigoCest = string.Empty;
			string ncm = string.Empty;
			if (pedidoVendaItemGPS.EstoqueRef != null)
			{
				codigoCest = pedidoVendaItemGPS.EstoqueRef.Cest;
				ncm = pedidoVendaItemGPS.EstoqueRef.ClassificacaoFiscal;
			}
			NotaFiscalCest notaFiscalCest = ModuloNotaFiscal.ObterNotaFiscalCest(codigoCest, ncm, cliente.CodigoUf);
			if (notaFiscalCFOPs.IsUsarTabelaCest && notaFiscalCest != null)
			{
				PercentualBaseAgragadaICMSST = notaFiscalCest.ValorMva;
				PercentualICMSSTAgregado = notaFiscalCest.PercentualIcmsSt;
				PercentualReducaoBaseCalculoICMSST = notaFiscalCest.PercentualReducaoBaseCalculoICMSST;
			}
			else
			{
				PercentualBaseAgragadaICMSST = notaFiscalCFOPs.PercentualBaseAgragadaICMSST;
				PercentualICMSSTAgregado = notaFiscalCFOPs.PercentualICMSST;
				PercentualReducaoBaseCalculoICMSST = notaFiscalCFOPs.PercentualReducaoBaseCalculoICMSST;
			}
		}
		IsICMSInterestadual = notaFiscalCFOPs.IsICMSInterestadual;
		PercentualIcmsInterestadualFundoPobreza = notaFiscalCFOPs.PercentualIcmsInterestadualFundoPobreza;
		PercentualIcmsInterestadualUfDestino = notaFiscalCFOPs.PercentualIcmsInterestadualUfDestino;
		PercentualIcmsInterestadualUfEnvolvidas = notaFiscalCFOPs.PercentualIcmsInterestadualUfEnvolvidas;
		ValorTotal = Math.Round(ValorUnitario * Quantidade, 2);
		ValorFatura = 0m;
		ValorCreditoIcms = 0m;
		ValorBaseICMS = 0m;
		ValorICMS = 0m;
		ValorBaseAgragadaICMSST = 0m;
		ValorICMSSTAgregado = 0m;
		ValorIcmsInterestadualFundoPobreza = 0m;
		ValorIcmsInterestadualUfDestino = 0m;
		ValorIcmsInterestadualUfEnvolvidas = 0m;
		ValorBaseReducaoSemFrete = 0m;
		ValorCsll = 0m;
		ValorFatura = 0m;
		ValorBaseCalculoIpi = 0m;
		ValorIPI = 0m;
		ValorBaseCalculoPis = 0m;
		ValorPIS = 0m;
		ValorRetencaoPis = 0m;
		ValorBaseCalculoCofins = 0m;
		ValorCofins = 0m;
		ValorRetencaoCofins = 0m;
		ValorBaseCalculoImpostoImportacao = 0m;
		ValorImpostoImportacao = 0m;
		CodigoSituacaoTributaria = $"{CodigoOrigemProduto}{TipoIncidenciaIcms}";
		if (int.Parse(TipoIncidenciaPis) < 6)
		{
			if (ValorBaseCalculoPis == 0m && AliquotaPis > 0m)
			{
				ValorBaseCalculoPis = ValorTotal + ValorFrete + ValorSeguro + ValorOutros;
			}
			ValorRetencaoPis = Math.Round(ValorBaseCalculoPis * (PercentualRetencaoPis / 100.0m), 2);
			ValorPIS = Math.Round(ValorBaseCalculoPis * (AliquotaPis / 100.0m), 2);
		}
		if (int.Parse(TipoIncidenciaCofins) < 6)
		{
			if (ValorBaseCalculoCofins == 0m && AliquotaCofins > 0m)
			{
				ValorBaseCalculoCofins = ValorTotal + ValorFrete + ValorSeguro + ValorOutros;
			}
			ValorRetencaoCofins = Math.Round(ValorBaseCalculoCofins * (PercentualRetencaoCofins / 100.0m), 2);
			ValorCofins = Math.Round(ValorBaseCalculoCofins * (AliquotaCofins / 100.0m), 2);
		}
		if (ValorBaseCalculoIpi == 0m && AliquotaIPI > 0m)
		{
			ValorBaseCalculoIpi = ValorTotal + ValorFrete + ValorSeguro + ValorImpostoImportacao + ValorOutros;
		}
		ValorIPI = Math.Round(AliquotaIPI / 100.0m * ValorBaseCalculoIpi, 2);
		if (TipoIncidenciaIcms == "30" || TipoIncidenciaIcms == "40" || TipoIncidenciaIcms == "41")
		{
			ValorBaseICMS = 0m;
			AliquotaICMS = 0m;
		}
		else if (TipoIncidenciaIcms == "10" || TipoIncidenciaIcms == "201" || TipoIncidenciaIcms == "202")
		{
			if (PercentualBaseReducaoIcms > 0m && PercentualBaseReducaoIcms < 100m)
			{
				ValorBaseICMS = ValorTotal * (PercentualBaseReducaoIcms / 100.0m) + ValorFrete + ValorSeguro + ValorOutros;
			}
			else if (ValorBaseICMS == 0m && !IsConsumidorFinal)
			{
				ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros;
			}
			else if (ValorBaseICMS == 0m && IsConsumidorFinal)
			{
				ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI;
			}
			if (AliquotaICMS == 0m)
			{
				ValorBaseICMS = 0m;
			}
			decimal num = ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI;
			ValorICMS = Math.Round(ValorBaseICMS * AliquotaICMS / 100.0m, 2);
			ValorBaseAgragadaICMSST = num + num * PercentualBaseAgragadaICMSST / 100.0m;
			ValorBaseAgragadaICMSST = ValorBaseAgragadaICMSST * ((PercentualReducaoBaseCalculoICMSST == 0m) ? 100m : PercentualReducaoBaseCalculoICMSST) / 100m;
			ValorICMSSTAgregado = Math.Round(ValorBaseAgragadaICMSST * PercentualICMSSTAgregado / 100.0m - ValorICMS, 2);
			if (PercentualICMSSTAgregado == 0m)
			{
				ValorICMSSTAgregado = 0m;
				ValorBaseAgragadaICMSST = 0m;
			}
		}
		else
		{
			if (IsConsumidorFinal)
			{
				if (PercentualBaseReducaoIcms > 0m && PercentualBaseReducaoIcms < 100m)
				{
					ValorBaseICMS = ValorTotal * (PercentualBaseReducaoIcms / 100.0m) + ValorFrete + ValorSeguro + ValorOutros + ValorIPI;
				}
				else
				{
					ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI;
				}
			}
			else if (PercentualBaseReducaoIcms > 0m && PercentualBaseReducaoIcms < 100m)
			{
				ValorBaseICMS = ValorTotal * (PercentualBaseReducaoIcms / 100.0m) + ValorFrete + ValorSeguro + ValorOutros;
			}
			else
			{
				ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros;
			}
			if (AliquotaICMS == 0m)
			{
				ValorBaseICMS = 0m;
			}
		}
		if (PercentualCreditoIcms > 0m)
		{
			if (ValorBaseICMS == 0m)
			{
				ValorCreditoIcms = (ValorTotal * (PercentualBaseReducaoIcms / 100.0m) + ValorFrete + ValorSeguro + ValorOutros) * (PercentualCreditoIcms / 100m);
			}
			else
			{
				ValorCreditoIcms = ValorBaseICMS * (PercentualCreditoIcms / 100m);
			}
		}
		if (IsICMSInterestadual)
		{
			ValorIcmsInterestadualFundoPobreza = ValorBaseICMS * PercentualIcmsInterestadualFundoPobreza / 100m;
			if (DateTime.Today.Year == 2016)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * 0.4m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = ValorBaseICMS * 0.6m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
			}
			else if (DateTime.Today.Year == 2017)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * 0.6m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = ValorBaseICMS * 0.4m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
			}
			else if (DateTime.Today.Year == 2018)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * 0.8m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = ValorBaseICMS * 0.2m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
			}
			else if (DateTime.Today.Year >= 2019)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = 0m;
			}
		}
		ValorBaseReducaoSemFrete = ValorBaseICMS - ValorFrete;
		ValorICMS = Math.Round(ValorBaseICMS * AliquotaICMS / 100.0m, 2);
		if (IsCsll)
		{
			ValorCsll = Math.Round((ValorTotal + ValorFrete + ValorSeguro + ValorOutros) * PercentualCsll / 100.0m, 2);
		}
		if (IsGeraDuplicata)
		{
			ValorFatura = ValorTotal - ValorRetencaoPis - ValorRetencaoCofins + ValorFrete + ValorSeguro + ValorOutros;
		}
	}
}
