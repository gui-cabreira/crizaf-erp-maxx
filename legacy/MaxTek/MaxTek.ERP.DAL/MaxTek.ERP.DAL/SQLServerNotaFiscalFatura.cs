using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalFatura : INotaFiscalFatura
{
	private MapTableNotaFiscalFatura MapearClasse(DataRow row)
	{
		MapTableNotaFiscalFatura result = default(MapTableNotaFiscalFatura);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.codigoFatura = BaseDadosERP.ObterDbValor<string>(row["codigoFatura"]);
			result.valorFatura = BaseDadosERP.ObterDbValor<decimal>(row["valorFatura"]);
			result.vencimento = BaseDadosERP.ObterDbValor<DateTime>(row["vencimento"]);
			result.codigoSerieNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.isNaoGerarTitulo = BaseDadosERP.ObterDbValor<bool>(row["isNaoGerarTitulo"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_nota_fiscal] as [codigoNotaFiscal], ");
		stringBuilder.Append("[nm_fatura] as [codigoFatura], ");
		stringBuilder.Append("[vl_fatura] as [valorFatura], ");
		stringBuilder.Append("[dt_vencimento] as [vencimento], ");
		stringBuilder.Append("[cd_serie_nf] as [codigoSerieNotaFiscal], ");
		stringBuilder.Append("[ic_nao_gerar_titulo] as [isNaoGerarTitulo] ");
		stringBuilder.Append($" from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Fatura] ");
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

	public MapTableNotaFiscalFatura ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [nm_fatura] = @nm_fatura");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fatura", codigoFatura));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public IList<MapTableNotaFiscalFatura> ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
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
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [nm_fatura] = @nm_fatura");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalFatura.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalFatura.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalFatura.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fatura", NotaFiscalFatura.codigoFatura));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Insert into [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Fatura] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[nm_fatura], ");
		stringBuilder.Append("[vl_fatura], ");
		stringBuilder.Append("[dt_vencimento], ");
		stringBuilder.Append("[cd_serie_nf], ");
		stringBuilder.Append("[ic_nao_gerar_titulo]) Values (@cd_empresa,@cd_nota_fiscal,@nm_fatura,@vl_fatura,@dt_vencimento,@cd_serie_nf,@ic_nao_gerar_titulo) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", (NotaFiscalFatura.codigoEmpresa == 0) ? 1 : NotaFiscalFatura.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalFatura.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fatura", NotaFiscalFatura.codigoFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_fatura", NotaFiscalFatura.valorFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_vencimento", NotaFiscalFatura.vencimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalFatura.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_nao_gerar_titulo", NotaFiscalFatura.isNaoGerarTitulo));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append($"Update [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Fatura] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFatura", "vl_fatura", NotaFiscalFatura.valorFatura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Vencimento", "dt_vencimento", NotaFiscalFatura.vencimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsNaoGerarTitulo", "ic_nao_gerar_titulo", NotaFiscalFatura.isNaoGerarTitulo, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append(" [cd_empresa] = @cd_empresa and ");
			stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
			stringBuilder.Append("nm_fatura = @nm_fatura and ");
			stringBuilder.Append("cd_serie_nf = @cd_serie_nf");
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalFatura.codigoEmpresa));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalFatura.codigoNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@nm_fatura", NotaFiscalFatura.codigoFatura));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalFatura.codigoSerieNotaFiscal));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Fatura] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [nm_fatura] = @nm_fatura and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fatura", codigoFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Fatura] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
