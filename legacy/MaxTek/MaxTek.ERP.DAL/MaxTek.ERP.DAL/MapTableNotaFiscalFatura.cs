using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalFatura
{
	public int codigoEmpresa;

	public int codigoNotaFiscal;

	public string codigoFatura;

	public decimal valorFatura;

	public DateTime vencimento;

	public int codigoSerieNotaFiscal;

	public bool isNaoGerarTitulo;
}
