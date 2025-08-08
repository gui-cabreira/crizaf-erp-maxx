using System;

namespace MaxTek.ERP.BLL.NotaFiscal.NFe;

public class SituacaoServicoNFe
{
	private int _codigo;

	private string _motivo;

	private DateTime _datahora;

	public int Codigo => _codigo;

	public string Motivo => _motivo;

	public DateTime DataHora => _datahora;

	public bool OK => _codigo == 107;

	public SituacaoServicoNFe(int codigo, string motivo, DateTime datahora)
	{
		_codigo = codigo;
		_motivo = motivo;
		_datahora = datahora;
	}
}
