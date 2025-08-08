using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotasFiscaisEventos : INotasFiscaisEventos
{
	private MapTableNotasFiscaisEventos MapearClasse(DataRow row)
	{
		MapTableNotasFiscaisEventos result = default(MapTableNotasFiscaisEventos);
		if (row != null)
		{
			result.codigoNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.codigoSerieNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoEvento = BaseDadosGPS.ObterDbValor<int>(row["codigoEvento"]);
			result.codigoSequenciaEvento = BaseDadosGPS.ObterDbValor<int>(row["codigoSequenciaEvento"]);
			result.evento = BaseDadosGPS.ObterDbValor<string>(row["evento"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
			result.protocolo = BaseDadosGPS.ObterDbValor<string>(row["protocolo"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_serie_nf as codigoNotaFiscal, ");
		stringBuilder.Append("cd_nota_fiscal as codigoSerieNotaFiscal, ");
		stringBuilder.Append("cd_evento as codigoEvento, ");
		stringBuilder.Append("cd_evento_seq as codigoSequenciaEvento, ");
		stringBuilder.Append("nm_evento as evento, ");
		stringBuilder.Append("ds_evento as descricao, ");
		stringBuilder.Append("nm_protocolo as protocolo");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisEventos ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotasFiscaisEventos> list = new List<MapTableNotasFiscaisEventos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotasFiscaisEventos ObterNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_evento = ? and");
		stringBuilder.Append(" cd_evento_seq = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento", codigoEvento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento_seq", codigoSequenciaEvento));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotasFiscaisEventos ObterNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_evento = ? and");
		stringBuilder.Append(" cd_evento_seq = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotasFiscaisEventos.codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotasFiscaisEventos.codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento", NotasFiscaisEventos.codigoEvento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento_seq", NotasFiscaisEventos.codigoSequenciaEvento));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisEventos (");
		stringBuilder.Append("cd_serie_nf, ");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("cd_evento, ");
		stringBuilder.Append("cd_evento_seq, ");
		stringBuilder.Append("nm_evento, ");
		stringBuilder.Append("ds_evento, ");
		stringBuilder.Append("nm_protocolo) Values (?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotasFiscaisEventos.codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotasFiscaisEventos.codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento", NotasFiscaisEventos.codigoEvento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento_seq", NotasFiscaisEventos.codigoSequenciaEvento));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_evento", NotasFiscaisEventos.evento));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_evento", NotasFiscaisEventos.descricao));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_protocolo", NotasFiscaisEventos.protocolo));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisEventos Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Evento", "nm_evento", NotasFiscaisEventos.evento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_evento", NotasFiscaisEventos.descricao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Protocolo", "nm_protocolo", NotasFiscaisEventos.protocolo, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_serie_nf = ? and ");
			stringBuilder.Append("cd_nota_fiscal = ? and ");
			stringBuilder.Append("cd_evento = ? and ");
			stringBuilder.Append("cd_evento_seq = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotasFiscaisEventos.codigoNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotasFiscaisEventos.codigoSerieNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento", NotasFiscaisEventos.codigoEvento));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento_seq", NotasFiscaisEventos.codigoSequenciaEvento));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisEventos ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" cd_evento = ? and");
		stringBuilder.Append(" cd_evento_seq = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento", codigoEvento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_evento_seq", codigoSequenciaEvento));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}
}
