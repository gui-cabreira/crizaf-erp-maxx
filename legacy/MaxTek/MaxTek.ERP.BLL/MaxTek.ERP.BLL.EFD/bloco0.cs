using System;
using System.Collections.Generic;
using System.Text;
using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL.EFD;

internal static class bloco0
{
	private static int linhas;

	private static IList<XmlProduto> _produtos;

	private static IDictionary<string, XmlEntidade> _entidades;

	private static IList<XmlCabecalho> _cabecalhos;

	private static int NumeroLinhasBloco0 => linhas;

	public static StringBuilder GerarBloco0(out int linhasTotais, DateTime DataPeriodoInicial, DateTime DataPeriodoFinal, EnumEFDTipoEscrituracao tipoEscrituracao)
	{
		linhasTotais = 0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(gerarRegistro0000(DataPeriodoInicial, DataPeriodoFinal, tipoEscrituracao));
		linhasTotais = linhas;
		return stringBuilder;
	}

	private static StringBuilder gerarRegistro0000(DateTime DataPeriodoInicial, DateTime DataPeriodoFinal, EnumEFDTipoEscrituracao tipoEscrituracao)
	{
		linhas = 0;
		Sociedade sociedade = ModuloParametros.ObterSociedade(1);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6:ddMMyyyy}|{7:ddMMyyyy}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|", "", "0000", "003", (int)tipoEscrituracao, "", "", DataPeriodoInicial, DataPeriodoFinal, sociedade.RazaoSocial, FuncoesUteis.LimparNro(sociedade.Cnpj), sociedade.Estado, sociedade.CodigoCidade, "", "00", "0").AppendLine();
		linhas++;
		stringBuilder.Append("|0001|0|").AppendLine();
		linhas++;
		stringBuilder.AppendLine("|0100|SERGIO ABREU|91909694800|113621/O-7|71540546000183|09770330|Alameda Dona Tereza Cristina|309|.|Nova Petrópolis|1141256280|1141256280|ABREU@SERCONCONTABIL.COM.BR|3548708|");
		linhas++;
		stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|", "", "0110", "1", "2", "1", "").AppendLine();
		linhas++;
		stringBuilder.AppendFormat("{0}|{1:f2}|{2:f2}|{3:f2}|{4:f2}|{5:f2}|{6:f2}|", "", "0111", 0, 0, 0, 0, 0).AppendLine();
		linhas++;
		stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", "", "0140", FuncoesUteis.LimparNro(sociedade.Cnpj), sociedade.RazaoSocial, FuncoesUteis.LimparNro(sociedade.Cnpj), sociedade.Estado, FuncoesUteis.LimparNro(sociedade.InscricaoEstadual), sociedade.CodigoCidade, "", "").AppendLine();
		linhas++;
		stringBuilder.AppendFormat("|0145|2|0|0|0||").AppendLine();
		linhas++;
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0150(IList<XmlEntidade> Participantes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XmlEntidade Participante in Participantes)
		{
			stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|", "", "0150", FuncoesUteis.LimparNro(Participante.Cnpj), Participante.RazaoSocial, Participante.CodigoPais, FuncoesUteis.LimparNro(Participante.Cnpj), "", FuncoesUteis.LimparNro(Participante.InscricaoEstadual), Participante.CodigoMunicipio, Participante.InscricaoSuframa, Participante.Endereco, Participante.EnderecoNumero, Participante.EnderecoComplemento, Participante.Bairro).AppendLine();
			linhas++;
		}
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0150(IList<classe0150> Participantes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (classe0150 Participante in Participantes)
		{
			stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|", "", "0150", FuncoesUteis.LimparNro(Participante.Cnpj), Participante.RazaoSocial, Participante.CodigoPais, FuncoesUteis.LimparNro(Participante.Cnpj), "", FuncoesUteis.LimparNro(Participante.InscricaoEstadual), Participante.CodigoMunicipio, Participante.Suframa, Participante.Endereco, Participante.Numero, Participante.Complemento, Participante.Bairro).AppendLine();
			linhas++;
		}
		return stringBuilder;
	}

	private static StringBuilder gerarRegistro0190(IList<XmlEntidade> Participantes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XmlEntidade Participante in Participantes)
		{
			stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|", "", "0190", "UN", "Unidade").AppendLine();
			linhas++;
		}
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0190()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|", "", "0190", "UN", "Unidade").AppendLine();
		linhas++;
		stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|", "", "0190", "KG", "Quilograma").AppendLine();
		linhas++;
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0200(IList<XmlProduto> produtos)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XmlProduto produto in produtos)
		{
			string value = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|", "", "0200", produto.CodigoProduto, produto.DescricaoProduto, produto.CodigoEan, "", "PC", "01", produto.CodigoNcm, produto.IpiCodigoEnquadramento, (produto.CodigoNcm.Length > 2) ? produto.CodigoNcm.Substring(0, 2) : produto.CodigoNcm, produto.IssqnCodigoListaServico, produto.IcmsAliquota);
			if (!stringBuilder.ToString().Contains(value))
			{
				stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|", "", "0200", produto.CodigoProduto, produto.DescricaoProduto, produto.CodigoEan, "", "PC", "01", produto.CodigoNcm, produto.IpiCodigoEnquadramento, (produto.CodigoNcm.Length > 2) ? produto.CodigoNcm.Substring(0, 2) : produto.CodigoNcm, produto.IssqnCodigoListaServico, produto.IcmsAliquota).AppendLine();
				linhas++;
			}
		}
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0200(IList<classe0200> produtos)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (classe0200 produto in produtos)
		{
			stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|", "", "0200", produto.CodigoProduto, produto.DescricaoProduto, produto.CodigoEan, "", "PC", "01", produto.CodigoNCM, produto.IpiCodigoEnquadramento, produto.CodigoGenero, produto.IssqnCodigoListaServico, produto.AliquotaIcms).AppendLine();
			linhas++;
		}
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0400(IList<XmlCabecalho> cabecalhos)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XmlCabecalho cabecalho in cabecalhos)
		{
			foreach (XmlProduto item in cabecalho.ProdutosRef)
			{
				string value = string.Format("{0}|{1}|{2}", "", "0400", item.CfopEntrada);
				if (!stringBuilder.ToString().Contains(value))
				{
					stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|", "", "0400", item.CfopEntrada, cabecalho.NaturezaDaOperacao).AppendLine();
					linhas++;
				}
			}
		}
		return stringBuilder;
	}

	public static StringBuilder gerarRegistro0400(IList<classe0400> CFOPs)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (classe0400 CFOP in CFOPs)
		{
			stringBuilder.AppendFormat("{0}|{1}|{2}|{3}|", "", "0400", CFOP.Cfop, CFOP.NaturezaOpercao).AppendLine();
			linhas++;
		}
		return stringBuilder;
	}

	private static StringBuilder gerarRegistro0990(IList<XmlEntidade> Participantes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		linhas++;
		stringBuilder.AppendFormat("{0}|{1}|{2}|", "", "0990", NumeroLinhasBloco0).AppendLine();
		return stringBuilder;
	}
}
