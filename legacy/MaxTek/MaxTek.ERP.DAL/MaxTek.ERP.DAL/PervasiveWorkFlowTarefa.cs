using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveWorkFlowTarefa : IWorkFlowTarefa
{
	private MapTableWorkFlowTarefa MapearClasse(DataRow row)
	{
		MapTableWorkFlowTarefa result = default(MapTableWorkFlowTarefa);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.dataSolicitacao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataSolicitacao"]);
			result.isConcluido = BaseDadosGPS.ObterDbValor<bool>(row["isConcluido"]);
			result.status = BaseDadosGPS.ObterDbValor<int>(row["status"]);
			result.codigoSolicitante = BaseDadosGPS.ObterDbValor<int>(row["codigoSolicitante"]);
			result.codigoSolicitado = BaseDadosGPS.ObterDbValor<int>(row["codigoSolicitado"]);
			result.assunto = BaseDadosGPS.ObterDbValor<string>(row["assunto"]);
			result.solicitacao = BaseDadosGPS.ObterDbValor<string>(row["solicitacao"]);
			result.comentario = BaseDadosGPS.ObterDbValor<string>(row["comentario"]);
			result.dataConclusao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataConclusao"]);
			result.codigoDepartamentoSolicitante = BaseDadosGPS.ObterDbValor<int>(row["codigoDepartamentoSolicitante"]);
			result.codigoDepartamentoSolicitado = BaseDadosGPS.ObterDbValor<string>(row["codigoDepartamentoSolicitado"]);
			result.prioridade = BaseDadosGPS.ObterDbValor<int>(row["prioridade"]);
			result.percentualConcluido = BaseDadosGPS.ObterDbValor<int>(row["percentualConcluido"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("dt_solicitacao as dataSolicitacao, ");
		stringBuilder.Append("ic_concluido as isConcluido, ");
		stringBuilder.Append("cd_status as status, ");
		stringBuilder.Append("cd_solicitante as codigoSolicitante, ");
		stringBuilder.Append("cd_solicitado as codigoSolicitado, ");
		stringBuilder.Append("nm_assunto as assunto, ");
		stringBuilder.Append("nm_solicitacao as solicitacao, ");
		stringBuilder.Append("nm_comentario as comentario, ");
		stringBuilder.Append("dt_conclusao as dataConclusao, ");
		stringBuilder.Append("cd_departamento_soli as codigoDepartamentoSolicitante, ");
		stringBuilder.Append("cd_departamento_soli as codigoDepartamentoSolicitado, ");
		stringBuilder.Append("cd_prioridade as prioridade, ");
		stringBuilder.Append("pc_concluido as percentualConcluido");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "Erp.WorkFlowTarefa ");
		return stringBuilder.ToString();
	}

	public IList<MapTableWorkFlowTarefa> ObterTodosWorkFlowTarefa()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableWorkFlowTarefa ObterWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", WorkFlowTarefa.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "Erp.WorkFlowTarefa (");
		stringBuilder.Append("dt_solicitacao, ");
		stringBuilder.Append("ic_concluido, ");
		stringBuilder.Append("cd_status, ");
		stringBuilder.Append("cd_solicitante, ");
		stringBuilder.Append("cd_solicitado, ");
		stringBuilder.Append("nm_assunto, ");
		stringBuilder.Append("nm_solicitacao, ");
		stringBuilder.Append("nm_comentario, ");
		stringBuilder.Append("dt_conclusao, ");
		stringBuilder.Append("cd_departamento_soli, ");
		stringBuilder.Append("cd_departamento_soli, ");
		stringBuilder.Append("cd_prioridade, ");
		stringBuilder.Append("pc_concluido) Values (?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_solicitacao", WorkFlowTarefa.dataSolicitacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_concluido", WorkFlowTarefa.isConcluido));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_status", WorkFlowTarefa.status));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_solicitante", WorkFlowTarefa.codigoSolicitante));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_solicitado", WorkFlowTarefa.codigoSolicitado));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_assunto", WorkFlowTarefa.assunto));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_solicitacao", WorkFlowTarefa.solicitacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_comentario", WorkFlowTarefa.comentario));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_conclusao", WorkFlowTarefa.dataConclusao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_departamento_soli", WorkFlowTarefa.codigoDepartamentoSolicitante));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_departamento_soli", WorkFlowTarefa.codigoDepartamentoSolicitado));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_prioridade", WorkFlowTarefa.prioridade));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_concluido", WorkFlowTarefa.percentualConcluido));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarWorkFlowTarefa(MapTableWorkFlowTarefa WorkFlowTarefa, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "Erp.WorkFlowTarefa Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataSolicitacao", "dt_solicitacao", WorkFlowTarefa.dataSolicitacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsConcluido", "ic_concluido", WorkFlowTarefa.isConcluido, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Status", "cd_status", WorkFlowTarefa.status, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoSolicitante", "cd_solicitante", WorkFlowTarefa.codigoSolicitante, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoSolicitado", "cd_solicitado", WorkFlowTarefa.codigoSolicitado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Assunto", "nm_assunto", WorkFlowTarefa.assunto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Solicitacao", "nm_solicitacao", WorkFlowTarefa.solicitacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Comentario", "nm_comentario", WorkFlowTarefa.comentario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataConclusao", "dt_conclusao", WorkFlowTarefa.dataConclusao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoDepartamentoSolicitante", "cd_departamento_soli", WorkFlowTarefa.codigoDepartamentoSolicitante, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoDepartamentoSolicitado", "cd_departamento_soli", WorkFlowTarefa.codigoDepartamentoSolicitado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Prioridade", "cd_prioridade", WorkFlowTarefa.prioridade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PercentualConcluido", "pc_concluido", WorkFlowTarefa.percentualConcluido, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", WorkFlowTarefa.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirWorkFlowTarefa(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "Erp.WorkFlowTarefa ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
