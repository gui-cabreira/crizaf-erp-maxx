namespace MaxTek.ERP.BLL.EFD;

public class classeA001
{
	private string cnpj;

	public string Cnpj
	{
		get
		{
			return cnpj;
		}
		set
		{
			if (!(cnpj == value))
			{
				cnpj = value;
			}
		}
	}

	public classeA001(string cnpj)
	{
		this.cnpj = cnpj;
	}
}
