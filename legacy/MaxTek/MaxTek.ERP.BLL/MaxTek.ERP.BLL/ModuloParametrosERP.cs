using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloParametrosERP
{
	private static IParametrosSociedade _parametrosSociedadeDao = AcessoDados.ParametrosSociedadeDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ParametrosSociedade> ObterTodosParametrosSociedade()
	{
		return ObjectDataMapper.MapObjectList<ParametrosSociedade>((IList)_parametrosSociedadeDao.ObterTodosParametrosSociedade());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ParametrosSociedade ObterParametrosSociedade(int id)
	{
		return ObjectDataMapper.MapObject<ParametrosSociedade>(_parametrosSociedadeDao.ObterParametrosSociedade(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ParametrosSociedade ObterParametrosSociedade(ParametrosSociedade parametrosSociedade)
	{
		return ObjectDataMapper.MapObject<ParametrosSociedade>(_parametrosSociedadeDao.ObterParametrosSociedade((MapTableParametrosSociedade)parametrosSociedade.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirParametrosSociedade(ParametrosSociedade parametrosSociedade)
	{
		return _parametrosSociedadeDao.InserirParametrosSociedade((MapTableParametrosSociedade)parametrosSociedade.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarParametrosSociedade(ParametrosSociedade parametrosSociedade, Hashtable camposAlterados)
	{
		int num = 0;
		num = _parametrosSociedadeDao.AlterarParametrosSociedade((MapTableParametrosSociedade)parametrosSociedade.ObterDadosMapeados(), camposAlterados);
		parametrosSociedade.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirParametrosSociedade(int id)
	{
		return _parametrosSociedadeDao.ExcluirParametrosSociedade(id);
	}
}
