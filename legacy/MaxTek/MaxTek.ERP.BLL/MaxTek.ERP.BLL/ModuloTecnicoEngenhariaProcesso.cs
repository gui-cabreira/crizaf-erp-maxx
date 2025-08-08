using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloTecnicoEngenhariaProcesso
{
	private static ITecnicoEngenhariaProcessoControle _tecnicoEngenhariaProcessoControleDao = AcessoDados.TecnicoEngenhariaProcessoControleDAO;

	private static ITecnicoEngenhariaProcesso _tecnicoEngenhariaProcessoDao = AcessoDados.TecnicoEngenhariaProcessoDAO;

	private static ITecnicoEngenhariaProcessoMateria _tecnicoEngenhariaProcessoMateriaDao = AcessoDados.TecnicoEngenhariaProcessoMateriaDAO;

	private static ITecnicoEngenhariaProcessoOperacao _tecnicoEngenhariaProcessoOperacaoDao = AcessoDados.TecnicoEngenhariaProcessoOperacaoDAO;

	private static ITecnicoEngenhariaProcessoOperacaoFerramenta _tecnicoEngenhariaProcessoOperacaoFerramentaDao = AcessoDados.TecnicoEngenhariaProcessoOperacaoFerramentaDAO;

	private static ITecnicoEngenhariaProcessoOperacaoRevisao _tecnicoEngenhariaProcessoOperacaoRevisaoDao = AcessoDados.TecnicoEngenhariaProcessoOperacaoRevisaoDAO;

	private static ITecnicoEngenhariaProcessoRevisao _tecnicoEngenhariaProcessoRevisaoDao = AcessoDados.TecnicoEngenhariaProcessoRevisaoDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoControle> ObterTodosTecnicoEngenhariaProcessoControle()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoControle>((IList)_tecnicoEngenhariaProcessoControleDao.ObterTodosTecnicoEngenhariaProcessoControle());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoControle ObterTecnicoEngenhariaProcessoControle(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoControle>(_tecnicoEngenhariaProcessoControleDao.ObterTecnicoEngenhariaProcessoControle(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoControle ObterTecnicoEngenhariaProcessoControle(TecnicoEngenhariaProcessoControle tecnicoEngenhariaProcessoControle)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoControle>(_tecnicoEngenhariaProcessoControleDao.ObterTecnicoEngenhariaProcessoControle((MapTableTecnicoEngenhariaProcessoControle)tecnicoEngenhariaProcessoControle.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcessoControle(TecnicoEngenhariaProcessoControle tecnicoEngenhariaProcessoControle)
	{
		return _tecnicoEngenhariaProcessoControleDao.InserirTecnicoEngenhariaProcessoControle((MapTableTecnicoEngenhariaProcessoControle)tecnicoEngenhariaProcessoControle.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcessoControle(TecnicoEngenhariaProcessoControle tecnicoEngenhariaProcessoControle, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoControleDao.AlterarTecnicoEngenhariaProcessoControle((MapTableTecnicoEngenhariaProcessoControle)tecnicoEngenhariaProcessoControle.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcessoControle.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcessoControle(int id)
	{
		return _tecnicoEngenhariaProcessoControleDao.ExcluirTecnicoEngenhariaProcessoControle(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcesso> ObterTodosTecnicoEngenhariaProcesso()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcesso>((IList)_tecnicoEngenhariaProcessoDao.ObterTodosTecnicoEngenhariaProcesso());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcesso ObterTecnicoEngenhariaProcesso(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcesso>(_tecnicoEngenhariaProcessoDao.ObterTecnicoEngenhariaProcesso(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcesso ObterTecnicoEngenhariaProcesso(TecnicoEngenhariaProcesso tecnicoEngenhariaProcesso)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcesso>(_tecnicoEngenhariaProcessoDao.ObterTecnicoEngenhariaProcesso((MapTableTecnicoEngenhariaProcesso)tecnicoEngenhariaProcesso.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcesso(TecnicoEngenhariaProcesso tecnicoEngenhariaProcesso)
	{
		return _tecnicoEngenhariaProcessoDao.InserirTecnicoEngenhariaProcesso((MapTableTecnicoEngenhariaProcesso)tecnicoEngenhariaProcesso.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcesso(TecnicoEngenhariaProcesso tecnicoEngenhariaProcesso, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoDao.AlterarTecnicoEngenhariaProcesso((MapTableTecnicoEngenhariaProcesso)tecnicoEngenhariaProcesso.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcesso.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcesso(int id)
	{
		return _tecnicoEngenhariaProcessoDao.ExcluirTecnicoEngenhariaProcesso(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoMateria> ObterTodosTecnicoEngenhariaProcessoMateria()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoMateria>((IList)_tecnicoEngenhariaProcessoMateriaDao.ObterTodosTecnicoEngenhariaProcessoMateria());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoMateria> ObterTodosTecnicoEngenhariaProcessoMateria(int idProcesso)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoMateria>((IList)_tecnicoEngenhariaProcessoMateriaDao.ObterTodosTecnicoEngenhariaProcessoMateria(idProcesso));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoMateria ObterTecnicoEngenhariaProcessoMateria(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoMateria>(_tecnicoEngenhariaProcessoMateriaDao.ObterTecnicoEngenhariaProcessoMateria(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoMateria ObterTecnicoEngenhariaProcessoMateria(TecnicoEngenhariaProcessoMateria tecnicoEngenhariaProcessoMateria)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoMateria>(_tecnicoEngenhariaProcessoMateriaDao.ObterTecnicoEngenhariaProcessoMateria((MapTableTecnicoEngenhariaProcessoMateria)tecnicoEngenhariaProcessoMateria.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcessoMateria(TecnicoEngenhariaProcessoMateria tecnicoEngenhariaProcessoMateria)
	{
		return _tecnicoEngenhariaProcessoMateriaDao.InserirTecnicoEngenhariaProcessoMateria((MapTableTecnicoEngenhariaProcessoMateria)tecnicoEngenhariaProcessoMateria.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcessoMateria(TecnicoEngenhariaProcessoMateria tecnicoEngenhariaProcessoMateria, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoMateriaDao.AlterarTecnicoEngenhariaProcessoMateria((MapTableTecnicoEngenhariaProcessoMateria)tecnicoEngenhariaProcessoMateria.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcessoMateria.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcessoMateria(int id)
	{
		return _tecnicoEngenhariaProcessoMateriaDao.ExcluirTecnicoEngenhariaProcessoMateria(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoOperacao> ObterTodosTecnicoEngenhariaProcessoOperacao()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoOperacao>((IList)_tecnicoEngenhariaProcessoOperacaoDao.ObterTodosTecnicoEngenhariaProcessoOperacao());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoOperacao> ObterTodosTecnicoEngenhariaProcessoOperacao(int idProcesso)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoOperacao>((IList)_tecnicoEngenhariaProcessoOperacaoDao.ObterTodosTecnicoEngenhariaProcessoOperacao(idProcesso));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoOperacao ObterTecnicoEngenhariaProcessoOperacao(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoOperacao>(_tecnicoEngenhariaProcessoOperacaoDao.ObterTecnicoEngenhariaProcessoOperacao(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoOperacao ObterTecnicoEngenhariaProcessoOperacao(TecnicoEngenhariaProcessoOperacao tecnicoEngenhariaProcessoOperacao)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoOperacao>(_tecnicoEngenhariaProcessoOperacaoDao.ObterTecnicoEngenhariaProcessoOperacao((MapTableTecnicoEngenhariaProcessoOperacao)tecnicoEngenhariaProcessoOperacao.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcessoOperacao(TecnicoEngenhariaProcessoOperacao tecnicoEngenhariaProcessoOperacao)
	{
		return _tecnicoEngenhariaProcessoOperacaoDao.InserirTecnicoEngenhariaProcessoOperacao((MapTableTecnicoEngenhariaProcessoOperacao)tecnicoEngenhariaProcessoOperacao.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcessoOperacao(TecnicoEngenhariaProcessoOperacao tecnicoEngenhariaProcessoOperacao, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoOperacaoDao.AlterarTecnicoEngenhariaProcessoOperacao((MapTableTecnicoEngenhariaProcessoOperacao)tecnicoEngenhariaProcessoOperacao.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcessoOperacao.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcessoOperacao(int id)
	{
		return _tecnicoEngenhariaProcessoOperacaoDao.ExcluirTecnicoEngenhariaProcessoOperacao(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoOperacaoFerramenta> ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoOperacaoFerramenta>((IList)_tecnicoEngenhariaProcessoOperacaoFerramentaDao.ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoOperacaoFerramenta> ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta(int idOperacao)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoOperacaoFerramenta>((IList)_tecnicoEngenhariaProcessoOperacaoFerramentaDao.ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta(idOperacao));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoOperacaoFerramenta ObterTecnicoEngenhariaProcessoOperacaoFerramenta(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoOperacaoFerramenta>(_tecnicoEngenhariaProcessoOperacaoFerramentaDao.ObterTecnicoEngenhariaProcessoOperacaoFerramenta(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoOperacaoFerramenta ObterTecnicoEngenhariaProcessoOperacaoFerramenta(TecnicoEngenhariaProcessoOperacaoFerramenta tecnicoEngenhariaProcessoOperacaoFerramenta)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoOperacaoFerramenta>(_tecnicoEngenhariaProcessoOperacaoFerramentaDao.ObterTecnicoEngenhariaProcessoOperacaoFerramenta((MapTableTecnicoEngenhariaProcessoOperacaoFerramenta)tecnicoEngenhariaProcessoOperacaoFerramenta.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcessoOperacaoFerramenta(TecnicoEngenhariaProcessoOperacaoFerramenta tecnicoEngenhariaProcessoOperacaoFerramenta)
	{
		return _tecnicoEngenhariaProcessoOperacaoFerramentaDao.InserirTecnicoEngenhariaProcessoOperacaoFerramenta((MapTableTecnicoEngenhariaProcessoOperacaoFerramenta)tecnicoEngenhariaProcessoOperacaoFerramenta.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcessoOperacaoFerramenta(TecnicoEngenhariaProcessoOperacaoFerramenta tecnicoEngenhariaProcessoOperacaoFerramenta, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoOperacaoFerramentaDao.AlterarTecnicoEngenhariaProcessoOperacaoFerramenta((MapTableTecnicoEngenhariaProcessoOperacaoFerramenta)tecnicoEngenhariaProcessoOperacaoFerramenta.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcessoOperacaoFerramenta.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcessoOperacaoFerramenta(int id)
	{
		return _tecnicoEngenhariaProcessoOperacaoFerramentaDao.ExcluirTecnicoEngenhariaProcessoOperacaoFerramenta(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoOperacaoRevisao> ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoOperacaoRevisao>((IList)_tecnicoEngenhariaProcessoOperacaoRevisaoDao.ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoOperacaoRevisao> ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao(int idOperacao)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoOperacaoRevisao>((IList)_tecnicoEngenhariaProcessoOperacaoRevisaoDao.ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao(idOperacao));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoOperacaoRevisao ObterTecnicoEngenhariaProcessoOperacaoRevisao(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoOperacaoRevisao>(_tecnicoEngenhariaProcessoOperacaoRevisaoDao.ObterTecnicoEngenhariaProcessoOperacaoRevisao(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoOperacaoRevisao ObterTecnicoEngenhariaProcessoOperacaoRevisao(TecnicoEngenhariaProcessoOperacaoRevisao tecnicoEngenhariaProcessoOperacaoRevisao)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoOperacaoRevisao>(_tecnicoEngenhariaProcessoOperacaoRevisaoDao.ObterTecnicoEngenhariaProcessoOperacaoRevisao((MapTableTecnicoEngenhariaProcessoOperacaoRevisao)tecnicoEngenhariaProcessoOperacaoRevisao.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcessoOperacaoRevisao(TecnicoEngenhariaProcessoOperacaoRevisao tecnicoEngenhariaProcessoOperacaoRevisao)
	{
		return _tecnicoEngenhariaProcessoOperacaoRevisaoDao.InserirTecnicoEngenhariaProcessoOperacaoRevisao((MapTableTecnicoEngenhariaProcessoOperacaoRevisao)tecnicoEngenhariaProcessoOperacaoRevisao.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcessoOperacaoRevisao(TecnicoEngenhariaProcessoOperacaoRevisao tecnicoEngenhariaProcessoOperacaoRevisao, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoOperacaoRevisaoDao.AlterarTecnicoEngenhariaProcessoOperacaoRevisao((MapTableTecnicoEngenhariaProcessoOperacaoRevisao)tecnicoEngenhariaProcessoOperacaoRevisao.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcessoOperacaoRevisao.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcessoOperacaoRevisao(int id)
	{
		return _tecnicoEngenhariaProcessoOperacaoRevisaoDao.ExcluirTecnicoEngenhariaProcessoOperacaoRevisao(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoRevisao> ObterTodosTecnicoEngenhariaProcessoRevisao()
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoRevisao>((IList)_tecnicoEngenhariaProcessoRevisaoDao.ObterTodosTecnicoEngenhariaProcessoRevisao());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoEngenhariaProcessoRevisao> ObterTodosTecnicoEngenhariaProcessoRevisao(int idProcesso)
	{
		return ObjectDataMapper.MapObjectList<TecnicoEngenhariaProcessoRevisao>((IList)_tecnicoEngenhariaProcessoRevisaoDao.ObterTodosTecnicoEngenhariaProcessoRevisao(idProcesso));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoRevisao ObterTecnicoEngenhariaProcessoRevisao(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoRevisao>(_tecnicoEngenhariaProcessoRevisaoDao.ObterTecnicoEngenhariaProcessoRevisao(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoEngenhariaProcessoRevisao ObterTecnicoEngenhariaProcessoRevisao(TecnicoEngenhariaProcessoRevisao tecnicoEngenhariaProcessoRevisao)
	{
		return ObjectDataMapper.MapObject<TecnicoEngenhariaProcessoRevisao>(_tecnicoEngenhariaProcessoRevisaoDao.ObterTecnicoEngenhariaProcessoRevisao((MapTableTecnicoEngenhariaProcessoRevisao)tecnicoEngenhariaProcessoRevisao.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoEngenhariaProcessoRevisao(TecnicoEngenhariaProcessoRevisao tecnicoEngenhariaProcessoRevisao)
	{
		return _tecnicoEngenhariaProcessoRevisaoDao.InserirTecnicoEngenhariaProcessoRevisao((MapTableTecnicoEngenhariaProcessoRevisao)tecnicoEngenhariaProcessoRevisao.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoEngenhariaProcessoRevisao(TecnicoEngenhariaProcessoRevisao tecnicoEngenhariaProcessoRevisao, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoEngenhariaProcessoRevisaoDao.AlterarTecnicoEngenhariaProcessoRevisao((MapTableTecnicoEngenhariaProcessoRevisao)tecnicoEngenhariaProcessoRevisao.ObterDadosMapeados(), camposAlterados);
		tecnicoEngenhariaProcessoRevisao.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoEngenhariaProcessoRevisao(int id)
	{
		return _tecnicoEngenhariaProcessoRevisaoDao.ExcluirTecnicoEngenhariaProcessoRevisao(id);
	}
}
