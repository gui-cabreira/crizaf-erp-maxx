namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class RetornoLote
{
	private string _chave;

	private int _codigo;

	private string _motivo;

	private string _protocolo;

	private string _retornoCompleto;

	public string Chave => _chave;

	public int Codigo => _codigo;

	public string Motivo => _motivo;

	public string Protocolo => _protocolo;

	public string RetornoCompleto => _retornoCompleto;

	public RetornoLote(string chave, int cod, string motivo, string protocolo, string retornoCompleto)
	{
		_chave = chave;
		_codigo = cod;
		_motivo = motivo;
		_protocolo = protocolo;
		_retornoCompleto = retornoCompleto;
	}
}
