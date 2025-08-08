using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalNotasFiscais
{
	public int id;

	public int codigoEmpresa;

	public int numeroNotaFiscal;

	public int codigoSerieNF;

	public string serieNotaFiscal;

	public int codigoCFOP;

	public string numeracaoCFOP;

	public string descricaoCFOP;

	public int codigoFichaExpedicao;

	public int codigoFormaPagto;

	public int codigoTransportadora;

	public int codigoEntidade;

	public bool isFretePagoPeloEmitente;

	public bool isNotaFiscalEntrada;

	public DateTime dataEmissao;

	public DateTime dataSaida;

	public DateTime dataEnvioNFE;

	public DateTime dataCancelamento;

	public DateTime dataCancelamentoNFE;

	public string motivoCancelamento;

	public int codigoEmissor;

	public int codigoResponsavelCancelamento;

	public int codigoResponsavelEnvioNfe;

	public decimal valorBaseICMS;

	public decimal valorICMS;

	public decimal valorBaseICMSSubstituto;

	public decimal valorICMSSubstituto;

	public decimal valorIPI;

	public decimal valorPIS;

	public decimal valorCSLL;

	public decimal valorProdutos;

	public decimal valorFrete;

	public decimal valorSeguro;

	public decimal valorOutrasDespesas;

	public decimal valorCofins;

	public decimal valorImpostoRetido;

	public decimal valorTotalNotaFiscal;

	public string chaveNfe;

	public string protocoloNfe;

	public string xmlNfe;

	public int codigoTextoLegal1;

	public int codigoTextoLegal2;

	public string razaoSocialDestinatario;

	public string cnpjDestinatario;

	public string situacaoNfe;

	public string codigoLote;

	public int tipoEmissao;

	public decimal valorPISRetido;

	public decimal valorCofinsRetido;

	public decimal valorTotalFatura;

	public int tipoEntidade;

	public decimal pesoBruto;

	public decimal pesoLiquido;

	public int qtVolumes;

	public string textoLegal;

	public int tipoNota;

	public string notaReferenciada;

	public bool isConsumidorFinal;

	public int codigoCondicaoPagamento;

	public decimal valorImpostoImportacao;

	public bool isFreteCliente;

	public decimal valorCambio;

	public string suframa;

	public string placaCaminhao;

	public int codigoTipoEntidadeEntrega;

	public int codigoEntidadeEntrega;

	public decimal valorTotalIcmsInterestadualFundoPobreza;

	public decimal valorTotalIcmsInterestadualUfDestino;

	public decimal valorTotalIcmsInterestadualUfEnvolvidas;

	public string portaoEntrega;

	public decimal valorCreditoIcms;

	public decimal percentualCreditoIcms;

	public decimal valorDesconto;

	public decimal valorIcmsDesonerado;

	public bool isBloquearRecalculoFatura;

	public int codigoEDI;

	public int codigoControleReajuste;

	public decimal valorBaseCalculoFundoCombatePobreza;

	public decimal valorBaseCalculoFundoCombatePobrezaST;

	public decimal valorFundoCombatePobreza;

	public decimal valorFundoCombatePobrezaST;

	public int codigoIndicadorPresenca;

	public int codigoModeloDocumentoFiscalReferenciado;

	public int codigoModalidadeFrete;

	public bool isComissaoApurada;

	public string tipoVolume;

	public int codigoContaContabil;
}
