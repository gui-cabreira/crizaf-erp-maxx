using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalOrigemProduto : INotaFiscalOrigemProduto
{
	private MapTableNotaFiscalOrigemProduto MapearClasse(DataRow row)
	{
		MapTableNotaFiscalOrigemProduto result = default(MapTableNotaFiscalOrigemProduto);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.origemProduto = BaseDadosERP.ObterDbValor<string>(row["origemProduto"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[ds_origem_produto] as [origemProduto]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[OrigemProduto] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalOrigemProduto> ObterTodosNotaFiscalOrigemProduto()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalOrigemProduto> list = new List<MapTableNotaFiscalOrigemProduto>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalOrigemProduto ObterNotaFiscalOrigemProduto(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalOrigemProduto ObterNotaFiscalOrigemProduto(MapTableNotaFiscalOrigemProduto NotaFiscalOrigemProduto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalOrigemProduto.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalOrigemProduto(MapTableNotaFiscalOrigemProduto NotaFiscalOrigemProduto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[OrigemProduto] (");
		stringBuilder.Append("[ds_origem_produto]) Values (@ds_origem_produto) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_origem_produto", NotaFiscalOrigemProduto.origemProduto));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalOrigemProduto(MapTableNotaFiscalOrigemProduto NotaFiscalOrigemProduto, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[OrigemProduto] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "OrigemProduto", "ds_origem_produto", NotaFiscalOrigemProduto.origemProduto, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalOrigemProduto.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalOrigemProduto(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[OrigemProduto] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
