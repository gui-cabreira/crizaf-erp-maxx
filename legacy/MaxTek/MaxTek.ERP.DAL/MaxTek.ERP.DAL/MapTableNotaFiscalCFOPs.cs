using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableNotaFiscalCFOPs
{
	public int id;

	public string numeracaoCFOP;

	public string seqCFOP;

	public string exibirComo;

	public string nfe;

	public bool isEntrada;

	public int incideICMS;

	public int retemICMS;

	public int modalidadeICMS;

	public decimal padraoICMS;

	public decimal reducaoICMS;

	public int codigoModalidadeICMSST;

	public decimal percentualBaseAgragadaICMSST;

	public int incideIPI;

	public int retemIPI;

	public int modalidadeIPI;

	public decimal padraoIPI;

	public int incidePIS;

	public int retemPIS;

	public decimal percentualRetencaoPis;

	public int modalidadePIS;

	public decimal padraoPIS;

	public int incideCofins;

	public int retemCofins;

	public decimal percentualRetencaoCofins;

	public int modalidadeCofins;

	public decimal valorCofins;

	public bool isCSLL;

	public decimal valorCSLL;

	public bool isIR;

	public int modalidadeIR;

	public decimal valorIR;

	public bool isISSQN;

	public int modalidadeISSQN;

	public decimal valorISS;

	public bool isINSS;

	public int modalidadeINSS;

	public decimal valorINSS;

	public decimal percINSS;

	public int origemProduto;

	public int cfopAssociado;

	public int codigoTexto1;

	public int codigoTexto2;

	public bool isGeraDuplicata;

	public bool isAtivo;

	public bool isEnviaConsignado;

	public bool isFaturaConsignado;

	public bool isConsumidorFinal;

	public bool usarIpiTabelaProduto;

	public bool usarIcmsEstadoFederacao;

	public decimal percentualICMSST;

	public decimal percentualReducaoBaseAgregadaICMSST;

	public int codigoEnquadramentoIPI;

	public decimal percentualII;

	public decimal percentualCreditoIcms;

	public bool isICMSInterestadual;

	public decimal percentualIcmsInterestadualFundoPobreza;

	public decimal percentualIcmsInterestadualUfDestino;

	public decimal percentualIcmsInterestadualUfEnvolvidas;

	public bool isDevolucaoMaterialCliente;

	public bool isUsarTabelaCest;

	public decimal percentualReducaoBaseCalculoICMSST;

	public bool isPrefeitura;

	public decimal percentualFundoCombatePobreza;

	public decimal percentualFundoCombatePobrezaST;

	public decimal percentualIcmsStCargaMedia;

	public bool isEntregaFutura;

	public bool isContaOrdem;

	public bool isSimplesRemessa;

	public int extipi;
}
