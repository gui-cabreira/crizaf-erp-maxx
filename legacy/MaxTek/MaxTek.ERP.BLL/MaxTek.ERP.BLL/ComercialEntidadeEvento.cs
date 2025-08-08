using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialEntidadeEvento : BusinessObjectBase
{
	private MapTableComercialEntidadeEvento _dados;

	private RHFuncionario _funcionario;

	private ComercialEntidade _entidade;

	private ComercialEntidadeContato _contato;

	private ComercialEntidadeTipoAtendimento _tipoAtendimento;

	public int Codigo
	{
		get
		{
			return _dados.codigo;
		}
		set
		{
			if (_dados.codigo != value)
			{
				_dados.codigo = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataCadastro
	{
		get
		{
			return _dados.dataCadastro;
		}
		set
		{
			if (_dados.dataCadastro != value)
			{
				_dados.dataCadastro = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionario
	{
		get
		{
			return _dados.codigoFuncionario;
		}
		set
		{
			if (_dados.codigoFuncionario != value)
			{
				_dados.codigoFuncionario = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEntidade
	{
		get
		{
			return _dados.codigoEntidade;
		}
		set
		{
			if (_dados.codigoEntidade != value)
			{
				_dados.codigoEntidade = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoContato
	{
		get
		{
			return _dados.codigoContato;
		}
		set
		{
			if (_dados.codigoContato != value)
			{
				_dados.codigoContato = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoAtendimento
	{
		get
		{
			return _dados.codigoTipoAtendimento;
		}
		set
		{
			if (_dados.codigoTipoAtendimento != value)
			{
				_dados.codigoTipoAtendimento = value;
				PropertyHasChanged();
			}
		}
	}

	public string Assunto
	{
		get
		{
			return _dados.assunto;
		}
		set
		{
			if (_dados.assunto != value)
			{
				_dados.assunto = value;
				PropertyHasChanged();
			}
		}
	}

	public string Solicitacao
	{
		get
		{
			return _dados.solicitacao;
		}
		set
		{
			if (_dados.solicitacao != value)
			{
				_dados.solicitacao = value;
				PropertyHasChanged();
			}
		}
	}

	public string Comentario
	{
		get
		{
			return _dados.comentario;
		}
		set
		{
			if (_dados.comentario != value)
			{
				_dados.comentario = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoStatusAtendimento
	{
		get
		{
			return _dados.codigoStatusAtendimento;
		}
		set
		{
			if (_dados.codigoStatusAtendimento != value)
			{
				_dados.codigoStatusAtendimento = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsAcompanhar
	{
		get
		{
			return _dados.isAcompanhar;
		}
		set
		{
			if (_dados.isAcompanhar != value)
			{
				_dados.isAcompanhar = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataAcompanhamento
	{
		get
		{
			return _dados.dataAcompanhamento;
		}
		set
		{
			if (_dados.dataAcompanhamento != value)
			{
				_dados.dataAcompanhamento = value;
				PropertyHasChanged();
			}
		}
	}

	public RHFuncionario Funcionario
	{
		get
		{
			if (_funcionario == null && _dados.codigoFuncionario > 0)
			{
				_funcionario = ModuloRH.ObterRHFuncionario(_dados.codigoFuncionario);
			}
			return _funcionario;
		}
	}

	public ComercialEntidade Entidade
	{
		get
		{
			if (_entidade == null && _dados.codigoEntidade > 0)
			{
				_entidade = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoEntidade);
			}
			return _entidade;
		}
	}

	public ComercialEntidadeContato Contato
	{
		get
		{
			if (_contato == null && _dados.codigoContato > 0)
			{
				_contato = ModuloComercialEntidade.ObterComercialEntidadeContato(_dados.codigoContato);
			}
			return _contato;
		}
	}

	public ComercialEntidadeTipoAtendimento TipoAtendendimento
	{
		get
		{
			if (_tipoAtendimento == null && _dados.codigoTipoAtendimento > 0)
			{
				_tipoAtendimento = ModuloComercialEntidade.ObterComercialEntidadeTipoAtendimento(_dados.codigoTipoAtendimento);
			}
			return _tipoAtendimento;
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialEntidadeEvento);
		_funcionario = null;
		_entidade = null;
		_contato = null;
		_tipoAtendimento = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialEntidadeEvento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialEntidadeEvento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialEntidadeEvento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
