using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalCest : INotaFiscalCest
{
	private MapTableNotaFiscalCest MapearClasse(DataRow row)
	{
		MapTableNotaFiscalCest result = default(MapTableNotaFiscalCest);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoCest = BaseDadosERP.ObterDbValor<string>(row["codigoCest"]);
			result.ncm = BaseDadosGPS.ObterDbValor<string>(row["ncm"]);
			result.codigoEstado = BaseDadosERP.ObterDbValor<int>(row["codigoEstado"]);
			result.valorMva = BaseDadosERP.ObterDbValor<decimal>(row["valorMva"]);
			result.percentualIcmsSt = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsSt"]);
			result.percentualReducaoBaseCalculoICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualReducaoBaseCalculoICMSST"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_cest] as [codigoCest], ");
		stringBuilder.Append("[cd_ncm] as [ncm], ");
		stringBuilder.Append("[cd_uf] as [codigoEstado], ");
		stringBuilder.Append("[pc_mva] as [valorMva], ");
		stringBuilder.Append("[pc_icms_st] as [percentualIcmsSt], ");
		stringBuilder.Append("[pc_base_red_st] as [percentualReducaoBaseCalculoICMSST]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Cest] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalCest> ObterTodosNotaFiscalCest()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [cd_cest] = @cd_cest and");
		stringBuilder.Append(" [cd_ncm] = @cd_ncm and");
		stringBuilder.Append(" [cd_uf] = @cd_uf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cest", codigoCest));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ncm", string.Empty));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_uf", codigoEstado));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCest ObterNotaFiscalCest(string codigoCest, string ncm, int codigoEstado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_cest] = @cd_cest and");
		stringBuilder.Append(" [cd_ncm] = @cd_ncm and");
		stringBuilder.Append(" [cd_uf] = @cd_uf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cest", codigoCest));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ncm", ncm));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_uf", codigoEstado));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCest ObterNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalCest.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest)
	{
		TimeSpan timeSpan = new TimeSpan(9, 0, 0);
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Cest] (");
		stringBuilder.Append("[cd_cest], ");
		stringBuilder.Append("[cd_ncm], ");
		stringBuilder.Append("[cd_uf], ");
		stringBuilder.Append("[pc_mva], ");
		stringBuilder.Append("[pc_icms_st], ");
		stringBuilder.Append("[pc_base_red_st]) Values (@cd_cest,@cd_ncm,@cd_uf,@pc_mva,@pc_icms_st,@pc_base_red_st) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cest", string.IsNullOrWhiteSpace(NotaFiscalCest.codigoCest) ? string.Empty : NotaFiscalCest.codigoCest));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ncm", string.IsNullOrWhiteSpace(NotaFiscalCest.ncm) ? string.Empty : NotaFiscalCest.ncm));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_uf", NotaFiscalCest.codigoEstado));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_mva", NotaFiscalCest.valorMva));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_st", NotaFiscalCest.percentualIcmsSt));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_base_red_st", NotaFiscalCest.percentualReducaoBaseCalculoICMSST));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Cest] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCest", "cd_cest", NotaFiscalCest.codigoCest, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Ncm", "cd_ncm", NotaFiscalCest.ncm, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEstado", "cd_uf", NotaFiscalCest.codigoEstado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorMva", "pc_mva", NotaFiscalCest.valorMva, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsSt", "pc_icms_st", NotaFiscalCest.percentualIcmsSt, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualReducaoBaseCalculoICMSST", "pc_base_red_st", NotaFiscalCest.percentualReducaoBaseCalculoICMSST, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id ");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalCest.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalCest(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Cest] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
