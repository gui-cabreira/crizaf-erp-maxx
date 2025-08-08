using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoProducaoEstatisticasApontamento : ITecnicoProducaoEstatisticasApontamento
{
	private MapTableTecnicoProducaoEstatisticasApontamento MapearClasse(DataRow row)
	{
		MapTableTecnicoProducaoEstatisticasApontamento result = default(MapTableTecnicoProducaoEstatisticasApontamento);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.dataInicio = BaseDadosERP.ObterDbValor<DateTime>(row["dataInicio"]);
			result.dataFim = BaseDadosERP.ObterDbValor<DateTime>(row["dataFim"]);
			result.tipoApontamento = BaseDadosERP.ObterDbValor<string>(row["tipoApontamento"]);
			result.codigoFuncionario = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionario"]);
			result.nomeFuncionario = BaseDadosERP.ObterDbValor<string>(row["nomeFuncionario"]);
			result.codigoFichaProducao = BaseDadosERP.ObterDbValor<int>(row["codigoFichaProducao"]);
			result.codigoProjeto = BaseDadosERP.ObterDbValor<int>(row["codigoProjeto"]);
			result.codigoOrdemFabricacao = BaseDadosERP.ObterDbValor<int>(row["codigoOrdemFabricacao"]);
			result.codigoIdPeca = BaseDadosERP.ObterDbValor<int>(row["codigoIdPeca"]);
			result.nomeProduto = BaseDadosERP.ObterDbValor<string>(row["nomeProduto"]);
			result.fase = BaseDadosERP.ObterDbValor<int>(row["fase"]);
			result.tipoRecursoApontado = BaseDadosERP.ObterDbValor<int>(row["tipoRecursoApontado"]);
			result.codigoRecursoApontado = BaseDadosERP.ObterDbValor<int>(row["recursoApontado"]);
			result.nomeRecursoApontado = BaseDadosERP.ObterDbValor<string>(row["nomeRecurso"]);
			result.codigoParada = BaseDadosERP.ObterDbValor<int>(row["codigoParada"]);
			result.nomeParada = BaseDadosERP.ObterDbValor<string>(row["nomeParada"]);
			result.tipoRecurosProcesso = BaseDadosERP.ObterDbValor<int>(row["tipoRecurosProcesso"]);
			result.codigoRecursoProcesso = BaseDadosERP.ObterDbValor<int>(row["codigoRecursoProcesso"]);
			result.nomeRecursoProcesso = BaseDadosERP.ObterDbValor<string>(row["nomeRecursoProcesso"]);
			result.tempoPreparacaoPrevisto = BaseDadosERP.ObterDbValor<decimal>(row["tempoPreparacaoPrevisto"]);
			result.tempoPreparacaoApontado = BaseDadosERP.ObterDbValor<decimal>(row["tempoPreparacaoApontado"]);
			result.tempoProducaoPrevisto = BaseDadosERP.ObterDbValor<decimal>(row["tempoProducaoPrevisto"]);
			result.tempoProducaoApontado = BaseDadosERP.ObterDbValor<decimal>(row["tempoProducaoApontado"]);
			result.tempoControlePrevisto = BaseDadosERP.ObterDbValor<decimal>(row["tempoControlePrevisto"]);
			result.tempoControleApontado = BaseDadosERP.ObterDbValor<decimal>(row["tempoControleApontado"]);
			result.tempoParada = BaseDadosERP.ObterDbValor<decimal>(row["tempoParada"]);
			result.tempoTotalPrevisto = BaseDadosERP.ObterDbValor<decimal>(row["tempoTotalPrevisto"]);
			result.tempoTotalApontado = BaseDadosERP.ObterDbValor<decimal>(row["tempoTotalApontado"]);
			result.pecasHoraProcesso = BaseDadosERP.ObterDbValor<int>(row["pecasHoraProcesso"]);
			result.pecasHoraApontado = BaseDadosERP.ObterDbValor<int>(row["pecasHoraApontado"]);
			result.quantidadeProduzida = BaseDadosERP.ObterDbValor<int>(row["quantidadeProduzida"]);
			result.quantidadeRuim = BaseDadosERP.ObterDbValor<int>(row["quantidadeRuim"]);
			result.quantidadeBoa = BaseDadosERP.ObterDbValor<int>(row["quantidadeBoa"]);
			result.custoPrevisto = BaseDadosERP.ObterDbValor<decimal>(row["custoPrevisto"]);
			result.custoRealizado = BaseDadosERP.ObterDbValor<decimal>(row["custoRealizado"]);
			result.custoDivergencia = BaseDadosERP.ObterDbValor<decimal>(row["custoDivergencia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("dt_inicio as dataInicio, ");
		stringBuilder.Append("dt_termino as dataFim, ");
		stringBuilder.Append("nm_tipo_apontamento as tipoApontamento, ");
		stringBuilder.Append("cd_funcionario as codigoFuncionario, ");
		stringBuilder.Append("nm_funcionario as nomeFuncionario, ");
		stringBuilder.Append("cd_ficha_producao as codigoFichaProducao, ");
		stringBuilder.Append("cd_projeto as codigoProjeto, ");
		stringBuilder.Append("cd_of as codigoOrdemFabricacao, ");
		stringBuilder.Append("nm_produto as nomeProduto, ");
		stringBuilder.Append("cd_fase as fase, ");
		stringBuilder.Append("cd_tipo_recurso_apon as tipoRecursoApontado, ");
		stringBuilder.Append("cd_recurso_apontado as recursoApontado, ");
		stringBuilder.Append("nm_recurso as nomeRecurso, ");
		stringBuilder.Append("cd_parada as codigoParada, ");
		stringBuilder.Append("nm_parada as nomeParada, ");
		stringBuilder.Append("cd_tipo_recurso_proc as tipoRecurosProcesso, ");
		stringBuilder.Append("cd_recurso_processo as codigoRecursoProcesso, ");
		stringBuilder.Append("nm_recurso_processo as nomeRecursoProcesso, ");
		stringBuilder.Append("tp_preparacao_previs as tempoPreparacaoPrevisto, ");
		stringBuilder.Append("tp_preparacao_aponta as tempoPreparacaoApontado, ");
		stringBuilder.Append("tp_producao_previsto as tempoProducaoPrevisto, ");
		stringBuilder.Append("tp_producao_apontado as tempoProducaoApontado, ");
		stringBuilder.Append("tp_controle_previsto as tempoControlePrevisto, ");
		stringBuilder.Append("tp_controle_apontado as tempoControleApontado, ");
		stringBuilder.Append("tp_parada as tempoParada, ");
		stringBuilder.Append("tp_total_previsto as tempoTotalPrevisto, ");
		stringBuilder.Append("tp_total_apontado as tempoTotalApontado, ");
		stringBuilder.Append("vl_pecas_hora_proces as pecasHoraProcesso, ");
		stringBuilder.Append("vl_pecas_hora_aponta as pecasHoraApontado, ");
		stringBuilder.Append("qd_produzida as quantidadeProduzida, ");
		stringBuilder.Append("qd_ruim as quantidadeRuim, ");
		stringBuilder.Append("qd_boa as quantidadeBoa, ");
		stringBuilder.Append("vl_custo_previsto as custoPrevisto, ");
		stringBuilder.Append("vl_custo_realizado as custoRealizado, ");
		stringBuilder.Append("vl_resultado as custoDivergencia, ");
		stringBuilder.Append("cd_id_peca as codigoIdPeca");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.Apontamento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticasApontamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoProducaoEstatisticasApontamento> list = new List<MapTableTecnicoProducaoEstatisticasApontamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticasApontamento(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" dt_inicio between ?");
		stringBuilder.Append(" and ?");
		list.Add(BaseDadosERP.ObterNovoParametro("dt_inicio1", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_inicio2", dataFim));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoProducaoEstatisticasApontamento> list2 = new List<MapTableTecnicoProducaoEstatisticasApontamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoProducaoEstatisticasApontamento ObterTecnicoProducaoEstatisticasApontamento(int id)
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

	public MapTableTecnicoProducaoEstatisticasApontamento ObterTecnicoProducaoEstatisticasApontamento(MapTableTecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", TecnicoProducaoEstatisticasApontamento.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoProducaoEstatisticasApontamento(MapTableTecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.Apontamento (");
		stringBuilder.Append("dt_inicio, ");
		stringBuilder.Append("dt_termino, ");
		stringBuilder.Append("nm_tipo_apontamento, ");
		stringBuilder.Append("cd_funcionario, ");
		stringBuilder.Append("nm_funcionario, ");
		stringBuilder.Append("cd_ficha_producao, ");
		stringBuilder.Append("cd_projeto, ");
		stringBuilder.Append("cd_of, ");
		stringBuilder.Append("nm_produto, ");
		stringBuilder.Append("cd_fase, ");
		stringBuilder.Append("cd_tipo_recurso_apon, ");
		stringBuilder.Append("cd_recurso_apontado, ");
		stringBuilder.Append("nm_recurso, ");
		stringBuilder.Append("cd_parada, ");
		stringBuilder.Append("nm_parada, ");
		stringBuilder.Append("cd_tipo_recurso_proc, ");
		stringBuilder.Append("cd_recurso_processo, ");
		stringBuilder.Append("nm_recurso_processo, ");
		stringBuilder.Append("tp_preparacao_previs, ");
		stringBuilder.Append("tp_preparacao_aponta, ");
		stringBuilder.Append("tp_producao_previsto, ");
		stringBuilder.Append("tp_producao_apontado, ");
		stringBuilder.Append("tp_controle_previsto, ");
		stringBuilder.Append("tp_controle_apontado, ");
		stringBuilder.Append("tp_parada, ");
		stringBuilder.Append("tp_total_previsto, ");
		stringBuilder.Append("tp_total_apontado, ");
		stringBuilder.Append("vl_pecas_hora_proces, ");
		stringBuilder.Append("vl_pecas_hora_aponta, ");
		stringBuilder.Append("qd_produzida, ");
		stringBuilder.Append("qd_ruim, ");
		stringBuilder.Append("qd_boa, ");
		stringBuilder.Append("vl_custo_previsto, ");
		stringBuilder.Append("vl_custo_realizado, ");
		stringBuilder.Append("vl_resultado, ");
		stringBuilder.Append("cd_id_peca) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("dt_inicio", TecnicoProducaoEstatisticasApontamento.dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_termino", TecnicoProducaoEstatisticasApontamento.dataFim));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_tipo_apontamento", TecnicoProducaoEstatisticasApontamento.tipoApontamento));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_funcionario", TecnicoProducaoEstatisticasApontamento.codigoFuncionario));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_funcionario", TecnicoProducaoEstatisticasApontamento.nomeFuncionario));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_ficha_producao", TecnicoProducaoEstatisticasApontamento.codigoFichaProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_projeto", TecnicoProducaoEstatisticasApontamento.codigoProjeto));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_of", TecnicoProducaoEstatisticasApontamento.codigoOrdemFabricacao));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_produto", TecnicoProducaoEstatisticasApontamento.nomeProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_fase", TecnicoProducaoEstatisticasApontamento.fase));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_tipo_recurso_apon", TecnicoProducaoEstatisticasApontamento.tipoRecursoApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_recurso_apontado", TecnicoProducaoEstatisticasApontamento.codigoRecursoApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_recurso", TecnicoProducaoEstatisticasApontamento.nomeRecursoApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_parada", TecnicoProducaoEstatisticasApontamento.codigoParada));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_parada", TecnicoProducaoEstatisticasApontamento.nomeParada));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_tipo_recurso_proc", TecnicoProducaoEstatisticasApontamento.tipoRecurosProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_recurso_processo", TecnicoProducaoEstatisticasApontamento.codigoRecursoProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_recurso_processo", TecnicoProducaoEstatisticasApontamento.nomeRecursoProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_preparacao_previs", TecnicoProducaoEstatisticasApontamento.tempoPreparacaoPrevisto));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_preparacao_aponta", TecnicoProducaoEstatisticasApontamento.tempoPreparacaoApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_producao_previsto", TecnicoProducaoEstatisticasApontamento.tempoProducaoPrevisto));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_producao_apontado", TecnicoProducaoEstatisticasApontamento.tempoProducaoApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_controle_previsto", TecnicoProducaoEstatisticasApontamento.tempoControlePrevisto));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_controle_apontado", TecnicoProducaoEstatisticasApontamento.tempoControleApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_parada", TecnicoProducaoEstatisticasApontamento.tempoParada));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_total_previsto", TecnicoProducaoEstatisticasApontamento.tempoTotalPrevisto));
		list.Add(BaseDadosERP.ObterNovoParametro("tp_total_apontado", TecnicoProducaoEstatisticasApontamento.tempoTotalApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_pecas_hora_proces", TecnicoProducaoEstatisticasApontamento.pecasHoraProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_pecas_hora_aponta", TecnicoProducaoEstatisticasApontamento.pecasHoraApontado));
		list.Add(BaseDadosERP.ObterNovoParametro("qd_produzida", TecnicoProducaoEstatisticasApontamento.quantidadeProduzida));
		list.Add(BaseDadosERP.ObterNovoParametro("qd_ruim", TecnicoProducaoEstatisticasApontamento.quantidadeRuim));
		list.Add(BaseDadosERP.ObterNovoParametro("qd_boa", TecnicoProducaoEstatisticasApontamento.quantidadeBoa));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_custo_previsto", TecnicoProducaoEstatisticasApontamento.custoPrevisto));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_custo_realizado", TecnicoProducaoEstatisticasApontamento.custoRealizado));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_resultado", TecnicoProducaoEstatisticasApontamento.custoDivergencia));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_id_peca", TecnicoProducaoEstatisticasApontamento.codigoIdPeca));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoProducaoEstatisticasApontamento(MapTableTecnicoProducaoEstatisticasApontamento TecnicoProducaoEstatisticasApontamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.Apontamento Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataInicio", "dt_inicio", TecnicoProducaoEstatisticasApontamento.dataInicio, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataFim", "dt_termino", TecnicoProducaoEstatisticasApontamento.dataFim, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoApontamento", "nm_tipo_apontamento", TecnicoProducaoEstatisticasApontamento.tipoApontamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "cd_funcionario", TecnicoProducaoEstatisticasApontamento.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeFuncionario", "nm_funcionario", TecnicoProducaoEstatisticasApontamento.nomeFuncionario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFichaProducao", "cd_ficha_producao", TecnicoProducaoEstatisticasApontamento.codigoFichaProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProjeto", "cd_projeto", TecnicoProducaoEstatisticasApontamento.codigoProjeto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoOrdemFabricacao", "cd_of", TecnicoProducaoEstatisticasApontamento.codigoOrdemFabricacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeProduto", "nm_produto", TecnicoProducaoEstatisticasApontamento.nomeProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Fase", "cd_fase", TecnicoProducaoEstatisticasApontamento.fase, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoRecursoApontado", "cd_tipo_recurso_apon", TecnicoProducaoEstatisticasApontamento.tipoRecursoApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRecursoApontado", "cd_recurso_apontado", TecnicoProducaoEstatisticasApontamento.codigoRecursoApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeRecursoApontado", "nm_recurso", TecnicoProducaoEstatisticasApontamento.nomeRecursoApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoParada", "cd_parada", TecnicoProducaoEstatisticasApontamento.codigoParada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeParada", "nm_parada", TecnicoProducaoEstatisticasApontamento.nomeParada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoRecurosProcesso", "cd_tipo_recurso_proc", TecnicoProducaoEstatisticasApontamento.tipoRecurosProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRecursoProcesso", "cd_recurso_processo", TecnicoProducaoEstatisticasApontamento.codigoRecursoProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeRecursoProcesso", "nm_recurso_processo", TecnicoProducaoEstatisticasApontamento.nomeRecursoProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoPreparacaoPrevisto", "tp_preparacao_previs", TecnicoProducaoEstatisticasApontamento.tempoPreparacaoPrevisto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoPreparacaoApontado", "tp_preparacao_aponta", TecnicoProducaoEstatisticasApontamento.tempoPreparacaoApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoProducaoPrevisto", "tp_producao_previsto", TecnicoProducaoEstatisticasApontamento.tempoProducaoPrevisto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoProducaoApontado", "tp_producao_apontado", TecnicoProducaoEstatisticasApontamento.tempoProducaoApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoControlePrevisto", "tp_controle_previsto", TecnicoProducaoEstatisticasApontamento.tempoControlePrevisto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoControleApontado", "tp_controle_apontado", TecnicoProducaoEstatisticasApontamento.tempoControleApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoParada", "tp_parada", TecnicoProducaoEstatisticasApontamento.tempoParada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoTotalPrevisto", "tp_total_previsto", TecnicoProducaoEstatisticasApontamento.tempoTotalPrevisto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoTotalApontado", "tp_total_apontado", TecnicoProducaoEstatisticasApontamento.tempoTotalApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PecasHoraProcesso", "vl_pecas_hora_proces", TecnicoProducaoEstatisticasApontamento.pecasHoraProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PecasHoraApontado", "vl_pecas_hora_aponta", TecnicoProducaoEstatisticasApontamento.pecasHoraApontado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeProduzida", "qd_produzida", TecnicoProducaoEstatisticasApontamento.quantidadeProduzida, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeRuim", "qd_ruim", TecnicoProducaoEstatisticasApontamento.quantidadeRuim, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeBoa", "qd_boa", TecnicoProducaoEstatisticasApontamento.quantidadeBoa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoPrevisto", "vl_custo_previsto", TecnicoProducaoEstatisticasApontamento.custoPrevisto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoRealizado", "vl_custo_realizado", TecnicoProducaoEstatisticasApontamento.custoRealizado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoDivergencia", "vl_resultado", TecnicoProducaoEstatisticasApontamento.custoDivergencia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoIdPeca", "cd_id_peca", TecnicoProducaoEstatisticasApontamento.codigoIdPeca, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", TecnicoProducaoEstatisticasApontamento.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoProducaoEstatisticasApontamento(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.Apontamento ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableTecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticaOperacao(DateTime dataInicio, DateTime dataFim)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public IList<MapTableTecnicoProducaoEstatisticasApontamento> ObterTodosTecnicoProducaoEstatisticaOperacaoOperador(DateTime dataInicio, DateTime dataFim)
	{
		throw new Exception("The method or operation is not implemented.");
	}
}
