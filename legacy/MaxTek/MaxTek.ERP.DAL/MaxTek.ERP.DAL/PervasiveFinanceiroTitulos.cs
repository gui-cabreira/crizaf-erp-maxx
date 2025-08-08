using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveFinanceiroTitulos : IFinanceiroTitulos
{
	private MapTableFinanceiroTitulos MapearClasse(DataRow row)
	{
		MapTableFinanceiroTitulos result = default(MapTableFinanceiroTitulos);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.dataMovimento = BaseDadosGPS.ObterDbValor<DateTime>(row["dataMovimento"]);
			result.dataEmissao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataEmissao"]);
			result.codigoTipo = BaseDadosGPS.ObterDbValor<int>(row["codigoTipo"]);
			result.isPrevisao = BaseDadosGPS.ObterDbValor<bool>(row["isPrevisao"]);
			result.descricaoTitulo = BaseDadosGPS.ObterDbValor<string>(row["descricaoTitulo"]);
			result.codigoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidade"]);
			result.documento = BaseDadosGPS.ObterDbValor<string>(row["documento"]);
			result.sequenciaDe = BaseDadosGPS.ObterDbValor<int>(row["sequenciaDe"]);
			result.sequenciaAte = BaseDadosGPS.ObterDbValor<int>(row["sequenciaAte"]);
			result.dataVencimento = BaseDadosGPS.ObterDbValor<DateTime>(row["dataVencimento"]);
			result.dataVencimentoNegociado = BaseDadosGPS.ObterDbValor<DateTime>(row["dataVencimentoNegociado"]);
			result.valorTitulo = BaseDadosGPS.ObterDbValor<decimal>(row["valorTitulo"]);
			result.valorTituloNegociado = BaseDadosGPS.ObterDbValor<decimal>(row["valorTituloNegociado"]);
			result.competencia = BaseDadosGPS.ObterDbValor<string>(row["competencia"]);
			result.naturezaOperacao = BaseDadosGPS.ObterDbValor<string>(row["naturezaOperacao"]);
			result.codigoContaContabil = BaseDadosGPS.ObterDbValor<int>(row["codigoContaContabil"]);
			result.codigoBanco = BaseDadosGPS.ObterDbValor<int>(row["codigoBanco"]);
			result.percentualJuros = BaseDadosGPS.ObterDbValor<decimal>(row["percentualJuros"]);
			result.percentualDesconto = BaseDadosGPS.ObterDbValor<decimal>(row["percentualDesconto"]);
			result.valorJuros = BaseDadosGPS.ObterDbValor<decimal>(row["valorJuros"]);
			result.valorDesconto = BaseDadosGPS.ObterDbValor<decimal>(row["valorDesconto"]);
			result.valorPago = BaseDadosGPS.ObterDbValor<decimal>(row["valorPago"]);
			result.dataPagamento = BaseDadosGPS.ObterDbValor<DateTime>(row["dataPagamento"]);
			result.isPago = BaseDadosGPS.ObterDbValor<bool>(row["isPago"]);
			result.codigoMeioPagamento = BaseDadosGPS.ObterDbValor<int>(row["codigoMeioPagamento"]);
			result.percentualPisCofins = BaseDadosGPS.ObterDbValor<decimal>(row["percentualPisCofins"]);
			result.valorPisCofins = BaseDadosGPS.ObterDbValor<decimal>(row["valorPisCofins"]);
			result.dataCadastramento = BaseDadosGPS.ObterDbValor<DateTime>(row["dataCadastramento"]);
			result.dataAtualizacao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoFuncionarioCadastramento = BaseDadosGPS.ObterDbValor<int>(row["codigoFuncionarioCadastramento"]);
			result.codigoFuncionarioAtualizacao = BaseDadosGPS.ObterDbValor<int>(row["codigoFuncionarioAtualizacao"]);
			result.codigoTipoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoEntidade"]);
			result.codigoOrigem = BaseDadosGPS.ObterDbValor<int>(row["codigoOrigem"]);
			result.codigoCentroCustos = BaseDadosGPS.ObterDbValor<int>(row["codigoCentroCustos"]);
			result.codigoSubCentroCustos = BaseDadosGPS.ObterDbValor<int>(row["codigoSubCentroCustos"]);
			result.comentario = BaseDadosGPS.ObterDbValor<string>(row["comentario"]);
			result.codigoTipoDocumentoOrigem = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoDocumentoOrigem"]);
			result.codigoDocumentoOrigem = BaseDadosGPS.ObterDbValor<int>(row["codigoDocumentoOrigem"]);
			result.codigoDocumentoOrigemItem = BaseDadosGPS.ObterDbValor<int>(row["codigoDocumentoOrigemItem"]);
			result.razaoSocial = BaseDadosGPS.ObterDbValor<string>(row["razaoSocial"]);
			result.cnpj = BaseDadosGPS.ObterDbValor<string>(row["cnpj"]);
			result.valorDocumentoOrigem = BaseDadosGPS.ObterDbValor<decimal>(row["valorDocumentoOrigem"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("dt_movimento as dataMovimento, ");
		stringBuilder.Append("dt_emissao as dataEmissao, ");
		stringBuilder.Append("cd_tipo as codigoTipo, ");
		stringBuilder.Append("ic_previsao as isPrevisao, ");
		stringBuilder.Append("ds_titulo as descricaoTitulo, ");
		stringBuilder.Append("cd_cliente as codigoEntidade, ");
		stringBuilder.Append("nm_documento as documento, ");
		stringBuilder.Append("vl_sequencia_de as sequenciaDe, ");
		stringBuilder.Append("vl_sequencia_ate as sequenciaAte, ");
		stringBuilder.Append("dt_vencimento as dataVencimento, ");
		stringBuilder.Append("dt_vencimento_negoci as dataVencimentoNegociado, ");
		stringBuilder.Append("vl_titulo as valorTitulo, ");
		stringBuilder.Append("vl_titulo_negociado as valorTituloNegociado, ");
		stringBuilder.Append("nm_competencia as competencia, ");
		stringBuilder.Append("nm_natureza_document as naturezaOperacao, ");
		stringBuilder.Append("cd_financeiro as codigoContaContabil, ");
		stringBuilder.Append("cd_banco as codigoBanco, ");
		stringBuilder.Append("pc_juros as percentualJuros, ");
		stringBuilder.Append("pc_desconto as percentualDesconto, ");
		stringBuilder.Append("vl_juros as valorJuros, ");
		stringBuilder.Append("vl_desconto as valorDesconto, ");
		stringBuilder.Append("vl_pago as valorPago, ");
		stringBuilder.Append("dt_pagamento as dataPagamento, ");
		stringBuilder.Append("ic_pago as isPago, ");
		stringBuilder.Append("cd_meio_pagamento as codigoMeioPagamento, ");
		stringBuilder.Append("pc_pis_cofins as percentualPisCofins, ");
		stringBuilder.Append("vl_pis_cofins as valorPisCofins, ");
		stringBuilder.Append("dt_criacao as dataCadastramento, ");
		stringBuilder.Append("dt_atualizacao as dataAtualizacao, ");
		stringBuilder.Append("cd_criador as codigoFuncionarioCadastramento, ");
		stringBuilder.Append("cd_atualizador as codigoFuncionarioAtualizacao, ");
		stringBuilder.Append("cd_tipo_entidade as codigoTipoEntidade, ");
		stringBuilder.Append("cd_origem as codigoOrigem, ");
		stringBuilder.Append("cd_centro_custos as codigoCentroCustos, ");
		stringBuilder.Append("cd_sub_centro_custos as codigoSubCentroCustos, ");
		stringBuilder.Append("ds_comentario as comentario, ");
		stringBuilder.Append("cd_documento_origem_ as codigoTipoDocumentoOrigem, ");
		stringBuilder.Append("cd_documento_origem as codigoDocumentoOrigem, ");
		stringBuilder.Append("cd_documento_origem_ as codigoDocumentoOrigemItem, ");
		stringBuilder.Append("nm_entidade as razaoSocial, ");
		stringBuilder.Append("nm_cnpj as cnpj, ");
		stringBuilder.Append("vl_documento_origem as valorDocumentoOrigem");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "Erp.FinanceiroTitulos ");
		return stringBuilder.ToString();
	}

	public IList<MapTableFinanceiroTitulos> ObterTodosFinanceiroTitulos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableFinanceiroTitulos ObterFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", FinanceiroTitulos.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "Erp.FinanceiroTitulos (");
		stringBuilder.Append("dt_movimento, ");
		stringBuilder.Append("dt_emissao, ");
		stringBuilder.Append("cd_tipo, ");
		stringBuilder.Append("ic_previsao, ");
		stringBuilder.Append("ds_titulo, ");
		stringBuilder.Append("cd_cliente, ");
		stringBuilder.Append("nm_documento, ");
		stringBuilder.Append("vl_sequencia_de, ");
		stringBuilder.Append("vl_sequencia_ate, ");
		stringBuilder.Append("dt_vencimento, ");
		stringBuilder.Append("dt_vencimento_negoci, ");
		stringBuilder.Append("vl_titulo, ");
		stringBuilder.Append("vl_titulo_negociado, ");
		stringBuilder.Append("nm_competencia, ");
		stringBuilder.Append("nm_natureza_document, ");
		stringBuilder.Append("cd_financeiro, ");
		stringBuilder.Append("cd_banco, ");
		stringBuilder.Append("pc_juros, ");
		stringBuilder.Append("pc_desconto, ");
		stringBuilder.Append("vl_juros, ");
		stringBuilder.Append("vl_desconto, ");
		stringBuilder.Append("vl_pago, ");
		stringBuilder.Append("dt_pagamento, ");
		stringBuilder.Append("ic_pago, ");
		stringBuilder.Append("cd_meio_pagamento, ");
		stringBuilder.Append("pc_pis_cofins, ");
		stringBuilder.Append("vl_pis_cofins, ");
		stringBuilder.Append("dt_criacao, ");
		stringBuilder.Append("dt_atualizacao, ");
		stringBuilder.Append("cd_criador, ");
		stringBuilder.Append("cd_atualizador, ");
		stringBuilder.Append("cd_tipo_entidade, ");
		stringBuilder.Append("cd_origem, ");
		stringBuilder.Append("cd_centro_custos, ");
		stringBuilder.Append("cd_sub_centro_custos, ");
		stringBuilder.Append("ds_comentario, ");
		stringBuilder.Append("cd_documento_origem_, ");
		stringBuilder.Append("cd_documento_origem, ");
		stringBuilder.Append("cd_documento_origem_, ");
		stringBuilder.Append("nm_entidade, ");
		stringBuilder.Append("nm_cnpj, ");
		stringBuilder.Append("vl_documento_origem) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_movimento", FinanceiroTitulos.dataMovimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_emissao", FinanceiroTitulos.dataEmissao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_tipo", FinanceiroTitulos.codigoTipo));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_previsao", FinanceiroTitulos.isPrevisao));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_titulo", FinanceiroTitulos.descricaoTitulo));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cliente", FinanceiroTitulos.codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_documento", FinanceiroTitulos.documento));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_sequencia_de", FinanceiroTitulos.sequenciaDe));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_sequencia_ate", FinanceiroTitulos.sequenciaAte));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_vencimento", FinanceiroTitulos.dataVencimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_vencimento_negoci", FinanceiroTitulos.dataVencimentoNegociado));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_titulo", FinanceiroTitulos.valorTitulo));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_titulo_negociado", FinanceiroTitulos.valorTituloNegociado));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_competencia", FinanceiroTitulos.competencia));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_natureza_document", FinanceiroTitulos.naturezaOperacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_financeiro", FinanceiroTitulos.codigoContaContabil));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_banco", FinanceiroTitulos.codigoBanco));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_juros", FinanceiroTitulos.percentualJuros));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_desconto", FinanceiroTitulos.percentualDesconto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_juros", FinanceiroTitulos.valorJuros));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_desconto", FinanceiroTitulos.valorDesconto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_pago", FinanceiroTitulos.valorPago));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_pagamento", FinanceiroTitulos.dataPagamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_pago", FinanceiroTitulos.isPago));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_meio_pagamento", FinanceiroTitulos.codigoMeioPagamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_pis_cofins", FinanceiroTitulos.percentualPisCofins));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_pis_cofins", FinanceiroTitulos.valorPisCofins));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_criacao", FinanceiroTitulos.dataCadastramento));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_atualizacao", FinanceiroTitulos.dataAtualizacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_criador", FinanceiroTitulos.codigoFuncionarioCadastramento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_atualizador", FinanceiroTitulos.codigoFuncionarioAtualizacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_tipo_entidade", FinanceiroTitulos.codigoTipoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_origem", FinanceiroTitulos.codigoOrigem));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_centro_custos", FinanceiroTitulos.codigoCentroCustos));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_sub_centro_custos", FinanceiroTitulos.codigoSubCentroCustos));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_comentario", FinanceiroTitulos.comentario));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_documento_origem_", FinanceiroTitulos.codigoTipoDocumentoOrigem));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_documento_origem", FinanceiroTitulos.codigoDocumentoOrigem));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_documento_origem_", FinanceiroTitulos.codigoDocumentoOrigemItem));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_entidade", FinanceiroTitulos.razaoSocial));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_cnpj", FinanceiroTitulos.cnpj));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_documento_origem", FinanceiroTitulos.valorDocumentoOrigem));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "Erp.FinanceiroTitulos Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataMovimento", "dt_movimento", FinanceiroTitulos.dataMovimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataEmissao", "dt_emissao", FinanceiroTitulos.dataEmissao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipo", "cd_tipo", FinanceiroTitulos.codigoTipo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsPrevisao", "ic_previsao", FinanceiroTitulos.isPrevisao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DescricaoTitulo", "ds_titulo", FinanceiroTitulos.descricaoTitulo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "cd_cliente", FinanceiroTitulos.codigoEntidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Documento", "nm_documento", FinanceiroTitulos.documento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "SequenciaDe", "vl_sequencia_de", FinanceiroTitulos.sequenciaDe, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "SequenciaAte", "vl_sequencia_ate", FinanceiroTitulos.sequenciaAte, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataVencimento", "dt_vencimento", FinanceiroTitulos.dataVencimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataVencimentoNegociado", "dt_vencimento_negoci", FinanceiroTitulos.dataVencimentoNegociado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorTitulo", "vl_titulo", FinanceiroTitulos.valorTitulo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorTituloNegociado", "vl_titulo_negociado", FinanceiroTitulos.valorTituloNegociado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Competencia", "nm_competencia", FinanceiroTitulos.competencia, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NaturezaOperacao", "nm_natureza_document", FinanceiroTitulos.naturezaOperacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "cd_financeiro", FinanceiroTitulos.codigoContaContabil, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoBanco", "cd_banco", FinanceiroTitulos.codigoBanco, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PercentualJuros", "pc_juros", FinanceiroTitulos.percentualJuros, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PercentualDesconto", "pc_desconto", FinanceiroTitulos.percentualDesconto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorJuros", "vl_juros", FinanceiroTitulos.valorJuros, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorDesconto", "vl_desconto", FinanceiroTitulos.valorDesconto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorPago", "vl_pago", FinanceiroTitulos.valorPago, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataPagamento", "dt_pagamento", FinanceiroTitulos.dataPagamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsPago", "ic_pago", FinanceiroTitulos.isPago, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoMeioPagamento", "cd_meio_pagamento", FinanceiroTitulos.codigoMeioPagamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PercentualPisCofins", "pc_pis_cofins", FinanceiroTitulos.percentualPisCofins, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorPisCofins", "vl_pis_cofins", FinanceiroTitulos.valorPisCofins, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataCadastramento", "dt_criacao", FinanceiroTitulos.dataCadastramento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", FinanceiroTitulos.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioCadastramento", "cd_criador", FinanceiroTitulos.codigoFuncionarioCadastramento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionarioAtualizacao", "cd_atualizador", FinanceiroTitulos.codigoFuncionarioAtualizacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipoEntidade", "cd_tipo_entidade", FinanceiroTitulos.codigoTipoEntidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoOrigem", "cd_origem", FinanceiroTitulos.codigoOrigem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCentroCustos", "cd_centro_custos", FinanceiroTitulos.codigoCentroCustos, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoSubCentroCustos", "cd_sub_centro_custos", FinanceiroTitulos.codigoSubCentroCustos, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Comentario", "ds_comentario", FinanceiroTitulos.comentario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipoDocumentoOrigem", "cd_documento_origem_", FinanceiroTitulos.codigoTipoDocumentoOrigem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoDocumentoOrigem", "cd_documento_origem", FinanceiroTitulos.codigoDocumentoOrigem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoDocumentoOrigemItem", "cd_documento_origem_", FinanceiroTitulos.codigoDocumentoOrigemItem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "RazaoSocial", "nm_entidade", FinanceiroTitulos.razaoSocial, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Cnpj", "nm_cnpj", FinanceiroTitulos.cnpj, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorDocumentoOrigem", "vl_documento_origem", FinanceiroTitulos.valorDocumentoOrigem, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", FinanceiroTitulos.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirFinanceiroTitulos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "Erp.FinanceiroTitulos ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
