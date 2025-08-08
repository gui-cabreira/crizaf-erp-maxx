using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalFatura : INotaFiscalFatura
{
	private MapTableNotaFiscalFatura MapearClasse(DataRow row)
	{
		MapTableNotaFiscalFatura result = default(MapTableNotaFiscalFatura);
		if (row != null)
		{
			result.codigoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.codigoFatura = BaseDadosERP.ObterDbValor<string>(row["codigoFatura"]);
			result.valorFatura = BaseDadosERP.ObterDbValor<decimal>(row["valorFatura"]);
			result.vencimento = BaseDadosERP.ObterDbValor<DateTime>(row["vencimento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_nota_fiscal as codigoNotaFiscal, ");
		stringBuilder.Append("nm_fatura as codigoFatura, ");
		stringBuilder.Append("vl_fatura as valorFatura, ");
		stringBuilder.Append("dt_vencimento as vencimento");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalFatura ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalFatura> ObterTodosNotaFiscalFatura()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalFatura> list = new List<MapTableNotaFiscalFatura>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalFatura ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, string codigoFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" nm_fatura = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_fatura", codigoFatura));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public IList<MapTableNotaFiscalFatura> ObterNotaFiscalFatura(int codigoNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalFatura> list2 = new List<MapTableNotaFiscalFatura>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalFatura ObterNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" nm_fatura = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalFatura.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_fatura", NotaFiscalFatura.codigoFatura));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalFatura (");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("nm_fatura, ");
		stringBuilder.Append("vl_fatura, ");
		stringBuilder.Append("dt_vencimento) Values (?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalFatura.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_fatura", NotaFiscalFatura.codigoFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_fatura", NotaFiscalFatura.valorFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_vencimento", NotaFiscalFatura.vencimento));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalFatura Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFatura", "vl_fatura", NotaFiscalFatura.valorFatura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Vencimento", "dt_vencimento", NotaFiscalFatura.vencimento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_nota_fiscal = ? and ");
			stringBuilder.Append("nm_fatura = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalFatura.codigoNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("nm_fatura", NotaFiscalFatura.codigoFatura));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, string codigoFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalFatura ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" nm_fatura = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_fatura", codigoFatura));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalFatura(int codigoNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalFatura ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotaFiscalFatura> ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalFatura ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		throw new NotImplementedException();
	}
}
