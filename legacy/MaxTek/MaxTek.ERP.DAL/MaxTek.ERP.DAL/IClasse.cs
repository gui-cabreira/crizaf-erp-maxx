using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IClasse
{
	IList<MapTableClasse> ObterClasse(string nomeServidor, string bancoDados, string nomeEsquema, string nomeTabela);

	int Alterar(MapTableClasse classe, Hashtable camposAlterados);

	int Inserir(MapTableClasse classe);

	void Excluir(string nomeServidor, string nomeBaseDados, string nomeEsquema, string nomeTabela);
}
