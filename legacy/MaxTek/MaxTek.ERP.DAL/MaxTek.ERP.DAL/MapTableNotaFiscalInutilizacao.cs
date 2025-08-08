using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalInutilizacao
{
	public int id;

	public int codigoEmpresa;

	public int codigoModelo;

	public int codigoSerie;

	public int ano;

	public int notaInicial;

	public int notaFinal;

	public int codigoStatus;

	public string status;

	public DateTime dataRecibo;

	public string protocolo;

	public string usuario;

	public string justificativa;
}
