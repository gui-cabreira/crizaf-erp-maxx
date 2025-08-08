using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloTecnicoEngenhariaProduto
{
	private static ITecnicoEngenhariaProduto _tecnicoEngenhariaProdutoDao = AcessoDados.TecnicoEngenhariaProdutoDAO;

	private static ITecnicoEngenhariaProdutoAlmoxarifado _tecnicoEngenhariaProdutoAlmoxarifadoDao = AcessoDados.TecnicoEngenhariaProdutoAlmoxarifadoDAO;

	private static ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento _tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao = AcessoDados.TecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDAO;

	private static ITecnicoEngenhariaProdutoFamilia _tecnicoEngenhariaProdutoFamiliaDao = AcessoDados.TecnicoEngenhariaProdutoFamiliaDAO;

	private static ITecnicoEngenhariaProdutoSubfamilia _tecnicoEngenhariaProdutoSubfamiliaDao = AcessoDados.TecnicoEngenhariaProdutoSubfamiliaDAO;

	private static ITecnicoEngenhariaProdutoTipo _tecnicoEngenhariaProdutoTipoDao = AcessoDados.TecnicoEngenhariaProdutoTipoDAO;

	private static ITecnicoEngenhariaProdutoUnidade _tecnicoEngenhariaProdutoUnidadeDao = AcessoDados.TecnicoEngenhariaProdutoUnidadeDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProduto> ObterTodosTecnicoEngenhariaProduto()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProduto>((IList)_tecnicoEngenhariaProdutoDao.ObterTodosTecnicoEngenhariaProduto());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProduto>(_tecnicoEngenhariaProdutoDao.ObterTecnicoEngenhariaProduto(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(TecnicoEngenhariaProduto tecnicoEngenhariaProduto)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProduto>(_tecnicoEngenhariaProdutoDao.ObterTecnicoEngenhariaProduto((MapTableTecnicoEngenhariaProduto)tecnicoEngenhariaProduto.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProduto(TecnicoEngenhariaProduto tecnicoEngenhariaProduto)
	{
		return _tecnicoEngenhariaProdutoDao.InserirTecnicoEngenhariaProduto((MapTableTecnicoEngenhariaProduto)tecnicoEngenhariaProduto.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProduto(TecnicoEngenhariaProduto tecnicoEngenhariaProduto, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoDao.AlterarTecnicoEngenhariaProduto((MapTableTecnicoEngenhariaProduto)tecnicoEngenhariaProduto.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProduto.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProduto(int id)
	{
		return _tecnicoEngenhariaProdutoDao.ExcluirTecnicoEngenhariaProduto(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoAlmoxarifado> ObterTodosTecnicoEngenhariaProdutoAlmoxarifado()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoAlmoxarifado>((IList)_tecnicoEngenhariaProdutoAlmoxarifadoDao.ObterTodosTecnicoEngenhariaProdutoAlmoxarifado());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoAlmoxarifado ObterTecnicoEngenhariaProdutoAlmoxarifado(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoAlmoxarifado>(_tecnicoEngenhariaProdutoAlmoxarifadoDao.ObterTecnicoEngenhariaProdutoAlmoxarifado(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoAlmoxarifado ObterTecnicoEngenhariaProdutoAlmoxarifado(TecnicoEngenhariaProdutoAlmoxarifado tecnicoEngenhariaProdutoAlmoxarifado)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoAlmoxarifado>(_tecnicoEngenhariaProdutoAlmoxarifadoDao.ObterTecnicoEngenhariaProdutoAlmoxarifado((MapTableTecnicoEngenhariaProdutoAlmoxarifado)tecnicoEngenhariaProdutoAlmoxarifado.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProdutoAlmoxarifado(TecnicoEngenhariaProdutoAlmoxarifado tecnicoEngenhariaProdutoAlmoxarifado)
	{
		return _tecnicoEngenhariaProdutoAlmoxarifadoDao.InserirTecnicoEngenhariaProdutoAlmoxarifado((MapTableTecnicoEngenhariaProdutoAlmoxarifado)tecnicoEngenhariaProdutoAlmoxarifado.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProdutoAlmoxarifado(TecnicoEngenhariaProdutoAlmoxarifado tecnicoEngenhariaProdutoAlmoxarifado, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoAlmoxarifadoDao.AlterarTecnicoEngenhariaProdutoAlmoxarifado((MapTableTecnicoEngenhariaProdutoAlmoxarifado)tecnicoEngenhariaProdutoAlmoxarifado.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProdutoAlmoxarifado.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProdutoAlmoxarifado(int id)
	{
		_tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ExcluirTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(id);
		return _tecnicoEngenhariaProdutoAlmoxarifadoDao.ExcluirTecnicoEngenhariaProdutoAlmoxarifado(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento> ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento>((IList)_tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento> ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int codigoAlmoxarifado)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento>((IList)_tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(codigoAlmoxarifado));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoAlmoxarifadoCompartimento ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento>(_tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoAlmoxarifadoCompartimento ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(TecnicoEngenhariaProdutoAlmoxarifadoCompartimento tecnicoEngenhariaProdutoAlmoxarifadoCompartimento)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento>(_tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento((MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento)tecnicoEngenhariaProdutoAlmoxarifadoCompartimento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(TecnicoEngenhariaProdutoAlmoxarifadoCompartimento tecnicoEngenhariaProdutoAlmoxarifadoCompartimento)
	{
		return _tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.InserirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento((MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento)tecnicoEngenhariaProdutoAlmoxarifadoCompartimento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(TecnicoEngenhariaProdutoAlmoxarifadoCompartimento tecnicoEngenhariaProdutoAlmoxarifadoCompartimento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.AlterarTecnicoEngenhariaProdutoAlmoxarifadoCompartimento((MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento)tecnicoEngenhariaProdutoAlmoxarifadoCompartimento.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProdutoAlmoxarifadoCompartimento.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int id)
	{
		return _tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ExcluirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(id);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int codigoAlmoxarifado)
	{
		return _tecnicoEngenhariaProdutoAlmoxarifadoCompartimentoDao.ExcluirTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(codigoAlmoxarifado);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoFamilia> ObterTodosTecnicoEngenhariaProdutoFamilia()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoFamilia>((IList)_tecnicoEngenhariaProdutoFamiliaDao.ObterTodosTecnicoEngenhariaProdutoFamilia());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoFamilia ObterTecnicoEngenhariaProdutoFamilia(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoFamilia>(_tecnicoEngenhariaProdutoFamiliaDao.ObterTecnicoEngenhariaProdutoFamilia(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoFamilia ObterTecnicoEngenhariaProdutoFamilia(TecnicoEngenhariaProdutoFamilia tecnicoEngenhariaProdutoFamilia)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoFamilia>(_tecnicoEngenhariaProdutoFamiliaDao.ObterTecnicoEngenhariaProdutoFamilia((MapTableTecnicoEngenhariaProdutoFamilia)tecnicoEngenhariaProdutoFamilia.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProdutoFamilia(TecnicoEngenhariaProdutoFamilia tecnicoEngenhariaProdutoFamilia)
	{
		return _tecnicoEngenhariaProdutoFamiliaDao.InserirTecnicoEngenhariaProdutoFamilia((MapTableTecnicoEngenhariaProdutoFamilia)tecnicoEngenhariaProdutoFamilia.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProdutoFamilia(TecnicoEngenhariaProdutoFamilia tecnicoEngenhariaProdutoFamilia, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoFamiliaDao.AlterarTecnicoEngenhariaProdutoFamilia((MapTableTecnicoEngenhariaProdutoFamilia)tecnicoEngenhariaProdutoFamilia.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProdutoFamilia.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProdutoFamilia(int id)
	{
		return _tecnicoEngenhariaProdutoFamiliaDao.ExcluirTecnicoEngenhariaProdutoFamilia(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoSubfamilia> ObterTodosTecnicoEngenhariaProdutoSubfamilia()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoSubfamilia>((IList)_tecnicoEngenhariaProdutoSubfamiliaDao.ObterTodosTecnicoEngenhariaProdutoSubfamilia());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoSubfamilia> ObterTodosTecnicoEngenhariaProdutoSubfamilia(int codigoFamilia)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoSubfamilia>((IList)_tecnicoEngenhariaProdutoSubfamiliaDao.ObterTodosTecnicoEngenhariaProdutoSubfamilia(codigoFamilia));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoSubfamilia ObterTecnicoEngenhariaProdutoSubfamilia(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoSubfamilia>(_tecnicoEngenhariaProdutoSubfamiliaDao.ObterTecnicoEngenhariaProdutoSubfamilia(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoSubfamilia ObterTecnicoEngenhariaProdutoSubfamilia(TecnicoEngenhariaProdutoSubfamilia tecnicoEngenhariaProdutoSubfamilia)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoSubfamilia>(_tecnicoEngenhariaProdutoSubfamiliaDao.ObterTecnicoEngenhariaProdutoSubfamilia((MapTableTecnicoEngenhariaProdutoSubfamilia)tecnicoEngenhariaProdutoSubfamilia.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProdutoSubfamilia(TecnicoEngenhariaProdutoSubfamilia tecnicoEngenhariaProdutoSubfamilia)
	{
		return _tecnicoEngenhariaProdutoSubfamiliaDao.InserirTecnicoEngenhariaProdutoSubfamilia((MapTableTecnicoEngenhariaProdutoSubfamilia)tecnicoEngenhariaProdutoSubfamilia.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProdutoSubfamilia(TecnicoEngenhariaProdutoSubfamilia tecnicoEngenhariaProdutoSubfamilia, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoSubfamiliaDao.AlterarTecnicoEngenhariaProdutoSubfamilia((MapTableTecnicoEngenhariaProdutoSubfamilia)tecnicoEngenhariaProdutoSubfamilia.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProdutoSubfamilia.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProdutoSubfamilia(int id)
	{
		return _tecnicoEngenhariaProdutoSubfamiliaDao.ExcluirTecnicoEngenhariaProdutoSubfamilia(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoTipo> ObterTodosTecnicoEngenhariaProdutoTipo()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoTipo>((IList)_tecnicoEngenhariaProdutoTipoDao.ObterTodosTecnicoEngenhariaProdutoTipo());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoTipo ObterTecnicoEngenhariaProdutoTipo(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoTipo>(_tecnicoEngenhariaProdutoTipoDao.ObterTecnicoEngenhariaProdutoTipo(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoTipo ObterTecnicoEngenhariaProdutoTipo(TecnicoEngenhariaProdutoTipo tecnicoEngenhariaProdutoTipo)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoTipo>(_tecnicoEngenhariaProdutoTipoDao.ObterTecnicoEngenhariaProdutoTipo((MapTableTecnicoEngenhariaProdutoTipo)tecnicoEngenhariaProdutoTipo.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProdutoTipo(TecnicoEngenhariaProdutoTipo tecnicoEngenhariaProdutoTipo)
	{
		return _tecnicoEngenhariaProdutoTipoDao.InserirTecnicoEngenhariaProdutoTipo((MapTableTecnicoEngenhariaProdutoTipo)tecnicoEngenhariaProdutoTipo.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProdutoTipo(TecnicoEngenhariaProdutoTipo tecnicoEngenhariaProdutoTipo, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoTipoDao.AlterarTecnicoEngenhariaProdutoTipo((MapTableTecnicoEngenhariaProdutoTipo)tecnicoEngenhariaProdutoTipo.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProdutoTipo.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProdutoTipo(int id)
	{
		return _tecnicoEngenhariaProdutoTipoDao.ExcluirTecnicoEngenhariaProdutoTipo(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProdutoUnidade> ObterTodosTecnicoEngenhariaProdutoUnidade()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProdutoUnidade>((IList)_tecnicoEngenhariaProdutoUnidadeDao.ObterTodosTecnicoEngenhariaProdutoUnidade());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoUnidade ObterTecnicoEngenhariaProdutoUnidade(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoUnidade>(_tecnicoEngenhariaProdutoUnidadeDao.ObterTecnicoEngenhariaProdutoUnidade(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProdutoUnidade ObterTecnicoEngenhariaProdutoUnidade(TecnicoEngenhariaProdutoUnidade tecnicoEngenhariaProdutoUnidade)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProdutoUnidade>(_tecnicoEngenhariaProdutoUnidadeDao.ObterTecnicoEngenhariaProdutoUnidade((MapTableTecnicoEngenhariaProdutoUnidade)tecnicoEngenhariaProdutoUnidade.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProdutoUnidade(TecnicoEngenhariaProdutoUnidade tecnicoEngenhariaProdutoUnidade)
	{
		return _tecnicoEngenhariaProdutoUnidadeDao.InserirTecnicoEngenhariaProdutoUnidade((MapTableTecnicoEngenhariaProdutoUnidade)tecnicoEngenhariaProdutoUnidade.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProdutoUnidade(TecnicoEngenhariaProdutoUnidade tecnicoEngenhariaProdutoUnidade, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProdutoUnidadeDao.AlterarTecnicoEngenhariaProdutoUnidade((MapTableTecnicoEngenhariaProdutoUnidade)tecnicoEngenhariaProdutoUnidade.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProdutoUnidade.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProdutoUnidade(int id)
	{
		return _tecnicoEngenhariaProdutoUnidadeDao.ExcluirTecnicoEngenhariaProdutoUnidade(id);
	}
}
