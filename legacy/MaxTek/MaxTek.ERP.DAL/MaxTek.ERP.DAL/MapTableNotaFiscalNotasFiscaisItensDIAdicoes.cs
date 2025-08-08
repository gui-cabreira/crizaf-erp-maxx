using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalNotasFiscaisItensDIAdicoes
{
	public int codigoEmpresa;

	public int codigoSerieNotaFiscal;

	public int codigoNotaFiscal;

	public int ordem;

	public string numeroDI;

	public int numeroAdicao;

	public int numeroSequenciaAdicao;

	public string codigoFabricante;

	public decimal valorDescontoDI;

	public string codigoDrawBack;
}
