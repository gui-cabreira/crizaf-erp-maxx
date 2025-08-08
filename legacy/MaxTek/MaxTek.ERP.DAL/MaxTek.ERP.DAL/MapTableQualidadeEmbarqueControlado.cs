using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableQualidadeEmbarqueControlado
{
	public int id;

	public string codigoProduto;

	public string codigoProdutoCliente;

	public DateTime dataInicioEmbarqueControlado;

	public DateTime dataPrevisaoTerminoEmbarqueControlado;

	public int nivelEmbarqueControlado;

	public string descricaoDefeito;

	public bool isFechado;
}
