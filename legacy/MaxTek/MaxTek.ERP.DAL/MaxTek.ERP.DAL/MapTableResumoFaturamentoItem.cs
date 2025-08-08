using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableResumoFaturamentoItem
{
	public int codigoCliente;

	public string codigoProduto;

	public decimal quantidade;

	public decimal valorUnitario;

	public decimal valorTotal;

	public decimal valorImposto;

	public string cfop;

	public string unidade;

	public string contaContabil;
}
