using System;
using System.Configuration;
using DevExpress.XtraEditors;
using MaxTek.DataBase;

namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class ConfigNFe
{
	private static readonly string AmbienteNF = ConfigurationManager.AppSettings.Get("AmbienteNF");

	private static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;

	private static ConfigNFe _instancia;

	public static string VersaoNfe = "1.10";

	public static string VersaoEnvNfe = "1.10";

	public static string VersaoRetEnvNfe = "1.10";

	public static string VersaoConsReciNfe = "1.10";

	public static string VersaoProcNfe = "1.10";

	public static string VersaoCancNfe = "1.07";

	public static string VersaoRetCancNfe = "1.07";

	public static string VersaoProcCancNfe = "1.07";

	public static string VersaoInutNfe = "1.07";

	public static string VersaoRetInutNfe = "1.07";

	public static string VersaoProcInutNfe = "1.07";

	public static string VersaoConsSitNfe = "1.07";

	public static string VersaoRetConsSitNfe = "1.07";

	public static string VersaoConsStatServ = "1.07";

	public static string VersaoRetConsStatServ = "1.07";

	public static string VersaoConsCad = "1.01";

	public static string VersaoRetConsCad = "1.01";

	public static string ExtNfe = "-nfe.xml";

	public static string ExtEnvioLoteNfe = "-env-lot.xml";

	public static string ExtReciboEnvioLoteNfe = "-rec.xml";

	public static string ExtProcLoteNfe = "-ped-rec.xml";

	public static string ExtRetProcLoteNfe = "-pro-rec.xml";

	public static string ExtDenegacao = "-den.xml";

	public static string ExtPedCanc = "-ped-can.xml";

	public static string ExtCanc = "-can.xml";

	public static string ExtPedInu = "-ped-inu.xml";

	public static string ExtInu = "-inu.xml";

	public static string ExtPedSitNfe = "-ped-sit.xml";

	public static string ExtSitNfe = "-sit.xml";

	public static string ExtStatus = "-sta.xml";

	public static string ExtEnvCartaCorrecao = "-ccor.xml";

	public static string ExtRetCartaCorrecao = "-ret-ccor.xml";

	public static ConfigNFe Instancia
	{
		get
		{
			if (_instancia == null)
			{
				_instancia = new ConfigNFe();
			}
			return _instancia;
		}
	}

	public string DirSistema => AppDir;

	public string DirNFe => $"{AppDir}NFe";

	public string DirNFeEmpresa => DirNFe + "\\" + NomeEmpresa;

	public string DirDanfe => DirNFeEmpresa + "\\Danfe";

	public string DirNFeContingencia => DirNFeEmpresa + "\\Contingencia";

	public string DirNFeLote => DirNFeEmpresa + "\\Lote";

	public string DirNFeStore => DirNFeEmpresa + "\\Store";

	public string DirNFeSchemas => DirNFe + "\\Schemas";

	public string DirNFeErros => DirNFeEmpresa + "\\Erros";

	public string NomeEmpresa => BaseDadosERP.NomeBaseDados;

	public string DirNFeAutorizadas => DirNFeEmpresa + "\\Autorizadas\\" + DateTime.Today.ToString("yyyyMMdd");

	public string DirNFeAutorizadasSemDirData => DirNFeEmpresa + "\\Autorizadas";

	public static TipoAmbiente Ambiente
	{
		get
		{
			TipoAmbiente tipoAmbiente = TipoAmbiente.Homologacao;
			if (AmbienteNF == "Producao")
			{
				return TipoAmbiente.Producao;
			}
			if (AmbienteNF == "Homologacao")
			{
				return TipoAmbiente.Homologacao;
			}
			XtraMessageBox.Show("Ambiente da Nota Fiscal Eletronica não definido no arquivo de configuração. As notas serão emitidas no ambiente de Homologação");
			return TipoAmbiente.Homologacao;
		}
	}

	public int AmbienteInt => (Ambiente != TipoAmbiente.Homologacao) ? 1 : 2;

	private ConfigNFe()
	{
	}
}
