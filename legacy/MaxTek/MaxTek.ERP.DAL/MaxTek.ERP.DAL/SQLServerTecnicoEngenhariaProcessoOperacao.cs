using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProcessoOperacao : ITecnicoEngenhariaProcessoOperacao
{
	private MapTableTecnicoEngenhariaProcessoOperacao MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProcessoOperacao result = default(MapTableTecnicoEngenhariaProcessoOperacao);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.revisaoOperacao = BaseDadosERP.ObterDbValor<int>(row["revisaoOperacao"]);
			result.dataCriacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataCriacao"]);
			result.dataAtualizacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoFuncionarioCriador = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioCriador"]);
			result.codigoFuncionarioAtualizacao = BaseDadosERP.ObterDbValor<string>(row["codigoFuncionarioAtualizacao"]);
			result.isAprovado = BaseDadosERP.ObterDbValor<bool>(row["isAprovado"]);
			result.codigoFuncionarioAprovacao = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioAprovacao"]);
			result.nomeUsuarioConectado = BaseDadosERP.ObterDbValor<string>(row["nomeUsuarioConectado"]);
			result.nomeUsuarioConectadoAprovacao = BaseDadosERP.ObterDbValor<string>(row["nomeUsuarioConectadoAprovacao"]);
			result.idProcesso = BaseDadosERP.ObterDbValor<int>(row["idProcesso"]);
			result.codigoTipoProcesso = BaseDadosERP.ObterDbValor<int>(row["codigoTipoProcesso"]);
			result.codigoTipoRecurso = BaseDadosERP.ObterDbValor<int>(row["codigoTipoRecurso"]);
			result.codigoRecurso = BaseDadosERP.ObterDbValor<int>(row["codigoRecurso"]);
			result.tempoSetUp = BaseDadosERP.ObterDbValor<decimal>(row["tempoSetUp"]);
			result.tempoProducao = BaseDadosERP.ObterDbValor<decimal>(row["tempoProducao"]);
			result.tempoControle = BaseDadosERP.ObterDbValor<decimal>(row["tempoControle"]);
			result.tempoTransito = BaseDadosERP.ObterDbValor<decimal>(row["tempoTransito"]);
			result.codigoUnidadeTempo = BaseDadosERP.ObterDbValor<int>(row["codigoUnidadeTempo"]);
			result.valorRendimentoMinimo = BaseDadosERP.ObterDbValor<decimal>(row["valorRendimentoMinimo"]);
			result.valorRendimentoMaximo = BaseDadosERP.ObterDbValor<decimal>(row["valorRendimentoMaximo"]);
			result.quantidadeOperador = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeOperador"]);
			result.codigoTipoOperador = BaseDadosERP.ObterDbValor<int>(row["codigoTipoOperador"]);
			result.codigoTipoSubContratacao = BaseDadosERP.ObterDbValor<int>(row["codigoTipoSubContratacao"]);
			result.codigoEntidadeSubContratada = BaseDadosERP.ObterDbValor<int>(row["codigoEntidadeSubContratada"]);
			result.tempoSubContratacao = BaseDadosERP.ObterDbValor<decimal>(row["tempoSubContratacao"]);
			result.valorTeorico = BaseDadosERP.ObterDbValor<decimal>(row["valorTeorico"]);
			result.valorNecessidade = BaseDadosERP.ObterDbValor<decimal>(row["valorNecessidade"]);
			result.codigoUnidadeSubContratacao = BaseDadosERP.ObterDbValor<int>(row["codigoUnidadeSubContratacao"]);
			result.imagem = BaseDadosERP.ObterDbValor<Image>(row["imagem"]);
			result.nomeInformacaoEspecifica01Recurso01 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica01Recurso01"]);
			result.valorInformacaoEspecifica01Recurso01 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica01Recurso01"]);
			result.nomeInformacaoEspecifica02Recurso01 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica02Recurso01"]);
			result.valorInformacaoEspecifica02Recurso01 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica02Recurso01"]);
			result.nomeInformacaoEspecifica03Recurso01 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica03Recurso01"]);
			result.valorInformacaoEspecifica03Recurso01 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica03Recurso01"]);
			result.nomeInformacaoEspecifica04Recurso01 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica04Recurso01"]);
			result.valorInformacaoEspecifica04Recurso01 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica04Recurso01"]);
			result.nomeInformacaoEspecifica05Recurso01 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica05Recurso01"]);
			result.valorInformacaoEspecifica05Recurso01 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica05Recurso01"]);
			result.nomeInformacaoEspecifica01Recurso02 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica01Recurso02"]);
			result.valorInformacaoEspecifica01Recurso02 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica01Recurso02"]);
			result.nomeInformacaoEspecifica02Recurso02 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica02Recurso02"]);
			result.valorInformacaoEspecifica02Recurso02 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica02Recurso02"]);
			result.nomeInformacaoEspecifica03Recurso02 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica03Recurso02"]);
			result.valorInformacaoEspecifica03Recurso02 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica03Recurso02"]);
			result.nomeInformacaoEspecifica04Recurso02 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica04Recurso02"]);
			result.valorInformacaoEspecifica04Recurso02 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica04Recurso02"]);
			result.nomeInformacaoEspecifica05Recurso02 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica05Recurso02"]);
			result.valorInformacaoEspecifica05Recurso02 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica05Recurso02"]);
			result.nomeInformacaoEspecifica01Recurso03 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica01Recurso03"]);
			result.valorInformacaoEspecifica01Recurso03 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica01Recurso03"]);
			result.nomeInformacaoEspecifica02Recurso03 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica02Recurso03"]);
			result.valorInformacaoEspecifica02Recurso03 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica02Recurso03"]);
			result.nomeInformacaoEspecifica03Recurso03 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica03Recurso03"]);
			result.valorInformacaoEspecifica03Recurso03 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica03Recurso03"]);
			result.nomeInformacaoEspecifica04Recurso03 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica04Recurso03"]);
			result.valorInformacaoEspecifica04Recurso03 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica04Recurso03"]);
			result.nomeInformacaoEspecifica05Recurso03 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoEspecifica05Recurso03"]);
			result.valorInformacaoEspecifica05Recurso03 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoEspecifica05Recurso03"]);
			result.nomeInformacaoAdicional01 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoAdicional01"]);
			result.valorInformacaoAdicional01 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoAdicional01"]);
			result.nomeInformacaoAdicional02 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoAdicional02"]);
			result.valorInformacaoAdicional02 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoAdicional02"]);
			result.nomeInformacaoAdicional03 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoAdicional03"]);
			result.valorInformacaoAdicional03 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoAdicional03"]);
			result.nomeInformacaoAdicional04 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoAdicional04"]);
			result.valorInformacaoAdicional04 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoAdicional04"]);
			result.nomeInformacaoAdicional05 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoAdicional05"]);
			result.valorInformacaoAdicional05 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoAdicional05"]);
			result.nomeInformacaoAdicional06 = BaseDadosERP.ObterDbValor<string>(row["nomeInformacaoAdicional06"]);
			result.valorInformacaoAdicional06 = BaseDadosERP.ObterDbValor<string>(row["valorInformacaoAdicional06"]);
			result.descricaoSequenciaTrabalho = BaseDadosERP.ObterDbValor<string>(row["descricaoSequenciaTrabalho"]);
			result.observacoes = BaseDadosERP.ObterDbValor<string>(row["observacoes"]);
			result.codigoEPI01 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI01"]);
			result.codigoEPI02 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI02"]);
			result.codigoEPI03 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI03"]);
			result.codigoEPI04 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI04"]);
			result.codigoEPI05 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI05"]);
			result.codigoEPI06 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI06"]);
			result.codigoEPI07 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI07"]);
			result.codigoEPI08 = BaseDadosERP.ObterDbValor<int>(row["codigoEPI08"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_revisao_operacao] as [revisaoOperacao], ");
		stringBuilder.Append("[dt_criacao_operacao] as [dataCriacao], ");
		stringBuilder.Append("[dt_atualizacao_operacao] as [dataAtualizacao], ");
		stringBuilder.Append("[cd_funcionario_criador] as [codigoFuncionarioCriador], ");
		stringBuilder.Append("[cd_funcionario_atualizador] as [codigoFuncionarioAtualizacao], ");
		stringBuilder.Append("[ic_aprovado] as [isAprovado], ");
		stringBuilder.Append("[cd_funcionario_aprovador] as [codigoFuncionarioAprovacao], ");
		stringBuilder.Append("[nm_usuario_conectado_modificacao] as [nomeUsuarioConectado], ");
		stringBuilder.Append("[nm_usuario_conectado_aprovacao] as [nomeUsuarioConectadoAprovacao], ");
		stringBuilder.Append("[id_processo] as [idProcesso], ");
		stringBuilder.Append("[cd_tipo_processo] as [codigoTipoProcesso], ");
		stringBuilder.Append("[cd_tipo_recurso] as [codigoTipoRecurso], ");
		stringBuilder.Append("[cd_recurso] as [codigoRecurso], ");
		stringBuilder.Append("[tp_setup] as [tempoSetUp], ");
		stringBuilder.Append("[tp_producao] as [tempoProducao], ");
		stringBuilder.Append("[tp_controle] as [tempoControle], ");
		stringBuilder.Append("[tp_transito] as [tempoTransito], ");
		stringBuilder.Append("[cd_unidade_tempo] as [codigoUnidadeTempo], ");
		stringBuilder.Append("[vl_rendimento_minimo] as [valorRendimentoMinimo], ");
		stringBuilder.Append("[vl_rendimento_maximo] as [valorRendimentoMaximo], ");
		stringBuilder.Append("[qd_operador] as [quantidadeOperador], ");
		stringBuilder.Append("[cd_tipo_operador] as [codigoTipoOperador], ");
		stringBuilder.Append("[cd_tipo_sc] as [codigoTipoSubContratacao], ");
		stringBuilder.Append("[cd_sc] as [codigoEntidadeSubContratada], ");
		stringBuilder.Append("[tp_sc] as [tempoSubContratacao], ");
		stringBuilder.Append("[vl_teorico] as [valorTeorico], ");
		stringBuilder.Append("[vl_necessidade] as [valorNecessidade], ");
		stringBuilder.Append("[cd_unidade_sc] as [codigoUnidadeSubContratacao], ");
		stringBuilder.Append("[im_operacao] as [imagem], ");
		stringBuilder.Append("[nm_informacao_especifica_01_maq_01] as [nomeInformacaoEspecifica01Recurso01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_01_maq_01] as [valorInformacaoEspecifica01Recurso01], ");
		stringBuilder.Append("[nm_informacao_especifica_02_maq_01] as [nomeInformacaoEspecifica02Recurso01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_02_maq_01] as [valorInformacaoEspecifica02Recurso01], ");
		stringBuilder.Append("[nm_informacao_especifica_03_maq_01] as [nomeInformacaoEspecifica03Recurso01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_03_maq_01] as [valorInformacaoEspecifica03Recurso01], ");
		stringBuilder.Append("[nm_informacao_especifica_04_maq_01] as [nomeInformacaoEspecifica04Recurso01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_04_maq_01] as [valorInformacaoEspecifica04Recurso01], ");
		stringBuilder.Append("[nm_informacao_especifica_05_maq_01] as [nomeInformacaoEspecifica05Recurso01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_05_maq_01] as [valorInformacaoEspecifica05Recurso01], ");
		stringBuilder.Append("[nm_informacao_especifica_01_maq_02] as [nomeInformacaoEspecifica01Recurso02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_01_maq_02] as [valorInformacaoEspecifica01Recurso02], ");
		stringBuilder.Append("[nm_informacao_especifica_02_maq_02] as [nomeInformacaoEspecifica02Recurso02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_02_maq_02] as [valorInformacaoEspecifica02Recurso02], ");
		stringBuilder.Append("[nm_informacao_especifica_03_maq_02] as [nomeInformacaoEspecifica03Recurso02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_03_maq_02] as [valorInformacaoEspecifica03Recurso02], ");
		stringBuilder.Append("[nm_informacao_especifica_04_maq_02] as [nomeInformacaoEspecifica04Recurso02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_04_maq_02] as [valorInformacaoEspecifica04Recurso02], ");
		stringBuilder.Append("[nm_informacao_especifica_05_maq_02] as [nomeInformacaoEspecifica05Recurso02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_05_maq_02] as [valorInformacaoEspecifica05Recurso02], ");
		stringBuilder.Append("[nm_informacao_especifica_01_maq_03] as [nomeInformacaoEspecifica01Recurso03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_01_maq_03] as [valorInformacaoEspecifica01Recurso03], ");
		stringBuilder.Append("[nm_informacao_especifica_02_maq_03] as [nomeInformacaoEspecifica02Recurso03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_02_maq_03] as [valorInformacaoEspecifica02Recurso03], ");
		stringBuilder.Append("[nm_informacao_especifica_03_maq_03] as [nomeInformacaoEspecifica03Recurso03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_03_maq_03] as [valorInformacaoEspecifica03Recurso03], ");
		stringBuilder.Append("[nm_informacao_especifica_04_maq_03] as [nomeInformacaoEspecifica04Recurso03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_04_maq_03] as [valorInformacaoEspecifica04Recurso03], ");
		stringBuilder.Append("[nm_informacao_especifica_05_maq_03] as [nomeInformacaoEspecifica05Recurso03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_05_maq_03] as [valorInformacaoEspecifica05Recurso03], ");
		stringBuilder.Append("[nm_informacao_adicional_01] as [nomeInformacaoAdicional01], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_01] as [valorInformacaoAdicional01], ");
		stringBuilder.Append("[nm_informacao_adicional_02] as [nomeInformacaoAdicional02], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_02] as [valorInformacaoAdicional02], ");
		stringBuilder.Append("[nm_informacao_adicional_03] as [nomeInformacaoAdicional03], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_03] as [valorInformacaoAdicional03], ");
		stringBuilder.Append("[nm_informacao_adicional_04] as [nomeInformacaoAdicional04], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_04] as [valorInformacaoAdicional04], ");
		stringBuilder.Append("[nm_informacao_adicional_05] as [nomeInformacaoAdicional05], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_05] as [valorInformacaoAdicional05], ");
		stringBuilder.Append("[nm_informacao_adicional_06] as [nomeInformacaoAdicional06], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_06] as [valorInformacaoAdicional06], ");
		stringBuilder.Append("[ds_sequencia_trabalho] as [descricaoSequenciaTrabalho], ");
		stringBuilder.Append("[ds_observacoes] as [observacoes], ");
		stringBuilder.Append("[cd_epi_01] as [codigoEPI01], ");
		stringBuilder.Append("[cd_epi_02] as [codigoEPI02], ");
		stringBuilder.Append("[cd_epi_03] as [codigoEPI03], ");
		stringBuilder.Append("[cd_epi_04] as [codigoEPI04], ");
		stringBuilder.Append("[cd_epi_05] as [codigoEPI05], ");
		stringBuilder.Append("[cd_epi_06] as [codigoEPI06], ");
		stringBuilder.Append("[cd_epi_07] as [codigoEPI07], ");
		stringBuilder.Append("[cd_epi_08] as [codigoEPI08]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacao] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProcessoOperacao> ObterTodosTecnicoEngenhariaProcessoOperacao()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProcessoOperacao> list = new List<MapTableTecnicoEngenhariaProcessoOperacao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProcessoOperacao> ObterTodosTecnicoEngenhariaProcessoOperacao(int idProcesso)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_processo] = @id_processo");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_processo", idProcesso));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProcessoOperacao> list2 = new List<MapTableTecnicoEngenhariaProcessoOperacao>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProcessoOperacao ObterTecnicoEngenhariaProcessoOperacao(int id)
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

	public MapTableTecnicoEngenhariaProcessoOperacao ObterTecnicoEngenhariaProcessoOperacao(MapTableTecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoOperacao.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProcessoOperacao(MapTableTecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacao] (");
		stringBuilder.Append("[cd_revisao_operacao], ");
		stringBuilder.Append("[dt_criacao_operacao], ");
		stringBuilder.Append("[dt_atualizacao_operacao], ");
		stringBuilder.Append("[cd_funcionario_criador], ");
		stringBuilder.Append("[cd_funcionario_atualizador], ");
		stringBuilder.Append("[ic_aprovado], ");
		stringBuilder.Append("[cd_funcionario_aprovador], ");
		stringBuilder.Append("[nm_usuario_conectado_modificacao], ");
		stringBuilder.Append("[nm_usuario_conectado_aprovacao], ");
		stringBuilder.Append("[id_processo], ");
		stringBuilder.Append("[cd_tipo_processo], ");
		stringBuilder.Append("[cd_tipo_recurso], ");
		stringBuilder.Append("[cd_recurso], ");
		stringBuilder.Append("[tp_setup], ");
		stringBuilder.Append("[tp_producao], ");
		stringBuilder.Append("[tp_controle], ");
		stringBuilder.Append("[tp_transito], ");
		stringBuilder.Append("[cd_unidade_tempo], ");
		stringBuilder.Append("[vl_rendimento_minimo], ");
		stringBuilder.Append("[vl_rendimento_maximo], ");
		stringBuilder.Append("[qd_operador], ");
		stringBuilder.Append("[cd_tipo_operador], ");
		stringBuilder.Append("[cd_tipo_sc], ");
		stringBuilder.Append("[cd_sc], ");
		stringBuilder.Append("[tp_sc], ");
		stringBuilder.Append("[vl_teorico], ");
		stringBuilder.Append("[vl_necessidade], ");
		stringBuilder.Append("[cd_unidade_sc], ");
		stringBuilder.Append("[im_operacao], ");
		stringBuilder.Append("[nm_informacao_especifica_01_maq_01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_01_maq_01], ");
		stringBuilder.Append("[nm_informacao_especifica_02_maq_01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_02_maq_01], ");
		stringBuilder.Append("[nm_informacao_especifica_03_maq_01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_03_maq_01], ");
		stringBuilder.Append("[nm_informacao_especifica_04_maq_01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_04_maq_01], ");
		stringBuilder.Append("[nm_informacao_especifica_05_maq_01], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_05_maq_01], ");
		stringBuilder.Append("[nm_informacao_especifica_01_maq_02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_01_maq_02], ");
		stringBuilder.Append("[nm_informacao_especifica_02_maq_02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_02_maq_02], ");
		stringBuilder.Append("[nm_informacao_especifica_03_maq_02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_03_maq_02], ");
		stringBuilder.Append("[nm_informacao_especifica_04_maq_02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_04_maq_02], ");
		stringBuilder.Append("[nm_informacao_especifica_05_maq_02], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_05_maq_02], ");
		stringBuilder.Append("[nm_informacao_especifica_01_maq_03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_01_maq_03], ");
		stringBuilder.Append("[nm_informacao_especifica_02_maq_03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_02_maq_03], ");
		stringBuilder.Append("[nm_informacao_especifica_03_maq_03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_03_maq_03], ");
		stringBuilder.Append("[nm_informacao_especifica_04_maq_03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_04_maq_03], ");
		stringBuilder.Append("[nm_informacao_especifica_05_maq_03], ");
		stringBuilder.Append("[nm_valor_informacao_especifica_05_maq_03], ");
		stringBuilder.Append("[nm_informacao_adicional_01], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_01], ");
		stringBuilder.Append("[nm_informacao_adicional_02], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_02], ");
		stringBuilder.Append("[nm_informacao_adicional_03], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_03], ");
		stringBuilder.Append("[nm_informacao_adicional_04], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_04], ");
		stringBuilder.Append("[nm_informacao_adicional_05], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_05], ");
		stringBuilder.Append("[nm_informacao_adicional_06], ");
		stringBuilder.Append("[nm_valor_informacao_adicional_06], ");
		stringBuilder.Append("[ds_sequencia_trabalho], ");
		stringBuilder.Append("[ds_observacoes], ");
		stringBuilder.Append("[cd_epi_01], ");
		stringBuilder.Append("[cd_epi_02], ");
		stringBuilder.Append("[cd_epi_03], ");
		stringBuilder.Append("[cd_epi_04], ");
		stringBuilder.Append("[cd_epi_05], ");
		stringBuilder.Append("[cd_epi_06], ");
		stringBuilder.Append("[cd_epi_07], ");
		stringBuilder.Append("[cd_epi_08]) Values (@cd_revisao_operacao,@dt_criacao_operacao,@dt_atualizacao_operacao,@cd_funcionario_criador,@cd_funcionario_atualizador,@ic_aprovado,@cd_funcionario_aprovador,@nm_usuario_conectado_modificacao,@nm_usuario_conectado_aprovacao,@id_processo,@cd_tipo_processo,@cd_tipo_recurso,@cd_recurso,@tp_setup,@tp_producao,@tp_controle,@tp_transito,@cd_unidade_tempo,@vl_rendimento_minimo,@vl_rendimento_maximo,@qd_operador,@cd_tipo_operador,@cd_tipo_sc,@cd_sc,@tp_sc,@vl_teorico,@vl_necessidade,@cd_unidade_sc,@im_operacao,@nm_informacao_especifica_01_maq_01,@nm_valor_informacao_especifica_01_maq_01,@nm_informacao_especifica_02_maq_01,@nm_valor_informacao_especifica_02_maq_01,@nm_informacao_especifica_03_maq_01,@nm_valor_informacao_especifica_03_maq_01,@nm_informacao_especifica_04_maq_01,@nm_valor_informacao_especifica_04_maq_01,@nm_informacao_especifica_05_maq_01,@nm_valor_informacao_especifica_05_maq_01,@nm_informacao_especifica_01_maq_02,@nm_valor_informacao_especifica_01_maq_02,@nm_informacao_especifica_02_maq_02,@nm_valor_informacao_especifica_02_maq_02,@nm_informacao_especifica_03_maq_02,@nm_valor_informacao_especifica_03_maq_02,@nm_informacao_especifica_04_maq_02,@nm_valor_informacao_especifica_04_maq_02,@nm_informacao_especifica_05_maq_02,@nm_valor_informacao_especifica_05_maq_02,@nm_informacao_especifica_01_maq_03,@nm_valor_informacao_especifica_01_maq_03,@nm_informacao_especifica_02_maq_03,@nm_valor_informacao_especifica_02_maq_03,@nm_informacao_especifica_03_maq_03,@nm_valor_informacao_especifica_03_maq_03,@nm_informacao_especifica_04_maq_03,@nm_valor_informacao_especifica_04_maq_03,@nm_informacao_especifica_05_maq_03,@nm_valor_informacao_especifica_05_maq_03,@nm_informacao_adicional_01,@nm_valor_informacao_adicional_01,@nm_informacao_adicional_02,@nm_valor_informacao_adicional_02,@nm_informacao_adicional_03,@nm_valor_informacao_adicional_03,@nm_informacao_adicional_04,@nm_valor_informacao_adicional_04,@nm_informacao_adicional_05,@nm_valor_informacao_adicional_05,@nm_informacao_adicional_06,@nm_valor_informacao_adicional_06,@ds_sequencia_trabalho,@ds_observacoes,@cd_epi_01,@cd_epi_02,@cd_epi_03,@cd_epi_04,@cd_epi_05,@cd_epi_06,@cd_epi_07,@cd_epi_08) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_revisao_operacao", TecnicoEngenhariaProcessoOperacao.revisaoOperacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_criacao_operacao", TecnicoEngenhariaProcessoOperacao.dataCriacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_atualizacao_operacao", TecnicoEngenhariaProcessoOperacao.dataAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_criador", TecnicoEngenhariaProcessoOperacao.codigoFuncionarioCriador));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_atualizador", TecnicoEngenhariaProcessoOperacao.codigoFuncionarioAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_aprovado", TecnicoEngenhariaProcessoOperacao.isAprovado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario_aprovador", TecnicoEngenhariaProcessoOperacao.codigoFuncionarioAprovacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario_conectado_modificacao", TecnicoEngenhariaProcessoOperacao.nomeUsuarioConectado));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario_conectado_aprovacao", TecnicoEngenhariaProcessoOperacao.nomeUsuarioConectadoAprovacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_processo", TecnicoEngenhariaProcessoOperacao.idProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_processo", TecnicoEngenhariaProcessoOperacao.codigoTipoProcesso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_recurso", TecnicoEngenhariaProcessoOperacao.codigoTipoRecurso));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_recurso", TecnicoEngenhariaProcessoOperacao.codigoRecurso));
		list.Add(BaseDadosERP.ObterNovoParametro("@tp_setup", TecnicoEngenhariaProcessoOperacao.tempoSetUp));
		list.Add(BaseDadosERP.ObterNovoParametro("@tp_producao", TecnicoEngenhariaProcessoOperacao.tempoProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("@tp_controle", TecnicoEngenhariaProcessoOperacao.tempoControle));
		list.Add(BaseDadosERP.ObterNovoParametro("@tp_transito", TecnicoEngenhariaProcessoOperacao.tempoTransito));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade_tempo", TecnicoEngenhariaProcessoOperacao.codigoUnidadeTempo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_rendimento_minimo", TecnicoEngenhariaProcessoOperacao.valorRendimentoMinimo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_rendimento_maximo", TecnicoEngenhariaProcessoOperacao.valorRendimentoMaximo));
		list.Add(BaseDadosERP.ObterNovoParametro("@qd_operador", TecnicoEngenhariaProcessoOperacao.quantidadeOperador));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_operador", TecnicoEngenhariaProcessoOperacao.codigoTipoOperador));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_sc", TecnicoEngenhariaProcessoOperacao.codigoTipoSubContratacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_sc", TecnicoEngenhariaProcessoOperacao.codigoEntidadeSubContratada));
		list.Add(BaseDadosERP.ObterNovoParametro("@tp_sc", TecnicoEngenhariaProcessoOperacao.tempoSubContratacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_teorico", TecnicoEngenhariaProcessoOperacao.valorTeorico));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_necessidade", TecnicoEngenhariaProcessoOperacao.valorNecessidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade_sc", TecnicoEngenhariaProcessoOperacao.codigoUnidadeSubContratacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@im_operacao", TecnicoEngenhariaProcessoOperacao.imagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_01_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica01Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_01_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica01Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_02_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica02Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_02_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica02Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_03_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica03Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_03_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica03Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_04_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica04Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_04_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica04Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_05_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica05Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_05_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica05Recurso01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_01_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica01Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_01_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica01Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_02_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica02Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_02_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica02Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_03_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica03Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_03_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica03Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_04_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica04Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_04_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica04Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_05_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica05Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_05_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica05Recurso02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_01_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica01Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_01_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica01Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_02_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica02Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_02_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica02Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_03_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica03Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_03_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica03Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_04_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica04Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_04_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica04Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_especifica_05_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica05Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_especifica_05_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica05Recurso03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_adicional_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_adicional_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_adicional_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_adicional_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_adicional_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_adicional_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_adicional_04", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional04));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_adicional_04", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional04));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_adicional_05", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional05));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_adicional_05", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional05));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_informacao_adicional_06", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional06));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_valor_informacao_adicional_06", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional06));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_sequencia_trabalho", TecnicoEngenhariaProcessoOperacao.descricaoSequenciaTrabalho));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_observacoes", TecnicoEngenhariaProcessoOperacao.observacoes));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_01", TecnicoEngenhariaProcessoOperacao.codigoEPI01));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_02", TecnicoEngenhariaProcessoOperacao.codigoEPI02));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_03", TecnicoEngenhariaProcessoOperacao.codigoEPI03));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_04", TecnicoEngenhariaProcessoOperacao.codigoEPI04));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_05", TecnicoEngenhariaProcessoOperacao.codigoEPI05));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_06", TecnicoEngenhariaProcessoOperacao.codigoEPI06));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_07", TecnicoEngenhariaProcessoOperacao.codigoEPI07));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_epi_08", TecnicoEngenhariaProcessoOperacao.codigoEPI08));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProcessoOperacao(MapTableTecnicoEngenhariaProcessoOperacao TecnicoEngenhariaProcessoOperacao, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacao] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RevisaoOperacao", "cd_revisao_operacao", TecnicoEngenhariaProcessoOperacao.revisaoOperacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCriacao", "dt_criacao_operacao", TecnicoEngenhariaProcessoOperacao.dataCriacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao_operacao", TecnicoEngenhariaProcessoOperacao.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioCriador", "cd_funcionario_criador", TecnicoEngenhariaProcessoOperacao.codigoFuncionarioCriador, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioAtualizacao", "cd_funcionario_atualizador", TecnicoEngenhariaProcessoOperacao.codigoFuncionarioAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsAprovado", "ic_aprovado", TecnicoEngenhariaProcessoOperacao.isAprovado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioAprovacao", "cd_funcionario_aprovador", TecnicoEngenhariaProcessoOperacao.codigoFuncionarioAprovacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeUsuarioConectado", "nm_usuario_conectado_modificacao", TecnicoEngenhariaProcessoOperacao.nomeUsuarioConectado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeUsuarioConectadoAprovacao", "nm_usuario_conectado_aprovacao", TecnicoEngenhariaProcessoOperacao.nomeUsuarioConectadoAprovacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IdProcesso", "id_processo", TecnicoEngenhariaProcessoOperacao.idProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProcesso", "cd_tipo_processo", TecnicoEngenhariaProcessoOperacao.codigoTipoProcesso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoRecurso", "cd_tipo_recurso", TecnicoEngenhariaProcessoOperacao.codigoTipoRecurso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRecurso", "cd_recurso", TecnicoEngenhariaProcessoOperacao.codigoRecurso, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoSetUp", "tp_setup", TecnicoEngenhariaProcessoOperacao.tempoSetUp, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoProducao", "tp_producao", TecnicoEngenhariaProcessoOperacao.tempoProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoControle", "tp_controle", TecnicoEngenhariaProcessoOperacao.tempoControle, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoTransito", "tp_transito", TecnicoEngenhariaProcessoOperacao.tempoTransito, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeTempo", "cd_unidade_tempo", TecnicoEngenhariaProcessoOperacao.codigoUnidadeTempo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorRendimentoMinimo", "vl_rendimento_minimo", TecnicoEngenhariaProcessoOperacao.valorRendimentoMinimo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorRendimentoMaximo", "vl_rendimento_maximo", TecnicoEngenhariaProcessoOperacao.valorRendimentoMaximo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeOperador", "qd_operador", TecnicoEngenhariaProcessoOperacao.quantidadeOperador, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoOperador", "cd_tipo_operador", TecnicoEngenhariaProcessoOperacao.codigoTipoOperador, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoSubContratacao", "cd_tipo_sc", TecnicoEngenhariaProcessoOperacao.codigoTipoSubContratacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeSubContratada", "cd_sc", TecnicoEngenhariaProcessoOperacao.codigoEntidadeSubContratada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TempoSubContratacao", "tp_sc", TecnicoEngenhariaProcessoOperacao.tempoSubContratacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTeorico", "vl_teorico", TecnicoEngenhariaProcessoOperacao.valorTeorico, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorNecessidade", "vl_necessidade", TecnicoEngenhariaProcessoOperacao.valorNecessidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeSubContratacao", "cd_unidade_sc", TecnicoEngenhariaProcessoOperacao.codigoUnidadeSubContratacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Imagem", "im_operacao", TecnicoEngenhariaProcessoOperacao.imagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica01Recurso01", "nm_informacao_especifica_01_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica01Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica01Recurso01", "nm_valor_informacao_especifica_01_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica01Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica02Recurso01", "nm_informacao_especifica_02_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica02Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica02Recurso01", "nm_valor_informacao_especifica_02_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica02Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica03Recurso01", "nm_informacao_especifica_03_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica03Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica03Recurso01", "nm_valor_informacao_especifica_03_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica03Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica04Recurso01", "nm_informacao_especifica_04_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica04Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica04Recurso01", "nm_valor_informacao_especifica_04_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica04Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica05Recurso01", "nm_informacao_especifica_05_maq_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica05Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica05Recurso01", "nm_valor_informacao_especifica_05_maq_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica05Recurso01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica01Recurso02", "nm_informacao_especifica_01_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica01Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica01Recurso02", "nm_valor_informacao_especifica_01_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica01Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica02Recurso02", "nm_informacao_especifica_02_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica02Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica02Recurso02", "nm_valor_informacao_especifica_02_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica02Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica03Recurso02", "nm_informacao_especifica_03_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica03Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica03Recurso02", "nm_valor_informacao_especifica_03_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica03Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica04Recurso02", "nm_informacao_especifica_04_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica04Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica04Recurso02", "nm_valor_informacao_especifica_04_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica04Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica05Recurso02", "nm_informacao_especifica_05_maq_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica05Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica05Recurso02", "nm_valor_informacao_especifica_05_maq_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica05Recurso02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica01Recurso03", "nm_informacao_especifica_01_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica01Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica01Recurso03", "nm_valor_informacao_especifica_01_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica01Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica02Recurso03", "nm_informacao_especifica_02_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica02Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica02Recurso03", "nm_valor_informacao_especifica_02_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica02Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica03Recurso03", "nm_informacao_especifica_03_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica03Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica03Recurso03", "nm_valor_informacao_especifica_03_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica03Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica04Recurso03", "nm_informacao_especifica_04_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica04Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica04Recurso03", "nm_valor_informacao_especifica_04_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica04Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoEspecifica05Recurso03", "nm_informacao_especifica_05_maq_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoEspecifica05Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoEspecifica05Recurso03", "nm_valor_informacao_especifica_05_maq_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoEspecifica05Recurso03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoAdicional01", "nm_informacao_adicional_01", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoAdicional01", "nm_valor_informacao_adicional_01", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoAdicional02", "nm_informacao_adicional_02", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoAdicional02", "nm_valor_informacao_adicional_02", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoAdicional03", "nm_informacao_adicional_03", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoAdicional03", "nm_valor_informacao_adicional_03", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoAdicional04", "nm_informacao_adicional_04", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional04, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoAdicional04", "nm_valor_informacao_adicional_04", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional04, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoAdicional05", "nm_informacao_adicional_05", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional05, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoAdicional05", "nm_valor_informacao_adicional_05", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional05, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeInformacaoAdicional06", "nm_informacao_adicional_06", TecnicoEngenhariaProcessoOperacao.nomeInformacaoAdicional06, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorInformacaoAdicional06", "nm_valor_informacao_adicional_06", TecnicoEngenhariaProcessoOperacao.valorInformacaoAdicional06, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoSequenciaTrabalho", "ds_sequencia_trabalho", TecnicoEngenhariaProcessoOperacao.descricaoSequenciaTrabalho, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Observacoes", "ds_observacoes", TecnicoEngenhariaProcessoOperacao.observacoes, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI01", "cd_epi_01", TecnicoEngenhariaProcessoOperacao.codigoEPI01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI02", "cd_epi_02", TecnicoEngenhariaProcessoOperacao.codigoEPI02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI03", "cd_epi_03", TecnicoEngenhariaProcessoOperacao.codigoEPI03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI04", "cd_epi_04", TecnicoEngenhariaProcessoOperacao.codigoEPI04, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI05", "cd_epi_05", TecnicoEngenhariaProcessoOperacao.codigoEPI05, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI06", "cd_epi_06", TecnicoEngenhariaProcessoOperacao.codigoEPI06, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI07", "cd_epi_07", TecnicoEngenhariaProcessoOperacao.codigoEPI07, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEPI08", "cd_epi_08", TecnicoEngenhariaProcessoOperacao.codigoEPI08, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProcessoOperacao.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProcessoOperacao(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProcessoOperacao] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
