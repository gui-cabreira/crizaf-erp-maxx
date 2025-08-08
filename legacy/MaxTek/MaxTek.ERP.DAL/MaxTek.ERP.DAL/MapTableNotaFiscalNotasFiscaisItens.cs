using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalNotasFiscaisItens
{
	public int codigoEmpresa;

	public int codigoNotaFiscal;

	public int ordem;

	public string codigoProduto;

	public string descricaoProduto;

	public decimal quantidade;

	public decimal valorUnitario;

	public decimal valorTotal;

	public decimal valorBaseICMS;

	public decimal aliquotaICMS;

	public decimal valorICMS;

	public decimal aliquotaIPI;

	public decimal valorIPI;

	public decimal valorPIS;

	public decimal valorCofins;

	public decimal valorFrete;

	public decimal valorSeguro;

	public int codigoClassificacaoFiscal;

	public int codigoSituacaoTributaria;

	public string nomeCfop;

	public int codigoCFOPInterna;

	public int codigoFichaExpedicao;

	public int codigoFichaExpedicaoItem;

	public string siglaUnidadeFaturamento;

	public decimal valorFatura;

	public string codigoOrigemProduto;

	public decimal valorBaseReducaoSemFrete;

	public decimal percentualBaseReducaoIcms;

	public string codigoModalidadeIcms;

	public string tipoIncidenciaIcms;

	public string tipoIncidenciaIpi;

	public string tipoIncidenciaPis;

	public string tipoIncidenciaCofins;

	public decimal aliquotaPis;

	public decimal percentualRetencaoPis;

	public decimal valorRetencaoPis;

	public decimal aliquotaCofins;

	public decimal percentualRetencaoCofins;

	public decimal valorRetencaoCofins;

	public int codigoPedidoVenda;

	public int codigoPedidoVendaItem;

	public int codigoPedidoCompra;

	public int codigoPedidoCompraItem;

	public bool isCsll;

	public decimal percentualCsll;

	public decimal valorCsll;

	public bool isGeraDuplicata;

	public bool isConsumidorFinal;

	public int codigoSerieNotaFiscal;

	public int codigoAuxiliarAtualizacaoNotaFiscal;

	public string descricaoComplementar;

	public string contaContabilAnalitica;

	public string codigoPedidoCompraCliente;

	public int codigoPedidoCompraItemCliente;

	public int codigoGrupoEstoqueGPS;

	public string codigoProdutoGPS;

	public int codigoTipoProdutoGPS;

	public decimal valorDimensao01GPS;

	public decimal valorDimensao02GPS;

	public decimal valorDimensao03GPS;

	public int codigoClienteEntidadeGPS;

	public int codigoModalidadeICMSST;

	public decimal percentualBaseAgragadaICMSST;

	public decimal valorBaseAgragadaICMSST;

	public decimal valorICMSSTAgregado;

	public int codigoRecebimentoMaterialCliente;

	public decimal percentualICMSSTAgregado;

	public decimal valorBaseCalculoIpi;

	public decimal valorBaseCalculoPis;

	public decimal valorBaseCalculoCofins;

	public decimal valorBaseCalculoImpostoImportacao;

	public decimal valorOutros;

	public decimal valorDespesasAduaneiras;

	public decimal valorImpostoImportacao;

	public decimal valorIof;

	public string contratoCliente;

	public int contratoClienteItem;

	public int codigoEnquadramentoIPI;

	public string codigoEan;

	public decimal percentualII;

	public decimal valorSiscomex;

	public decimal valorMarinhaMercante;

	public int pecasPorEtiqueta;

	public decimal percentualCreditoIcms;

	public decimal valorCreditoIcms;

	public string cest;

	public bool isICMSInterestadual;

	public decimal percentualIcmsInterestadualFundoPobreza;

	public decimal valorIcmsInterestadualFundoPobreza;

	public decimal percentualIcmsInterestadualUfDestino;

	public decimal valorIcmsInterestadualUfDestino;

	public decimal percentualIcmsInterestadualUfEnvolvidas;

	public decimal valorIcmsInterestadualUfEnvolvidas;

	public string tagXml;

	public string codigoEmbalagem;

	public int quantidadeEmbalagem;

	public decimal pesoLiquido;

	public decimal pesoBruto;

	public decimal valorDesconto;

	public decimal valorIcmsDesonerado;

	public int motivoDesoneracaoIcms;

	public bool isFreteBaseCalculoIcms;

	public string codigoExterno;

	public decimal percentualReducaoBaseCalculoICMSST;

	public int codigoControleReajuste;

	public string codigoFCI;

	public decimal valorBaseCalculoFundoCombatePobreza;

	public decimal valorBaseCalculoFundoCombatePobrezaST;

	public decimal percentualFundoCombatePobreza;

	public decimal percentualFundoCombatePobrezaST;

	public decimal valorFundoCombatePobreza;

	public decimal valorFundoCombatePobrezaST;

	public bool isProduzidoEscalaRelevante;

	public string cnpjFabricante;

	public string codigoBenefícioFiscalUF;

	public decimal valorBaseCalculoIcmsStRetido;

	public decimal percentualSuportadoConsumidorFinal;

	public decimal valorIcmsSubstituto;

	public decimal valorIcmsStRetido;

	public decimal percentualIcmsStCargaMedia;

	public decimal quantidadeEmPecas;

	public string siglaFaturamentoTributario;

	public decimal coefienteValorTributario;

	public int extipi;
}
