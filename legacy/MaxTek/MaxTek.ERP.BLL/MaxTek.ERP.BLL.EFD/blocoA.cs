using System.Collections.Generic;
using System.Text;
using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL.EFD;

internal static class blocoA
{
	private static int linhas;

	private static IList<XmlProduto> _produtos;

	private static IDictionary<string, XmlEntidade> _entidades;

	private static IList<XmlCabecalho> _cabecalhos;

	public static StringBuilder GerarRegistroA(bool possuiRegistro, IDictionary<string, XmlEntidade> entidades, IList<XmlCabecalho> cabecalhos)
	{
		_entidades = entidades;
		_cabecalhos = cabecalhos;
		linhas = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (!possuiRegistro)
		{
			stringBuilder.Append("|A001|1|").AppendLine();
			linhas++;
		}
		else
		{
			stringBuilder.Append("|A001|0|").AppendLine();
			linhas++;
			foreach (XmlEntidade value in _entidades.Values)
			{
				stringBuilder.AppendFormat("|A010|{0}|", FuncoesUteis.LimparNro(value.Cnpj)).AppendLine();
				linhas++;
			}
			foreach (XmlCabecalho cabecalho in _cabecalhos)
			{
				if (!(cabecalho.CodigoModeloDocumentoFiscal == "2"))
				{
					continue;
				}
				stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10:ddMMyyyy}|{11:ddMMyyyy}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|", "", "A100", "0", "0", cabecalho.Cnpj, "00", cabecalho.SerieNotaFiscal, "", cabecalho.CodigoNotaFiscal, FuncoesUteis.LimparNro(cabecalho.Chave), cabecalho.DataEmissao, cabecalho.DataEmissao, cabecalho.ValorTotalNfe, cabecalho.IndicadorFormaPagamento, cabecalho.ValorDesconto, cabecalho.ValorBaseCalculoIcms, cabecalho.ValorPisServico, cabecalho.ValorBaseCalculoIcms, cabecalho.ValorCofinsServico, cabecalho.ValorPisRetido, cabecalho.ValorCofinsRetido, cabecalho.ValorIss).AppendLine();
				linhas++;
				foreach (XmlProduto item in cabecalho.ProdutosRef)
				{
					stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|", "", "A170", item.CodigoItem, item.CodigoProduto, item.DescricaoProduto, item.ValorTotalBruto, item.ValorDesconto, "", "0", item.PisCst, item.PisValorBaseCalculo, item.PisAliquota, item.PisValor, item.CofinsCst, item.CofinsValorBaseCalculo, item.CofinsAliquota, item.CofinsValor, item.CodigoContaReduzida, item.CodigoCentroCustos).AppendLine();
					linhas++;
				}
			}
			linhas++;
			stringBuilder.AppendFormat("|A990|{0}|", linhas).AppendLine();
		}
		return stringBuilder;
	}

	public static StringBuilder GerarRegistroA(bool possuiRegistro, IDictionary<string, classeA001> entidades, IList<classeA100> cabecalhos)
	{
		linhas = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (!possuiRegistro)
		{
			stringBuilder.Append("|A001|1|").AppendLine();
			linhas++;
		}
		else
		{
			stringBuilder.Append("|A001|0|").AppendLine();
			linhas++;
			foreach (KeyValuePair<string, classeA001> entidade in entidades)
			{
				stringBuilder.AppendFormat("|A010|{0}|", FuncoesUteis.LimparNro(entidade.Key.ToString())).AppendLine();
				linhas++;
			}
			foreach (classeA100 cabecalho in cabecalhos)
			{
				stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10:ddMMyyyy}|{11:ddMMyyyy}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|", "", "A100", cabecalho.IndicadorTipoOperacao, cabecalho.IndicadorEmitente, cabecalho.CodigoParticipante, cabecalho.CodigoSituacaoDocumento, cabecalho.Serie, cabecalho.SubSerie, cabecalho.NumeroNotaFiscal, FuncoesUteis.LimparNro(cabecalho.ChaveEletronica), cabecalho.DataEmissao, cabecalho.DataEntrada, cabecalho.ValorTotalDocumento, cabecalho.CodigoIndicadorTipoPagamento, cabecalho.ValorDesconto, cabecalho.ValorBaseCalculoPisPasep, cabecalho.ValorTotalPis, cabecalho.ValorBaseCalculoCofins, cabecalho.ValorTotalCofins, cabecalho.ValorTotalPisRetido, cabecalho.ValorTotalCofinsRetido, cabecalho.ValorIss).AppendLine();
				linhas++;
				foreach (classeA170 item in cabecalho.ClA170)
				{
					stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12:f2}|{13}|{14:f2}|{15}|{16}|{17}|{18}|", "", "A170", item.CodigoItem, item.CodigoProduto, item.DescricaoProduto, item.ValorTotalBruto, item.ValorDesconto, item.CodigoBaseCalculoCredito, item.IndicadorOrigemCredito, item.PisCst, item.PisValorBaseCalculo, item.PisAliquota, item.PisValor, item.CofinsCst, item.CofinsValorBaseCalculo, item.CofinsAliquota, item.CofinsValor, item.CodigoContaReduzida, item.CodigoCentroCustos).AppendLine();
					linhas++;
				}
			}
			linhas++;
			stringBuilder.AppendFormat("|A990|{0}|", linhas).AppendLine();
		}
		return stringBuilder;
	}
}
