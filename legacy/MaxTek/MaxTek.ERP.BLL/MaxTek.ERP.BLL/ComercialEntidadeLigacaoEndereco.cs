using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialEntidadeLigacaoEndereco : BusinessObjectBase
{
	private MapTableComercialEntidadeLigacaoEndereco _dados;

	private ComercialEntidade _entidade;

	private ComercialEntidade _entidadeEndereco;

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

	public int CodigoEntidadeEndereco
	{
		get
		{
			return _dados.codigoEntidadeEndereco;
		}
		set
		{
			if (_dados.codigoEntidadeEndereco != value)
			{
				_dados.codigoEntidadeEndereco = value;
				PropertyHasChanged();
			}
		}
	}

	public string Descricao
	{
		get
		{
			return _dados.descricao;
		}
		set
		{
			if (_dados.descricao != value)
			{
				_dados.descricao = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsEnderecoEntrega
	{
		get
		{
			return _dados.isEnderecoEntrega;
		}
		set
		{
			if (_dados.isEnderecoEntrega != value)
			{
				_dados.isEnderecoEntrega = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsEnderecoCobranca
	{
		get
		{
			return _dados.isEnderecoCobranca;
		}
		set
		{
			if (_dados.isEnderecoCobranca != value)
			{
				_dados.isEnderecoCobranca = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsEnderecoFaturamente
	{
		get
		{
			return _dados.isEnderecoFaturamente;
		}
		set
		{
			if (_dados.isEnderecoFaturamente != value)
			{
				_dados.isEnderecoFaturamente = value;
				PropertyHasChanged();
			}
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

	public ComercialEntidade EntidadeEndereco
	{
		get
		{
			if (_entidadeEndereco == null && _dados.codigoEntidadeEndereco > 0)
			{
				_entidadeEndereco = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoEntidadeEndereco);
			}
			return _entidadeEndereco;
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialEntidadeLigacaoEndereco);
		_entidade = null;
		_entidadeEndereco = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialEntidadeLigacaoEndereco()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialEntidadeLigacaoEndereco(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialEntidadeLigacaoEndereco)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
