using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalResumoFaturamentoItem : BusinessObjectBase
{
	private MapTableResumoFaturamentoItem _dados;

	private Estoque _estoque;

	public int CodigoCliente => _dados.codigoCliente;

	public string CodigoProduto => _dados.codigoProduto;

	public decimal Quantidade => _dados.quantidade;

	public decimal ValorUnitario => _dados.valorUnitario;

	public decimal ValorTotal => _dados.valorTotal;

	public decimal ValorImposto => _dados.valorImposto;

	public string Cfop => _dados.cfop;

	public string Unidade => _dados.unidade;

	public string ContaContabil => _dados.contaContabil;

	public Estoque EstoqueRef
	{
		get
		{
			if (_estoque == null)
			{
				_estoque = ModuloEngenharia.ObterProdutoEstoque(1, CodigoProduto, 1, 0m, 0m, 0m, 0);
				if (_estoque == null)
				{
					_estoque = ModuloEngenharia.ObterProdutoEstoque(1, CodigoProduto, 0, 0m, 0m, 0m, 0);
				}
				if (_estoque == null)
				{
					_estoque = ModuloEngenharia.ObterProdutoEstoque(2, CodigoProduto, 0, 0m, 0m, 0m, 0);
				}
			}
			return _estoque;
		}
	}

	public ChaveEstoque ChaveEstoqueRef
	{
		get
		{
			ChaveEstoque result = default(ChaveEstoque);
			if (EstoqueRef != null)
			{
				return EstoqueRef.ChavePrimariaEstoque;
			}
			return result;
		}
	}

	public decimal ValorUnitarioLiquido => (ValorTotal - ValorImposto) / Quantidade;

	public decimal QuantidadePadraoMetrico
	{
		get
		{
			decimal quantidade = Quantidade;
			if (Unidade.ToUpper() == "MH")
			{
				quantidade *= 1000m;
			}
			return quantidade;
		}
	}

	public decimal ValorUnitarioLiquidoPadraoMetrico
	{
		get
		{
			decimal valorUnitarioLiquido = ValorUnitarioLiquido;
			if (Unidade.ToUpper() == "MH")
			{
				valorUnitarioLiquido /= 1000m;
			}
			return Math.Round(valorUnitarioLiquido, 4);
		}
	}

	public decimal ValorUnitarioPadraoMetrico
	{
		get
		{
			decimal valorUnitario = ValorUnitario;
			if (Unidade.ToUpper() == "MH")
			{
				valorUnitario /= 1000m;
			}
			return Math.Round(valorUnitario, 4);
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableResumoFaturamentoItem);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalResumoFaturamentoItem()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalResumoFaturamentoItem(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableResumoFaturamentoItem)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
