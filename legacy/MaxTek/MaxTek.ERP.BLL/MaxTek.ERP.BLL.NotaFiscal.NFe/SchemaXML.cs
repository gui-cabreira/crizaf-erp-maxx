using System.Collections.Generic;

namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class SchemaXML
{
	public static List<string> lstXMLTag = new List<string>();

	public static List<int> lstXMLID = new List<int>();

	public static List<string> lstXMLTextoID = new List<string>();

	public static List<string> lstXMLSchema = new List<string>();

	public static List<string> lstXMLTagAssinar = new List<string>();

	public static void CriarListaIDXML()
	{
		lstXMLID.Clear();
		lstXMLSchema.Clear();
		lstXMLTag.Clear();
		lstXMLTagAssinar.Clear();
		lstXMLTextoID.Clear();
		lstXMLTag.Add("nfeProc");
		lstXMLID.Add(9);
		lstXMLTextoID.Add("XML de distribuição da NFe com protocolo de autorização anexado");
		lstXMLSchema.Add("procNFe_v1.10.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("procCancNFe");
		lstXMLID.Add(10);
		lstXMLTextoID.Add("XML de distribuição do Cancelamento da NFe com protocolo de autorização anexado");
		lstXMLSchema.Add("procCancNFe_v1.07.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("procInutNFe");
		lstXMLID.Add(11);
		lstXMLTextoID.Add("XML de distribuição de Inutilização de Números de NFe com protocolo de autorização anexado");
		lstXMLSchema.Add("procInutNFe_v1.07.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("NFe");
		lstXMLID.Add(1);
		lstXMLTextoID.Add("XML de Nota Fiscal Eletrônica");
		lstXMLSchema.Add("nfe_v1.10.xsd");
		lstXMLTagAssinar.Add("infNFe");
		lstXMLTag.Add("enviNFe");
		lstXMLID.Add(2);
		lstXMLTextoID.Add("XML de Envio de Lote de Notas Fiscais Eletrônicas");
		lstXMLSchema.Add("enviNFe_v1.10.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("cancNFe");
		lstXMLID.Add(3);
		lstXMLTextoID.Add("XML de Cancelamento de Nota Fiscal Eletrônica");
		lstXMLSchema.Add("cancNFe_v1.07.xsd");
		lstXMLTagAssinar.Add("infCanc");
		lstXMLTag.Add("inutNFe");
		lstXMLID.Add(4);
		lstXMLTextoID.Add("XML de Inutilização de Numerações de Notas Fiscais Eletrônicas");
		lstXMLSchema.Add("inutNFe_v1.07.xsd");
		lstXMLTagAssinar.Add("infInut");
		lstXMLTag.Add("consSitNFe");
		lstXMLID.Add(5);
		lstXMLTextoID.Add("XML de Consulta da Situação da Nota Fiscal Eletrônica");
		lstXMLSchema.Add("consSitNFe_v1.07.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("consReciNFe");
		lstXMLID.Add(6);
		lstXMLTextoID.Add("XML de Consulta do Recibo do Lote de Notas Fiscais Eletrônicas");
		lstXMLSchema.Add("consReciNfe_v1.10.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("consStatServ");
		lstXMLID.Add(7);
		lstXMLTextoID.Add("XML de Consulta da Situação do Serviço da Nota Fiscal Eletrônica");
		lstXMLSchema.Add("consStatServ_v1.07.xsd");
		lstXMLTagAssinar.Add(string.Empty);
		lstXMLTag.Add("ConsCad");
		lstXMLID.Add(8);
		lstXMLTextoID.Add("XML de Consulta do Cadastro do Contribuinte");
		lstXMLSchema.Add("consCad_v1.01.xsd");
		lstXMLTagAssinar.Add(string.Empty);
	}
}
