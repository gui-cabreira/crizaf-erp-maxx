using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProdutoTipo : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProdutoTipo _dados;

	public int Id
	{
		get
		{
			return _dados.id;
		}
		set
		{
			if (_dados.id != value)
			{
				_dados.id = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoProduto
	{
		get
		{
			return _dados.tipoProduto;
		}
		set
		{
			if (_dados.tipoProduto != value)
			{
				_dados.tipoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeDimensao01
	{
		get
		{
			return _dados.nomeDimensao01;
		}
		set
		{
			if (_dados.nomeDimensao01 != value)
			{
				_dados.nomeDimensao01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeDimensao02
	{
		get
		{
			return _dados.nomeDimensao02;
		}
		set
		{
			if (_dados.nomeDimensao02 != value)
			{
				_dados.nomeDimensao02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeDimensao03
	{
		get
		{
			return _dados.nomeDimensao03;
		}
		set
		{
			if (_dados.nomeDimensao03 != value)
			{
				_dados.nomeDimensao03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeDimensao04
	{
		get
		{
			return _dados.nomeDimensao04;
		}
		set
		{
			if (_dados.nomeDimensao04 != value)
			{
				_dados.nomeDimensao04 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidadeEstoque
	{
		get
		{
			return _dados.codigoUnidadeEstoque;
		}
		set
		{
			if (_dados.codigoUnidadeEstoque != value)
			{
				_dados.codigoUnidadeEstoque = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidadeCompra
	{
		get
		{
			return _dados.codigoUnidadeCompra;
		}
		set
		{
			if (_dados.codigoUnidadeCompra != value)
			{
				_dados.codigoUnidadeCompra = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProdutoTipo);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProdutoTipo()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProdutoTipo(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProdutoTipo)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
