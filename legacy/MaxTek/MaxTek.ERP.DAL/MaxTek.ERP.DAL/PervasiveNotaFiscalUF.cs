using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalUF : INotaFiscalUF
{
	private MapTableNotaFiscalUF MapearClasse(DataRow row)
	{
		MapTableNotaFiscalUF result = default(MapTableNotaFiscalUF);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.siglaUF = BaseDadosERP.ObterDbValor<string>(row["siglaUF"]);
			result.nomeUF = BaseDadosERP.ObterDbValor<string>(row["nomeUF"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_uf as siglaUF, ");
		stringBuilder.Append("ds_uf as nomeUF");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalUF ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalUF> ObterTodosNotaFiscalUF()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalUF> list = new List<MapTableNotaFiscalUF>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalUF ObterNotaFiscalUF(int id)
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

	public MapTableNotaFiscalUF ObterNotaFiscalUF(string uf)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_uf = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_uf", uf.ToUpper()));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalUF ObterNotaFiscalUF(MapTableNotaFiscalUF NotaFiscalUF)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalUF.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalUF(MapTableNotaFiscalUF NotaFiscalUF)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalUF (");
		stringBuilder.Append("nm_uf, ");
		stringBuilder.Append("ds_uf) Values (?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_uf", NotaFiscalUF.siglaUF));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_uf", NotaFiscalUF.nomeUF));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalUF(MapTableNotaFiscalUF NotaFiscalUF, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalUF Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SiglaUF", "nm_uf", NotaFiscalUF.siglaUF, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeUF", "ds_uf", NotaFiscalUF.nomeUF, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalUF.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalUF(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalUF ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
