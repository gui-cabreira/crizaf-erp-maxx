using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalSerie : INotaFiscalSerie
{
	private MapTableNotaFiscalSerie MapearClasse(DataRow row)
	{
		MapTableNotaFiscalSerie result = default(MapTableNotaFiscalSerie);
		if (row != null)
		{
			result.codigoSerie = BaseDadosGPS.ObterDbValor<int>(row["codigoSerie"]);
			result.nomeSerie = BaseDadosGPS.ObterDbValor<string>(row["nomeSerie"]);
			result.proximoNumero = BaseDadosGPS.ObterDbValor<int>(row["proximoNumero"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_serie as codigoSerie, ");
		stringBuilder.Append("nm_serie as nomeSerie, ");
		stringBuilder.Append("cd_proximo_numero as proximoNumero");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalSerie ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalSerie> ObterTodosNotaFiscalSerie()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalSerie> list = new List<MapTableNotaFiscalSerie>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalSerie ObterNotaFiscalSerie(int codigoSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie", codigoSerie));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalSerie ObterNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie", NotaFiscalSerie.codigoSerie));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalSerie (");
		stringBuilder.Append("cd_serie, ");
		stringBuilder.Append("nm_serie, ");
		stringBuilder.Append("cd_proximo_numero) Values (?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie", NotaFiscalSerie.codigoSerie));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_serie", NotaFiscalSerie.nomeSerie));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_proximo_numero", NotaFiscalSerie.proximoNumero));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalSerie Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NomeSerie", "nm_serie", NotaFiscalSerie.nomeSerie, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ProximoNumero", "cd_proximo_numero", NotaFiscalSerie.proximoNumero, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_serie = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie", NotaFiscalSerie.codigoSerie));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalSerie(int codigoSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NotaFiscalSerie ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie", codigoSerie));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotaFiscalSerie> ObterTodosNotaFiscalSerie(int codigoEmpresa)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa, int codigoSerie)
	{
		throw new NotImplementedException();
	}
}
