using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalNotasFiscaisItensDIAdicoes : INotaFiscalNotasFiscaisItensDIAdicoes
{
	private MapTableNotaFiscalNotasFiscaisItensDIAdicoes MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscaisItensDIAdicoes result = default(MapTableNotaFiscalNotasFiscaisItensDIAdicoes);
		if (row != null)
		{
			result.codigoSerieNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.ordem = BaseDadosGPS.ObterDbValor<int>(row["ordem"]);
			result.numeroDI = BaseDadosGPS.ObterDbValor<string>(row["numeroDI"]);
			result.numeroAdicao = BaseDadosGPS.ObterDbValor<int>(row["numeroAdicao"]);
			result.numeroSequenciaAdicao = BaseDadosGPS.ObterDbValor<int>(row["numeroSequenciaAdicao"]);
			result.codigoFabricante = BaseDadosGPS.ObterDbValor<string>(row["codigoFabricante"]);
			result.valorDescontoDI = BaseDadosGPS.ObterDbValor<decimal>(row["valorDescontoDI"]);
			result.codigoDrawBack = BaseDadosGPS.ObterDbValor<string>(row["codigoDrawBack"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_serie_nf as codigoSerieNotaFiscal, ");
		stringBuilder.Append("cd_nota_fiscal as codigoNotaFiscal, ");
		stringBuilder.Append("vl_ordem as ordem, ");
		stringBuilder.Append("nDi as numeroDI, ");
		stringBuilder.Append("nAdicao as numeroAdicao, ");
		stringBuilder.Append("nSeqAdic as numeroSequenciaAdicao, ");
		stringBuilder.Append("cFabricante as codigoFabricante, ");
		stringBuilder.Append("vDescDI as valorDescontoDI, ");
		stringBuilder.Append("nDraw as codigoDrawBack");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NFIDIAdicoes ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> list = new List<MapTableNotaFiscalNotasFiscaisItensDIAdicoes>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalNotasFiscaisItensDIAdicoes ObterNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI, int numeroAdicao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? and");
		stringBuilder.Append(" nDi = ? and");
		stringBuilder.Append(" nAdicao = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", numeroDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("nAdicao", numeroAdicao));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscaisItensDIAdicoes ObterNotaFiscalNotasFiscaisItensDIAdicoes(MapTableNotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoes)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? and");
		stringBuilder.Append(" nDi = ? and");
		stringBuilder.Append(" nAdicao = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotaFiscalNotasFiscaisItensDIAdicoes.codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItensDIAdicoes.codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItensDIAdicoes.ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", NotaFiscalNotasFiscaisItensDIAdicoes.numeroDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("nAdicao", NotaFiscalNotasFiscaisItensDIAdicoes.numeroAdicao));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotasFiscaisItensDIAdicoes(MapTableNotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoes)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NFIDIAdicoes (");
		stringBuilder.Append("cd_serie_nf, ");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("vl_ordem, ");
		stringBuilder.Append("nDi, ");
		stringBuilder.Append("nAdicao, ");
		stringBuilder.Append("nSeqAdic, ");
		stringBuilder.Append("cFabricante, ");
		stringBuilder.Append("vDescDI, ");
		stringBuilder.Append("nDraw) Values (?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotaFiscalNotasFiscaisItensDIAdicoes.codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItensDIAdicoes.codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItensDIAdicoes.ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", NotaFiscalNotasFiscaisItensDIAdicoes.numeroDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("nAdicao", NotaFiscalNotasFiscaisItensDIAdicoes.numeroAdicao));
		list.Add(BaseDadosGPS.ObterNovoParametro("nSeqAdic", NotaFiscalNotasFiscaisItensDIAdicoes.numeroSequenciaAdicao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cFabricante", NotaFiscalNotasFiscaisItensDIAdicoes.codigoFabricante));
		list.Add(BaseDadosGPS.ObterNovoParametro("vDescDI", NotaFiscalNotasFiscaisItensDIAdicoes.valorDescontoDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDraw", NotaFiscalNotasFiscaisItensDIAdicoes.codigoDrawBack));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotasFiscaisItensDIAdicoes(MapTableNotaFiscalNotasFiscaisItensDIAdicoes NotaFiscalNotasFiscaisItensDIAdicoes, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NFIDIAdicoes Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NumeroSequenciaAdicao", "nSeqAdic", NotaFiscalNotasFiscaisItensDIAdicoes.numeroSequenciaAdicao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFabricante", "cFabricante", NotaFiscalNotasFiscaisItensDIAdicoes.codigoFabricante, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorDescontoDI", "vDescDI", NotaFiscalNotasFiscaisItensDIAdicoes.valorDescontoDI, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoDrawBack", "nDraw", NotaFiscalNotasFiscaisItensDIAdicoes.codigoDrawBack, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_serie_nf = ? and ");
			stringBuilder.Append("cd_nota_fiscal = ? and ");
			stringBuilder.Append("vl_ordem = ? and ");
			stringBuilder.Append("nDi = ? and ");
			stringBuilder.Append("nAdicao = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotaFiscalNotasFiscaisItensDIAdicoes.codigoSerieNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItensDIAdicoes.codigoNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItensDIAdicoes.ordem));
			list.Add(BaseDadosGPS.ObterNovoParametro("nDi", NotaFiscalNotasFiscaisItensDIAdicoes.numeroDI));
			list.Add(BaseDadosGPS.ObterNovoParametro("nAdicao", NotaFiscalNotasFiscaisItensDIAdicoes.numeroAdicao));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI, int numeroAdicao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NFIDIAdicoes ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? and");
		stringBuilder.Append(" nDi = ? and");
		stringBuilder.Append(" nAdicao = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", numeroDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("nAdicao", numeroAdicao));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotaFiscalNotasFiscaisItensDIAdicoes> ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDIAdicoes(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal)
	{
		throw new NotImplementedException();
	}
}
