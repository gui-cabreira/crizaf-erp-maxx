using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloComercialFinanceiro
{
	private static IComercialFinanceiroCondicaoPagamento _comercialFinanceiroCondicaoPagamentoDao = AcessoDados.ComercialFinanceiroCondicaoPagamentoDAO;

	private static IComercialFinanceiroModoPagamento _comercialFinanceiroModoPagamentoDao = AcessoDados.ComercialFinanceiroModoPagamentoDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialFinanceiroCondicaoPagamento> ObterTodosComercialFinanceiroCondicaoPagamento()
	{
		return ObjectDataMapper.MapObjectList<ComercialFinanceiroCondicaoPagamento>((IList)_comercialFinanceiroCondicaoPagamentoDao.ObterTodosComercialFinanceiroCondicaoPagamento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFinanceiroCondicaoPagamento ObterComercialFinanceiroCondicaoPagamento(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialFinanceiroCondicaoPagamento>(_comercialFinanceiroCondicaoPagamentoDao.ObterComercialFinanceiroCondicaoPagamento(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFinanceiroCondicaoPagamento ObterComercialFinanceiroCondicaoPagamento(ComercialFinanceiroCondicaoPagamento comercialFinanceiroCondicaoPagamento)
	{
		return ObjectDataMapper.MapObject<ComercialFinanceiroCondicaoPagamento>(_comercialFinanceiroCondicaoPagamentoDao.ObterComercialFinanceiroCondicaoPagamento((MapTableComercialFinanceiroCondicaoPagamento)comercialFinanceiroCondicaoPagamento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialFinanceiroCondicaoPagamento(ComercialFinanceiroCondicaoPagamento comercialFinanceiroCondicaoPagamento)
	{
		return _comercialFinanceiroCondicaoPagamentoDao.InserirComercialFinanceiroCondicaoPagamento((MapTableComercialFinanceiroCondicaoPagamento)comercialFinanceiroCondicaoPagamento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialFinanceiroCondicaoPagamento(ComercialFinanceiroCondicaoPagamento comercialFinanceiroCondicaoPagamento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialFinanceiroCondicaoPagamentoDao.AlterarComercialFinanceiroCondicaoPagamento((MapTableComercialFinanceiroCondicaoPagamento)comercialFinanceiroCondicaoPagamento.ObterDadosMapeados(), camposAlterados);
		comercialFinanceiroCondicaoPagamento.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialFinanceiroCondicaoPagamento(int codigo)
	{
		return _comercialFinanceiroCondicaoPagamentoDao.ExcluirComercialFinanceiroCondicaoPagamento(codigo);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialFinanceiroModoPagamento> ObterTodosComercialFinanceiroModoPagamento()
	{
		return ObjectDataMapper.MapObjectList<ComercialFinanceiroModoPagamento>((IList)_comercialFinanceiroModoPagamentoDao.ObterTodosComercialFinanceiroModoPagamento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFinanceiroModoPagamento ObterComercialFinanceiroModoPagamento(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialFinanceiroModoPagamento>(_comercialFinanceiroModoPagamentoDao.ObterComercialFinanceiroModoPagamento(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialFinanceiroModoPagamento ObterComercialFinanceiroModoPagamento(ComercialFinanceiroModoPagamento comercialFinanceiroModoPagamento)
	{
		return ObjectDataMapper.MapObject<ComercialFinanceiroModoPagamento>(_comercialFinanceiroModoPagamentoDao.ObterComercialFinanceiroModoPagamento((MapTableComercialFinanceiroModoPagamento)comercialFinanceiroModoPagamento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialFinanceiroModoPagamento(ComercialFinanceiroModoPagamento comercialFinanceiroModoPagamento)
	{
		return _comercialFinanceiroModoPagamentoDao.InserirComercialFinanceiroModoPagamento((MapTableComercialFinanceiroModoPagamento)comercialFinanceiroModoPagamento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialFinanceiroModoPagamento(ComercialFinanceiroModoPagamento comercialFinanceiroModoPagamento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialFinanceiroModoPagamentoDao.AlterarComercialFinanceiroModoPagamento((MapTableComercialFinanceiroModoPagamento)comercialFinanceiroModoPagamento.ObterDadosMapeados(), camposAlterados);
		comercialFinanceiroModoPagamento.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialFinanceiroModoPagamento(int codigo)
	{
		return _comercialFinanceiroModoPagamentoDao.ExcluirComercialFinanceiroModoPagamento(codigo);
	}
}
