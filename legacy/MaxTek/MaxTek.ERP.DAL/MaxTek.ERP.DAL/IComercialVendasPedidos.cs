using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IComercialVendasPedidos
{
	IList<MapTableComercialVendasPedidos> ObterTodosComercialVendasPedidos();

	IList<MapTableComercialVendasPedidos> ObterTodosComercialVendasPedidosPorDataCadastro(DateTime dataInicio, DateTime dataFim);

	MapTableComercialVendasPedidos ObterComercialVendasPedidos(int id);

	MapTableComercialVendasPedidos ObterComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos);

	int InserirComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos);

	int AlterarComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos, Hashtable camposAlterados);

	int ExcluirComercialVendasPedidos(int id);
}
