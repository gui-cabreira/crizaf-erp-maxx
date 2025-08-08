using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableDesenvolvimentoClasse
{
	public int id;

	public string nomeBaseDados;

	public string nomeEsquema;

	public int idEsquema;

	public string nomeClasse;

	public int idTabela;

	public string nomeTabela;

	public string nomeTabelaPervasive;
}
