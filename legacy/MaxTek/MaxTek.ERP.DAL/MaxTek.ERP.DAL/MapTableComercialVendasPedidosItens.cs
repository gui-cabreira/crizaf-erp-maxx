using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialVendasPedidosItens
{
	public int id;

	public int codigoPedidoVenda;

	public int codigoPedidoVendaItem;

	public int codigoProduto;

	public decimal valorUnitario;

	public decimal valorPercentualDesconto;

	public decimal valorCustosDiversos;

	public int codigoUnidade;

	public DateTime dataEntrega;

	public int codigoEmbalagem;

	public bool isReserva;

	public bool isCancelado;

	public string comentarioItem;
}
