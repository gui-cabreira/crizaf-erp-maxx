using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalNotasFiscais : INotaFiscalNotasFiscais
{
	private MapTableNotaFiscalNotasFiscais MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscais result = default(MapTableNotaFiscalNotasFiscais);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.numeroNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["numeroNotaFiscal"]);
			result.codigoSerieNF = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNF"]);
			result.serieNotaFiscal = BaseDadosERP.ObterDbValor<string>(row["serieNotaFiscal"]);
			result.codigoCFOP = BaseDadosERP.ObterDbValor<int>(row["codigoCFOP"]);
			result.numeracaoCFOP = BaseDadosERP.ObterDbValor<string>(row["numeracaoCFOP"]);
			result.descricaoCFOP = BaseDadosERP.ObterDbValor<string>(row["descricaoCFOP"]);
			result.codigoFichaExpedicao = BaseDadosERP.ObterDbValor<int>(row["codigoFichaExpedicao"]);
			result.codigoFormaPagto = BaseDadosERP.ObterDbValor<int>(row["codigoFormaPagto"]);
			result.codigoTransportadora = BaseDadosERP.ObterDbValor<int>(row["codigoTransportadora"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.isFretePagoPeloEmitente = BaseDadosERP.ObterDbValor<bool>(row["isFretePagoPeloEmitente"]);
			result.isNotaFiscalEntrada = BaseDadosERP.ObterDbValor<bool>(row["isNotaFiscalEntrada"]);
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
			result.valorBaseICMSSubstituto = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseICMSSubstituto"]);
			result.valorICMSSubstituto = BaseDadosERP.ObterDbValor<decimal>(row["valorICMSSubstituto"]);
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
			result.codigoTextoLegal1 = BaseDadosERP.ObterDbValor<int>(row["codigoTextoLegal1"]);
			result.codigoTextoLegal2 = BaseDadosERP.ObterDbValor<int>(row["codigoTextoLegal2"]);
			result.razaoSocialDestinatario = BaseDadosERP.ObterDbValor<string>(row["razaoSocialDestinatario"]);
			result.cnpjDestinatario = BaseDadosERP.ObterDbValor<string>(row["cnpjDestinatario"]);
			result.situacaoNfe = BaseDadosERP.ObterDbValor<string>(row["situacaoNfe"]);
			result.codigoLote = BaseDadosERP.ObterDbValor<string>(row["codigoLote"]);
			result.tipoEmissao = BaseDadosERP.ObterDbValor<int>(row["tipoEmissao"]);
			result.valorPISRetido = BaseDadosERP.ObterDbValor<decimal>(row["valorPISRetido"]);
			result.valorCofinsRetido = BaseDadosERP.ObterDbValor<decimal>(row["valorCofinsRetido"]);
			result.valorTotalFatura = BaseDadosERP.ObterDbValor<decimal>(row["valorTotalFatura"]);
			result.tipoEntidade = BaseDadosERP.ObterDbValor<int>(row["tipoEntidade"]);
			result.pesoBruto = BaseDadosERP.ObterDbValor<decimal>(row["pesoBruto"]);
			result.pesoLiquido = BaseDadosERP.ObterDbValor<decimal>(row["pesoLiquido"]);
			result.qtVolumes = BaseDadosERP.ObterDbValor<int>(row["qtVolumes"]);
			result.textoLegal = BaseDadosERP.ObterDbValor<string>(row["textoLegal"]);
			result.tipoNota = BaseDadosERP.ObterDbValor<int>(row["tipoNota"]);
			result.notaReferenciada = BaseDadosERP.ObterDbValor<string>(row["notaReferenciada"]);
			result.isConsumidorFinal = BaseDadosERP.ObterDbValor<bool>(row["isConsumidorFinal"]);
			result.codigoCondicaoPagamento = BaseDadosERP.ObterDbValor<int>(row["codigoCondicaoPagamento"]);
			result.valorImpostoImportacao = BaseDadosERP.ObterDbValor<decimal>(row["valorImpostoImportacao"]);
			result.isFreteCliente = BaseDadosERP.ObterDbValor<bool>(row["isFreteCliente"]);
			result.valorCambio = BaseDadosERP.ObterDbValor<decimal>(row["valorCambio"]);
			result.suframa = BaseDadosERP.ObterDbValor<string>(row["suframa"]);
			result.placaCaminhao = BaseDadosERP.ObterDbValor<string>(row["placaCaminhao"]);
			result.codigoTipoEntidadeEntrega = BaseDadosERP.ObterDbValor<int>(row["codigoTipoEntidadeEntrega"]);
			result.codigoEntidadeEntrega = BaseDadosERP.ObterDbValor<int>(row["codigoEntidadeEntrega"]);
			result.valorTotalIcmsInterestadualFundoPobreza = BaseDadosERP.ObterDbValor<decimal>(row["valorTotalIcmsInterestadualFundoPobreza"]);
			result.valorTotalIcmsInterestadualUfDestino = BaseDadosERP.ObterDbValor<decimal>(row["valorTotalIcmsInterestadualUfDestino"]);
			result.valorTotalIcmsInterestadualUfEnvolvidas = BaseDadosERP.ObterDbValor<decimal>(row["valorTotalIcmsInterestadualUfEnvolvidas"]);
			result.portaoEntrega = BaseDadosERP.ObterDbValor<string>(row["portaoEntrega"]);
			result.valorCreditoIcms = BaseDadosERP.ObterDbValor<decimal>(row["valorCreditoIcms"]);
			result.percentualCreditoIcms = BaseDadosERP.ObterDbValor<decimal>(row["percentualCreditoIcms"]);
			result.valorDesconto = BaseDadosERP.ObterDbValor<decimal>(row["valorDesconto"]);
			result.valorIcmsDesonerado = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsDesonerado"]);
			result.isBloquearRecalculoFatura = BaseDadosERP.ObterDbValor<bool>(row["isBloquearRecalculoFatura"]);
			result.codigoEDI = BaseDadosERP.ObterDbValor<int>(row["codigoEDI"]);
			result.codigoControleReajuste = BaseDadosERP.ObterDbValor<int>(row["codigoControleReajuste"]);
			result.codigoIndicadorPresenca = BaseDadosERP.ObterDbValor<int>(row["codigoIndicadorPresenca"]);
			result.codigoModeloDocumentoFiscalReferenciado = BaseDadosERP.ObterDbValor<int>(row["codigoModeloDocumentoFiscalReferenciado"]);
			result.codigoModalidadeFrete = BaseDadosERP.ObterDbValor<int>(row["codigoModalidadeFrete"]);
			result.valorBaseCalculoFundoCombatePobreza = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoFundoCombatePobreza"]);
			result.valorFundoCombatePobreza = BaseDadosERP.ObterDbValor<decimal>(row["valorFundoCombatePobreza"]);
			result.valorBaseCalculoFundoCombatePobrezaST = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoFundoCombatePobrezaST"]);
			result.valorFundoCombatePobrezaST = BaseDadosERP.ObterDbValor<decimal>(row["valorFundoCombatePobrezaST"]);
			result.isComissaoApurada = BaseDadosERP.ObterDbValor<bool>(row["isComissaoApurada"]);
			result.tipoVolume = BaseDadosERP.ObterDbValor<string>(row["tipoVolume"]);
			result.codigoContaContabil = BaseDadosERP.ObterDbValor<int>(row["codigoContaContabil"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("[cd_nota_fiscal] as [numeroNotaFiscal], ");
		stringBuilder.Append("[cd_serie_nota_fiscal] as [codigoSerieNF], ");
		stringBuilder.Append("[nm_serie_nota_fiscal] as [serieNotaFiscal], ");
		stringBuilder.Append("[cd_cfop] as [codigoCFOP], ");
		stringBuilder.Append("[nm_cfop] as [numeracaoCFOP], ");
		stringBuilder.Append("[ds_cfop] as [descricaoCFOP], ");
		stringBuilder.Append("[cd_fe] as [codigoFichaExpedicao], ");
		stringBuilder.Append("[cd_forma_pagto] as [codigoFormaPagto], ");
		stringBuilder.Append("[cd_transportadora] as [codigoTransportadora], ");
		stringBuilder.Append("[cd_entidade] as [codigoEntidade], ");
		stringBuilder.Append("[ic_frete_emitente] as [isFretePagoPeloEmitente], ");
		stringBuilder.Append("[ic_saida] as [isNotaFiscalEntrada], ");
		stringBuilder.Append("[dt_emissao] as [dataEmissao], ");
		stringBuilder.Append("[dt_saida] as [dataSaida], ");
		stringBuilder.Append("[dt_emissao_nfe] as [dataEnvioNFE], ");
		stringBuilder.Append("[dt_cancelamento] as [dataCancelamento], ");
		stringBuilder.Append("[dt_cancelamento_nfe] as [dataCancelamentoNFE], ");
		stringBuilder.Append("[ds_motivo_cancelamento] as [motivoCancelamento], ");
		stringBuilder.Append("[cd_emissor] as [codigoEmissor], ");
		stringBuilder.Append("[cd_cancelou] as [codigoResponsavelCancelamento], ");
		stringBuilder.Append("[cd_enviou_nfe] as [codigoResponsavelEnvioNfe], ");
		stringBuilder.Append("[vl_base_icms] as [valorBaseICMS], ");
		stringBuilder.Append("[vl_icms] as [valorICMS], ");
		stringBuilder.Append("[vl_base_icms_sub] as [valorBaseICMSSubstituto], ");
		stringBuilder.Append("[vl_icms_sub] as [valorICMSSubstituto], ");
		stringBuilder.Append("[vl_ipi] as [valorIPI], ");
		stringBuilder.Append("[vl_pis] as [valorPIS], ");
		stringBuilder.Append("[vl_csll] as [valorCSLL], ");
		stringBuilder.Append("[vl_produtos] as [valorProdutos], ");
		stringBuilder.Append("[vl_frete] as [valorFrete], ");
		stringBuilder.Append("[vl_seguro] as [valorSeguro], ");
		stringBuilder.Append("[vl_outras_despesas] as [valorOutrasDespesas], ");
		stringBuilder.Append("[vl_cofins] as [valorCofins], ");
		stringBuilder.Append("[vl_imposto_retido] as [valorImpostoRetido], ");
		stringBuilder.Append("[vl_total_nota] as [valorTotalNotaFiscal], ");
		stringBuilder.Append("[nm_chave_nfe] as [chaveNfe], ");
		stringBuilder.Append("[nm_protocolo_nfe] as [protocoloNfe], ");
		stringBuilder.Append("[cd_texto_legal1] as [codigoTextoLegal1], ");
		stringBuilder.Append("[cd_texto_legal2] as [codigoTextoLegal2], ");
		stringBuilder.Append("[nm_destinatario] as [razaoSocialDestinatario], ");
		stringBuilder.Append("[nm_cnpj_destinatario] as [cnpjDestinatario], ");
		stringBuilder.Append("[ds_situacao_nfe] as [situacaoNfe], ");
		stringBuilder.Append("[cd_lote] as [codigoLote], ");
		stringBuilder.Append("[cd_emissao] as [tipoEmissao], ");
		stringBuilder.Append("[vl_pis_retido] as [valorPISRetido], ");
		stringBuilder.Append("[vl_cofins_retido] as [valorCofinsRetido], ");
		stringBuilder.Append("[vl_total_fatura] as [valorTotalFatura], ");
		stringBuilder.Append("[cd_tipo_entidade] as [tipoEntidade], ");
		stringBuilder.Append("[vl_peso_bruto] as [pesoBruto], ");
		stringBuilder.Append("[vl_peso_liquido] as [pesoLiquido], ");
		stringBuilder.Append("[vl_numero_embalagens] as [qtVolumes], ");
		stringBuilder.Append("[ds_texto_legal] as [textoLegal], ");
		stringBuilder.Append("[cd_tipo_nota] as [tipoNota], ");
		stringBuilder.Append("[cd_nota_referenciada] as [notaReferenciada], ");
		stringBuilder.Append("[ic_consumidor_final] as [isConsumidorFinal], ");
		stringBuilder.Append("[cd_condicao_pagamento] as [codigoCondicaoPagamento], ");
		stringBuilder.Append("[vl_imposto_importacao] as [valorImpostoImportacao], ");
		stringBuilder.Append("[ic_transportadora_cliente] as [isFreteCliente], ");
		stringBuilder.Append("[vl_cambio] as [valorCambio],");
		stringBuilder.Append("[cd_suframa ] as [suframa],");
		stringBuilder.Append("[nm_placa_caminhao] as [placaCaminhao],");
		stringBuilder.Append("[cd_tipo_entidade_entrega] as [codigoTipoEntidadeEntrega],");
		stringBuilder.Append("[cd_entidade_entrega] as [codigoEntidadeEntrega], ");
		stringBuilder.Append("[vl_total_fundo_pobreza_uf_destino] as [valorTotalIcmsInterestadualFundoPobreza], ");
		stringBuilder.Append("[vl_total_icms_interestadual_uf_destino] as [valorTotalIcmsInterestadualUfDestino], ");
		stringBuilder.Append("[vl_total_icms_interestadual_uf_remetente] as [valorTotalIcmsInterestadualUfEnvolvidas], ");
		stringBuilder.Append("[nm_portao_entrega] as [portaoEntrega], ");
		stringBuilder.Append("[vl_credito_icms] as [valorCreditoIcms], ");
		stringBuilder.Append("[pc_credito_icms] as [percentualCreditoIcms], ");
		stringBuilder.Append("[vl_desconto] as [valorDesconto], ");
		stringBuilder.Append("[vl_icms_deson] as [valorIcmsDesonerado], ");
		stringBuilder.Append("[ic_bloquear_recalculo_fatura] as [isBloquearRecalculoFatura],");
		stringBuilder.Append("[cd_edi] as [codigoEDI],");
		stringBuilder.Append("[cd_ctrl_reajuste] as [codigoControleReajuste],");
		stringBuilder.Append("[cd_indicador_presenca] as [codigoIndicadorPresenca],");
		stringBuilder.Append("[cd_modelo_doc_fiscal_referenciado] as [codigoModeloDocumentoFiscalReferenciado],");
		stringBuilder.Append("[cd_modalidade_frete] as [codigoModalidadeFrete],");
		stringBuilder.Append("[vl_bc_fcp] as [valorBaseCalculoFundoCombatePobreza],");
		stringBuilder.Append("[vl_fcp] as [valorFundoCombatePobreza],");
		stringBuilder.Append("[vl_bc_fcpst] as [valorBaseCalculoFundoCombatePobrezaST],");
		stringBuilder.Append("[vl_fcpst] as [valorFundoCombatePobrezaST],");
		stringBuilder.Append("[ic_comissao_apurada] as [isComissaoApurada],");
		stringBuilder.Append("[nm_tipo_volume] as [tipoVolume], ");
		stringBuilder.Append("[cd_conta_contabil] as [codigoContaContabil]");
		stringBuilder.Append($" from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscais] ");
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

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [dt_emissao] between @dataInicio and @dataFim");
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [dt_emissao] between @dataInicio and @dataFim");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoCliente)
	{
		string valor = "NaoEnviada";
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [cd_entidade] = @cd_entidade ");
		stringBuilder.Append(" and [cd_tipo_entidade] = @cd_tipo_entidade ");
		stringBuilder.Append(" and [ds_situacao_nfe] = @ds_situacao_nfe ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade", codigoCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_entidade", 1));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_situacao_nfe", valor));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisSituacao(string situacao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000  ");
		stringBuilder.Append(" and [ds_situacao_nfe] = @ds_situacao_nfe ");
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_situacao_nfe", situacao));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", codigoNotaFiscalSerie));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(string chave)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_chave_nfe] = @nm_chave_nfe");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_chave_nfe", chave));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscais.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscais.numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", NotaFiscalNotasFiscais.codigoSerieNF));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais)
	{
		if (NotaFiscalNotasFiscais.tipoNota == 0)
		{
			NotaFiscalNotasFiscais.tipoNota = 1;
		}
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Insert into [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscais] (");
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[cd_serie_nota_fiscal], ");
		stringBuilder.Append("[nm_serie_nota_fiscal], ");
		stringBuilder.Append("[cd_cfop], ");
		stringBuilder.Append("[nm_cfop], ");
		stringBuilder.Append("[ds_cfop], ");
		stringBuilder.Append("[cd_fe], ");
		stringBuilder.Append("[cd_forma_pagto], ");
		stringBuilder.Append("[cd_transportadora], ");
		stringBuilder.Append("[cd_entidade], ");
		stringBuilder.Append("[ic_frete_emitente], ");
		stringBuilder.Append("[ic_saida], ");
		stringBuilder.Append("[dt_emissao], ");
		stringBuilder.Append("[dt_saida], ");
		stringBuilder.Append("[dt_emissao_nfe], ");
		stringBuilder.Append("[dt_cancelamento], ");
		stringBuilder.Append("[dt_cancelamento_nfe], ");
		stringBuilder.Append("[ds_motivo_cancelamento], ");
		stringBuilder.Append("[cd_emissor], ");
		stringBuilder.Append("[cd_cancelou], ");
		stringBuilder.Append("[cd_enviou_nfe], ");
		stringBuilder.Append("[vl_base_icms], ");
		stringBuilder.Append("[vl_icms], ");
		stringBuilder.Append("[vl_base_icms_sub], ");
		stringBuilder.Append("[vl_icms_sub], ");
		stringBuilder.Append("[vl_ipi], ");
		stringBuilder.Append("[vl_pis], ");
		stringBuilder.Append("[vl_csll], ");
		stringBuilder.Append("[vl_produtos], ");
		stringBuilder.Append("[vl_frete], ");
		stringBuilder.Append("[vl_seguro], ");
		stringBuilder.Append("[vl_outras_despesas], ");
		stringBuilder.Append("[vl_cofins], ");
		stringBuilder.Append("[vl_imposto_retido], ");
		stringBuilder.Append("[vl_total_nota], ");
		stringBuilder.Append("[nm_chave_nfe], ");
		stringBuilder.Append("[nm_protocolo_nfe], ");
		stringBuilder.Append("[cd_texto_legal1], ");
		stringBuilder.Append("[cd_texto_legal2], ");
		stringBuilder.Append("[nm_destinatario], ");
		stringBuilder.Append("[nm_cnpj_destinatario], ");
		stringBuilder.Append("[ds_situacao_nfe], ");
		stringBuilder.Append("[cd_lote], ");
		stringBuilder.Append("[cd_emissao], ");
		stringBuilder.Append("[vl_pis_retido], ");
		stringBuilder.Append("[vl_cofins_retido], ");
		stringBuilder.Append("[vl_total_fatura], ");
		stringBuilder.Append("[cd_tipo_entidade], ");
		stringBuilder.Append("[vl_peso_bruto], ");
		stringBuilder.Append("[vl_peso_liquido], ");
		stringBuilder.Append("[vl_numero_embalagens], ");
		stringBuilder.Append("[ds_texto_legal], ");
		stringBuilder.Append("[cd_tipo_nota], ");
		stringBuilder.Append("[cd_nota_referenciada], ");
		stringBuilder.Append("[ic_consumidor_final], ");
		stringBuilder.Append("[cd_condicao_pagamento], ");
		stringBuilder.Append("[vl_imposto_importacao], ");
		stringBuilder.Append("[ic_transportadora_cliente], ");
		stringBuilder.Append("[vl_cambio], ");
		stringBuilder.Append("[cd_suframa], ");
		stringBuilder.Append("[nm_placa_caminhao], ");
		stringBuilder.Append("[cd_tipo_entidade_entrega], ");
		stringBuilder.Append("[cd_entidade_entrega], ");
		stringBuilder.Append("[vl_total_fundo_pobreza_uf_destino], ");
		stringBuilder.Append("[vl_total_icms_interestadual_uf_destino], ");
		stringBuilder.Append("[vl_total_icms_interestadual_uf_remetente], ");
		stringBuilder.Append("[nm_portao_entrega], ");
		stringBuilder.Append("[vl_credito_icms], ");
		stringBuilder.Append("[pc_credito_icms], ");
		stringBuilder.Append("[vl_desconto], ");
		stringBuilder.Append("[vl_icms_deson], ");
		stringBuilder.Append("[ic_bloquear_recalculo_fatura], ");
		stringBuilder.Append("[cd_edi], ");
		stringBuilder.Append("[cd_ctrl_reajuste], ");
		stringBuilder.Append("[cd_indicador_presenca], ");
		stringBuilder.Append("[cd_modelo_doc_fiscal_referenciado], ");
		stringBuilder.Append("[cd_modalidade_frete], ");
		stringBuilder.Append("[vl_bc_fcp], ");
		stringBuilder.Append("[vl_fcp], ");
		stringBuilder.Append("[vl_bc_fcpst], ");
		stringBuilder.Append("[vl_fcpst], ");
		stringBuilder.Append("[ic_comissao_apurada], ");
		stringBuilder.Append("[nm_tipo_volume], ");
		stringBuilder.Append("[cd_conta_contabil]) Values (@cd_empresa,@cd_nota_fiscal,@cd_serie_nota_fiscal,@nm_serie_nota_fiscal,@cd_cfop,@nm_cfop,@ds_cfop,@cd_fe,@cd_forma_pagto,@cd_transportadora,@cd_entidade,@ic_frete_emitente,@ic_saida,@dt_emissao,@dt_saida,@dt_emissao_nfe,@dt_cancelamento,@dt_cancelamento_nfe,@ds_motivo_cancelamento,@cd_emissor,@cd_cancelou,@cd_enviou_nfe,@vl_base_icms,@vl_icms,@vl_base_icms_sub,@vl_icms_sub,@vl_ipi,@vl_pis,@vl_csll,@vl_produtos,@vl_frete,@vl_seguro,@vl_outras_despesas,@vl_cofins,@vl_imposto_retido,@vl_total_nota,@nm_chave_nfe,@nm_protocolo_nfe,@cd_texto_legal1,@cd_texto_legal2,@nm_destinatario,@nm_cnpj_destinatario,@ds_situacao_nfe,@cd_lote,@cd_emissao,@vl_pis_retido,@vl_cofins_retido,@vl_total_fatura,@cd_tipo_entidade,@vl_peso_bruto,@vl_peso_liquido,@vl_numero_embalagens,@ds_texto_legal,@cd_tipo_nota,@cd_nota_referenciada,@ic_consumidor_final,@cd_condicao_pagamento,@vl_imposto_importacao,@ic_transportadora_cliente,@vl_cambio,@cd_suframa,@nm_placa_caminhao,@cd_tipo_entidade_entrega,@cd_entidade_entrega,@vl_total_fundo_pobreza_uf_destino,@vl_total_icms_interestadual_uf_destino,@vl_total_icms_interestadual_uf_remetente,@nm_portao_entrega,@vl_credito_icms,@pc_credito_icms,@vl_desconto,@vl_icms_deson,@ic_bloquear_recalculo_fatura,@cd_edi,@cd_ctrl_reajuste,@cd_indicador_presenca,@cd_modelo_doc_fiscal_referenciado,@cd_modalidade_frete,@vl_bc_fcp,@vl_fcp,@vl_bc_fcpst,@vl_fcpst,@ic_comissao_apurada,@nm_tipo_volume,@cd_conta_contabil) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscais.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscais.numeroNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", NotaFiscalNotasFiscais.codigoSerieNF));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_serie_nota_fiscal", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.serieNotaFiscal) ? string.Empty : NotaFiscalNotasFiscais.serieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cfop", NotaFiscalNotasFiscais.codigoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cfop", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.numeracaoCFOP) ? string.Empty : NotaFiscalNotasFiscais.numeracaoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_cfop", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.descricaoCFOP) ? string.Empty : NotaFiscalNotasFiscais.descricaoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_fe", NotaFiscalNotasFiscais.codigoFichaExpedicao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_forma_pagto", NotaFiscalNotasFiscais.codigoFormaPagto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_transportadora", NotaFiscalNotasFiscais.codigoTransportadora));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade", NotaFiscalNotasFiscais.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_frete_emitente", NotaFiscalNotasFiscais.isFretePagoPeloEmitente));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_saida", NotaFiscalNotasFiscais.isNotaFiscalEntrada));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_emissao", NotaFiscalNotasFiscais.dataEmissao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_saida", NotaFiscalNotasFiscais.dataSaida));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_emissao_nfe", NotaFiscalNotasFiscais.dataEnvioNFE));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_cancelamento", NotaFiscalNotasFiscais.dataCancelamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_cancelamento_nfe", NotaFiscalNotasFiscais.dataCancelamentoNFE));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_motivo_cancelamento", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.motivoCancelamento) ? string.Empty : NotaFiscalNotasFiscais.motivoCancelamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_emissor", NotaFiscalNotasFiscais.codigoEmissor));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cancelou", NotaFiscalNotasFiscais.codigoResponsavelCancelamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_enviou_nfe", NotaFiscalNotasFiscais.codigoResponsavelEnvioNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_icms", NotaFiscalNotasFiscais.valorBaseICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms", NotaFiscalNotasFiscais.valorICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_icms_sub", NotaFiscalNotasFiscais.valorBaseICMSSubstituto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms_sub", NotaFiscalNotasFiscais.valorICMSSubstituto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ipi", NotaFiscalNotasFiscais.valorIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_pis", NotaFiscalNotasFiscais.valorPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_csll", NotaFiscalNotasFiscais.valorCSLL));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_produtos", NotaFiscalNotasFiscais.valorProdutos));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_frete", NotaFiscalNotasFiscais.valorFrete));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_seguro", NotaFiscalNotasFiscais.valorSeguro));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_outras_despesas", NotaFiscalNotasFiscais.valorOutrasDespesas));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_cofins", NotaFiscalNotasFiscais.valorCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_imposto_retido", NotaFiscalNotasFiscais.valorImpostoRetido));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total_nota", NotaFiscalNotasFiscais.valorTotalNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_chave_nfe", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.chaveNfe) ? string.Empty : NotaFiscalNotasFiscais.chaveNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_protocolo_nfe", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.protocoloNfe) ? string.Empty : NotaFiscalNotasFiscais.protocoloNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_texto_legal1", NotaFiscalNotasFiscais.codigoTextoLegal1));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_texto_legal2", NotaFiscalNotasFiscais.codigoTextoLegal2));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_destinatario", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.razaoSocialDestinatario) ? string.Empty : NotaFiscalNotasFiscais.razaoSocialDestinatario));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cnpj_destinatario", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.cnpjDestinatario) ? string.Empty : NotaFiscalNotasFiscais.cnpjDestinatario));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_situacao_nfe", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.situacaoNfe) ? string.Empty : NotaFiscalNotasFiscais.situacaoNfe));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_lote", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.codigoLote) ? string.Empty : NotaFiscalNotasFiscais.codigoLote));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_emissao", NotaFiscalNotasFiscais.tipoEmissao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_pis_retido", NotaFiscalNotasFiscais.valorPISRetido));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_cofins_retido", NotaFiscalNotasFiscais.valorCofinsRetido));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total_fatura", NotaFiscalNotasFiscais.valorTotalFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_entidade", NotaFiscalNotasFiscais.tipoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_peso_bruto", NotaFiscalNotasFiscais.pesoBruto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_peso_liquido", NotaFiscalNotasFiscais.pesoLiquido));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_numero_embalagens", NotaFiscalNotasFiscais.qtVolumes));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_texto_legal", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.textoLegal) ? string.Empty : NotaFiscalNotasFiscais.textoLegal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_nota", NotaFiscalNotasFiscais.tipoNota));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_referenciada", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.notaReferenciada) ? string.Empty : NotaFiscalNotasFiscais.notaReferenciada));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_consumidor_final", NotaFiscalNotasFiscais.isConsumidorFinal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_condicao_pagamento", NotaFiscalNotasFiscais.codigoCondicaoPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_imposto_importacao", NotaFiscalNotasFiscais.valorImpostoImportacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_transportadora_cliente", NotaFiscalNotasFiscais.isFreteCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_cambio", NotaFiscalNotasFiscais.valorCambio));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_suframa", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.suframa) ? string.Empty : NotaFiscalNotasFiscais.suframa));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_placa_caminhao", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscais.placaCaminhao) ? string.Empty : NotaFiscalNotasFiscais.placaCaminhao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_entidade_entrega", NotaFiscalNotasFiscais.codigoTipoEntidadeEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade_entrega", NotaFiscalNotasFiscais.codigoEntidadeEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total_fundo_pobreza_uf_destino", NotaFiscalNotasFiscais.valorTotalIcmsInterestadualFundoPobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total_icms_interestadual_uf_destino", NotaFiscalNotasFiscais.valorTotalIcmsInterestadualUfDestino));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total_icms_interestadual_uf_remetente", NotaFiscalNotasFiscais.valorTotalIcmsInterestadualUfEnvolvidas));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_portao_entrega", NotaFiscalNotasFiscais.portaoEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_credito_icms", NotaFiscalNotasFiscais.valorCreditoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_credito_icms", NotaFiscalNotasFiscais.percentualCreditoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_desconto", NotaFiscalNotasFiscais.valorDesconto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms_deson", NotaFiscalNotasFiscais.valorIcmsDesonerado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_bloquear_recalculo_fatura", NotaFiscalNotasFiscais.isBloquearRecalculoFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_edi", NotaFiscalNotasFiscais.codigoEDI));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ctrl_reajuste", NotaFiscalNotasFiscais.codigoControleReajuste));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_indicador_presenca", NotaFiscalNotasFiscais.codigoIndicadorPresenca));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modelo_doc_fiscal_referenciado", NotaFiscalNotasFiscais.codigoModeloDocumentoFiscalReferenciado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modalidade_frete", NotaFiscalNotasFiscais.codigoModalidadeFrete));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_bc_fcp", NotaFiscalNotasFiscais.valorBaseCalculoFundoCombatePobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_fcp", NotaFiscalNotasFiscais.valorFundoCombatePobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_bc_fcpst", NotaFiscalNotasFiscais.valorBaseCalculoFundoCombatePobrezaST));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_fcpst", NotaFiscalNotasFiscais.valorFundoCombatePobrezaST));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_comissao_apurada", NotaFiscalNotasFiscais.isComissaoApurada));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_volume", NotaFiscalNotasFiscais.tipoVolume));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_conta_contabil", NotaFiscalNotasFiscais.codigoContaContabil));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[NotasFiscais] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SerieNotaFiscal", "nm_serie_nota_fiscal", NotaFiscalNotasFiscais.serieNotaFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCFOP", "cd_cfop", NotaFiscalNotasFiscais.codigoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeracaoCFOP", "nm_cfop", NotaFiscalNotasFiscais.numeracaoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoCFOP", "ds_cfop", NotaFiscalNotasFiscais.descricaoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFichaExpedicao", "cd_fe", NotaFiscalNotasFiscais.codigoFichaExpedicao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFormaPagto", "cd_forma_pagto", NotaFiscalNotasFiscais.codigoFormaPagto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTransportadora", "cd_transportadora", NotaFiscalNotasFiscais.codigoTransportadora, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "cd_entidade", NotaFiscalNotasFiscais.codigoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFretePagoPeloEmitente", "ic_frete_emitente", NotaFiscalNotasFiscais.isFretePagoPeloEmitente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsNotaFiscalEntrada", "ic_saida", NotaFiscalNotasFiscais.isNotaFiscalEntrada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEmissao", "dt_emissao", NotaFiscalNotasFiscais.dataEmissao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataSaida", "dt_saida", NotaFiscalNotasFiscais.dataSaida, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEnvioNFE", "dt_emissao_nfe", NotaFiscalNotasFiscais.dataEnvioNFE, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCancelamento", "dt_cancelamento", NotaFiscalNotasFiscais.dataCancelamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCancelamentoNFE", "dt_cancelamento_nfe", NotaFiscalNotasFiscais.dataCancelamentoNFE, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "MotivoCancelamento", "ds_motivo_cancelamento", NotaFiscalNotasFiscais.motivoCancelamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmissor", "cd_emissor", NotaFiscalNotasFiscais.codigoEmissor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoResponsavelCancelamento", "cd_cancelou", NotaFiscalNotasFiscais.codigoResponsavelCancelamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoResponsavelEnvioNfe", "cd_enviou_nfe", NotaFiscalNotasFiscais.codigoResponsavelEnvioNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseICMS", "vl_base_icms", NotaFiscalNotasFiscais.valorBaseICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorICMS", "vl_icms", NotaFiscalNotasFiscais.valorICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseICMSSubstituto", "vl_base_icms_sub", NotaFiscalNotasFiscais.valorBaseICMSSubstituto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorICMSSubstituto", "vl_icms_sub", NotaFiscalNotasFiscais.valorICMSSubstituto, camposAlterados));
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
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTextoLegal1", "cd_texto_legal1", NotaFiscalNotasFiscais.codigoTextoLegal1, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTextoLegal2", "cd_texto_legal2", NotaFiscalNotasFiscais.codigoTextoLegal2, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RazaoSocialDestinatario", "nm_destinatario", NotaFiscalNotasFiscais.razaoSocialDestinatario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CnpjDestinatario", "nm_cnpj_destinatario", NotaFiscalNotasFiscais.cnpjDestinatario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SituacaoNfe", "ds_situacao_nfe", NotaFiscalNotasFiscais.situacaoNfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoLote", "cd_lote", NotaFiscalNotasFiscais.codigoLote, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoEmissao", "cd_emissao", NotaFiscalNotasFiscais.tipoEmissao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorPISRetido", "vl_pis_retido", NotaFiscalNotasFiscais.valorPISRetido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCofinsRetido", "vl_cofins_retido", NotaFiscalNotasFiscais.valorCofinsRetido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotalFatura", "vl_total_fatura", NotaFiscalNotasFiscais.valorTotalFatura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoEntidade", "cd_tipo_entidade", NotaFiscalNotasFiscais.tipoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PesoBruto", "vl_peso_bruto", NotaFiscalNotasFiscais.pesoBruto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PesoLiquido", "vl_peso_liquido", NotaFiscalNotasFiscais.pesoLiquido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeVolumes", "vl_numero_embalagens", NotaFiscalNotasFiscais.qtVolumes, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TextoLegal", "ds_texto_legal", NotaFiscalNotasFiscais.textoLegal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoNota", "cd_tipo_nota", NotaFiscalNotasFiscais.tipoNota, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NotaReferenciada", "cd_nota_referenciada", NotaFiscalNotasFiscais.notaReferenciada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsConsumidorFinal", "ic_consumidor_final", NotaFiscalNotasFiscais.isConsumidorFinal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCondicaoPagamento", "cd_condicao_pagamento", NotaFiscalNotasFiscais.codigoCondicaoPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorImpostoImportacao", "vl_imposto_importacao", NotaFiscalNotasFiscais.valorImpostoImportacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFreteCliente", "ic_transportadora_cliente", NotaFiscalNotasFiscais.isFreteCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCambio", "vl_cambio", NotaFiscalNotasFiscais.valorCambio, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Suframa", "cd_suframa", NotaFiscalNotasFiscais.suframa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PlacaCaminhao", "nm_placa_caminhao", NotaFiscalNotasFiscais.placaCaminhao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoEntidadeEntrega", "cd_tipo_entidade_entrega", NotaFiscalNotasFiscais.codigoTipoEntidadeEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeEntrega", "cd_entidade_entrega", NotaFiscalNotasFiscais.codigoEntidadeEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotalIcmsInterestadualFundoPobreza", "vl_total_fundo_pobreza_uf_destino", NotaFiscalNotasFiscais.valorTotalIcmsInterestadualFundoPobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotalIcmsInterestadualUfDestino", "vl_total_icms_interestadual_uf_destino", NotaFiscalNotasFiscais.valorTotalIcmsInterestadualUfDestino, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotalIcmsInterestadualUfEnvolvidas", "vl_total_icms_interestadual_uf_remetente", NotaFiscalNotasFiscais.valorTotalIcmsInterestadualUfEnvolvidas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PortaoEntrega", "nm_portao_entrega", NotaFiscalNotasFiscais.portaoEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCreditoIcms", "vl_credito_icms", NotaFiscalNotasFiscais.valorCreditoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualCreditoIcms", "pc_credito_icms", NotaFiscalNotasFiscais.percentualCreditoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDesconto", "vl_desconto", NotaFiscalNotasFiscais.valorDesconto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsDesonerado", "vl_icms_deson", NotaFiscalNotasFiscais.valorIcmsDesonerado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsBloquearRecalculoFatura", "ic_bloquear_recalculo_fatura", NotaFiscalNotasFiscais.isBloquearRecalculoFatura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEDI", "cd_edi", NotaFiscalNotasFiscais.codigoEDI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoControleReajuste", "cd_ctrl_reajuste", NotaFiscalNotasFiscais.codigoControleReajuste, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoIndicadorPresenca", "cd_indicador_presenca", NotaFiscalNotasFiscais.codigoIndicadorPresenca, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModeloDocumentoFiscalReferenciado", "cd_modelo_doc_fiscal_referenciado", NotaFiscalNotasFiscais.codigoModeloDocumentoFiscalReferenciado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModalidadeFrete", "cd_modalidade_frete", NotaFiscalNotasFiscais.codigoModalidadeFrete, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoFundoCombatePobreza", "vl_bc_fcp", NotaFiscalNotasFiscais.valorBaseCalculoFundoCombatePobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFundoCombatePobreza", "vl_fcp", NotaFiscalNotasFiscais.valorFundoCombatePobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoFundoCombatePobrezaST", "vl_bc_fcpst", NotaFiscalNotasFiscais.valorBaseCalculoFundoCombatePobrezaST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFundoCombatePobrezaST", "vl_fcpst", NotaFiscalNotasFiscais.valorFundoCombatePobrezaST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsComissaoApurada", "ic_comissao_apurada", NotaFiscalNotasFiscais.isComissaoApurada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoVolume", "nm_tipo_volume", NotaFiscalNotasFiscais.tipoVolume, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "cd_conta_contabil", NotaFiscalNotasFiscais.codigoContaContabil, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_empresa = @cd_empresa and ");
			stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
			stringBuilder.Append("cd_serie_nota_fiscal = @cd_serie_nota_fiscal");
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscais.codigoEmpresa));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscais.numeroNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", NotaFiscalNotasFiscais.codigoSerieNF));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoNotaFiscalSerie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Delete from [{0}].[{1}].[NotaFiscal].[NotasFiscais] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append(" Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", codigoNotaFiscalSerie));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ObterUltimaNota(int codigoEmpresa, int serie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SELECT Max([cd_nota_fiscal]) as Numero ");
		stringBuilder.AppendFormat("FROM [{0}].[{1}].[NotaFiscal].[NotasFiscais] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", serie));
		DataRow dataRow = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return BaseDadosERP.ObterDbValor<int>(dataRow["Numero"]);
	}

	public bool ChecarSeNotaExiste(int codigoEmpresa, int numeroNota, int serie)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SELECT Count([cd_nota_fiscal])  as qde ");
		stringBuilder.AppendFormat("FROM [{0}].[{1}].[NotaFiscal].[NotasFiscais] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", numeroNota));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", serie));
		bool result = false;
		DataRow dataRow = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		int num = BaseDadosERP.ObterDbValor<int>(dataRow["qde"]);
		if (num > 0)
		{
			result = true;
		}
		return result;
	}

	public IList<MapTableResumoFaturamentoItem> ObterRelatorioFaturamento(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select \r\n\t                    [NF].[cd_entidade] as codigoCliente\r\n                        ,[NF].[cd_tipo_nota] as tipoNota\r\n\t                    ,[NFI].[cd_produto] as codigoProduto\r\n\t                    ,SUM([NFI].[vl_quantidade]) as quantidade\r\n                        ,MAX([NFI].[vl_unitario]) as valorUnitario\r\n                        ,SUM([NFI].[vl_total]) as valorTotal\r\n                        ,SUM([NFI].[vl_icms] + [NFI].[vl_ipi] + [NFI].[vl_pis] + [NFI].[vl_cofins]) as valorImposto\r\n                        ,[NFI].[nm_cfop] as cfop\r\n                        ,[NFI].[sg_unidade] as unidade\r\n                        ,[NFI].[cd_conta_contabil_analitica] as contaContabil ");
		stringBuilder.Append($"FROM [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscais] NF ");
		stringBuilder.Append($"inner join [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisItens] NFI ");
		stringBuilder.Append("on [NF].[cd_empresa] = [nfi].[cd_empresa] ");
		stringBuilder.Append("and [NF].[cd_nota_fiscal] = [nfi].[cd_nota_fiscal] ");
		stringBuilder.Append("where [NF].[ds_situacao_nfe] in ('Sucesso','SucessoContingencia','SistemaLegado')\r\n                      and [NF].[dt_emissao] between  @dataInicio and @dataFim\r\n                      and [NF].[vl_total_fatura] > 0 or [NF].[cd_tipo_nota] = 4\r\n                      and [NF].[cd_tipo_entidade] = 1\r\n                      and [NFI].[ic_gera_duplicata] = 1\r\n  \r\n                      group by\r\n\t                    [NF].[cd_entidade]\r\n                        ,[NF].[cd_tipo_nota]\r\n\t                    ,[NFI].[cd_produto]\r\n\t                    ,[NFI].[nm_cfop]\r\n                        ,[NFI].[sg_unidade]\r\n                        ,[NFI].[ic_gera_duplicata]\r\n                        ,[NFI].[cd_conta_contabil_analitica]");
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableResumoFaturamentoItem> list2 = new List<MapTableResumoFaturamentoItem>();
		foreach (DataRow row in dataTable.Rows)
		{
			int num = BaseDadosERP.ObterDbValor<int>(row["tipoNota"]);
			int num2 = ((num != 4) ? 1 : (-1));
			list2.Add(new MapTableResumoFaturamentoItem
			{
				codigoCliente = BaseDadosERP.ObterDbValor<int>(row["codigoCliente"]),
				codigoProduto = BaseDadosERP.ObterDbValor<string>(row["codigoProduto"]),
				quantidade = BaseDadosERP.ObterDbValor<decimal>(row["quantidade"]),
				valorUnitario = BaseDadosERP.ObterDbValor<decimal>(row["valorUnitario"]) * (decimal)num2,
				valorTotal = BaseDadosERP.ObterDbValor<decimal>(row["valorTotal"]) * (decimal)num2,
				valorImposto = BaseDadosERP.ObterDbValor<decimal>(row["valorImposto"]) * (decimal)num2,
				cfop = BaseDadosERP.ObterDbValor<string>(row["cfop"]),
				unidade = BaseDadosERP.ObterDbValor<string>(row["unidade"]),
				contaContabil = BaseDadosERP.ObterDbValor<string>(row["contaContabil"])
			});
		}
		return list2;
	}

	public IList<MapTableResumoFaturamentoItem> ObterRelatorioFaturamento(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select \r\n\t                    [NF].[cd_entidade] as codigoCliente\r\n                        ,[NF].[cd_tipo_nota] as tipoNota\r\n\t                    ,[NFI].[cd_produto] as codigoProduto\r\n\t                    ,SUM([NFI].[vl_quantidade]) as quantidade\r\n                        ,MAX([NFI].[vl_unitario]) as valorUnitario\r\n                        ,SUM([NFI].[vl_total]) as valorTotal\r\n                        ,SUM([NFI].[vl_icms] + [NFI].[vl_ipi] + [NFI].[vl_pis] + [NFI].[vl_cofins]) as valorImposto\r\n                        ,[NFI].[nm_cfop] as cfop\r\n                        ,[NFI].[sg_unidade] as unidade\r\n                        ,[NFI].[cd_conta_contabil_analitica] as contaContabil ");
		stringBuilder.Append($"FROM [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscais] NF ");
		stringBuilder.Append($"inner join [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisItens] NFI ");
		stringBuilder.Append("on [NF].[cd_empresa] = [nfi].[cd_empresa] ");
		stringBuilder.Append("and [NF].[cd_nota_fiscal] = [nfi].[cd_nota_fiscal] ");
		stringBuilder.Append("where [NF].[ds_situacao_nfe] in ('Sucesso','SucessoContingencia','SistemaLegado')\r\n                      and [NF].[dt_emissao] between  @dataInicio and @dataFim\r\n                      and [NF].[vl_total_fatura] > 0 or [NF].[cd_tipo_nota] = 4\r\n                      and [NF].[cd_empresa] = @cd_empresa\r\n                      and [NF].[cd_tipo_entidade] = 1\r\n                      and [NFI].[ic_gera_duplicata] = 1\r\n  \r\n                      group by\r\n\t                    [NF].[cd_entidade]\r\n                        ,[NF].[cd_tipo_nota]\r\n\t                    ,[NFI].[cd_produto]\r\n\t                    ,[NFI].[nm_cfop]\r\n                        ,[NFI].[sg_unidade]\r\n                        ,[NFI].[ic_gera_duplicata]\r\n                        ,[NFI].[cd_conta_contabil_analitica]");
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableResumoFaturamentoItem> list2 = new List<MapTableResumoFaturamentoItem>();
		foreach (DataRow row in dataTable.Rows)
		{
			int num = BaseDadosERP.ObterDbValor<int>(row["tipoNota"]);
			int num2 = ((num != 4) ? 1 : (-1));
			list2.Add(new MapTableResumoFaturamentoItem
			{
				codigoCliente = BaseDadosERP.ObterDbValor<int>(row["codigoCliente"]),
				codigoProduto = BaseDadosERP.ObterDbValor<string>(row["codigoProduto"]),
				quantidade = BaseDadosERP.ObterDbValor<decimal>(row["quantidade"]),
				valorUnitario = BaseDadosERP.ObterDbValor<decimal>(row["valorUnitario"]) * (decimal)num2,
				valorTotal = BaseDadosERP.ObterDbValor<decimal>(row["valorTotal"]) * (decimal)num2,
				valorImposto = BaseDadosERP.ObterDbValor<decimal>(row["valorImposto"]) * (decimal)num2,
				cfop = BaseDadosERP.ObterDbValor<string>(row["cfop"]),
				unidade = BaseDadosERP.ObterDbValor<string>(row["unidade"]),
				contaContabil = BaseDadosERP.ObterDbValor<string>(row["contaContabil"])
			});
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal and ");
		stringBuilder.Append(" [dt_emissao] between @dataInicio and @dataFim");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", 9999));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(int codigoEmpresa, DateTime dataInicio, DateTime dataFim)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] = @cd_serie_nota_fiscal and ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [dt_emissao] between @dataInicio and @dataFim");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nota_fiscal", 9999));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", dataInicio));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", dataFim.AddDays(1.0).AddSeconds(-1.0)));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int tipo, int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_entidade] = @cd_entidade ");
		stringBuilder.Append(" and [cd_tipo_entidade] = @cd_tipo_entidade ");
		stringBuilder.Append(" and [cd_serie_nota_fiscal] < 9000 ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade", codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_entidade", tipo));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoNota(int codigoNota)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNota));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoPedidoVenda(int codigoPedidoVenda)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [cd_nota_fiscal] in ");
		stringBuilder.AppendFormat("(SELECT[cd_nota_fiscal] ");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_pedido_venda] = @cd_pedido_venda)");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", codigoPedidoVenda));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoProduto(string codigoProduto)
	{
		string valor = $"%{codigoProduto}%";
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [cd_nota_fiscal] in ");
		stringBuilder.AppendFormat("(SELECT[cd_nota_fiscal] ");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_produto] like @cd_produto)");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", valor));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoContrato(string codigoContrato)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_serie_nota_fiscal] < 9000 and ");
		stringBuilder.Append(" [cd_nota_fiscal] in ");
		stringBuilder.AppendFormat("(SELECT[cd_nota_fiscal] ");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_pedido_compra_cliente] = @nm_pedido_compra_cliente)");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_pedido_compra_cliente", codigoContrato));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscais> list2 = new List<MapTableNotaFiscalNotasFiscais>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}
}
