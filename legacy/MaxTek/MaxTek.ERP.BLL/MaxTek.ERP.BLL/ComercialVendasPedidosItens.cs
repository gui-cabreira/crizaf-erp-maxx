using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialVendasPedidosItens : BusinessObjectBase
{
	private MapTableComercialVendasPedidosItens _dados;

	private ComercialVendasPedidos _pedido;

	private IList<ComercialVendasPedidosItensCadencia> _cadencias;

	private TecnicoEngenhariaProdutoUnidade _unidade;

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

	public int CodigoPedidoVenda
	{
		get
		{
			return _dados.codigoPedidoVenda;
		}
		set
		{
			if (_dados.codigoPedidoVenda != value)
			{
				_dados.codigoPedidoVenda = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoPedidoVendaItem
	{
		get
		{
			return _dados.codigoPedidoVendaItem;
		}
		set
		{
			if (_dados.codigoPedidoVendaItem != value)
			{
				_dados.codigoPedidoVendaItem = value;
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

	public decimal ValorUnitario
	{
		get
		{
			return _dados.valorUnitario;
		}
		set
		{
			if (_dados.valorUnitario != value)
			{
				_dados.valorUnitario = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorPercentualDesconto
	{
		get
		{
			return _dados.valorPercentualDesconto;
		}
		set
		{
			if (_dados.valorPercentualDesconto != value)
			{
				_dados.valorPercentualDesconto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCustosDiversos
	{
		get
		{
			return _dados.valorCustosDiversos;
		}
		set
		{
			if (_dados.valorCustosDiversos != value)
			{
				_dados.valorCustosDiversos = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidade
	{
		get
		{
			return _dados.codigoUnidade;
		}
		set
		{
			if (_dados.codigoUnidade != value)
			{
				_dados.codigoUnidade = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataEntrega
	{
		get
		{
			return _dados.dataEntrega;
		}
		set
		{
			if (_dados.dataEntrega != value)
			{
				_dados.dataEntrega = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEmbalagem
	{
		get
		{
			return _dados.codigoEmbalagem;
		}
		set
		{
			if (_dados.codigoEmbalagem != value)
			{
				_dados.codigoEmbalagem = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsReserva
	{
		get
		{
			return _dados.isReserva;
		}
		set
		{
			if (_dados.isReserva != value)
			{
				_dados.isReserva = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsCancelado
	{
		get
		{
			return _dados.isCancelado;
		}
		set
		{
			if (_dados.isCancelado != value)
			{
				_dados.isCancelado = value;
				PropertyHasChanged();
			}
		}
	}

	public string ComentarioItem
	{
		get
		{
			return _dados.comentarioItem;
		}
		set
		{
			if (_dados.comentarioItem != value)
			{
				_dados.comentarioItem = value;
				PropertyHasChanged();
			}
		}
	}

	public ComercialVendasPedidos Pedido
	{
		get
		{
			if (_pedido == null)
			{
				_pedido = ModuloComercialVendas.ObterComercialVendasPedidos(_dados.codigoPedidoVenda);
			}
			return _pedido;
		}
		set
		{
			if (_pedido != value)
			{
				_pedido = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<ComercialVendasPedidosItensCadencia> Cadencias
	{
		get
		{
			if (_cadencias == null)
			{
				_cadencias = ModuloComercialVendas.ObterTodosComercialVendasPedidosItensCadencia(_dados.id);
			}
			return _cadencias;
		}
		set
		{
			if (_cadencias != value)
			{
				_cadencias = value;
				PropertyHasChanged();
			}
		}
	}

	public TecnicoEngenhariaProdutoUnidade Unidade
	{
		get
		{
			if (_unidade == null)
			{
				_unidade = ModuloTecnicoEngenhariaProduto.ObterTecnicoEngenhariaProdutoUnidade(_dados.codigoUnidade);
			}
			return _unidade;
		}
		set
		{
			if (_unidade != value)
			{
				_unidade = value;
				_dados.codigoUnidade = _unidade.Id;
				PropertyHasChanged();
			}
		}
	}

	public TecnicoEngenhariaProduto Produto
	{
		get
		{
			if (_produto == null)
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

	public decimal QuantidadePedida => CalcularQuantidadePedida();

	public decimal QuantidadeEntregue => CalcularQuantidadeEntregue();

	public decimal Valor => _dados.valorUnitario * QuantidadePedida;

	public DateTime DataUltimaEntrega => VerificarDataUltimaEntrega();

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialVendasPedidosItens);
		_pedido = null;
		_cadencias = null;
		_unidade = null;
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

	public ComercialVendasPedidosItens()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialVendasPedidosItens(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	private decimal CalcularQuantidadePedida()
	{
		decimal result = default(decimal);
		foreach (ComercialVendasPedidosItensCadencia cadencia in Cadencias)
		{
			result += cadencia.QuantidadePedida;
		}
		return result;
	}

	private decimal CalcularQuantidadeEntregue()
	{
		decimal result = default(decimal);
		foreach (ComercialVendasPedidosItensCadencia cadencia in Cadencias)
		{
			result += cadencia.QuantidadeEntrega;
		}
		return result;
	}

	private DateTime VerificarDataUltimaEntrega()
	{
		DateTime dateTime = DateTime.MinValue;
		foreach (ComercialVendasPedidosItensCadencia cadencia in Cadencias)
		{
			if (dateTime < cadencia.DataEntrega)
			{
				dateTime = cadencia.DataEntrega;
			}
		}
		return dateTime;
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialVendasPedidosItens)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
