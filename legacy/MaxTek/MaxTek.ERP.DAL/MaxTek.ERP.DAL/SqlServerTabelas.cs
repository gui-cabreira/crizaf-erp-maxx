using System.Collections.Generic;
using System.Data;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SqlServerTabelas : ITabelas
{
	private static MapTableTabelas MapearClasse(DataRow row)
	{
		MapTableTabelas result = default(MapTableTabelas);
		if (row != null)
		{
			result.id = 0;
			result.nomeEsquema = BaseDadosERP.ObterDbValor<string>(row["nomeEsquema"]);
			result.nomeTabela = BaseDadosERP.ObterDbValor<string>(row["nomeTabela"]);
			result.nomeBtr = string.Empty;
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select [TABLE_SCHEMA] as [nomeEsquema], [TABLE_NAME] as [nomeTabela] FROM ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTabelas> ObterTabelas(string nomeServidor, string nomeBaseDados)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("[" + nomeServidor + "].[" + nomeBaseDados + "].[INFORMATION_SCHEMA].[TABLES] ");
		stringBuilder.Append("order by [TABLE_SCHEMA],[TABLE_NAME]");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTabelas> list = new List<MapTableTabelas>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTabelas ObterTabela(string nomeServidor, string nomeBaseDados, string nomeEsquema, string nomeTabela)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("[ " + nomeServidor + "].[" + nomeBaseDados + "].[INFORMATION_SCHEMA].[COLUMNS] ");
		stringBuilder.Append("Where [TABLE_SCHEMA] = " + BaseDadosERP.Escape(nomeEsquema));
		stringBuilder.Append(" and [TABLE_NAME] = " + BaseDadosERP.Escape(nomeTabela));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString());
		return MapearClasse(row);
	}
}
