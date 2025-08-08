using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloComercialFiscal
{
	private static IComercialFiscalClassificacaoFiscal _comercialFiscalClassificacaoFiscalDao = AcessoDados.ComercialFiscalClassificacaoFiscalDAO;

	private static IComercialFiscalContaContabil _comercialFiscalContaContabilDao = AcessoDados.ComercialFiscalContaContabilDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialFiscalClassificacaoFiscal> ObterTodosComercialFiscalClassificacaoFiscal()
	{
		return ObjectDataMapper.MapObjectList<ComercialFiscalClassificacaoFiscal>((IList)_comercialFiscalClassificacaoFiscalDao.ObterTodosComercialFiscalClassificacaoFiscal());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFiscalClassificacaoFiscal ObterComercialFiscalClassificacaoFiscal(int id)
	{
		return ObjectDataMapper.MapObject<ComercialFiscalClassificacaoFiscal>(_comercialFiscalClassificacaoFiscalDao.ObterComercialFiscalClassificacaoFiscal(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFiscalClassificacaoFiscal ObterComercialFiscalClassificacaoFiscal(ComercialFiscalClassificacaoFiscal comercialFiscalClassificacaoFiscal)
	{
		return ObjectDataMapper.MapObject<ComercialFiscalClassificacaoFiscal>(_comercialFiscalClassificacaoFiscalDao.ObterComercialFiscalClassificacaoFiscal((MapTableComercialFiscalClassificacaoFiscal)comercialFiscalClassificacaoFiscal.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialFiscalClassificacaoFiscal(ComercialFiscalClassificacaoFiscal comercialFiscalClassificacaoFiscal)
	{
		return _comercialFiscalClassificacaoFiscalDao.InserirComercialFiscalClassificacaoFiscal((MapTableComercialFiscalClassificacaoFiscal)comercialFiscalClassificacaoFiscal.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialFiscalClassificacaoFiscal(ComercialFiscalClassificacaoFiscal comercialFiscalClassificacaoFiscal, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialFiscalClassificacaoFiscalDao.AlterarComercialFiscalClassificacaoFiscal((MapTableComercialFiscalClassificacaoFiscal)comercialFiscalClassificacaoFiscal.ObterDadosMapeados(), camposAlterados);
		comercialFiscalClassificacaoFiscal.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialFiscalClassificacaoFiscal(int id)
	{
		return _comercialFiscalClassificacaoFiscalDao.ExcluirComercialFiscalClassificacaoFiscal(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialFiscalContaContabil> ObterTodosComercialFiscalContaContabil()
	{
		return ObjectDataMapper.MapObjectList<ComercialFiscalContaContabil>((IList)_comercialFiscalContaContabilDao.ObterTodosComercialFiscalContaContabil());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFiscalContaContabil ObterComercialFiscalContaContabil(int id)
	{
		return ObjectDataMapper.MapObject<ComercialFiscalContaContabil>(_comercialFiscalContaContabilDao.ObterComercialFiscalContaContabil(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFiscalContaContabil ObterComercialFiscalContaContabil(ComercialFiscalContaContabil comercialFiscalContaContabil)
	{
		return ObjectDataMapper.MapObject<ComercialFiscalContaContabil>(_comercialFiscalContaContabilDao.ObterComercialFiscalContaContabil((MapTableComercialFiscalContaContabil)comercialFiscalContaContabil.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialFiscalContaContabil(ComercialFiscalContaContabil comercialFiscalContaContabil)
	{
		return _comercialFiscalContaContabilDao.InserirComercialFiscalContaContabil((MapTableComercialFiscalContaContabil)comercialFiscalContaContabil.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialFiscalContaContabil(ComercialFiscalContaContabil comercialFiscalContaContabil, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialFiscalContaContabilDao.AlterarComercialFiscalContaContabil((MapTableComercialFiscalContaContabil)comercialFiscalContaContabil.ObterDadosMapeados(), camposAlterados);
		comercialFiscalContaContabil.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialFiscalContaContabil(int id)
	{
		return _comercialFiscalContaContabilDao.ExcluirComercialFiscalContaContabil(id);
	}
}
