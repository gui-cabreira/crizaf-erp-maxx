using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IComercialVendasCatalogos
{
	IList<MapTableComercialVendasCatalogos> ObterTodosComercialVendasCatalogos();

	MapTableComercialVendasCatalogos ObterComercialVendasCatalogos(int id);

	MapTableComercialVendasCatalogos ObterComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos);

	int InserirComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos);

	int AlterarComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos, Hashtable camposAlterados);

	int ExcluirComercialVendasCatalogos(int id);
}
