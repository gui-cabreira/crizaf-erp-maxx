using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableClasse
{
	public int id;

	public string bancoDados;

	public string nomeClasse;

	public string nomeEsquema;

	public string nomeTabela;

	public string nomeTabelaPervasive;

	public string nomeCampoDados;

	public string nomeCampoDadosPervasive;

	public string tipoDadoBanco;

	public int quantidadeCaracteres;

	public string tipoDado;

	public string nomeCampo;

	public string nomePropriedade;

	public bool isChavePrimaria;

	public bool isDesconsidera;

	public int numeroChaveUnica;

	public int numeroChaveEstrangeira;
}
