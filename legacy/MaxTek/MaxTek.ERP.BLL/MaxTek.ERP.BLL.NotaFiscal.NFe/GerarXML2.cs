using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public static class GerarXML2
{
	public static string Consulta(int tpAmb, int tpEmis, string chNFe)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.AppendFormat("<consSitNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\">");
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.Append("<xServ>CONSULTAR</xServ>");
		stringBuilder.AppendFormat("<chNFe>{0}</chNFe>", chNFe);
		stringBuilder.Append("</consSitNFe>");
		return stringBuilder.ToString();
	}

	public static string StatusServico(int tpAmb, int tpEmis, int cUF)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.Append("<consStatServ xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\">");
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.AppendFormat("<cUF>{0}</cUF>", cUF);
		stringBuilder.Append("<xServ>STATUS</xServ>");
		stringBuilder.Append("</consStatServ>");
		string text = stringBuilder.ToString();
		SalvarXml(GerarNomeArqSitServico(), ConfigNFe.ExtPedSitNfe, text);
		return text;
	}

	public static string StatusServico4(int tpAmb, int tpEmis, int cUF)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.Append("<consStatServ xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"4.00\">");
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.AppendFormat("<cUF>{0}</cUF>", cUF);
		stringBuilder.Append("<xServ>STATUS</xServ>");
		stringBuilder.Append("</consStatServ>");
		string text = stringBuilder.ToString();
		SalvarXml(GerarNomeArqSitServico(), ConfigNFe.ExtPedSitNfe, text);
		return text;
	}

	public static string ConsultaLote(int tpAmb, int cUF, string recibo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.Append("<consReciNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\">");
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.AppendFormat("<nRec>{0}</nRec>", recibo);
		stringBuilder.Append("</consReciNFe>");
		string text = stringBuilder.ToString();
		SalvarXml(recibo, ConfigNFe.ExtProcLoteNfe, text);
		return text;
	}

	public static string ConsultaLote4(int tpAmb, int cUF, string recibo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.Append("<consReciNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"4.00\">");
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.AppendFormat("<nRec>{0}</nRec>", recibo);
		stringBuilder.Append("</consReciNFe>");
		string text = stringBuilder.ToString();
		SalvarXml(recibo, ConfigNFe.ExtProcLoteNfe, text);
		return text;
	}

	public static string GerarXmlUmaNota(string nfeXmlFile, out int ilote)
	{
		int num = 0;
		NotaFiscalSerie notaFiscalSerie = null;
		IList<NotaFiscalSerie> list = ModuloNotaFiscal.ObterTodosNotaFiscalSerie();
		if (list != null && list.Count > 0)
		{
			notaFiscalSerie = list[0];
			num = notaFiscalSerie.Indice;
		}
		string path;
		do
		{
			num++;
			path = GerarNomeArqXmlLoteCompleto(num);
		}
		while (File.Exists(path));
		ilote = num;
		if (notaFiscalSerie != null)
		{
			notaFiscalSerie.Indice = num;
			ModuloNotaFiscal.SalvarNotaFiscalSerie(notaFiscalSerie);
		}
		return EncerrarLoteNfe(num, IniciarLoteNfe(num) + InserirNFeLote(nfeXmlFile));
	}

	public static string GerarXmlUmaNota4(string nfeXmlFile, out int ilote)
	{
		int num = 0;
		NotaFiscalSerie notaFiscalSerie = null;
		IList<NotaFiscalSerie> list = ModuloNotaFiscal.ObterTodosNotaFiscalSerie();
		if (list != null && list.Count > 0)
		{
			notaFiscalSerie = list[0];
			num = notaFiscalSerie.Indice;
		}
		string path;
		do
		{
			num++;
			path = GerarNomeArqXmlLoteCompleto(num);
		}
		while (File.Exists(path));
		ilote = num;
		if (notaFiscalSerie != null)
		{
			notaFiscalSerie.Indice = num;
			ModuloNotaFiscal.SalvarNotaFiscalSerie(notaFiscalSerie);
		}
		return EncerrarLoteNfe(num, IniciarLoteNfe4(num) + InserirNFeLote(nfeXmlFile));
	}

	public static string IniciarLoteNfe(int intNumeroLote)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
		stringBuilder.AppendFormat("<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\">");
		stringBuilder.AppendFormat("<idLote>{0}</idLote>", intNumeroLote);
		stringBuilder.AppendFormat("<indSinc>0</indSinc>");
		return stringBuilder.ToString();
	}

	public static string IniciarLoteNfe4(int intNumeroLote)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
		stringBuilder.AppendFormat("<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"4.00\">");
		stringBuilder.AppendFormat("<idLote>{0}</idLote>", intNumeroLote);
		stringBuilder.AppendFormat("<indSinc>0</indSinc>");
		return stringBuilder.ToString();
	}

	public static string InserirNFeLote(string xmlFile)
	{
		try
		{
			string text = XmlToString(xmlFile);
			int num = text.IndexOf("<NFe");
			int length = text.Length - num;
			return text.Substring(num, length);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static string EncerrarLoteNfe(int intNumeroLote, string strXMLLoteNfe)
	{
		strXMLLoteNfe += "</enviNFe>";
		try
		{
			GerarXMLLote(intNumeroLote, strXMLLoteNfe);
		}
		catch (IOException ex)
		{
			throw ex;
		}
		catch (Exception ex2)
		{
			throw ex2;
		}
		return strXMLLoteNfe;
	}

	public static string GerarXMLLote(int intNumeroLote, string strXMLLoteNfe)
	{
		string text = GerarNomeArqXmlLoteCompleto(intNumeroLote);
		if (!Directory.Exists(ConfigNFe.Instancia.DirNFeLote))
		{
			Directory.CreateDirectory(ConfigNFe.Instancia.DirNFeLote);
		}
		SalvarCompleto(text, strXMLLoteNfe);
		return text;
	}

	public static void XmlCancelamento(int CodUF, int tpAmb, string cnpj, string chNFe, string nProt, string xJust)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.Append("<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
		stringBuilder.AppendFormat("<idLote>{0}</idLote>", DateTime.Now.ToString("yyyMMddHHmmss"));
		stringBuilder.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
		stringBuilder.AppendFormat("<infEvento Id=\"ID110111{0}01\">", chNFe);
		stringBuilder.AppendFormat("<cOrgao>{0}</cOrgao>", CodUF);
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.AppendFormat("<CNPJ>{0}</CNPJ>", LimpaNro(cnpj));
		stringBuilder.AppendFormat("<chNFe>{0}</chNFe>", chNFe);
		stringBuilder.AppendFormat("<dhEvento>{0}</dhEvento>", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));
		stringBuilder.AppendFormat("<tpEvento>{0}</tpEvento>", "110111");
		stringBuilder.AppendFormat("<nSeqEvento>{0}</nSeqEvento>", "1");
		stringBuilder.AppendFormat("<verEvento>{0}</verEvento>", "1.00");
		stringBuilder.AppendFormat("<detEvento versao=\"{0}\">", "1.00");
		stringBuilder.AppendFormat("<descEvento>{0}</descEvento>", "Cancelamento");
		stringBuilder.AppendFormat("<nProt>{0}</nProt>", nProt);
		stringBuilder.AppendFormat("<xJust>{0}</xJust>", xJust.Trim());
		stringBuilder.Append("</detEvento>");
		stringBuilder.Append("</infEvento>");
		stringBuilder.Append("</evento>");
		stringBuilder.Append("</envEvento>");
		SalvarXml(chNFe, ConfigNFe.ExtPedCanc, stringBuilder.ToString());
	}

	public static void XmlCartaCorrecao(int CodUF, int tpAmb, string cnpj, string chNFe, string xCorrecao, int sequenciaEvento)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		stringBuilder.Append("<envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
		stringBuilder.AppendFormat("<idLote>{0}</idLote>", DateTime.Now.ToString("yyyMMddHHmmss"));
		stringBuilder.Append("<evento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">");
		stringBuilder.AppendFormat("<infEvento Id=\"ID110110{0}0{1}\">", chNFe, sequenciaEvento);
		stringBuilder.AppendFormat("<cOrgao>{0}</cOrgao>", CodUF);
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.AppendFormat("<CNPJ>{0}</CNPJ>", LimpaNro(cnpj));
		stringBuilder.AppendFormat("<chNFe>{0}</chNFe>", chNFe);
		stringBuilder.AppendFormat("<dhEvento>{0}</dhEvento>", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));
		stringBuilder.AppendFormat("<tpEvento>{0}</tpEvento>", "110110");
		stringBuilder.AppendFormat("<nSeqEvento>{0}</nSeqEvento>", sequenciaEvento);
		stringBuilder.AppendFormat("<verEvento>{0}</verEvento>", "1.00");
		stringBuilder.AppendFormat("<detEvento versao=\"{0}\">", "1.00");
		stringBuilder.AppendFormat("<descEvento>{0}</descEvento>", "Carta de Correção");
		stringBuilder.AppendFormat("<xCorrecao>{0}</xCorrecao>", xCorrecao.Trim());
		stringBuilder.Append("<xCondUso>A Carta de Correção é disciplinada pelo § 1º-A do art. 7º do Convênio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularização de erro ocorrido na emissão de documento fiscal, desde que o erro não esteja relacionado com: I - as variáveis que determinam o valor do imposto tais como: base de cálculo, alíquota, diferença de preço, quantidade, valor da operação ou da prestação; II - a correção de dados cadastrais que implique mudança do remetente ou do destinatário; III - a data de emissão ou de saída.</xCondUso>");
		stringBuilder.Append("</detEvento>");
		stringBuilder.Append("</infEvento>");
		stringBuilder.Append("</evento>");
		stringBuilder.Append("</envEvento>");
		SalvarXml(chNFe, ConfigNFe.ExtEnvCartaCorrecao, stringBuilder.ToString());
	}

	public static string XmlToString(string parNomeArquivo)
	{
		string result = string.Empty;
		StreamReader streamReader = null;
		try
		{
			streamReader = File.OpenText(parNomeArquivo);
			result = streamReader.ReadToEnd();
		}
		catch (IOException ex)
		{
			throw ex;
		}
		catch (Exception ex2)
		{
			throw ex2;
		}
		finally
		{
			streamReader.Close();
		}
		return result;
	}

	public static void SalvarXml(string fileName, string extensao, string conteudo)
	{
		if (!Directory.Exists(ConfigNFe.Instancia.DirNFeStore))
		{
			Directory.CreateDirectory(ConfigNFe.Instancia.DirNFeStore);
		}
		SalvarCompleto(ConfigNFe.Instancia.DirNFeStore + "\\" + fileName + extensao, conteudo);
	}

	public static void SalvarCompleto(string fullPath, string conteudo)
	{
		StreamWriter streamWriter = null;
		try
		{
			streamWriter = File.CreateText(fullPath);
			streamWriter.Write(conteudo);
			streamWriter.Close();
		}
		catch (IOException ex)
		{
			throw ex;
		}
		catch (Exception ex2)
		{
			throw ex2;
		}
		finally
		{
			streamWriter.Close();
		}
	}

	public static string GerarNomeArqSitServico()
	{
		return DateTime.Now.ToString("yyyyMMddThhmmss");
	}

	public static string GerarNomeArqXmlLote(int intNumeroLote)
	{
		if (!Directory.Exists(ConfigNFe.Instancia.DirNFeLote))
		{
			Directory.CreateDirectory(ConfigNFe.Instancia.DirNFeLote);
		}
		return intNumeroLote.ToString("000000000000000");
	}

	public static string GerarNomeArqXmlLoteCompleto(int intNumeroLote)
	{
		return $"{ConfigNFe.Instancia.DirNFeLote}\\{GerarNomeArqXmlLote(intNumeroLote)}{ConfigNFe.ExtEnvioLoteNfe}";
	}

	public static string CodificaCaracteresEspeciais(string texto)
	{
		return texto.Trim();
	}

	public static string GerarCNF(int serie, int nro)
	{
		return (serie * 1000000 + nro * 3).ToString("00000000");
	}

	public static string LimpaNro(string valor)
	{
		string text = string.Empty;
		for (int i = 0; i < valor.Length; i++)
		{
			char c = valor[i];
			if (char.IsDigit(c))
			{
				text += c;
			}
		}
		return text;
	}

	public static void Inutilizacao(string pFinalArqEnvio, int tpAmb, int cUF, int ano, string CNPJ, int mod, int serie, int nNFIni, int nNFFin, string xJust)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
		stringBuilder.Append("<inutNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\">");
		stringBuilder.AppendFormat("<infInut Id=\"ID{0}{1}{2}{3}{4}{5}{6}\">", cUF.ToString("00"), ano.ToString("00"), CNPJ, mod.ToString("00"), serie.ToString("000"), nNFIni.ToString("000000000"), nNFFin.ToString("000000000"));
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.Append("<xServ>INUTILIZAR</xServ>");
		stringBuilder.AppendFormat("<cUF>{0}</cUF>", cUF.ToString("00"));
		stringBuilder.AppendFormat("<ano>{0}</ano>", ano.ToString("00"));
		stringBuilder.AppendFormat("<CNPJ>{0}</CNPJ>", CNPJ);
		stringBuilder.AppendFormat("<mod>{0}</mod>", mod.ToString("00"));
		stringBuilder.AppendFormat("<serie>{0}</serie>", serie);
		stringBuilder.AppendFormat("<nNFIni>{0}</nNFIni>", nNFIni);
		stringBuilder.AppendFormat("<nNFFin>{0}</nNFFin>", nNFFin);
		stringBuilder.AppendFormat("<xJust>{0}</xJust>", xJust);
		stringBuilder.Append("</infInut>");
		stringBuilder.Append("</inutNFe>");
		SalvarXml(pFinalArqEnvio, ConfigNFe.ExtPedInu, stringBuilder.ToString());
	}

	public static void Inutilizacao4(string pFinalArqEnvio, int tpAmb, int cUF, int ano, string CNPJ, int mod, int serie, int nNFIni, int nNFFin, string xJust)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
		stringBuilder.Append("<inutNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"4.00\">");
		stringBuilder.AppendFormat("<infInut Id=\"ID{0}{1}{2}{3}{4}{5}{6}\">", cUF.ToString("00"), ano.ToString("00"), CNPJ, mod.ToString("00"), serie.ToString("000"), nNFIni.ToString("000000000"), nNFFin.ToString("000000000"));
		stringBuilder.AppendFormat("<tpAmb>{0}</tpAmb>", tpAmb);
		stringBuilder.Append("<xServ>INUTILIZAR</xServ>");
		stringBuilder.AppendFormat("<cUF>{0}</cUF>", cUF.ToString("00"));
		stringBuilder.AppendFormat("<ano>{0}</ano>", ano.ToString("00"));
		stringBuilder.AppendFormat("<CNPJ>{0}</CNPJ>", CNPJ);
		stringBuilder.AppendFormat("<mod>{0}</mod>", mod.ToString("00"));
		stringBuilder.AppendFormat("<serie>{0}</serie>", serie);
		stringBuilder.AppendFormat("<nNFIni>{0}</nNFIni>", nNFIni);
		stringBuilder.AppendFormat("<nNFFin>{0}</nNFFin>", nNFFin);
		stringBuilder.AppendFormat("<xJust>{0}</xJust>", xJust);
		stringBuilder.Append("</infInut>");
		stringBuilder.Append("</inutNFe>");
		SalvarXml(pFinalArqEnvio, ConfigNFe.ExtPedInu, stringBuilder.ToString());
	}
}
