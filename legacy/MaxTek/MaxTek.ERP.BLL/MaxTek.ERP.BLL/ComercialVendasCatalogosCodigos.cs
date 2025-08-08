using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialVendasCatalogosCodigos : BusinessObjectBase
{
	private MapTableComercialVendasCatalogosCodigos _dados;

	private ComercialVendasCatalogos _catalogo;

	private TecnicoEngenhariaProduto _produto;

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

	public int CodigoCatalogo
	{
		get
		{
			return _dados.codigoCatalogo;
		}
		set
		{
			if (_dados.codigoCatalogo != value)
			{
				_dados.codigoCatalogo = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoCatalogoProduto
	{
		get
		{
			return _dados.codigoCatalogoProduto;
		}
		set
		{
			if (_dados.codigoCatalogoProduto != value)
			{
				_dados.codigoCatalogoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoCatalogoProduto
	{
		get
		{
			return _dados.descricaoCatalogoProduto;
		}
		set
		{
			if (_dados.descricaoCatalogoProduto != value)
			{
				_dados.descricaoCatalogoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoProduto
	{
		get
		{
			return _dados.codigoProduto;
		}
		set
		{
			if (_dados.codigoProduto != value)
			{
				_dados.codigoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Preco
	{
		get
		{
			return _dados.preco;
		}
		set
		{
			if (_dados.preco != value)
			{
				_dados.preco = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Desconto
	{
		get
		{
			return _dados.desconto;
		}
		set
		{
			if (_dados.desconto != value)
			{
				_dados.desconto = value;
				PropertyHasChanged();
			}
		}
	}

	public ComercialVendasCatalogos Catalogo
	{
		get
		{
			if (_dados.codigoCatalogo > 0 && _catalogo == null)
			{
				_catalogo = ModuloComercialVendas.ObterComercialVendasCatalogos(_dados.codigoCatalogo);
			}
			return _catalogo;
		}
		set
		{
			if (_catalogo != value)
			{
				_catalogo = value;
				_dados.codigoCatalogo = _catalogo.Id;
				PropertyHasChanged();
			}
		}
	}

	public TecnicoEngenhariaProduto Produto
	{
		get
		{
			if (_dados.codigoProduto > 0 && _produto == null)
			{
				_produto = ModuloTecnicoEngenhariaProduto.ObterTecnicoEngenhariaProduto(_dados.codigoProduto);
			}
			return _produto;
		}
		set
		{
			if (_produto != value)
			{
				_produto = value;
				_dados.codigoProduto = _produto.Id;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialVendasCatalogosCodigos);
		_catalogo = null;
		_produto = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialVendasCatalogosCodigos()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialVendasCatalogosCodigos(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialVendasCatalogosCodigos)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
