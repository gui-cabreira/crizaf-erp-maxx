using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SqlServerIndices : IIndices
{
	private static MapTableListaIndices MapearListaIndices(DataRow row)
	{
		MapTableListaIndices result = default(MapTableListaIndices);
		if (row != null)
		{
			result.nomeSchema = BaseDadosERP.ObterDbValor<string>(row["nomeSchema"]);
			result.nomeTabela = BaseDadosERP.ObterDbValor<string>(row["nomeTabela"]);
			result.idTabela = BaseDadosERP.ObterDbValor<int>(row["idTabela"]);
			result.nomeIndex = BaseDadosERP.ObterDbValor<string>(row["nomeIndex"]);
			result.index_id = BaseDadosERP.ObterDbValor<int>(row["index_id"]);
			result.tipo = BaseDadosERP.ObterDbValor<int>(row["tipo"]);
			result.isUnico = BaseDadosERP.ObterDbValor<bool>(row["isUnico"]);
			result.isPk = BaseDadosERP.ObterDbValor<bool>(row["isPk"]);
		}
		return result;
	}

	public IList<MapTableListaIndices> ObterListaIndices(string schema, string tabela)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SELECT ");
		stringBuilder.Append("[sc].[name] as [nomeSchema] ");
		stringBuilder.Append(",[tb].[name] as [nomeTabela] ");
		stringBuilder.Append(",[tb].[object_id] as [idTabela] ");
		stringBuilder.Append(",[id].[name]  as [nomeIndex] ");
		stringBuilder.Append(",[id].[index_id] as [index_id] ");
		stringBuilder.Append(",[id].[type] as [tipo] ");
		stringBuilder.Append(",[id].[is_unique] as [isUnico] ");
		stringBuilder.Append(",[id].[is_primary_key] as [isPk] ");
		stringBuilder.Append("FROM [" + BaseDadosERP.NomeServidor + "].[sys].[tables] as [tb] ");
		stringBuilder.Append("inner join [" + BaseDadosERP.NomeServidor + "].[sys].[schemas] as [sc] ");
		stringBuilder.Append("on [tb].[schema_id] = [sc].[schema_id] ");
		stringBuilder.Append("inner join [" + BaseDadosERP.NomeServidor + "].[sys].[indexes] as [id] ");
		stringBuilder.Append("on [tb].[Object_id] = [id].[Object_id] ");
		stringBuilder.Append("where [tb].[name] = @nomeTabela ");
		stringBuilder.Append("and [sc].[name] = @nomeSchema) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nomeTabela", tabela));
		list.Add(BaseDadosERP.ObterNovoParametro("@nomeSchema", schema));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableListaIndices> list2 = new List<MapTableListaIndices>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearListaIndices(row));
		}
		return list2;
	}

	private static MapTableIndices MapearIndices(DataRow row)
	{
		MapTableIndices result = default(MapTableIndices);
		if (row != null)
		{
			result.object_id = BaseDadosERP.ObterDbValor<int>(row["object_id"]);
			result.index_id = BaseDadosERP.ObterDbValor<int>(row["index_id"]);
			result.column_id = BaseDadosERP.ObterDbValor<int>(row["column_id"]);
			result.key_ordinal = BaseDadosERP.ObterDbValor<int>(row["key_ordinal"]);
			result.index_column_id = BaseDadosERP.ObterDbValor<int>(row["index_column_id"]);
			result.coluna = BaseDadosERP.ObterDbValor<string>(row["coluna"]);
			result.tipo = BaseDadosERP.ObterDbValor<string>(row["tipo"]);
		}
		return result;
	}

	public IList<MapTableIndices> ObterIndices(int objectId, int indexId)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[ic].[object_id] ");
		stringBuilder.Append(",[ic].[index_id] ");
		stringBuilder.Append(",[ic].[column_id] ");
		stringBuilder.Append(",[ic].[key_ordinal] ");
		stringBuilder.Append(",[ic].[index_column_id] ");
		stringBuilder.Append(",[cl].[name] as [coluna] ");
		stringBuilder.Append(",[tp].[name] as [tipo] ");
		stringBuilder.Append("From [" + BaseDadosERP.NomeServidor + "].[sys].[index_columns] as [ic] ");
		stringBuilder.Append("inner join " + BaseDadosERP.NomeServidor + "].[sys].[all_columns] as [cl] ");
		stringBuilder.Append("on [ic].[object_id] = [cl].[object_id]  ");
		stringBuilder.Append("and [ic].[column_id] = [cl].[column_id] ");
		stringBuilder.Append("inner join [" + BaseDadosERP.NomeServidor + "].[sys].[types] as [tp] ");
		stringBuilder.Append("on [cl].[system_type_id] = [tp].[system_type_id] ");
		stringBuilder.Append("where [ic].[object_id] = @object_id ");
		stringBuilder.Append("and [ic].[index_id] = @index_id ");
		stringBuilder.Append("and [tp].[schema_id] = 4 ");
		stringBuilder.Append("order by ");
		stringBuilder.Append("[ic].[index_column_id] ");
		list.Add(BaseDadosERP.ObterNovoParametro("@object_id", objectId));
		list.Add(BaseDadosERP.ObterNovoParametro("@index_id", indexId));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableIndices> list2 = new List<MapTableIndices>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearIndices(row));
		}
		return list2;
	}
}
