using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialEntidadeEvento : IComercialEntidadeEvento
{
	private MapTableComercialEntidadeEvento MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeEvento result = default(MapTableComercialEntidadeEvento);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.dataCadastro = BaseDadosGPS.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.codigoFuncionario = BaseDadosGPS.ObterDbValor<int>(row["codigoFuncionario"]);
			result.codigoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoContato = BaseDadosGPS.ObterDbValor<int>(row["codigoContato"]);
			result.codigoTipoAtendimento = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoAtendimento"]);
			result.assunto = BaseDadosGPS.ObterDbValor<string>(row["assunto"]);
			result.solicitacao = BaseDadosGPS.ObterDbValor<string>(row["solicitacao"]);
			result.comentario = BaseDadosGPS.ObterDbValor<string>(row["comentario"]);
			result.codigoStatusAtendimento = BaseDadosGPS.ObterDbValor<int>(row["codigoStatusAtendimento"]);
			result.isAcompanhar = BaseDadosGPS.ObterDbValor<bool>(row["isAcompanhar"]);
			result.dataAcompanhamento = BaseDadosGPS.ObterDbValor<DateTime>(row["dataAcompanhamento"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("dt_evento as dataCadastro, ");
		stringBuilder.Append("id_funcionario as codigoFuncionario, ");
		stringBuilder.Append("id_entidade as codigoEntidade, ");
		stringBuilder.Append("id_contato_entidade as codigoContato, ");
		stringBuilder.Append("id_tipo_atendimento as codigoTipoAtendimento, ");
		stringBuilder.Append("nm_assunto as assunto, ");
		stringBuilder.Append("nm_solicitacao as solicitacao, ");
		stringBuilder.Append("nm_comentario as comentario, ");
		stringBuilder.Append("id_status_atendiment as codigoStatusAtendimento, ");
		stringBuilder.Append("ic_acompanhar as isAcompanhar, ");
		stringBuilder.Append("dt_acompanhamento as dataAcompanhamento");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeEvento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEvento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where ic_acompanhar = 1");
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where dt_acompanhamento between " + BaseDadosGPS.Escape(dataInicio.ToString("yyyy-MM-dd")));
		stringBuilder.Append(" and " + BaseDadosGPS.Escape(dataFim.ToString("yyyy-MM-dd")));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeEvento ObterComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeEvento.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeEvento (");
		stringBuilder.Append("dt_evento, ");
		stringBuilder.Append("id_funcionario, ");
		stringBuilder.Append("id_entidade, ");
		stringBuilder.Append("id_contato_entidade, ");
		stringBuilder.Append("id_tipo_atendimento, ");
		stringBuilder.Append("nm_assunto, ");
		stringBuilder.Append("nm_solicitacao, ");
		stringBuilder.Append("nm_comentario, ");
		stringBuilder.Append("id_status_atendiment, ");
		stringBuilder.Append("ic_acompanhar, ");
		stringBuilder.Append("dt_acompanhamento) Values (?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_evento", ComercialEntidadeEvento.dataCadastro));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_funcionario", ComercialEntidadeEvento.codigoFuncionario));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade", ComercialEntidadeEvento.codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_contato_entidade", ComercialEntidadeEvento.codigoContato));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_tipo_atendimento", ComercialEntidadeEvento.codigoTipoAtendimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_assunto", ComercialEntidadeEvento.assunto));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_solicitacao", ComercialEntidadeEvento.solicitacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_comentario", ComercialEntidadeEvento.comentario));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_status_atendiment", ComercialEntidadeEvento.codigoStatusAtendimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_acompanhar", ComercialEntidadeEvento.isAcompanhar));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_acompanhamento", ComercialEntidadeEvento.dataAcompanhamento));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeEvento Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_evento", ComercialEntidadeEvento.dataCadastro, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "id_funcionario", ComercialEntidadeEvento.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "id_entidade", ComercialEntidadeEvento.codigoEntidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoContato", "id_contato_entidade", ComercialEntidadeEvento.codigoContato, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipoAtendimento", "id_tipo_atendimento", ComercialEntidadeEvento.codigoTipoAtendimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Assunto", "nm_assunto", ComercialEntidadeEvento.assunto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Solicitacao", "nm_solicitacao", ComercialEntidadeEvento.solicitacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Comentario", "nm_comentario", ComercialEntidadeEvento.comentario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoStatusAtendimento", "id_status_atendiment", ComercialEntidadeEvento.codigoStatusAtendimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsAcompanhar", "ic_acompanhar", ComercialEntidadeEvento.isAcompanhar, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataAcompanhamento", "dt_acompanhamento", ComercialEntidadeEvento.dataAcompanhamento, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeEvento.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}
}
