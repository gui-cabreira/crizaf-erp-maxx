using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalNotaReferenciada : INotaFiscalNotaReferenciada
{
	private MapTableNotaFiscalNotaReferenciada MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotaReferenciada result = default(MapTableNotaFiscalNotaReferenciada);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.numeroNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["numeroNotaFiscal"]);
			result.codigoSerieNF = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNF"]);
			result.notaReferenciada = BaseDadosERP.ObterDbValor<string>(row["notaReferenciada"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_nota_fiscal] as [numeroNotaFiscal], ");
		stringBuilder.Append("[cd_serie_nota_fiscal] as [codigoSerieNF], ");
		stringBuilder.Append("[nm_nota_referenciada] as [notaReferenciada]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisNotaReferenciada] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotaReferenciada> ObterTodosNotaFiscalNotaReferenciada()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", codigoSerieNF));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
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
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal and");
		stringBuilder.Append(" [nm_nota_referenciada] = @nm_nota_referenciada");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", codigoSerieNF));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_nota_referenciada", notaReferenciada));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal and");
		stringBuilder.Append(" [nm_nota_referenciada] = @nm_nota_referenciada");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotaReferenciada.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotaReferenciada.numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", NotaFiscalNotaReferenciada.codigoSerieNF));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_nota_referenciada", NotaFiscalNotaReferenciada.notaReferenciada));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisNotaReferenciada] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[cd_serie_nota_fiscal], ");
		stringBuilder.Append("[nm_nota_referenciada]) Values (@cd_empresa,@cd_nota_fiscal,@cd_serie_nota_fiscal,@nm_nota_referenciada) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotaReferenciada.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotaReferenciada.numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", NotaFiscalNotaReferenciada.codigoSerieNF));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_nota_referenciada", string.IsNullOrWhiteSpace(NotaFiscalNotaReferenciada.notaReferenciada) ? string.Empty : NotaFiscalNotaReferenciada.notaReferenciada));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisNotaReferenciada] Set ");
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_empresa = @cd_empresa and ");
			stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
			stringBuilder.Append("cd_serie_nota_fiscal = @cd_serie_nota_fiscal and ");
			stringBuilder.Append("nm_nota_referenciada = @nm_nota_referenciada");
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotaReferenciada.codigoEmpresa));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotaReferenciada.numeroNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", NotaFiscalNotaReferenciada.codigoSerieNF));
			list.Add(BaseDadosERP.ObterNovoParametro("@nm_nota_referenciada", NotaFiscalNotaReferenciada.notaReferenciada));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisNotaReferenciada] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal and");
		stringBuilder.Append(" [nm_nota_referenciada] = @nm_nota_referenciada");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", codigoSerieNF));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_nota_referenciada", notaReferenciada));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscaisNotaReferenciada] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", codigoSerieNF));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
