using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalNotasFiscais : INotaFiscalNotasFiscais
{
	private MapTableNotaFiscalNotasFiscais MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscais result = default(MapTableNotaFiscalNotasFiscais);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.numeroNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["numeroNotaFiscal"]);
			result.serieNotaFiscal = BaseDadosERP.ObterDbValor<string>(row["serieNotaFiscal"]);
			result.codigoCFOP = BaseDadosERP.ObterDbValor<int>(row["codigoCFOP"]);
			result.codigoFichaExpedicao = BaseDadosERP.ObterDbValor<int>(row["codigoFichaExpedicao"]);
			result.codigoFormaPagto = BaseDadosERP.ObterDbValor<int>(row["codigoFormaPagto"]);
			result.codigoTransportadora = BaseDadosERP.ObterDbValor<int>(row["codigoTransportadora"]);
			result.isFretePagoPeloEmitente = BaseDadosERP.ObterDbValor<bool>(row["isFretePagoPeloEmitente"]);
			result.isNotaFiscalEntrada = BaseDadosERP.ObterDbValor<bool>(row["isNotaFiscalSaida"]);
			result.dataEmissao = BaseDadosERP.ObterDbValor<DateTime>(row["dataEmissao"]);
			result.dataSaida = BaseDadosERP.ObterDbValor<DateTime>(row["dataSaida"]);
			result.dataEnvioNFE = BaseDadosERP.ObterDbValor<DateTime>(row["dataEnvioNFE"]);
			result.dataCancelamento = BaseDadosERP.ObterDbValor<DateTime>(row["dataCancelamento"]);
			result.dataCancelamentoNFE = BaseDadosERP.ObterDbValor<DateTime>(row["dataCancelamentoNFE"]);
			result.motivoCancelamento = BaseDadosERP.ObterDbValor<string>(row["motivoCancelamento"]);
			result.codigoEmissor = BaseDadosERP.ObterDbValor<int>(row["codigoEmissor"]);
			result.codigoResponsavelCancelamento = BaseDadosERP.ObterDbValor<int>(row["codigoResponsavelCancelamento"]);
			result.codigoResponsavelEnvioNfe = BaseDadosERP.ObterDbValor<int>(row["codigoResponsavelEnvioNfe"]);
			result.valorBaseICMS = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseICMS"]);
			result.valorICMS = BaseDadosERP.ObterDbValor<decimal>(row["valorICMS"]);
			result.valorIPI = BaseDadosERP.ObterDbValor<decimal>(row["valorIPI"]);
			result.valorPIS = BaseDadosERP.ObterDbValor<decimal>(row["valorPIS"]);
			result.valorCSLL = BaseDadosERP.ObterDbValor<decimal>(row["valorCSLL"]);
			result.valorProdutos = BaseDadosERP.ObterDbValor<decimal>(row["valorProdutos"]);
			result.valorFrete = BaseDadosERP.ObterDbValor<decimal>(row["valorFrete"]);
			result.valorSeguro = BaseDadosERP.ObterDbValor<decimal>(row["valorSeguro"]);
			result.valorOutrasDespesas = BaseDadosERP.ObterDbValor<decimal>(row["valorOutrasDespesas"]);
			result.valorCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorCofins"]);
			result.valorImpostoRetido = BaseDadosERP.ObterDbValor<decimal>(row["valorImpostoRetido"]);
			result.valorTotalNotaFiscal = BaseDadosERP.ObterDbValor<decimal>(row["valorTotalNotaFiscal"]);
			result.chaveNfe = BaseDadosERP.ObterDbValor<string>(row["chaveNfe"]);
			result.protocoloNfe = BaseDadosERP.ObterDbValor<string>(row["protocoloNfe"]);
			result.xmlNfe = BaseDadosERP.ObterDbValor<string>(row["xmlNfe"]);
			result.valorBaseICMSSubstituto = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseICMSSubstituto"]);
			result.valorICMSSubstituto = BaseDadosERP.ObterDbValor<decimal>(row["valorICMSSubstituto"]);
			result.codigoSerieNF = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNF"]);
			result.numeracaoCFOP = BaseDadosERP.ObterDbValor<string>(row["numeracaoCFOP"]);
			result.descricaoCFOP = BaseDadosERP.ObterDbValor<string>(row["descricaoCFOP"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoTextoLegal1 = BaseDadosERP.ObterDbValor<int>(row["codigoTextoLegal1"]);
			result.codigoTextoLegal2 = BaseDadosERP.ObterDbValor<int>(row["codigoTextoLegal2"]);
			result.razaoSocialDestinatario = BaseDadosERP.ObterDbValor<string>(row["razaoSocialDestinatario"]);
			result.cnpjDestinatario = BaseDadosERP.ObterDbValor<string>(row["cnpjDestinatario"]);
			result.situacaoNfe = BaseDadosERP.ObterDbValor<string>(row["situacaoNfe"]);
			result.codigoLote = BaseDadosERP.ObterDbValor<string>(row["codigoLote"]);
			result.tipoEmissao = BaseDadosERP.ObterDbValor<int>(row["tipoEmissao"]);
			result.valorTotalFatura = BaseDadosERP.ObterDbValor<decimal>(row["valorTotalFatura"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_nota_fiscal as numeroNotaFiscal, ");
		stringBuilder.Append("nm_serie_nota_fiscal as serieNotaFiscal, ");
		stringBuilder.Append("cd_cfop as codigoCFOP, ");
		stringBuilder.Append("cd_fe as codigoFichaExpedicao, ");
		stringBuilder.Append("cd_forma_pagto as codigoFormaPagto, ");
		stringBuilder.Append("cd_transportadora as codigoTransportadora, ");
		stringBuilder.Append("ic_frete_emitente as isFretePagoPeloEmitente, ");
		stringBuilder.Append("ic_saida as isNotaFiscalSaida, ");
		stringBuilder.Append("dt_emissao as dataEmissao, ");
		stringBuilder.Append("dt_saida as dataSaida, ");
		stringBuilder.Append("dt_emissao_nfe as dataEnvioNFE, ");
		stringBuilder.Append("dt_cancelamento as dataCancelamento, ");
		stringBuilder.Append("dt_cancelamento_nfe as dataCancelamentoNFE, ");
		stringBuilder.Append("ds_motivo_cancelamen as motivoCancelamento, ");
		stringBuilder.Append("cd_emissor as codigoEmissor, ");
		stringBuilder.Append("cd_cancelou as codigoResponsavelCancelamento, ");
		stringBuilder.Append("cd_enviou_nfe as codigoResponsavelEnvioNfe, ");
		stringBuilder.Append("vl_base_icms as valorBaseICMS, ");
		stringBuilder.Append("vl_icms as valorICMS, ");
		stringBuilder.Append("vl_ipi as valorIPI, ");
		stringBuilder.Append("vl_pis as valorPIS, ");
		stringBuilder.Append("vl_csll as valorCSLL, ");
		stringBuilder.Append("vl_produtos as valorProdutos, ");
		stringBuilder.Append("vl_frete as valorFrete, ");
		stringBuilder.Append("vl_seguro as valorSeguro, ");
		stringBuilder.Append("vl_outras_despesas as valorOutrasDespesas, ");
		stringBuilder.Append("vl_cofins as valorCofins, ");
		stringBuilder.Append("vl_imposto_retido as valorImpostoRetido, ");
		stringBuilder.Append("vl_total_nota as valorTotalNotaFiscal, ");
		stringBuilder.Append("nm_chave_nfe as chaveNfe, ");
		stringBuilder.Append("nm_protocolo_nfe as protocoloNfe, ");
		stringBuilder.Append("xml_nfe as xmlNfe, ");
		stringBuilder.Append("vl_base_icms_sub as valorBaseICMSSubstituto, ");
		stringBuilder.Append("vl_icms_sub as valorICMSSubstituto, ");
		stringBuilder.Append("cd_serie_nota_fiscal as codigoSerieNF, ");
		stringBuilder.Append("nm_cfop as numeracaoCFOP, ");
		stringBuilder.Append("ds_cfop as descricaoCFOP, ");
		stringBuilder.Append("cd_entidade as codigoEntidade, ");
		stringBuilder.Append("cd_texto_legal1 as codigoTextoLegal1, ");
		stringBuilder.Append("cd_texto_legal2 as codigoTextoLegal2, ");
		stringBuilder.Append("cd_emissao as tipoEmissao, ");
		stringBuilder.Append("nm_destinatario as razaoSocialDestinatario, ");
		stringBuilder.Append("nm_cnpj_destinatario as cnpjDestinatario, ");
		stringBuilder.Append("ds_situacao_nfe as situacaoNfe, ");
		stringBuilder.Append("cd_lote as codigoLote, ");
		stringBuilder.Append("vl_total_fatura as valorTotalFatura");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscais ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotasFiscais> list = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(int id)
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

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(string chave)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_chave_nfe = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_chave_nfe", chave));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalNotasFiscais.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscais (");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("nm_serie_nota_fiscal, ");
		stringBuilder.Append("cd_cfop, ");
		stringBuilder.Append("cd_fe, ");
		stringBuilder.Append("cd_forma_pagto, ");
		stringBuilder.Append("cd_transportadora, ");
		stringBuilder.Append("ic_frete_emitente, ");
		stringBuilder.Append("ic_saida, ");
		stringBuilder.Append("dt_emissao, ");
		stringBuilder.Append("dt_saida, ");
		stringBuilder.Append("dt_emissao_nfe, ");
		stringBuilder.Append("dt_cancelamento, ");
		stringBuilder.Append("dt_cancelamento_nfe, ");
		stringBuilder.Append("ds_motivo_cancelamen, ");
		stringBuilder.Append("cd_emissor, ");
		stringBuilder.Append("cd_cancelou, ");
		stringBuilder.Append("cd_enviou_nfe, ");
		stringBuilder.Append("vl_base_icms, ");
		stringBuilder.Append("vl_icms, ");
		stringBuilder.Append("vl_ipi, ");
		stringBuilder.Append("vl_pis, ");
		stringBuilder.Append("vl_csll, ");
		stringBuilder.Append("vl_produtos, ");
		stringBuilder.Append("vl_frete, ");
		stringBuilder.Append("vl_seguro, ");
		stringBuilder.Append("vl_outras_despesas, ");
		stringBuilder.Append("vl_cofins, ");
		stringBuilder.Append("vl_imposto_retido, ");
		stringBuilder.Append("vl_total_nota, ");
		stringBuilder.Append("nm_chave_nfe, ");
		stringBuilder.Append("nm_protocolo_nfe, ");
		stringBuilder.Append("xml_nfe, ");
		stringBuilder.Append("vl_base_icms_sub, ");
		stringBuilder.Append("vl_icms_sub, ");
		stringBuilder.Append("cd_serie_nota_fiscal, ");
		stringBuilder.Append("nm_cfop, ");
		stringBuilder.Append("ds_cfop, ");
		stringBuilder.Append("cd_entidade, ");
		stringBuilder.Append("cd_texto_legal1, ");
		stringBuilder.Append("cd_texto_legal2, ");
		stringBuilder.Append("cd_emissao, ");
		stringBuilder.Append("nm_destinatario, ");
		stringBuilder.Append("nm_cnpj_destinatario, ");
		stringBuilder.Append("ds_situacao_nfe, ");
		stringBuilder.Append("cd_lote, vl_total_fatura ) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscais.numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_serie_nota_fiscal", NotaFiscalNotasFiscais.serieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cfop", NotaFiscalNotasFiscais.codigoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_fe", NotaFiscalNotasFiscais.codigoFichaExpedicao));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_forma_pagto", NotaFiscalNotasFiscais.codigoFormaPagto));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_transportadora", NotaFiscalNotasFiscais.codigoTransportadora));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_frete_emitente", NotaFiscalNotasFiscais.isFretePagoPeloEmitente));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_saida", NotaFiscalNotasFiscais.isNotaFiscalEntrada));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_emissao", NotaFiscalNotasFiscais.dataEmissao));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_saida", NotaFiscalNotasFiscais.dataSaida));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_emissao_nfe", NotaFiscalNotasFiscais.dataEnvioNFE));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_cancelamento", NotaFiscalNotasFiscais.dataCancelamento));
		list.Add(BaseDadosERP.ObterNovoParametro("dt_cancelamento_nfe", NotaFiscalNotasFiscais.dataCancelamentoNFE));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_motivo_cancelamen", NotaFiscalNotasFiscais.motivoCancelamento));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_emissor", NotaFiscalNotasFiscais.codigoEmissor));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cancelou", NotaFiscalNotasFiscais.codigoResponsavelCancelamento));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_enviou_nfe", NotaFiscalNotasFiscais.codigoResponsavelEnvioNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_base_icms", NotaFiscalNotasFiscais.valorBaseICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_icms", NotaFiscalNotasFiscais.valorICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_ipi", NotaFiscalNotasFiscais.valorIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_pis", NotaFiscalNotasFiscais.valorPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_csll", NotaFiscalNotasFiscais.valorCSLL));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_produtos", NotaFiscalNotasFiscais.valorProdutos));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_frete", NotaFiscalNotasFiscais.valorFrete));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_seguro", NotaFiscalNotasFiscais.valorSeguro));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_outras_despesas", NotaFiscalNotasFiscais.valorOutrasDespesas));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_cofins", NotaFiscalNotasFiscais.valorCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_imposto_retido", NotaFiscalNotasFiscais.valorImpostoRetido));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_total_nota", NotaFiscalNotasFiscais.valorTotalNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_chave_nfe", NotaFiscalNotasFiscais.chaveNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_protocolo_nfe", NotaFiscalNotasFiscais.protocoloNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("xml_nfe", NotaFiscalNotasFiscais.xmlNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_base_icms_sub", NotaFiscalNotasFiscais.valorBaseICMSSubstituto));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_icms_sub", NotaFiscalNotasFiscais.valorICMSSubstituto));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_serie_nota_fiscal", NotaFiscalNotasFiscais.codigoSerieNF));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_cfop", NotaFiscalNotasFiscais.numeracaoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_cfop", NotaFiscalNotasFiscais.descricaoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_entidade", NotaFiscalNotasFiscais.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_texto_legal1", NotaFiscalNotasFiscais.codigoTextoLegal1));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_texto_legal2", NotaFiscalNotasFiscais.codigoTextoLegal2));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_emissao", NotaFiscalNotasFiscais.tipoEmissao));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_destinatario", NotaFiscalNotasFiscais.razaoSocialDestinatario));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_cnpj_destinatario", NotaFiscalNotasFiscais.cnpjDestinatario));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_situacao_nfe", NotaFiscalNotasFiscais.situacaoNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_lote", NotaFiscalNotasFiscais.codigoLote));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_total_fatura", NotaFiscalNotasFiscais.valorTotalFatura));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscais Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeroNotaFiscal", "cd_nota_fiscal", NotaFiscalNotasFiscais.numeroNotaFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SerieNotaFiscal", "nm_serie_nota_fiscal", NotaFiscalNotasFiscais.serieNotaFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCFOP", "cd_cfop", NotaFiscalNotasFiscais.codigoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFichaExpedicao", "cd_fe", NotaFiscalNotasFiscais.codigoFichaExpedicao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFormaPagto", "cd_forma_pagto", NotaFiscalNotasFiscais.codigoFormaPagto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTransportadora", "cd_transportadora", NotaFiscalNotasFiscais.codigoTransportadora, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFretePagoPeloEmitente", "ic_frete_emitente", NotaFiscalNotasFiscais.isFretePagoPeloEmitente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsNotaFiscalSaida", "ic_saida", NotaFiscalNotasFiscais.isNotaFiscalEntrada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEmissao", "dt_emissao", NotaFiscalNotasFiscais.dataEmissao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataSaida", "dt_saida", NotaFiscalNotasFiscais.dataSaida, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEnvioNFE", "dt_emissao_nfe", NotaFiscalNotasFiscais.dataEnvioNFE, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCancelamento", "dt_cancelamento", NotaFiscalNotasFiscais.dataCancelamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCancelamentoNFE", "dt_cancelamento_nfe", NotaFiscalNotasFiscais.dataCancelamentoNFE, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "MotivoCancelamento", "ds_motivo_cancelamen", NotaFiscalNotasFiscais.motivoCancelamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmissor", "cd_emissor", NotaFiscalNotasFiscais.codigoEmissor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoResponsavelCancelamento", "cd_cancelou", NotaFiscalNotasFiscais.codigoResponsavelCancelamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoResponsavelEnvioNfe", "cd_enviou_nfe", NotaFiscalNotasFiscais.codigoResponsavelEnvioNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseICMS", "vl_base_icms", NotaFiscalNotasFiscais.valorBaseICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorICMS", "vl_icms", NotaFiscalNotasFiscais.valorICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIPI", "vl_ipi", NotaFiscalNotasFiscais.valorIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorPIS", "vl_pis", NotaFiscalNotasFiscais.valorPIS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCSLL", "vl_csll", NotaFiscalNotasFiscais.valorCSLL, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorProdutos", "vl_produtos", NotaFiscalNotasFiscais.valorProdutos, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFrete", "vl_frete", NotaFiscalNotasFiscais.valorFrete, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorSeguro", "vl_seguro", NotaFiscalNotasFiscais.valorSeguro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorOutrasDespesas", "vl_outras_despesas", NotaFiscalNotasFiscais.valorOutrasDespesas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCofins", "vl_cofins", NotaFiscalNotasFiscais.valorCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorImpostoRetido", "vl_imposto_retido", NotaFiscalNotasFiscais.valorImpostoRetido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotalNotaFiscal", "vl_total_nota", NotaFiscalNotasFiscais.valorTotalNotaFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ChaveNfe", "nm_chave_nfe", NotaFiscalNotasFiscais.chaveNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ProtocoloNfe", "nm_protocolo_nfe", NotaFiscalNotasFiscais.protocoloNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "XmlNfe", "xml_nfe", NotaFiscalNotasFiscais.xmlNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseICMSSubstituto", "vl_base_icms_sub", NotaFiscalNotasFiscais.valorBaseICMSSubstituto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorICMSSubstituto", "vl_icms_sub", NotaFiscalNotasFiscais.valorICMSSubstituto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSerieNF", "cd_serie_nota_fiscal", NotaFiscalNotasFiscais.codigoSerieNF, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeracaoCFOP", "nm_cfop", NotaFiscalNotasFiscais.numeracaoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoCFOP", "ds_cfop", NotaFiscalNotasFiscais.descricaoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "cd_entidade", NotaFiscalNotasFiscais.codigoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTextoLegal1", "cd_texto_legal1", NotaFiscalNotasFiscais.codigoTextoLegal1, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTextoLegal2", "cd_texto_legal2", NotaFiscalNotasFiscais.codigoTextoLegal2, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoEmissao", "cd_emissao", NotaFiscalNotasFiscais.tipoEmissao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RazaoSocialDestinatario", "nm_destinatario", NotaFiscalNotasFiscais.razaoSocialDestinatario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CnpjDestinatario", "nm_cnpj_destinatario", NotaFiscalNotasFiscais.cnpjDestinatario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SituacaoNfe", "ds_situacao_nfe", NotaFiscalNotasFiscais.situacaoNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoLote", "cd_lote", NotaFiscalNotasFiscais.codigoLote, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotalFatura", "vl_total_fatura", NotaFiscalNotasFiscais.valorTotalFatura, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalNotasFiscais.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscais(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscais ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ObterUltimaNota(string serie)
	{
		throw new NotImplementedException();
	}

	public bool ChecarSeNotaExiste(int numeroNota, string serie)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscaisNumeroNota(int NotaFiscal)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscaisNumeroNota(int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalNotasFiscais(int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		throw new NotImplementedException();
	}

	public int ObterUltimaNota(int serie)
	{
		throw new NotImplementedException();
	}

	public bool ChecarSeNotaExiste(int numeroNota, int serie)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableResumoFaturamentoItem> ObterRelatorioFaturamento(DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoCliente)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		throw new NotImplementedException();
	}

	public int ObterUltimaNota(int codigoEmpresa, int serie)
	{
		throw new NotImplementedException();
	}

	public bool ChecarSeNotaExiste(int codigoEmpresa, int numeroNota, int serie)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableResumoFaturamentoItem> ObterRelatorioFaturamento(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int tipo, int codigoEntidade)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoNota(int codigoNota)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoPedidoVenda(int codigoPedidoVenda)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoProduto(string codigoProduto)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoContrato(string codigoContrato)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisSituacao(string situacao)
	{
		throw new NotImplementedException();
	}
}
