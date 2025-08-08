using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IComercialVendasPedidosItens
{
	IList<MapTableComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens();

	IList<MapTableComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens(int codigoPedido);

	MapTableComercialVendasPedidosItens ObterComercialVendasPedidosItens(int id);

	MapTableComercialVendasPedidosItens ObterComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens);

	int InserirComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens);

	int AlterarComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens, Hashtable camposAlterados);

	int ExcluirComercialVendasPedidosItens(int id);
}
