using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class ValidarXMLs
{
	public static string SubFolder110 = "v110";

	public static string SubFolder200 = "v200";

	public static string SubFolder310 = "v310";

	public static string SubFolder400 = "v400";

	private string PastaSchema = ConfigNFe.Instancia.DirNFeSchemas;

	private string cErro;

	public int Retorno { get; private set; }

	public string RetornoString { get; private set; }

	public int nRetornoTipoArq { get; private set; }

	public string cRetornoTipoArq { get; private set; }

	public string cArquivoSchema { get; private set; }

	public string TagAssinar { get; private set; }

	public void Validar(string cRotaArqXML, string cRotaArqSchema, string subFolder)
	{
		bool flag = File.Exists(cRotaArqXML);
		string text = PastaSchema + "\\" + subFolder + "\\" + cRotaArqSchema;
		bool flag2 = File.Exists(text);
		if (flag && flag2)
		{
			StreamReader input = new StreamReader(cRotaArqXML);
			XmlTextReader reader = new XmlTextReader(input);
			XmlValidatingReader xmlValidatingReader = new XmlValidatingReader(reader);
			XmlSchemaCollection xmlSchemaCollection = new XmlSchemaCollection();
			xmlSchemaCollection.Add("http://www.portalfiscal.inf.br/nfe", text);
			xmlValidatingReader.Schemas.Add(xmlSchemaCollection);
			xmlValidatingReader.ValidationEventHandler += reader_ValidationEventHandler;
			cErro = "";
			try
			{
				while (xmlValidatingReader.Read())
				{
				}
			}
			catch (Exception ex)
			{
				cErro = ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
			}
			xmlValidatingReader.Close();
			Retorno = 0;
			RetornoString = "";
			if (cErro != "")
			{
				Retorno = 1;
				RetornoString = "Início da validação...\r\n\r\n";
				RetornoString = RetornoString + "Arquivo XML: " + cRotaArqXML + "\r\n";
				RetornoString = RetornoString + "Arquivo SCHEMA: " + text + "\r\n\r\n";
				RetornoString += cErro;
				RetornoString += "\r\n...Final da validação";
			}
		}
		else if (!flag)
		{
			Retorno = 2;
			RetornoString = "Arquivo XML não foi encontrato";
		}
		else if (!flag2)
		{
			Retorno = 3;
			RetornoString = "Arquivo XSD (schema) não foi encontrado em " + text;
		}
	}

	private void reader_ValidationEventHandler(object sender, ValidationEventArgs e)
	{
		cErro += $"Linha: {e.Exception.LineNumber} Coluna: {e.Exception.LinePosition} Erro: {e.Exception.Message}\r\n";
	}

	public void TipoArquivoXML(string cRotaArqXML)
	{
		nRetornoTipoArq = 0;
		cRetornoTipoArq = string.Empty;
		cArquivoSchema = string.Empty;
		TagAssinar = string.Empty;
		if (File.Exists(cRotaArqXML))
		{
			XmlTextReader xmlTextReader = null;
			try
			{
				xmlTextReader = new XmlTextReader(cRotaArqXML);
				while (xmlTextReader.Read())
				{
					if (xmlTextReader.NodeType != XmlNodeType.Element)
					{
						continue;
					}
					for (int i = 0; i < SchemaXML.lstXMLTag.Count; i++)
					{
						if (SchemaXML.lstXMLTag[i] == xmlTextReader.Name)
						{
							nRetornoTipoArq = SchemaXML.lstXMLID[i];
							cRetornoTipoArq = SchemaXML.lstXMLTextoID[i];
							cArquivoSchema = SchemaXML.lstXMLSchema[i];
							TagAssinar = SchemaXML.lstXMLTagAssinar[i];
							break;
						}
					}
					if (nRetornoTipoArq != 0)
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				nRetornoTipoArq = 102;
				cRetornoTipoArq = ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
			}
			finally
			{
				if (xmlTextReader != null && xmlTextReader.ReadState != ReadState.Closed)
				{
					xmlTextReader.Close();
				}
			}
		}
		else
		{
			nRetornoTipoArq = 100;
			cRetornoTipoArq = "Arquivo XML não foi encontrado";
		}
		if (nRetornoTipoArq == 0)
		{
			nRetornoTipoArq = 101;
			cRetornoTipoArq = "Não foi possível identificar o arquivo XML";
		}
	}
}
