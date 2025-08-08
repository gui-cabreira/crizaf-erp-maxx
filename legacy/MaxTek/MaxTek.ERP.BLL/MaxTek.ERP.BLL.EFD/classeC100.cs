using System.Collections.Generic;
using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL.EFD;

public class classeC100
{
	private string indicadorTipoOperacao;

	private string indicadorEmitente;

	private string codigoParticipante;

	private string codigoModeloDocumentoFiscal;

	private string codigoSituacaoDocumento;

	private string serie;

	private string numeroNotaFiscal;

	private string chaveEletronica;

	private string dataEmissao;

	private string dataEntrada;

	private string valorTotalDocumento;

	private string codigoIndicadorTipoPagamento;

	private string valorDesconto;

	private string valorAbatimento;

	private string valorTotalMercadorias;

	private string indicadorTipoFrete;

	private string valorFrete;

	private string valorSeguro;

	private string valorOutrasDespesas;

	private string valorBaseCalculoIcms;

	private string valorIcms;

	private string valorBaseCalculoIcmsSt;

	private string valorIcmsSt;

	private string valorIpi;

	private string valorPis;

	private string valorCofins;

	private string valorPisSt;

	private string valorCofinsSt;

	private IList<classeC170> clC170 = new List<classeC170>();

	public IList<classeC170> ClC170
	{
		get
		{
			return clC170;
		}
		set
		{
			if (clC170 != value)
			{
				clC170 = value;
			}
		}
	}

	public string IndicadorTipoOperacao
	{
		get
		{
			return indicadorTipoOperacao;
		}
		set
		{
			if (!(indicadorTipoOperacao == value))
			{
				indicadorTipoOperacao = value;
			}
		}
	}

	public string IndicadorEmitente
	{
		get
		{
			return indicadorEmitente;
		}
		set
		{
			if (!(indicadorEmitente == value))
			{
				indicadorEmitente = value;
			}
		}
	}

	public string CodigoParticipante
	{
		get
		{
			return codigoParticipante;
		}
		set
		{
			if (!(codigoParticipante == value))
			{
				codigoParticipante = value;
			}
		}
	}

	public string CodigoModeloDocumentoFiscal
	{
		get
		{
			return codigoModeloDocumentoFiscal;
		}
		set
		{
			if (!(codigoModeloDocumentoFiscal == value))
			{
				codigoModeloDocumentoFiscal = value;
			}
		}
	}

	public string CodigoSituacaoDocumento
	{
		get
		{
			return codigoSituacaoDocumento;
		}
		set
		{
			if (!(codigoSituacaoDocumento == value))
			{
				codigoSituacaoDocumento = value;
			}
		}
	}

	public string Serie
	{
		get
		{
			return serie;
		}
		set
		{
			if (!(serie == value))
			{
				serie = value;
			}
		}
	}

	public string NumeroNotaFiscal
	{
		get
		{
			return numeroNotaFiscal;
		}
		set
		{
			if (!(numeroNotaFiscal == value))
			{
				numeroNotaFiscal = value;
			}
		}
	}

	public string ChaveEletronica
	{
		get
		{
			return chaveEletronica;
		}
		set
		{
			if (!(chaveEletronica == value))
			{
				chaveEletronica = value;
			}
		}
	}

	public string DataEmissao
	{
		get
		{
			return dataEmissao;
		}
		set
		{
			if (!(dataEmissao == value))
			{
				dataEmissao = value;
			}
		}
	}

	public string DataEntrada
	{
		get
		{
			return dataEntrada;
		}
		set
		{
			if (!(dataEntrada == value))
			{
				dataEntrada = value;
			}
		}
	}

	public string ValorTotalDocumento
	{
		get
		{
			return valorTotalDocumento;
		}
		set
		{
			if (!(valorTotalDocumento == value))
			{
				valorTotalDocumento = value;
			}
		}
	}

	public string CodigoIndicadorTipoPagamento
	{
		get
		{
			return codigoIndicadorTipoPagamento;
		}
		set
		{
			if (!(codigoIndicadorTipoPagamento == value))
			{
				codigoIndicadorTipoPagamento = value;
			}
		}
	}

	public string ValorDesconto
	{
		get
		{
			return valorDesconto;
		}
		set
		{
			if (!(valorDesconto == value))
			{
				valorDesconto = value;
			}
		}
	}

	public string ValorAbatimento
	{
		get
		{
			return valorAbatimento;
		}
		set
		{
			if (!(valorAbatimento == value))
			{
				valorAbatimento = value;
			}
		}
	}

	public string ValorTotalMercadorias
	{
		get
		{
			return valorTotalMercadorias;
		}
		set
		{
			if (!(valorTotalMercadorias == value))
			{
				valorTotalMercadorias = value;
			}
		}
	}

	public string IndicadorTipoFrete
	{
		get
		{
			return indicadorTipoFrete;
		}
		set
		{
			if (!(indicadorTipoFrete == value))
			{
				indicadorTipoFrete = value;
			}
		}
	}

	public string ValorFrete
	{
		get
		{
			return valorFrete;
		}
		set
		{
			if (!(valorFrete == value))
			{
				valorFrete = value;
			}
		}
	}

	public string ValorSeguro
	{
		get
		{
			return valorSeguro;
		}
		set
		{
			if (!(valorSeguro == value))
			{
				valorSeguro = value;
			}
		}
	}

	public string ValorOutrasDespesas
	{
		get
		{
			return valorOutrasDespesas;
		}
		set
		{
			if (!(valorOutrasDespesas == value))
			{
				valorOutrasDespesas = value;
			}
		}
	}

	public string ValorBaseCalculoIcms
	{
		get
		{
			return valorBaseCalculoIcms;
		}
		set
		{
			if (!(valorBaseCalculoIcms == value))
			{
				valorBaseCalculoIcms = value;
			}
		}
	}

	public string ValorIcms
	{
		get
		{
			return valorIcms;
		}
		set
		{
			if (!(valorIcms == value))
			{
				valorIcms = value;
			}
		}
	}

	public string ValorBaseCalculoIcmsSt
	{
		get
		{
			return valorBaseCalculoIcmsSt;
		}
		set
		{
			if (!(valorBaseCalculoIcmsSt == value))
			{
				valorBaseCalculoIcmsSt = value;
			}
		}
	}

	public string ValorIcmsSt
	{
		get
		{
			return valorIcmsSt;
		}
		set
		{
			if (!(valorIcmsSt == value))
			{
				valorIcmsSt = value;
			}
		}
	}

	public string ValorIpi
	{
		get
		{
			return valorIpi;
		}
		set
		{
			if (!(valorIpi == value))
			{
				valorIpi = value;
			}
		}
	}

	public string ValorPis
	{
		get
		{
			return valorPis;
		}
		set
		{
			if (!(valorPis == value))
			{
				valorPis = value;
			}
		}
	}

	public string ValorCofins
	{
		get
		{
			return valorCofins;
		}
		set
		{
			if (!(valorCofins == value))
			{
				valorCofins = value;
			}
		}
	}

	public string ValorPisSt
	{
		get
		{
			return valorPisSt;
		}
		set
		{
			if (!(valorPisSt == value))
			{
				valorPisSt = value;
			}
		}
	}

	public string ValorCofinsSt
	{
		get
		{
			return valorCofinsSt;
		}
		set
		{
			if (!(valorCofinsSt == value))
			{
				valorCofinsSt = value;
			}
		}
	}

	public classeC100(XmlCabecalho xmlCabecalho)
	{
		indicadorTipoOperacao = "1";
		indicadorEmitente = "0";
		codigoParticipante = xmlCabecalho.Cnpj;
		codigoModeloDocumentoFiscal = xmlCabecalho.CodigoModeloDocumentoFiscal;
		codigoSituacaoDocumento = "00";
		serie = xmlCabecalho.SerieNotaFiscal;
		numeroNotaFiscal = xmlCabecalho.CodigoNotaFiscal.ToString();
		chaveEletronica = xmlCabecalho.Chave;
		dataEmissao = xmlCabecalho.DataEmissao.ToString("ddMMyyyy");
		dataEntrada = xmlCabecalho.DataEscrituracao.ToString("ddMMyyyy");
		valorTotalDocumento = xmlCabecalho.ValorTotalNfe.ToString();
		codigoIndicadorTipoPagamento = xmlCabecalho.IndicadorFormaPagamento.ToString();
		valorDesconto = xmlCabecalho.ValorDesconto.ToString();
		valorAbatimento = "0";
		valorTotalMercadorias = xmlCabecalho.ValorTotalProdutos.ToString();
		indicadorTipoFrete = xmlCabecalho.ModalidadeFrete.ToString();
		valorFrete = xmlCabecalho.ValorFrete.ToString();
		valorSeguro = xmlCabecalho.ValorSeguro.ToString();
		valorOutrasDespesas = xmlCabecalho.ValorOutros.ToString();
		valorBaseCalculoIcms = xmlCabecalho.ValorBaseCalculoIcms.ToString();
		valorIcms = xmlCabecalho.ValorIcms.ToString();
		valorBaseCalculoIcmsSt = xmlCabecalho.ValorBaseCalculoIcmsSt.ToString();
		valorIcmsSt = xmlCabecalho.ValorIcmsSt.ToString();
		valorIpi = xmlCabecalho.ValorIpi.ToString();
		valorPis = xmlCabecalho.ValorPis.ToString();
		valorCofins = xmlCabecalho.ValorCofins.ToString();
		valorPisSt = "0";
		valorCofinsSt = "0";
	}

	public classeC100(NotaFiscalNotasFiscais notaFiscal)
	{
		indicadorTipoOperacao = "1";
		indicadorEmitente = "0";
		codigoParticipante = notaFiscal.CnpjDestinatario;
		codigoModeloDocumentoFiscal = "55";
		codigoSituacaoDocumento = ((notaFiscal.SituacaoNfe == "Sucesso" || notaFiscal.SituacaoNfe == "SucessoContingencia" || notaFiscal.SituacaoNfe == "SistemaLegado") ? "00" : "01");
		serie = notaFiscal.SerieNotaFiscal;
		numeroNotaFiscal = notaFiscal.NumeroNotaFiscal.ToString();
		chaveEletronica = notaFiscal.ChaveNfe;
		dataEmissao = notaFiscal.DataEmissao.ToString("ddMMyyyy");
		dataEntrada = notaFiscal.DataSaida.ToString("ddMMyyyy");
		valorTotalDocumento = notaFiscal.ValorTotalNotaFiscal.ToString();
		codigoIndicadorTipoPagamento = ((notaFiscal.ValorTotalFatura > 0m) ? "1" : "9");
		valorDesconto = "0";
		valorAbatimento = "0";
		valorTotalMercadorias = notaFiscal.ValorProdutos.ToString();
		indicadorTipoFrete = ((notaFiscal.ValorFrete > 0m) ? "0" : "1");
		valorFrete = notaFiscal.ValorFrete.ToString();
		valorSeguro = notaFiscal.ValorSeguro.ToString();
		valorOutrasDespesas = notaFiscal.ValorOutrasDespesas.ToString();
		valorBaseCalculoIcms = notaFiscal.ValorBaseICMS.ToString();
		valorIcms = notaFiscal.ValorICMS.ToString();
		valorBaseCalculoIcmsSt = notaFiscal.ValorBaseICMSSubstituto.ToString();
		valorIcmsSt = notaFiscal.ValorICMSSubstituto.ToString();
		valorIpi = notaFiscal.ValorIPI.ToString();
		valorPis = notaFiscal.ValorPIS.ToString();
		valorCofins = notaFiscal.ValorCofins.ToString();
		valorPisSt = "0";
		valorCofinsSt = "0";
	}
}
