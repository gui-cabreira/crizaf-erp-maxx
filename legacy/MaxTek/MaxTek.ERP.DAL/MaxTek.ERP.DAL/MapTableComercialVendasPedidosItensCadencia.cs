using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialVendasPedidosItensCadencia
{
	public int id;

	public int codigoPedidoItem;

	public DateTime dataEntrega;

	public DateTime dataLiberacaoProducao;

	public bool isFirme;

	public decimal quantidadePedida;

	public decimal quantidadeEntrega;

	public string comentarioCadencia;
}
