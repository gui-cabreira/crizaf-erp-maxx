using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialVendasCatalogos : BusinessObjectBase
{
	private MapTableComercialVendasCatalogos _dados;

	private IList<ComercialVendasCatalogosCodigos> _codigosProduto;

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

	public bool IsPercentualPrecoBase
	{
		get
		{
			return _dados.isPercentualPrecoBase;
		}
		set
		{
			if (_dados.isPercentualPrecoBase != value)
			{
				_dados.isPercentualPrecoBase = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualPrecoBase
	{
		get
		{
			return _dados.percentualPrecoBase;
		}
		set
		{
			if (_dados.percentualPrecoBase != value)
			{
				_dados.percentualPrecoBase = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<ComercialVendasCatalogosCodigos> CodigosProduto
	{
		get
		{
			if (_codigosProduto == null)
			{
				_codigosProduto = ModuloComercialVendas.ObterTodosComercialVendasCatalogosCodigos(_dados.id);
			}
			return _codigosProduto;
		}
		set
		{
			if (_codigosProduto != value)
			{
				_codigosProduto = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialVendasCatalogos);
		_codigosProduto = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialVendasCatalogos()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialVendasCatalogos(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialVendasCatalogos)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
