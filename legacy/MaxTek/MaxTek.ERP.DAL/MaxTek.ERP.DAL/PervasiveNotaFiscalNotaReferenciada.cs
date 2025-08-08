using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalNotaReferenciada : INotaFiscalNotaReferenciada
{
	private MapTableNotaFiscalNotaReferenciada MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotaReferenciada result = default(MapTableNotaFiscalNotaReferenciada);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosGPS.ObterDbValor<int>(row["codigoEmpresa"]);
			result.numeroNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["numeroNotaFiscal"]);
			result.codigoSerieNF = BaseDadosGPS.ObterDbValor<int>(row["codigoSerieNF"]);
			result.notaReferenciada = BaseDadosGPS.ObterDbValor<string>(row["notaReferenciada"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_empresa as codigoEmpresa, ");
		stringBuilder.Append("cd_nota_fiscal as numeroNotaFiscal, ");
		stringBuilder.Append("cd_serie_nota_fiscal as codigoSerieNF, ");
		stringBuilder.Append("nm_nota_referenciada as notaReferenciada");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaReferenciada ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotaReferenciada> ObterTodosNotaFiscalNotaReferenciada()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotaReferenciada> list = new List<MapTableNotaFiscalNotaReferenciada>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalNotaReferenciada> ObterTodosNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_empresa = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_serie_nota_fiscal = ? ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", codigoSerieNF));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotaReferenciada> list2 = new List<MapTableNotaFiscalNotaReferenciada>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_empresa = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_serie_nota_fiscal = ? and");
		stringBuilder.Append(" nm_nota_referenciada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", codigoSerieNF));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_nota_referenciada", notaReferenciada));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_empresa = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_serie_nota_fiscal = ? and");
		stringBuilder.Append(" nm_nota_referenciada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", NotaFiscalNotaReferenciada.codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotaReferenciada.numeroNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", NotaFiscalNotaReferenciada.codigoSerieNF));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_nota_referenciada", NotaFiscalNotaReferenciada.notaReferenciada));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NotaReferenciada (");
		stringBuilder.Append("cd_empresa, ");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("cd_serie_nota_fiscal, ");
		stringBuilder.Append("nm_nota_referenciada) Values (?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", NotaFiscalNotaReferenciada.codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotaReferenciada.numeroNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", NotaFiscalNotaReferenciada.codigoSerieNF));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_nota_referenciada", NotaFiscalNotaReferenciada.notaReferenciada));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NotaReferenciada Set ");
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_empresa = ? and ");
			stringBuilder.Append("cd_nota_fiscal = ? and ");
			stringBuilder.Append("cd_serie_nota_fiscal = ? and ");
			stringBuilder.Append("nm_nota_referenciada = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", NotaFiscalNotaReferenciada.codigoEmpresa));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotaReferenciada.numeroNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", NotaFiscalNotaReferenciada.codigoSerieNF));
			list.Add(BaseDadosGPS.ObterNovoParametro("nm_nota_referenciada", NotaFiscalNotaReferenciada.notaReferenciada));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaReferenciada ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_empresa = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_serie_nota_fiscal = ? and");
		stringBuilder.Append(" nm_nota_referenciada = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", codigoSerieNF));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_nota_referenciada", notaReferenciada));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaReferenciada ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_empresa = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_serie_nota_fiscal = ? ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_empresa", codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nota_fiscal", codigoSerieNF));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
