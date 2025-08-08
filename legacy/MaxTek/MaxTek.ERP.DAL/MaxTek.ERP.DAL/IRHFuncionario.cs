using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IRHFuncionario
{
	IList<MapTableRHFuncionario> ObterTodosRHFuncionario();

	MapTableRHFuncionario ObterRHFuncionario(int codigo);

	MapTableRHFuncionario ObterRHFuncionario(MapTableRHFuncionario RHFuncionario);

	int InserirRHFuncionario(MapTableRHFuncionario RHFuncionario);

	int AlterarRHFuncionario(MapTableRHFuncionario RHFuncionario, Hashtable camposAlterados);

	int ExcluirRHFuncionario(int codigo);
}
