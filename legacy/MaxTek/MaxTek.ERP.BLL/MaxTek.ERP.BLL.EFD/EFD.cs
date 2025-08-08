using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL.EFD;

public static class EFD
{
	private static int NumeroTotalLinhas;

	private static IList<XmlProduto> _produtos;

	private static IDictionary<string, XmlEntidade> _entidades;

	private static IList<XmlCabecalho> _cabecalhos;

	private static Sociedade _empresa;

	private static IDictionary<string, classe0150> cl0150;

	private static IDictionary<string, classe0200> cl0200;

	private static IDictionary<string, classe0400> cl0400;

	private static IDictionary<string, classeA001> clA001;

	private static IList<classeA100> clA100;

	private static IDictionary<string, classeA001> clC001;

	private static IList<classeC100> clC100;

	public static string GerarEFD(DateTime dataPeriodoInicial, DateTime dataPeriodoFinal)
	{
		NumeroTotalLinhas = 0;
		PrepararDadosParaGeracaoEFD(dataPeriodoInicial, dataPeriodoFinal);
		StringBuilder stringBuilder = new StringBuilder();
		int linhasTotais = 0;
		stringBuilder.Append(bloco0.GerarBloco0(out linhasTotais, dataPeriodoInicial, dataPeriodoFinal, EnumEFDTipoEscrituracao.Original));
		stringBuilder.Append(bloco0.gerarRegistro0150(cl0150.Values.ToList()));
		stringBuilder.Append(bloco0.gerarRegistro0190());
		stringBuilder.Append(bloco0.gerarRegistro0200(cl0200.Values.ToList()));
		stringBuilder.Append(bloco0.gerarRegistro0400(cl0400.Values.ToList()));
		NumeroTotalLinhas += linhasTotais;
		stringBuilder.Append(blocoA.GerarRegistroA(possuiRegistro: true, clA001, clA100));
		stringBuilder.Append(blocoC.GerarRegistroC(possuiRegistro: true, clC001, clC100));
		return stringBuilder.ToString();
	}

	private static void PrepararDadosParaGeracaoEFD(DateTime dataPeriodoInicial, DateTime dataPeriodoFinal)
	{
		_empresa = ModuloParametros.ObterSociedade(1);
		_empresa.Cnpj = FuncoesUteis.LimparNro(_empresa.Cnpj);
		_cabecalhos = ModuloXml.ObterTodosXmlCabecalhoEscriturados(dataPeriodoInicial, dataPeriodoFinal);
		_entidades = new Dictionary<string, XmlEntidade>();
		_produtos = new List<XmlProduto>();
		cl0150 = new Dictionary<string, classe0150>();
		cl0200 = new Dictionary<string, classe0200>();
		cl0400 = new Dictionary<string, classe0400>();
		clA001 = new Dictionary<string, classeA001>();
		clA100 = new List<classeA100>();
		clC001 = new Dictionary<string, classeA001>();
		clC100 = new List<classeC100>();
		IList<NotaFiscalNotasFiscais> list = ModuloNotaFiscal.ObterTodosNotaFiscalNotasFiscais(dataPeriodoInicial, dataPeriodoFinal);
		foreach (NotaFiscalNotasFiscais item in list)
		{
			classeC100 classeC171 = new classeC100(item);
			if (!cl0150.ContainsKey(FuncoesUteis.LimparNro(item.CnpjDestinatario)))
			{
				cl0150.Add(FuncoesUteis.LimparNro(item.CnpjDestinatario), new classe0150(item.Entidade));
			}
			if (!clC001.ContainsKey(FuncoesUteis.LimparNro(item.CnpjDestinatario)))
			{
				clC001.Add(FuncoesUteis.LimparNro(item.CnpjDestinatario), new classeA001(FuncoesUteis.LimparNro(item.CnpjDestinatario)));
			}
			foreach (NotaFiscalNotasFiscaisItens iten in item.Itens)
			{
				classeC171.ClC170.Add(new classeC170(iten));
				if (!cl0200.ContainsKey(iten.CodigoProduto))
				{
					cl0200.Add(iten.CodigoProduto, new classe0200(iten));
				}
				if (!cl0400.ContainsKey(FuncoesUteis.LimparNro(iten.NomeCfop)))
				{
					cl0400.Add(FuncoesUteis.LimparNro(iten.NomeCfop), new classe0400(FuncoesUteis.LimparNro(iten.NomeCfop), iten.CFOPRef.Nfe));
				}
			}
			clC100.Add(classeC171);
		}
		bool flag = false;
	}
}
