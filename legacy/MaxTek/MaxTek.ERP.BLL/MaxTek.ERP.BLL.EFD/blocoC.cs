using System.Collections.Generic;
using System.Text;
using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL.EFD;

internal static class blocoC
{
	private static int linhas;

	private static IList<XmlProduto> _produtos;

	private static IDictionary<string, XmlEntidade> _entidades;

	private static IList<XmlCabecalho> _cabecalhos;

	public static StringBuilder GerarRegistroC(bool possuiRegistro, IDictionary<string, XmlEntidade> entidades, IList<XmlCabecalho> cabecalhos)
	{
		_entidades = entidades;
		_cabecalhos = cabecalhos;
		linhas = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (!possuiRegistro)
		{
			stringBuilder.Append("|C001|1|").AppendLine();
			linhas++;
		}
		else
		{
			stringBuilder.Append("|C001|0|").AppendLine();
			linhas++;
			foreach (XmlEntidade value in _entidades.Values)
			{
				stringBuilder.AppendFormat("|C010|{0}|{1}|", FuncoesUteis.LimparNro(value.Cnpj), 2).AppendLine();
				linhas++;
			}
			foreach (XmlCabecalho cabecalho in _cabecalhos)
			{
				if (!(cabecalho.CodigoModeloDocumentoFiscal == "1") && !(cabecalho.CodigoModeloDocumentoFiscal == "55"))
				{
					continue;
				}
				stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10:ddMMyyyy}|{11:ddMMyyyy}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|", "", "C100", "1", "0", cabecalho.Cnpj, "00", "00", cabecalho.SerieNotaFiscal, cabecalho.CodigoNotaFiscal, FuncoesUteis.LimparNro(cabecalho.Chave), cabecalho.DataEmissao, cabecalho.DataSaida, cabecalho.ValorTotalNfe, cabecalho.IndicadorFormaPagamento, cabecalho.ValorDesconto, "0", cabecalho.ValorTotalProdutos, cabecalho.ModalidadeFrete, cabecalho.ValorFrete, cabecalho.ValorSeguro, cabecalho.ValorOutros, cabecalho.ValorBaseCalculoIcms, cabecalho.ValorIcms, cabecalho.ValorBaseCalculoIcmsSt, cabecalho.ValorIcmsSt, cabecalho.ValorIpi, cabecalho.ValorPis, cabecalho.ValorCofins, cabecalho.ValorPisRetido, cabecalho.ValorCofinsRetido).AppendLine();
				linhas++;
				foreach (XmlProduto item in cabecalho.ProdutosRef)
				{
					stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}|{37}|", "", "C170", item.CodigoItem, item.CodigoProduto, item.DescricaoProduto, item.QuantidadeComercial, item.UnidadeComercial, item.ValorTotalBruto, item.ValorDesconto, cabecalho.IsRecebido ? "0" : "1", item.IcmsCst, item.CfopEntrada, "Natureza da Operação", item.IcmsValorBaseCalculo, item.IcmsAliquota, item.IcmsValor, item.IcmsBaseCalculoSt, item.IcmsAliquota, item.IcmsValorSt, "0", item.IpiCst, "999", item.IpiValorBaseCalculo, item.IpiAliquota, item.IpiValor, item.PisCst, item.PisValorBaseCalculo, item.PisAliquota, "", "", item.PisValor, item.CofinsCst, item.CofinsValorBaseCalculo, item.CofinsAliquota, "", "", item.CofinsValor, item.CodigoContaReduzida).AppendLine();
					linhas++;
				}
			}
			linhas++;
			stringBuilder.AppendFormat("|C990|{0}|", linhas).AppendLine();
		}
		return stringBuilder;
	}

	public static StringBuilder GerarRegistroC(bool possuiRegistro, IDictionary<string, classeA001> entidades, IList<classeC100> cabecalhos)
	{
		linhas = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (!possuiRegistro)
		{
			stringBuilder.Append("|C001|1|").AppendLine();
			linhas++;
		}
		else
		{
			stringBuilder.Append("|C001|0|").AppendLine();
			linhas++;
			foreach (classeA001 value in entidades.Values)
			{
				stringBuilder.AppendFormat("|C010|{0}|{1}|", FuncoesUteis.LimparNro(value.Cnpj), 2).AppendLine();
				linhas++;
			}
			foreach (classeC100 cabecalho in cabecalhos)
			{
				if (!(cabecalho.CodigoModeloDocumentoFiscal == "1") && !(cabecalho.CodigoModeloDocumentoFiscal == "55"))
				{
					continue;
				}
				stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10:ddMMyyyy}|{11:ddMMyyyy}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|", "", "C100", "1", "0", cabecalho.CodigoParticipante, "00", "00", cabecalho.Serie, cabecalho.NumeroNotaFiscal, FuncoesUteis.LimparNro(cabecalho.ChaveEletronica), cabecalho.DataEmissao, cabecalho.DataEntrada, cabecalho.ValorTotalDocumento, cabecalho.CodigoIndicadorTipoPagamento, cabecalho.ValorDesconto, "0", cabecalho.ValorTotalMercadorias, cabecalho.IndicadorTipoFrete, cabecalho.ValorFrete, cabecalho.ValorSeguro, cabecalho.ValorOutrasDespesas, cabecalho.ValorBaseCalculoIcms, cabecalho.ValorIcms, cabecalho.ValorBaseCalculoIcmsSt, cabecalho.ValorIcmsSt, cabecalho.ValorIpi, cabecalho.ValorPis, cabecalho.ValorCofins, "0", "0", "").AppendLine();
				linhas++;
				foreach (classeC170 item in cabecalho.ClC170)
				{
					stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}|{37}|", "", "C170", item.NumeroItem, item.CodigoProduto, item.DescricaoProduto, item.Quantidade, item.Unidade, item.ValorTotalItem, item.ValorDesconto, "0", item.CstIcms, item.Cfop, item.CodNatureza, item.ValorBaseIcms, item.AliquotaIcms, item.ValorIcms, item.ValorBaseIcmsSt, item.AliquotaIcmsSt, item.ValorIcmsSt, "0", item.CstIpi, "999", item.BaseCalculoIpi, item.AliquotaIpi, item.ValorIpi, item.CstPis, item.ValorBaseCalculoPis, item.AliquotaPis, "", "", item.ValorPis, item.CstCofins, item.ValorBaseCalculoCofins, item.AliquotaCofins, "", "", item.ValorCofins, item.ContaContabil).AppendLine();
					linhas++;
				}
			}
			linhas++;
			stringBuilder.AppendFormat("|C990|{0}|", linhas).AppendLine();
		}
		return stringBuilder;
	}
}
