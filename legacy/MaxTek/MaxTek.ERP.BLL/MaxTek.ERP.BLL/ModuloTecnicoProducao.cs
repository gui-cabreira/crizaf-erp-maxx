using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloTecnicoProducao
{
	private static ITecnicoProducaoApontamento _tecnicoProducaoApontamentoDao = AcessoDados.TecnicoProducaoApontamentoDAO;

	private static ITecnicoProducaoEstatisticasApontamento _tecnicoProducaoEstatisticasApontamentoDao = AcessoDados.TecnicoProducaoEstatisticasApontamentoDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento()
	{
		return ObjectDataMapper.MapObjectList<TecnicoProducaoApontamento>((IList)_tecnicoProducaoApontamentoDao.ObterTodosTecnicoProducaoApontamento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<TecnicoProducaoApontamento>((IList)_tecnicoProducaoApontamentoDao.ObterTodosTecnicoProducaoApontamento(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoProducaoApontamento ObterTecnicoProducaoApontamento(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoProducaoApontamento>(_tecnicoProducaoApontamentoDao.ObterTecnicoProducaoApontamento(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoProducaoApontamento ObterTecnicoProducaoApontamento(TecnicoProducaoApontamento tecnicoProducaoApontamento)
	{
		return ObjectDataMapper.MapObject<TecnicoProducaoApontamento>(_tecnicoProducaoApontamentoDao.ObterTecnicoProducaoApontamento((MapTableTecnicoProducaoApontamento)tecnicoProducaoApontamento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoProducaoApontamento(TecnicoProducaoApontamento tecnicoProducaoApontamento)
	{
		return _tecnicoProducaoApontamentoDao.InserirTecnicoProducaoApontamento((MapTableTecnicoProducaoApontamento)tecnicoProducaoApontamento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoProducaoApontamento(TecnicoProducaoApontamento tecnicoProducaoApontamento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoProducaoApontamentoDao.AlterarTecnicoProducaoApontamento((MapTableTecnicoProducaoApontamento)tecnicoProducaoApontamento.ObterDadosMapeados(), camposAlterados);
		tecnicoProducaoApontamento.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoProducaoApontamento(int id)
	{
		return _tecnicoProducaoApontamentoDao.ExcluirTecnicoProducaoApontamento(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticasApontamento()
	{
		return ObjectDataMapper.MapObjectList<TecnicoProducaoEstatisticasApontamento>((IList)_tecnicoProducaoEstatisticasApontamentoDao.ObterTodosTecnicoProducaoEstatisticasApontamento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticasApontamento(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<TecnicoProducaoEstatisticasApontamento>((IList)_tecnicoProducaoEstatisticasApontamentoDao.ObterTodosTecnicoProducaoEstatisticasApontamento(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoProducaoEstatisticasApontamento ObterTecnicoProducaoEstatisticasApontamento(int id)
	{
		return ObjectDataMapper.MapObject<TecnicoProducaoEstatisticasApontamento>(_tecnicoProducaoEstatisticasApontamentoDao.ObterTecnicoProducaoEstatisticasApontamento(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static TecnicoProducaoEstatisticasApontamento ObterTecnicoProducaoEstatisticasApontamento(TecnicoProducaoEstatisticasApontamento tecnicoProducaoEstatisticasApontamento)
	{
		return ObjectDataMapper.MapObject<TecnicoProducaoEstatisticasApontamento>(_tecnicoProducaoEstatisticasApontamentoDao.ObterTecnicoProducaoEstatisticasApontamento((MapTableTecnicoProducaoEstatisticasApontamento)tecnicoProducaoEstatisticasApontamento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirTecnicoProducaoEstatisticasApontamento(TecnicoProducaoEstatisticasApontamento tecnicoProducaoEstatisticasApontamento)
	{
		return _tecnicoProducaoEstatisticasApontamentoDao.InserirTecnicoProducaoEstatisticasApontamento((MapTableTecnicoProducaoEstatisticasApontamento)tecnicoProducaoEstatisticasApontamento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarTecnicoProducaoEstatisticasApontamento(TecnicoProducaoEstatisticasApontamento tecnicoProducaoEstatisticasApontamento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _tecnicoProducaoEstatisticasApontamentoDao.AlterarTecnicoProducaoEstatisticasApontamento((MapTableTecnicoProducaoEstatisticasApontamento)tecnicoProducaoEstatisticasApontamento.ObterDadosMapeados(), camposAlterados);
		tecnicoProducaoEstatisticasApontamento.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTecnicoProducaoEstatisticasApontamento(int id)
	{
		return _tecnicoProducaoEstatisticasApontamentoDao.ExcluirTecnicoProducaoEstatisticasApontamento(id);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<TecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticaOperacao(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<TecnicoProducaoEstatisticasApontamento>((IList)_tecnicoProducaoEstatisticasApontamentoDao.ObterTodosTecnicoProducaoEstatisticaOperacao(dataInicio, dataFim));
	}
}
