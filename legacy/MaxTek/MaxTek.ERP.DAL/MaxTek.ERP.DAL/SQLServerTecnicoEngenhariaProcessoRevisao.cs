using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProcessoRevisao : ITecnicoEngenhariaProcessoRevisao
{
	private MapTableTecnicoEngenhariaProcessoRevisao MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoRevisao result = default(MapTableTecnicoEngenhariaProcessoRevisao);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.idProcesso = BaseDadosERP.ObterDbValor<int>(row["idProcesso"]);
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
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[id_processo] as [idProcesso], ");
		stringBuilder.Append("[cd_revisao] as [revisao], ");
		stringBuilder.Append("[ds_modificacao] as [descricao], ");
		stringBuilder.Append("[dt_revisao] as [data], ");
		stringBuilder.Append("[cd_funcionario_revisor] as [codigoFuncionarioRevisor], ");
		stringBuilder.Append("[nm_conectado] as [nomeUsuarioConectado], ");
		stringBuilder.Append("[ds_sql_utilizado] as [sqlUtilizado]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoRevisao] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoRevisao> ObterTodosTecnicoEngenhariaProcessoRevisao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcessoRevisao> list = new List<MapTableTecnicoEngenhariaProcessoRevisao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProcessoRevisao> ObterTodosTecnicoEngenhariaProcessoRevisao(int idProcesso)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_processo] = @id_processo");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_processo", idProcesso));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProcessoRevisao> list2 = new List<MapTableTecnicoEngenhariaProcessoRevisao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProcessoRevisao ObterTecnicoEngenhariaProcessoRevisao(int id)
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

	public MapTableTecnicoEngenhariaProcessoRevisao ObterTecnicoEngenhariaProcessoRevisao(MapTableTecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoRevisao.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoRevisao(MapTableTecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoRevisao] (");
		stringBuilder.Append("[id_processo], ");
		stringBuilder.Append("[cd_revisao], ");
		stringBuilder.Append("[ds_modificacao], ");
		stringBuilder.Append("[dt_revisao], ");
		stringBuilder.Append("[cd_funcionario_revisor], ");
		stringBuilder.Append("[nm_conectado], ");
		stringBuilder.Append("[ds_sql_utilizado]) Values (@id_processo,@cd_revisao,@ds_modificacao,@dt_revisao,@cd_funcionario_revisor,@nm_conectado,@ds_sql_utilizado) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_processo", TecnicoEngenhariaProcessoRevisao.idProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_revisao", TecnicoEngenhariaProcessoRevisao.revisao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_modificacao", TecnicoEngenhariaProcessoRevisao.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_revisao", TecnicoEngenhariaProcessoRevisao.data));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_revisor", TecnicoEngenhariaProcessoRevisao.codigoFuncionarioRevisor));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_conectado", TecnicoEngenhariaProcessoRevisao.nomeUsuarioConectado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_sql_utilizado", TecnicoEngenhariaProcessoRevisao.sqlUtilizado));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoRevisao(MapTableTecnicoEngenhariaProcessoRevisao TecnicoEngenhariaProcessoRevisao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoRevisao] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProcesso", "id_processo", TecnicoEngenhariaProcessoRevisao.idProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Revisao", "cd_revisao", TecnicoEngenhariaProcessoRevisao.revisao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_modificacao", TecnicoEngenhariaProcessoRevisao.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Data", "dt_revisao", TecnicoEngenhariaProcessoRevisao.data, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioRevisor", "cd_funcionario_revisor", TecnicoEngenhariaProcessoRevisao.codigoFuncionarioRevisor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeUsuarioConectado", "nm_conectado", TecnicoEngenhariaProcessoRevisao.nomeUsuarioConectado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SqlUtilizado", "ds_sql_utilizado", TecnicoEngenhariaProcessoRevisao.sqlUtilizado, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoRevisao.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoRevisao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoRevisao] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
