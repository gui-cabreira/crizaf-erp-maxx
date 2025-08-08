using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.BLL.NotaFiscal.NFe;
using MaxTek.ERP.DAL;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalNotasFiscaisItens : BusinessObjectBase
{
	private MapTableNotaFiscalNotasFiscaisItens _dados;

	private NotaFiscalCFOPs _cfop;

	private EstoqueConsignado _consignado;

	private EstoqueConsignadoLote _consignadoLote;

	private EstoqueConsignadoMovimento _consignadoMovimento;

	private FichaExpedicaoItem _fichaExpedicaoItem;

	private PedidoVendaItemGPS _pedidoVendaItemGPS;

	private PedidoVendaGPS _pedidoVendaGPS;

	private PedidoCompraItem _pedidoCompraItemGPS;

	private ChaveEstoque _chaveEstoque;

	private NotaFiscalNotasFiscaisItensDI _notaFiscalNotasFiscaisItensDI;

	private decimal valorTotalImportacao = default(decimal);

	private readonly bool _basePisCofinsSemICMS = ModuloParametros.ObterParametros("Faturamento", "BasePisCofinsSemICMS").Valor == 1;

	private NotaFiscalNotasFiscais _nf;

	public decimal ValorTotalImportacao => valorTotalImportacao;

	public int CodigoEmpresa
	{
		get
		{
			if (_dados.codigoEmpresa == 0)
			{
				CodigoEmpresa = 1;
			}
			return _dados.codigoEmpresa;
		}
		set
		{
			if (_dados.codigoEmpresa != value)
			{
				_dados.codigoEmpresa = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoNotaFiscal
	{
		get
		{
			return _dados.codigoNotaFiscal;
		}
		set
		{
			if (_dados.codigoNotaFiscal != value)
			{
				_dados.codigoNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int Ordem
	{
		get
		{
			return _dados.ordem;
		}
		set
		{
			if (_dados.ordem != value)
			{
				_dados.ordem = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoProduto
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

	public string DescricaoProduto
	{
		get
		{
			return _dados.descricaoProduto;
		}
		set
		{
			if (_dados.descricaoProduto != value)
			{
				_dados.descricaoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Quantidade
	{
		get
		{
			return _dados.quantidade;
		}
		set
		{
			if (_dados.quantidade != Math.Round(value, 4))
			{
				_dados.quantidade = Math.Round(value, 4);
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
			if (_dados.valorUnitario != Math.Round(value, 6))
			{
				_dados.valorUnitario = Math.Round(value, 6);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTotal
	{
		get
		{
			return _dados.valorTotal;
		}
		set
		{
			if (_dados.valorTotal != Math.Round(value, 2))
			{
				_dados.valorTotal = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseICMS
	{
		get
		{
			return _dados.valorBaseICMS;
		}
		set
		{
			if (_dados.valorBaseICMS != Math.Round(value, 2))
			{
				_dados.valorBaseICMS = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal AliquotaICMS
	{
		get
		{
			return _dados.aliquotaICMS;
		}
		set
		{
			if (_dados.aliquotaICMS != value)
			{
				_dados.aliquotaICMS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorICMS
	{
		get
		{
			return _dados.valorICMS;
		}
		set
		{
			if (_dados.valorICMS != Math.Round(value, 2))
			{
				_dados.valorICMS = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal AliquotaIPI
	{
		get
		{
			return _dados.aliquotaIPI;
		}
		set
		{
			if (_dados.aliquotaIPI != value)
			{
				_dados.aliquotaIPI = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIPI
	{
		get
		{
			return _dados.valorIPI;
		}
		set
		{
			if (_dados.valorIPI != Math.Round(value, 2))
			{
				_dados.valorIPI = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorPIS
	{
		get
		{
			return _dados.valorPIS;
		}
		set
		{
			if (_dados.valorPIS != Math.Round(value, 2))
			{
				_dados.valorPIS = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCofins
	{
		get
		{
			return _dados.valorCofins;
		}
		set
		{
			if (_dados.valorCofins != Math.Round(value, 2))
			{
				_dados.valorCofins = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFrete
	{
		get
		{
			return _dados.valorFrete;
		}
		set
		{
			if (_dados.valorFrete != Math.Round(value, 2))
			{
				_dados.valorFrete = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorSeguro
	{
		get
		{
			return _dados.valorSeguro;
		}
		set
		{
			if (_dados.valorSeguro != Math.Round(value, 2))
			{
				_dados.valorSeguro = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string CodigoClassificacaoFiscal
	{
		get
		{
			return _dados.codigoClassificacaoFiscal.ToString("00000000");
		}
		set
		{
			if (_dados.codigoClassificacaoFiscal.ToString() != value)
			{
				int result = 0;
				int.TryParse(value, out result);
				_dados.codigoClassificacaoFiscal = result;
				PropertyHasChanged();
				AjustarCest();
			}
		}
	}

	public string NomeCfop
	{
		get
		{
			return MetodosUteis.LimpaNro(_dados.nomeCfop);
		}
		set
		{
			if (_dados.nomeCfop != MetodosUteis.LimpaNro(value))
			{
				_dados.nomeCfop = MetodosUteis.LimpaNro(value);
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCFOPInterna
	{
		get
		{
			return _dados.codigoCFOPInterna;
		}
		set
		{
			if (_dados.codigoCFOPInterna != value)
			{
				_dados.codigoCFOPInterna = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFichaExpedicao
	{
		get
		{
			return _dados.codigoFichaExpedicao;
		}
		set
		{
			if (_dados.codigoFichaExpedicao != value)
			{
				_dados.codigoFichaExpedicao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFichaExpedicaoItem
	{
		get
		{
			return _dados.codigoFichaExpedicaoItem;
		}
		set
		{
			if (_dados.codigoFichaExpedicaoItem != value)
			{
				_dados.codigoFichaExpedicaoItem = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFatura
	{
		get
		{
			return _dados.valorFatura;
		}
		set
		{
			if (_dados.valorFatura != Math.Round(value, 2))
			{
				_dados.valorFatura = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string CodigoOrigemProduto
	{
		get
		{
			return _dados.codigoOrigemProduto;
		}
		set
		{
			if (_dados.codigoOrigemProduto != value)
			{
				_dados.codigoOrigemProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseReducaoSemFrete
	{
		get
		{
			return _dados.valorBaseReducaoSemFrete;
		}
		set
		{
			if (_dados.valorBaseReducaoSemFrete != Math.Round(value, 2))
			{
				_dados.valorBaseReducaoSemFrete = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualBaseReducaoIcms
	{
		get
		{
			return (_dados.percentualBaseReducaoIcms == 0m) ? 100m : _dados.percentualBaseReducaoIcms;
		}
		set
		{
			if (_dados.percentualBaseReducaoIcms != value)
			{
				_dados.percentualBaseReducaoIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoModalidadeIcms
	{
		get
		{
			return _dados.codigoModalidadeIcms;
		}
		set
		{
			if (_dados.codigoModalidadeIcms != value)
			{
				_dados.codigoModalidadeIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoIncidenciaIcms
	{
		get
		{
			return _dados.tipoIncidenciaIcms;
		}
		set
		{
			if (_dados.tipoIncidenciaIcms != value)
			{
				_dados.tipoIncidenciaIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoIncidenciaIpi
	{
		get
		{
			return _dados.tipoIncidenciaIpi;
		}
		set
		{
			if (_dados.tipoIncidenciaIpi != value)
			{
				_dados.tipoIncidenciaIpi = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoIncidenciaPis
	{
		get
		{
			return _dados.tipoIncidenciaPis;
		}
		set
		{
			if (_dados.tipoIncidenciaPis != value)
			{
				_dados.tipoIncidenciaPis = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoIncidenciaCofins
	{
		get
		{
			return _dados.tipoIncidenciaCofins;
		}
		set
		{
			if (_dados.tipoIncidenciaCofins != value)
			{
				_dados.tipoIncidenciaCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal AliquotaPis
	{
		get
		{
			return _dados.aliquotaPis;
		}
		set
		{
			if (_dados.aliquotaPis != value)
			{
				_dados.aliquotaPis = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualRetencaoPis
	{
		get
		{
			return _dados.percentualRetencaoPis;
		}
		set
		{
			if (_dados.percentualRetencaoPis != value)
			{
				_dados.percentualRetencaoPis = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorRetencaoPis
	{
		get
		{
			return _dados.valorRetencaoPis;
		}
		set
		{
			if (_dados.valorRetencaoPis != Math.Round(value, 2))
			{
				_dados.valorRetencaoPis = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal AliquotaCofins
	{
		get
		{
			return _dados.aliquotaCofins;
		}
		set
		{
			if (_dados.aliquotaCofins != value)
			{
				_dados.aliquotaCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualRetencaoCofins
	{
		get
		{
			return _dados.percentualRetencaoCofins;
		}
		set
		{
			if (_dados.percentualRetencaoCofins != value)
			{
				_dados.percentualRetencaoCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorRetencaoCofins
	{
		get
		{
			return _dados.valorRetencaoCofins;
		}
		set
		{
			if (_dados.valorRetencaoCofins != Math.Round(value, 2))
			{
				_dados.valorRetencaoCofins = Math.Round(value, 2);
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

	public int CodigoPedidoCompra
	{
		get
		{
			return _dados.codigoPedidoCompra;
		}
		set
		{
			if (_dados.codigoPedidoCompra != value)
			{
				_dados.codigoPedidoCompra = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoPedidoCompraItem
	{
		get
		{
			return _dados.codigoPedidoCompraItem;
		}
		set
		{
			if (_dados.codigoPedidoCompraItem != value)
			{
				_dados.codigoPedidoCompraItem = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsCsll
	{
		get
		{
			return _dados.isCsll;
		}
		set
		{
			if (_dados.isCsll != value)
			{
				_dados.isCsll = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualCsll
	{
		get
		{
			return _dados.percentualCsll;
		}
		set
		{
			if (_dados.percentualCsll != value)
			{
				_dados.percentualCsll = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCsll
	{
		get
		{
			return _dados.valorCsll;
		}
		set
		{
			if (_dados.valorCsll != Math.Round(value, 2))
			{
				_dados.valorCsll = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public bool IsGeraDuplicata
	{
		get
		{
			return _dados.isGeraDuplicata;
		}
		set
		{
			if (_dados.isGeraDuplicata != value)
			{
				_dados.isGeraDuplicata = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsConsumidorFinal
	{
		get
		{
			return _dados.isConsumidorFinal;
		}
		set
		{
			if (_dados.isConsumidorFinal != value)
			{
				_dados.isConsumidorFinal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSerieNotaFiscal
	{
		get
		{
			return _dados.codigoSerieNotaFiscal;
		}
		set
		{
			if (_dados.codigoSerieNotaFiscal != value)
			{
				_dados.codigoSerieNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoAuxiliarAtualizacaoNotaFiscal
	{
		get
		{
			return _dados.codigoAuxiliarAtualizacaoNotaFiscal;
		}
		set
		{
			if (_dados.codigoAuxiliarAtualizacaoNotaFiscal != value)
			{
				_dados.codigoAuxiliarAtualizacaoNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public string ContaContabilAnalitica
	{
		get
		{
			return _dados.contaContabilAnalitica;
		}
		set
		{
			if (_dados.contaContabilAnalitica != value)
			{
				_dados.contaContabilAnalitica = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoPedidoCompraCliente
	{
		get
		{
			return _dados.codigoPedidoCompraCliente;
		}
		set
		{
			if (_dados.codigoPedidoCompraCliente != value)
			{
				_dados.codigoPedidoCompraCliente = value;
				if (!string.IsNullOrEmpty(value) && value.Length > 15)
				{
					CodigoPedidoCompraCliente = value.Substring(0, 15);
				}
				PropertyHasChanged();
			}
		}
	}

	public int CodigoPedidoCompraItemCliente
	{
		get
		{
			return _dados.codigoPedidoCompraItemCliente;
		}
		set
		{
			if (_dados.codigoPedidoCompraItemCliente != value)
			{
				_dados.codigoPedidoCompraItemCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoGrupoEstoqueGPS
	{
		get
		{
			return _dados.codigoGrupoEstoqueGPS;
		}
		set
		{
			if (_dados.codigoGrupoEstoqueGPS != value)
			{
				_dados.codigoGrupoEstoqueGPS = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoProdutoGPS
	{
		get
		{
			return _dados.codigoProdutoGPS;
		}
		set
		{
			if (_dados.codigoProdutoGPS != value)
			{
				_dados.codigoProdutoGPS = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoProdutoGPS
	{
		get
		{
			return _dados.codigoTipoProdutoGPS;
		}
		set
		{
			if (_dados.codigoTipoProdutoGPS != value)
			{
				_dados.codigoTipoProdutoGPS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorDimensao01GPS
	{
		get
		{
			return _dados.valorDimensao01GPS;
		}
		set
		{
			if (_dados.valorDimensao01GPS != value)
			{
				_dados.valorDimensao01GPS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorDimensao02GPS
	{
		get
		{
			return _dados.valorDimensao02GPS;
		}
		set
		{
			if (_dados.valorDimensao02GPS != value)
			{
				_dados.valorDimensao02GPS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorDimensao03GPS
	{
		get
		{
			return _dados.valorDimensao03GPS;
		}
		set
		{
			if (_dados.valorDimensao03GPS != value)
			{
				_dados.valorDimensao03GPS = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoClienteEntidadeGPS
	{
		get
		{
			return _dados.codigoClienteEntidadeGPS;
		}
		set
		{
			if (_dados.codigoClienteEntidadeGPS != value)
			{
				_dados.codigoClienteEntidadeGPS = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoModalidadeICMSST
	{
		get
		{
			return _dados.codigoModalidadeICMSST;
		}
		set
		{
			if (_dados.codigoModalidadeICMSST != value)
			{
				_dados.codigoModalidadeICMSST = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualBaseAgragadaICMSST
	{
		get
		{
			return _dados.percentualBaseAgragadaICMSST;
		}
		set
		{
			if (_dados.percentualBaseAgragadaICMSST != value)
			{
				_dados.percentualBaseAgragadaICMSST = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseAgragadaICMSST
	{
		get
		{
			return _dados.valorBaseAgragadaICMSST;
		}
		set
		{
			if (_dados.valorBaseAgragadaICMSST != Math.Round(value, 2))
			{
				_dados.valorBaseAgragadaICMSST = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorICMSSTAgregado
	{
		get
		{
			return _dados.valorICMSSTAgregado;
		}
		set
		{
			if (_dados.valorICMSSTAgregado != Math.Round(value, 2))
			{
				_dados.valorICMSSTAgregado = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public int CodigoRecebimentoMaterialCliente
	{
		get
		{
			return _dados.codigoRecebimentoMaterialCliente;
		}
		set
		{
			if (_dados.codigoRecebimentoMaterialCliente != value)
			{
				_dados.codigoRecebimentoMaterialCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualICMSSTAgregado
	{
		get
		{
			return _dados.percentualICMSSTAgregado;
		}
		set
		{
			if (_dados.percentualICMSSTAgregado != value)
			{
				_dados.percentualICMSSTAgregado = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoIpi
	{
		get
		{
			return _dados.valorBaseCalculoIpi;
		}
		set
		{
			if (_dados.valorBaseCalculoIpi != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoIpi = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoPis
	{
		get
		{
			return _dados.valorBaseCalculoPis;
		}
		set
		{
			if (_dados.valorBaseCalculoPis != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoPis = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoCofins
	{
		get
		{
			return _dados.valorBaseCalculoCofins;
		}
		set
		{
			if (_dados.valorBaseCalculoCofins != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoCofins = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoImpostoImportacao
	{
		get
		{
			return _dados.valorBaseCalculoImpostoImportacao;
		}
		set
		{
			if (_dados.valorBaseCalculoImpostoImportacao != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoImpostoImportacao = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorOutros
	{
		get
		{
			return _dados.valorOutros;
		}
		set
		{
			if (_dados.valorOutros != Math.Round(value, 2))
			{
				_dados.valorOutros = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorDespesasAduaneiras
	{
		get
		{
			return _dados.valorDespesasAduaneiras;
		}
		set
		{
			if (_dados.valorDespesasAduaneiras != Math.Round(value, 2))
			{
				_dados.valorDespesasAduaneiras = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorImpostoImportacao
	{
		get
		{
			return _dados.valorImpostoImportacao;
		}
		set
		{
			if (_dados.valorImpostoImportacao != Math.Round(value, 2))
			{
				_dados.valorImpostoImportacao = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIof
	{
		get
		{
			return _dados.valorIof;
		}
		set
		{
			if (_dados.valorIof != Math.Round(value, 2))
			{
				_dados.valorIof = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string ContratoCliente
	{
		get
		{
			return _dados.contratoCliente;
		}
		set
		{
			if (_dados.contratoCliente != value)
			{
				_dados.contratoCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public int ContratoClienteItem
	{
		get
		{
			return _dados.contratoClienteItem;
		}
		set
		{
			if (_dados.contratoClienteItem != value)
			{
				_dados.contratoClienteItem = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEnquadramentoIPI
	{
		get
		{
			return _dados.codigoEnquadramentoIPI;
		}
		set
		{
			if (_dados.codigoEnquadramentoIPI != value)
			{
				_dados.codigoEnquadramentoIPI = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoEan
	{
		get
		{
			return _dados.codigoEan;
		}
		set
		{
			if (_dados.codigoEan != value)
			{
				_dados.codigoEan = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualII
	{
		get
		{
			return _dados.percentualII;
		}
		set
		{
			if (_dados.percentualII != value)
			{
				_dados.percentualII = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorSiscomex
	{
		get
		{
			return _dados.valorSiscomex;
		}
		set
		{
			if (_dados.valorSiscomex != Math.Round(value, 2))
			{
				_dados.valorSiscomex = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorMarinhaMercante
	{
		get
		{
			return _dados.valorMarinhaMercante;
		}
		set
		{
			if (_dados.valorMarinhaMercante != Math.Round(value, 2))
			{
				_dados.valorMarinhaMercante = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public int PecasPorEtiqueta
	{
		get
		{
			return _dados.pecasPorEtiqueta;
		}
		set
		{
			if (_dados.pecasPorEtiqueta != value)
			{
				_dados.pecasPorEtiqueta = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualCreditoIcms
	{
		get
		{
			return _dados.percentualCreditoIcms;
		}
		set
		{
			if (_dados.percentualCreditoIcms != value)
			{
				_dados.percentualCreditoIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCreditoIcms
	{
		get
		{
			return _dados.valorCreditoIcms;
		}
		set
		{
			if (_dados.valorCreditoIcms != Math.Round(value, 2))
			{
				_dados.valorCreditoIcms = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string Cest
	{
		get
		{
			return _dados.cest;
		}
		set
		{
			if (_dados.cest != value)
			{
				_dados.cest = value;
				PropertyHasChanged();
				AjustarCest();
			}
		}
	}

	public bool IsICMSInterestadual
	{
		get
		{
			return _dados.isICMSInterestadual;
		}
		set
		{
			if (_dados.isICMSInterestadual != value)
			{
				_dados.isICMSInterestadual = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualIcmsInterestadualFundoPobreza
	{
		get
		{
			return _dados.percentualIcmsInterestadualFundoPobreza;
		}
		set
		{
			if (_dados.percentualIcmsInterestadualFundoPobreza != value)
			{
				_dados.percentualIcmsInterestadualFundoPobreza = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcmsInterestadualFundoPobreza
	{
		get
		{
			return _dados.valorIcmsInterestadualFundoPobreza;
		}
		set
		{
			if (_dados.valorIcmsInterestadualFundoPobreza != Math.Round(value, 2))
			{
				_dados.valorIcmsInterestadualFundoPobreza = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualIcmsInterestadualUfDestino
	{
		get
		{
			return _dados.percentualIcmsInterestadualUfDestino;
		}
		set
		{
			if (_dados.percentualIcmsInterestadualUfDestino != value)
			{
				_dados.percentualIcmsInterestadualUfDestino = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcmsInterestadualUfDestino
	{
		get
		{
			return _dados.valorIcmsInterestadualUfDestino;
		}
		set
		{
			if (_dados.valorIcmsInterestadualUfDestino != Math.Round(value, 2))
			{
				_dados.valorIcmsInterestadualUfDestino = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualIcmsInterestadualUfEnvolvidas
	{
		get
		{
			return _dados.percentualIcmsInterestadualUfEnvolvidas;
		}
		set
		{
			if (_dados.percentualIcmsInterestadualUfEnvolvidas != value)
			{
				_dados.percentualIcmsInterestadualUfEnvolvidas = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcmsInterestadualUfEnvolvidas
	{
		get
		{
			return _dados.valorIcmsInterestadualUfEnvolvidas;
		}
		set
		{
			if (_dados.valorIcmsInterestadualUfEnvolvidas != Math.Round(value, 2))
			{
				_dados.valorIcmsInterestadualUfEnvolvidas = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string TagXml
	{
		get
		{
			return _dados.tagXml;
		}
		set
		{
			if (_dados.tagXml != value)
			{
				_dados.tagXml = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoEmbalagem
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

	public int QuantidadeEmbalagem
	{
		get
		{
			return _dados.quantidadeEmbalagem;
		}
		set
		{
			if (_dados.quantidadeEmbalagem != value)
			{
				_dados.quantidadeEmbalagem = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PesoLiquido
	{
		get
		{
			return _dados.pesoLiquido;
		}
		set
		{
			if (_dados.pesoLiquido != value)
			{
				_dados.pesoLiquido = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PesoBruto
	{
		get
		{
			return _dados.pesoBruto;
		}
		set
		{
			if (_dados.pesoBruto != value)
			{
				_dados.pesoBruto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorDesconto
	{
		get
		{
			return _dados.valorDesconto;
		}
		set
		{
			if (_dados.valorDesconto != Math.Round(value, 2))
			{
				_dados.valorDesconto = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcmsDesonerado
	{
		get
		{
			return _dados.valorIcmsDesonerado;
		}
		set
		{
			if (_dados.valorIcmsDesonerado != Math.Round(value, 2))
			{
				_dados.valorIcmsDesonerado = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public int MotivoDesoneracaoIcms
	{
		get
		{
			return _dados.motivoDesoneracaoIcms;
		}
		set
		{
			if (_dados.motivoDesoneracaoIcms != value)
			{
				_dados.motivoDesoneracaoIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsFreteBaseCalculoIcms
	{
		get
		{
			return _dados.isFreteBaseCalculoIcms;
		}
		set
		{
			if (_dados.isFreteBaseCalculoIcms != value)
			{
				_dados.isFreteBaseCalculoIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoExterno
	{
		get
		{
			return _dados.codigoExterno;
		}
		set
		{
			if (_dados.codigoExterno != value)
			{
				_dados.codigoExterno = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualReducaoBaseCalculoICMSST
	{
		get
		{
			return _dados.percentualReducaoBaseCalculoICMSST;
		}
		set
		{
			if (_dados.percentualReducaoBaseCalculoICMSST != value)
			{
				_dados.percentualReducaoBaseCalculoICMSST = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoControleReajuste
	{
		get
		{
			return _dados.codigoControleReajuste;
		}
		set
		{
			if (_dados.codigoControleReajuste != value)
			{
				_dados.codigoControleReajuste = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoFCI
	{
		get
		{
			return _dados.codigoFCI;
		}
		set
		{
			if (_dados.codigoFCI != value)
			{
				_dados.codigoFCI = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoFundoCombatePobreza
	{
		get
		{
			return _dados.valorBaseCalculoFundoCombatePobreza;
		}
		set
		{
			if (_dados.valorBaseCalculoFundoCombatePobreza != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoFundoCombatePobreza = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualFundoCombatePobreza
	{
		get
		{
			return _dados.percentualFundoCombatePobreza;
		}
		set
		{
			if (_dados.percentualFundoCombatePobreza != value)
			{
				_dados.percentualFundoCombatePobreza = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFundoCombatePobreza
	{
		get
		{
			return _dados.valorFundoCombatePobreza;
		}
		set
		{
			if (_dados.valorFundoCombatePobreza != Math.Round(value, 2))
			{
				_dados.valorFundoCombatePobreza = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoFundoCombatePobrezaST
	{
		get
		{
			return _dados.valorBaseCalculoFundoCombatePobrezaST;
		}
		set
		{
			if (_dados.valorBaseCalculoFundoCombatePobrezaST != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoFundoCombatePobrezaST = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualFundoCombatePobrezaST
	{
		get
		{
			return _dados.percentualFundoCombatePobrezaST;
		}
		set
		{
			if (_dados.percentualFundoCombatePobrezaST != value)
			{
				_dados.percentualFundoCombatePobrezaST = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFundoCombatePobrezaST
	{
		get
		{
			return _dados.valorFundoCombatePobrezaST;
		}
		set
		{
			if (_dados.valorFundoCombatePobrezaST != Math.Round(value, 2))
			{
				_dados.valorFundoCombatePobrezaST = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public bool IsProduzidoEscalaRelevante
	{
		get
		{
			return _dados.isProduzidoEscalaRelevante;
		}
		set
		{
			if (_dados.isProduzidoEscalaRelevante != value)
			{
				_dados.isProduzidoEscalaRelevante = value;
				PropertyHasChanged();
			}
		}
	}

	public string CnpjFabricante
	{
		get
		{
			return _dados.cnpjFabricante;
		}
		set
		{
			if (_dados.cnpjFabricante != value)
			{
				_dados.cnpjFabricante = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoBenefícioFiscalUF
	{
		get
		{
			return _dados.codigoBenefícioFiscalUF;
		}
		set
		{
			if (_dados.codigoBenefícioFiscalUF != value)
			{
				_dados.codigoBenefícioFiscalUF = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoIcmsStRetido
	{
		get
		{
			return _dados.valorBaseCalculoIcmsStRetido;
		}
		set
		{
			if (_dados.valorBaseCalculoIcmsStRetido != Math.Round(value, 2))
			{
				_dados.valorBaseCalculoIcmsStRetido = Math.Round(value, 2);
				PropertyHasChanged();
				ValorIcmsStRetido = value * PercentualSuportadoConsumidorFinal / 100m;
			}
		}
	}

	public decimal PercentualSuportadoConsumidorFinal
	{
		get
		{
			return _dados.percentualSuportadoConsumidorFinal;
		}
		set
		{
			if (_dados.percentualSuportadoConsumidorFinal != Math.Round(value, 4))
			{
				_dados.percentualSuportadoConsumidorFinal = Math.Round(value, 4);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcmsSubstituto
	{
		get
		{
			return _dados.valorIcmsSubstituto;
		}
		set
		{
			if (_dados.valorIcmsSubstituto != Math.Round(value, 2))
			{
				_dados.valorIcmsSubstituto = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcmsStRetido
	{
		get
		{
			return _dados.valorIcmsStRetido;
		}
		set
		{
			if (_dados.valorIcmsStRetido != Math.Round(value, 2))
			{
				_dados.valorIcmsStRetido = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualIcmsStCargaMedia
	{
		get
		{
			return _dados.percentualIcmsStCargaMedia;
		}
		set
		{
			if (_dados.percentualIcmsStCargaMedia != value)
			{
				_dados.percentualIcmsStCargaMedia = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeEmPecas
	{
		get
		{
			return _dados.quantidadeEmPecas;
		}
		set
		{
			if (_dados.quantidadeEmPecas != value)
			{
				_dados.quantidadeEmPecas = value;
				PropertyHasChanged();
			}
		}
	}

	public string SiglaFaturamentoTributario
	{
		get
		{
			return string.IsNullOrWhiteSpace(_dados.siglaFaturamentoTributario) ? SiglaUnidadeFaturamento : _dados.siglaFaturamentoTributario;
		}
		set
		{
			if (_dados.siglaFaturamentoTributario != value)
			{
				_dados.siglaFaturamentoTributario = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CoefienteValorTributario
	{
		get
		{
			return (_dados.coefienteValorTributario == 0m) ? 1m : _dados.coefienteValorTributario;
		}
		set
		{
			if (_dados.coefienteValorTributario != value)
			{
				_dados.coefienteValorTributario = value;
				PropertyHasChanged();
			}
		}
	}

	public int Extipi
	{
		get
		{
			return _dados.extipi;
		}
		set
		{
			if (_dados.extipi != value)
			{
				_dados.extipi = value;
				PropertyHasChanged("Extipi");
			}
		}
	}

	public FichaExpedicaoItem FichaExpedicaoItemRef
	{
		get
		{
			if (_fichaExpedicaoItem == null && _dados.codigoFichaExpedicao > 0 && _dados.codigoFichaExpedicaoItem > 0)
			{
				_fichaExpedicaoItem = ModuloExpedicao.ObterFichaExpedicaoItem(_dados.codigoFichaExpedicao, _dados.codigoFichaExpedicaoItem);
			}
			return _fichaExpedicaoItem;
		}
		set
		{
			if (_fichaExpedicaoItem != value)
			{
				_fichaExpedicaoItem = value;
				CodigoFichaExpedicao = _fichaExpedicaoItem.CodigoFichaExpedicao;
				CodigoFichaExpedicaoItem = _fichaExpedicaoItem.ItemFichaExpedicao;
			}
		}
	}

	public PedidoCompraItem PedidoCompraItemGPSRef
	{
		get
		{
			if (_pedidoCompraItemGPS == null && _dados.codigoPedidoCompra > 0 && _dados.codigoPedidoCompraItem > 0)
			{
				_pedidoCompraItemGPS = ModuloCompras.ObterPedidoCompraItem(_dados.codigoPedidoCompra, _dados.codigoPedidoCompraItem);
			}
			return _pedidoCompraItemGPS;
		}
	}

	public NotaFiscalCFOPs CFOPRef
	{
		get
		{
			if (_cfop == null && _dados.codigoCFOPInterna > 0)
			{
				_cfop = ModuloNotaFiscal.ObterNotaFiscalCFOPs(_dados.codigoCFOPInterna);
			}
			return _cfop;
		}
		set
		{
			if (_cfop == value)
			{
				return;
			}
			_cfop = value;
			if (value != null)
			{
				CodigoModalidadeIcms = _cfop.ModalidadeICMS.ToString();
				AliquotaICMS = _cfop.PadraoICMS;
				AliquotaIPI = _cfop.PadraoIPI;
				AliquotaCofins = _cfop.ValorCofins;
				AliquotaPis = _cfop.PadraoPIS;
				PercentualBaseReducaoIcms = _cfop.ReducaoICMS;
				CodigoOrigemProduto = _cfop.OrigemProduto.ToString();
				TipoIncidenciaIcms = ModuloNotaFiscal.ObterNotaFiscalTipoIncidencia(_cfop.IncideICMS).TipoIncidencia;
				TipoIncidenciaIpi = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaIPI(_cfop.IncideIPI).CodigoIncidencia;
				TipoIncidenciaPis = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaImpostosFederais(_cfop.IncidePIS).CodigoIncidencia;
				TipoIncidenciaCofins = ModuloNotaFiscal.ObterNotaFiscalTipoIncidenciaImpostosFederais(_cfop.IncideCofins).CodigoIncidencia;
				PercentualRetencaoPis = _cfop.PercentualRetencaoPis;
				PercentualRetencaoCofins = _cfop.PercentualRetencaoCofins;
				IsCsll = _cfop.IsCSLL;
				PercentualCsll = _cfop.ValorCSLL;
				CodigoEnquadramentoIPI = _cfop.CodigoEnquadramentoIPI;
				PercentualII = _cfop.PercentualII;
				Extipi = _cfop.Extipi;
				IsConsumidorFinal = _cfop.IsConsumidorFinal;
				IsGeraDuplicata = _cfop.IsGeraDuplicata;
				NomeCfop = MetodosUteis.LimpaNro(_cfop.NumeracaoCFOP);
				CodigoCFOPInterna = _cfop.Id;
				PercentualCreditoIcms = _cfop.PercentualCreditoIcms;
				PercentualFundoCombatePobreza = _cfop.PercentualFundoCombatePobreza;
				PercentualFundoCombatePobrezaST = _cfop.PercentualFundoCombatePobrezaST;
				if (TipoIncidenciaIcms == "201" || TipoIncidenciaIcms == "202" || TipoIncidenciaIcms == "10" || TipoIncidenciaIcms == "70")
				{
					CodigoModalidadeICMSST = _cfop.CodigoModalidadeICMSST;
					NotaFiscalCest notaFiscalCest = ModuloNotaFiscal.ObterNotaFiscalCest(Cest, CodigoClassificacaoFiscal, CodigoEstadoDestinatario);
					PercentualReducaoBaseCalculoICMSST = _cfop.PercentualReducaoBaseCalculoICMSST;
					PercentualIcmsStCargaMedia = _cfop.PercentualIcmsStCargaMedia;
					if (_cfop.IsUsarTabelaCest && notaFiscalCest != null)
					{
						PercentualBaseAgragadaICMSST = notaFiscalCest.ValorMva;
						PercentualICMSSTAgregado = notaFiscalCest.PercentualIcmsSt;
						PercentualReducaoBaseCalculoICMSST = notaFiscalCest.PercentualReducaoBaseCalculoICMSST;
					}
					else
					{
						PercentualBaseAgragadaICMSST = _cfop.PercentualBaseAgragadaICMSST;
						PercentualICMSSTAgregado = _cfop.PercentualICMSST;
						PercentualReducaoBaseCalculoICMSST = _cfop.PercentualReducaoBaseCalculoICMSST;
					}
				}
				IsICMSInterestadual = _cfop.IsICMSInterestadual;
				PercentualIcmsInterestadualFundoPobreza = _cfop.PercentualIcmsInterestadualFundoPobreza;
				PercentualIcmsInterestadualUfDestino = _cfop.PercentualIcmsInterestadualUfDestino;
				PercentualIcmsInterestadualUfEnvolvidas = _cfop.PercentualIcmsInterestadualUfEnvolvidas;
			}
			else
			{
				CodigoModalidadeIcms = string.Empty;
				AliquotaICMS = 0m;
				AliquotaIPI = 0m;
				AliquotaCofins = 0m;
				AliquotaPis = 0m;
				PercentualBaseReducaoIcms = 0m;
				CodigoOrigemProduto = string.Empty;
				TipoIncidenciaIcms = string.Empty;
				TipoIncidenciaIpi = string.Empty;
				TipoIncidenciaPis = string.Empty;
				TipoIncidenciaCofins = string.Empty;
				PercentualRetencaoPis = 0m;
				PercentualRetencaoCofins = 0m;
				IsCsll = false;
				PercentualCsll = 0m;
				IsConsumidorFinal = false;
				IsGeraDuplicata = false;
				NomeCfop = MetodosUteis.LimpaNro(_cfop.NumeracaoCFOP);
				CodigoCFOPInterna = 0;
			}
		}
	}

	public NotaFiscalNotasFiscais NotaFiscalRef
	{
		get
		{
			if (_nf == null)
			{
				_nf = ModuloNotaFiscal.ObterNotaFiscalNotasFiscais(CodigoEmpresa, CodigoNotaFiscal, CodigoSerieNotaFiscal);
			}
			return _nf;
		}
	}

	public EstoqueConsignado EstoqueConsignadoRef
	{
		get
		{
			return _consignado;
		}
		set
		{
			if (_consignado != value)
			{
				_consignado = value;
			}
		}
	}

	public EstoqueConsignadoLote EstoqueConsignadoLoteRef
	{
		get
		{
			return _consignadoLote;
		}
		set
		{
			if (_consignadoLote != value)
			{
				_consignadoLote = value;
			}
		}
	}

	public EstoqueConsignadoMovimento ConsignadoMovimentoRef
	{
		get
		{
			return _consignadoMovimento;
		}
		set
		{
			if (_consignadoMovimento != value)
			{
				_consignadoMovimento = value;
			}
		}
	}

	public PedidoVendaItemGPS PedidoVendaItemGPSRef
	{
		get
		{
			if (_pedidoVendaItemGPS == null && _dados.codigoPedidoVenda > 0 && _dados.codigoPedidoVendaItem > 0)
			{
				_pedidoVendaItemGPS = ModuloVendasGPS.ObterPedidoVendaItem(_dados.codigoPedidoVenda, _dados.codigoPedidoVendaItem);
			}
			return _pedidoVendaItemGPS;
		}
	}

	public PedidoVendaGPS PedidoVendaGPSRef
	{
		get
		{
			if (_pedidoVendaGPS == null && _dados.codigoPedidoVenda > 0)
			{
				_pedidoVendaGPS = ModuloVendasGPS.ObterPedidoVenda(_dados.codigoPedidoVenda);
			}
			return _pedidoVendaGPS;
		}
	}

	public NotaFiscalNotasFiscaisItensDI NotaFiscalItensDIRef
	{
		get
		{
			if (_notaFiscalNotasFiscaisItensDI == null)
			{
				_notaFiscalNotasFiscaisItensDI = ModuloNotaFiscal.ObterNotaFiscalNotasFiscaisItensDI(CodigoEmpresa, CodigoSerieNotaFiscal, CodigoNotaFiscal, Ordem);
			}
			return _notaFiscalNotasFiscaisItensDI;
		}
		set
		{
			if (_notaFiscalNotasFiscaisItensDI != value)
			{
				_notaFiscalNotasFiscaisItensDI = value;
			}
		}
	}

	public decimal ValorUnitarioTributario
	{
		get
		{
			if (CoefienteValorTributario == 0m || CoefienteValorTributario == 1m)
			{
				return ValorUnitarioComImpostoImportacao;
			}
			return Math.Round(ValorUnitarioComImpostoImportacao / ((CoefienteValorTributario == 0m) ? 1m : CoefienteValorTributario), 6);
		}
	}

	public decimal QuantidadeTributario => Math.Round(Quantidade * CoefienteValorTributario, 3);

	public decimal? ValorUnitarioTributarioDanfe
	{
		get
		{
			if (CoefienteValorTributario == 0m || CoefienteValorTributario == 1m)
			{
				return null;
			}
			return ValorUnitarioTributario;
		}
	}

	public decimal? QuantidadeTributarioDanfe
	{
		get
		{
			if (QuantidadeTributario == Quantidade)
			{
				return null;
			}
			return QuantidadeTributario;
		}
	}

	public string SiglaFaturamentoTributarioDanfe
	{
		get
		{
			if (SiglaFaturamentoTributario.ToUpper().Equals(SiglaUnidadeFaturamento.ToUpper()))
			{
				return string.Empty;
			}
			return SiglaFaturamentoTributario;
		}
	}

	public string SiglaUnidadeFaturamento
	{
		get
		{
			return _dados.siglaUnidadeFaturamento;
		}
		set
		{
			if (_dados.siglaUnidadeFaturamento != value)
			{
				_dados.siglaUnidadeFaturamento = value;
				if (_dados.siglaUnidadeFaturamento.Length > 2)
				{
					_dados.siglaUnidadeFaturamento = value.Substring(0, 2);
				}
				PropertyHasChanged();
			}
		}
	}

	public string CodigoSituacaoTributaria
	{
		get
		{
			return $"{CodigoOrigemProduto}{TipoIncidenciaIcms}";
		}
		set
		{
			if (_dados.codigoSituacaoTributaria.ToString() != value)
			{
				_dados.codigoSituacaoTributaria = ((!string.IsNullOrWhiteSpace(value)) ? int.Parse(value) : 0);
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoComplementar
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(CodigoPedidoCompraCliente))
			{
				int result = 0;
				int.TryParse(MetodosUteis.LimpaNro(CodigoPedidoCompraCliente), out result);
				if (result > 0)
				{
					string text = $" Pedido: {CodigoPedidoCompraCliente}/{CodigoPedidoCompraItemCliente}";
					if (_dados.descricaoComplementar == null)
					{
						_dados.descricaoComplementar = string.Empty;
						_dados.descricaoComplementar += text.Trim();
					}
				}
			}
			return _dados.descricaoComplementar;
		}
		set
		{
			if (_dados.descricaoComplementar != value)
			{
				_dados.descricaoComplementar = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseCalculoTotalST
	{
		get
		{
			return ValorBaseICMS + ValorBaseAgragadaICMSST;
		}
		set
		{
			ValorBaseICMS = value;
		}
	}

	public decimal ValorICMSTotal
	{
		get
		{
			return ValorICMS + ValorICMSSTAgregado;
		}
		set
		{
			ValorICMS = value;
		}
	}

	public decimal ValorLiquido
	{
		get
		{
			decimal num = default(decimal);
			if (NomeCfop.StartsWith("3"))
			{
				return ValorTotal + ValorFrete + ValorSeguro + ValorImpostoImportacao + ValorSiscomex + ValorMarinhaMercante;
			}
			return ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorPIS - ValorCofins - ValorICMS;
		}
	}

	public decimal ValorLiquidoUnitario => ValorLiquido / ((Quantidade == 0m) ? 1m : Quantidade);

	public ChaveEstoque ChaveEstoqueRef
	{
		get
		{
			_chaveEstoque.codigoEntidade = CodigoClienteEntidadeGPS;
			_chaveEstoque.codigoProduto = CodigoProdutoGPS;
			_chaveEstoque.dimensao01 = ValorDimensao01GPS;
			_chaveEstoque.dimensao02 = ValorDimensao02GPS;
			_chaveEstoque.dimensao03 = ValorDimensao03GPS;
			_chaveEstoque.tipoEstoque = CodigoGrupoEstoqueGPS;
			_chaveEstoque.tipoProduto = CodigoTipoProdutoGPS;
			return _chaveEstoque;
		}
		set
		{
			if (!_chaveEstoque.Equals(value))
			{
				CodigoClienteEntidadeGPS = value.codigoEntidade;
				CodigoProdutoGPS = value.codigoProduto;
				ValorDimensao01GPS = value.dimensao01;
				ValorDimensao02GPS = value.dimensao02;
				ValorDimensao03GPS = value.dimensao03;
				CodigoGrupoEstoqueGPS = value.tipoEstoque;
				CodigoTipoProdutoGPS = value.tipoProduto;
			}
		}
	}

	public decimal ValorTotalIPI => ValorTotalComImpostoImportacao + ValorFrete + ValorSeguro + ValorOutros + ValorIPI;

	public decimal ValorFreteSeguroOutros => ValorFrete + ValorSeguro + ValorOutros;

	public decimal ValorTotalFreteSeguroOutros => ValorTotalComImpostoImportacao + ValorFreteSeguroOutros;

	public decimal ValorTotalFreteSeguroOutrosDesconto => ValorTotalFreteSeguroOutros - ValorDesconto;

	public decimal ValorUnitarioComImpostoImportacao
	{
		get
		{
			if (PercentualII > 0m)
			{
				return ValorTotalComImpostoImportacao / ((Quantidade == 0m) ? 1m : Quantidade);
			}
			return ValorUnitario;
		}
	}

	public decimal ValorTotalComImpostoImportacao => ValorTotal + ValorImpostoImportacao;

	public string StatusNota
	{
		get
		{
			string result = string.Empty;
			if (NotaFiscalRef != null)
			{
				result = NotaFiscalRef.SituacaoNfe;
			}
			return result;
		}
	}

	public string Destinatario
	{
		get
		{
			string result = string.Empty;
			if (NotaFiscalRef != null)
			{
				result = NotaFiscalRef.CodigoEntidade + " - " + NotaFiscalRef.RazaoSocialDestinatario;
			}
			return result;
		}
	}

	public DateTime DataSefaz
	{
		get
		{
			DateTime result = default(DateTime);
			if (NotaFiscalRef != null)
			{
				return NotaFiscalRef.DataEnvioNFE;
			}
			return result;
		}
	}

	public int CodigoEstadoDestinatario { get; set; }

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalNotasFiscaisItens);
		_cfop = null;
		_consignado = null;
		_consignadoLote = null;
		_nf = null;
		_consignadoMovimento = null;
		_fichaExpedicaoItem = null;
		IsProduzidoEscalaRelevante = true;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalNotasFiscaisItens()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalNotasFiscaisItens(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	private void AjustarCest()
	{
		if (TipoIncidenciaIcms == "201" || TipoIncidenciaIcms == "202" || TipoIncidenciaIcms == "10" || TipoIncidenciaIcms == "70")
		{
			NotaFiscalCest notaFiscalCest = ModuloNotaFiscal.ObterNotaFiscalCest(Cest, CodigoClassificacaoFiscal, CodigoEstadoDestinatario);
			if (_cfop.IsUsarTabelaCest && notaFiscalCest != null)
			{
				PercentualBaseAgragadaICMSST = notaFiscalCest.ValorMva;
				PercentualICMSSTAgregado = notaFiscalCest.PercentualIcmsSt;
				PercentualReducaoBaseCalculoICMSST = notaFiscalCest.PercentualReducaoBaseCalculoICMSST;
			}
		}
	}

	public void NegativarValores()
	{
		ValorUnitario = -1m * ValorUnitario;
		ValorSeguro = -1m * ValorSeguro;
		ValorFrete = -1m * ValorFrete;
		ValorOutros = -1m * ValorOutros;
		ValorBaseCalculoPis = -1m * ValorBaseCalculoPis;
		ValorBaseAgragadaICMSST = -1m * ValorBaseAgragadaICMSST;
		ValorBaseCalculoCofins = -1m * ValorBaseCalculoCofins;
		ValorBaseCalculoImpostoImportacao = -1m * ValorBaseCalculoImpostoImportacao;
		ValorBaseCalculoIpi = -1m * ValorBaseCalculoIpi;
		ValorBaseCalculoTotalST = -1m * ValorBaseCalculoTotalST;
		ValorBaseICMS = -1m * ValorBaseICMS;
		ValorBaseReducaoSemFrete = -1m * ValorBaseReducaoSemFrete;
		CalcularImposto(EnumFinalidadeNotaFiscal.Devolução);
		ValorFatura = ValorTotal - ValorRetencaoPis - ValorRetencaoCofins + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto - ValorIcmsDesonerado;
	}

	public void CalcularImposto(EnumFinalidadeNotaFiscal finalidadeNota)
	{
		if (finalidadeNota == EnumFinalidadeNotaFiscal.Complementar || NomeCfop == "1604")
		{
			return;
		}
		ValorTotal = Math.Round(ValorUnitario * Quantidade, 2);
		ValorFatura = 0m;
		valorTotalImportacao = default(decimal);
		ValorCreditoIcms = 0m;
		ValorBaseICMS = 0m;
		ValorICMS = 0m;
		ValorBaseAgragadaICMSST = 0m;
		ValorICMSSTAgregado = 0m;
		ValorIcmsInterestadualFundoPobreza = 0m;
		ValorIcmsInterestadualUfDestino = 0m;
		ValorIcmsInterestadualUfEnvolvidas = 0m;
		ValorBaseReducaoSemFrete = 0m;
		ValorCsll = 0m;
		ValorFundoCombatePobreza = 0m;
		ValorFundoCombatePobrezaST = 0m;
		ValorBaseCalculoIpi = 0m;
		ValorIPI = 0m;
		ValorBaseCalculoPis = 0m;
		ValorPIS = 0m;
		ValorRetencaoPis = 0m;
		ValorBaseCalculoCofins = 0m;
		ValorCofins = 0m;
		ValorRetencaoCofins = 0m;
		ValorBaseCalculoImpostoImportacao = 0m;
		ValorImpostoImportacao = 0m;
		bool flag = false;
		CodigoSituacaoTributaria = $"{CodigoOrigemProduto}{TipoIncidenciaIcms}";
		if (finalidadeNota != EnumFinalidadeNotaFiscal.Normal && finalidadeNota != EnumFinalidadeNotaFiscal.Devolução)
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(NomeCfop) && NomeCfop.Substring(0, 1) == "3")
		{
			flag = true;
			valorTotalImportacao = Math.Round(ValorTotal + ValorSeguro + ValorFrete - ValorDesconto, 2);
			if (PercentualII > 0m)
			{
				ValorBaseCalculoImpostoImportacao = valorTotalImportacao;
				ValorImpostoImportacao = Math.Round(ValorBaseCalculoImpostoImportacao * PercentualII / 100m, 2);
			}
		}
		if (flag)
		{
			ValorBaseCalculoPis = valorTotalImportacao;
			ValorPIS = Math.Round(ValorBaseCalculoPis * (AliquotaPis / 100.0m), 2);
		}
		else if (!string.IsNullOrWhiteSpace(TipoIncidenciaPis))
		{
			if (ValorBaseCalculoPis == 0m && AliquotaPis > 0m)
			{
				ValorBaseCalculoPis = ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto;
			}
			else if (AliquotaPis == 0m)
			{
				ValorBaseCalculoPis = 0m;
			}
			ValorRetencaoPis = Math.Round(ValorBaseCalculoPis * (PercentualRetencaoPis / 100.0m), 2);
			ValorPIS = Math.Round(ValorBaseCalculoPis * (AliquotaPis / 100.0m), 2);
		}
		if (flag)
		{
			ValorBaseCalculoCofins = valorTotalImportacao;
			ValorCofins = Math.Round(ValorBaseCalculoCofins * (AliquotaCofins / 100.0m), 2);
		}
		else if (!string.IsNullOrWhiteSpace(TipoIncidenciaCofins))
		{
			if (ValorBaseCalculoCofins == 0m && AliquotaCofins > 0m)
			{
				ValorBaseCalculoCofins = ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto;
			}
			else if (AliquotaCofins == 0m)
			{
				ValorBaseCalculoCofins = 0m;
			}
			ValorRetencaoCofins = Math.Round(ValorBaseCalculoCofins * (PercentualRetencaoCofins / 100.0m), 2);
			ValorCofins = Math.Round(ValorBaseCalculoCofins * (AliquotaCofins / 100.0m), 2);
		}
		if (flag)
		{
			ValorBaseCalculoIpi = valorTotalImportacao + ValorImpostoImportacao;
		}
		else if (ValorBaseCalculoIpi == 0m && AliquotaIPI > 0m)
		{
			ValorBaseCalculoIpi = ValorTotal + ValorFreteSeguroOutros - ValorDesconto;
		}
		ValorIPI = Math.Round(AliquotaIPI / 100.0m * ValorBaseCalculoIpi, 2);
		if (flag && TipoIncidenciaIcms != "41")
		{
			decimal num = (100m - AliquotaICMS) / 100m;
			ValorBaseICMS = Math.Round((valorTotalImportacao + ValorImpostoImportacao + ValorPIS + ValorCofins + ValorIPI + ValorSiscomex + ValorMarinhaMercante - ValorDesconto) / ((num == 0m) ? 1m : num) * (PercentualBaseReducaoIcms / 100.0m), 2);
		}
		else if (!string.IsNullOrWhiteSpace(TipoIncidenciaIcms) && (TipoIncidenciaIcms == "30" || TipoIncidenciaIcms == "40" || TipoIncidenciaIcms == "41"))
		{
			ValorBaseICMS = 0m;
			AliquotaICMS = 0m;
		}
		else if (!string.IsNullOrWhiteSpace(TipoIncidenciaIcms) && (TipoIncidenciaIcms == "10" || TipoIncidenciaIcms == "70" || TipoIncidenciaIcms == "201" || TipoIncidenciaIcms == "202"))
		{
			if (PercentualBaseReducaoIcms > 0m && PercentualBaseReducaoIcms < 100m)
			{
				ValorBaseICMS = (ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto) * (PercentualBaseReducaoIcms / 100.0m);
			}
			else if (ValorBaseICMS == 0m && !IsConsumidorFinal)
			{
				ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto;
			}
			else if (ValorBaseICMS == 0m && IsConsumidorFinal)
			{
				ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI - ValorDesconto;
			}
			if (AliquotaICMS == 0m)
			{
				ValorBaseICMS = 0m;
			}
			decimal num2 = ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI;
			ValorICMS = Math.Round(ValorBaseICMS * AliquotaICMS / 100.0m, 2);
			if (PercentualIcmsStCargaMedia == 0m)
			{
				ValorBaseAgragadaICMSST = num2 + num2 * PercentualBaseAgragadaICMSST / 100.0m;
				ValorBaseAgragadaICMSST = ValorBaseAgragadaICMSST * ((PercentualReducaoBaseCalculoICMSST == 0m) ? 100m : PercentualReducaoBaseCalculoICMSST) / 100m;
				ValorICMSSTAgregado = Math.Round(ValorBaseAgragadaICMSST * PercentualICMSSTAgregado / 100.0m - ValorICMS, 2);
				if (PercentualICMSSTAgregado == 0m)
				{
					ValorICMSSTAgregado = 0m;
					ValorBaseAgragadaICMSST = 0m;
				}
			}
			else
			{
				ValorICMSSTAgregado = Math.Round(num2 * PercentualIcmsStCargaMedia / 100m, 2);
				ValorBaseAgragadaICMSST = Math.Round((ValorICMS + ValorICMSSTAgregado) / ((PercentualICMSSTAgregado / 100.0m == 0m) ? 1m : (PercentualICMSSTAgregado / 100.0m)), 2);
			}
		}
		else
		{
			if (IsConsumidorFinal)
			{
				if (PercentualBaseReducaoIcms > 0m && PercentualBaseReducaoIcms < 100m)
				{
					ValorBaseICMS = (ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI - ValorDesconto) * (PercentualBaseReducaoIcms / 100.0m);
				}
				else
				{
					ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI - ValorDesconto;
				}
			}
			else if (PercentualBaseReducaoIcms > 0m && PercentualBaseReducaoIcms < 100m)
			{
				ValorBaseICMS = (ValorTotal + ValorFrete + ValorSeguro + ValorOutros + ValorIPI - ValorDesconto) * (PercentualBaseReducaoIcms / 100.0m);
			}
			else
			{
				ValorBaseICMS = ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto;
			}
			if (AliquotaICMS == 0m)
			{
				ValorBaseICMS = 0m;
			}
		}
		if (PercentualCreditoIcms > 0m)
		{
			if (ValorBaseICMS == 0m)
			{
				ValorCreditoIcms = (ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto) * (PercentualBaseReducaoIcms / 100.0m) * (PercentualCreditoIcms / 100m);
			}
			else
			{
				ValorCreditoIcms = ValorBaseICMS * (PercentualCreditoIcms / 100m);
			}
		}
		if (PercentualFundoCombatePobreza > 0m)
		{
			ValorBaseCalculoFundoCombatePobreza = ValorBaseICMS;
			ValorFundoCombatePobreza = Math.Round(ValorBaseCalculoFundoCombatePobreza * PercentualFundoCombatePobreza / 100m, 2);
		}
		else
		{
			ValorBaseCalculoFundoCombatePobreza = 0m;
			ValorFundoCombatePobreza = 0m;
		}
		if (PercentualFundoCombatePobrezaST > 0m)
		{
			ValorBaseCalculoFundoCombatePobrezaST = ValorBaseAgragadaICMSST;
			ValorFundoCombatePobrezaST = Math.Round(ValorBaseCalculoFundoCombatePobrezaST * PercentualFundoCombatePobrezaST / 100m, 2);
		}
		else
		{
			ValorBaseCalculoFundoCombatePobrezaST = 0m;
			ValorFundoCombatePobrezaST = 0m;
		}
		if (IsICMSInterestadual)
		{
			ValorIcmsInterestadualFundoPobreza = ValorBaseICMS * PercentualIcmsInterestadualFundoPobreza / 100m;
			if (DateTime.Today.Year == 2016)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * 0.4m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = ValorBaseICMS * 0.6m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
			}
			else if (DateTime.Today.Year == 2017)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * 0.6m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = ValorBaseICMS * 0.4m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
			}
			else if (DateTime.Today.Year == 2018)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * 0.8m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = ValorBaseICMS * 0.2m * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
			}
			else if (DateTime.Today.Year >= 2019)
			{
				ValorIcmsInterestadualUfDestino = ValorBaseICMS * (PercentualIcmsInterestadualUfDestino - PercentualIcmsInterestadualUfEnvolvidas) / 100m;
				ValorIcmsInterestadualUfEnvolvidas = 0m;
			}
		}
		ValorBaseReducaoSemFrete = ValorBaseICMS - ValorFrete;
		ValorICMS = Math.Round(ValorBaseICMS * AliquotaICMS / 100.0m, 2);
		if (!flag && _basePisCofinsSemICMS && ValorICMS > 0m)
		{
			if (!string.IsNullOrWhiteSpace(TipoIncidenciaPis))
			{
				if (AliquotaPis > 0m)
				{
					ValorBaseCalculoPis = ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto - ValorICMS;
				}
				else
				{
					ValorBaseCalculoPis = 0m;
				}
				ValorRetencaoPis = Math.Round(ValorBaseCalculoPis * (PercentualRetencaoPis / 100.0m), 2);
				ValorPIS = Math.Round(ValorBaseCalculoPis * (AliquotaPis / 100.0m), 2);
			}
			if (!string.IsNullOrWhiteSpace(TipoIncidenciaCofins))
			{
				if (AliquotaCofins > 0m)
				{
					ValorBaseCalculoCofins = ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto - ValorICMS;
				}
				else
				{
					ValorBaseCalculoCofins = 0m;
				}
				ValorRetencaoCofins = Math.Round(ValorBaseCalculoCofins * (PercentualRetencaoCofins / 100.0m), 2);
				ValorCofins = Math.Round(ValorBaseCalculoCofins * (AliquotaCofins / 100.0m), 2);
			}
		}
		if (IsCsll)
		{
			ValorCsll = Math.Round((ValorTotal + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto) * PercentualCsll / 100.0m, 2);
		}
		if (IsGeraDuplicata)
		{
			ValorFatura = ValorTotal - ValorRetencaoPis - ValorRetencaoCofins + ValorFrete + ValorSeguro + ValorOutros - ValorDesconto - ValorIcmsDesonerado;
		}
	}

	private bool _validacaoCest()
	{
		bool result = true;
		if (!string.IsNullOrWhiteSpace(_dados.cest) && GerarXML2.LimpaNro(_dados.cest).Length != 7)
		{
			result = false;
		}
		return result;
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalNotasFiscaisItens)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}

	protected override List<Regra> CriarRegras()
	{
		List<Regra> list = base.CriarRegras();
		list.Add(new RegraSimples("Cest", "O código Cest possui 7 numeros", () => _validacaoCest()));
		list.Add(new RegraSimples("CodigoProduto", "O Código do Produto não pode ser em branco", () => !string.IsNullOrWhiteSpace(CodigoProduto)));
		return list;
	}
}
