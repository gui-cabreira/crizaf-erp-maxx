using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloQualidade
{
	private static IQualidadeCertificacao _qualidadeCertificacaoDao = AcessoDados.QualidadeCertificacaoDAO;

	private static IQualidadeEmbarqueControlado _qualidadeEmbarqueControladoDao = AcessoDados.QualidadeEmbarqueControladoDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<QualidadeCertificacao> ObterTodosQualidadeCertificacao()
	{
		return ObjectDataMapper.MapObjectList<QualidadeCertificacao>((IList)_qualidadeCertificacaoDao.ObterTodosQualidadeCertificacao());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static QualidadeCertificacao ObterQualidadeCertificacao(int codigo)
	{
		return ObjectDataMapper.MapObject<QualidadeCertificacao>(_qualidadeCertificacaoDao.ObterQualidadeCertificacao(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static QualidadeCertificacao ObterQualidadeCertificacao(QualidadeCertificacao qualidadeCertificacao)
	{
		return ObjectDataMapper.MapObject<QualidadeCertificacao>(_qualidadeCertificacaoDao.ObterQualidadeCertificacao((MapTableQualidadeCertificacao)qualidadeCertificacao.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirQualidadeCertificacao(QualidadeCertificacao qualidadeCertificacao)
	{
		return _qualidadeCertificacaoDao.InserirQualidadeCertificacao((MapTableQualidadeCertificacao)qualidadeCertificacao.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarQualidadeCertificacao(QualidadeCertificacao qualidadeCertificacao, Hashtable camposAlterados)
	{
		int num = 0;
		num = _qualidadeCertificacaoDao.AlterarQualidadeCertificacao((MapTableQualidadeCertificacao)qualidadeCertificacao.ObterDadosMapeados(), camposAlterados);
		qualidadeCertificacao.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirQualidadeCertificacao(int codigo)
	{
		return _qualidadeCertificacaoDao.ExcluirQualidadeCertificacao(codigo);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<QualidadeEmbarqueControlado> ObterTodosQualidadeEmbarqueControlado()
	{
		return ObjectDataMapper.MapObjectList<QualidadeEmbarqueControlado>((IList)_qualidadeEmbarqueControladoDao.ObterTodosQualidadeEmbarqueControlado());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static QualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(int id)
	{
		return ObjectDataMapper.MapObject<QualidadeEmbarqueControlado>(_qualidadeEmbarqueControladoDao.ObterQualidadeEmbarqueControlado(id));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static QualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(string produto)
	{
		return ObjectDataMapper.MapObject<QualidadeEmbarqueControlado>(_qualidadeEmbarqueControladoDao.ObterQualidadeEmbarqueControlado(produto));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static QualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(QualidadeEmbarqueControlado qualidadeEmbarqueControlado)
	{
		return ObjectDataMapper.MapObject<QualidadeEmbarqueControlado>(_qualidadeEmbarqueControladoDao.ObterQualidadeEmbarqueControlado((MapTableQualidadeEmbarqueControlado)qualidadeEmbarqueControlado.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirQualidadeEmbarqueControlado(QualidadeEmbarqueControlado qualidadeEmbarqueControlado)
	{
		return _qualidadeEmbarqueControladoDao.InserirQualidadeEmbarqueControlado((MapTableQualidadeEmbarqueControlado)qualidadeEmbarqueControlado.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarQualidadeEmbarqueControlado(QualidadeEmbarqueControlado qualidadeEmbarqueControlado, Hashtable camposAlterados)
	{
		int num = 0;
		num = _qualidadeEmbarqueControladoDao.AlterarQualidadeEmbarqueControlado((MapTableQualidadeEmbarqueControlado)qualidadeEmbarqueControlado.ObterDadosMapeados(), camposAlterados);
		qualidadeEmbarqueControlado.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirQualidadeEmbarqueControlado(int id)
	{
		return _qualidadeEmbarqueControladoDao.ExcluirQualidadeEmbarqueControlado(id);
	}
}
