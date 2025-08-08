using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace MaxTek.ERP.BLL.NotaFiscal;

public class AssinaturaDigital
{
	private XmlDocument XMLDoc;

	public int intResultado { get; private set; }

	public string vXMLStringAssinado { get; private set; }

	public void Assinar(string strArqXMLAssinar, string strUri, X509Certificate2 x509Certificado, string strArqXMLAssinado)
	{
		intResultado = 0;
		StreamReader streamReader = null;
		try
		{
			streamReader = File.OpenText(strArqXMLAssinar);
			string xml = streamReader.ReadToEnd();
			streamReader.Close();
			try
			{
				string findValue = "";
				if (x509Certificado != null)
				{
					findValue = x509Certificado.Subject.ToString();
				}
				X509Certificate2 x509Certificate = new X509Certificate2();
				X509Store x509Store = new X509Store("MY", StoreLocation.CurrentUser);
				x509Store.Open(OpenFlags.OpenExistingOnly);
				X509Certificate2Collection certificates = x509Store.Certificates;
				X509Certificate2Collection x509Certificate2Collection = certificates.Find(X509FindType.FindBySubjectDistinguishedName, findValue, validOnly: false);
				if (x509Certificate2Collection.Count == 0)
				{
					intResultado = 2;
					throw new Exception("Foram detectados problemas com o certificado digital. (Código do Erro: 2)");
				}
				x509Certificate = x509Certificate2Collection[0];
				string text = x509Certificate.GetKeyAlgorithm().ToString();
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.PreserveWhitespace = false;
				try
				{
					xmlDocument.LoadXml(xml);
					int count = xmlDocument.GetElementsByTagName(strUri).Count;
					if (count == 0)
					{
						throw new Exception("A tag de assinatura " + strUri.Trim() + " não existe no XML. (Código do Erro: 4)");
					}
					if (count > 1)
					{
						throw new Exception("A tag de assinatura " + strUri.Trim() + " não é unica. (Código do Erro: 5)");
					}
					if (xmlDocument.GetElementsByTagName("Signature").Count != 0)
					{
						return;
					}
					try
					{
						SignedXml signedXml = new SignedXml(xmlDocument);
						signedXml.SigningKey = x509Certificate.PrivateKey;
						Reference reference = new Reference();
						XmlAttributeCollection attributes = xmlDocument.GetElementsByTagName(strUri).Item(0).Attributes;
						foreach (XmlAttribute item in attributes)
						{
							if (item.Name == "Id")
							{
								reference.Uri = "#" + item.InnerText;
							}
						}
						XmlDsigEnvelopedSignatureTransform transform = new XmlDsigEnvelopedSignatureTransform();
						reference.AddTransform(transform);
						XmlDsigC14NTransform transform2 = new XmlDsigC14NTransform();
						reference.AddTransform(transform2);
						signedXml.AddReference(reference);
						KeyInfo keyInfo = new KeyInfo();
						keyInfo.AddClause(new KeyInfoX509Data(x509Certificate));
						signedXml.KeyInfo = keyInfo;
						signedXml.ComputeSignature();
						XmlElement xml2 = signedXml.GetXml();
						if (strUri == "infEvento")
						{
							XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("evento");
							XmlNode xmlNode = elementsByTagName.Item(0);
							xmlNode.AppendChild(xml2);
						}
						else
						{
							xmlDocument.DocumentElement.AppendChild(xmlDocument.ImportNode(xml2, deep: true));
						}
						XMLDoc = new XmlDocument();
						XMLDoc.PreserveWhitespace = false;
						XMLDoc = xmlDocument;
						vXMLStringAssinado = XMLDoc.OuterXml;
						StreamWriter streamWriter = File.CreateText(strArqXMLAssinado);
						streamWriter.Write(vXMLStringAssinado);
						streamWriter.Close();
					}
					catch (Exception ex)
					{
						if (intResultado == 0)
						{
							intResultado = 3;
						}
						throw ex;
					}
				}
				catch (Exception ex2)
				{
					if (intResultado == 0)
					{
						intResultado = 6;
					}
					throw ex2;
				}
			}
			catch (Exception ex3)
			{
				if (intResultado == 0)
				{
					intResultado = 1;
				}
				throw ex3;
			}
		}
		catch (Exception ex4)
		{
			if (intResultado == 0)
			{
				intResultado = 7;
			}
			throw ex4;
		}
		finally
		{
			streamReader.Close();
		}
	}

	public void Assinar(string strArqXMLAssinar, string strUri, X509Certificate2 x509Certificado)
	{
		try
		{
			Assinar(strArqXMLAssinar, strUri, x509Certificado, strArqXMLAssinar);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
