using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalCFOPs : BusinessObjectBase
{
	private MapTableNotaFiscalCFOPs _dados;

	private NotaFiscalTextosLegais _texto01;

	private NotaFiscalTextosLegais _texto02;

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

	public string NumeracaoCFOP
	{
		get
		{
			return _dados.numeracaoCFOP;
		}
		set
		{
			if (_dados.numeracaoCFOP != value)
			{
				_dados.numeracaoCFOP = value;
				PropertyHasChanged();
			}
		}
	}

	public string SeqCFOP
	{
		get
		{
			return _dados.seqCFOP;
		}
		set
		{
			if (_dados.seqCFOP != value)
			{
				_dados.seqCFOP = value;
				PropertyHasChanged();
			}
		}
	}

	public string ExibirComo
	{
		get
		{
			return _dados.exibirComo;
		}
		set
		{
			if (_dados.exibirComo != value)
			{
				_dados.exibirComo = value;
				PropertyHasChanged();
			}
		}
	}

	public string Nfe
	{
		get
		{
			return _dados.nfe;
		}
		set
		{
			if (_dados.nfe != value)
			{
				_dados.nfe = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsEntrada
	{
		get
		{
			return _dados.isEntrada;
		}
		set
		{
			if (_dados.isEntrada != value)
			{
				_dados.isEntrada = value;
				PropertyHasChanged();
			}
		}
	}

	public int IncideICMS
	{
		get
		{
			return _dados.incideICMS;
		}
		set
		{
			if (_dados.incideICMS != value)
			{
				_dados.incideICMS = value;
				PropertyHasChanged();
			}
		}
	}

	public int RetemICMS
	{
		get
		{
			return _dados.retemICMS;
		}
		set
		{
			if (_dados.retemICMS != value)
			{
				_dados.retemICMS = value;
				PropertyHasChanged();
			}
		}
	}

	public int ModalidadeICMS
	{
		get
		{
			return _dados.modalidadeICMS;
		}
		set
		{
			if (_dados.modalidadeICMS != value)
			{
				_dados.modalidadeICMS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PadraoICMS
	{
		get
		{
			return _dados.padraoICMS;
		}
		set
		{
			if (_dados.padraoICMS != value)
			{
				_dados.padraoICMS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ReducaoICMS
	{
		get
		{
			return _dados.reducaoICMS;
		}
		set
		{
			if (_dados.reducaoICMS != value)
			{
				_dados.reducaoICMS = value;
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

	public int IncideIPI
	{
		get
		{
			return _dados.incideIPI;
		}
		set
		{
			if (_dados.incideIPI != value)
			{
				_dados.incideIPI = value;
				PropertyHasChanged();
			}
		}
	}

	public int RetemIPI
	{
		get
		{
			return _dados.retemIPI;
		}
		set
		{
			if (_dados.retemIPI != value)
			{
				_dados.retemIPI = value;
				PropertyHasChanged();
			}
		}
	}

	public int ModalidadeIPI
	{
		get
		{
			return _dados.modalidadeIPI;
		}
		set
		{
			if (_dados.modalidadeIPI != value)
			{
				_dados.modalidadeIPI = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PadraoIPI
	{
		get
		{
			return _dados.padraoIPI;
		}
		set
		{
			if (_dados.padraoIPI != value)
			{
				_dados.padraoIPI = value;
				PropertyHasChanged();
			}
		}
	}

	public int IncidePIS
	{
		get
		{
			return _dados.incidePIS;
		}
		set
		{
			if (_dados.incidePIS != value)
			{
				_dados.incidePIS = value;
				PropertyHasChanged();
			}
		}
	}

	public int RetemPIS
	{
		get
		{
			return _dados.retemPIS;
		}
		set
		{
			if (_dados.retemPIS != value)
			{
				_dados.retemPIS = value;
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

	public int ModalidadePIS
	{
		get
		{
			return _dados.modalidadePIS;
		}
		set
		{
			if (_dados.modalidadePIS != value)
			{
				_dados.modalidadePIS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PadraoPIS
	{
		get
		{
			return _dados.padraoPIS;
		}
		set
		{
			if (_dados.padraoPIS != value)
			{
				_dados.padraoPIS = value;
				PropertyHasChanged();
			}
		}
	}

	public int IncideCofins
	{
		get
		{
			return _dados.incideCofins;
		}
		set
		{
			if (_dados.incideCofins != value)
			{
				_dados.incideCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public int RetemCofins
	{
		get
		{
			return _dados.retemCofins;
		}
		set
		{
			if (_dados.retemCofins != value)
			{
				_dados.retemCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public int ModalidadeCofins
	{
		get
		{
			return _dados.modalidadeCofins;
		}
		set
		{
			if (_dados.modalidadeCofins != value)
			{
				_dados.modalidadeCofins = value;
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
			if (_dados.valorCofins != value)
			{
				_dados.valorCofins = value;
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

	public bool IsCSLL
	{
		get
		{
			return _dados.isCSLL;
		}
		set
		{
			if (_dados.isCSLL != value)
			{
				_dados.isCSLL = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCSLL
	{
		get
		{
			return _dados.valorCSLL;
		}
		set
		{
			if (_dados.valorCSLL != value)
			{
				_dados.valorCSLL = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsIR
	{
		get
		{
			return _dados.isIR;
		}
		set
		{
			if (_dados.isIR != value)
			{
				_dados.isIR = value;
				PropertyHasChanged();
			}
		}
	}

	public int ModalidadeIR
	{
		get
		{
			return _dados.modalidadeIR;
		}
		set
		{
			if (_dados.modalidadeIR != value)
			{
				_dados.modalidadeIR = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIR
	{
		get
		{
			return _dados.valorIR;
		}
		set
		{
			if (_dados.valorIR != value)
			{
				_dados.valorIR = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsISSQN
	{
		get
		{
			return _dados.isISSQN;
		}
		set
		{
			if (_dados.isISSQN != value)
			{
				_dados.isISSQN = value;
				PropertyHasChanged();
			}
		}
	}

	public int ModalidadeISSQN
	{
		get
		{
			return _dados.modalidadeISSQN;
		}
		set
		{
			if (_dados.modalidadeISSQN != value)
			{
				_dados.modalidadeISSQN = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorISS
	{
		get
		{
			return _dados.valorISS;
		}
		set
		{
			if (_dados.valorISS != value)
			{
				_dados.valorISS = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsINSS
	{
		get
		{
			return _dados.isINSS;
		}
		set
		{
			if (_dados.isINSS != value)
			{
				_dados.isINSS = value;
				PropertyHasChanged();
			}
		}
	}

	public int ModalidadeINSS
	{
		get
		{
			return _dados.modalidadeINSS;
		}
		set
		{
			if (_dados.modalidadeINSS != value)
			{
				_dados.modalidadeINSS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorINSS
	{
		get
		{
			return _dados.valorINSS;
		}
		set
		{
			if (_dados.valorINSS != value)
			{
				_dados.valorINSS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercINSS
	{
		get
		{
			return _dados.percINSS;
		}
		set
		{
			if (_dados.percINSS != value)
			{
				_dados.percINSS = value;
				PropertyHasChanged();
			}
		}
	}

	public int OrigemProduto
	{
		get
		{
			return _dados.origemProduto;
		}
		set
		{
			if (_dados.origemProduto != value)
			{
				_dados.origemProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CfopAssociado
	{
		get
		{
			return _dados.cfopAssociado;
		}
		set
		{
			if (_dados.cfopAssociado != value)
			{
				_dados.cfopAssociado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTexto1
	{
		get
		{
			return _dados.codigoTexto1;
		}
		set
		{
			if (_dados.codigoTexto1 != value)
			{
				_dados.codigoTexto1 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTexto2
	{
		get
		{
			return _dados.codigoTexto2;
		}
		set
		{
			if (_dados.codigoTexto2 != value)
			{
				_dados.codigoTexto2 = value;
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

	public bool IsAtivo
	{
		get
		{
			return _dados.isAtivo;
		}
		set
		{
			if (_dados.isAtivo != value)
			{
				_dados.isAtivo = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsEnviaConsignado
	{
		get
		{
			return _dados.isEnviaConsignado;
		}
		set
		{
			if (_dados.isEnviaConsignado != value)
			{
				_dados.isEnviaConsignado = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsFaturaConsignado
	{
		get
		{
			return _dados.isFaturaConsignado;
		}
		set
		{
			if (_dados.isFaturaConsignado != value)
			{
				_dados.isFaturaConsignado = value;
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

	public bool UsarIpiTabelaProduto
	{
		get
		{
			return _dados.usarIpiTabelaProduto;
		}
		set
		{
			if (_dados.usarIpiTabelaProduto != value)
			{
				_dados.usarIpiTabelaProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public bool UsarIcmsEstadoFederacao
	{
		get
		{
			return _dados.usarIcmsEstadoFederacao;
		}
		set
		{
			if (_dados.usarIcmsEstadoFederacao != value)
			{
				_dados.usarIcmsEstadoFederacao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualICMSST
	{
		get
		{
			return _dados.percentualICMSST;
		}
		set
		{
			if (_dados.percentualICMSST != value)
			{
				_dados.percentualICMSST = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualReducaoBaseAgregadaICMSST
	{
		get
		{
			return _dados.percentualReducaoBaseAgregadaICMSST;
		}
		set
		{
			if (_dados.percentualReducaoBaseAgregadaICMSST != value)
			{
				_dados.percentualReducaoBaseAgregadaICMSST = value;
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

	public bool IsDevolucaoMaterialCliente
	{
		get
		{
			return _dados.isDevolucaoMaterialCliente;
		}
		set
		{
			if (_dados.isDevolucaoMaterialCliente != value)
			{
				_dados.isDevolucaoMaterialCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsUsarTabelaCest
	{
		get
		{
			return _dados.isUsarTabelaCest;
		}
		set
		{
			if (_dados.isUsarTabelaCest != value)
			{
				_dados.isUsarTabelaCest = value;
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

	public bool IsPrefeitura
	{
		get
		{
			return _dados.isPrefeitura;
		}
		set
		{
			if (_dados.isPrefeitura != value)
			{
				_dados.isPrefeitura = value;
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

	public bool IsEntregaFutura
	{
		get
		{
			return _dados.isEntregaFutura;
		}
		set
		{
			if (_dados.isEntregaFutura != value)
			{
				_dados.isEntregaFutura = value;
				PropertyHasChanged("IsEntregaFutura");
			}
		}
	}

	public bool IsContaOrdem
	{
		get
		{
			return _dados.isContaOrdem;
		}
		set
		{
			if (_dados.isContaOrdem != value)
			{
				_dados.isContaOrdem = value;
				PropertyHasChanged("IsContaOrdem");
			}
		}
	}

	public bool IsSimplesRemessa
	{
		get
		{
			return _dados.isSimplesRemessa;
		}
		set
		{
			if (_dados.isSimplesRemessa != value)
			{
				_dados.isSimplesRemessa = value;
				PropertyHasChanged("IsSimplesRemessa");
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

	public NotaFiscalTextosLegais Texto01
	{
		get
		{
			if (_dados.codigoTexto1 > 0 && _texto01 == null)
			{
				_texto01 = ModuloNotaFiscal.ObterNotaFiscalTextosLegais(_dados.codigoTexto1);
			}
			return _texto01;
		}
	}

	public NotaFiscalTextosLegais Texto02
	{
		get
		{
			if (_dados.codigoTexto2 > 0 && _texto02 == null)
			{
				_texto02 = ModuloNotaFiscal.ObterNotaFiscalTextosLegais(_dados.codigoTexto2);
			}
			return _texto02;
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalCFOPs);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalCFOPs()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalCFOPs(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalCFOPs)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}

	protected override List<Regra> CriarRegras()
	{
		List<Regra> list = base.CriarRegras();
		list.Add(new RegraSimples("NumeracaoCFOP", "Favor escolher a CFOP.", () => !string.IsNullOrWhiteSpace(NumeracaoCFOP)));
		list.Add(new RegraSimples("SeqCFOP", "Favor definir um nome para essa CFOP.", () => !string.IsNullOrWhiteSpace(SeqCFOP)));
		list.Add(new RegraSimples("NumExibirComoeracaoCFOP", "Favor definir uma descrição para esta CFOP.", () => !string.IsNullOrWhiteSpace(ExibirComo)));
		list.Add(new RegraSimples("Nfe", "Favor definir a natureza de operação.", () => !string.IsNullOrWhiteSpace(Nfe)));
		list.Add(new RegraSimples("CodigoEnquadramentoIPI", "Favor definir o enquadramento de IPI.", () => CodigoEnquadramentoIPI > 0));
		list.Add(new RegraSimples("IncideICMS", "Favor definir a incidencia de ICMS.", () => IncideICMS > 0));
		list.Add(new RegraSimples("IncideIPI", "Favor definir a incidencia de IPI.", () => IncideIPI > 0));
		list.Add(new RegraSimples("IncidePIS", "Favor definir a incidencia de PIS.", () => IncidePIS > 0));
		list.Add(new RegraSimples("IncideCofins", "Favor definir a incidencia de COFINS.", () => IncideCofins > 0));
		return list;
	}
}
