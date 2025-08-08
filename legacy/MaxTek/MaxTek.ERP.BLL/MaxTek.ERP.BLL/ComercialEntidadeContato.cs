using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialEntidadeContato : BusinessObjectBase
{
	private MapTableComercialEntidadeContato _dados;

	private ComercialEntidade _entidade;

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

	public string Nome
	{
		get
		{
			return _dados.nome;
		}
		set
		{
			if (_dados.nome != value)
			{
				_dados.nome = value;
				PropertyHasChanged();
			}
		}
	}

	public string Funcao
	{
		get
		{
			return _dados.funcao;
		}
		set
		{
			if (_dados.funcao != value)
			{
				_dados.funcao = value;
				PropertyHasChanged();
			}
		}
	}

	public string Cargo
	{
		get
		{
			return _dados.cargo;
		}
		set
		{
			if (_dados.cargo != value)
			{
				_dados.cargo = value;
				PropertyHasChanged();
			}
		}
	}

	public string Telefone
	{
		get
		{
			return _dados.telefone;
		}
		set
		{
			if (_dados.telefone != value)
			{
				_dados.telefone = value;
				PropertyHasChanged();
			}
		}
	}

	public string Celular
	{
		get
		{
			return _dados.celular;
		}
		set
		{
			if (_dados.celular != value)
			{
				_dados.celular = value;
				PropertyHasChanged();
			}
		}
	}

	public string Email
	{
		get
		{
			return _dados.email;
		}
		set
		{
			if (_dados.email != value)
			{
				_dados.email = value;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidade Entidade
	{
		get
		{
			if (_entidade == null)
			{
				_entidade = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoEntidade);
			}
			return _entidade;
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialEntidadeContato);
		_entidade = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialEntidadeContato()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialEntidadeContato(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialEntidadeContato)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
