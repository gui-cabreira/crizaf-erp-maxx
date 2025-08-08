using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloDesenvolvimento
{
	private static IDesenvolvimentoClasse _desenvolvimentoClasseDao = AcessoDados.DesenvolvimentoClasseDAO;

	private static IDesenvolvimentoClasseCampos _desenvolvimentoClasseCamposDao = AcessoDados.DesenvolvimentoClasseCamposDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<DesenvolvimentoClasse> ObterTodosDesenvolvimentoClasse()
	{
		return ObjectDataMapper.MapObjectList<DesenvolvimentoClasse>((IList)_desenvolvimentoClasseDao.ObterTodosDesenvolvimentoClasse());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static DesenvolvimentoClasse ObterDesenvolvimentoClasse(int id)
	{
		return ObjectDataMapper.MapObject<DesenvolvimentoClasse>(_desenvolvimentoClasseDao.ObterDesenvolvimentoClasse(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static DesenvolvimentoClasse ObterDesenvolvimentoClasse(DesenvolvimentoClasse desenvolvimentoClasse)
	{
		return ObjectDataMapper.MapObject<DesenvolvimentoClasse>(_desenvolvimentoClasseDao.ObterDesenvolvimentoClasse((MapTableDesenvolvimentoClasse)desenvolvimentoClasse.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirDesenvolvimentoClasse(DesenvolvimentoClasse desenvolvimentoClasse)
	{
		return _desenvolvimentoClasseDao.InserirDesenvolvimentoClasse((MapTableDesenvolvimentoClasse)desenvolvimentoClasse.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarDesenvolvimentoClasse(DesenvolvimentoClasse desenvolvimentoClasse, Hashtable camposAlterados)
	{
		int num = 0;
		num = _desenvolvimentoClasseDao.AlterarDesenvolvimentoClasse((MapTableDesenvolvimentoClasse)desenvolvimentoClasse.ObterDadosMapeados(), camposAlterados);
		desenvolvimentoClasse.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirDesenvolvimentoClasse(int id)
	{
		return _desenvolvimentoClasseDao.ExcluirDesenvolvimentoClasse(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<DesenvolvimentoClasseCampos> ObterTodosDesenvolvimentoClasseCampos()
	{
		return ObjectDataMapper.MapObjectList<DesenvolvimentoClasseCampos>((IList)_desenvolvimentoClasseCamposDao.ObterTodosDesenvolvimentoClasseCampos());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static DesenvolvimentoClasseCampos ObterDesenvolvimentoClasseCampos(int id)
	{
		return ObjectDataMapper.MapObject<DesenvolvimentoClasseCampos>(_desenvolvimentoClasseCamposDao.ObterDesenvolvimentoClasseCampos(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static DesenvolvimentoClasseCampos ObterDesenvolvimentoClasseCampos(DesenvolvimentoClasseCampos desenvolvimentoClasseCampos)
	{
		return ObjectDataMapper.MapObject<DesenvolvimentoClasseCampos>(_desenvolvimentoClasseCamposDao.ObterDesenvolvimentoClasseCampos((MapTableDesenvolvimentoClasseCampos)desenvolvimentoClasseCampos.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirDesenvolvimentoClasseCampos(DesenvolvimentoClasseCampos desenvolvimentoClasseCampos)
	{
		return _desenvolvimentoClasseCamposDao.InserirDesenvolvimentoClasseCampos((MapTableDesenvolvimentoClasseCampos)desenvolvimentoClasseCampos.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarDesenvolvimentoClasseCampos(DesenvolvimentoClasseCampos desenvolvimentoClasseCampos, Hashtable camposAlterados)
	{
		int num = 0;
		num = _desenvolvimentoClasseCamposDao.AlterarDesenvolvimentoClasseCampos((MapTableDesenvolvimentoClasseCampos)desenvolvimentoClasseCampos.ObterDadosMapeados(), camposAlterados);
		desenvolvimentoClasseCampos.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirDesenvolvimentoClasseCampos(int id)
	{
		return _desenvolvimentoClasseCamposDao.ExcluirDesenvolvimentoClasseCampos(id);
	}
}
