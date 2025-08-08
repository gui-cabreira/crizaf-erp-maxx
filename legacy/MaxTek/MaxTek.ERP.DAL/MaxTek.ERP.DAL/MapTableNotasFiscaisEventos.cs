using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotasFiscaisEventos
{
	public int codigoEmpresa;

	public int codigoNotaFiscal;

	public int codigoSerieNotaFiscal;

	public int codigoEvento;

	public int codigoSequenciaEvento;

	public string evento;

	public string descricao;

	public string protocolo;

	public string dataEvento;
}
