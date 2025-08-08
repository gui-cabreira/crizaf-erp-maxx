using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalInutilizacao : INotaFiscalInutilizacao
{
	private MapTableNotaFiscalInutilizacao MapearClasse(DataRow row)
	{
		MapTableNotaFiscalInutilizacao result = default(MapTableNotaFiscalInutilizacao);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoModelo = BaseDadosERP.ObterDbValor<int>(row["codigoModelo"]);
			result.codigoSerie = BaseDadosERP.ObterDbValor<int>(row["codigoSerie"]);
			result.ano = BaseDadosERP.ObterDbValor<int>(row["ano"]);
			result.notaInicial = BaseDadosERP.ObterDbValor<int>(row["notaInicial"]);
			result.notaFinal = BaseDadosERP.ObterDbValor<int>(row["notaFinal"]);
			result.codigoStatus = BaseDadosERP.ObterDbValor<int>(row["codigoStatus"]);
			result.status = BaseDadosERP.ObterDbValor<string>(row["status"]);
			result.dataRecibo = BaseDadosERP.ObterDbValor<DateTime>(row["dataRecibo"]);
			result.protocolo = BaseDadosERP.ObterDbValor<string>(row["protocolo"]);
			result.usuario = BaseDadosERP.ObterDbValor<string>(row["usuario"]);
			result.justificativa = BaseDadosERP.ObterDbValor<string>(row["justificativa"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[Id] as [id], ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_modelo] as [codigoModelo], ");
		stringBuilder.Append("[cd_serie] as [codigoSerie], ");
		stringBuilder.Append("[ano] as [ano], ");
		stringBuilder.Append("[cd_nota_inicial] as [notaInicial], ");
		stringBuilder.Append("[cd_nota_final] as [notaFinal], ");
		stringBuilder.Append("[cd_status] as [codigoStatus], ");
		stringBuilder.Append("[ds_status] as [status], ");
		stringBuilder.Append("[dt_recibo] as [dataRecibo], ");
		stringBuilder.Append("[nm_protocolo] as [protocolo], ");
		stringBuilder.Append("[nm_usuario] as [usuario], ");
		stringBuilder.Append("[ds_justificativa] as [justificativa]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Inutilizacao] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalInutilizacao> list = new List<MapTableNotaFiscalInutilizacao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao(int codigoEmpresa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalInutilizacao> list2 = new List<MapTableNotaFiscalInutilizacao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalInutilizacao ObterNotaFiscalInutilizacao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Id] = @Id");
		list.Add(BaseDadosERP.ObterNovoParametro("@Id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalInutilizacao ObterNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Id] = @Id");
		list.Add(BaseDadosERP.ObterNovoParametro("@Id", NotaFiscalInutilizacao.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Inutilizacao] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_modelo], ");
		stringBuilder.Append("[cd_serie], ");
		stringBuilder.Append("[ano], ");
		stringBuilder.Append("[cd_nota_inicial], ");
		stringBuilder.Append("[cd_nota_final], ");
		stringBuilder.Append("[cd_status], ");
		stringBuilder.Append("[ds_status], ");
		stringBuilder.Append("[dt_recibo], ");
		stringBuilder.Append("[nm_protocolo], ");
		stringBuilder.Append("[nm_usuario], ");
		stringBuilder.Append("[ds_justificativa]) Values (@cd_empresa,@cd_modelo,@cd_serie,@ano,@cd_nota_inicial,@cd_nota_final,@cd_status,@ds_status,@dt_recibo,@nm_protocolo,@nm_usuario,@ds_justificativa) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalInutilizacao.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modelo", NotaFiscalInutilizacao.codigoModelo));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie", NotaFiscalInutilizacao.codigoSerie));
		list.Add(BaseDadosERP.ObterNovoParametro("@ano", NotaFiscalInutilizacao.ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_inicial", NotaFiscalInutilizacao.notaInicial));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_final", NotaFiscalInutilizacao.notaFinal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_status", NotaFiscalInutilizacao.codigoStatus));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_status", string.IsNullOrWhiteSpace(NotaFiscalInutilizacao.status) ? string.Empty : NotaFiscalInutilizacao.status));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_recibo", NotaFiscalInutilizacao.dataRecibo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_protocolo", string.IsNullOrWhiteSpace(NotaFiscalInutilizacao.protocolo) ? string.Empty : NotaFiscalInutilizacao.protocolo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario", string.IsNullOrWhiteSpace(NotaFiscalInutilizacao.usuario) ? string.Empty : NotaFiscalInutilizacao.usuario));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_justificativa", string.IsNullOrWhiteSpace(NotaFiscalInutilizacao.justificativa) ? string.Empty : NotaFiscalInutilizacao.justificativa));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Inutilizacao] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmpresa", "cd_empresa", NotaFiscalInutilizacao.codigoEmpresa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModelo", "cd_modelo", NotaFiscalInutilizacao.codigoModelo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSerie", "cd_serie", NotaFiscalInutilizacao.codigoSerie, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Ano", "ano", NotaFiscalInutilizacao.ano, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NotaInicial", "cd_nota_inicial", NotaFiscalInutilizacao.notaInicial, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NotaFinal", "cd_nota_final", NotaFiscalInutilizacao.notaFinal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoStatus", "cd_status", NotaFiscalInutilizacao.codigoStatus, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Status", "ds_status", NotaFiscalInutilizacao.status, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataRecibo", "dt_recibo", NotaFiscalInutilizacao.dataRecibo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Protocolo", "nm_protocolo", NotaFiscalInutilizacao.protocolo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Usuario", "nm_usuario", NotaFiscalInutilizacao.usuario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Justificativa", "ds_justificativa", NotaFiscalInutilizacao.justificativa, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("Id = @Id");
			list.Add(BaseDadosERP.ObterNovoParametro("@Id", NotaFiscalInutilizacao.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalInutilizacao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[Inutilizacao] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Id] = @Id");
		list.Add(BaseDadosERP.ObterNovoParametro("@Id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
