namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class RetornoNFe
{
	public enum EtapaEnvio
	{
		OK,
		VerSituacao,
		EnvioPedido
	}

	private string _nomearqxml;

	private TipoEmissao _tipoEmissao;

	private int _codigoRetorno;

	private string _motivoRetorno;

	private EtapaEnvio _etapa;

	public int CodigoRetorno => _codigoRetorno;

	public string ArquivoXmlNFe => _nomearqxml;

	public TipoEmissao TipoEmissao => _tipoEmissao;

	public string MotivoRetorno => _motivoRetorno;

	public EtapaEnvio Etapa => _etapa;

	public RetornoNFe(int codigo, string nomearqxml, EtapaEnvio etapa, TipoEmissao tEmis, string motivoRetorno)
	{
		_nomearqxml = nomearqxml;
		_tipoEmissao = tEmis;
		_codigoRetorno = codigo;
		_motivoRetorno = motivoRetorno;
		_etapa = etapa;
	}
}
