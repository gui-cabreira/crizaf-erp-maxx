using MaxTek.GPS.BLL;

namespace MaxTek.ERP.BLL.EFD;

public class classeA170
{
	private string codigoItem;

	private string codigoProduto;

	private string descricaoProduto;

	private string valorTotalBruto;

	private string valorDesconto;

	private string codigoBaseCalculoCredito;

	private string indicadorOrigemCredito;

	private string pisCst;

	private string pisValorBaseCalculo;

	private string pisAliquota;

	private string pisValor;

	private string cofinsCst;

	private string cofinsValorBaseCalculo;

	private string cofinsAliquota;

	private string cofinsValor;

	private string codigoContaReduzida;

	private string codigoCentroCustos;

	public string CodigoItem
	{
		get
		{
			return codigoItem;
		}
		set
		{
			if (!(codigoItem == value))
			{
				codigoItem = value;
			}
		}
	}

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

	public string ValorTotalBruto
	{
		get
		{
			return valorTotalBruto;
		}
		set
		{
			if (!(valorTotalBruto == value))
			{
				valorTotalBruto = value;
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

	public string CodigoBaseCalculoCredito
	{
		get
		{
			return codigoBaseCalculoCredito;
		}
		set
		{
			if (!(codigoBaseCalculoCredito == value))
			{
				codigoBaseCalculoCredito = value;
			}
		}
	}

	public string IndicadorOrigemCredito
	{
		get
		{
			return indicadorOrigemCredito;
		}
		set
		{
			if (!(indicadorOrigemCredito == value))
			{
				indicadorOrigemCredito = value;
			}
		}
	}

	public string PisCst
	{
		get
		{
			return pisCst;
		}
		set
		{
			if (!(pisCst == value))
			{
				pisCst = value;
			}
		}
	}

	public string PisValorBaseCalculo
	{
		get
		{
			return pisValorBaseCalculo;
		}
		set
		{
			if (!(pisValorBaseCalculo == value))
			{
				pisValorBaseCalculo = value;
			}
		}
	}

	public string PisAliquota
	{
		get
		{
			return pisAliquota;
		}
		set
		{
			if (!(pisAliquota == value))
			{
				pisAliquota = value;
			}
		}
	}

	public string PisValor
	{
		get
		{
			return pisValor;
		}
		set
		{
			if (!(pisValor == value))
			{
				pisValor = value;
			}
		}
	}

	public string CofinsCst
	{
		get
		{
			return cofinsCst;
		}
		set
		{
			if (!(cofinsCst == value))
			{
				cofinsCst = value;
			}
		}
	}

	public string CofinsValorBaseCalculo
	{
		get
		{
			return cofinsValorBaseCalculo;
		}
		set
		{
			if (!(cofinsValorBaseCalculo == value))
			{
				cofinsValorBaseCalculo = value;
			}
		}
	}

	public string CofinsAliquota
	{
		get
		{
			return cofinsAliquota;
		}
		set
		{
			if (!(cofinsAliquota == value))
			{
				cofinsAliquota = value;
			}
		}
	}

	public string CofinsValor
	{
		get
		{
			return cofinsValor;
		}
		set
		{
			if (!(cofinsValor == value))
			{
				cofinsValor = value;
			}
		}
	}

	public string CodigoContaReduzida
	{
		get
		{
			return codigoContaReduzida;
		}
		set
		{
			if (!(codigoContaReduzida == value))
			{
				codigoContaReduzida = value;
			}
		}
	}

	public string CodigoCentroCustos
	{
		get
		{
			return codigoCentroCustos;
		}
		set
		{
			if (!(codigoCentroCustos == value))
			{
				codigoCentroCustos = value;
			}
		}
	}

	public classeA170(XmlProduto produto)
	{
		codigoItem = produto.CodigoItem.ToString();
		codigoProduto = produto.CodigoProduto;
		descricaoProduto = produto.DescricaoProduto;
		valorTotalBruto = produto.ValorTotalBruto.ToString();
		valorDesconto = produto.ValorDesconto.ToString();
		codigoBaseCalculoCredito = "";
		indicadorOrigemCredito = "0";
		pisCst = produto.PisCst;
		pisValorBaseCalculo = produto.PisValorBaseCalculo.ToString();
		pisAliquota = produto.PisAliquota.ToString();
		pisValor = produto.PisValor.ToString();
		cofinsCst = produto.CofinsCst;
		cofinsValorBaseCalculo = produto.CofinsValorBaseCalculo.ToString();
		cofinsAliquota = produto.CofinsAliquota.ToString();
		cofinsValor = produto.CofinsValor.ToString();
		codigoContaReduzida = produto.CodigoContaReduzida.ToString();
		codigoCentroCustos = produto.CodigoCentroCustos.ToString();
	}
}
