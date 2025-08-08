using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalCest
{
	public int id;

	public string codigoCest;

	public string ncm;

	public int codigoEstado;

	public decimal valorMva;

	public decimal percentualIcmsSt;

	public decimal percentualReducaoBaseCalculoICMSST;
}
