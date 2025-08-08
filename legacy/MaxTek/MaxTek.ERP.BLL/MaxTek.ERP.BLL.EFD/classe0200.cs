using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL.EFD;

public class classe0200
{
	private string codigoProduto;

	private string descricaoProduto;

	private string codigoEan;

	private string unidadeEstoque;

	private string tipoItem;

	private string codigoNCM;

	private string ipiCodigoEnquadramento;

	private string codigoGenero;

	private string issqnCodigoListaServico;

	private string aliquotaIcms;

	public string CodigoProduto
	{
		get
		{
			return codigoProduto;
		}
		set
		{
			if (!(codigoProduto == value))
			{
				codigoProduto = value;
			}
		}
	}

	public string DescricaoProduto
	{
		get
		{
			return descricaoProduto;
		}
		set
		{
			if (!(descricaoProduto == value))
			{
				descricaoProduto = value;
			}
		}
	}

	public string CodigoEan
	{
		get
		{
			return codigoEan;
		}
		set
		{
			if (!(codigoEan == value))
			{
				codigoEan = value;
			}
		}
	}

	public string UnidadeEstoque
	{
		get
		{
			return unidadeEstoque;
		}
		set
		{
			if (!(unidadeEstoque == value))
			{
				unidadeEstoque = value;
			}
		}
	}

	public string TipoItem
	{
		get
		{
			return tipoItem;
		}
		set
		{
			if (!(tipoItem == value))
			{
				tipoItem = value;
			}
		}
	}

	public string CodigoNCM
	{
		get
		{
			return codigoNCM;
		}
		set
		{
			if (!(codigoNCM == value))
			{
				codigoNCM = value;
			}
		}
	}

	public string IpiCodigoEnquadramento
	{
		get
		{
			return ipiCodigoEnquadramento;
		}
		set
		{
			if (!(ipiCodigoEnquadramento == value))
			{
				ipiCodigoEnquadramento = value;
			}
		}
	}

	public string CodigoGenero
	{
		get
		{
			return codigoGenero;
		}
		set
		{
			if (!(codigoGenero == value))
			{
				codigoGenero = value;
			}
		}
	}

	public string IssqnCodigoListaServico
	{
		get
		{
			return issqnCodigoListaServico;
		}
		set
		{
			if (!(issqnCodigoListaServico == value))
			{
				issqnCodigoListaServico = value;
			}
		}
	}

	public string AliquotaIcms
	{
		get
		{
			return aliquotaIcms;
		}
		set
		{
			if (!(aliquotaIcms == value))
			{
				aliquotaIcms = value;
			}
		}
	}

	public classe0200(XmlProduto produto)
	{
		if (!string.IsNullOrEmpty(produto.GpsCodigoProduto) && produto.EstoqueGPSRef != null && !string.IsNullOrEmpty(produto.EstoqueGPSRef.CodigoProduto))
		{
			codigoProduto = produto.GpsCodigoProduto;
			descricaoProduto = produto.EstoqueGPSRef.DescricaoProduto;
			codigoEan = produto.EstoqueGPSRef.CodigoEAN;
			unidadeEstoque = produto.EstoqueGPSRef.SiglaUnidadeEstoque.ToString();
			tipoItem = "01";
			codigoNCM = produto.CodigoNcm;
		}
		else
		{
			codigoProduto = produto.CodigoProduto;
			descricaoProduto = produto.DescricaoProduto;
			codigoEan = produto.CodigoEan;
			unidadeEstoque = produto.UnidadeComercial;
			tipoItem = "01";
			codigoNCM = produto.CodigoNcm;
		}
		ipiCodigoEnquadramento = produto.IpiCodigoEnquadramento;
		codigoGenero = ((produto.CodigoNcm.Length > 2) ? produto.CodigoNcm.Substring(0, 2) : produto.CodigoNcm);
		issqnCodigoListaServico = produto.IssqnCodigoListaServico.ToString();
		aliquotaIcms = produto.IcmsAliquota.ToString();
	}

	public classe0200(NotaFiscalNotasFiscaisItens itemNF)
	{
		codigoProduto = itemNF.CodigoProduto;
		descricaoProduto = itemNF.DescricaoProduto;
		codigoEan = itemNF.CodigoEan;
		unidadeEstoque = itemNF.SiglaUnidadeFaturamento;
		tipoItem = "04";
		codigoNCM = itemNF.CodigoClassificacaoFiscal;
		ipiCodigoEnquadramento = itemNF.CodigoEnquadramentoIPI.ToString();
		codigoGenero = ((codigoNCM.Length > 2) ? codigoNCM.Substring(0, 2) : codigoNCM);
		issqnCodigoListaServico = string.Empty;
		aliquotaIcms = itemNF.AliquotaICMS.ToString();
	}
}
