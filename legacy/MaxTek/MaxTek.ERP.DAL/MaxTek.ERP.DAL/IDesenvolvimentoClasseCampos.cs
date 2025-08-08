using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IDesenvolvimentoClasseCampos
{
	IList<MapTableDesenvolvimentoClasseCampos> ObterTodosDesenvolvimentoClasseCampos();

	MapTableDesenvolvimentoClasseCampos ObterDesenvolvimentoClasseCampos(int id);

	MapTableDesenvolvimentoClasseCampos ObterDesenvolvimentoClasseCampos(MapTableDesenvolvimentoClasseCampos DesenvolvimentoClasseCampos);

	int InserirDesenvolvimentoClasseCampos(MapTableDesenvolvimentoClasseCampos DesenvolvimentoClasseCampos);

	int AlterarDesenvolvimentoClasseCampos(MapTableDesenvolvimentoClasseCampos DesenvolvimentoClasseCampos, Hashtable camposAlterados);

	int ExcluirDesenvolvimentoClasseCampos(int id);
}
