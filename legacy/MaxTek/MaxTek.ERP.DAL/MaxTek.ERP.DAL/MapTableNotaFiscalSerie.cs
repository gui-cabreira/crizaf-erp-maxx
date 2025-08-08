using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalSerie
{
	public int id;

	public int codigoEmpresa;

	public int codigoSerie;

	public string nomeSerie;

	public int proximoNumero;

	public int indice;
}
