using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IWorkFlowTarefa
{
	IList<MapTableWorkFlowTarefa> ObterTodosWorkFlowTarefa();

	MapTableWorkFlowTarefa ObterWorkFlowTarefa(int id);

	MapTableWorkFlowTarefa ObterWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa);

	int InserirWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa);

	int AlterarWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa, Hashtable camposAlterados);

	int ExcluirWorkFlowTarefa(int id);
}
