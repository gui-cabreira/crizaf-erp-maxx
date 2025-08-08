using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerWorkFlowTarefa : IWorkFlowTarefa
{
	private MapTableWorkFlowTarefa MapearClasse(DataRow row)
	{
		MapTableWorkFlowTarefa result = default(MapTableWorkFlowTarefa);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.dataSolicitacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataSolicitacao"]);
			result.isConcluido = BaseDadosERP.ObterDbValor<bool>(row["isConcluido"]);
			result.status = BaseDadosERP.ObterDbValor<int>(row["status"]);
			result.codigoSolicitante = BaseDadosERP.ObterDbValor<int>(row["codigoSolicitante"]);
			result.codigoSolicitado = BaseDadosERP.ObterDbValor<int>(row["codigoSolicitado"]);
			result.assunto = BaseDadosERP.ObterDbValor<string>(row["assunto"]);
			result.solicitacao = BaseDadosERP.ObterDbValor<string>(row["solicitacao"]);
			result.comentario = BaseDadosERP.ObterDbValor<string>(row["comentario"]);
			result.dataConclusao = BaseDadosERP.ObterDbValor<DateTime>(row["dataConclusao"]);
			result.codigoDepartamentoSolicitante = BaseDadosERP.ObterDbValor<int>(row["codigoDepartamentoSolicitante"]);
			result.codigoDepartamentoSolicitado = BaseDadosERP.ObterDbValor<string>(row["codigoDepartamentoSolicitado"]);
			result.prioridade = BaseDadosERP.ObterDbValor<int>(row["prioridade"]);
			result.percentualConcluido = BaseDadosERP.ObterDbValor<int>(row["percentualConcluido"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[dt_solicitacao] as [dataSolicitacao], ");
		stringBuilder.Append("[ic_concluido] as [isConcluido], ");
		stringBuilder.Append("[cd_status] as [status], ");
		stringBuilder.Append("[cd_solicitante] as [codigoSolicitante], ");
		stringBuilder.Append("[cd_solicitado] as [codigoSolicitado], ");
		stringBuilder.Append("[nm_assunto] as [assunto], ");
		stringBuilder.Append("[nm_solicitacao] as [solicitacao], ");
		stringBuilder.Append("[nm_comentario] as [comentario], ");
		stringBuilder.Append("[dt_conclusao] as [dataConclusao], ");
		stringBuilder.Append("[cd_departamento_solicitante] as [codigoDepartamentoSolicitante], ");
		stringBuilder.Append("[cd_departamento_solicitado] as [codigoDepartamentoSolicitado], ");
		stringBuilder.Append("[cd_prioridade] as [prioridade], ");
		stringBuilder.Append("[pc_concluido] as [percentualConcluido]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[WorkFlow].[Tarefa] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableWorkFlowTarefa> ObterTodosWorkFlowTarefa()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableWorkFlowTarefa> list = new List<MapTableWorkFlowTarefa>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableWorkFlowTarefa ObterWorkFlowTarefa(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableWorkFlowTarefa ObterWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", WorkFlowTarefa.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[WorkFlow].[Tarefa] (");
		stringBuilder.Append("[dt_solicitacao], ");
		stringBuilder.Append("[ic_concluido], ");
		stringBuilder.Append("[cd_status], ");
		stringBuilder.Append("[cd_solicitante], ");
		stringBuilder.Append("[cd_solicitado], ");
		stringBuilder.Append("[nm_assunto], ");
		stringBuilder.Append("[nm_solicitacao], ");
		stringBuilder.Append("[nm_comentario], ");
		stringBuilder.Append("[dt_conclusao], ");
		stringBuilder.Append("[cd_departamento_solicitante], ");
		stringBuilder.Append("[cd_departamento_solicitado], ");
		stringBuilder.Append("[cd_prioridade], ");
		stringBuilder.Append("[pc_concluido]) Values (@dt_solicitacao,@ic_concluido,@cd_status,@cd_solicitante,@cd_solicitado,@nm_assunto,@nm_solicitacao,@nm_comentario,@dt_conclusao,@cd_departamento_solicitante,@cd_departamento_solicitado,@cd_prioridade,@pc_concluido) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_solicitacao", WorkFlowTarefa.dataSolicitacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_concluido", WorkFlowTarefa.isConcluido));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_status", WorkFlowTarefa.status));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_solicitante", WorkFlowTarefa.codigoSolicitante));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_solicitado", WorkFlowTarefa.codigoSolicitado));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_assunto", WorkFlowTarefa.assunto));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_solicitacao", WorkFlowTarefa.solicitacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_comentario", WorkFlowTarefa.comentario));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_conclusao", WorkFlowTarefa.dataConclusao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_departamento_solicitante", WorkFlowTarefa.codigoDepartamentoSolicitante));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_departamento_solicitado", WorkFlowTarefa.codigoDepartamentoSolicitado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_prioridade", WorkFlowTarefa.prioridade));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_concluido", WorkFlowTarefa.percentualConcluido));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[WorkFlow].[Tarefa] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataSolicitacao", "dt_solicitacao", WorkFlowTarefa.dataSolicitacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsConcluido", "ic_concluido", WorkFlowTarefa.isConcluido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Status", "cd_status", WorkFlowTarefa.status, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSolicitante", "cd_solicitante", WorkFlowTarefa.codigoSolicitante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSolicitado", "cd_solicitado", WorkFlowTarefa.codigoSolicitado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Assunto", "nm_assunto", WorkFlowTarefa.assunto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Solicitacao", "nm_solicitacao", WorkFlowTarefa.solicitacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Comentario", "nm_comentario", WorkFlowTarefa.comentario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataConclusao", "dt_conclusao", WorkFlowTarefa.dataConclusao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDepartamentoSolicitante", "cd_departamento_solicitante", WorkFlowTarefa.codigoDepartamentoSolicitante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDepartamentoSolicitado", "cd_departamento_solicitado", WorkFlowTarefa.codigoDepartamentoSolicitado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Prioridade", "cd_prioridade", WorkFlowTarefa.prioridade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualConcluido", "pc_concluido", WorkFlowTarefa.percentualConcluido, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", WorkFlowTarefa.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirWorkFlowTarefa(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[WorkFlow].[Tarefa] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
