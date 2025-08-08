using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[DataObject(true)]
public static class ModuloComercialEntidade
{
	private static IComercialEntidade _comercialEntidadeDao = AcessoDados.ComercialEntidadeDAO;

	private static IComercialEntidadeContato _comercialEntidadeContatoDao = AcessoDados.ComercialEntidadeContatoDAO;

	private static IComercialEntidadeEspecialidade _comercialEntidadeEspecialidadeDao = AcessoDados.ComercialEntidadeEspecialidadeDAO;

	private static IComercialEntidadeEvento _comercialEntidadeEventoDao = AcessoDados.ComercialEntidadeEventoDAO;

	private static IComercialEntidadeLigacaoEndereco _comercialEntidadeLigacaoEnderecoDao = AcessoDados.ComercialEntidadeLigacaoEnderecoDAO;

	private static IComercialEntidadeTipoAtendimento _comercialEntidadeTipoAtendimentoDao = AcessoDados.ComercialEntidadeTipoAtendimentoDAO;

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidade> ObterTodosComercialEntidade()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidade>((IList)_comercialEntidadeDao.ObterTodosComercialEntidade());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidade> ObterTodosComercialEntidadeCliente()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidade>((IList)_comercialEntidadeDao.ObterTodosComercialEntidadeCliente());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidade> ObterTodosComercialEntidadeFornecedor()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidade>((IList)_comercialEntidadeDao.ObterTodosComercialEntidadeFornecedor());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidade> ObterTodosComercialEntidadeSubContratado()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidade>((IList)_comercialEntidadeDao.ObterTodosComercialEntidadeSubContratado());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidade> ObterTodosComercialEntidadeRepresentante()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidade>((IList)_comercialEntidadeDao.ObterTodosComercialEntidadeRepresentante());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidade> ObterTodosComercialEntidadeTransportadora()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidade>((IList)_comercialEntidadeDao.ObterTodosComercialEntidadeTransportadora());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidade ObterComercialEntidade(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialEntidade>(_comercialEntidadeDao.ObterComercialEntidade(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidade ObterComercialEntidade(ComercialEntidade comercialEntidade)
	{
		return ObjectDataMapper.MapObject<ComercialEntidade>(_comercialEntidadeDao.ObterComercialEntidade((MapTableComercialEntidade)comercialEntidade.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialEntidade(ComercialEntidade comercialEntidade)
	{
		return _comercialEntidadeDao.InserirComercialEntidade((MapTableComercialEntidade)comercialEntidade.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialEntidade(ComercialEntidade comercialEntidade, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialEntidadeDao.AlterarComercialEntidade((MapTableComercialEntidade)comercialEntidade.ObterDadosMapeados(), camposAlterados);
		comercialEntidade.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialEntidade(int codigo)
	{
		_comercialEntidadeContatoDao.ExcluirTodosComercialEntidadeContato(codigo);
		_comercialEntidadeLigacaoEnderecoDao.ExcluirTodosComercialEntidadeLigacaoEndereco(codigo);
		return _comercialEntidadeDao.ExcluirComercialEntidade(codigo);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeContato> ObterTodosComercialEntidadeContato()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeContato>((IList)_comercialEntidadeContatoDao.ObterTodosComercialEntidadeContato());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeContato> ObterTodosComercialEntidadeContato(int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeContato>((IList)_comercialEntidadeContatoDao.ObterTodosComercialEntidadeContato(codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeContato ObterComercialEntidadeContato(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeContato>(_comercialEntidadeContatoDao.ObterComercialEntidadeContato(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeContato ObterComercialEntidadeContato(ComercialEntidadeContato comercialEntidadeContato)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeContato>(_comercialEntidadeContatoDao.ObterComercialEntidadeContato((MapTableComercialEntidadeContato)comercialEntidadeContato.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialEntidadeContato(ComercialEntidadeContato comercialEntidadeContato)
	{
		return _comercialEntidadeContatoDao.InserirComercialEntidadeContato((MapTableComercialEntidadeContato)comercialEntidadeContato.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialEntidadeContato(ComercialEntidadeContato comercialEntidadeContato, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialEntidadeContatoDao.AlterarComercialEntidadeContato((MapTableComercialEntidadeContato)comercialEntidadeContato.ObterDadosMapeados(), camposAlterados);
		comercialEntidadeContato.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialEntidadeContato(int codigo)
	{
		return _comercialEntidadeContatoDao.ExcluirComercialEntidadeContato(codigo);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTodosComercialEntidadeContato(int codigoEntidade)
	{
		return _comercialEntidadeContatoDao.ExcluirComercialEntidadeContato(codigoEntidade);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeEspecialidade> ObterTodosComercialEntidadeEspecialidade()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeEspecialidade>((IList)_comercialEntidadeEspecialidadeDao.ObterTodosComercialEntidadeEspecialidade());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeEspecialidade ObterComercialEntidadeEspecialidade(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeEspecialidade>(_comercialEntidadeEspecialidadeDao.ObterComercialEntidadeEspecialidade(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeEspecialidade ObterComercialEntidadeEspecialidade(ComercialEntidadeEspecialidade comercialEntidadeEspecialidade)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeEspecialidade>(_comercialEntidadeEspecialidadeDao.ObterComercialEntidadeEspecialidade((MapTableComercialEntidadeEspecialidade)comercialEntidadeEspecialidade.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialEntidadeEspecialidade(ComercialEntidadeEspecialidade comercialEntidadeEspecialidade)
	{
		return _comercialEntidadeEspecialidadeDao.InserirComercialEntidadeEspecialidade((MapTableComercialEntidadeEspecialidade)comercialEntidadeEspecialidade.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialEntidadeEspecialidade(ComercialEntidadeEspecialidade comercialEntidadeEspecialidade, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialEntidadeEspecialidadeDao.AlterarComercialEntidadeEspecialidade((MapTableComercialEntidadeEspecialidade)comercialEntidadeEspecialidade.ObterDadosMapeados(), camposAlterados);
		comercialEntidadeEspecialidade.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialEntidadeEspecialidade(int codigo)
	{
		return _comercialEntidadeEspecialidadeDao.ExcluirComercialEntidadeEspecialidade(codigo);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeEvento> ObterTodosComercialEntidadeEvento()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeEvento>((IList)_comercialEntidadeEventoDao.ObterTodosComercialEntidadeEvento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeEvento> ObterTodosComercialEntidadeEventoAcompanhar()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeEvento>((IList)_comercialEntidadeEventoDao.ObterTodosComercialEntidadeEventoAcompanhar());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeEvento> ObterTodosComercialEntidadeEventoPorPeriodo(DateTime dataInicio, DateTime dataFim)
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeEvento>((IList)_comercialEntidadeEventoDao.ObterTodosComercialEntidadeEventoPorPeriodo(dataInicio, dataFim));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeEvento> ObterTodosComercialEntidadeEvento(int codigoEntidade)
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeEvento>((IList)_comercialEntidadeEventoDao.ObterTodosComercialEntidadeEvento(codigoEntidade));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeEvento> ObterTodosComercialEntidadeEventoContato(int codigoContato)
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeEvento>((IList)_comercialEntidadeEventoDao.ObterTodosComercialEntidadeEventoContato(codigoContato));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeEvento ObterComercialEntidadeEvento(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeEvento>(_comercialEntidadeEventoDao.ObterComercialEntidadeEvento(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeEvento ObterComercialEntidadeEvento(ComercialEntidadeEvento comercialEntidadeEvento)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeEvento>(_comercialEntidadeEventoDao.ObterComercialEntidadeEvento((MapTableComercialEntidadeEvento)comercialEntidadeEvento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialEntidadeEvento(ComercialEntidadeEvento comercialEntidadeEvento)
	{
		return _comercialEntidadeEventoDao.InserirComercialEntidadeEvento((MapTableComercialEntidadeEvento)comercialEntidadeEvento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialEntidadeEvento(ComercialEntidadeEvento comercialEntidadeEvento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialEntidadeEventoDao.AlterarComercialEntidadeEvento((MapTableComercialEntidadeEvento)comercialEntidadeEvento.ObterDadosMapeados(), camposAlterados);
		comercialEntidadeEvento.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeLigacaoEndereco> ObterTodosComercialEntidadeLigacaoEndereco(int codigoEntidadePrincipal)
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeLigacaoEndereco>((IList)_comercialEntidadeLigacaoEnderecoDao.ObterTodosComercialEntidadeLigacaoEndereco(codigoEntidadePrincipal));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeLigacaoEndereco> ObterTodosComercialEntidadeLigacaoEndereco()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeLigacaoEndereco>((IList)_comercialEntidadeLigacaoEnderecoDao.ObterTodosComercialEntidadeLigacaoEndereco());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeLigacaoEndereco ObterComercialEntidadeLigacaoEndereco(int codigoEntidade, int codigoEntidadeEndereco)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeLigacaoEndereco>(_comercialEntidadeLigacaoEnderecoDao.ObterComercialEntidadeLigacaoEndereco(codigoEntidade, codigoEntidadeEndereco));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeLigacaoEndereco ObterComercialEntidadeLigacaoEndereco(ComercialEntidadeLigacaoEndereco comercialEntidadeLigacaoEndereco)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeLigacaoEndereco>(_comercialEntidadeLigacaoEnderecoDao.ObterComercialEntidadeLigacaoEndereco((MapTableComercialEntidadeLigacaoEndereco)comercialEntidadeLigacaoEndereco.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialEntidadeLigacaoEndereco(ComercialEntidadeLigacaoEndereco comercialEntidadeLigacaoEndereco)
	{
		return _comercialEntidadeLigacaoEnderecoDao.InserirComercialEntidadeLigacaoEndereco((MapTableComercialEntidadeLigacaoEndereco)comercialEntidadeLigacaoEndereco.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialEntidadeLigacaoEndereco(ComercialEntidadeLigacaoEndereco comercialEntidadeLigacaoEndereco, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialEntidadeLigacaoEnderecoDao.AlterarComercialEntidadeLigacaoEndereco((MapTableComercialEntidadeLigacaoEndereco)comercialEntidadeLigacaoEndereco.ObterDadosMapeados(), camposAlterados);
		comercialEntidadeLigacaoEndereco.MarcarExistente();
		return num;
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirComercialEntidadeLigacaoEndereco(int codigoEntidade, int codigoEntidadeEndereco)
	{
		return _comercialEntidadeLigacaoEnderecoDao.ExcluirComercialEntidadeLigacaoEndereco(codigoEntidade, codigoEntidadeEndereco);
	}

	[DataObjectMethod(DataObjectMethodType.Delete)]
	public static int ExcluirTodosComercialEntidadeLigacaoEndereco(int codigoEntidade)
	{
		return _comercialEntidadeLigacaoEnderecoDao.ExcluirTodosComercialEntidadeLigacaoEndereco(codigoEntidade);
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static IList<ComercialEntidadeTipoAtendimento> ObterTodosComercialEntidadeTipoAtendimento()
	{
		return ObjectDataMapper.MapObjectList<ComercialEntidadeTipoAtendimento>((IList)_comercialEntidadeTipoAtendimentoDao.ObterTodosComercialEntidadeTipoAtendimento());
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeTipoAtendimento ObterComercialEntidadeTipoAtendimento(int codigo)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeTipoAtendimento>(_comercialEntidadeTipoAtendimentoDao.ObterComercialEntidadeTipoAtendimento(codigo));
	}

	[DataObjectMethod(DataObjectMethodType.Select)]
	public static ComercialEntidadeTipoAtendimento ObterComercialEntidadeTipoAtendimento(ComercialEntidadeTipoAtendimento comercialEntidadeTipoAtendimento)
	{
		return ObjectDataMapper.MapObject<ComercialEntidadeTipoAtendimento>(_comercialEntidadeTipoAtendimentoDao.ObterComercialEntidadeTipoAtendimento((MapTableComercialEntidadeTipoAtendimento)comercialEntidadeTipoAtendimento.ObterDadosMapeados()));
	}

	[DataObjectMethod(DataObjectMethodType.Insert)]
	public static int InserirComercialEntidadeTipoAtendimento(ComercialEntidadeTipoAtendimento comercialEntidadeTipoAtendimento)
	{
		return _comercialEntidadeTipoAtendimentoDao.InserirComercialEntidadeTipoAtendimento((MapTableComercialEntidadeTipoAtendimento)comercialEntidadeTipoAtendimento.ObterDadosMapeados());
	}

	[DataObjectMethod(DataObjectMethodType.Update)]
	public static int AlterarComercialEntidadeTipoAtendimento(ComercialEntidadeTipoAtendimento comercialEntidadeTipoAtendimento, Hashtable camposAlterados)
	{
		int num = 0;
		num = _comercialEntidadeTipoAtendimentoDao.AlterarComercialEntidadeTipoAtendimento((MapTableComercialEntidadeTipoAtendimento)comercialEntidadeTipoAtendimento.ObterDadosMapeados(), camposAlterados);
		comercialEntidadeTipoAtendimento.MarcarExistente();
		return num;
	}
}
