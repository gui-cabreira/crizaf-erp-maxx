using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProdutoTipo
{
	public int id;

	public string tipoProduto;

	public string nomeDimensao01;

	public string nomeDimensao02;

	public string nomeDimensao03;

	public string nomeDimensao04;

	public int codigoUnidadeEstoque;

	public int codigoUnidadeCompra;
}
