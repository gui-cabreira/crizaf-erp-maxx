using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloRH
{
	private static IRHFuncionario _rHFuncionarioDao = AcessoDados.RHFuncionarioDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<RHFuncionario> ObterTodosRHFuncionario()
	{
		return ObjectDataMapper.MapObjectList<RHFuncionario>((IList)_rHFuncionarioDao.ObterTodosRHFuncionario());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static RHFuncionario ObterRHFuncionario(int codigo)
	{
		return ObjectDataMapper.MapObject<RHFuncionario>(_rHFuncionarioDao.ObterRHFuncionario(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static RHFuncionario ObterRHFuncionario(RHFuncionario rHFuncionario)
	{
		return ObjectDataMapper.MapObject<RHFuncionario>(_rHFuncionarioDao.ObterRHFuncionario((MapTableRHFuncionario)rHFuncionario.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirRHFuncionario(RHFuncionario rHFuncionario)
	{
		return _rHFuncionarioDao.InserirRHFuncionario((MapTableRHFuncionario)rHFuncionario.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarRHFuncionario(RHFuncionario rHFuncionario, Hashtable camposAlterados)
	{
		int num = 0;
		num = _rHFuncionarioDao.AlterarRHFuncionario((MapTableRHFuncionario)rHFuncionario.ObterDadosMapeados(), camposAlterados);
		rHFuncionario.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirRHFuncionario(int codigo)
	{
		return _rHFuncionarioDao.ExcluirRHFuncionario(codigo);
	}
}
