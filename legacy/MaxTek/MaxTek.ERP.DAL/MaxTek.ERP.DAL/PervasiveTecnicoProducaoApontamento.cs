using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoProducaoApontamento : ITecnicoProducaoApontamento
{
	private MapTableTecnicoProducaoApontamento MapearClasse(DataRow row)
	{
		MapTableTecnicoProducaoApontamento result = default(MapTableTecnicoProducaoApontamento);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.data = BaseDadosGPS.ObterDbValor<DateTime>(row["data"]);
			result.tipoApontamento = BaseDadosGPS.ObterDbValor<int>(row["tipoApontamento"]);
			result.codigoOperador = BaseDadosGPS.ObterDbValor<int>(row["codigoOperador"]);
			result.codigoRecurso = BaseDadosGPS.ObterDbValor<int>(row["codigoRecurso"]);
			result.codigoImprodutivo = BaseDadosGPS.ObterDbValor<int>(row["codigoImprodutivo"]);
			result.tempoPrevistoSetup = BaseDadosGPS.ObterDbValor<decimal>(row["tempoPrevistoSetup"]);
			result.tempoPrevistoProducao = BaseDadosGPS.ObterDbValor<decimal>(row["tempoPrevistoProducao"]);
			result.tempoPrevistoControle = BaseDadosGPS.ObterDbValor<decimal>(row["tempoPrevistoControle"]);
			result.tempoRealizadoSetup = BaseDadosGPS.ObterDbValor<decimal>(row["tempoRealizadoSetup"]);
			result.tempoRealizadoProducao = BaseDadosGPS.ObterDbValor<decimal>(row["tempoRealizadoProducao"]);
			result.tempoRealizadoControle = BaseDadosGPS.ObterDbValor<decimal>(row["tempoRealizadoControle"]);
			result.tempoRealizadoImprodutivo = BaseDadosGPS.ObterDbValor<decimal>(row["tempoRealizadoImprodutivo"]);
			result.quantidadeTerminada = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeTerminada"]);
			result.quantidadeRuim = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeRuim"]);
			result.quantidadeBoa = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeBoa"]);
			result.codigoFichaProducao = BaseDadosGPS.ObterDbValor<int>(row["codigoFichaProducao"]);
			result.codigoProjeto = BaseDadosGPS.ObterDbValor<int>(row["codigoProjeto"]);
			result.codigoOrdemFabricacao = BaseDadosGPS.ObterDbValor<int>(row["codigoOrdemFabricacao"]);
			result.nomeProduto = BaseDadosGPS.ObterDbValor<string>(row["nomeProduto"]);
			result.idProdutoOf = BaseDadosGPS.ObterDbValor<int>(row["idProdutoOf"]);
			result.fase = BaseDadosGPS.ObterDbValor<int>(row["fase"]);
			result.codigoTipoProduto = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoProduto"]);
			result.potencialRecurso = BaseDadosGPS.ObterDbValor<decimal>(row["potencialRecurso"]);
			result.custoHoraSetup = BaseDadosGPS.ObterDbValor<decimal>(row["custoHoraSetup"]);
			result.custoHoraProducao = BaseDadosGPS.ObterDbValor<decimal>(row["custoHoraProducao"]);
			result.custoHoraControle = BaseDadosGPS.ObterDbValor<decimal>(row["custoHoraControle"]);
			result.custoHoraOperador = BaseDadosGPS.ObterDbValor<decimal>(row["custoHoraOperador"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("dt_cadastro as data, ");
		stringBuilder.Append("cd_tipo_apontamento as tipoApontamento, ");
		stringBuilder.Append("cd_operador as codigoOperador, ");
		stringBuilder.Append("cd_recurso as codigoRecurso, ");
		stringBuilder.Append("cd_improdutivo as codigoImprodutivo, ");
		stringBuilder.Append("vl_tempo_previsto_se as tempoPrevistoSetup, ");
		stringBuilder.Append("vl_tempo_previsto_pr as tempoPrevistoProducao, ");
		stringBuilder.Append("vl_tempo_previsto_co as tempoPrevistoControle, ");
		stringBuilder.Append("vl_tempo_passado_set as tempoRealizadoSetup, ");
		stringBuilder.Append("vl_tempo_passado_pro as tempoRealizadoProducao, ");
		stringBuilder.Append("vl_tempo_passado_con as tempoRealizadoControle, ");
		stringBuilder.Append("vl_tempo_passado_imp as tempoRealizadoImprodutivo, ");
		stringBuilder.Append("vl_quantidade_termin as quantidadeTerminada, ");
		stringBuilder.Append("vl_quantidade_ruim as quantidadeRuim, ");
		stringBuilder.Append("vl_quantidade_boa as quantidadeBoa, ");
		stringBuilder.Append("cd_ficha_producao as codigoFichaProducao, ");
		stringBuilder.Append("cd_projeto_producao as codigoProjeto, ");
		stringBuilder.Append("cd_ordem_fabricacao as codigoOrdemFabricacao, ");
		stringBuilder.Append("nm_produto as nomeProduto, ");
		stringBuilder.Append("id_produto as idProdutoOf, ");
		stringBuilder.Append("nm_fase as fase, ");
		stringBuilder.Append("cd_tipo_produto as codigoTipoProduto, ");
		stringBuilder.Append("vl_potencial_recurso as potencialRecurso, ");
		stringBuilder.Append("vl_custo_hora_setup as custoHoraSetup, ");
		stringBuilder.Append("vl_custo_hora_produc as custoHoraProducao, ");
		stringBuilder.Append("vl_custo_hora_contro as custoHoraControle, ");
		stringBuilder.Append("vl_custo_hora_operad as custoHoraOperador");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ProducaoApontamento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoProducaoApontamento> list = new List<MapTableTecnicoProducaoApontamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento(DateTime dataInicio, DateTime dataFim)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append(" Where dt_cadastramento between " + BaseDadosGPS.Escape(dataInicio.ToString("yyyy-MM-dd")));
		stringBuilder.Append(" and " + BaseDadosGPS.Escape(dataFim.ToString("yyyy-MM-dd")));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoProducaoApontamento> list = new List<MapTableTecnicoProducaoApontamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoProducaoApontamento ObterTecnicoProducaoApontamento(int id)
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

	public MapTableTecnicoProducaoApontamento ObterTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento TecnicoProducaoApontamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoProducaoApontamento.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento TecnicoProducaoApontamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ProducaoApontamento (");
		stringBuilder.Append("dt_cadastro, ");
		stringBuilder.Append("cd_tipo_apontamento, ");
		stringBuilder.Append("cd_operador, ");
		stringBuilder.Append("cd_recurso, ");
		stringBuilder.Append("cd_improdutivo, ");
		stringBuilder.Append("vl_tempo_previsto_se, ");
		stringBuilder.Append("vl_tempo_previsto_pr, ");
		stringBuilder.Append("vl_tempo_previsto_co, ");
		stringBuilder.Append("vl_tempo_passado_set, ");
		stringBuilder.Append("vl_tempo_passado_pro, ");
		stringBuilder.Append("vl_tempo_passado_con, ");
		stringBuilder.Append("vl_tempo_passado_imp, ");
		stringBuilder.Append("vl_quantidade_termin, ");
		stringBuilder.Append("vl_quantidade_ruim, ");
		stringBuilder.Append("vl_quantidade_boa, ");
		stringBuilder.Append("cd_ficha_producao, ");
		stringBuilder.Append("cd_projeto_producao, ");
		stringBuilder.Append("cd_ordem_fabricacao, ");
		stringBuilder.Append("nm_produto, ");
		stringBuilder.Append("id_produto, ");
		stringBuilder.Append("nm_fase, ");
		stringBuilder.Append("cd_tipo_produto, ");
		stringBuilder.Append("vl_potencial_recurso, ");
		stringBuilder.Append("vl_custo_hora_setup, ");
		stringBuilder.Append("vl_custo_hora_produc, ");
		stringBuilder.Append("vl_custo_hora_contro, ");
		stringBuilder.Append("vl_custo_hora_operad) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_cadastro", TecnicoProducaoApontamento.data));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_tipo_apontamento", TecnicoProducaoApontamento.tipoApontamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_operador", TecnicoProducaoApontamento.codigoOperador));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_recurso", TecnicoProducaoApontamento.codigoRecurso));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_improdutivo", TecnicoProducaoApontamento.codigoImprodutivo));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_previsto_se", TecnicoProducaoApontamento.tempoPrevistoSetup));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_previsto_pr", TecnicoProducaoApontamento.tempoPrevistoProducao));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_previsto_co", TecnicoProducaoApontamento.tempoPrevistoControle));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_passado_set", TecnicoProducaoApontamento.tempoRealizadoSetup));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_passado_pro", TecnicoProducaoApontamento.tempoRealizadoProducao));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_passado_con", TecnicoProducaoApontamento.tempoRealizadoControle));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_tempo_passado_imp", TecnicoProducaoApontamento.tempoRealizadoImprodutivo));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_termin", TecnicoProducaoApontamento.quantidadeTerminada));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_ruim", TecnicoProducaoApontamento.quantidadeRuim));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_quantidade_boa", TecnicoProducaoApontamento.quantidadeBoa));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_ficha_producao", TecnicoProducaoApontamento.codigoFichaProducao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_projeto_producao", TecnicoProducaoApontamento.codigoProjeto));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_ordem_fabricacao", TecnicoProducaoApontamento.codigoOrdemFabricacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_produto", TecnicoProducaoApontamento.nomeProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("id_produto", TecnicoProducaoApontamento.idProdutoOf));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_fase", TecnicoProducaoApontamento.fase));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_tipo_produto", TecnicoProducaoApontamento.codigoTipoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_potencial_recurso", TecnicoProducaoApontamento.potencialRecurso));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_custo_hora_setup", TecnicoProducaoApontamento.custoHoraSetup));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_custo_hora_produc", TecnicoProducaoApontamento.custoHoraProducao));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_custo_hora_contro", TecnicoProducaoApontamento.custoHoraControle));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_custo_hora_operad", TecnicoProducaoApontamento.custoHoraOperador));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento TecnicoProducaoApontamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ProducaoApontamento Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Data", "dt_cadastro", TecnicoProducaoApontamento.data, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TipoApontamento", "cd_tipo_apontamento", TecnicoProducaoApontamento.tipoApontamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoOperador", "cd_operador", TecnicoProducaoApontamento.codigoOperador, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoRecurso", "cd_recurso", TecnicoProducaoApontamento.codigoRecurso, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoImprodutivo", "cd_improdutivo", TecnicoProducaoApontamento.codigoImprodutivo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoPrevistoSetup", "vl_tempo_previsto_se", TecnicoProducaoApontamento.tempoPrevistoSetup, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoPrevistoProducao", "vl_tempo_previsto_pr", TecnicoProducaoApontamento.tempoPrevistoProducao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoPrevistoControle", "vl_tempo_previsto_co", TecnicoProducaoApontamento.tempoPrevistoControle, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoSetup", "vl_tempo_passado_set", TecnicoProducaoApontamento.tempoRealizadoSetup, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoProducao", "vl_tempo_passado_pro", TecnicoProducaoApontamento.tempoRealizadoProducao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoControle", "vl_tempo_passado_con", TecnicoProducaoApontamento.tempoRealizadoControle, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoImprodutivo", "vl_tempo_passado_imp", TecnicoProducaoApontamento.tempoRealizadoImprodutivo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeTerminada", "vl_quantidade_termin", TecnicoProducaoApontamento.quantidadeTerminada, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeRuim", "vl_quantidade_ruim", TecnicoProducaoApontamento.quantidadeRuim, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeBoa", "vl_quantidade_boa", TecnicoProducaoApontamento.quantidadeBoa, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFichaProducao", "cd_ficha_producao", TecnicoProducaoApontamento.codigoFichaProducao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProjeto", "cd_projeto_producao", TecnicoProducaoApontamento.codigoProjeto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoOrdemFabricacao", "cd_ordem_fabricacao", TecnicoProducaoApontamento.codigoOrdemFabricacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NomeProduto", "nm_produto", TecnicoProducaoApontamento.nomeProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IdProdutoOf", "id_produto", TecnicoProducaoApontamento.idProdutoOf, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Fase", "nm_fase", TecnicoProducaoApontamento.fase, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProduto", "cd_tipo_produto", TecnicoProducaoApontamento.codigoTipoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PotencialRecurso", "vl_potencial_recurso", TecnicoProducaoApontamento.potencialRecurso, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CustoHoraSetup", "vl_custo_hora_setup", TecnicoProducaoApontamento.custoHoraSetup, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CustoHoraProducao", "vl_custo_hora_produc", TecnicoProducaoApontamento.custoHoraProducao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CustoHoraControle", "vl_custo_hora_contro", TecnicoProducaoApontamento.custoHoraControle, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CustoHoraOperador", "vl_custo_hora_operad", TecnicoProducaoApontamento.custoHoraOperador, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoProducaoApontamento.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoProducaoApontamento(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ProducaoApontamento ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
