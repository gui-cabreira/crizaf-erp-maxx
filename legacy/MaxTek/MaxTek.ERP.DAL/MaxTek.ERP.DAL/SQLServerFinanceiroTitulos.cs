using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerFinanceiroTitulos : IFinanceiroTitulos
{
	private MapTableFinanceiroTitulos MapearClasse(DataRow row)
	{
		MapTableFinanceiroTitulos result = default(MapTableFinanceiroTitulos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.dataMovimento = BaseDadosERP.ObterDbValor<DateTime>(row["dataMovimento"]);
			result.dataEmissao = BaseDadosERP.ObterDbValor<DateTime>(row["dataEmissao"]);
			result.codigoTipo = BaseDadosERP.ObterDbValor<int>(row["codigoTipo"]);
			result.isPrevisao = BaseDadosERP.ObterDbValor<bool>(row["isPrevisao"]);
			result.descricaoTitulo = BaseDadosERP.ObterDbValor<string>(row["descricaoTitulo"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.documento = BaseDadosERP.ObterDbValor<string>(row["documento"]);
			result.sequenciaDe = BaseDadosERP.ObterDbValor<int>(row["sequenciaDe"]);
			result.sequenciaAte = BaseDadosERP.ObterDbValor<int>(row["sequenciaAte"]);
			result.dataVencimento = BaseDadosERP.ObterDbValor<DateTime>(row["dataVencimento"]);
			result.dataVencimentoNegociado = BaseDadosERP.ObterDbValor<DateTime>(row["dataVencimentoNegociado"]);
			result.valorTitulo = BaseDadosERP.ObterDbValor<decimal>(row["valorTitulo"]);
			result.valorTituloNegociado = BaseDadosERP.ObterDbValor<decimal>(row["valorTituloNegociado"]);
			result.competencia = BaseDadosERP.ObterDbValor<string>(row["competencia"]);
			result.naturezaOperacao = BaseDadosERP.ObterDbValor<string>(row["naturezaOperacao"]);
			result.codigoContaContabil = BaseDadosERP.ObterDbValor<int>(row["codigoContaContabil"]);
			result.codigoBanco = BaseDadosERP.ObterDbValor<int>(row["codigoBanco"]);
			result.percentualJuros = BaseDadosERP.ObterDbValor<decimal>(row["percentualJuros"]);
			result.percentualDesconto = BaseDadosERP.ObterDbValor<decimal>(row["percentualDesconto"]);
			result.valorJuros = BaseDadosERP.ObterDbValor<decimal>(row["valorJuros"]);
			result.valorDesconto = BaseDadosERP.ObterDbValor<decimal>(row["valorDesconto"]);
			result.valorPago = BaseDadosERP.ObterDbValor<decimal>(row["valorPago"]);
			result.dataPagamento = BaseDadosERP.ObterDbValor<DateTime>(row["dataPagamento"]);
			result.isPago = BaseDadosERP.ObterDbValor<bool>(row["isPago"]);
			result.codigoMeioPagamento = BaseDadosERP.ObterDbValor<int>(row["codigoMeioPagamento"]);
			result.percentualPisCofins = BaseDadosERP.ObterDbValor<decimal>(row["percentualPisCofins"]);
			result.valorPisCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorPisCofins"]);
			result.dataCadastramento = BaseDadosERP.ObterDbValor<DateTime>(row["dataCadastramento"]);
			result.dataAtualizacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoFuncionarioCadastramento = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioCadastramento"]);
			result.codigoFuncionarioAtualizacao = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionarioAtualizacao"]);
			result.codigoTipoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoTipoEntidade"]);
			result.codigoOrigem = BaseDadosERP.ObterDbValor<int>(row["codigoOrigem"]);
			result.codigoCentroCustos = BaseDadosERP.ObterDbValor<int>(row["codigoCentroCustos"]);
			result.codigoSubCentroCustos = BaseDadosERP.ObterDbValor<int>(row["codigoSubCentroCustos"]);
			result.comentario = BaseDadosERP.ObterDbValor<string>(row["comentario"]);
			result.codigoTipoDocumentoOrigem = BaseDadosERP.ObterDbValor<int>(row["codigoTipoDocumentoOrigem"]);
			result.codigoDocumentoOrigem = BaseDadosERP.ObterDbValor<int>(row["codigoDocumentoOrigem"]);
			result.codigoDocumentoOrigemItem = BaseDadosERP.ObterDbValor<int>(row["codigoDocumentoOrigemItem"]);
			result.razaoSocial = BaseDadosERP.ObterDbValor<string>(row["razaoSocial"]);
			result.cnpj = BaseDadosERP.ObterDbValor<string>(row["cnpj"]);
			result.valorDocumentoOrigem = BaseDadosERP.ObterDbValor<decimal>(row["valorDocumentoOrigem"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[dt_movimento] as [dataMovimento], ");
		stringBuilder.Append("[dt_emissao] as [dataEmissao], ");
		stringBuilder.Append("[cd_tipo] as [codigoTipo], ");
		stringBuilder.Append("[ic_previsao] as [isPrevisao], ");
		stringBuilder.Append("[ds_titulo] as [descricaoTitulo], ");
		stringBuilder.Append("[cd_cliente] as [codigoEntidade], ");
		stringBuilder.Append("[nm_documento] as [documento], ");
		stringBuilder.Append("[vl_sequencia_de] as [sequenciaDe], ");
		stringBuilder.Append("[vl_sequencia_ate] as [sequenciaAte], ");
		stringBuilder.Append("[dt_vencimento] as [dataVencimento], ");
		stringBuilder.Append("[dt_vencimento_negociado] as [dataVencimentoNegociado], ");
		stringBuilder.Append("[vl_titulo] as [valorTitulo], ");
		stringBuilder.Append("[vl_titulo_negociado] as [valorTituloNegociado], ");
		stringBuilder.Append("[nm_competencia] as [competencia], ");
		stringBuilder.Append("[nm_natureza_documento] as [naturezaOperacao], ");
		stringBuilder.Append("[cd_financeiro] as [codigoContaContabil], ");
		stringBuilder.Append("[cd_banco] as [codigoBanco], ");
		stringBuilder.Append("[pc_juros] as [percentualJuros], ");
		stringBuilder.Append("[pc_desconto] as [percentualDesconto], ");
		stringBuilder.Append("[vl_juros] as [valorJuros], ");
		stringBuilder.Append("[vl_desconto] as [valorDesconto], ");
		stringBuilder.Append("[vl_pago] as [valorPago], ");
		stringBuilder.Append("[dt_pagamento] as [dataPagamento], ");
		stringBuilder.Append("[ic_pago] as [isPago], ");
		stringBuilder.Append("[cd_meio_pagamento] as [codigoMeioPagamento], ");
		stringBuilder.Append("[pc_pis_cofins] as [percentualPisCofins], ");
		stringBuilder.Append("[vl_pis_cofins] as [valorPisCofins], ");
		stringBuilder.Append("[dt_criacao] as [dataCadastramento], ");
		stringBuilder.Append("[dt_atualizacao] as [dataAtualizacao], ");
		stringBuilder.Append("[cd_criador] as [codigoFuncionarioCadastramento], ");
		stringBuilder.Append("[cd_atualizador] as [codigoFuncionarioAtualizacao], ");
		stringBuilder.Append("[cd_tipo_entidade] as [codigoTipoEntidade], ");
		stringBuilder.Append("[cd_origem] as [codigoOrigem], ");
		stringBuilder.Append("[cd_centro_custos] as [codigoCentroCustos], ");
		stringBuilder.Append("[cd_sub_centro_custos] as [codigoSubCentroCustos], ");
		stringBuilder.Append("[ds_comentario] as [comentario], ");
		stringBuilder.Append("[cd_documento_origem_tipo] as [codigoTipoDocumentoOrigem], ");
		stringBuilder.Append("[cd_documento_origem] as [codigoDocumentoOrigem], ");
		stringBuilder.Append("[cd_documento_origem_item] as [codigoDocumentoOrigemItem], ");
		stringBuilder.Append("[nm_entidade] as [razaoSocial], ");
		stringBuilder.Append("[nm_cnpj] as [cnpj], ");
		stringBuilder.Append("[vl_documento_origem] as [valorDocumentoOrigem]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Titulos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableFinanceiroTitulos> ObterTodosFinanceiroTitulos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append(" order by [dt_vencimento_negociado], [cd_tipo] desc");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableFinanceiroTitulos> list = new List<MapTableFinanceiroTitulos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableFinanceiroTitulos ObterFinanceiroTitulos(int id)
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

	public MapTableFinanceiroTitulos ObterFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", FinanceiroTitulos.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Titulos] (");
		stringBuilder.Append("[dt_movimento], ");
		stringBuilder.Append("[dt_emissao], ");
		stringBuilder.Append("[cd_tipo], ");
		stringBuilder.Append("[ic_previsao], ");
		stringBuilder.Append("[ds_titulo], ");
		stringBuilder.Append("[cd_cliente], ");
		stringBuilder.Append("[nm_documento], ");
		stringBuilder.Append("[vl_sequencia_de], ");
		stringBuilder.Append("[vl_sequencia_ate], ");
		stringBuilder.Append("[dt_vencimento], ");
		stringBuilder.Append("[dt_vencimento_negociado], ");
		stringBuilder.Append("[vl_titulo], ");
		stringBuilder.Append("[vl_titulo_negociado], ");
		stringBuilder.Append("[nm_competencia], ");
		stringBuilder.Append("[nm_natureza_documento], ");
		stringBuilder.Append("[cd_financeiro], ");
		stringBuilder.Append("[cd_banco], ");
		stringBuilder.Append("[pc_juros], ");
		stringBuilder.Append("[pc_desconto], ");
		stringBuilder.Append("[vl_juros], ");
		stringBuilder.Append("[vl_desconto], ");
		stringBuilder.Append("[vl_pago], ");
		stringBuilder.Append("[dt_pagamento], ");
		stringBuilder.Append("[ic_pago], ");
		stringBuilder.Append("[cd_meio_pagamento], ");
		stringBuilder.Append("[pc_pis_cofins], ");
		stringBuilder.Append("[vl_pis_cofins], ");
		stringBuilder.Append("[dt_criacao], ");
		stringBuilder.Append("[dt_atualizacao], ");
		stringBuilder.Append("[cd_criador], ");
		stringBuilder.Append("[cd_atualizador], ");
		stringBuilder.Append("[cd_tipo_entidade], ");
		stringBuilder.Append("[cd_origem], ");
		stringBuilder.Append("[cd_centro_custos], ");
		stringBuilder.Append("[cd_sub_centro_custos], ");
		stringBuilder.Append("[ds_comentario], ");
		stringBuilder.Append("[cd_documento_origem_tipo], ");
		stringBuilder.Append("[cd_documento_origem], ");
		stringBuilder.Append("[cd_documento_origem_item], ");
		stringBuilder.Append("[nm_entidade], ");
		stringBuilder.Append("[nm_cnpj], ");
		stringBuilder.Append("[vl_documento_origem]) Values (@dt_movimento,@dt_emissao,@cd_tipo,@ic_previsao,@ds_titulo,@cd_cliente,@nm_documento,@vl_sequencia_de,@vl_sequencia_ate,@dt_vencimento,@dt_vencimento_negociado,@vl_titulo,@vl_titulo_negociado,@nm_competencia,@nm_natureza_documento,@cd_financeiro,@cd_banco,@pc_juros,@pc_desconto,@vl_juros,@vl_desconto,@vl_pago,@dt_pagamento,@ic_pago,@cd_meio_pagamento,@pc_pis_cofins,@vl_pis_cofins,@dt_criacao,@dt_atualizacao,@cd_criador,@cd_atualizador,@cd_tipo_entidade,@cd_origem,@cd_centro_custos,@cd_sub_centro_custos,@ds_comentario,@cd_documento_origem_tipo,@cd_documento_origem,@cd_documento_origem_item,@nm_entidade,@nm_cnpj,@vl_documento_origem) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_movimento", FinanceiroTitulos.dataMovimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_emissao", FinanceiroTitulos.dataEmissao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo", FinanceiroTitulos.codigoTipo));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_previsao", FinanceiroTitulos.isPrevisao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_titulo", FinanceiroTitulos.descricaoTitulo));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cliente", FinanceiroTitulos.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_documento", FinanceiroTitulos.documento));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_sequencia_de", FinanceiroTitulos.sequenciaDe));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_sequencia_ate", FinanceiroTitulos.sequenciaAte));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_vencimento", FinanceiroTitulos.dataVencimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_vencimento_negociado", FinanceiroTitulos.dataVencimentoNegociado));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_titulo", FinanceiroTitulos.valorTitulo));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_titulo_negociado", FinanceiroTitulos.valorTituloNegociado));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_competencia", FinanceiroTitulos.competencia));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_natureza_documento", FinanceiroTitulos.naturezaOperacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_financeiro", FinanceiroTitulos.codigoContaContabil));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_banco", FinanceiroTitulos.codigoBanco));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_juros", FinanceiroTitulos.percentualJuros));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_desconto", FinanceiroTitulos.percentualDesconto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_juros", FinanceiroTitulos.valorJuros));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_desconto", FinanceiroTitulos.valorDesconto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_pago", FinanceiroTitulos.valorPago));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_pagamento", FinanceiroTitulos.dataPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_pago", FinanceiroTitulos.isPago));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_meio_pagamento", FinanceiroTitulos.codigoMeioPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_pis_cofins", FinanceiroTitulos.percentualPisCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_pis_cofins", FinanceiroTitulos.valorPisCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_criacao", FinanceiroTitulos.dataCadastramento));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_atualizacao", FinanceiroTitulos.dataAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_criador", FinanceiroTitulos.codigoFuncionarioCadastramento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_atualizador", FinanceiroTitulos.codigoFuncionarioAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_entidade", FinanceiroTitulos.codigoTipoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_origem", FinanceiroTitulos.codigoOrigem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_centro_custos", FinanceiroTitulos.codigoCentroCustos));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_sub_centro_custos", FinanceiroTitulos.codigoSubCentroCustos));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_comentario", FinanceiroTitulos.comentario));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_documento_origem_tipo", FinanceiroTitulos.codigoTipoDocumentoOrigem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_documento_origem", FinanceiroTitulos.codigoDocumentoOrigem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_documento_origem_item", FinanceiroTitulos.codigoDocumentoOrigemItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_entidade", FinanceiroTitulos.razaoSocial));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cnpj", FinanceiroTitulos.cnpj));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_documento_origem", FinanceiroTitulos.valorDocumentoOrigem));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Titulos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataMovimento", "dt_movimento", FinanceiroTitulos.dataMovimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEmissao", "dt_emissao", FinanceiroTitulos.dataEmissao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipo", "cd_tipo", FinanceiroTitulos.codigoTipo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsPrevisao", "ic_previsao", FinanceiroTitulos.isPrevisao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoTitulo", "ds_titulo", FinanceiroTitulos.descricaoTitulo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "cd_cliente", FinanceiroTitulos.codigoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Documento", "nm_documento", FinanceiroTitulos.documento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SequenciaDe", "vl_sequencia_de", FinanceiroTitulos.sequenciaDe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SequenciaAte", "vl_sequencia_ate", FinanceiroTitulos.sequenciaAte, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataVencimento", "dt_vencimento", FinanceiroTitulos.dataVencimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataVencimentoNegociado", "dt_vencimento_negociado", FinanceiroTitulos.dataVencimentoNegociado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTitulo", "vl_titulo", FinanceiroTitulos.valorTitulo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTituloNegociado", "vl_titulo_negociado", FinanceiroTitulos.valorTituloNegociado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Competencia", "nm_competencia", FinanceiroTitulos.competencia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NaturezaOperacao", "nm_natureza_documento", FinanceiroTitulos.naturezaOperacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "cd_financeiro", FinanceiroTitulos.codigoContaContabil, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoBanco", "cd_banco", FinanceiroTitulos.codigoBanco, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualJuros", "pc_juros", FinanceiroTitulos.percentualJuros, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualDesconto", "pc_desconto", FinanceiroTitulos.percentualDesconto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorJuros", "vl_juros", FinanceiroTitulos.valorJuros, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDesconto", "vl_desconto", FinanceiroTitulos.valorDesconto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorPago", "vl_pago", FinanceiroTitulos.valorPago, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataPagamento", "dt_pagamento", FinanceiroTitulos.dataPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsPago", "ic_pago", FinanceiroTitulos.isPago, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoMeioPagamento", "cd_meio_pagamento", FinanceiroTitulos.codigoMeioPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualPisCofins", "pc_pis_cofins", FinanceiroTitulos.percentualPisCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorPisCofins", "vl_pis_cofins", FinanceiroTitulos.valorPisCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCadastramento", "dt_criacao", FinanceiroTitulos.dataCadastramento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", FinanceiroTitulos.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioCadastramento", "cd_criador", FinanceiroTitulos.codigoFuncionarioCadastramento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioAtualizacao", "cd_atualizador", FinanceiroTitulos.codigoFuncionarioAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoEntidade", "cd_tipo_entidade", FinanceiroTitulos.codigoTipoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoOrigem", "cd_origem", FinanceiroTitulos.codigoOrigem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCentroCustos", "cd_centro_custos", FinanceiroTitulos.codigoCentroCustos, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSubCentroCustos", "cd_sub_centro_custos", FinanceiroTitulos.codigoSubCentroCustos, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Comentario", "ds_comentario", FinanceiroTitulos.comentario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoDocumentoOrigem", "cd_documento_origem_tipo", FinanceiroTitulos.codigoTipoDocumentoOrigem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDocumentoOrigem", "cd_documento_origem", FinanceiroTitulos.codigoDocumentoOrigem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoDocumentoOrigemItem", "cd_documento_origem_item", FinanceiroTitulos.codigoDocumentoOrigemItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RazaoSocial", "nm_entidade", FinanceiroTitulos.razaoSocial, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cnpj", "nm_cnpj", FinanceiroTitulos.cnpj, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDocumentoOrigem", "vl_documento_origem", FinanceiroTitulos.valorDocumentoOrigem, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", FinanceiroTitulos.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirFinanceiroTitulos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Financeiro].[Titulos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
