using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialVendasPedidosItensCadencia : BusinessObjectBase
{
	private MapTableComercialVendasPedidosItensCadencia _dados;

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

	public int CodigoPedidoItem
	{
		get
		{
			return _dados.codigoPedidoItem;
		}
		set
		{
			if (_dados.codigoPedidoItem != value)
			{
				_dados.codigoPedidoItem = value;
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

	public DateTime DataLiberacaoProducao
	{
		get
		{
			return _dados.dataLiberacaoProducao;
		}
		set
		{
			if (_dados.dataLiberacaoProducao != value)
			{
				_dados.dataLiberacaoProducao = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsFirme
	{
		get
		{
			return _dados.isFirme;
		}
		set
		{
			if (_dados.isFirme != value)
			{
				_dados.isFirme = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadePedida
	{
		get
		{
			return _dados.quantidadePedida;
		}
		set
		{
			if (_dados.quantidadePedida != value)
			{
				_dados.quantidadePedida = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeEntrega
	{
		get
		{
			return _dados.quantidadeEntrega;
		}
		set
		{
			if (_dados.quantidadeEntrega != value)
			{
				_dados.quantidadeEntrega = value;
				PropertyHasChanged();
			}
		}
	}

	public string ComentarioCadencia
	{
		get
		{
			return _dados.comentarioCadencia;
		}
		set
		{
			if (_dados.comentarioCadencia != value)
			{
				_dados.comentarioCadencia = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialVendasPedidosItensCadencia);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialVendasPedidosItensCadencia()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialVendasPedidosItensCadencia(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialVendasPedidosItensCadencia)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
