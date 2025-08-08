using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalNotasFiscaisItensDI
{
	public int codigoEmpresa;

	public int codigoSerieNotaFiscal;

	public int codigoNotaFiscal;

	public int ordem;

	public string numeroDI;

	public DateTime datasDI;

	public string localDesembarque;

	public string ufDesembarque;

	public DateTime dataDesembarque;

	public int tipoViaTransporte;

	public decimal vafrmm;

	public int tipoIntermedio;

	public string cnpja;

	public string ufTerceiro;

	public string codigoExportador;
}
