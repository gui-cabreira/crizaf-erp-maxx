using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialEntidadeEvento : IComercialEntidadeEvento
{
	private MapTableComercialEntidadeEvento MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeEvento result = default(MapTableComercialEntidadeEvento);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.dataCadastro = BaseDadosERP.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.codigoFuncionario = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionario"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoContato = BaseDadosERP.ObterDbValor<int>(row["codigoContato"]);
			result.codigoTipoAtendimento = BaseDadosERP.ObterDbValor<int>(row["codigoTipoAtendimento"]);
			result.assunto = BaseDadosERP.ObterDbValor<string>(row["assunto"]);
			result.solicitacao = BaseDadosERP.ObterDbValor<string>(row["solicitacao"]);
			result.comentario = BaseDadosERP.ObterDbValor<string>(row["comentario"]);
			result.codigoStatusAtendimento = BaseDadosERP.ObterDbValor<int>(row["codigoStatusAtendimento"]);
			result.isAcompanhar = BaseDadosERP.ObterDbValor<bool>(row["isAcompanhar"]);
			result.dataAcompanhamento = BaseDadosERP.ObterDbValor<DateTime>(row["dataAcompanhamento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[dt_evento] as [dataCadastro], ");
		stringBuilder.Append("[id_funcionario] as [codigoFuncionario], ");
		stringBuilder.Append("[id_entidade] as [codigoEntidade], ");
		stringBuilder.Append("[id_contato_entidade] as [codigoContato], ");
		stringBuilder.Append("[id_tipo_atendimento] as [codigoTipoAtendimento], ");
		stringBuilder.Append("[nm_assunto] as [assunto], ");
		stringBuilder.Append("[nm_solicitacao] as [solicitacao], ");
		stringBuilder.Append("[nm_comentario] as [comentario], ");
		stringBuilder.Append("[id_status_atendimento] as [codigoStatusAtendimento], ");
		stringBuilder.Append("[ic_acompanhar] as [isAcompanhar], ");
		stringBuilder.Append("[dt_acompanhamento] as [dataAcompanhamento]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEvento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEvento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeEvento> list = new List<MapTableComercialEntidadeEvento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEventoAcompanhar()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [ic_acompanhar] = 1");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeEvento> list = new List<MapTableComercialEntidadeEvento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEventoPorPeriodo(DateTime dataInicio, DateTime dataFim)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [dt_acompanhamento] between " + BaseDadosERP.Escape(dataInicio.ToString("yyyy-MM-dd")));
		stringBuilder.Append(" and " + BaseDadosERP.Escape(dataFim.ToString("yyyy-MM-dd")));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeEvento> list = new List<MapTableComercialEntidadeEvento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEvento(int codigoEntidade)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where id_entidade = " + codigoEntidade);
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeEvento> list = new List<MapTableComercialEntidadeEvento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEventoContato(int codigoContato)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where id_contato_entidade = " + codigoContato);
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeEvento> list = new List<MapTableComercialEntidadeEvento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialEntidadeEvento ObterComercialEntidadeEvento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeEvento ObterComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeEvento.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEvento] (");
		stringBuilder.Append("dt_evento, ");
		stringBuilder.Append("id_funcionario, ");
		stringBuilder.Append("id_entidade, ");
		stringBuilder.Append("id_contato_entidade, ");
		stringBuilder.Append("id_tipo_atendimento, ");
		stringBuilder.Append("nm_assunto, ");
		stringBuilder.Append("nm_solicitacao, ");
		stringBuilder.Append("nm_comentario, ");
		stringBuilder.Append("id_status_atendimento, ");
		stringBuilder.Append("ic_acompanhar, ");
		stringBuilder.Append("dt_acompanhamento) Values (@dt_evento,@id_funcionario,@id_entidade,@id_contato_entidade,@id_tipo_atendimento,@nm_assunto,@nm_solicitacao,@nm_comentario,@id_status_atendimento,@ic_acompanhar,@dt_acompanhamento) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_evento", ComercialEntidadeEvento.dataCadastro));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_funcionario", ComercialEntidadeEvento.codigoFuncionario));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade", ComercialEntidadeEvento.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_contato_entidade", ComercialEntidadeEvento.codigoContato));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_tipo_atendimento", ComercialEntidadeEvento.codigoTipoAtendimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_assunto", ComercialEntidadeEvento.assunto));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_solicitacao", ComercialEntidadeEvento.solicitacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_comentario", ComercialEntidadeEvento.comentario));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_status_atendimento", ComercialEntidadeEvento.codigoStatusAtendimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_acompanhar", ComercialEntidadeEvento.isAcompanhar));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_acompanhamento", ComercialEntidadeEvento.dataAcompanhamento));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEvento] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_evento", ComercialEntidadeEvento.dataCadastro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "id_funcionario", ComercialEntidadeEvento.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "id_entidade", ComercialEntidadeEvento.codigoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoContato", "id_contato_entidade", ComercialEntidadeEvento.codigoContato, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoAtendimento", "id_tipo_atendimento", ComercialEntidadeEvento.codigoTipoAtendimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Assunto", "nm_assunto", ComercialEntidadeEvento.assunto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Solicitacao", "nm_solicitacao", ComercialEntidadeEvento.solicitacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Comentario", "nm_comentario", ComercialEntidadeEvento.comentario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoStatusAtendimento", "id_status_atendimento", ComercialEntidadeEvento.codigoStatusAtendimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsAcompanhar", "ic_acompanhar", ComercialEntidadeEvento.isAcompanhar, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAcompanhamento", "dt_acompanhamento", ComercialEntidadeEvento.dataAcompanhamento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeEvento.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}
}
