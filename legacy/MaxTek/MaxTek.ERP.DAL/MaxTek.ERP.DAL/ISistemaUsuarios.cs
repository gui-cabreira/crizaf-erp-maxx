using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface ISistemaUsuarios
{
	IList<MapTableSistemaUsuarios> ObterTodosSistemaUsuarios();

	MapTableSistemaUsuarios ObterSistemaUsuarios(string nomeLogon);

	MapTableSistemaUsuarios ObterSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios);

	int InserirSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios);

	int AlterarSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios, Hashtable camposAlterados);

	int ExcluirSistemaUsuarios(string nomeLogon);

	int ExcluirSistemaUsuarios(int id);
}
