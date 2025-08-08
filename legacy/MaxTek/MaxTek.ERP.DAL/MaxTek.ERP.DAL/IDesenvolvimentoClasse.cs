using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IDesenvolvimentoClasse
{
	IList<MapTableDesenvolvimentoClasse> ObterTodosDesenvolvimentoClasse();

	MapTableDesenvolvimentoClasse ObterDesenvolvimentoClasse(int id);

	MapTableDesenvolvimentoClasse ObterDesenvolvimentoClasse(MapTableDesenvolvimentoClasse DesenvolvimentoClasse);

	int InserirDesenvolvimentoClasse(MapTableDesenvolvimentoClasse DesenvolvimentoClasse);

	int AlterarDesenvolvimentoClasse(MapTableDesenvolvimentoClasse DesenvolvimentoClasse, Hashtable camposAlterados);

	int ExcluirDesenvolvimentoClasse(int id);
}
