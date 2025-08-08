using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalFormasPagto : INotaFiscalFormasPagto
{
	private MapTableNotaFiscalFormasPagto MapearClasse(DataRow row)
	{
		MapTableNotaFiscalFormasPagto result = default(MapTableNotaFiscalFormasPagto);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.descricaoFormaPagamento = BaseDadosERP.ObterDbValor<string>(row["descricaoFormaPagamento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_forma_pagto as descricaoFormaPagamento");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NFFormasPagto ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalFormasPagto> ObterTodosNotaFiscalFormasPagto()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalFormasPagto> list = new List<MapTableNotaFiscalFormasPagto>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalFormasPagto ObterNotaFiscalFormasPagto(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalFormasPagto ObterNotaFiscalFormasPagto(MapTableNotaFiscalFormasPagto NotaFiscalFormasPagto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalFormasPagto.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalFormasPagto(MapTableNotaFiscalFormasPagto NotaFiscalFormasPagto)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NFFormasPagto (");
		stringBuilder.Append("nm_forma_pagto) Values (?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_forma_pagto", NotaFiscalFormasPagto.descricaoFormaPagamento));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalFormasPagto(MapTableNotaFiscalFormasPagto NotaFiscalFormasPagto, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NFFormasPagto Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoFormaPagamento", "nm_forma_pagto", NotaFiscalFormasPagto.descricaoFormaPagamento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalFormasPagto.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalFormasPagto(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NFFormasPagto ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
