namespace MaxTek.ERP.DAL;

public class ProviderFactories
{
	public static ProviderFactory ObterFactory(string dataProvider)
	{
		if (dataProvider == "System.Data.SqlClient")
		{
			return new SqlServerFactory();
		}
		return new SqlServerFactory();
	}
}
