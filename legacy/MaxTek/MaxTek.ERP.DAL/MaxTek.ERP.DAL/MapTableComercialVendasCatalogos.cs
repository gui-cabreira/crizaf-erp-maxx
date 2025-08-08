using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialVendasCatalogos
{
	public int id;

	public string nome;

	public string descricao;

	public bool isPercentualPrecoBase;

	public decimal percentualPrecoBase;
}
