using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using MaxTek.Core;
using MaxTek.ERP.DAL;
using MaxTek.GPS.BLL;
using MaxTek.MaxEditors.Windows.Forms;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalNotasFiscais : BusinessObjectBase
{
	private MapTableNotaFiscalNotasFiscais _dados;

	private IList<NotaFiscalNotasFiscaisItens> _itens;

	private IList<NotaFiscalFatura> _fatura;

	private IList<NotaFiscalNotaReferenciada> _notasReferenciadas;

	private EntidadeGPS _entidade;

	private Sociedade _emitente;

	private NotaFiscalCFOPs _cfop;

	private FichaExpedicao _fichaExpedicao;

	private EntidadeGPS _transportadora;

	private PedidoCompra _pedidoCompra;

	private NotaFiscalNotasFiscais _notaReferenciada;

	private CondicaoPagamentoGPS _condicaoPagamento;

	private IList<NotasFiscaisEventos> _eventos;

	private bool isImportacao = false;

	private EntidadeGPS _entidadeEntrega;

	private StructTipoCodigo _tipoCodigoCobranca;

	private IDictionary<int, EstoqueLoteMaterailClienteControle> _matsCli;

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
				_emitente = null;
			}
		}
	}

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

	public int TipoEmissao
	{
		get
		{
			return _dados.tipoEmissao;
		}
		set
		{
			if (_dados.tipoEmissao != value)
			{
				_dados.tipoEmissao = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroNotaFiscal
	{
		get
		{
			return _dados.numeroNotaFiscal;
		}
		set
		{
			if (_dados.numeroNotaFiscal == value)
			{
				return;
			}
			_dados.numeroNotaFiscal = value;
			PropertyHasChanged();
			if (FichaExpedicaoRef == null || FichaExpedicaoRef.CodigoNotaFiscal != 0)
			{
				return;
			}
			FichaExpedicaoRef.CodigoNotaFiscal = value;
			if (FichaExpedicaoRef.Itens == null)
			{
				return;
			}
			foreach (FichaExpedicaoItem iten in FichaExpedicaoRef.Itens)
			{
				iten.CodigoNotaFiscal = value;
			}
		}
	}

	public string SerieNotaFiscal
	{
		get
		{
			return _dados.serieNotaFiscal;
		}
		set
		{
			if (_dados.serieNotaFiscal != value)
			{
				_dados.serieNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCFOP
	{
		get
		{
			return _dados.codigoCFOP;
		}
		set
		{
			if (_dados.codigoCFOP != value)
			{
				_dados.codigoCFOP = value;
				PropertyHasChanged();
				if (CFOP == null || _dados.numeracaoCFOP != CFOP.NumeracaoCFOP)
				{
					CFOP = ModuloNotaFiscal.ObterNotaFiscalCFOPs(_dados.codigoCFOP);
				}
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
				if (value != 0)
				{
					AtualizaItens();
				}
			}
		}
	}

	public int CodigoPedidoCompra
	{
		get
		{
			return -CodigoFichaExpedicao;
		}
		set
		{
			CodigoFichaExpedicao = -value;
		}
	}

	public int CodigoFormaPagto
	{
		get
		{
			return _dados.codigoFormaPagto;
		}
		set
		{
			if (_dados.codigoFormaPagto != value)
			{
				_dados.codigoFormaPagto = value;
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

	public bool IsFretePagoPeloEmitente
	{
		get
		{
			return _dados.isFretePagoPeloEmitente;
		}
		set
		{
			if (_dados.isFretePagoPeloEmitente != value)
			{
				_dados.isFretePagoPeloEmitente = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsNotaFiscalEntrada
	{
		get
		{
			return _dados.isNotaFiscalEntrada;
		}
		set
		{
			if (_dados.isNotaFiscalEntrada != value)
			{
				_dados.isNotaFiscalEntrada = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataEmissao
	{
		get
		{
			return _dados.dataEmissao;
		}
		set
		{
			if (_dados.dataEmissao != value)
			{
				_dados.dataEmissao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataSaida
	{
		get
		{
			return _dados.dataSaida;
		}
		set
		{
			if (_dados.dataSaida != value)
			{
				_dados.dataSaida = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataEnvioNFE
	{
		get
		{
			return _dados.dataEnvioNFE;
		}
		set
		{
			if (_dados.dataEnvioNFE != value)
			{
				_dados.dataEnvioNFE = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataCancelamento
	{
		get
		{
			return _dados.dataCancelamento;
		}
		set
		{
			if (_dados.dataCancelamento != value)
			{
				_dados.dataCancelamento = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataCancelamentoNFE
	{
		get
		{
			return _dados.dataCancelamentoNFE;
		}
		set
		{
			if (_dados.dataCancelamentoNFE != value)
			{
				_dados.dataCancelamentoNFE = value;
				PropertyHasChanged();
			}
		}
	}

	public string MotivoCancelamento
	{
		get
		{
			return _dados.motivoCancelamento;
		}
		set
		{
			if (_dados.motivoCancelamento != value)
			{
				_dados.motivoCancelamento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEmissor
	{
		get
		{
			return _dados.codigoEmissor;
		}
		set
		{
			if (_dados.codigoEmissor != value)
			{
				_dados.codigoEmissor = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoResponsavelCancelamento
	{
		get
		{
			return _dados.codigoResponsavelCancelamento;
		}
		set
		{
			if (_dados.codigoResponsavelCancelamento != value)
			{
				_dados.codigoResponsavelCancelamento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoResponsavelEnvioNfe
	{
		get
		{
			return _dados.codigoResponsavelEnvioNfe;
		}
		set
		{
			if (_dados.codigoResponsavelEnvioNfe != value)
			{
				_dados.codigoResponsavelEnvioNfe = value;
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

	public decimal ValorPISRetido
	{
		get
		{
			return _dados.valorPISRetido;
		}
		set
		{
			if (_dados.valorPISRetido != Math.Round(value, 2))
			{
				_dados.valorPISRetido = Math.Round(value, 2);
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
			if (_dados.valorCSLL != Math.Round(value, 2))
			{
				_dados.valorCSLL = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorProdutos
	{
		get
		{
			return _dados.valorProdutos;
		}
		set
		{
			if (_dados.valorProdutos != Math.Round(value, 2))
			{
				_dados.valorProdutos = Math.Round(value, 2);
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

	public decimal ValorOutrasDespesas
	{
		get
		{
			return _dados.valorOutrasDespesas;
		}
		set
		{
			if (_dados.valorOutrasDespesas != Math.Round(value, 2))
			{
				_dados.valorOutrasDespesas = Math.Round(value, 2);
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

	public decimal ValorCofinsRetido
	{
		get
		{
			return _dados.valorCofinsRetido;
		}
		set
		{
			if (_dados.valorCofinsRetido != Math.Round(value, 2))
			{
				_dados.valorCofinsRetido = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorImpostoRetido
	{
		get
		{
			return _dados.valorImpostoRetido;
		}
		set
		{
			if (_dados.valorImpostoRetido != Math.Round(value, 2))
			{
				_dados.valorImpostoRetido = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTotalNotaFiscal
	{
		get
		{
			return _dados.valorTotalNotaFiscal;
		}
		set
		{
			if (_dados.valorTotalNotaFiscal != Math.Round(value, 2))
			{
				_dados.valorTotalNotaFiscal = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string ChaveNfe
	{
		get
		{
			return _dados.chaveNfe;
		}
		set
		{
			if (_dados.chaveNfe != value)
			{
				_dados.chaveNfe = value;
				PropertyHasChanged();
			}
		}
	}

	public string ProtocoloNfe
	{
		get
		{
			return _dados.protocoloNfe;
		}
		set
		{
			if (_dados.protocoloNfe != value)
			{
				_dados.protocoloNfe = value;
				PropertyHasChanged();
			}
		}
	}

	public string XmlNfe
	{
		get
		{
			return _dados.xmlNfe;
		}
		set
		{
			if (_dados.xmlNfe != value)
			{
				_dados.xmlNfe = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseICMSSubstituto
	{
		get
		{
			return _dados.valorBaseICMSSubstituto;
		}
		set
		{
			if (_dados.valorBaseICMSSubstituto != Math.Round(value, 2))
			{
				_dados.valorBaseICMSSubstituto = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorICMSSubstituto
	{
		get
		{
			return _dados.valorICMSSubstituto;
		}
		set
		{
			if (_dados.valorICMSSubstituto != Math.Round(value, 2))
			{
				_dados.valorICMSSubstituto = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSerieNF
	{
		get
		{
			return _dados.codigoSerieNF;
		}
		set
		{
			if (_dados.codigoSerieNF != value)
			{
				_dados.codigoSerieNF = value;
				PropertyHasChanged();
				SerieNotaFiscal = value.ToString();
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

	public string DescricaoCFOP
	{
		get
		{
			return _dados.descricaoCFOP;
		}
		set
		{
			if (_dados.descricaoCFOP != value)
			{
				_dados.descricaoCFOP = value;
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
				_entidade = null;
			}
		}
	}

	public int CodigoTextoLegal1
	{
		get
		{
			return _dados.codigoTextoLegal1;
		}
		set
		{
			if (_dados.codigoTextoLegal1 != value)
			{
				_dados.codigoTextoLegal1 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTextoLegal2
	{
		get
		{
			return _dados.codigoTextoLegal2;
		}
		set
		{
			if (_dados.codigoTextoLegal2 != value)
			{
				_dados.codigoTextoLegal2 = value;
				PropertyHasChanged();
			}
		}
	}

	public string RazaoSocialDestinatario
	{
		get
		{
			if (Entidade != null && Entidade.RazaoSocialNF != null)
			{
				RazaoSocialDestinatario = Entidade.RazaoSocialNF;
			}
			return _dados.razaoSocialDestinatario;
		}
		set
		{
			if (_dados.razaoSocialDestinatario != value)
			{
				_dados.razaoSocialDestinatario = value;
				PropertyHasChanged();
			}
		}
	}

	public string CnpjDestinatario
	{
		get
		{
			if (Entidade != null && Entidade.CNPJLimpo != null)
			{
				CnpjDestinatario = Entidade.CNPJLimpo;
			}
			return _dados.cnpjDestinatario;
		}
		set
		{
			if (_dados.cnpjDestinatario != value)
			{
				_dados.cnpjDestinatario = value;
				PropertyHasChanged();
			}
		}
	}

	public string SituacaoNfe
	{
		get
		{
			return _dados.situacaoNfe;
		}
		set
		{
			if (_dados.situacaoNfe != value)
			{
				_dados.situacaoNfe = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoLote
	{
		get
		{
			return _dados.codigoLote;
		}
		set
		{
			if (_dados.codigoLote != value)
			{
				_dados.codigoLote = value;
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

	public int QuantidadeVolumes
	{
		get
		{
			return _dados.qtVolumes;
		}
		set
		{
			if (_dados.qtVolumes != value)
			{
				_dados.qtVolumes = value;
				PropertyHasChanged("QuantidadeVolumes");
			}
		}
	}

	public decimal ValorTotalFatura
	{
		get
		{
			return _dados.valorTotalFatura;
		}
		set
		{
			if (_dados.valorTotalFatura != Math.Round(value, 2))
			{
				_dados.valorTotalFatura = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public int TipoEntidade
	{
		get
		{
			return _dados.tipoEntidade;
		}
		set
		{
			if (_dados.tipoEntidade != value)
			{
				_dados.tipoEntidade = value;
				PropertyHasChanged();
				_entidade = null;
			}
		}
	}

	public decimal ValorTotalFaturadoBruto
	{
		get
		{
			decimal result = default(decimal);
			foreach (NotaFiscalNotasFiscaisItens iten in Itens)
			{
				if (iten.ValorFatura > 0m || iten.NomeCfop.StartsWith("1") || iten.NomeCfop.StartsWith("2"))
				{
					result += iten.ValorTotalIPI;
				}
			}
			return result;
		}
	}

	public string TextoLegal
	{
		get
		{
			if (string.IsNullOrEmpty(_dados.textoLegal))
			{
				if (CFOP == null && Itens != null && Itens.Count > 0 && Itens[0].CFOPRef != null)
				{
					CFOP = Itens[0].CFOPRef;
				}
				if (CFOP != null)
				{
					if (CFOP.Texto01 != null && (string.IsNullOrWhiteSpace(_dados.textoLegal) || !_dados.textoLegal.Contains(CFOP.Texto01.TextoLegal)))
					{
						ref string textoLegal = ref _dados.textoLegal;
						textoLegal = textoLegal + CFOP.Texto01.TextoLegal + ";";
					}
					if (CFOP.Texto02 != null && (string.IsNullOrWhiteSpace(_dados.textoLegal) || !_dados.textoLegal.Contains(CFOP.Texto02.TextoLegal)))
					{
						ref string textoLegal2 = ref _dados.textoLegal;
						textoLegal2 = textoLegal2 + CFOP.Texto02.TextoLegal + ";";
					}
				}
			}
			return _dados.textoLegal;
		}
		set
		{
			if (_dados.textoLegal != value)
			{
				_dados.textoLegal = value;
				PropertyHasChanged();
			}
		}
	}

	public int TipoNota
	{
		get
		{
			return _dados.tipoNota;
		}
		set
		{
			if (_dados.tipoNota != value)
			{
				_dados.tipoNota = value;
				PropertyHasChanged();
			}
		}
	}

	public string NotaReferenciada
	{
		get
		{
			return _dados.notaReferenciada;
		}
		set
		{
			if (_dados.notaReferenciada != value)
			{
				_dados.notaReferenciada = value;
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
				ModificaConsumidorFinal(value);
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

	public bool IsFreteCliente
	{
		get
		{
			return _dados.isFreteCliente;
		}
		set
		{
			if (_dados.isFreteCliente != value)
			{
				_dados.isFreteCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCambio
	{
		get
		{
			return _dados.valorCambio;
		}
		set
		{
			if (_dados.valorCambio != value)
			{
				_dados.valorCambio = value;
				PropertyHasChanged();
			}
		}
	}

	public string Suframa
	{
		get
		{
			return _dados.suframa;
		}
		set
		{
			if (_dados.suframa != value)
			{
				_dados.suframa = value;
				PropertyHasChanged();
			}
		}
	}

	public string PlacaCaminhao
	{
		get
		{
			return _dados.placaCaminhao;
		}
		set
		{
			if (_dados.placaCaminhao != value)
			{
				_dados.placaCaminhao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoEntidadeEntrega
	{
		get
		{
			return _dados.codigoTipoEntidadeEntrega;
		}
		set
		{
			if (_dados.codigoTipoEntidadeEntrega != value)
			{
				_dados.codigoTipoEntidadeEntrega = value;
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

	public decimal ValorTotalIcmsInterestadualFundoPobreza
	{
		get
		{
			return _dados.valorTotalIcmsInterestadualFundoPobreza;
		}
		set
		{
			if (_dados.valorTotalIcmsInterestadualFundoPobreza != Math.Round(value, 2))
			{
				_dados.valorTotalIcmsInterestadualFundoPobreza = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTotalIcmsInterestadualUfDestino
	{
		get
		{
			return _dados.valorTotalIcmsInterestadualUfDestino;
		}
		set
		{
			if (_dados.valorTotalIcmsInterestadualUfDestino != Math.Round(value, 2))
			{
				_dados.valorTotalIcmsInterestadualUfDestino = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTotalIcmsInterestadualUfEnvolvidas
	{
		get
		{
			return _dados.valorTotalIcmsInterestadualUfEnvolvidas;
		}
		set
		{
			if (_dados.valorTotalIcmsInterestadualUfEnvolvidas != Math.Round(value, 2))
			{
				_dados.valorTotalIcmsInterestadualUfEnvolvidas = Math.Round(value, 2);
				PropertyHasChanged();
			}
		}
	}

	public string PortaoEntrega
	{
		get
		{
			return _dados.portaoEntrega;
		}
		set
		{
			if (_dados.portaoEntrega != value)
			{
				_dados.portaoEntrega = value;
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

	public bool IsBloquearRecalculoFatura
	{
		get
		{
			return _dados.isBloquearRecalculoFatura;
		}
		set
		{
			if (_dados.isBloquearRecalculoFatura != value)
			{
				_dados.isBloquearRecalculoFatura = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEDI
	{
		get
		{
			return _dados.codigoEDI;
		}
		set
		{
			if (_dados.codigoEDI != value)
			{
				_dados.codigoEDI = value;
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

	public int CodigoIndicadorPresenca
	{
		get
		{
			return _dados.codigoIndicadorPresenca;
		}
		set
		{
			if (_dados.codigoIndicadorPresenca != value)
			{
				_dados.codigoIndicadorPresenca = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoModeloDocumentoFiscalReferenciado
	{
		get
		{
			return _dados.codigoModeloDocumentoFiscalReferenciado;
		}
		set
		{
			if (_dados.codigoModeloDocumentoFiscalReferenciado != value)
			{
				_dados.codigoModeloDocumentoFiscalReferenciado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoModalidadeFrete
	{
		get
		{
			return _dados.codigoModalidadeFrete;
		}
		set
		{
			if (_dados.codigoModalidadeFrete != value)
			{
				_dados.codigoModalidadeFrete = value;
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

	public bool IsComissaoApurada
	{
		get
		{
			return _dados.isComissaoApurada;
		}
		set
		{
			if (_dados.isComissaoApurada != value)
			{
				_dados.isComissaoApurada = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoVolume
	{
		get
		{
			return string.IsNullOrWhiteSpace(_dados.tipoVolume) ? "Volumes" : _dados.tipoVolume;
		}
		set
		{
			if (_dados.tipoVolume != value)
			{
				_dados.tipoVolume = value;
				PropertyHasChanged("TipoVolume");
			}
		}
	}

	public int CodigoContaContabil
	{
		get
		{
			return _dados.codigoContaContabil;
		}
		set
		{
			if (_dados.codigoContaContabil != value)
			{
				_dados.codigoContaContabil = value;
				PropertyHasChanged("CodigoContaContabil");
			}
		}
	}

	public PedidoCompra PedidoCompraRef
	{
		get
		{
			if ((_pedidoCompra == null || _pedidoCompra.Codigo != -CodigoFichaExpedicao) && CodigoFichaExpedicao < 0)
			{
				_pedidoCompra = ModuloCompras.ObterPedidoCompra(Math.Abs(CodigoFichaExpedicao));
			}
			return _pedidoCompra;
		}
	}

	public FichaExpedicao FichaExpedicaoRef
	{
		get
		{
			if (CodigoFichaExpedicao <= 0)
			{
				return null;
			}
			if ((_fichaExpedicao == null || _fichaExpedicao.Codigo != CodigoFichaExpedicao) && CodigoFichaExpedicao > 0)
			{
				_fichaExpedicao = ModuloExpedicao.ObterFichaExpedicao(CodigoFichaExpedicao);
			}
			return _fichaExpedicao;
		}
		set
		{
			if (_fichaExpedicao != value)
			{
				_fichaExpedicao = value;
				if (value != null)
				{
					CodigoFichaExpedicao = _fichaExpedicao.Codigo;
				}
				else
				{
					CodigoFichaExpedicao = 0;
				}
			}
		}
	}

	public Sociedade Emitente
	{
		get
		{
			if (_emitente == null)
			{
				_emitente = ModuloParametros.ObterSociedade((CodigoEmpresa == 0) ? 1 : CodigoEmpresa);
			}
			return _emitente;
		}
	}

	public EntidadeGPS Entidade
	{
		get
		{
			if (_entidade == null || _entidade.Codigo != CodigoEntidade)
			{
				if (CodigoEntidade > 0 && TipoEntidade > 0)
				{
					_entidade = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoEntidade, (int)TipoEntidadeEnum);
				}
				else if (CodigoFichaExpedicao > 0)
				{
					_entidade = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoEntidade, 1);
				}
				else if (CodigoFichaExpedicao < 0)
				{
					_entidade = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoEntidade, 2);
				}
				else if (TipoEntidade == 2)
				{
					_entidade = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoEntidade, 2);
				}
				else if (TipoEntidade == 1)
				{
					_entidade = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoEntidade, 1);
				}
			}
			return _entidade;
		}
		set
		{
			if (_entidade != value)
			{
				if (value.IsCliente)
				{
					TipoEntidade = 1;
				}
				else
				{
					TipoEntidade = 2;
				}
				RazaoSocialDestinatario = value.RazaoSocialNF;
				CnpjDestinatario = value.CNPJLimpo;
				Suframa = value.CodigoSuframa;
				CodigoEntidade = value.Codigo;
				_entidade = value;
			}
		}
	}

	public EntidadeGPS Transportadora
	{
		get
		{
			if (_transportadora == null || _transportadora.Codigo != CodigoTransportadora)
			{
				_transportadora = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoTransportadora, 3);
			}
			return _transportadora;
		}
		set
		{
			_transportadora = value;
			if (value != null)
			{
				CodigoTransportadora = value.Codigo;
			}
			else
			{
				CodigoTransportadora = 0;
			}
		}
	}

	public NotaFiscalCFOPs CFOP
	{
		get
		{
			if (_cfop == null || _cfop.Id != CodigoCFOP)
			{
				_cfop = ModuloNotaFiscal.ObterNotaFiscalCFOPs(CodigoCFOP);
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
			if (_cfop != null)
			{
				CodigoCFOP = _cfop.Id;
				CodigoTextoLegal1 = _cfop.CodigoTexto1;
				CodigoTextoLegal2 = _cfop.CodigoTexto2;
				NumeracaoCFOP = _cfop.NumeracaoCFOP;
				DescricaoCFOP = _cfop.Nfe;
				if (_cfop.Texto01 != null && !string.IsNullOrEmpty(_cfop.Texto01.TextoLegal) && !TextoLegal.Contains(_cfop.Texto01.TextoLegal))
				{
					TextoLegal += _cfop.Texto01.TextoLegal;
				}
				if (_cfop.Texto02 != null && !string.IsNullOrEmpty(_cfop.Texto02.TextoLegal) && !TextoLegal.Contains(_cfop.Texto02.TextoLegal))
				{
					TextoLegal += $" {_cfop.Texto02.TextoLegal}";
				}
				if (!string.IsNullOrWhiteSpace(TextoLegal))
				{
					TextoLegal = TextoLegal.Trim();
				}
			}
			else
			{
				CodigoCFOP = 0;
				CodigoTextoLegal1 = 0;
				CodigoTextoLegal2 = 0;
				NumeracaoCFOP = string.Empty;
				DescricaoCFOP = string.Empty;
			}
		}
	}

	public IList<NotaFiscalFatura> Fatura
	{
		get
		{
			if (_fatura == null || _fatura.Count == 0)
			{
				DateTime dataInicioCalulo = DataSaida;
				if (NumeroNotaFiscal > 0)
				{
					_fatura = ModuloNotaFiscal.ObterNotaFiscalFatura(CodigoEmpresa, NumeroNotaFiscal, CodigoSerieNF);
				}
				if (ValorTotalFatura > 0m && (_fatura == null || _fatura.Count == 0))
				{
					if (_fatura == null)
					{
						_fatura = new List<NotaFiscalFatura>();
					}
					if (CodigoCondicaoPagamento > 0 && CondicaoPagamentoRef != null)
					{
						if (CondicaoPagamentoRef.IsCalcularDataPedido && FichaExpedicaoRef != null && FichaExpedicaoRef.PedidoVenda != null)
						{
							dataInicioCalulo = FichaExpedicaoRef.PedidoVenda.DataPedido;
						}
						_fatura = ModuloNotaFiscal.CalcularCondicaoPagamento(CondicaoPagamentoRef, dataInicioCalulo, ValorTotalFatura, NumeroNotaFiscal, CodigoSerieNF, ValorICMSSubstituto);
					}
					else if (FichaExpedicaoRef != null && FichaExpedicaoRef.PedidoVenda != null && FichaExpedicaoRef.PedidoVenda.CondicaoPagamento != null)
					{
						if (CondicaoPagamentoRef.IsCalcularDataPedido)
						{
							dataInicioCalulo = FichaExpedicaoRef.PedidoVenda.DataPedido;
						}
						_fatura = ModuloNotaFiscal.CalcularCondicaoPagamento(FichaExpedicaoRef.PedidoVenda.CondicaoPagamento, dataInicioCalulo, ValorTotalFatura, NumeroNotaFiscal, CodigoSerieNF, ValorICMSSubstituto);
					}
					else
					{
						_fatura = ModuloNotaFiscal.CalcularCondicaoPagamento(ValorTotalFatura, NumeroNotaFiscal, CodigoSerieNF);
					}
				}
			}
			return _fatura;
		}
		set
		{
			if (_fatura != value)
			{
				_fatura = value;
				if (_fatura == null)
				{
					ModuloNotaFiscal.ExcluirNotaFiscalFatura(CodigoEmpresa, NumeroNotaFiscal, CodigoSerieNF);
				}
			}
		}
	}

	public IList<NotaFiscalNotasFiscaisItens> Itens
	{
		get
		{
			if (_itens == null && NumeroNotaFiscal > 0)
			{
				_itens = ModuloNotaFiscal.ObterNotaFiscalNotasFiscaisItens(CodigoEmpresa, NumeroNotaFiscal, CodigoSerieNF);
				if (_itens == null || _itens.Count == 0)
				{
					AtualizaItens();
				}
			}
			if (_itens == null)
			{
				_itens = new List<NotaFiscalNotasFiscaisItens>();
			}
			return _itens;
		}
		set
		{
			if (_itens != value)
			{
				_itens = value;
			}
		}
	}

	public IList<NotaFiscalNotaReferenciada> ChavesNotasReferenciadas
	{
		get
		{
			if (_notasReferenciadas == null)
			{
				_notasReferenciadas = ModuloNotaFiscal.ObterTodosNotaFiscalNotaReferenciada(CodigoEmpresa, NumeroNotaFiscal, CodigoSerieNF);
			}
			if (_notasReferenciadas == null)
			{
				_notasReferenciadas = new List<NotaFiscalNotaReferenciada>();
			}
			return _notasReferenciadas;
		}
	}

	public NotaFiscalNotasFiscais NotaReferenciadaRef
	{
		get
		{
			if (_notaReferenciada == null && TipoNota > 1)
			{
				_notaReferenciada = ModuloNotaFiscal.ObterNotaFiscalNotasFiscais(NotaReferenciada);
			}
			return _notaReferenciada;
		}
		set
		{
			if (_notaReferenciada != value)
			{
				_notaReferenciada = value;
				if (_notaReferenciada != null)
				{
					NotaReferenciada = _notaReferenciada.ChaveNfe;
					Entidade = _notaReferenciada.Entidade;
					CodigoTransportadora = _notaReferenciada.CodigoTransportadora;
					IsNotaFiscalEntrada = _notaReferenciada.IsNotaFiscalEntrada;
				}
				else
				{
					NotaReferenciada = string.Empty;
				}
			}
		}
	}

	public CondicaoPagamentoGPS CondicaoPagamentoRef
	{
		get
		{
			if (_condicaoPagamento == null && _dados.codigoCondicaoPagamento > 0)
			{
				_condicaoPagamento = ModuloVendasGPS.ObterCondicaoPagamento(_dados.codigoCondicaoPagamento);
			}
			return _condicaoPagamento;
		}
		set
		{
			if (_condicaoPagamento != value)
			{
				_condicaoPagamento = value;
				if (_condicaoPagamento != null)
				{
					CodigoCondicaoPagamento = _condicaoPagamento.CodigoCondicaoPagamento;
				}
				else
				{
					CodigoCondicaoPagamento = 0;
				}
			}
		}
	}

	public IList<NotasFiscaisEventos> NotasFiscaisEventosRef
	{
		get
		{
			if (_eventos == null)
			{
				_eventos = ModuloNotaFiscal.ObterTodosNotasFiscaisEventos(CodigoEmpresa, NumeroNotaFiscal, CodigoSerieNF);
			}
			return _eventos;
		}
	}

	public EntidadeGPS EntidadeEntrega
	{
		get
		{
			if (_entidadeEntrega == null || _entidadeEntrega.Codigo != CodigoEntidadeEntrega)
			{
				_entidadeEntrega = ModuloEntidadesGPS.ObterEntidadeGPS(CodigoEntidadeEntrega, CodigoTipoEntidadeEntrega);
			}
			return _entidadeEntrega;
		}
		set
		{
			_entidadeEntrega = value;
		}
	}

	public decimal ValorTotalProdutos => ValorImpostoImportacao + ValorProdutos;

	public string NomeFantasiaEmitente
	{
		get
		{
			string result = string.Empty;
			if (Emitente != null)
			{
				result = Emitente.NomeFantasia;
			}
			return result;
		}
	}

	public Sociedade SociedadeRef => Emitente;

	public StructTipoCodigo TipoCodigoEntidade
	{
		get
		{
			return new StructTipoCodigo(TipoEntidade, CodigoEntidade);
		}
		set
		{
			TipoEntidade = value.tipo;
			CodigoEntidade = value.codigo;
		}
	}

	public StructTipoCodigo EntidadeEntregaStruct
	{
		get
		{
			_tipoCodigoCobranca.codigo = CodigoEntidadeEntrega;
			_tipoCodigoCobranca.tipo = CodigoTipoEntidadeEntrega;
			return _tipoCodigoCobranca;
		}
		set
		{
			if (!_tipoCodigoCobranca.Equals(value))
			{
				_tipoCodigoCobranca = value;
				CodigoEntidadeEntrega = _tipoCodigoCobranca.codigo;
				CodigoTipoEntidadeEntrega = _tipoCodigoCobranca.tipo;
			}
		}
	}

	public EnumFinalidadeNotaFiscal TipoNotaEnum
	{
		get
		{
			return (EnumFinalidadeNotaFiscal)TipoNota;
		}
		set
		{
			TipoNota = (int)value;
		}
	}

	public EnumMeioPagamentoNotaFiscal MeioPagamentoNotaFiscalEnum
	{
		get
		{
			return (EnumMeioPagamentoNotaFiscal)CodigoFormaPagto;
		}
		set
		{
			CodigoFormaPagto = (int)value;
		}
	}

	public EnumTipoEntidade TipoEntidadeEnum
	{
		get
		{
			return (EnumTipoEntidade)TipoEntidade;
		}
		set
		{
			TipoEntidade = (int)value;
		}
	}

	public string CFOPLongo
	{
		get
		{
			if (CFOP != null)
			{
				return CFOP.SeqCFOP + ": " + CFOP.ExibirComo;
			}
			return string.Empty;
		}
	}

	public int CodigoPedido
	{
		get
		{
			if (FichaExpedicaoRef != null && FichaExpedicaoRef.PedidoVenda != null)
			{
				return FichaExpedicaoRef.PedidoVenda.CodigoPedidoVenda;
			}
			if (PedidoCompraRef != null)
			{
				return PedidoCompraRef.Codigo;
			}
			return 0;
		}
	}

	public decimal ValorLiquidoFatura => ValorTotalFaturadoBruto + ValorICMSSubstituto - ValorPIS - ValorCofins - ValorICMS - ValorIPI;

	public IDictionary<int, EstoqueLoteMaterailClienteControle> matsCli
	{
		get
		{
			return _matsCli;
		}
		set
		{
			if (_matsCli != value)
			{
				_matsCli = value;
			}
		}
	}

	public decimal ValorFreteSeguroOutrasDespesas => ValorFrete + ValorSeguro + ValorOutrasDespesas;

	public decimal ValorTotalAproximadoImpostos => ValorICMSTotal + ValorIPI + ValorPIS + ValorCofins + ValorImpostoImportacao + ValorCSLL;

	public decimal ValorProdutosComImpostoImportacao => ValorProdutos + ValorImpostoImportacao;

	public decimal ValorICMSTotal => ValorICMS + ValorICMSSubstituto;

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalNotasFiscais);
		_itens = null;
		_fatura = null;
		_entidade = null;
		_emitente = null;
		_cfop = null;
		_fichaExpedicao = null;
		_transportadora = null;
		_pedidoCompra = null;
		_notaReferenciada = null;
		_condicaoPagamento = null;
		if (isNovo)
		{
			MarcarNovo();
			CodigoEmpresa = 1;
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalNotasFiscais()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalNotasFiscais(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public NotaFiscalNotasFiscais(PedidoVendaGPS pedidoVenda, int codigoCFOP)
		: this()
	{
		CriarNotaFaturamentoEntregaFutura(pedidoVenda, codigoCFOP);
	}

	public void ModificaConsumidorFinal(bool isConsumidor)
	{
		if (this == null || Itens == null || Itens.Count <= 0)
		{
			return;
		}
		foreach (NotaFiscalNotasFiscaisItens iten in Itens)
		{
			iten.IsConsumidorFinal = isConsumidor;
			iten.CalcularImposto(TipoNotaEnum);
		}
		AcertaTotais();
	}

	public void AtualizaTotais()
	{
		if (isImportacao)
		{
			ValorTotalNotaFiscal = ValorBaseICMS;
		}
		else
		{
			ValorTotalNotaFiscal = ValorProdutos - ValorDesconto - ValorIcmsDesonerado + ValorICMSSubstituto + ValorFreteSeguroOutrasDespesas + ValorImpostoImportacao + ValorIPI;
		}
		if (ValorCreditoIcms > 0m && ValorProdutos > 0m)
		{
			PercentualCreditoIcms = Math.Round(ValorCreditoIcms / ValorProdutos * 100m, 2);
		}
	}

	public void AtualizaItens()
	{
		if (FichaExpedicaoRef == null && PedidoCompraRef == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		try
		{
			flag = ModuloParametros.ObterParametros("Faturamento", "CodigoPedidoInformacaoesAdicionais").Valor == 1;
			flag2 = ModuloParametros.ObterParametros("Faturamento", "EnderecoCobranca").Valor == 1;
		}
		catch
		{
		}
		decimal pesoBruto = default(decimal);
		decimal pesoLiquido = default(decimal);
		int num = 0;
		_matsCli = new Dictionary<int, EstoqueLoteMaterailClienteControle>();
		int ordem = 1;
		List<NotaFiscalNotasFiscaisItens> list = new List<NotaFiscalNotasFiscaisItens>();
		int codigoEstadoDestinatario = 0;
		if (FichaExpedicaoRef != null && FichaExpedicaoRef.Itens != null)
		{
			if (FichaExpedicaoRef.EntidadeRef != null && FichaExpedicaoRef.EntidadeRef.CodigoUf > 0)
			{
				codigoEstadoDestinatario = FichaExpedicaoRef.EntidadeRef.CodigoUf;
			}
			IList<FichaExpedicaoItem> itens = FichaExpedicaoRef.Itens;
			CodigoEmpresa = FichaExpedicaoRef.CodigoSociedade;
			CodigoEntidade = FichaExpedicaoRef.CodigoEntidade;
			TipoEntidade = 1;
			CodigoTransportadora = FichaExpedicaoRef.CodigoTransportadora;
			PlacaCaminhao = FichaExpedicaoRef.PlacaCaminhao;
			PortaoEntrega = FichaExpedicaoRef.PortaoEntrega;
			if (CodigoTransportadora == 0 && FichaExpedicaoRef.PedidoVenda != null && FichaExpedicaoRef.PedidoVenda.CodigoTransportador > 0)
			{
				CodigoTransportadora = FichaExpedicaoRef.PedidoVenda.CodigoTransportador;
			}
			if (FichaExpedicaoRef.PedidoVenda != null)
			{
				CodigoModalidadeFrete = FichaExpedicaoRef.PedidoVenda.CodigoModoTransporteNotaFiscal;
			}
			IsFretePagoPeloEmitente = FichaExpedicaoRef.IsFretePago;
			pesoBruto = FichaExpedicaoRef.PesoBrutoTotal;
			pesoLiquido = FichaExpedicaoRef.PesoLiquidoTotal;
			num = FichaExpedicaoRef.QuantidadeEmbalagens;
			FichaExpedicaoRef.CodigoNotaFiscal = _dados.numeroNotaFiscal;
			FichaExpedicaoRef.StatusFichaExpedicao = EnumStatusFichaExpedicao.Faturado;
			NotaFiscalCFOPs notaFiscalCFOPs = new NotaFiscalCFOPs();
			foreach (FichaExpedicaoItem item in itens)
			{
				notaFiscalCFOPs = new NotaFiscalCFOPs();
				if (item.CodigoNotaFiscal != 0 || item.ItemNotaFiscal != 0)
				{
					continue;
				}
				if (item.CodigoCfopInterna > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.CodigoCfopInterna);
				}
				else if (item.Tarifa != null && item.Tarifa.CodigoCfopInterna > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.Tarifa.CodigoCfopInterna);
				}
				else if (item.EstoqueRef != null && item.EstoqueRef.TarifaPadraoVenda != null)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.EstoqueRef.TarifaPadraoVenda.CodigoCfopInterna);
				}
				if (notaFiscalCFOPs.ReducaoICMS == 0m)
				{
					notaFiscalCFOPs.ReducaoICMS = 100m;
				}
				if (CFOP == null || string.IsNullOrWhiteSpace(CFOP.NumeracaoCFOP))
				{
					CFOP = notaFiscalCFOPs;
				}
				NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = new NotaFiscalNotasFiscaisItens(isNovo: true);
				notaFiscalNotasFiscaisItens.CodigoFichaExpedicao = item.CodigoFichaExpedicao;
				notaFiscalNotasFiscaisItens.CodigoFichaExpedicaoItem = item.ItemFichaExpedicao;
				notaFiscalNotasFiscaisItens.CodigoPedidoVenda = item.CodigoPedido;
				notaFiscalNotasFiscaisItens.CodigoPedidoVendaItem = item.ItemPedido;
				if (item.EstoqueRef != null)
				{
					notaFiscalNotasFiscaisItens.Cest = item.EstoqueRef.Cest;
					notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = item.EstoqueRef.ClassificacaoFiscal;
				}
				notaFiscalNotasFiscaisItens.CodigoEstadoDestinatario = codigoEstadoDestinatario;
				notaFiscalNotasFiscaisItens.CFOPRef = notaFiscalCFOPs;
				if (item.IdContaContabil > 0)
				{
					PlanoConta planoConta = ModuloFiscal.ObterPlanoConta(item.IdContaContabil);
					if (planoConta != null && planoConta.Conta.Length > 0)
					{
						notaFiscalNotasFiscaisItens.ContaContabilAnalitica = planoConta.Conta;
					}
				}
				notaFiscalNotasFiscaisItens.CodigoProduto = item.CodigoProduto;
				notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = "PC";
				notaFiscalNotasFiscaisItens.Quantidade = item.QuantidadeEntregue;
				notaFiscalNotasFiscaisItens.QuantidadeEmPecas = item.QuantidadeEntregue;
				if (item.Tarifa != null)
				{
					if (!string.IsNullOrEmpty(item.Tarifa.CodigoContratoEntrega))
					{
						notaFiscalNotasFiscaisItens.ContratoCliente = item.Tarifa.CodigoContratoEntrega;
						if (!string.IsNullOrWhiteSpace(item.ChamadaKanban) && int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban)) > 0)
						{
							notaFiscalNotasFiscaisItens.ContratoClienteItem = int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban));
						}
						else
						{
							notaFiscalNotasFiscaisItens.ContratoClienteItem = item.Tarifa.CodigoContratoEntregaItem;
						}
						notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente = item.Tarifa.CodigoContratoEntrega;
						notaFiscalNotasFiscaisItens.CodigoPedidoCompraItemCliente = item.Tarifa.CodigoContratoEntregaItem;
					}
					else if (string.IsNullOrEmpty(notaFiscalNotasFiscaisItens.ContratoCliente))
					{
						notaFiscalNotasFiscaisItens.ContratoCliente = item.PedidoVendaItemRef.PedidoVenda.ReferenciaPedido;
						notaFiscalNotasFiscaisItens.ContratoClienteItem = item.PedidoVendaItemRef.CodigoItemPedido;
						notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente = item.PedidoVendaItemRef.PedidoVenda.ReferenciaPedido;
						notaFiscalNotasFiscaisItens.CodigoPedidoCompraItemCliente = item.PedidoVendaItemRef.CodigoItemPedido;
					}
					notaFiscalNotasFiscaisItens.TagXml = item.Tarifa.TagXml;
					notaFiscalNotasFiscaisItens.ValorUnitario = item.Tarifa.PrecoTarifaCatalogo;
					notaFiscalNotasFiscaisItens.ChaveEstoqueRef = item.Tarifa.ChavePrimariaEstoque;
					if (item.Tarifa.SiglaUnidadeFaturamento.Length > 1)
					{
						notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.Tarifa.SiglaUnidadeFaturamento.ToUpper();
					}
					if (!string.IsNullOrWhiteSpace(item.Tarifa.CodigoProdutoEntidade))
					{
						if (notaFiscalNotasFiscaisItens.CodigoProduto.ToUpper().Equals(item.Tarifa.CodigoProdutoEntidade.ToUpper()) && !item.Tarifa.IsAdicionaCodigoExternaDescricaoNF)
						{
							notaFiscalNotasFiscaisItens.DescricaoProduto = item.Tarifa.DescricaoProdutoEntidade;
						}
						else
						{
							notaFiscalNotasFiscaisItens.DescricaoProduto = $"{item.Tarifa.CodigoProdutoEntidade} - {item.Tarifa.DescricaoProdutoEntidade}";
						}
						notaFiscalNotasFiscaisItens.CodigoExterno = item.Tarifa.CodigoProdutoEntidade;
					}
				}
				else if (item.EstoqueRef != null && item.EstoqueRef.TarifaPadraoVenda != null)
				{
					if (notaFiscalNotasFiscaisItens.CodigoProduto.ToUpper().Equals(item.EstoqueRef.TarifaPadraoVenda.CodigoProdutoEntidade.ToUpper()) && !item.Tarifa.IsAdicionaCodigoExternaDescricaoNF)
					{
						notaFiscalNotasFiscaisItens.DescricaoProduto = item.EstoqueRef.TarifaPadraoVenda.DescricaoProdutoEntidade;
					}
					else
					{
						notaFiscalNotasFiscaisItens.DescricaoProduto = $"{item.EstoqueRef.TarifaPadraoVenda.CodigoProdutoEntidade} - {item.EstoqueRef.TarifaPadraoVenda.DescricaoProdutoEntidade}";
					}
					try
					{
						notaFiscalNotasFiscaisItens.ValorUnitario = ModuloVendasGPS.ObterPedidoVendaItem(item.CodigoPedido, item.ItemPedido).PrecoUnitarioBruto;
					}
					catch
					{
						notaFiscalNotasFiscaisItens.ValorUnitario = 0m;
						XtraMessageBox.Show("Valor Unitário não encontrado para o item: " + item.CodigoProduto, "Atenção!");
					}
					if (item.EstoqueRef.TarifaPadraoVenda.SiglaUnidadeFaturamento.Length > 1)
					{
						notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.EstoqueRef.TarifaPadraoVenda.SiglaUnidadeFaturamento.ToUpper();
					}
				}
				else
				{
					notaFiscalNotasFiscaisItens.DescricaoProduto = item.DescricaoProduto;
					if (item.ItemPedido > 0)
					{
						try
						{
							notaFiscalNotasFiscaisItens.ValorUnitario = ModuloVendasGPS.ObterPedidoVendaItem(item.CodigoPedido, item.ItemPedido).PrecoUnitarioBruto;
						}
						catch
						{
							notaFiscalNotasFiscaisItens.ValorUnitario = 0m;
							XtraMessageBox.Show("Valor Unitário não encontrado para o item: " + item.CodigoProduto, "Atenção!");
						}
					}
					else
					{
						notaFiscalNotasFiscaisItens.ValorUnitario = 0m;
					}
				}
				if (item.Tarifa != null && item.Tarifa.FatorConversaoUnidadeFaturamento != 1m && item.Tarifa.FatorConversaoUnidadeFaturamento != 0m)
				{
					notaFiscalNotasFiscaisItens.ValorUnitario *= item.Tarifa.FatorConversaoUnidadeFaturamento;
					notaFiscalNotasFiscaisItens.Quantidade /= item.Tarifa.FatorConversaoUnidadeFaturamento;
					notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.Tarifa.SiglaUnidadeFaturamento.ToUpper();
				}
				else if (item.EstoqueRef != null && item.EstoqueRef.TarifaPadraoVenda != null && item.EstoqueRef.TarifaPadraoVenda.FatorConversaoUnidadeFaturamento != 1m && item.EstoqueRef.TarifaPadraoVenda.FatorConversaoUnidadeFaturamento != 0m)
				{
					notaFiscalNotasFiscaisItens.ValorUnitario *= item.Tarifa.FatorConversaoUnidadeFaturamento;
					notaFiscalNotasFiscaisItens.Quantidade /= item.Tarifa.FatorConversaoUnidadeFaturamento;
					notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.Tarifa.SiglaUnidadeFaturamento.ToUpper();
				}
				if (!string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens.DescricaoProduto))
				{
					notaFiscalNotasFiscaisItens.DescricaoProduto = notaFiscalNotasFiscaisItens.DescricaoProduto.Trim();
				}
				decimal num2 = default(decimal);
				if (CondicaoPagamentoRef != null && CondicaoPagamentoRef.Desconto > 0m)
				{
					num2 = CondicaoPagamentoRef.Desconto;
					notaFiscalNotasFiscaisItens.ValorUnitario -= notaFiscalNotasFiscaisItens.ValorUnitario * num2 / 100m;
				}
				if (item.EstoqueRef != null)
				{
					notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = item.EstoqueRef.ClassificacaoFiscal;
					notaFiscalNotasFiscaisItens.Cest = item.EstoqueRef.Cest;
					notaFiscalNotasFiscaisItens.ChaveEstoqueRef = item.EstoqueRef.ChavePrimariaEstoque;
					if (item.EstoqueRef.EstoqueEanRef != null && !string.IsNullOrWhiteSpace(item.EstoqueRef.EstoqueEanRef.CodigoEAN))
					{
						notaFiscalNotasFiscaisItens.CodigoEan = item.EstoqueRef.EstoqueEanRef.CodigoEANComDigitoVerificador.Trim();
					}
				}
				else
				{
					notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = "00000000";
				}
				if (item.PedidoVendaItemRef != null)
				{
					if (!string.IsNullOrWhiteSpace(item.PedidoVendaItemRef.ClassificacaoFiscal))
					{
						notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = item.PedidoVendaItemRef.ClassificacaoFiscal;
					}
					if (string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens.ContratoCliente))
					{
						notaFiscalNotasFiscaisItens.ContratoCliente = item.PedidoVendaItemRef.PedidoVenda.ReferenciaPedido;
					}
					if (item.PedidoVendaItemRef.NumeroItemFaturamento > 0)
					{
						notaFiscalNotasFiscaisItens.ContratoClienteItem = item.PedidoVendaItemRef.NumeroItemFaturamento;
					}
					if (!string.IsNullOrWhiteSpace(item.ChamadaKanban) && int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban)) > 0)
					{
						notaFiscalNotasFiscaisItens.ContratoClienteItem = int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban));
					}
					else if (notaFiscalNotasFiscaisItens.ContratoClienteItem == 0)
					{
						notaFiscalNotasFiscaisItens.ContratoClienteItem = item.PedidoVendaItemRef.CodigoItemPedido;
					}
					notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente = notaFiscalNotasFiscaisItens.ContratoCliente;
					notaFiscalNotasFiscaisItens.CodigoPedidoCompraItemCliente = notaFiscalNotasFiscaisItens.ContratoClienteItem;
					notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.PedidoVendaItemRef.SiglaFaturamento;
				}
				notaFiscalNotasFiscaisItens.ValorUnitario = Math.Round(notaFiscalNotasFiscaisItens.ValorUnitario, 4);
				notaFiscalNotasFiscaisItens.CalcularImposto(EnumFinalidadeNotaFiscal.Normal);
				if (flag && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente))
				{
					string value = $"Pedido: {notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente}";
					if (notaFiscalNotasFiscaisItens.DescricaoComplementar == null || !notaFiscalNotasFiscaisItens.DescricaoComplementar.Contains(value))
					{
						notaFiscalNotasFiscaisItens.DescricaoComplementar += $" Pedido: {notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente}";
						if (notaFiscalNotasFiscaisItens.ContratoClienteItem > 0)
						{
							notaFiscalNotasFiscaisItens.DescricaoComplementar += $" Item: {notaFiscalNotasFiscaisItens.ContratoClienteItem}";
						}
					}
					notaFiscalNotasFiscaisItens.DescricaoComplementar = notaFiscalNotasFiscaisItens.DescricaoComplementar.Trim();
				}
				if (FichaExpedicaoRef.EntidadeRef != null && FichaExpedicaoRef.EntidadeRef.IdNormaEdi == 5)
				{
					notaFiscalNotasFiscaisItens.DescricaoComplementar = string.Format("{0}{1}{2}{3}", "IAP01", notaFiscalNotasFiscaisItens.CodigoExterno.PadLeft(11, '0'), " ".PadRight(19), notaFiscalNotasFiscaisItens.ContratoCliente.PadRight(12, ' '));
				}
				notaFiscalNotasFiscaisItens.Ordem = ordem++;
				if (notaFiscalCFOPs.IsEnviaConsignado && item.EstoqueRef != null)
				{
					try
					{
						EstoqueConsignado estoqueConsignado = ModuloVendasGPS.ObterEstoqueConsignado(_dados.codigoEntidade, (int)item.EstoqueRef.TipoEstoque, item.CodigoProduto, item.TipoProduto, item.EstoqueRef.CodigoCliente);
						if (estoqueConsignado == null)
						{
							estoqueConsignado = new EstoqueConsignado();
							estoqueConsignado.CodigoCliente = _dados.codigoEntidade;
							estoqueConsignado.EstoqueRef = item.EstoqueRef;
						}
						notaFiscalNotasFiscaisItens.EstoqueConsignadoRef = estoqueConsignado;
						EstoqueConsignadoLote estoqueConsignadoLote = new EstoqueConsignadoLote();
						estoqueConsignadoLote.EstoqueConsignadoRef = estoqueConsignado;
						estoqueConsignadoLote.Quantidade = item.QuantidadeEntregue;
						estoqueConsignadoLote.Lote = notaFiscalNotasFiscaisItens.CodigoNotaFiscal * 1000 + notaFiscalNotasFiscaisItens.Ordem;
						notaFiscalNotasFiscaisItens.EstoqueConsignadoLoteRef = estoqueConsignadoLote;
						EstoqueConsignadoMovimento estoqueConsignadoMovimento = new EstoqueConsignadoMovimento();
						estoqueConsignadoMovimento.EstoqueConsignadoLoteRef = estoqueConsignadoLote;
						estoqueConsignadoMovimento.Data = DataEmissao;
						estoqueConsignadoMovimento.Descricao = "Envio de Mercadoria Consignada, Pedido: " + FichaExpedicaoRef.CodigoProjeto + " Item: " + item.ItemPedido + " FE: " + FichaExpedicaoRef.Codigo;
						estoqueConsignadoMovimento.QuantidadeEntrada = estoqueConsignadoLote.Quantidade;
						estoqueConsignadoMovimento.QuantidadeSaida = 0m;
						notaFiscalNotasFiscaisItens.ConsignadoMovimentoRef = estoqueConsignadoMovimento;
					}
					catch
					{
						XtraMessageBox.Show("Erro ao movimentar consignado", "Erro");
					}
				}
				list.Add(notaFiscalNotasFiscaisItens);
				bool flag3 = ModuloParametros.ObterParametros("Faturamento", "DevolverMaterialCliente").Valor == 1;
				Estoque estoque = null;
				decimal quantidadeEntregue = item.QuantidadeEntregue;
				if (item.EstoqueRef != null && item.IsItemCliente)
				{
					estoque = item.EstoqueRef;
				}
				if (estoque != null && estoque.DevolverMateriaClienteAutomatico && !string.IsNullOrEmpty(estoque.CodigoProduto) && item.OrdemFabricacaoProduto == 0)
				{
					ordem = CalculoMaterialCliente(ordem, list, estoque, (int)quantidadeEntregue, null);
				}
			}
			if (flag2 && FichaExpedicaoRef.PedidoVenda != null && FichaExpedicaoRef.PedidoVenda.EnderecoFaturamento != null)
			{
				EnderecoEntidadeGPS enderecoFaturamento = FichaExpedicaoRef.PedidoVenda.EnderecoFaturamento;
				TextoLegal += string.Format(" Endereço Cobrança: {0} {1}, {1}, {2}, {3}", enderecoFaturamento.Endereco, enderecoFaturamento.Complemento, enderecoFaturamento.Cidade, enderecoFaturamento.Uf, enderecoFaturamento.CodigoPostal).Trim();
			}
		}
		else
		{
			PedidoCompraRef.Status = EnumStatusPedidosCompra.Enviado;
			IList<PedidoCompraItem> list2 = new List<PedidoCompraItem>();
			list2 = ((PedidoCompraRef.ItensSimplesRemessa == null || PedidoCompraRef.ItensSimplesRemessa.Count <= 0) ? PedidoCompraRef.ItensImpressao : PedidoCompraRef.ItensSimplesRemessa);
			CodigoEmpresa = PedidoCompraRef.CodigoSociedade;
			CodigoEntidade = PedidoCompraRef.CodigoFornecedor;
			TipoEntidade = 2;
			if (PedidoCompraRef.FornecedorRef != null && PedidoCompraRef.FornecedorRef.CodigoUf > 0)
			{
				codigoEstadoDestinatario = PedidoCompraRef.FornecedorRef.CodigoUf;
			}
			CodigoTransportadora = PedidoCompraRef.CodigoTransportadora;
			IsFretePagoPeloEmitente = PedidoCompraRef.CodigoModoTransporte == 1;
			foreach (PedidoCompraItem item2 in list2)
			{
				NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens2 = new NotaFiscalNotasFiscaisItens(isNovo: true);
				if (item2.EstoqueRef != null)
				{
					notaFiscalNotasFiscaisItens2.Cest = item2.EstoqueRef.Cest;
				}
				notaFiscalNotasFiscaisItens2.CodigoEstadoDestinatario = codigoEstadoDestinatario;
				if (item2.CodigoImpostoNotaFiscal > 0)
				{
					notaFiscalNotasFiscaisItens2.CFOPRef = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item2.CodigoImpostoNotaFiscal);
				}
				else if (item2.ImpostoCompraRef != null && item2.ImpostoCompraRef.CodigoImpostoSaida > 0)
				{
					notaFiscalNotasFiscaisItens2.CFOPRef = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item2.ImpostoCompraRef.CodigoImpostoSaida);
				}
				else
				{
					notaFiscalNotasFiscaisItens2.CFOPRef = CFOP;
				}
				notaFiscalNotasFiscaisItens2.CodigoProduto = item2.CodigoProduto;
				notaFiscalNotasFiscaisItens2.DescricaoProduto = item2.DescricaoProduto;
				notaFiscalNotasFiscaisItens2.CodigoPedidoCompra = item2.CodigoPedido;
				notaFiscalNotasFiscaisItens2.CodigoPedidoCompraItem = item2.ItemPedido;
				notaFiscalNotasFiscaisItens2.DescricaoComplementar = $"Pedido de Compra {item2.CodigoPedido}, item {item2.ItemPedido}";
				if (item2.OrigemNecessidade != null && item2.OrigemNecessidade.Count > 0)
				{
					foreach (PedidoCompraItemOrigem item3 in item2.OrigemNecessidade)
					{
						if (item3.CodigoProjeto > 0)
						{
							notaFiscalNotasFiscaisItens2.DescricaoComplementar += $", OF {item3.CodigoProjeto}/{item3.CodigoOrdemFabricacao}/{item3.CodigoFichaProducao}";
						}
					}
				}
				notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = ((EnumUnidadeSigla)item2.UnidadeCompra/*cast due to .constrained prefix*/).ToString();
				if (item2.UnidadeCompra == EnumUnidade.Unitário)
				{
					notaFiscalNotasFiscaisItens2.Quantidade = item2.QuantidadePedida;
				}
				else
				{
					notaFiscalNotasFiscaisItens2.Quantidade = item2.QuantidadePedida * ((item2.ComprimentoPedido == 0m) ? 1m : item2.ComprimentoPedido);
				}
				if (item2.ValorRemessa == 0m && item2.PrecoUnitario == 0m && item2.EstoqueRef != null && item2.EstoqueRef.PrecoBaseCompra > 0m)
				{
					notaFiscalNotasFiscaisItens2.ValorUnitario = item2.EstoqueRef.PrecoBaseCompra;
					notaFiscalNotasFiscaisItens2.ValorTotal = item2.EstoqueRef.PrecoBaseCompra * item2.QuantidadePedida;
				}
				else if (item2.ValorRemessa > 0m)
				{
					notaFiscalNotasFiscaisItens2.ValorUnitario = item2.ValorRemessa;
					notaFiscalNotasFiscaisItens2.ValorTotal = Math.Round(item2.ValorRemessa * notaFiscalNotasFiscaisItens2.Quantidade, 2);
				}
				else
				{
					notaFiscalNotasFiscaisItens2.ValorUnitario = item2.PrecoUnitario;
					notaFiscalNotasFiscaisItens2.ValorTotal = item2.PrecoTotal;
				}
				if (item2.EstoqueRef != null && item2.EstoqueRef.ClassificacaoFiscal != string.Empty)
				{
					notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = item2.EstoqueRef.ClassificacaoFiscal;
					notaFiscalNotasFiscaisItens2.Cest = item2.EstoqueRef.Cest;
				}
				else
				{
					notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = "00000000";
				}
				notaFiscalNotasFiscaisItens2.QuantidadeEmbalagem = item2.QuantidadeEmbalagem;
				notaFiscalNotasFiscaisItens2.PesoLiquido = item2.Peso;
				notaFiscalNotasFiscaisItens2.PesoBruto = item2.Peso;
				notaFiscalNotasFiscaisItens2.CalcularImposto(EnumFinalidadeNotaFiscal.Normal);
				item2.Status = EnumStatusPedidoCompraItem.Enviado;
				pesoBruto += item2.Peso;
				pesoLiquido += item2.Peso;
				num += item2.QuantidadeEmbalagem;
				list.Add(notaFiscalNotasFiscaisItens2);
			}
		}
		Itens = list;
		AcertaTotais();
		PesoBruto = pesoBruto;
		PesoLiquido = pesoLiquido;
		QuantidadeVolumes = num;
	}

	public void InsereFichaExpedicao(int codigoFichaExpedicao)
	{
		InsereFichaExpedicao(codigoFichaExpedicao, 0, entrega: false);
	}

	public void InsereFichaExpedicao(int codigoFichaExpedicao, int codigoCfop, bool entrega)
	{
		if (codigoFichaExpedicao <= 0)
		{
			return;
		}
		FichaExpedicao fichaExpedicao = ModuloExpedicao.ObterFichaExpedicao(codigoFichaExpedicao);
		if ((entrega && fichaExpedicao.EntidadeEntregaRef == null) || fichaExpedicao == null || (!entrega && fichaExpedicao.StatusFichaExpedicao != EnumStatusFichaExpedicao.Faturar && fichaExpedicao.StatusFichaExpedicao != EnumStatusFichaExpedicao.Separar && fichaExpedicao.StatusFichaExpedicao != EnumStatusFichaExpedicao.Embarcar) || fichaExpedicao.Itens == null || fichaExpedicao.Itens.Count <= 0 || (CodigoEntidade != 0 && CodigoEntidade != fichaExpedicao.CodigoEntidade))
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = true;
		bool flag5 = false;
		bool flag6 = false;
		try
		{
			flag = ModuloParametros.ObterParametros("Faturamento", "InserirComentarioItem").Valor == 1;
			flag2 = ModuloParametros.ObterParametros("Faturamento", "CodigoPedidoInformacaoesAdicionais").Valor == 1;
			flag5 = ModuloParametros.ObterParametros("Faturamento", "Tarifa Prioritaria").Valor == 1;
			flag3 = ModuloParametros.ObterParametros("Faturamento", "InserirLotes").Valor == 1;
			flag6 = ModuloParametros.ObterParametros("Vendas", "inserir comentario em textos legais da nota").Valor == 1;
		}
		catch
		{
		}
		decimal pesoBruto = PesoBruto;
		decimal pesoLiquido = PesoLiquido;
		int num = QuantidadeVolumes;
		bool flag7 = false;
		_matsCli = new Dictionary<int, EstoqueLoteMaterailClienteControle>();
		int num2 = 1;
		if (TextoLegal == null)
		{
			TextoLegal = string.Empty;
		}
		if (CodigoEntidade == 0)
		{
			if (string.IsNullOrWhiteSpace(SerieNotaFiscal))
			{
				IList<NotaFiscalSerie> list = ModuloNotaFiscal.ObterTodosNotaFiscalSerie(fichaExpedicao.CodigoSociedade);
				if (list != null && list.Count > 0)
				{
					CodigoSerieNF = list[list.Count - 1].CodigoSerie;
					SerieNotaFiscal = list[list.Count - 1].CodigoSerie.ToString();
				}
			}
			_dados.codigoFichaExpedicao = codigoFichaExpedicao;
			DataEmissao = DateTime.Now;
			DataSaida = DateTime.Now;
			SituacaoNfe = SituacaoNFe.NaoEnviada.ToString();
			TipoNotaEnum = EnumFinalidadeNotaFiscal.Normal;
			PortaoEntrega = fichaExpedicao.PortaoEntrega;
			CodigoEmpresa = fichaExpedicao.CodigoSociedade;
			if (entrega)
			{
				Entidade = fichaExpedicao.EntidadeEntregaRef;
			}
			else
			{
				Entidade = fichaExpedicao.EntidadeRef;
			}
			if (Entidade.Pais.ToUpper() != "BRASIL" && ValorCambio == 0m)
			{
				frmCadastrarCambio frmCadastrarCambio2 = new frmCadastrarCambio();
				((Form)(object)frmCadastrarCambio2).ShowDialog();
				if (((Form)(object)frmCadastrarCambio2).DialogResult == DialogResult.OK)
				{
					ValorCambio = frmCadastrarCambio2.Valor;
					if (ValorCambio == 0m)
					{
						ValorCambio = 1m;
					}
				}
			}
			if (fichaExpedicao.CodigoTransportadora > 0)
			{
				Transportadora = fichaExpedicao.TransportadoraRef;
				PlacaCaminhao = fichaExpedicao.PlacaCaminhao;
			}
			else if (CodigoTransportadora == 0 && fichaExpedicao.PedidoVenda != null && fichaExpedicao.PedidoVenda.CodigoTransportador > 0 && fichaExpedicao.PedidoVenda.Transportadora != null)
			{
				Transportadora = fichaExpedicao.PedidoVenda.Transportadora;
			}
			else
			{
				IsFreteCliente = true;
			}
			if (fichaExpedicao.PedidoVenda != null)
			{
				CodigoModalidadeFrete = fichaExpedicao.PedidoVenda.CodigoModoTransporteNotaFiscal;
				CodigoContaContabil = fichaExpedicao.PedidoVenda.CodigoContaContabil;
			}
			IsFretePagoPeloEmitente = fichaExpedicao.IsFretePago;
			if (fichaExpedicao.PedidoVenda != null)
			{
				if (!entrega && fichaExpedicao.PedidoVenda.EnderecoEntrega != null)
				{
					EntidadeEntregaStruct = fichaExpedicao.PedidoVenda.EntidadeEntrega;
					EnderecoEntidadeGPS enderecoEntrega = fichaExpedicao.PedidoVenda.EnderecoEntrega;
					TextoLegal = $"Local de Entrega: {enderecoEntrega.EntidadeRef.RazaoSocial} Cnpj: {enderecoEntrega.Cnpj}, {enderecoEntrega.Endereco} {enderecoEntrega.Complemento}, {enderecoEntrega.Cidade}, {enderecoEntrega.Uf}, {enderecoEntrega.CodigoPostal} - {TextoLegal}".Trim();
				}
				if (!entrega && flag4 && fichaExpedicao.PedidoVenda.EnderecoFaturamento != null)
				{
					EnderecoEntidadeGPS enderecoFaturamento = fichaExpedicao.PedidoVenda.EnderecoFaturamento;
					TextoLegal += $" Endereço Cobrança: {enderecoFaturamento.Endereco} {enderecoFaturamento.Complemento}, {enderecoFaturamento.Cidade}, {enderecoFaturamento.Uf}, {enderecoFaturamento.CodigoPostal}".Trim();
				}
				if (!entrega)
				{
					IsConsumidorFinal = fichaExpedicao.PedidoVenda.IsConsumidorFinal;
					CodigoCondicaoPagamento = fichaExpedicao.PedidoVenda.ModoPagamento;
					if (fichaExpedicao.PedidoVenda.MeioPagamento != null)
					{
						MeioPagamentoNotaFiscalEnum = fichaExpedicao.PedidoVenda.MeioPagamento.MeioPagamentoNotaFiscalEnum;
					}
				}
			}
			if (codigoCfop > 0)
			{
				flag7 = true;
				CFOP = ModuloNotaFiscal.ObterNotaFiscalCFOPs(codigoCfop);
			}
			else if (fichaExpedicao.Itens[0].PedidoVendaItemRef != null && fichaExpedicao.Itens[0].PedidoVendaItemRef.CodigoImpostoVenda > 0)
			{
				CFOP = ModuloNotaFiscal.ObterNotaFiscalCFOPs(fichaExpedicao.Itens[0].PedidoVendaItemRef.CodigoImpostoVenda);
			}
			else if (fichaExpedicao.Itens[0].CodigoCfopInterna > 0)
			{
				CFOP = ModuloNotaFiscal.ObterNotaFiscalCFOPs(fichaExpedicao.Itens[0].CodigoCfopInterna);
			}
			if (flag6 && !string.IsNullOrWhiteSpace(fichaExpedicao.ComentarioLongo))
			{
				TextoLegal += fichaExpedicao.ComentarioLongo;
			}
		}
		if (!entrega)
		{
			fichaExpedicao.CodigoNotaFiscal = _dados.numeroNotaFiscal;
			fichaExpedicao.StatusFichaExpedicao = EnumStatusFichaExpedicao.Faturado;
		}
		IList<NotaFiscalNotasFiscaisItens> list2 = new List<NotaFiscalNotasFiscaisItens>();
		if (Itens != null && Itens.Count > 0)
		{
			list2 = Itens;
			num2 = EnumerableExtensions.MaxOrDefault(list2.Select((NotaFiscalNotasFiscaisItens c) => c.Ordem), 0);
			num2++;
		}
		IList<FichaExpedicaoItem> itens = fichaExpedicao.Itens;
		NotaFiscalCFOPs notaFiscalCFOPs = new NotaFiscalCFOPs();
		foreach (FichaExpedicaoItem item in itens)
		{
			bool flag8 = flag5;
			notaFiscalCFOPs = new NotaFiscalCFOPs();
			if (!entrega && (item.CodigoNotaFiscal != 0 || item.ItemNotaFiscal != 0))
			{
				continue;
			}
			bool flag9 = true;
			if (num2 > 1)
			{
				foreach (NotaFiscalNotasFiscaisItens item2 in list2)
				{
					if (item2.CodigoFichaExpedicao == item.CodigoFichaExpedicao && item2.CodigoFichaExpedicaoItem == item.ItemFichaExpedicao)
					{
						flag9 = false;
					}
				}
			}
			if (!flag9)
			{
				continue;
			}
			if (item.ItensFaturamentoRef.Count > 0)
			{
				foreach (FichaExpedicaoItemFaturamento item3 in item.ItensFaturamentoRef)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item3.CodigoImpostoFaturamento);
					if (notaFiscalCFOPs == null || notaFiscalCFOPs.Id == 0)
					{
						string text = $"O Pedido: {item.CodigoPedido} Item: {item.ItemPedido} não possui imposto associado";
						MaxWaitDialog.FecharMensagem();
						XtraMessageBox.Show(text, "Atenção");
						throw new Exception(text);
					}
					notaFiscalCFOPs.IsConsumidorFinal = IsConsumidorFinal;
					if (notaFiscalCFOPs.ReducaoICMS == 0m)
					{
						notaFiscalCFOPs.ReducaoICMS = 100m;
					}
					if (notaFiscalCFOPs.CodigoTexto1 > 0 && notaFiscalCFOPs.Texto01 != null && (TextoLegal == null || !TextoLegal.Contains(notaFiscalCFOPs.Texto01.TextoLegal)))
					{
						TextoLegal += $" {notaFiscalCFOPs.Texto01.TextoLegal}";
					}
					if (notaFiscalCFOPs.CodigoTexto2 > 0 && notaFiscalCFOPs.Texto02 != null && (TextoLegal == null || !TextoLegal.Contains(notaFiscalCFOPs.Texto02.TextoLegal)))
					{
						TextoLegal += $" {notaFiscalCFOPs.Texto02.TextoLegal}";
					}
					TextoLegal = TextoLegal.Trim();
					if (CFOP == null && notaFiscalCFOPs != null)
					{
						CFOP = notaFiscalCFOPs;
					}
					if (Entidade.Pais.ToUpper() == "BRASIL")
					{
						if (Entidade.UF.ToUpper() != Emitente.Estado.ToUpper())
						{
							if (Entidade.UfRef == null)
							{
								XtraMessageBox.Show("UF do Cliente não encontrada. Favor checar o cadastro antes de continuar");
								return;
							}
							if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "5")
							{
								notaFiscalCFOPs.NumeracaoCFOP = string.Format("{0}{1}", "6", notaFiscalCFOPs.NumeracaoCFOP.Substring(1));
								if (notaFiscalCFOPs.UsarIcmsEstadoFederacao)
								{
									notaFiscalCFOPs.PadraoICMS = Entidade.UfRef.PercentualIcms;
								}
								if (notaFiscalCFOPs.IsConsumidorFinal && Entidade.CodigoIndIeDestinatario == 9 && notaFiscalCFOPs.NumeracaoCFOP.Substring(1, 3) == "101")
								{
									notaFiscalCFOPs.NumeracaoCFOP = "6.107";
									notaFiscalCFOPs.PadraoICMS = 18m;
								}
							}
							else if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "1")
							{
								notaFiscalCFOPs.NumeracaoCFOP = string.Format("{0}{1}", "2", notaFiscalCFOPs.NumeracaoCFOP.Substring(1));
								if (notaFiscalCFOPs.UsarIcmsEstadoFederacao)
								{
									notaFiscalCFOPs.PadraoICMS = Entidade.UfRef.PercentualIcms;
								}
							}
							if (NumeracaoCFOP.Substring(0, 1) == "5" || NumeracaoCFOP.Substring(0, 1) == "1")
							{
								NumeracaoCFOP = notaFiscalCFOPs.NumeracaoCFOP;
							}
						}
					}
					else if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) != "7" && notaFiscalCFOPs.NumeracaoCFOP.Substring(1) != "3")
					{
						if (CFOP == null || (!(CFOP.NumeracaoCFOP.Substring(0, 1) == "7") && !(CFOP.NumeracaoCFOP.Substring(0, 1) == "3")))
						{
							XtraMessageBox.Show("CFOP imcompativel com exportação / Importacao!!!");
							return;
						}
						notaFiscalCFOPs = CFOP;
					}
					NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = new NotaFiscalNotasFiscaisItens(isNovo: true);
					if (item.EstoqueRef != null)
					{
						notaFiscalNotasFiscaisItens.CodigoOrigemProduto = item.EstoqueRef.CodigoOrigem.ToString();
						notaFiscalNotasFiscaisItens.Cest = item.EstoqueRef.Cest;
						notaFiscalNotasFiscaisItens.CodigoFCI = item.EstoqueRef.CodigoFCI;
						notaFiscalNotasFiscaisItens.ChaveEstoqueRef = item.EstoqueRef.ChavePrimariaEstoque;
						if (item.EstoqueRef.EstoqueEanRef != null && !string.IsNullOrWhiteSpace(item.EstoqueRef.EstoqueEanRef.CodigoEAN))
						{
							notaFiscalNotasFiscaisItens.CodigoEan = item.EstoqueRef.EstoqueEanRef.CodigoEANComDigitoVerificador.Trim();
						}
					}
					notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = item3.Ncm;
					notaFiscalNotasFiscaisItens.CodigoEstadoDestinatario = Entidade.CodigoUf;
					notaFiscalNotasFiscaisItens.CFOPRef = notaFiscalCFOPs;
					if (item3.Sequencia == 1)
					{
						notaFiscalNotasFiscaisItens.CodigoFichaExpedicao = item.CodigoFichaExpedicao;
						notaFiscalNotasFiscaisItens.CodigoFichaExpedicaoItem = item.ItemFichaExpedicao;
						notaFiscalNotasFiscaisItens.CodigoPedidoVenda = item.CodigoPedido;
						notaFiscalNotasFiscaisItens.CodigoPedidoVendaItem = item.ItemPedido;
						notaFiscalNotasFiscaisItens.CodigoEmbalagem = item.CodigoEmbalagem;
						notaFiscalNotasFiscaisItens.QuantidadeEmbalagem = item.QuantidadeEmbalagem;
						notaFiscalNotasFiscaisItens.PecasPorEtiqueta = item.QuantidadePorEmbalagem;
						notaFiscalNotasFiscaisItens.PesoLiquido = item.PesoLiquido;
						notaFiscalNotasFiscaisItens.PesoBruto = item.PesoBruto;
						pesoBruto += item.PesoBruto;
						pesoLiquido += item.PesoLiquido;
						num += item.QuantidadeEmbalagem;
						notaFiscalNotasFiscaisItens.ValorFrete = item.CustoTransporte;
					}
					if (item3.CodigoContaConatbil > 0)
					{
						PlanoConta planoConta = ModuloFiscal.ObterPlanoConta(item3.CodigoContaConatbil);
						if (planoConta != null && planoConta.Conta.Length > 0)
						{
							notaFiscalNotasFiscaisItens.ContaContabilAnalitica = planoConta.Conta;
						}
					}
					notaFiscalNotasFiscaisItens.CodigoProduto = item3.CodigoProdutoFaturamento;
					notaFiscalNotasFiscaisItens.DescricaoProduto = item3.DescricaoProdutoFaturamento;
					notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item3.SiglaFaturamento;
					notaFiscalNotasFiscaisItens.Quantidade = item3.Quantidade;
					notaFiscalNotasFiscaisItens.ValorUnitario = item3.Valor;
					if (fichaExpedicao.PedidoVenda != null && !string.IsNullOrEmpty(fichaExpedicao.PedidoVenda.ReferenciaPedido))
					{
						notaFiscalNotasFiscaisItens.ContratoCliente = ((fichaExpedicao.PedidoVenda.ReferenciaPedido.Length < 15) ? fichaExpedicao.PedidoVenda.ReferenciaPedido : fichaExpedicao.PedidoVenda.ReferenciaPedido.Substring(0, 14));
						if (!string.IsNullOrEmpty(item3.Contrato))
						{
							notaFiscalNotasFiscaisItens.ContratoCliente = item3.Contrato;
						}
						if (item.PedidoVendaItemRef != null)
						{
							if (item3.ItemContrato > 0)
							{
								notaFiscalNotasFiscaisItens.ContratoClienteItem = item3.ItemContrato;
							}
							else if (item.PedidoVendaItemRef.NumeroItemFaturamento > 0)
							{
								notaFiscalNotasFiscaisItens.ContratoClienteItem = item.PedidoVendaItemRef.NumeroItemFaturamento;
							}
							else if (!string.IsNullOrWhiteSpace(item.ChamadaKanban) && int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban)) > 0)
							{
								notaFiscalNotasFiscaisItens.ContratoClienteItem = int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban));
							}
							else
							{
								notaFiscalNotasFiscaisItens.ContratoClienteItem = item.ItemPedido;
							}
							notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente = notaFiscalNotasFiscaisItens.ContratoCliente;
							notaFiscalNotasFiscaisItens.CodigoPedidoCompraItemCliente = item.PedidoVendaItemRef.CodigoItemPedido;
						}
					}
					notaFiscalNotasFiscaisItens.DescricaoProduto = notaFiscalNotasFiscaisItens.DescricaoProduto.Trim();
					decimal num3 = default(decimal);
					if ((notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "7" || notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "3") && ValorCambio > 0m)
					{
						notaFiscalNotasFiscaisItens.ValorUnitario *= ValorCambio;
					}
					notaFiscalNotasFiscaisItens.ValorUnitario = Math.Round(notaFiscalNotasFiscaisItens.ValorUnitario, 4);
					notaFiscalNotasFiscaisItens.CalcularImposto(TipoNotaEnum);
					StringBuilder stringBuilder = new StringBuilder();
					if (!string.IsNullOrWhiteSpace(item.Spool))
					{
						stringBuilder.Append($"Lote/Spool: {item.Spool} ");
					}
					if (flag && notaFiscalNotasFiscaisItens.PedidoVendaItemGPSRef != null && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens.PedidoVendaItemGPSRef.Comentario))
					{
						stringBuilder.Append(notaFiscalNotasFiscaisItens.PedidoVendaItemGPSRef.Comentario);
					}
					if (item3.Sequencia == 1 && flag3 && item.Lotes != null && item.Lotes.Count > 0)
					{
						stringBuilder.Append(" Qde-Lote:");
						foreach (FichaExpedicaoLote lote in item.Lotes)
						{
							stringBuilder.Append($" {lote.QuantidadeEntregue}-({lote.NumeroLote});");
						}
					}
					if (flag2 && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente))
					{
						string value = $"Pedido: {notaFiscalNotasFiscaisItens.ContratoCliente}";
						if (!stringBuilder.ToString().Contains(value))
						{
							stringBuilder.Append($" Pedido: {notaFiscalNotasFiscaisItens.ContratoCliente}/{notaFiscalNotasFiscaisItens.ContratoClienteItem}");
						}
					}
					if (!string.IsNullOrWhiteSpace(stringBuilder.ToString().Trim()))
					{
						notaFiscalNotasFiscaisItens.DescricaoComplementar = stringBuilder.ToString().Trim();
					}
					notaFiscalNotasFiscaisItens.Ordem = num2++;
					list2.Add(notaFiscalNotasFiscaisItens);
				}
			}
			else
			{
				if (item.PedidoVendaItemRef != null && !flag5)
				{
					flag8 = item.PedidoVendaItemRef.IsTarifaPrioritaria;
				}
				if (flag7)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(codigoCfop);
				}
				else if (flag8 && item.Tarifa != null && item.Tarifa.CodigoCfopInterna > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.Tarifa.CodigoCfopInterna);
				}
				else if (item.PedidoVendaItemRef != null && item.PedidoVendaItemRef.CodigoImpostoVenda > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.PedidoVendaItemRef.CodigoImpostoVenda);
				}
				else if (item.CodigoCfopInterna > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.CodigoCfopInterna);
				}
				else if (item.Tarifa != null && item.Tarifa.CodigoCfopInterna > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.Tarifa.CodigoCfopInterna);
				}
				else if (item.EstoqueRef != null && item.EstoqueRef.TarifaPadraoVenda != null)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.EstoqueRef.TarifaPadraoVenda.CodigoCfopInterna);
				}
				else if (item.EstoqueRef != null && item.EstoqueRef.CodigoImpostoVenda > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.EstoqueRef.CodigoImpostoVenda);
				}
				else if (CFOP != null)
				{
					notaFiscalCFOPs = CFOP;
				}
				if (!flag7 && flag8 && item.Tarifa != null && item.Tarifa.CodigoCfopInterna > 0)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item.Tarifa.CodigoCfopInterna);
				}
				if (notaFiscalCFOPs == null || notaFiscalCFOPs.Id == 0)
				{
					string text2 = $"O Pedido: {item.CodigoPedido} Item: {item.ItemPedido} não possui imposto associado";
					MaxWaitDialog.FecharMensagem();
					XtraMessageBox.Show(text2, "Atenção");
					throw new Exception(text2);
				}
				notaFiscalCFOPs.IsConsumidorFinal = IsConsumidorFinal;
				if (notaFiscalCFOPs.ReducaoICMS == 0m)
				{
					notaFiscalCFOPs.ReducaoICMS = 100m;
				}
				if (notaFiscalCFOPs.CodigoTexto1 > 0 && notaFiscalCFOPs.Texto01 != null && (TextoLegal == null || !TextoLegal.Contains(notaFiscalCFOPs.Texto01.TextoLegal)))
				{
					TextoLegal += $" {notaFiscalCFOPs.Texto01.TextoLegal}";
				}
				if (notaFiscalCFOPs.CodigoTexto2 > 0 && notaFiscalCFOPs.Texto02 != null && (TextoLegal == null || !TextoLegal.Contains(notaFiscalCFOPs.Texto02.TextoLegal)))
				{
					TextoLegal += $" {notaFiscalCFOPs.Texto02.TextoLegal}";
				}
				TextoLegal = TextoLegal.Trim();
				if (CFOP == null && notaFiscalCFOPs != null)
				{
					CFOP = notaFiscalCFOPs;
				}
				if (Entidade.Pais.ToUpper() == "BRASIL")
				{
					if (Entidade.UF.ToUpper() != Emitente.Estado.ToUpper())
					{
						if (Entidade.UfRef == null)
						{
							XtraMessageBox.Show("UF do Cliente não encontrada. Favor checar o cadastro antes de continuar");
							return;
						}
						if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "5")
						{
							notaFiscalCFOPs.NumeracaoCFOP = string.Format("{0}{1}", "6", notaFiscalCFOPs.NumeracaoCFOP.Substring(1));
							if (notaFiscalCFOPs.UsarIcmsEstadoFederacao)
							{
								notaFiscalCFOPs.PadraoICMS = Entidade.UfRef.PercentualIcms;
							}
							if (notaFiscalCFOPs.IsConsumidorFinal && Entidade.CodigoIndIeDestinatario == 9 && notaFiscalCFOPs.NumeracaoCFOP.Substring(1, 3) == "101")
							{
								notaFiscalCFOPs.NumeracaoCFOP = "6.107";
								notaFiscalCFOPs.PadraoICMS = 18m;
							}
						}
						else if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "1")
						{
							notaFiscalCFOPs.NumeracaoCFOP = string.Format("{0}{1}", "2", notaFiscalCFOPs.NumeracaoCFOP.Substring(1));
							if (notaFiscalCFOPs.UsarIcmsEstadoFederacao)
							{
								notaFiscalCFOPs.PadraoICMS = Entidade.UfRef.PercentualIcms;
							}
						}
						if (NumeracaoCFOP.Substring(0, 1) == "5" || NumeracaoCFOP.Substring(0, 1) == "1")
						{
							NumeracaoCFOP = notaFiscalCFOPs.NumeracaoCFOP;
						}
					}
				}
				else if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) != "7" && notaFiscalCFOPs.NumeracaoCFOP.Substring(1) != "3")
				{
					if (CFOP == null || (!(CFOP.NumeracaoCFOP.Substring(0, 1) == "7") && !(CFOP.NumeracaoCFOP.Substring(0, 1) == "3")))
					{
						XtraMessageBox.Show("CFOP imcompativel com exportação / Importacao!!!");
						return;
					}
					notaFiscalCFOPs = CFOP;
				}
				NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens2 = new NotaFiscalNotasFiscaisItens(isNovo: true);
				if (item.EstoqueRef != null)
				{
					notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = item.EstoqueRef.ClassificacaoFiscal;
					notaFiscalNotasFiscaisItens2.CodigoOrigemProduto = item.EstoqueRef.CodigoOrigem.ToString();
					notaFiscalNotasFiscaisItens2.Cest = item.EstoqueRef.Cest;
					notaFiscalNotasFiscaisItens2.CodigoFCI = item.EstoqueRef.CodigoFCI;
					notaFiscalNotasFiscaisItens2.ChaveEstoqueRef = item.EstoqueRef.ChavePrimariaEstoque;
					if (item.EstoqueRef.EstoqueEanRef != null && !string.IsNullOrWhiteSpace(item.EstoqueRef.EstoqueEanRef.CodigoEAN))
					{
						notaFiscalNotasFiscaisItens2.CodigoEan = item.EstoqueRef.EstoqueEanRef.CodigoEANComDigitoVerificador.Trim();
					}
				}
				else
				{
					notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = "00000000";
				}
				if (!string.IsNullOrWhiteSpace(item.PedidoVendaItemRef.ClassificacaoFiscal))
				{
					notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = item.PedidoVendaItemRef.ClassificacaoFiscal;
				}
				notaFiscalNotasFiscaisItens2.CodigoEstadoDestinatario = Entidade.CodigoUf;
				notaFiscalNotasFiscaisItens2.CFOPRef = notaFiscalCFOPs;
				notaFiscalNotasFiscaisItens2.CodigoFichaExpedicao = item.CodigoFichaExpedicao;
				notaFiscalNotasFiscaisItens2.CodigoFichaExpedicaoItem = item.ItemFichaExpedicao;
				notaFiscalNotasFiscaisItens2.CodigoPedidoVenda = item.CodigoPedido;
				notaFiscalNotasFiscaisItens2.CodigoPedidoVendaItem = item.ItemPedido;
				notaFiscalNotasFiscaisItens2.CodigoEmbalagem = item.CodigoEmbalagem;
				notaFiscalNotasFiscaisItens2.QuantidadeEmbalagem = item.QuantidadeEmbalagem;
				notaFiscalNotasFiscaisItens2.PecasPorEtiqueta = item.QuantidadePorEmbalagem;
				notaFiscalNotasFiscaisItens2.PesoLiquido = item.PesoLiquido;
				notaFiscalNotasFiscaisItens2.PesoBruto = item.PesoBruto;
				pesoBruto += item.PesoBruto;
				pesoLiquido += item.PesoLiquido;
				num += item.QuantidadeEmbalagem;
				if (item.IdContaContabil > 0)
				{
					PlanoConta planoConta2 = ModuloFiscal.ObterPlanoConta(item.IdContaContabil);
					if (planoConta2 != null && planoConta2.Conta.Length > 0)
					{
						notaFiscalNotasFiscaisItens2.ContaContabilAnalitica = planoConta2.Conta;
					}
				}
				else if (item.EstoqueRef != null && item.EstoqueRef.PlanoContaVenda != null)
				{
					notaFiscalNotasFiscaisItens2.ContaContabilAnalitica = item.EstoqueRef.PlanoContaVenda.Conta;
				}
				notaFiscalNotasFiscaisItens2.CodigoProduto = item.CodigoProduto;
				notaFiscalNotasFiscaisItens2.DescricaoProduto = item.DescricaoProduto;
				notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = "PC";
				notaFiscalNotasFiscaisItens2.Quantidade = item.QuantidadeEntregue;
				notaFiscalNotasFiscaisItens2.ValorUnitario = item.ValorVendaUnitario / (decimal)((item.CoeficienteProducao == 0) ? 1 : item.CoeficienteProducao);
				notaFiscalNotasFiscaisItens2.ValorFrete = item.CustoTransporte;
				if (fichaExpedicao.PedidoVenda != null && !string.IsNullOrEmpty(fichaExpedicao.PedidoVenda.ReferenciaPedido))
				{
					notaFiscalNotasFiscaisItens2.ContratoCliente = ((fichaExpedicao.PedidoVenda.ReferenciaPedido.Length < 15) ? fichaExpedicao.PedidoVenda.ReferenciaPedido : fichaExpedicao.PedidoVenda.ReferenciaPedido.Substring(0, 14));
					if (item.PedidoVendaItemRef != null)
					{
						notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = item.PedidoVendaItemRef.ClassificacaoFiscal;
						if (item.PedidoVendaItemRef.NumeroItemFaturamento > 0)
						{
							notaFiscalNotasFiscaisItens2.ContratoClienteItem = item.PedidoVendaItemRef.NumeroItemFaturamento;
						}
						else if (!string.IsNullOrWhiteSpace(item.ChamadaKanban) && int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban)) > 0)
						{
							notaFiscalNotasFiscaisItens2.ContratoClienteItem = int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban));
						}
						else
						{
							notaFiscalNotasFiscaisItens2.ContratoClienteItem = item.PedidoVendaItemRef.CodigoItemPedido;
						}
						notaFiscalNotasFiscaisItens2.CodigoPedidoCompraCliente = notaFiscalNotasFiscaisItens2.ContratoCliente;
						notaFiscalNotasFiscaisItens2.CodigoPedidoCompraItemCliente = notaFiscalNotasFiscaisItens2.ContratoClienteItem;
						notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = item.PedidoVendaItemRef.SiglaFaturamento;
					}
				}
				if ((!flag8 || item.Tarifa == null) && item.PedidoVendaItemRef != null)
				{
					if (item.PedidoVendaItemRef.ItensPorEmbalagem > 0)
					{
						notaFiscalNotasFiscaisItens2.PecasPorEtiqueta = item.PedidoVendaItemRef.ItensPorEmbalagem;
					}
					if (item.QuantidadePorEmbalagem > 0)
					{
						notaFiscalNotasFiscaisItens2.PecasPorEtiqueta = item.QuantidadePorEmbalagem;
					}
					notaFiscalNotasFiscaisItens2.CodigoProduto = item.PedidoVendaItemRef.CodigoProduto;
					notaFiscalNotasFiscaisItens2.DescricaoProduto = item.PedidoVendaItemRef.DescricaoProduto;
					if (!string.IsNullOrWhiteSpace(item.PedidoVendaItemRef.CodigoPecaExterno))
					{
						if (notaFiscalNotasFiscaisItens2.CodigoProduto.ToUpper().Equals(item.PedidoVendaItemRef.CodigoPecaExterno.ToUpper()))
						{
							notaFiscalNotasFiscaisItens2.DescricaoProduto = item.PedidoVendaItemRef.DescricaoProduto;
						}
						else
						{
							notaFiscalNotasFiscaisItens2.DescricaoProduto = $"{item.PedidoVendaItemRef.CodigoPecaExterno} - {item.PedidoVendaItemRef.DescricaoProduto}";
						}
						notaFiscalNotasFiscaisItens2.CodigoExterno = item.PedidoVendaItemRef.CodigoPecaExterno;
					}
					if (!string.IsNullOrEmpty(item.PedidoVendaItemRef.CodigoFamilia))
					{
						notaFiscalNotasFiscaisItens2.DescricaoProduto = $"{notaFiscalNotasFiscaisItens2.CodigoProduto} - {notaFiscalNotasFiscaisItens2.DescricaoProduto}";
						notaFiscalNotasFiscaisItens2.CodigoProduto = item.PedidoVendaItemRef.CodigoFamilia;
					}
					notaFiscalNotasFiscaisItens2.Quantidade = item.QuantidadeEntregue;
					if (fichaExpedicao == null || fichaExpedicao.PedidoVenda == null || fichaExpedicao.PedidoVenda.CodigoTipoPedido != 2)
					{
						notaFiscalNotasFiscaisItens2.ValorUnitario = item.PedidoVendaItemRef.PrecoNet / (decimal)((item.CoeficienteProducao == 0) ? 1 : item.CoeficienteProducao);
					}
					if (notaFiscalNotasFiscaisItens2.PecasPorEtiqueta > 0)
					{
						notaFiscalNotasFiscaisItens2.QuantidadeEmbalagem = (int)Math.Ceiling(notaFiscalNotasFiscaisItens2.Quantidade / (decimal)notaFiscalNotasFiscaisItens2.PecasPorEtiqueta);
					}
					notaFiscalNotasFiscaisItens2.ValorFrete = item.PedidoVendaItemRef.ValorFrete;
					if (item.PedidoVendaItemRef.Unidade > 0)
					{
						if (item.CoeficienteProducao > 1 && item.QuantidadeEntregue == (decimal)notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.Quantidade)
						{
							notaFiscalNotasFiscaisItens2.Quantidade = notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.QuantidadeNaUnidadeVenda;
						}
						else if (item.CoeficienteProducao > 1)
						{
							notaFiscalNotasFiscaisItens2.Quantidade = Math.Round(item.QuantidadeEntregue / (decimal)item.CoeficienteProducao, 1);
						}
						notaFiscalNotasFiscaisItens2.ValorUnitario = notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.PrecoNet;
						if (notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.UnidadePedidoRef != null)
						{
							notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.UnidadePedidoRef.Sigla;
							if (!string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento) && notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento.Length > 2)
							{
								notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento.Substring(0, 2);
							}
						}
					}
					if (notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.ValorFrete > 0m)
					{
						IsFretePagoPeloEmitente = true;
						notaFiscalNotasFiscaisItens2.ValorFrete = notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.ValorFrete;
						notaFiscalNotasFiscaisItens2.ValorOutros = notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.CustoDiverso;
						notaFiscalNotasFiscaisItens2.ValorSeguro = notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.ValorSeguro;
					}
					if (item.Tarifa != null)
					{
						if (!string.IsNullOrEmpty(item.Tarifa.Ncm))
						{
							notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = item.Tarifa.Ncm;
						}
						if (!string.IsNullOrEmpty(item.Tarifa.Fci))
						{
							notaFiscalNotasFiscaisItens2.CodigoFCI = item.Tarifa.Fci;
						}
						if ((item.CoeficienteProducao == 0 || item.CoeficienteProducao == 1) && item.Tarifa.FatorConversaoUnidadeFaturamento != 0m)
						{
							notaFiscalNotasFiscaisItens2.ValorUnitario *= item.Tarifa.FatorConversaoUnidadeFaturamento;
							notaFiscalNotasFiscaisItens2.Quantidade /= item.Tarifa.FatorConversaoUnidadeFaturamento;
							notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = item.Tarifa.SiglaUnidadeFaturamento;
						}
						if (!string.IsNullOrWhiteSpace(item.Tarifa.CodigoContratoEntrega))
						{
							notaFiscalNotasFiscaisItens2.ContratoCliente = item.Tarifa.CodigoContratoEntrega;
							if (!string.IsNullOrWhiteSpace(item.ChamadaKanban) && int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban)) > 0)
							{
								notaFiscalNotasFiscaisItens2.ContratoClienteItem = int.Parse(MetodosUteis.LimpaNro(item.ChamadaKanban));
							}
							if (item.Tarifa.CodigoContratoEntregaItem > 0)
							{
								notaFiscalNotasFiscaisItens2.ContratoClienteItem = item.Tarifa.CodigoContratoEntregaItem;
							}
							notaFiscalNotasFiscaisItens2.CodigoPedidoCompraCliente = item.Tarifa.CodigoContratoEntrega;
							notaFiscalNotasFiscaisItens2.CodigoPedidoCompraItemCliente = item.Tarifa.CodigoContratoEntregaItem;
						}
					}
				}
				else if (flag8 && item.Tarifa != null)
				{
					AjustarItemNotaFiscalBaseadoTarifaCliente(item, notaFiscalNotasFiscaisItens2);
				}
				if (!string.IsNullOrWhiteSpace(item.Contrato))
				{
					notaFiscalNotasFiscaisItens2.ContratoCliente = item.Contrato;
					notaFiscalNotasFiscaisItens2.CodigoPedidoCompraCliente = item.Contrato;
				}
				notaFiscalNotasFiscaisItens2.DescricaoProduto = notaFiscalNotasFiscaisItens2.DescricaoProduto.Trim();
				decimal num4 = default(decimal);
				if (CondicaoPagamentoRef != null && CondicaoPagamentoRef.Desconto > 0m)
				{
					num4 = CondicaoPagamentoRef.Desconto;
					notaFiscalNotasFiscaisItens2.ValorUnitario -= notaFiscalNotasFiscaisItens2.ValorUnitario * num4 / 100m;
				}
				if ((notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "7" || notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "3") && ValorCambio > 0m)
				{
					notaFiscalNotasFiscaisItens2.ValorUnitario *= ValorCambio;
				}
				if (item.ValorFaturamento > 0m)
				{
					notaFiscalNotasFiscaisItens2.ValorUnitario = item.ValorFaturamento;
				}
				notaFiscalNotasFiscaisItens2.ValorUnitario = Math.Round(notaFiscalNotasFiscaisItens2.ValorUnitario, 6);
				if (entrega && item.EstoqueRef != null)
				{
					notaFiscalNotasFiscaisItens2.ValorUnitario = item.EstoqueRef.PrecoBaseCompra;
				}
				notaFiscalNotasFiscaisItens2.CalcularImposto(TipoNotaEnum);
				StringBuilder stringBuilder2 = new StringBuilder();
				if (!string.IsNullOrWhiteSpace(item.Spool))
				{
					stringBuilder2.Append($"Lote/Spool: {item.Spool} ");
				}
				if (flag && notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef != null && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.Comentario))
				{
					stringBuilder2.Append(notaFiscalNotasFiscaisItens2.PedidoVendaItemGPSRef.Comentario);
				}
				if (flag3 && item.Lotes != null && item.Lotes.Count > 0)
				{
					stringBuilder2.Append(" Qde-Lote:");
					foreach (FichaExpedicaoLote lote2 in item.Lotes)
					{
						stringBuilder2.Append($" {lote2.QuantidadeEntregue}-({lote2.NumeroLote});");
					}
				}
				if (flag2 && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens2.CodigoPedidoCompraCliente))
				{
					string value2 = $"Pedido: {notaFiscalNotasFiscaisItens2.ContratoCliente}";
					if (!stringBuilder2.ToString().Contains(value2))
					{
						stringBuilder2.Append($" Pedido: {notaFiscalNotasFiscaisItens2.ContratoCliente}/{notaFiscalNotasFiscaisItens2.ContratoClienteItem}");
					}
				}
				if (!string.IsNullOrWhiteSpace(stringBuilder2.ToString().Trim()))
				{
					notaFiscalNotasFiscaisItens2.DescricaoComplementar = stringBuilder2.ToString().Trim();
				}
				if (Entidade != null && Entidade.IdNormaEdi == 5)
				{
					notaFiscalNotasFiscaisItens2.DescricaoComplementar = string.Format("{0}{1}{2}{3}", "IAP01", notaFiscalNotasFiscaisItens2.CodigoExterno.PadLeft(11, '0'), " ".PadRight(19), notaFiscalNotasFiscaisItens2.ContratoCliente.PadRight(12, ' '));
				}
				notaFiscalNotasFiscaisItens2.Ordem = num2++;
				bool flag10 = false;
				list2.Add(notaFiscalNotasFiscaisItens2);
			}
			bool flag11 = ModuloParametros.ObterParametros("Faturamento", "DevolverMaterialCliente").Valor == 1;
			if (!entrega && flag11)
			{
				Estoque estoque = null;
				if (item.EstoqueRef != null && item.IsItemCliente)
				{
					estoque = item.EstoqueRef;
				}
				if (estoque != null && estoque.DevolverMateriaClienteAutomatico && !string.IsNullOrEmpty(estoque.CodigoProduto) && item.OrdemFabricacaoProduto == 0)
				{
					num2 = CalculoMaterialCliente(num2, (List<NotaFiscalNotasFiscaisItens>)list2, estoque, (int)item.QuantidadeEntregue, null);
				}
			}
		}
		Itens = list2;
		PesoBruto = pesoBruto;
		PesoLiquido = pesoLiquido;
		QuantidadeVolumes = num;
		AcertaTotais();
		if (fichaExpedicao.IsReagruparFaturamento && fichaExpedicao.PedidoVenda != null && fichaExpedicao.PedidoVenda.IsReagruparFaturamento && XtraMessageBox.Show("Deseja reagrupar os itens iguais na nota fiscal?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			ModuloNotaFiscal.InserirNotaFiscalNotasFiscais(this);
			MarcarExistente();
			ReagruparItensSemelhanteNotaFiscal();
		}
	}

	private static void AjustarItemNotaFiscalBaseadoTarifaCliente(FichaExpedicaoItem item, NotaFiscalNotasFiscaisItens novo)
	{
		novo.ValorUnitario = item.Tarifa.PrecoTarifaCatalogo;
		if (!string.IsNullOrWhiteSpace(item.Tarifa.CodigoContratoEntrega))
		{
			novo.CodigoPedidoCompraCliente = item.Tarifa.CodigoContratoEntrega;
			novo.ContratoCliente = item.Tarifa.CodigoContratoEntrega;
			if (item.Tarifa.CodigoContratoEntregaItem > 0)
			{
				novo.CodigoPedidoCompraItemCliente = item.Tarifa.CodigoContratoEntregaItem;
				novo.ContratoClienteItem = item.Tarifa.CodigoContratoEntregaItem;
			}
		}
		novo.ChaveEstoqueRef = item.Tarifa.ChavePrimariaEstoque;
		if (item.Tarifa.SiglaUnidadeFaturamento.Length > 1)
		{
			novo.SiglaUnidadeFaturamento = item.Tarifa.SiglaUnidadeFaturamento.ToUpper();
		}
		if (!string.IsNullOrWhiteSpace(item.Tarifa.CodigoProdutoEntidade))
		{
			if (novo.CodigoProduto.ToUpper().Equals(item.Tarifa.CodigoProdutoEntidade.ToUpper()) && !item.Tarifa.IsAdicionaCodigoExternaDescricaoNF)
			{
				novo.DescricaoProduto = item.Tarifa.DescricaoProdutoEntidade;
			}
			else
			{
				novo.DescricaoProduto = $"{item.Tarifa.CodigoProdutoEntidade} - {item.Tarifa.DescricaoProdutoEntidade}";
			}
			novo.CodigoExterno = item.Tarifa.CodigoProdutoEntidade;
		}
		if (item.Tarifa != null && item.Tarifa.FatorConversaoUnidadeFaturamento != 1m && item.Tarifa.FatorConversaoUnidadeFaturamento != 0m)
		{
			novo.ValorUnitario *= item.Tarifa.FatorConversaoUnidadeFaturamento;
			novo.Quantidade /= item.Tarifa.FatorConversaoUnidadeFaturamento;
		}
		if (item.Tarifa.ContaContabilVendaReduzida > 0)
		{
			PlanoConta planoConta = ModuloFiscal.ObterPlanoConta(item.Tarifa.ContaContabilVendaReduzida);
			if (planoConta != null && planoConta.Conta.Length > 0)
			{
				novo.ContaContabilAnalitica = planoConta.Conta;
			}
		}
		item.ValorFaturamento = novo.ValorUnitario;
		if (!string.IsNullOrEmpty(item.Tarifa.Ncm))
		{
			novo.CodigoClassificacaoFiscal = item.Tarifa.Ncm;
		}
		if (!string.IsNullOrEmpty(item.Tarifa.Fci))
		{
			novo.CodigoClassificacaoFiscal = item.Tarifa.Fci;
		}
	}

	private int CalculoMaterialCliente(int ordem, List<NotaFiscalNotasFiscaisItens> nfItens, Estoque itemCliente, int quantidadeEntregue, EstruturaProdutoComponente estruturaProdutoComponente)
	{
		if (itemCliente != null && itemCliente.IsClienteProprietario)
		{
			ordem = AdicionarMaterialCliente(ordem, nfItens, itemCliente, quantidadeEntregue, estruturaProdutoComponente);
			if (itemCliente.TipoEstoque == EnumTipoEstoque.Fabricado && itemCliente.TipoProduto == 1)
			{
				EstruturaProduto estruturaProduto = itemCliente.EstruturaProduto;
				if (estruturaProduto != null && estruturaProduto.Componentes != null && estruturaProduto.Componentes.Count > 0)
				{
					foreach (EstruturaProdutoComponente componente in estruturaProduto.Componentes)
					{
						if (componente.Estoque != null)
						{
							ordem = CalculoMaterialCliente(ordem, nfItens, componente.Estoque, quantidadeEntregue * componente.QdeComponente, componente);
						}
					}
				}
			}
		}
		return ordem;
	}

	private int AdicionarMaterialCliente(int ordem, List<NotaFiscalNotasFiscaisItens> nfItens, Estoque itemCliente, int quantidadeEntregue, EstruturaProdutoComponente estruturaProdutoComponente)
	{
		if (itemCliente.IsClienteProprietario && itemCliente.TipoEstoque == EnumTipoEstoque.Fabricado && itemCliente.Processo != null && itemCliente.Processo.MateriasPrima != null)
		{
			foreach (ProcessoMateriaPrima item in itemCliente.Processo.MateriasPrima)
			{
				if (item.Codigo.StartsWith("86040"))
				{
					string text = "";
				}
				if (!item.IsCliente)
				{
					continue;
				}
				decimal num = default(decimal);
				num = ((item.Unidade != EnumUnidade.PeçasPorChapa || !(item.Necessidade > 0m)) ? ((decimal)quantidadeEntregue * item.Quantidade * item.Necessidade * (1m + item.PercentualPerda / 100m)) : Math.Ceiling((decimal)quantidadeEntregue / item.Necessidade));
				if (item.EstoqueRef != null && item.EstoqueRef.ValorConversao > 0m && item.EstoqueRef.ValorConversao != 1m)
				{
					num *= item.EstoqueRef.ValorConversao;
				}
				num = Math.Round(num, 4);
				IList<EstoqueLoteMaterailClienteControle> list = ModuloEngenharia.ObterTodosEstoqueLoteMaterailClienteControle(item.ChaveEstoque, somenteComSaldo: false);
				NotaFiscalCFOPs notaFiscalCFOPs = null;
				Estoque estoque = ModuloEngenharia.ObterProdutoEstoque(item.ChaveEstoque);
				if (estoque != null)
				{
					notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(estoque.CodigoImpostoVenda);
				}
				if (item.PossuiAlternativo)
				{
					foreach (ProcessoMateriaOpcional item2 in item.MateriasAlternativasRef)
					{
						if (!item2.IsCliente)
						{
							continue;
						}
						IList<EstoqueLoteMaterailClienteControle> list2 = ModuloEngenharia.ObterTodosEstoqueLoteMaterailClienteControle(item2.ChaveMateriaAlternativa, somenteComSaldo: false);
						foreach (EstoqueLoteMaterailClienteControle item3 in list2)
						{
							list.Add(item3);
							if (notaFiscalCFOPs == null && item3.EstoqueRef.CodigoImpostoVenda > 0)
							{
								notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item3.EstoqueRef.CodigoImpostoVenda);
							}
						}
					}
				}
				IList<EstoqueLoteMaterailClienteControle> list3 = (from c in list
					where c.QuantidadeADevolver > 0m && !c.IsFechado
					orderby c.DataRecebimento, c.CodigoNotaFiscalRecebimento
					select c).ToList();
				foreach (EstoqueLoteMaterailClienteControle item4 in list3)
				{
					if (!(num > 0m))
					{
						continue;
					}
					XmlProduto xmlProduto = ModuloXml.ObterXmlProduto(FichaExpedicaoRef.EntidadeRef.CNPJLimpo, item4.CodigoNotaFiscalRecebimento, item4.CodigoItemNotaFiscal);
					NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = new NotaFiscalNotasFiscaisItens();
					notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = xmlProduto.CodigoNcm;
					notaFiscalNotasFiscaisItens.ChaveEstoqueRef = item4.ChaveEstoqueRef;
					notaFiscalNotasFiscaisItens.CFOPRef = notaFiscalCFOPs;
					if (item4.EstoqueRef != null && item4.EstoqueRef.PlanoContaVenda != null)
					{
						notaFiscalNotasFiscaisItens.ContaContabilAnalitica = item4.EstoqueRef.PlanoContaVenda.Conta;
					}
					notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente = item4.CodigoNotaFiscalRecebimento.ToString();
					notaFiscalNotasFiscaisItens.CodigoPedidoCompraItemCliente = item4.CodigoItemNotaFiscal;
					notaFiscalNotasFiscaisItens.CodigoProduto = xmlProduto.CodigoProduto;
					notaFiscalNotasFiscaisItens.CodigoExterno = xmlProduto.CodigoProduto;
					notaFiscalNotasFiscaisItens.CodigoSerieNotaFiscal = 0;
					notaFiscalNotasFiscaisItens.DescricaoProduto = xmlProduto.DescricaoProduto;
					notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = xmlProduto.UnidadeComercial;
					notaFiscalNotasFiscaisItens.ValorUnitario = xmlProduto.ValorUnitarioComercial;
					if (!_matsCli.ContainsKey(item4.Id))
					{
						_matsCli.Add(item4.Id, item4);
					}
					if (num <= item4.QuantidadeADevolver)
					{
						_matsCli[item4.Id].QuantidadeDevolvida += num;
						notaFiscalNotasFiscaisItens.Quantidade = num;
						num = default(decimal);
						if (_matsCli[item4.Id].QuantidadeADevolver <= 0m)
						{
							_matsCli[item4.Id].IsFechado = true;
						}
					}
					else
					{
						notaFiscalNotasFiscaisItens.Quantidade = _matsCli[item4.Id].QuantidadeADevolver;
						num -= _matsCli[item4.Id].QuantidadeADevolver;
						_matsCli[item4.Id].QuantidadeDevolvida = _matsCli[item4.Id].QuantidadeRecebida;
						_matsCli[item4.Id].IsFechado = true;
					}
					notaFiscalNotasFiscaisItens.DescricaoComplementar = $"Devolução Ref à NF: {item4.CodigoNotaFiscalRecebimento}, item {item4.CodigoItemNotaFiscal}, NFE: {item4.ChaveEletronicaRecebimento}, Codigo Interno: {item4.CodigoProduto} {item.CodigoProcesso}";
					notaFiscalNotasFiscaisItens.CodigoRecebimentoMaterialCliente = item4.Id;
					notaFiscalNotasFiscaisItens.Quantidade = Math.Round(notaFiscalNotasFiscaisItens.Quantidade, 4);
					notaFiscalNotasFiscaisItens.CalcularImposto(EnumFinalidadeNotaFiscal.Normal);
					if (notaFiscalNotasFiscaisItens.Quantidade > 0m)
					{
						notaFiscalNotasFiscaisItens.Ordem = ordem++;
						nfItens.Add(notaFiscalNotasFiscaisItens);
					}
				}
				if (num > 0m)
				{
					EstoqueLoteMaterailClienteControle estoqueLoteMaterailClienteControle = (from c in list
						orderby c.DataRecebimento descending, c.CodigoNotaFiscalRecebimento descending
						select c).FirstOrDefault();
					if (estoqueLoteMaterailClienteControle != null)
					{
						XmlProduto xmlProduto2 = ModuloXml.ObterXmlProduto(FichaExpedicaoRef.EntidadeRef.CNPJLimpo, estoqueLoteMaterailClienteControle.CodigoNotaFiscalRecebimento, estoqueLoteMaterailClienteControle.CodigoItemNotaFiscal);
						NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens2 = new NotaFiscalNotasFiscaisItens();
						notaFiscalNotasFiscaisItens2.CodigoClassificacaoFiscal = xmlProduto2.CodigoNcm;
						notaFiscalNotasFiscaisItens2.ChaveEstoqueRef = estoqueLoteMaterailClienteControle.ChaveEstoqueRef;
						notaFiscalNotasFiscaisItens2.CFOPRef = notaFiscalCFOPs;
						notaFiscalNotasFiscaisItens2.CodigoPedidoCompraCliente = estoqueLoteMaterailClienteControle.CodigoNotaFiscalRecebimento.ToString();
						notaFiscalNotasFiscaisItens2.CodigoPedidoCompraItemCliente = estoqueLoteMaterailClienteControle.CodigoItemNotaFiscal;
						notaFiscalNotasFiscaisItens2.CodigoProduto = xmlProduto2.CodigoProduto;
						notaFiscalNotasFiscaisItens2.CodigoExterno = xmlProduto2.CodigoProduto;
						notaFiscalNotasFiscaisItens2.CodigoSerieNotaFiscal = 0;
						notaFiscalNotasFiscaisItens2.DescricaoProduto = xmlProduto2.DescricaoProduto;
						notaFiscalNotasFiscaisItens2.SiglaUnidadeFaturamento = xmlProduto2.UnidadeComercial;
						notaFiscalNotasFiscaisItens2.ValorUnitario = xmlProduto2.ValorUnitarioComercial;
						if (!_matsCli.ContainsKey(estoqueLoteMaterailClienteControle.Id))
						{
							_matsCli.Add(estoqueLoteMaterailClienteControle.Id, estoqueLoteMaterailClienteControle);
						}
						_matsCli[estoqueLoteMaterailClienteControle.Id].QuantidadeDevolvida += num;
						notaFiscalNotasFiscaisItens2.Quantidade = num;
						num = default(decimal);
						if (_matsCli[estoqueLoteMaterailClienteControle.Id].QuantidadeADevolver <= 0m)
						{
							_matsCli[estoqueLoteMaterailClienteControle.Id].IsFechado = true;
						}
						notaFiscalNotasFiscaisItens2.DescricaoComplementar = $"Devolução Ref à NF: {estoqueLoteMaterailClienteControle.CodigoNotaFiscalRecebimento}, item {estoqueLoteMaterailClienteControle.CodigoItemNotaFiscal}, NFE: {estoqueLoteMaterailClienteControle.ChaveEletronicaRecebimento}, Codigo Interno: {estoqueLoteMaterailClienteControle.CodigoProduto}";
						notaFiscalNotasFiscaisItens2.CodigoRecebimentoMaterialCliente = estoqueLoteMaterailClienteControle.Id;
						notaFiscalNotasFiscaisItens2.CalcularImposto(EnumFinalidadeNotaFiscal.Normal);
						if (notaFiscalNotasFiscaisItens2.Quantidade > 0m)
						{
							notaFiscalNotasFiscaisItens2.Ordem = ordem++;
							nfItens.Add(notaFiscalNotasFiscaisItens2);
						}
					}
				}
				if (num > 0m)
				{
					MaxWaitDialog.FecharMensagem();
					MaxCaixaMensagem.ShowAtencaoOK($"Impossível Devolver o item: {item.Codigo}\r\nNenhuma Nota Fiscal encontrada");
					MaxWaitDialog.MostrarMensagem("Gerando Nota Fiscal");
				}
			}
		}
		else if (itemCliente.IsClienteProprietario && itemCliente.TipoEstoque == EnumTipoEstoque.Comprado)
		{
			decimal num2 = quantidadeEntregue;
			IList<EstoqueLoteMaterailClienteControle> list4 = ModuloEngenharia.ObterTodosEstoqueLoteMaterailClienteControle(itemCliente.ChavePrimariaEstoque, somenteComSaldo: false);
			NotaFiscalCFOPs notaFiscalCFOPs2 = null;
			if (itemCliente != null)
			{
				notaFiscalCFOPs2 = ModuloNotaFiscal.ObterNotaFiscalCFOPs(itemCliente.CodigoImpostoVenda);
			}
			if (estruturaProdutoComponente.PossuiAlternativo)
			{
				foreach (EstruturaComponentesAlternativos componentesAlternativo in estruturaProdutoComponente.ComponentesAlternativos)
				{
					if (!componentesAlternativo.IsClienteProprietario)
					{
						continue;
					}
					IList<EstoqueLoteMaterailClienteControle> list5 = ModuloEngenharia.ObterTodosEstoqueLoteMaterailClienteControle(componentesAlternativo.ChaveEstoqueProdutoAlternativo, somenteComSaldo: false);
					foreach (EstoqueLoteMaterailClienteControle item5 in list5)
					{
						list4.Add(item5);
						if (notaFiscalCFOPs2 == null && item5.EstoqueRef.CodigoImpostoVenda > 0)
						{
							notaFiscalCFOPs2 = ModuloNotaFiscal.ObterNotaFiscalCFOPs(item5.EstoqueRef.CodigoImpostoVenda);
						}
					}
				}
			}
			IList<EstoqueLoteMaterailClienteControle> list6 = (from c in list4
				where c.QuantidadeADevolver > 0m
				orderby c.DataRecebimento, c.CodigoNotaFiscalRecebimento
				select c).ToList();
			foreach (EstoqueLoteMaterailClienteControle item6 in list6)
			{
				if (!(num2 > 0m))
				{
					continue;
				}
				XmlProduto xmlProduto3 = ModuloXml.ObterXmlProduto(FichaExpedicaoRef.EntidadeRef.CNPJLimpo, item6.CodigoNotaFiscalRecebimento, item6.CodigoItemNotaFiscal);
				NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens3 = new NotaFiscalNotasFiscaisItens();
				notaFiscalNotasFiscaisItens3.CodigoClassificacaoFiscal = xmlProduto3.CodigoNcm;
				notaFiscalNotasFiscaisItens3.ChaveEstoqueRef = item6.ChaveEstoqueRef;
				notaFiscalNotasFiscaisItens3.CFOPRef = notaFiscalCFOPs2;
				notaFiscalNotasFiscaisItens3.CodigoPedidoCompraCliente = item6.CodigoNotaFiscalRecebimento.ToString();
				notaFiscalNotasFiscaisItens3.CodigoPedidoCompraItemCliente = item6.CodigoItemNotaFiscal;
				notaFiscalNotasFiscaisItens3.CodigoProduto = xmlProduto3.CodigoProduto;
				notaFiscalNotasFiscaisItens3.CodigoExterno = xmlProduto3.CodigoProduto;
				notaFiscalNotasFiscaisItens3.CodigoSerieNotaFiscal = 0;
				notaFiscalNotasFiscaisItens3.DescricaoProduto = xmlProduto3.DescricaoProduto;
				notaFiscalNotasFiscaisItens3.SiglaUnidadeFaturamento = xmlProduto3.UnidadeComercial;
				notaFiscalNotasFiscaisItens3.ValorUnitario = xmlProduto3.ValorUnitarioComercial;
				if (!_matsCli.ContainsKey(item6.Id))
				{
					_matsCli.Add(item6.Id, item6);
				}
				if (num2 <= item6.QuantidadeADevolver)
				{
					_matsCli[item6.Id].QuantidadeDevolvida += num2;
					notaFiscalNotasFiscaisItens3.Quantidade = num2;
					num2 = default(decimal);
					if (_matsCli[item6.Id].QuantidadeADevolver <= 0m)
					{
						_matsCli[item6.Id].IsFechado = true;
					}
				}
				else
				{
					notaFiscalNotasFiscaisItens3.Quantidade = _matsCli[item6.Id].QuantidadeADevolver;
					num2 -= _matsCli[item6.Id].QuantidadeADevolver;
					_matsCli[item6.Id].QuantidadeDevolvida = _matsCli[item6.Id].QuantidadeRecebida;
					_matsCli[item6.Id].IsFechado = true;
				}
				notaFiscalNotasFiscaisItens3.DescricaoComplementar = $"Devolução Ref à NF: {item6.CodigoNotaFiscalRecebimento}, item {item6.CodigoItemNotaFiscal}, NFE: {item6.ChaveEletronicaRecebimento}, Codigo Interno: {item6.CodigoProduto}";
				notaFiscalNotasFiscaisItens3.CodigoRecebimentoMaterialCliente = item6.Id;
				notaFiscalNotasFiscaisItens3.CalcularImposto(EnumFinalidadeNotaFiscal.Normal);
				if (notaFiscalNotasFiscaisItens3.Quantidade > 0m)
				{
					notaFiscalNotasFiscaisItens3.Ordem = ordem++;
					nfItens.Add(notaFiscalNotasFiscaisItens3);
				}
			}
			if (num2 > 0m)
			{
				EstoqueLoteMaterailClienteControle estoqueLoteMaterailClienteControle2 = new EstoqueLoteMaterailClienteControle();
				estoqueLoteMaterailClienteControle2 = (from c in list4
					orderby c.DataRecebimento descending, c.CodigoNotaFiscalRecebimento descending
					select c).FirstOrDefault();
				if (estoqueLoteMaterailClienteControle2 != null)
				{
					XmlProduto xmlProduto4 = ModuloXml.ObterXmlProduto(FichaExpedicaoRef.EntidadeRef.CNPJLimpo, estoqueLoteMaterailClienteControle2.CodigoNotaFiscalRecebimento, estoqueLoteMaterailClienteControle2.CodigoItemNotaFiscal);
					NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens4 = new NotaFiscalNotasFiscaisItens();
					notaFiscalNotasFiscaisItens4.CodigoClassificacaoFiscal = xmlProduto4.CodigoNcm;
					notaFiscalNotasFiscaisItens4.ChaveEstoqueRef = estoqueLoteMaterailClienteControle2.ChaveEstoqueRef;
					notaFiscalNotasFiscaisItens4.CFOPRef = notaFiscalCFOPs2;
					notaFiscalNotasFiscaisItens4.CodigoPedidoCompraCliente = estoqueLoteMaterailClienteControle2.CodigoNotaFiscalRecebimento.ToString();
					notaFiscalNotasFiscaisItens4.CodigoPedidoCompraItemCliente = estoqueLoteMaterailClienteControle2.CodigoItemNotaFiscal;
					notaFiscalNotasFiscaisItens4.CodigoProduto = xmlProduto4.CodigoProduto;
					notaFiscalNotasFiscaisItens4.CodigoExterno = xmlProduto4.CodigoProduto;
					notaFiscalNotasFiscaisItens4.CodigoSerieNotaFiscal = 0;
					notaFiscalNotasFiscaisItens4.DescricaoProduto = xmlProduto4.DescricaoProduto;
					notaFiscalNotasFiscaisItens4.SiglaUnidadeFaturamento = xmlProduto4.UnidadeComercial;
					notaFiscalNotasFiscaisItens4.ValorUnitario = xmlProduto4.ValorUnitarioComercial;
					if (!_matsCli.ContainsKey(estoqueLoteMaterailClienteControle2.Id))
					{
						_matsCli.Add(estoqueLoteMaterailClienteControle2.Id, estoqueLoteMaterailClienteControle2);
					}
					_matsCli[estoqueLoteMaterailClienteControle2.Id].QuantidadeDevolvida += num2;
					notaFiscalNotasFiscaisItens4.Quantidade = num2;
					num2 = default(decimal);
					if (_matsCli[estoqueLoteMaterailClienteControle2.Id].QuantidadeADevolver <= 0m)
					{
						_matsCli[estoqueLoteMaterailClienteControle2.Id].IsFechado = true;
					}
					notaFiscalNotasFiscaisItens4.DescricaoComplementar = $"Devolução Ref à NF: {estoqueLoteMaterailClienteControle2.CodigoNotaFiscalRecebimento}, item {estoqueLoteMaterailClienteControle2.CodigoItemNotaFiscal}, NFE: {estoqueLoteMaterailClienteControle2.ChaveEletronicaRecebimento}, Codigo Interno: {estoqueLoteMaterailClienteControle2.CodigoProduto}";
					notaFiscalNotasFiscaisItens4.CodigoRecebimentoMaterialCliente = estoqueLoteMaterailClienteControle2.Id;
					notaFiscalNotasFiscaisItens4.CalcularImposto(EnumFinalidadeNotaFiscal.Normal);
					if (notaFiscalNotasFiscaisItens4.Quantidade > 0m)
					{
						notaFiscalNotasFiscaisItens4.Ordem = ordem++;
						nfItens.Add(notaFiscalNotasFiscaisItens4);
					}
				}
			}
			if (num2 > 0m)
			{
				MaxWaitDialog.FecharMensagem();
				MaxCaixaMensagem.ShowAtencaoOK($"Impossível Devolver o item: {itemCliente.CodigoProduto}\r\nNenhuma Nota Fiscal encontrada");
				MaxWaitDialog.MostrarMensagem("Gerando Nota Fiscal");
			}
		}
		return ordem;
	}

	public void AcertaTotais()
	{
		ValorBaseICMS = 0m;
		ValorICMS = 0m;
		ValorIPI = 0m;
		decimal valorTotalFatura = default(decimal);
		ValorPIS = 0m;
		ValorCofins = 0m;
		ValorCSLL = 0m;
		ValorPISRetido = 0m;
		ValorCofinsRetido = 0m;
		ValorFrete = 0m;
		ValorProdutos = 0m;
		ValorTotalNotaFiscal = 0m;
		ValorICMSSubstituto = 0m;
		ValorBaseICMSSubstituto = 0m;
		ValorImpostoImportacao = 0m;
		ValorSeguro = 0m;
		ValorOutrasDespesas = 0m;
		ValorTotalIcmsInterestadualFundoPobreza = 0m;
		ValorTotalIcmsInterestadualUfDestino = 0m;
		ValorTotalIcmsInterestadualUfEnvolvidas = 0m;
		ValorCreditoIcms = 0m;
		PercentualCreditoIcms = 0m;
		ValorDesconto = 0m;
		ValorIcmsDesonerado = 0m;
		ValorFundoCombatePobreza = 0m;
		ValorFundoCombatePobrezaST = 0m;
		foreach (NotaFiscalNotasFiscaisItens iten in Itens)
		{
			if (!string.IsNullOrWhiteSpace(iten.NomeCfop) && iten.NomeCfop.Substring(0, 1) == "3")
			{
				isImportacao = true;
			}
			if (!(iten.TipoIncidenciaIcms == "201") && !(iten.TipoIncidenciaIcms == "202"))
			{
				ValorBaseICMS += iten.ValorBaseICMS;
				ValorICMS += iten.ValorICMS;
			}
			ValorDesconto += iten.ValorDesconto;
			ValorIcmsDesonerado += iten.ValorIcmsDesonerado;
			ValorBaseICMSSubstituto += iten.ValorBaseAgragadaICMSST;
			ValorIPI += iten.ValorIPI;
			ValorPIS += iten.ValorPIS;
			ValorCofins += iten.ValorCofins;
			ValorCSLL += iten.ValorCsll;
			ValorPISRetido += iten.ValorRetencaoPis;
			ValorCofinsRetido += iten.ValorRetencaoCofins;
			ValorFrete += iten.ValorFrete;
			ValorICMSSubstituto += iten.ValorICMSSTAgregado;
			ValorImpostoImportacao += iten.ValorImpostoImportacao;
			ValorSeguro += iten.ValorSeguro;
			ValorOutrasDespesas += iten.ValorOutros;
			ValorProdutos += iten.ValorTotal;
			ValorTotalIcmsInterestadualFundoPobreza += iten.ValorIcmsInterestadualFundoPobreza;
			ValorTotalIcmsInterestadualUfDestino += iten.ValorIcmsInterestadualUfDestino;
			ValorTotalIcmsInterestadualUfEnvolvidas += iten.ValorIcmsInterestadualUfEnvolvidas;
			ValorCreditoIcms += iten.ValorCreditoIcms;
			ValorFundoCombatePobreza += iten.ValorFundoCombatePobreza;
			ValorFundoCombatePobrezaST += iten.ValorFundoCombatePobrezaST;
			if (iten.ValorFatura > 0m)
			{
				valorTotalFatura += iten.ValorFatura + iten.ValorIPI + iten.ValorICMSSTAgregado;
			}
		}
		ValorTotalFatura = valorTotalFatura;
		AtualizaTotais();
		RecalcularFaturas();
	}

	public void RecalcularFaturas()
	{
		if (IsBloquearRecalculoFatura)
		{
			return;
		}
		if (ValorTotalFatura > 0m)
		{
			if (TipoNotaEnum == EnumFinalidadeNotaFiscal.Normal)
			{
				decimal adicionarPrimeira = default(decimal);
				if (ModuloParametros.ObterParametros("Faturamento", "Inserir IPI primeira parcela").Valor == 1)
				{
					adicionarPrimeira += ValorIPI;
				}
				if (ModuloParametros.ObterParametros("Faturamento", "Inserir ICMSST primeira parcela").Valor == 1)
				{
					adicionarPrimeira += ValorICMSSubstituto;
				}
				if (ModuloParametros.ObterParametros("Faturamento", "Inserir PIS primeira parcela").Valor == 1)
				{
					adicionarPrimeira += ValorPIS;
				}
				if (ModuloParametros.ObterParametros("Faturamento", "Inserir COFINS primeira parcela").Valor == 1)
				{
					adicionarPrimeira += ValorCofins;
				}
				if (ModuloParametros.ObterParametros("Faturamento", "Inserir ICMS primeira parcela").Valor == 1)
				{
					adicionarPrimeira += ValorICMS;
				}
				if (ModuloParametros.ObterParametros("Faturamento", "Inserir Frete primeira parcela").Valor == 1)
				{
					adicionarPrimeira += ValorFrete;
				}
				Fatura = ModuloNotaFiscal.CalcularCondicaoPagamento(ModuloVendasGPS.ObterCondicaoPagamento(CodigoCondicaoPagamento), DataSaida, ValorTotalFatura, NumeroNotaFiscal, CodigoSerieNF, adicionarPrimeira);
			}
		}
		else
		{
			Fatura = null;
		}
	}

	public void NegativarValores()
	{
		foreach (NotaFiscalNotasFiscaisItens iten in Itens)
		{
			iten.NegativarValores();
		}
		AcertaTotais();
		ValorTotalFatura = ValorTotalNotaFiscal;
	}

	public void CriarNotaFaturamentoEntregaFutura(PedidoVendaGPS pedidoVenda, int codigoCFOP)
	{
		if (pedidoVenda == null || codigoCFOP <= 0)
		{
			return;
		}
		NotaFiscalCFOPs notaFiscalCFOPs = ModuloNotaFiscal.ObterNotaFiscalCFOPs(codigoCFOP);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		try
		{
			flag = ModuloParametros.ObterParametros("Faturamento", "InserirComentarioItem").Valor == 1;
			flag2 = ModuloParametros.ObterParametros("Faturamento", "CodigoPedidoInformacaoesAdicionais").Valor == 1;
			flag3 = ModuloParametros.ObterParametros("Vendas", "inserir comentario em textos legais da nota").Valor == 1;
		}
		catch
		{
		}
		decimal pesoBruto = default(decimal);
		decimal pesoLiquido = default(decimal);
		int quantidadeVolumes = 0;
		int num = 1;
		if (TextoLegal == null)
		{
			TextoLegal = string.Empty;
		}
		if (notaFiscalCFOPs.ReducaoICMS == 0m)
		{
			notaFiscalCFOPs.ReducaoICMS = 100m;
		}
		notaFiscalCFOPs.IsConsumidorFinal = IsConsumidorFinal;
		if (notaFiscalCFOPs.CodigoTexto1 > 0 && notaFiscalCFOPs.Texto01 != null && (TextoLegal == null || !TextoLegal.Contains(notaFiscalCFOPs.Texto01.TextoLegal)))
		{
			TextoLegal += $" {notaFiscalCFOPs.Texto01.TextoLegal}";
		}
		if (notaFiscalCFOPs.CodigoTexto2 > 0 && notaFiscalCFOPs.Texto02 != null && (TextoLegal == null || !TextoLegal.Contains(notaFiscalCFOPs.Texto02.TextoLegal)))
		{
			TextoLegal += $" {notaFiscalCFOPs.Texto02.TextoLegal}";
		}
		if (flag3 && !string.IsNullOrWhiteSpace(pedidoVenda.Comentario))
		{
			TextoLegal += pedidoVenda.Comentario;
		}
		TextoLegal = TextoLegal.Trim();
		if (string.IsNullOrWhiteSpace(SerieNotaFiscal))
		{
			IList<NotaFiscalSerie> list = ModuloNotaFiscal.ObterTodosNotaFiscalSerie();
			if (list != null && list.Count > 0)
			{
				CodigoSerieNF = list[list.Count - 1].CodigoSerie;
				SerieNotaFiscal = list[list.Count - 1].CodigoSerie.ToString();
			}
		}
		DataEmissao = DateTime.Now;
		DataSaida = DateTime.Now;
		SituacaoNfe = SituacaoNFe.NaoEnviada.ToString();
		TipoNotaEnum = EnumFinalidadeNotaFiscal.Normal;
		CodigoEmpresa = pedidoVenda.CodigoSociedade;
		Entidade = pedidoVenda.EntidadeRef;
		if (Entidade.Pais.ToUpper() != "BRASIL" && ValorCambio == 0m)
		{
			frmCadastrarCambio frmCadastrarCambio2 = new frmCadastrarCambio();
			((Form)(object)frmCadastrarCambio2).ShowDialog();
			if (((Form)(object)frmCadastrarCambio2).DialogResult == DialogResult.OK)
			{
				ValorCambio = frmCadastrarCambio2.Valor;
				if (ValorCambio == 0m)
				{
					ValorCambio = 1m;
				}
			}
		}
		IsConsumidorFinal = pedidoVenda.IsConsumidorFinal;
		CodigoCondicaoPagamento = pedidoVenda.ModoPagamento;
		IList<NotaFiscalNotasFiscaisItens> list2 = new List<NotaFiscalNotasFiscaisItens>();
		IList<PedidoVendaItemGPS> itens = pedidoVenda.Itens;
		foreach (PedidoVendaItemGPS item in itens)
		{
			if (CFOP == null && notaFiscalCFOPs != null)
			{
				CFOP = notaFiscalCFOPs;
			}
			if (Entidade.Pais.ToUpper() == "BRASIL")
			{
				if (Entidade.UF.ToUpper() != Emitente.Estado.ToUpper())
				{
					if (Entidade.UfRef == null)
					{
						XtraMessageBox.Show("UF do Cliente não encontrada. Favor checar o cadastro antes de continuar");
						return;
					}
					if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "5")
					{
						notaFiscalCFOPs.NumeracaoCFOP = string.Format("{0}{1}", "6", notaFiscalCFOPs.NumeracaoCFOP.Substring(1));
						if (notaFiscalCFOPs.UsarIcmsEstadoFederacao)
						{
							notaFiscalCFOPs.PadraoICMS = Entidade.UfRef.PercentualIcms;
						}
						if (notaFiscalCFOPs.IsConsumidorFinal && Entidade.CodigoIndIeDestinatario == 9 && notaFiscalCFOPs.NumeracaoCFOP.Substring(1, 3) == "101")
						{
							notaFiscalCFOPs.NumeracaoCFOP = "6.107";
							notaFiscalCFOPs.PadraoICMS = 18m;
						}
					}
					else if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "1")
					{
						notaFiscalCFOPs.NumeracaoCFOP = string.Format("{0}{1}", "2", notaFiscalCFOPs.NumeracaoCFOP.Substring(1));
						if (notaFiscalCFOPs.UsarIcmsEstadoFederacao)
						{
							notaFiscalCFOPs.PadraoICMS = Entidade.UfRef.PercentualIcms;
						}
					}
					if (NumeracaoCFOP.Substring(0, 1) == "5" || NumeracaoCFOP.Substring(0, 1) == "1")
					{
						NumeracaoCFOP = notaFiscalCFOPs.NumeracaoCFOP;
					}
				}
			}
			else if (notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) != "7" && notaFiscalCFOPs.NumeracaoCFOP.Substring(1) != "3" && (CFOP == null || (!(CFOP.NumeracaoCFOP.Substring(0, 1) == "7") && !(CFOP.NumeracaoCFOP.Substring(0, 1) == "3"))))
			{
				XtraMessageBox.Show("CFOP imcompativel com exportação / Importacao!!!");
				return;
			}
			NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = new NotaFiscalNotasFiscaisItens(isNovo: true);
			if (item.EstoqueRef != null)
			{
				notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = item.EstoqueRef.ClassificacaoFiscal;
				notaFiscalNotasFiscaisItens.Cest = item.EstoqueRef.Cest;
				notaFiscalNotasFiscaisItens.ChaveEstoqueRef = item.EstoqueRef.ChavePrimariaEstoque;
				if (item.EstoqueRef.EstoqueEanRef != null && !string.IsNullOrWhiteSpace(item.EstoqueRef.EstoqueEanRef.CodigoEAN))
				{
					notaFiscalNotasFiscaisItens.CodigoEan = item.EstoqueRef.EstoqueEanRef.CodigoEANComDigitoVerificador.Trim();
				}
			}
			else
			{
				notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = "00000000";
			}
			if (!string.IsNullOrWhiteSpace(item.ClassificacaoFiscal))
			{
				notaFiscalNotasFiscaisItens.CodigoClassificacaoFiscal = item.ClassificacaoFiscal;
			}
			notaFiscalNotasFiscaisItens.CodigoEstadoDestinatario = Entidade.CodigoUf;
			notaFiscalNotasFiscaisItens.CodigoPedidoVenda = item.CodigoPedido;
			notaFiscalNotasFiscaisItens.CodigoPedidoVendaItem = item.CodigoItemPedido;
			notaFiscalNotasFiscaisItens.CFOPRef = notaFiscalCFOPs;
			if (item.CodigoConta > 0)
			{
				PlanoConta planoContaRef = item.PlanoContaRef;
				if (planoContaRef != null && planoContaRef.Conta.Length > 0)
				{
					notaFiscalNotasFiscaisItens.ContaContabilAnalitica = planoContaRef.Conta;
				}
			}
			else if (item.EstoqueRef != null && item.EstoqueRef.PlanoContaVenda != null)
			{
				notaFiscalNotasFiscaisItens.ContaContabilAnalitica = item.EstoqueRef.PlanoContaVenda.Conta;
			}
			notaFiscalNotasFiscaisItens.CodigoProduto = item.CodigoProduto;
			notaFiscalNotasFiscaisItens.DescricaoProduto = item.DescricaoProduto;
			notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.SiglaFaturamento;
			notaFiscalNotasFiscaisItens.Quantidade = item.QuantidadeNaUnidadeVenda;
			notaFiscalNotasFiscaisItens.ValorUnitario = item.PrecoUnitarioPecaComDesconto;
			notaFiscalNotasFiscaisItens.ValorFrete = item.ValorFrete;
			if (!string.IsNullOrEmpty(pedidoVenda.ReferenciaPedido))
			{
				notaFiscalNotasFiscaisItens.ContratoCliente = ((pedidoVenda.ReferenciaPedido.Length < 15) ? pedidoVenda.ReferenciaPedido : pedidoVenda.ReferenciaPedido.Substring(0, 14));
				if (item.NumeroItemFaturamento > 0)
				{
					notaFiscalNotasFiscaisItens.ContratoClienteItem = item.NumeroItemFaturamento;
				}
				else
				{
					notaFiscalNotasFiscaisItens.ContratoClienteItem = item.CodigoItemPedido;
				}
				notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente = notaFiscalNotasFiscaisItens.ContratoCliente;
				notaFiscalNotasFiscaisItens.CodigoPedidoCompraItemCliente = item.CodigoItemPedido;
				notaFiscalNotasFiscaisItens.SiglaUnidadeFaturamento = item.SiglaFaturamento;
			}
			notaFiscalNotasFiscaisItens.DescricaoProduto = notaFiscalNotasFiscaisItens.DescricaoProduto.Trim();
			decimal num2 = default(decimal);
			if (CondicaoPagamentoRef != null && CondicaoPagamentoRef.Desconto > 0m)
			{
				num2 = CondicaoPagamentoRef.Desconto;
				notaFiscalNotasFiscaisItens.ValorUnitario -= notaFiscalNotasFiscaisItens.ValorUnitario * num2 / 100m;
			}
			if ((notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "7" || notaFiscalCFOPs.NumeracaoCFOP.Substring(0, 1) == "3") && ValorCambio > 0m)
			{
				notaFiscalNotasFiscaisItens.ValorUnitario *= ValorCambio;
			}
			notaFiscalNotasFiscaisItens.ValorUnitario = Math.Round(notaFiscalNotasFiscaisItens.ValorUnitario, 4);
			notaFiscalNotasFiscaisItens.CalcularImposto(TipoNotaEnum);
			StringBuilder stringBuilder = new StringBuilder();
			if (flag && !string.IsNullOrWhiteSpace(item.Comentario))
			{
				stringBuilder.Append(item.Comentario);
			}
			if (flag2 && !string.IsNullOrWhiteSpace(notaFiscalNotasFiscaisItens.CodigoPedidoCompraCliente))
			{
				string value = $"Pedido: {notaFiscalNotasFiscaisItens.ContratoCliente}";
				if (!stringBuilder.ToString().Contains(value))
				{
					stringBuilder.Append($" Pedido: {notaFiscalNotasFiscaisItens.ContratoCliente}/{notaFiscalNotasFiscaisItens.ContratoClienteItem}");
				}
			}
			if (!string.IsNullOrWhiteSpace(stringBuilder.ToString().Trim()))
			{
				notaFiscalNotasFiscaisItens.DescricaoComplementar = stringBuilder.ToString().Trim();
			}
			notaFiscalNotasFiscaisItens.Ordem = num++;
			list2.Add(notaFiscalNotasFiscaisItens);
		}
		Itens = list2;
		PesoBruto = pesoBruto;
		PesoLiquido = pesoLiquido;
		QuantidadeVolumes = quantidadeVolumes;
		AcertaTotais();
	}

	public void RatiarFrete(decimal valorFrete)
	{
		if (valorFrete > 0m)
		{
			decimal num = valorFrete;
			foreach (NotaFiscalNotasFiscaisItens iten in Itens)
			{
				iten.ValorFrete = 0m;
				decimal num2 = default(decimal);
				if (ValorProdutos > 0m)
				{
					num2 = Math.Round(valorFrete * iten.ValorTotal / ValorProdutos, 2);
					num -= num2;
					iten.ValorFrete = num2;
				}
				else
				{
					num2 = Math.Round(valorFrete / (decimal)Itens.Count, 2);
					num -= num2;
					iten.ValorFrete = num2;
				}
				iten.CalcularImposto(TipoNotaEnum);
			}
			int num3 = 0;
			while (num != 0m && num3 < Itens.Count - 1)
			{
				if (Itens[num3].ValorFrete > 0m)
				{
					Itens[num3].ValorFrete += num;
					Itens[num3].CalcularImposto(TipoNotaEnum);
					num = default(decimal);
				}
				num3++;
			}
		}
		AcertaTotais();
	}

	public void ReagruparItensSemelhanteNotaFiscal()
	{
		string text = string.Empty;
		int num = 0;
		string text2 = string.Empty;
		decimal num2 = default(decimal);
		IList<NotaFiscalNotasFiscaisItens> list = (from c in Itens
			orderby c.CodigoProduto, c.CodigoCFOPInterna, c.CodigoClassificacaoFiscal, c.ValorUnitario, c.Ordem
			select c).ToList();
		IList<NotaFiscalNotasFiscaisItens> list2 = new List<NotaFiscalNotasFiscaisItens>();
		NotaFiscalNotasFiscaisItens notaFiscalNotasFiscaisItens = null;
		if (list == null)
		{
			return;
		}
		foreach (NotaFiscalNotasFiscaisItens item in list)
		{
			if (item.CodigoProduto == null)
			{
				continue;
			}
			if (!text.Equals(item.CodigoProduto) || num != item.CodigoCFOPInterna || !text2.Equals(item.CodigoClassificacaoFiscal) || !(num2 == item.ValorUnitario))
			{
				list2.Add(item);
				notaFiscalNotasFiscaisItens = item;
				text = item.CodigoProduto;
				num = item.CodigoCFOPInterna;
				text2 = item.CodigoClassificacaoFiscal;
				num2 = item.ValorUnitario;
				notaFiscalNotasFiscaisItens.DescricaoComplementar = $"Pedido: {item.CodigoPedidoCompraCliente}/{item.CodigoPedidoCompraItemCliente}";
				continue;
			}
			notaFiscalNotasFiscaisItens.Quantidade += item.Quantidade;
			notaFiscalNotasFiscaisItens.CodigoFichaExpedicao = 0;
			notaFiscalNotasFiscaisItens.CodigoFichaExpedicaoItem = 0;
			if (!notaFiscalNotasFiscaisItens.DescricaoComplementar.Contains($"{item.CodigoPedidoCompraCliente}/{item.CodigoPedidoCompraItemCliente}"))
			{
				notaFiscalNotasFiscaisItens.DescricaoComplementar += $", {item.CodigoPedidoCompraCliente}/{item.CodigoPedidoCompraItemCliente}";
			}
			notaFiscalNotasFiscaisItens.DescricaoComplementar = notaFiscalNotasFiscaisItens.DescricaoComplementar.Trim();
			notaFiscalNotasFiscaisItens.CalcularImposto(TipoNotaEnum);
		}
		Itens = list2;
		AcertaTotais();
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalNotasFiscais)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
