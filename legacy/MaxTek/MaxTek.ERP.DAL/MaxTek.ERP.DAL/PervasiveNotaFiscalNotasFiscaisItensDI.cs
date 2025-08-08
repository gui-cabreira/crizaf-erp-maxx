using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalNotasFiscaisItensDI : INotaFiscalNotasFiscaisItensDI
{
	private MapTableNotaFiscalNotasFiscaisItensDI MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscaisItensDI result = default(MapTableNotaFiscalNotasFiscaisItensDI);
		if (row != null)
		{
			result.codigoSerieNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.ordem = BaseDadosGPS.ObterDbValor<int>(row["ordem"]);
			result.numeroDI = BaseDadosGPS.ObterDbValor<string>(row["numeroDI"]);
			result.datasDI = BaseDadosGPS.ObterDbValor<DateTime>(row["datasDI"]);
			result.localDesembarque = BaseDadosGPS.ObterDbValor<string>(row["localDesembarque"]);
			result.ufDesembarque = BaseDadosGPS.ObterDbValor<string>(row["ufDesembarque"]);
			result.dataDesembarque = BaseDadosGPS.ObterDbValor<DateTime>(row["dataDesembarque"]);
			result.tipoViaTransporte = BaseDadosGPS.ObterDbValor<int>(row["tipoViaTransporte"]);
			result.vafrmm = BaseDadosGPS.ObterDbValor<decimal>(row["vafrmm"]);
			result.tipoIntermedio = BaseDadosGPS.ObterDbValor<int>(row["tipoIntermedio"]);
			result.cnpja = BaseDadosGPS.ObterDbValor<string>(row["cnpja"]);
			result.ufTerceiro = BaseDadosGPS.ObterDbValor<string>(row["ufTerceiro"]);
			result.codigoExportador = BaseDadosGPS.ObterDbValor<string>(row["codigoExportador"]);
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
		stringBuilder.Append("dDi as datasDI, ");
		stringBuilder.Append("xLocDesemb as localDesembarque, ");
		stringBuilder.Append("UFDesemb as ufDesembarque, ");
		stringBuilder.Append("dDesemb as dataDesembarque, ");
		stringBuilder.Append("tpViaTransp as tipoViaTransporte, ");
		stringBuilder.Append("vafrmm as vafrmm, ");
		stringBuilder.Append("tpIntermedio as tipoIntermedio, ");
		stringBuilder.Append("cnpj as cnpja, ");
		stringBuilder.Append("UFTerceiro as ufTerceiro, ");
		stringBuilder.Append("cExportador as codigoExportador");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisItensDI ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItensDI> ObterTodosNotaFiscalNotasFiscaisItensDI()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotasFiscaisItensDI> list = new List<MapTableNotaFiscalNotasFiscaisItensDI>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? and");
		stringBuilder.Append(" nDi = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", numeroDI));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? and");
		stringBuilder.Append(" nDi = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotaFiscalNotasFiscaisItensDI.codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItensDI.codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItensDI.ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", NotaFiscalNotasFiscaisItensDI.numeroDI));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisItensDI (");
		stringBuilder.Append("cd_serie_nf, ");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("vl_ordem, ");
		stringBuilder.Append("nDi, ");
		stringBuilder.Append("dDi, ");
		stringBuilder.Append("xLocDesemb, ");
		stringBuilder.Append("UFDesemb, ");
		stringBuilder.Append("dDesemb, ");
		stringBuilder.Append("tpViaTransp, ");
		stringBuilder.Append("vafrmm, ");
		stringBuilder.Append("tpIntermedio, ");
		stringBuilder.Append("cnpj, ");
		stringBuilder.Append("UFTerceiro, ");
		stringBuilder.Append("cExportador) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotaFiscalNotasFiscaisItensDI.codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItensDI.codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItensDI.ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", NotaFiscalNotasFiscaisItensDI.numeroDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("dDi", NotaFiscalNotasFiscaisItensDI.datasDI));
		list.Add(BaseDadosGPS.ObterNovoParametro("xLocDesemb", NotaFiscalNotasFiscaisItensDI.localDesembarque));
		list.Add(BaseDadosGPS.ObterNovoParametro("UFDesemb", NotaFiscalNotasFiscaisItensDI.ufDesembarque));
		list.Add(BaseDadosGPS.ObterNovoParametro("dDesemb", NotaFiscalNotasFiscaisItensDI.dataDesembarque));
		list.Add(BaseDadosGPS.ObterNovoParametro("tpViaTransp", NotaFiscalNotasFiscaisItensDI.tipoViaTransporte));
		list.Add(BaseDadosGPS.ObterNovoParametro("vafrmm", NotaFiscalNotasFiscaisItensDI.vafrmm));
		list.Add(BaseDadosGPS.ObterNovoParametro("tpIntermedio", NotaFiscalNotasFiscaisItensDI.tipoIntermedio));
		list.Add(BaseDadosGPS.ObterNovoParametro("cnpj", NotaFiscalNotasFiscaisItensDI.cnpja));
		list.Add(BaseDadosGPS.ObterNovoParametro("UFTerceiro", NotaFiscalNotasFiscaisItensDI.ufTerceiro));
		list.Add(BaseDadosGPS.ObterNovoParametro("cExportador", NotaFiscalNotasFiscaisItensDI.codigoExportador));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisItensDI Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DatasDI", "dDi", NotaFiscalNotasFiscaisItensDI.datasDI, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "LocalDesembarque", "xLocDesemb", NotaFiscalNotasFiscaisItensDI.localDesembarque, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "UfDesembarque", "UFDesemb", NotaFiscalNotasFiscaisItensDI.ufDesembarque, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataDesembarque", "dDesemb", NotaFiscalNotasFiscaisItensDI.dataDesembarque, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TipoViaTransporte", "tpViaTransp", NotaFiscalNotasFiscaisItensDI.tipoViaTransporte, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Vafrmm", "vafrmm", NotaFiscalNotasFiscaisItensDI.vafrmm, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TipoIntermedio", "tpIntermedio", NotaFiscalNotasFiscaisItensDI.tipoIntermedio, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Cnpja", "cnpj", NotaFiscalNotasFiscaisItensDI.cnpja, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "UfTerceiro", "UFTerceiro", NotaFiscalNotasFiscaisItensDI.ufTerceiro, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoExportador", "cExportador", NotaFiscalNotasFiscaisItensDI.codigoExportador, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_serie_nf = ? and ");
			stringBuilder.Append("cd_nota_fiscal = ? and ");
			stringBuilder.Append("vl_ordem = ? and ");
			stringBuilder.Append("nDi = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", NotaFiscalNotasFiscaisItensDI.codigoSerieNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItensDI.codigoNotaFiscal));
			list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItensDI.ordem));
			list.Add(BaseDadosGPS.ObterNovoParametro("nDi", NotaFiscalNotasFiscaisItensDI.numeroDI));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.NotasFiscaisItensDI ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_serie_nf = ? and");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? and");
		stringBuilder.Append(" nDi = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_ordem", ordem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nDi", numeroDI));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal)
	{
		throw new NotImplementedException();
	}
}
