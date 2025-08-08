using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProcessoOperacaoRevisao : ITecnicoEngenhariaProcessoOperacaoRevisao
{
	private MapTableTecnicoEngenhariaProcessoOperacaoRevisao MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoOperacaoRevisao result = default(MapTableTecnicoEngenhariaProcessoOperacaoRevisao);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.idProcessoOperacao = BaseDadosERP.ObterDbValor<int>(row["idProcessoOperacao"]);
			result.revisao = BaseDadosERP.ObterDbValor<int>(row["revisao"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
			result.data = BaseDadosERP.ObterDbValor<DateTime>(row["data"]);
			result.codigoFuncionarioRevisor = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioRevisor"]);
			result.nomeUsuarioConectado = BaseDadosERP.ObterDbValor<string>(row["nomeUsuarioConectado"]);
			result.sqlUtilizado = BaseDadosERP.ObterDbValor<string>(row["sqlUtilizado"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("id_processo_operacao as idProcessoOperacao, ");
		stringBuilder.Append("cd_revisao as revisao, ");
		stringBuilder.Append("ds_modificacao as descricao, ");
		stringBuilder.Append("dt_revisao as data, ");
		stringBuilder.Append("cd_funcionario_revis as codigoFuncionarioRevisor, ");
		stringBuilder.Append("nm_conectado as nomeUsuarioConectado, ");
		stringBuilder.Append("ds_sql_utilizado as sqlUtilizado");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "ERP.OperacaoRevisao ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoOperacaoRevisao> ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcessoOperacaoRevisao> list = new List<MapTableTecnicoEngenhariaProcessoOperacaoRevisao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProcessoOperacaoRevisao> ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao(int idOperacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id_operacao = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id_operacao", idOperacao));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProcessoOperacaoRevisao> list2 = new List<MapTableTecnicoEngenhariaProcessoOperacaoRevisao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProcessoOperacaoRevisao ObterTecnicoEngenhariaProcessoOperacaoRevisao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProcessoOperacaoRevisao ObterTecnicoEngenhariaProcessoOperacaoRevisao(MapTableTecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", TecnicoEngenhariaProcessoOperacaoRevisao.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoOperacaoRevisao(MapTableTecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "ERP.OperacaoRevisao (");
		stringBuilder.Append("id_processo_operacao, ");
		stringBuilder.Append("cd_revisao, ");
		stringBuilder.Append("ds_modificacao, ");
		stringBuilder.Append("dt_revisao, ");
		stringBuilder.Append("cd_funcionario_revis, ");
		stringBuilder.Append("nm_conectado, ");
		stringBuilder.Append("ds_sql_utilizado) Values (?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("id_processo_operacao", TecnicoEngenhariaProcessoOperacaoRevisao.idProcessoOperacao));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_revisao", TecnicoEngenhariaProcessoOperacaoRevisao.revisao));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_modificacao", TecnicoEngenhariaProcessoOperacaoRevisao.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_revisao", TecnicoEngenhariaProcessoOperacaoRevisao.data));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_funcionario_revis", TecnicoEngenhariaProcessoOperacaoRevisao.codigoFuncionarioRevisor));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_conectado", TecnicoEngenhariaProcessoOperacaoRevisao.nomeUsuarioConectado));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_sql_utilizado", TecnicoEngenhariaProcessoOperacaoRevisao.sqlUtilizado));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoOperacaoRevisao(MapTableTecnicoEngenhariaProcessoOperacaoRevisao TecnicoEngenhariaProcessoOperacaoRevisao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "ERP.OperacaoRevisao Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProcessoOperacao", "id_processo_operacao", TecnicoEngenhariaProcessoOperacaoRevisao.idProcessoOperacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Revisao", "cd_revisao", TecnicoEngenhariaProcessoOperacaoRevisao.revisao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_modificacao", TecnicoEngenhariaProcessoOperacaoRevisao.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Data", "dt_revisao", TecnicoEngenhariaProcessoOperacaoRevisao.data, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioRevisor", "cd_funcionario_revis", TecnicoEngenhariaProcessoOperacaoRevisao.codigoFuncionarioRevisor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeUsuarioConectado", "nm_conectado", TecnicoEngenhariaProcessoOperacaoRevisao.nomeUsuarioConectado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SqlUtilizado", "ds_sql_utilizado", TecnicoEngenhariaProcessoOperacaoRevisao.sqlUtilizado, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", TecnicoEngenhariaProcessoOperacaoRevisao.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoOperacaoRevisao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "ERP.OperacaoRevisao ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
