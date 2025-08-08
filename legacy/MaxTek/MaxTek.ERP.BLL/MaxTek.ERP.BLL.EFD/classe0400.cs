namespace MaxTek.ERP.BLL.EFD;

public class classe0400
{
	private string cfop;

	private string naturezaOpercao;

	public string Cfop
	{
		get
		{
			return cfop;
		}
		set
		{
			if (!(cfop == value))
			{
				cfop = value;
			}
		}
	}

	public string NaturezaOpercao
	{
		get
		{
			return naturezaOpercao;
		}
		set
		{
			if (!(naturezaOpercao == value))
			{
				naturezaOpercao = value;
			}
		}
	}

	public classe0400(string cfop, string naturezaOperacao)
	{
		this.cfop = cfop;
		naturezaOpercao = naturezaOperacao;
	}
}
