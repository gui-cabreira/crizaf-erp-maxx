using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalCest : INotaFiscalCest
{
	private MapTableNotaFiscalCest MapearClasse(DataRow row)
	{
		MapTableNotaFiscalCest result = default(MapTableNotaFiscalCest);
		if (row != null)
		{
			result.codigoCest = BaseDadosGPS.ObterDbValor<string>(row["codigoCest"]);
			result.ncm = BaseDadosGPS.ObterDbValor<string>(row["ncm"]);
			result.codigoEstado = BaseDadosGPS.ObterDbValor<int>(row["codigoEstado"]);
			result.valorMva = BaseDadosGPS.ObterDbValor<decimal>(row["valorMva"]);
			result.percentualIcmsSt = BaseDadosGPS.ObterDbValor<decimal>(row["percentualIcmsSt"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_cest as codigoCest, ");
		stringBuilder.Append("cd_ncm as ncm, ");
		stringBuilder.Append("cd_uf as codigoEstado, ");
		stringBuilder.Append("pc_mva as valorMva, ");
		stringBuilder.Append("pc_icms_st as percentualIcmsSt");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalCest ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalCest> ObterTodosNotaFiscalCest()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalCest> list = new List<MapTableNotaFiscalCest>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalCest ObterNotaFiscalCest(string codigoCest, int codigoEstado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_cest = ? and");
		stringBuilder.Append(" cd_ncm = ? and");
		stringBuilder.Append(" cd_uf = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cest", codigoCest));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_ncm", string.Empty));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_uf", codigoEstado));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCest ObterNotaFiscalCest(string codigoCest, string ncm, int codigoEstado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_cest = ? and");
		stringBuilder.Append(" cd_ncm = ? and");
		stringBuilder.Append(" cd_uf = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cest", codigoCest));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_ncm", ncm));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_uf", codigoEstado));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCest ObterNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ? ");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", NotaFiscalCest.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalCest (");
		stringBuilder.Append("cd_cest, ");
		stringBuilder.Append("cd_ncm, ");
		stringBuilder.Append("cd_uf, ");
		stringBuilder.Append("pc_mva, ");
		stringBuilder.Append("pc_icms_st) Values (?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cest", NotaFiscalCest.codigoCest));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_ncm", NotaFiscalCest.ncm));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_uf", NotaFiscalCest.codigoEstado));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_mva", NotaFiscalCest.valorMva));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_icms_st", NotaFiscalCest.percentualIcmsSt));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalCest Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorMva", "pc_mva", NotaFiscalCest.valorMva, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsSt", "pc_icms_st", NotaFiscalCest.percentualIcmsSt, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_cest = ? and ");
			stringBuilder.Append("cd_ncm = ? and ");
			stringBuilder.Append("cd_uf = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_cest", NotaFiscalCest.codigoCest));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_ncm", NotaFiscalCest.ncm));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_uf", NotaFiscalCest.codigoEstado));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalCest(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalCest ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ? ");
		stringBuilder.Append(" cd_uf = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
