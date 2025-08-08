using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoProducaoApontamento : ITecnicoProducaoApontamento
{
	private MapTableTecnicoProducaoApontamento MapearClasse(DataRow row)
	{
		MapTableTecnicoProducaoApontamento result = default(MapTableTecnicoProducaoApontamento);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.data = BaseDadosERP.ObterDbValor<DateTime>(row["data"]);
			result.tipoApontamento = BaseDadosERP.ObterDbValor<int>(row["tipoApontamento"]);
			result.codigoOperador = BaseDadosERP.ObterDbValor<int>(row["codigoOperador"]);
			result.codigoRecurso = BaseDadosERP.ObterDbValor<int>(row["codigoRecurso"]);
			result.codigoImprodutivo = BaseDadosERP.ObterDbValor<int>(row["codigoImprodutivo"]);
			result.tempoPrevistoSetup = BaseDadosERP.ObterDbValor<decimal>(row["tempoPrevistoSetup"]);
			result.tempoPrevistoProducao = BaseDadosERP.ObterDbValor<decimal>(row["tempoPrevistoProducao"]);
			result.tempoPrevistoControle = BaseDadosERP.ObterDbValor<decimal>(row["tempoPrevistoControle"]);
			result.tempoRealizadoSetup = BaseDadosERP.ObterDbValor<decimal>(row["tempoRealizadoSetup"]);
			result.tempoRealizadoProducao = BaseDadosERP.ObterDbValor<decimal>(row["tempoRealizadoProducao"]);
			result.tempoRealizadoControle = BaseDadosERP.ObterDbValor<decimal>(row["tempoRealizadoControle"]);
			result.tempoRealizadoImprodutivo = BaseDadosERP.ObterDbValor<decimal>(row["tempoRealizadoImprodutivo"]);
			result.quantidadeTerminada = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeTerminada"]);
			result.quantidadeRuim = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeRuim"]);
			result.quantidadeBoa = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeBoa"]);
			result.codigoFichaProducao = BaseDadosERP.ObterDbValor<int>(row["codigoFichaProducao"]);
			result.codigoProjeto = BaseDadosERP.ObterDbValor<int>(row["codigoProjeto"]);
			result.codigoOrdemFabricacao = BaseDadosERP.ObterDbValor<int>(row["codigoOrdemFabricacao"]);
			result.nomeProduto = BaseDadosERP.ObterDbValor<string>(row["nomeProduto"]);
			result.idProdutoOf = BaseDadosERP.ObterDbValor<int>(row["idProdutoOf"]);
			result.fase = BaseDadosERP.ObterDbValor<int>(row["fase"]);
			result.codigoTipoProduto = BaseDadosERP.ObterDbValor<int>(row["codigoTipoProduto"]);
			result.potencialRecurso = BaseDadosERP.ObterDbValor<decimal>(row["potencialRecurso"]);
			result.custoHoraSetup = BaseDadosERP.ObterDbValor<decimal>(row["custoHoraSetup"]);
			result.custoHoraProducao = BaseDadosERP.ObterDbValor<decimal>(row["custoHoraProducao"]);
			result.custoHoraControle = BaseDadosERP.ObterDbValor<decimal>(row["custoHoraControle"]);
			result.custoHoraOperador = BaseDadosERP.ObterDbValor<decimal>(row["custoHoraOperador"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[dt_cadastro] as [data], ");
		stringBuilder.Append("[cd_tipo_apontamento] as [tipoApontamento], ");
		stringBuilder.Append("[cd_operador] as [codigoOperador], ");
		stringBuilder.Append("[cd_recurso] as [codigoRecurso], ");
		stringBuilder.Append("[cd_improdutivo] as [codigoImprodutivo], ");
		stringBuilder.Append("[vl_tempo_previsto_setup] as [tempoPrevistoSetup], ");
		stringBuilder.Append("[vl_tempo_previsto_producao] as [tempoPrevistoProducao], ");
		stringBuilder.Append("[vl_tempo_previsto_controle] as [tempoPrevistoControle], ");
		stringBuilder.Append("[vl_tempo_passado_setup] as [tempoRealizadoSetup], ");
		stringBuilder.Append("[vl_tempo_passado_producao] as [tempoRealizadoProducao], ");
		stringBuilder.Append("[vl_tempo_passado_controle] as [tempoRealizadoControle], ");
		stringBuilder.Append("[vl_tempo_passado_improdutivo] as [tempoRealizadoImprodutivo], ");
		stringBuilder.Append("[vl_quantidade_terminada] as [quantidadeTerminada], ");
		stringBuilder.Append("[vl_quantidade_ruim] as [quantidadeRuim], ");
		stringBuilder.Append("[vl_quantidade_boa] as [quantidadeBoa], ");
		stringBuilder.Append("[cd_ficha_producao] as [codigoFichaProducao], ");
		stringBuilder.Append("[cd_projeto_producao] as [codigoProjeto], ");
		stringBuilder.Append("[cd_ordem_fabricacao] as [codigoOrdemFabricacao], ");
		stringBuilder.Append("[nm_produto] as [nomeProduto], ");
		stringBuilder.Append("[id_produto] as [idProdutoOf], ");
		stringBuilder.Append("[nm_fase] as [fase], ");
		stringBuilder.Append("[cd_tipo_produto] as [codigoTipoProduto], ");
		stringBuilder.Append("[vl_potencial_recurso] as [potencialRecurso], ");
		stringBuilder.Append("[vl_custo_hora_setup] as [custoHoraSetup], ");
		stringBuilder.Append("[vl_custo_hora_producao] as [custoHoraProducao], ");
		stringBuilder.Append("[vl_custo_hora_controle] as [custoHoraControle], ");
		stringBuilder.Append("[vl_custo_hora_operador] as [custoHoraOperador]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoProducao].[Apontamento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoProducaoApontamento> list = new List<MapTableTecnicoProducaoApontamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append("[dt_cadastro] between @dataInicio and @dataFim");
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoProducaoApontamento> list2 = new List<MapTableTecnicoProducaoApontamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoProducaoApontamento ObterTecnicoProducaoApontamento(int id)
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

	public MapTableTecnicoProducaoApontamento ObterTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento tecnicoProducaoApontamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", tecnicoProducaoApontamento.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento tecnicoProducaoApontamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoProducao].[Apontamento] (");
		stringBuilder.Append("[dt_cadastro], ");
		stringBuilder.Append("[cd_tipo_apontamento], ");
		stringBuilder.Append("[cd_operador], ");
		stringBuilder.Append("[cd_recurso], ");
		stringBuilder.Append("[cd_improdutivo], ");
		stringBuilder.Append("[vl_tempo_previsto_setup], ");
		stringBuilder.Append("[vl_tempo_previsto_producao], ");
		stringBuilder.Append("[vl_tempo_previsto_controle], ");
		stringBuilder.Append("[vl_tempo_passado_setup], ");
		stringBuilder.Append("[vl_tempo_passado_producao], ");
		stringBuilder.Append("[vl_tempo_passado_controle], ");
		stringBuilder.Append("[vl_tempo_passado_improdutivo], ");
		stringBuilder.Append("[vl_quantidade_terminada], ");
		stringBuilder.Append("[vl_quantidade_ruim], ");
		stringBuilder.Append("[vl_quantidade_boa], ");
		stringBuilder.Append("[cd_ficha_producao], ");
		stringBuilder.Append("[cd_projeto_producao], ");
		stringBuilder.Append("[cd_ordem_fabricacao], ");
		stringBuilder.Append("[nm_produto], ");
		stringBuilder.Append("[id_produto], ");
		stringBuilder.Append("[nm_fase], ");
		stringBuilder.Append("[cd_tipo_produto], ");
		stringBuilder.Append("[vl_potencial_recurso], ");
		stringBuilder.Append("[vl_custo_hora_setup], ");
		stringBuilder.Append("[vl_custo_hora_producao], ");
		stringBuilder.Append("[vl_custo_hora_controle], ");
		stringBuilder.Append("[vl_custo_hora_operador]) Values (@dt_cadastro,@cd_tipo_apontamento,@cd_operador,@cd_recurso,@cd_improdutivo,@vl_tempo_previsto_setup,@vl_tempo_previsto_producao,@vl_tempo_previsto_controle,@vl_tempo_passado_setup,@vl_tempo_passado_producao,@vl_tempo_passado_controle,@vl_tempo_passado_improdutivo,@vl_quantidade_terminada,@vl_quantidade_ruim,@vl_quantidade_boa,@cd_ficha_producao,@cd_projeto_producao,@cd_ordem_fabricacao,@nm_produto,@id_produto,@nm_fase,@cd_tipo_produto,@vl_potencial_recurso,@vl_custo_hora_setup,@vl_custo_hora_producao,@vl_custo_hora_controle,@vl_custo_hora_operador) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_cadastro", tecnicoProducaoApontamento.data));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_apontamento", tecnicoProducaoApontamento.tipoApontamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_operador", tecnicoProducaoApontamento.codigoOperador));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_recurso", tecnicoProducaoApontamento.codigoRecurso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_improdutivo", tecnicoProducaoApontamento.codigoImprodutivo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_previsto_setup", tecnicoProducaoApontamento.tempoPrevistoSetup));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_previsto_producao", tecnicoProducaoApontamento.tempoPrevistoProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_previsto_controle", tecnicoProducaoApontamento.tempoPrevistoControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_passado_setup", tecnicoProducaoApontamento.tempoRealizadoSetup));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_passado_producao", tecnicoProducaoApontamento.tempoRealizadoProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_passado_controle", tecnicoProducaoApontamento.tempoRealizadoControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_tempo_passado_improdutivo", tecnicoProducaoApontamento.tempoRealizadoImprodutivo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade_terminada", tecnicoProducaoApontamento.quantidadeTerminada));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade_ruim", tecnicoProducaoApontamento.quantidadeRuim));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade_boa", tecnicoProducaoApontamento.quantidadeBoa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ficha_producao", tecnicoProducaoApontamento.codigoFichaProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_projeto_producao", tecnicoProducaoApontamento.codigoProjeto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ordem_fabricacao", tecnicoProducaoApontamento.codigoOrdemFabricacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_produto", tecnicoProducaoApontamento.nomeProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_produto", tecnicoProducaoApontamento.idProdutoOf));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fase", tecnicoProducaoApontamento.fase));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_produto", tecnicoProducaoApontamento.codigoTipoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_potencial_recurso", tecnicoProducaoApontamento.potencialRecurso));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_custo_hora_setup", tecnicoProducaoApontamento.custoHoraSetup));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_custo_hora_producao", tecnicoProducaoApontamento.custoHoraProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_custo_hora_controle", tecnicoProducaoApontamento.custoHoraControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_custo_hora_operador", tecnicoProducaoApontamento.custoHoraOperador));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento tecnicoProducaoApontamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoProducao].[Apontamento] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Data", "dt_cadastro", tecnicoProducaoApontamento.data, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoApontamento", "cd_tipo_apontamento", tecnicoProducaoApontamento.tipoApontamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoOperador", "cd_operador", tecnicoProducaoApontamento.codigoOperador, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRecurso", "cd_recurso", tecnicoProducaoApontamento.codigoRecurso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoImprodutivo", "cd_improdutivo", tecnicoProducaoApontamento.codigoImprodutivo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoPrevistoSetup", "vl_tempo_previsto_setup", tecnicoProducaoApontamento.tempoPrevistoSetup, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoPrevistoProducao", "vl_tempo_previsto_producao", tecnicoProducaoApontamento.tempoPrevistoProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoPrevistoControle", "vl_tempo_previsto_controle", tecnicoProducaoApontamento.tempoPrevistoControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoSetup", "vl_tempo_passado_setup", tecnicoProducaoApontamento.tempoRealizadoSetup, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoProducao", "vl_tempo_passado_producao", tecnicoProducaoApontamento.tempoRealizadoProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoControle", "vl_tempo_passado_controle", tecnicoProducaoApontamento.tempoRealizadoControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoRealizadoImprodutivo", "vl_tempo_passado_improdutivo", tecnicoProducaoApontamento.tempoRealizadoImprodutivo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeTerminada", "vl_quantidade_terminada", tecnicoProducaoApontamento.quantidadeTerminada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeRuim", "vl_quantidade_ruim", tecnicoProducaoApontamento.quantidadeRuim, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeBoa", "vl_quantidade_boa", tecnicoProducaoApontamento.quantidadeBoa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFichaProducao", "cd_ficha_producao", tecnicoProducaoApontamento.codigoFichaProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProjeto", "cd_projeto_producao", tecnicoProducaoApontamento.codigoProjeto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoOrdemFabricacao", "cd_ordem_fabricacao", tecnicoProducaoApontamento.codigoOrdemFabricacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeProduto", "nm_produto", tecnicoProducaoApontamento.nomeProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProdutoOf", "id_produto", tecnicoProducaoApontamento.idProdutoOf, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Fase", "nm_fase", tecnicoProducaoApontamento.fase, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProduto", "cd_tipo_produto", tecnicoProducaoApontamento.codigoTipoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PotencialRecurso", "vl_potencial_recurso", tecnicoProducaoApontamento.potencialRecurso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoHoraSetup", "vl_custo_hora_setup", tecnicoProducaoApontamento.custoHoraSetup, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoHoraProducao", "vl_custo_hora_producao", tecnicoProducaoApontamento.custoHoraProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoHoraControle", "vl_custo_hora_controle", tecnicoProducaoApontamento.custoHoraControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CustoHoraOperador", "vl_custo_hora_operador", tecnicoProducaoApontamento.custoHoraOperador, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", tecnicoProducaoApontamento.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoProducaoApontamento(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoProducao].[Apontamento] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
