using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalSerie : INotaFiscalSerie
{
	private MapTableNotaFiscalSerie MapearClasse(DataRow row)
	{
		MapTableNotaFiscalSerie result = default(MapTableNotaFiscalSerie);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoSerie = BaseDadosERP.ObterDbValor<int>(row["codigoSerie"]);
			result.nomeSerie = BaseDadosERP.ObterDbValor<string>(row["nomeSerie"]);
			result.proximoNumero = BaseDadosERP.ObterDbValor<int>(row["proximoNumero"]);
			result.indice = BaseDadosERP.ObterDbValor<int>(row["indice"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_serie] as [codigoSerie], ");
		stringBuilder.Append("[nm_serie] as [nomeSerie], ");
		stringBuilder.Append("[cd_proximo_numero] as [proximoNumero], ");
		stringBuilder.Append("[cd_indice] as [indice]");
		stringBuilder.Append($" from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Serie] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalSerie> ObterTodosNotaFiscalSerie()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalSerie> list = new List<MapTableNotaFiscalSerie>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalSerie> ObterTodosNotaFiscalSerie(int codigoEmpresa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalSerie> list2 = new List<MapTableNotaFiscalSerie>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", (codigoEmpresa == 0) ? 1 : codigoEmpresa));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa, int codigoSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and ");
		stringBuilder.Append(" [cd_serie] = @cd_serie");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie", codigoSerie));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalSerie ObterNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and ");
		stringBuilder.Append(" [cd_serie] = @cd_serie");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalSerie.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie", NotaFiscalSerie.codigoSerie));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Serie] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_serie], ");
		stringBuilder.Append("[nm_serie], ");
		stringBuilder.Append("[cd_proximo_numero], ");
		stringBuilder.Append("[cd_indice] ");
		stringBuilder.Append(") Values (@cd_empresa,@cd_serie,@nm_serie,@cd_proximo_numero,@cd_indice) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", (NotaFiscalSerie.codigoEmpresa == 0) ? 1 : NotaFiscalSerie.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie", NotaFiscalSerie.codigoSerie));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_serie", string.IsNullOrWhiteSpace(NotaFiscalSerie.nomeSerie) ? string.Empty : NotaFiscalSerie.nomeSerie));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_proximo_numero", NotaFiscalSerie.proximoNumero));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_indice", NotaFiscalSerie.indice));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Update [{0}].[{1}].[NotaFiscal].[Serie] Set ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmpresa", "cd_empresa", NotaFiscalSerie.codigoEmpresa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSerie", "cd_serie", NotaFiscalSerie.codigoSerie, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeSerie", "nm_serie", NotaFiscalSerie.nomeSerie, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ProximoNumero", "cd_proximo_numero", NotaFiscalSerie.proximoNumero, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Indice", "cd_indice", NotaFiscalSerie.indice, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalSerie.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalSerie(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[Serie] ");
		stringBuilder.Append(" Where ");
		stringBuilder.Append("id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
