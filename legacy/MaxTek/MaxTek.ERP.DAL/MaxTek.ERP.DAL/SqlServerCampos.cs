using System.Collections.Generic;
using System.Data;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SqlServerCampos : ICampos
{
	private static MapTableCampos MapearClasse(DataRow row)
	{
		MapTableCampos result = default(MapTableCampos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.nomeEsquema = BaseDadosERP.ObterDbValor<string>(row["nomeEsquema"]);
			result.nomeColuna = BaseDadosERP.ObterDbValor<string>(row["nomeColuna"]);
			result.tipoDado = BaseDadosERP.ObterDbValor<string>(row["tipoDado"]);
			result.quantidadeCaracteres = BaseDadosERP.ObterDbValor<int>(row["quantidadeCaracteres"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("");
		stringBuilder.Append("select ");
		stringBuilder.Append("ORDINAL_POSITION as id,");
		stringBuilder.Append("TABLE_SCHEMA as nomeEsquema,");
		stringBuilder.Append("COLUMN_NAME as nomeColuna,");
		stringBuilder.Append("DATA_TYPE as tipoDado,");
		stringBuilder.Append("CHARACTER_MAXIMUM_LENGTH as quantidadeCaracteres");
		stringBuilder.Append(" from ");
		return stringBuilder.ToString();
	}

	public IList<MapTableCampos> ObterCampos(string nomeServidor, string bancoDados, string nomeEsquema, string nomeTabela)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("[" + nomeServidor + "].[" + bancoDados + "].[INFORMATION_SCHEMA].[COLUMNS] ");
		stringBuilder.Append("where [TABLE_SCHEMA] = " + BaseDadosERP.Escape(nomeEsquema));
		stringBuilder.Append(" and [TABLE_NAME] = " + BaseDadosERP.Escape(nomeTabela));
		stringBuilder.Append(" order by [ORDINAL_POSITION]");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableCampos> list = new List<MapTableCampos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}
}
