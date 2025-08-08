using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableComercialVendasCatalogosCodigos
{
	public int id;

	public int codigoCatalogo;

	public string codigoCatalogoProduto;

	public string descricaoCatalogoProduto;

	public int codigoProduto;

	public decimal preco;

	public decimal desconto;
}
