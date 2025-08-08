using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalPaises : INotaFiscalPaises
{
	private MapTableNotaFiscalPaises MapearClasse(DataRow row)
	{
		MapTableNotaFiscalPaises result = default(MapTableNotaFiscalPaises);
		if (row != null)
		{
			result.pais = BaseDadosERP.ObterDbValor<string>(row["pais"]);
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("nm_pais as pais, ");
		stringBuilder.Append("cd_pais as codigo");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalPaises ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalPaises> ObterTodosNotaFiscalPaises()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalPaises> list = new List<MapTableNotaFiscalPaises>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalPaises ObterNotaFiscalPaises(string pais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_pais = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_pais", pais));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalPaises ObterNotaFiscalPaises(int codigoPais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_pais = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_pais", codigoPais));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalPaises ObterNotaFiscalPaises(MapTableNotaFiscalPaises NotaFiscalPaises)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_pais = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_pais", NotaFiscalPaises.pais));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalPaises(MapTableNotaFiscalPaises NotaFiscalPaises)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalPaises (");
		stringBuilder.Append("nm_pais, ");
		stringBuilder.Append("cd_pais) Values (?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_pais", NotaFiscalPaises.pais));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_pais", NotaFiscalPaises.codigo));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalPaises(MapTableNotaFiscalPaises NotaFiscalPaises, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalPaises Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Codigo", "cd_pais", NotaFiscalPaises.codigo, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("nm_pais = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("nm_pais", NotaFiscalPaises.pais));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalPaises(string pais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalPaises ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_pais = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_pais", pais));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
