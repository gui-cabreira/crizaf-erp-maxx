using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalNotasFiscaisItensDI : INotaFiscalNotasFiscaisItensDI
{
	private MapTableNotaFiscalNotasFiscaisItensDI MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscaisItensDI result = default(MapTableNotaFiscalNotasFiscaisItensDI);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoSerieNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.ordem = BaseDadosERP.ObterDbValor<int>(row["ordem"]);
			result.numeroDI = BaseDadosERP.ObterDbValor<string>(row["numeroDI"]);
			result.datasDI = BaseDadosERP.ObterDbValor<DateTime>(row["datasDI"]);
			result.localDesembarque = BaseDadosERP.ObterDbValor<string>(row["localDesembarque"]);
			result.ufDesembarque = BaseDadosERP.ObterDbValor<string>(row["ufDesembarque"]);
			result.dataDesembarque = BaseDadosERP.ObterDbValor<DateTime>(row["dataDesembarque"]);
			result.tipoViaTransporte = BaseDadosERP.ObterDbValor<int>(row["tipoViaTransporte"]);
			result.vafrmm = BaseDadosERP.ObterDbValor<decimal>(row["vafrmm"]);
			result.tipoIntermedio = BaseDadosERP.ObterDbValor<int>(row["tipoIntermedio"]);
			result.cnpja = BaseDadosERP.ObterDbValor<string>(row["cnpja"]);
			result.ufTerceiro = BaseDadosERP.ObterDbValor<string>(row["ufTerceiro"]);
			result.codigoExportador = BaseDadosERP.ObterDbValor<string>(row["codigoExportador"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_serie_nf] as [codigoSerieNotaFiscal], ");
		stringBuilder.Append("[cd_nota_fiscal] as [codigoNotaFiscal], ");
		stringBuilder.Append("[vl_ordem] as [ordem], ");
		stringBuilder.Append("[nDi] as [numeroDI], ");
		stringBuilder.Append("[dDi] as [datasDI], ");
		stringBuilder.Append("[xLocDesemb] as [localDesembarque], ");
		stringBuilder.Append("[UFDesemb] as [ufDesembarque], ");
		stringBuilder.Append("[dDesemb] as [dataDesembarque], ");
		stringBuilder.Append("[tpViaTransp] as [tipoViaTransporte], ");
		stringBuilder.Append("[vafrmm] as [vafrmm], ");
		stringBuilder.Append("[tpIntermedio] as [tipoIntermedio], ");
		stringBuilder.Append("[cnpj] as [cnpja], ");
		stringBuilder.Append("[UFTerceiro] as [ufTerceiro], ");
		stringBuilder.Append("[cExportador] as [codigoExportador]");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDI] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItensDI> ObterTodosNotaFiscalNotasFiscaisItensDI()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", numeroDI));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItensDI.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItensDI.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItensDI.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItensDI.ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", NotaFiscalNotasFiscaisItensDI.numeroDI));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisItensDI] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_serie_nf], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[vl_ordem], ");
		stringBuilder.Append("[nDi], ");
		stringBuilder.Append("[dDi], ");
		stringBuilder.Append("[xLocDesemb], ");
		stringBuilder.Append("[UFDesemb], ");
		stringBuilder.Append("[dDesemb], ");
		stringBuilder.Append("[tpViaTransp], ");
		stringBuilder.Append("[vafrmm], ");
		stringBuilder.Append("[tpIntermedio], ");
		stringBuilder.Append("[cnpj], ");
		stringBuilder.Append("[UFTerceiro], ");
		stringBuilder.Append("[cExportador]) Values (@cd_empresa, @cd_serie_nf,@cd_nota_fiscal,@vl_ordem,@nDi,@dDi,@xLocDesemb,@UFDesemb,@dDesemb,@tpViaTransp,@vafrmm,@tpIntermedio,@cnpj,@UFTerceiro,@cExportador) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItensDI.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItensDI.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItensDI.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItensDI.ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", NotaFiscalNotasFiscaisItensDI.numeroDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@dDi", NotaFiscalNotasFiscaisItensDI.datasDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@xLocDesemb", NotaFiscalNotasFiscaisItensDI.localDesembarque));
		list.Add(BaseDadosERP.ObterNovoParametro("@UFDesemb", NotaFiscalNotasFiscaisItensDI.ufDesembarque));
		list.Add(BaseDadosERP.ObterNovoParametro("@dDesemb", NotaFiscalNotasFiscaisItensDI.dataDesembarque));
		list.Add(BaseDadosERP.ObterNovoParametro("@tpViaTransp", NotaFiscalNotasFiscaisItensDI.tipoViaTransporte));
		list.Add(BaseDadosERP.ObterNovoParametro("@vafrmm", NotaFiscalNotasFiscaisItensDI.vafrmm));
		list.Add(BaseDadosERP.ObterNovoParametro("@tpIntermedio", NotaFiscalNotasFiscaisItensDI.tipoIntermedio));
		list.Add(BaseDadosERP.ObterNovoParametro("@cnpj", NotaFiscalNotasFiscaisItensDI.cnpja));
		list.Add(BaseDadosERP.ObterNovoParametro("@UFTerceiro", NotaFiscalNotasFiscaisItensDI.ufTerceiro));
		list.Add(BaseDadosERP.ObterNovoParametro("@cExportador", NotaFiscalNotasFiscaisItensDI.codigoExportador));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisItensDI] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DatasDI", "dDi", NotaFiscalNotasFiscaisItensDI.datasDI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "LocalDesembarque", "xLocDesemb", NotaFiscalNotasFiscaisItensDI.localDesembarque, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "UfDesembarque", "UFDesemb", NotaFiscalNotasFiscaisItensDI.ufDesembarque, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataDesembarque", "dDesemb", NotaFiscalNotasFiscaisItensDI.dataDesembarque, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoViaTransporte", "tpViaTransp", NotaFiscalNotasFiscaisItensDI.tipoViaTransporte, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Vafrmm", "vafrmm", NotaFiscalNotasFiscaisItensDI.vafrmm, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoIntermedio", "tpIntermedio", NotaFiscalNotasFiscaisItensDI.tipoIntermedio, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cnpja", "cnpj", NotaFiscalNotasFiscaisItensDI.cnpja, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "UfTerceiro", "UFTerceiro", NotaFiscalNotasFiscaisItensDI.ufTerceiro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoExportador", "cExportador", NotaFiscalNotasFiscaisItensDI.codigoExportador, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append(" [cd_empresa] = @cd_empresa and ");
			stringBuilder.Append("cd_serie_nf = @cd_serie_nf and ");
			stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
			stringBuilder.Append("vl_ordem = @vl_ordem and ");
			stringBuilder.Append("nDi = @nDi");
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItensDI.codigoEmpresa));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItensDI.codigoSerieNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItensDI.codigoNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItensDI.ordem));
			list.Add(BaseDadosERP.ObterNovoParametro("@nDi", NotaFiscalNotasFiscaisItensDI.numeroDI));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDI] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem and");
		stringBuilder.Append(" [nDi] = @nDi");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nDi", numeroDI));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItensDI] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
