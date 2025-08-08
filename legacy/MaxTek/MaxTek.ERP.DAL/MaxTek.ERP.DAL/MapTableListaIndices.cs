using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableListaIndices
{
	public string nomeSchema;

	public string nomeTabela;

	public int idTabela;

	public string nomeIndex;

	public int index_id;

	public int tipo;

	public bool isUnico;

	public bool isPk;
}
