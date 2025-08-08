using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloWorkFlow
{
	private static IWorkFlowTarefa _workFlowTarefaDao = AcessoDados.WorkFlowTarefaDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<WorkFlowTarefa> ObterTodosWorkFlowTarefa()
	{
		return ObjectDataMapper.MapObjectList<WorkFlowTarefa>((IList)_workFlowTarefaDao.ObterTodosWorkFlowTarefa());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static WorkFlowTarefa ObterWorkFlowTarefa(int id)
	{
		return ObjectDataMapper.MapObject<WorkFlowTarefa>(_workFlowTarefaDao.ObterWorkFlowTarefa(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static WorkFlowTarefa ObterWorkFlowTarefa(WorkFlowTarefa workFlowTarefa)
	{
		return ObjectDataMapper.MapObject<WorkFlowTarefa>(_workFlowTarefaDao.ObterWorkFlowTarefa((MapTableWorkFlowTarefa)workFlowTarefa.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirWorkFlowTarefa(WorkFlowTarefa workFlowTarefa)
	{
		return _workFlowTarefaDao.InserirWorkFlowTarefa((MapTableWorkFlowTarefa)workFlowTarefa.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarWorkFlowTarefa(WorkFlowTarefa workFlowTarefa, Hashtable camposAlterados)
	{
		int num = 0;
		num = _workFlowTarefaDao.AlterarWorkFlowTarefa((MapTableWorkFlowTarefa)workFlowTarefa.ObterDadosMapeados(), camposAlterados);
		workFlowTarefa.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirWorkFlowTarefa(int id)
	{
		return _workFlowTarefaDao.ExcluirWorkFlowTarefa(id);
	}
}
