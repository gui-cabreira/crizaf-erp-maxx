using System.Collections.Generic;
using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL.EFD;

public class classeA100
{
	private string indicadorTipoOperacao;

	private string indicadorEmitente;

	private string codigoParticipante;

	private string codigoSituacaoDocumento;

	private string serie;

	private string subSerie;

	private string numeroNotaFiscal;

	private string chaveEletronica;

	private string dataEmissao;

	private string dataEntrada;

	private string valorTotalDocumento;

	private string codigoIndicadorTipoPagamento;

	private string valorDesconto;

	private string valorBaseCalculoPisPasep;

	private string valorTotalPis;

	private string valorBaseCalculoCofins;

	private string valorTotalCofins;

	private string valorTotalPisRetido;

	private string valorTotalCofinsRetido;

	private string valorIss;

	private IList<classeA170> clA170 = new List<classeA170>();

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

	public string SubSerie
	{
		get
		{
			return subSerie;
		}
		set
		{
			if (!(subSerie == value))
			{
				subSerie = value;
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

	public string ValorBaseCalculoPisPasep
	{
		get
		{
			return valorBaseCalculoPisPasep;
		}
		set
		{
			if (!(valorBaseCalculoPisPasep == value))
			{
				valorBaseCalculoPisPasep = value;
			}
		}
	}

	public string ValorTotalPis
	{
		get
		{
			return valorTotalPis;
		}
		set
		{
			if (!(valorTotalPis == value))
			{
				valorTotalPis = value;
			}
		}
	}

	public string ValorBaseCalculoCofins
	{
		get
		{
			return valorBaseCalculoCofins;
		}
		set
		{
			if (!(valorBaseCalculoCofins == value))
			{
				valorBaseCalculoCofins = value;
			}
		}
	}

	public string ValorTotalCofins
	{
		get
		{
			return valorTotalCofins;
		}
		set
		{
			if (!(valorTotalCofins == value))
			{
				valorTotalCofins = value;
			}
		}
	}

	public string ValorTotalPisRetido
	{
		get
		{
			return valorTotalPisRetido;
		}
		set
		{
			if (!(valorTotalPisRetido == value))
			{
				valorTotalPisRetido = value;
			}
		}
	}

	public string ValorTotalCofinsRetido
	{
		get
		{
			return valorTotalCofinsRetido;
		}
		set
		{
			if (!(valorTotalCofinsRetido == value))
			{
				valorTotalCofinsRetido = value;
			}
		}
	}

	public string ValorIss
	{
		get
		{
			return valorIss;
		}
		set
		{
			if (!(valorIss == value))
			{
				valorIss = value;
			}
		}
	}

	public IList<classeA170> ClA170
	{
		get
		{
			return clA170;
		}
		set
		{
			if (clA170 != value)
			{
				clA170 = value;
			}
		}
	}

	public classeA100(XmlCabecalho xmlCabecalho)
	{
		indicadorTipoOperacao = "0";
		indicadorEmitente = "0";
		codigoParticipante = xmlCabecalho.Cnpj;
		codigoSituacaoDocumento = "00";
		serie = xmlCabecalho.SerieNotaFiscal;
		subSerie = "";
		numeroNotaFiscal = xmlCabecalho.CodigoNotaFiscal.ToString();
		chaveEletronica = FuncoesUteis.LimparNro(xmlCabecalho.Chave);
		dataEmissao = xmlCabecalho.DataEmissao.ToString("ddMMyyyy");
		dataEntrada = xmlCabecalho.DataEscrituracao.ToString("ddMMyyyy");
		valorTotalDocumento = xmlCabecalho.ValorTotalNfe.ToString();
		codigoIndicadorTipoPagamento = xmlCabecalho.IndicadorFormaPagamento.ToString();
		valorDesconto = xmlCabecalho.ValorDesconto.ToString();
		valorBaseCalculoPisPasep = xmlCabecalho.ValorBaseCalculoIcms.ToString();
		valorTotalPis = xmlCabecalho.ValorPisServico.ToString();
		valorBaseCalculoCofins = xmlCabecalho.ValorBaseCalculoIcms.ToString();
		valorTotalCofins = xmlCabecalho.ValorCofinsServico.ToString();
		valorTotalPisRetido = xmlCabecalho.ValorPisRetido.ToString();
		valorTotalCofinsRetido = xmlCabecalho.ValorCofinsRetido.ToString();
		valorIss = xmlCabecalho.ValorIss.ToString();
	}
}
