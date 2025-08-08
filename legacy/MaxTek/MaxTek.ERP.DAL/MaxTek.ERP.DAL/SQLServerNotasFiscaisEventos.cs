using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotasFiscaisEventos : INotasFiscaisEventos
{
	private MapTableNotasFiscaisEventos MapearClasse(DataRow row)
	{
		MapTableNotasFiscaisEventos result = default(MapTableNotasFiscaisEventos);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.codigoSerieNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoEvento = BaseDadosERP.ObterDbValor<int>(row["codigoEvento"]);
			result.codigoSequenciaEvento = BaseDadosERP.ObterDbValor<int>(row["codigoSequenciaEvento"]);
			result.evento = BaseDadosERP.ObterDbValor<string>(row["evento"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
			result.protocolo = BaseDadosERP.ObterDbValor<string>(row["protocolo"]);
			result.dataEvento = BaseDadosERP.ObterDbValor<string>(row["dataEvento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_serie_nf] as [codigoNotaFiscal], ");
		stringBuilder.Append("[cd_nota_fiscal] as [codigoSerieNotaFiscal], ");
		stringBuilder.Append("[cd_evento] as [codigoEvento], ");
		stringBuilder.Append("[cd_evento_seq] as [codigoSequenciaEvento], ");
		stringBuilder.Append("[nm_evento] as [evento], ");
		stringBuilder.Append("[ds_evento] as [descricao], ");
		stringBuilder.Append("[nm_protocolo] as [protocolo],");
		stringBuilder.Append("[dt_evento] as [dataEvento]");
		stringBuilder.Append($" from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisEventos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotasFiscaisEventos> list = new List<MapTableNotasFiscaisEventos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoSerieNotaFiscal));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotasFiscaisEventos> list2 = new List<MapTableNotasFiscaisEventos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_evento] = @cd_evento ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento", codigoEvento));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotasFiscaisEventos> list2 = new List<MapTableNotasFiscaisEventos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotasFiscaisEventos ObterNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_evento] = @cd_evento and");
		stringBuilder.Append(" [cd_evento_seq] = @cd_evento_seq");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento", codigoEvento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento_seq", codigoSequenciaEvento));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotasFiscaisEventos ObterNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_evento] = @cd_evento and");
		stringBuilder.Append(" [cd_evento_seq] = @cd_evento_seq");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotasFiscaisEventos.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotasFiscaisEventos.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotasFiscaisEventos.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento", NotasFiscaisEventos.codigoEvento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento_seq", NotasFiscaisEventos.codigoSequenciaEvento));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Insert into [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisEventos] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_serie_nf], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[cd_evento], ");
		stringBuilder.Append("[cd_evento_seq], ");
		stringBuilder.Append("[nm_evento], ");
		stringBuilder.Append("[ds_evento], ");
		stringBuilder.Append("[nm_protocolo], ");
		stringBuilder.Append("[dt_evento]) Values (@cd_empresa,@cd_serie_nf,@cd_nota_fiscal,@cd_evento,@cd_evento_seq,@nm_evento,@ds_evento,@nm_protocolo,@dt_evento) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotasFiscaisEventos.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotasFiscaisEventos.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotasFiscaisEventos.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento", NotasFiscaisEventos.codigoEvento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento_seq", NotasFiscaisEventos.codigoSequenciaEvento));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_evento", NotasFiscaisEventos.evento));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_evento", NotasFiscaisEventos.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_protocolo", NotasFiscaisEventos.protocolo));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_evento", NotasFiscaisEventos.dataEvento));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append($"Update [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisEventos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Evento", "nm_evento", NotasFiscaisEventos.evento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_evento", NotasFiscaisEventos.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Protocolo", "nm_protocolo", NotasFiscaisEventos.protocolo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEvento", "dt_evento", NotasFiscaisEventos.dataEvento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append(" [cd_empresa] = @cd_empresa and ");
			stringBuilder.Append("cd_serie_nf = @cd_serie_nf and ");
			stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
			stringBuilder.Append("cd_evento = @cd_evento and ");
			stringBuilder.Append("cd_evento_seq = @cd_evento_seq");
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotasFiscaisEventos.codigoEmpresa));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotasFiscaisEventos.codigoNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotasFiscaisEventos.codigoSerieNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento", NotasFiscaisEventos.codigoEvento));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento_seq", NotasFiscaisEventos.codigoSequenciaEvento));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisEventos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_evento] = @cd_evento and");
		stringBuilder.Append(" [cd_evento_seq] = @cd_evento_seq");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento", codigoEvento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_evento_seq", codigoSequenciaEvento));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [dt_evento] between @dataInicio and @dataFim");
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotasFiscaisEventos> list2 = new List<MapTableNotasFiscaisEventos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}
}
