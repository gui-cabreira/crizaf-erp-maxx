using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialVendasPedidos : BusinessObjectBase
{
	private MapTableComercialVendasPedidos _dados;

	private IList<ComercialVendasPedidosItens> _itens;

	private ComercialEntidade _cliente;

	private ComercialEntidadeContato _contato;

	private ComercialFinanceiroModoPagamento _modoPagamento;

	private ComercialFinanceiroCondicaoPagamento _condicaoPagamento;

	private ComercialEntidade _transportadora;

	private RHFuncionario _vendedor;

	private ComercialEntidade _representante;

	private ComercialEntidade _localEntrega;

	private ComercialEntidade _localFaturamento;

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

	public EnumComercialVendasPedidosStatus CodigoStatus
	{
		get
		{
			return (EnumComercialVendasPedidosStatus)_dados.codigoStatus;
		}
		set
		{
			if (_dados.codigoStatus != (int)value)
			{
				_dados.codigoStatus = (int)value;
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

	public DateTime DataAtualizacao
	{
		get
		{
			return _dados.dataAtualizacao;
		}
		set
		{
			if (_dados.dataAtualizacao != value)
			{
				_dados.dataAtualizacao = value;
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

	public int CodigoEntidadeContato
	{
		get
		{
			return _dados.codigoEntidadeContato;
		}
		set
		{
			if (_dados.codigoEntidadeContato != value)
			{
				_dados.codigoEntidadeContato = value;
				PropertyHasChanged();
			}
		}
	}

	public string ReferenciaPedido
	{
		get
		{
			return _dados.referenciaPedido;
		}
		set
		{
			if (_dados.referenciaPedido != value)
			{
				_dados.referenciaPedido = value;
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

	public int CodigoModoPagamento
	{
		get
		{
			return _dados.codigoModoPagamento;
		}
		set
		{
			if (_dados.codigoModoPagamento != value)
			{
				_dados.codigoModoPagamento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCondicaoPagamento
	{
		get
		{
			return _dados.codigoCondicaoPagamento;
		}
		set
		{
			if (_dados.codigoCondicaoPagamento != value)
			{
				_dados.codigoCondicaoPagamento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTransportadora
	{
		get
		{
			return _dados.codigoTransportadora;
		}
		set
		{
			if (_dados.codigoTransportadora != value)
			{
				_dados.codigoTransportadora = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoVendedor
	{
		get
		{
			return _dados.codigoVendedor;
		}
		set
		{
			if (_dados.codigoVendedor != value)
			{
				_dados.codigoVendedor = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoRepresentante
	{
		get
		{
			return _dados.codigoRepresentante;
		}
		set
		{
			if (_dados.codigoRepresentante != value)
			{
				_dados.codigoRepresentante = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEntidadeEntrega
	{
		get
		{
			return _dados.codigoEntidadeEntrega;
		}
		set
		{
			if (_dados.codigoEntidadeEntrega != value)
			{
				_dados.codigoEntidadeEntrega = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEntidadeFatura
	{
		get
		{
			return _dados.codigoEntidadeFatura;
		}
		set
		{
			if (_dados.codigoEntidadeFatura != value)
			{
				_dados.codigoEntidadeFatura = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCfop
	{
		get
		{
			return _dados.codigoCfop;
		}
		set
		{
			if (_dados.codigoCfop != value)
			{
				_dados.codigoCfop = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoMoeda
	{
		get
		{
			return _dados.codigoMoeda;
		}
		set
		{
			if (_dados.codigoMoeda != value)
			{
				_dados.codigoMoeda = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoPedido
	{
		get
		{
			return _dados.descricaoPedido;
		}
		set
		{
			if (_dados.descricaoPedido != value)
			{
				_dados.descricaoPedido = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<ComercialVendasPedidosItens> Itens
	{
		get
		{
			if (_itens == null)
			{
				_itens = ModuloComercialVendas.ObterTodosComercialVendasPedidosItens(_dados.id);
			}
			return _itens;
		}
		set
		{
			if (_itens != value)
			{
				_itens = value;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidade Cliente
	{
		get
		{
			if (_dados.codigoEntidade > 0 && _cliente == null)
			{
				_cliente = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoEntidade);
			}
			return _cliente;
		}
		set
		{
			if (_cliente != null)
			{
				_cliente = value;
				_dados.codigoEntidade = _cliente.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidadeContato Contato
	{
		get
		{
			if (_dados.codigoEntidadeContato > 0 && _contato == null)
			{
				_contato = ModuloComercialEntidade.ObterComercialEntidadeContato(_dados.codigoEntidadeContato);
			}
			return _contato;
		}
		set
		{
			if (_contato != null)
			{
				_contato = value;
				_dados.codigoEntidadeContato = _contato.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialFinanceiroModoPagamento ModoPagamento
	{
		get
		{
			if (_dados.codigoModoPagamento > 0 && _modoPagamento == null)
			{
				_modoPagamento = ModuloComercialFinanceiro.ObterComercialFinanceiroModoPagamento(_dados.codigoModoPagamento);
			}
			return _modoPagamento;
		}
		set
		{
			if (_modoPagamento != null)
			{
				_modoPagamento = value;
				_dados.codigoModoPagamento = _modoPagamento.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialFinanceiroCondicaoPagamento CondicaoPagamento
	{
		get
		{
			if (_dados.codigoCondicaoPagamento > 0 && _condicaoPagamento == null)
			{
				_condicaoPagamento = ModuloComercialFinanceiro.ObterComercialFinanceiroCondicaoPagamento(_dados.codigoCondicaoPagamento);
			}
			return _condicaoPagamento;
		}
		set
		{
			if (_condicaoPagamento != null)
			{
				_condicaoPagamento = value;
				_dados.codigoCondicaoPagamento = _condicaoPagamento.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidade Transportadora
	{
		get
		{
			if (_dados.codigoTransportadora > 0 && _transportadora == null)
			{
				_transportadora = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoTransportadora);
			}
			return _transportadora;
		}
		set
		{
			if (_transportadora != null)
			{
				_transportadora = value;
				_dados.codigoTransportadora = _transportadora.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public RHFuncionario Vendedor
	{
		get
		{
			if (_dados.codigoVendedor > 0 && _vendedor == null)
			{
				_vendedor = ModuloRH.ObterRHFuncionario(_dados.codigoVendedor);
			}
			return _vendedor;
		}
		set
		{
			if (_vendedor != null)
			{
				_vendedor = value;
				_dados.codigoVendedor = _vendedor.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidade Representante
	{
		get
		{
			if (_dados.codigoRepresentante > 0 && _representante == null)
			{
				_representante = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoRepresentante);
			}
			return _representante;
		}
		set
		{
			if (_representante != null)
			{
				_representante = value;
				_dados.codigoRepresentante = _representante.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidade LocalEntrega
	{
		get
		{
			if (_dados.codigoEntidadeEntrega > 0 && _localEntrega == null)
			{
				_localEntrega = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoEntidadeEntrega);
			}
			return _localEntrega;
		}
		set
		{
			if (_localEntrega != null)
			{
				_localEntrega = value;
				_dados.codigoEntidadeEntrega = _representante.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public ComercialEntidade LocalFaturamento
	{
		get
		{
			if (_dados.codigoEntidadeFatura > 0 && _localFaturamento == null)
			{
				_localFaturamento = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoEntidadeFatura);
			}
			return _localFaturamento;
		}
		set
		{
			if (_localFaturamento != null)
			{
				_localFaturamento = value;
				_dados.codigoEntidadeFatura = _localFaturamento.Codigo;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTotal => CalcularValorPedido();

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialVendasPedidos);
		_itens = null;
		_cliente = null;
		_contato = null;
		_modoPagamento = null;
		_condicaoPagamento = null;
		_transportadora = null;
		_vendedor = null;
		_representante = null;
		_localEntrega = null;
		_localFaturamento = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialVendasPedidos()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialVendasPedidos(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	private decimal CalcularValorPedido()
	{
		decimal result = default(decimal);
		foreach (ComercialVendasPedidosItens iten in Itens)
		{
			result += iten.Valor;
		}
		return result;
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialVendasPedidos)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
