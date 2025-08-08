using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalNotasFiscaisItens : INotaFiscalNotasFiscaisItens
{
	private MapTableNotaFiscalNotasFiscaisItens MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscaisItens result = default(MapTableNotaFiscalNotasFiscaisItens);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.ordem = BaseDadosERP.ObterDbValor<int>(row["ordem"]);
			result.codigoProduto = BaseDadosERP.ObterDbValor<string>(row["codigoProduto"]);
			result.descricaoProduto = BaseDadosERP.ObterDbValor<string>(row["descricaoProduto"]);
			result.quantidade = BaseDadosERP.ObterDbValor<decimal>(row["quantidade"]);
			result.valorUnitario = BaseDadosERP.ObterDbValor<decimal>(row["valorUnitario"]);
			result.valorTotal = BaseDadosERP.ObterDbValor<decimal>(row["valorTotal"]);
			result.valorBaseICMS = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseICMS"]);
			result.aliquotaICMS = BaseDadosERP.ObterDbValor<decimal>(row["aliquotaICMS"]);
			result.valorICMS = BaseDadosERP.ObterDbValor<decimal>(row["valorICMS"]);
			result.aliquotaIPI = BaseDadosERP.ObterDbValor<decimal>(row["aliquotaIPI"]);
			result.valorIPI = BaseDadosERP.ObterDbValor<decimal>(row["valorIPI"]);
			result.valorPIS = BaseDadosERP.ObterDbValor<decimal>(row["valorPIS"]);
			result.valorCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorCofins"]);
			result.valorFrete = BaseDadosERP.ObterDbValor<decimal>(row["valorFrete"]);
			result.valorSeguro = BaseDadosERP.ObterDbValor<decimal>(row["valorSeguro"]);
			result.codigoClassificacaoFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoClassificacaoFiscal"]);
			result.codigoSituacaoTributaria = BaseDadosERP.ObterDbValor<int>(row["codigoSituacaoTributaria"]);
			result.nomeCfop = BaseDadosERP.ObterDbValor<string>(row["nomeCfop"]);
			result.codigoCFOPInterna = BaseDadosERP.ObterDbValor<int>(row["codigoCFOPInterna"]);
			result.codigoFichaExpedicao = BaseDadosERP.ObterDbValor<int>(row["codigoFichaExpedicao"]);
			result.codigoFichaExpedicaoItem = BaseDadosERP.ObterDbValor<int>(row["codigoFichaExpedicaoItem"]);
			result.siglaUnidadeFaturamento = BaseDadosERP.ObterDbValor<string>(row["siglaUnidadeFaturamento"]);
			result.valorFatura = BaseDadosERP.ObterDbValor<decimal>(row["valorFatura"]);
			result.codigoOrigemProduto = BaseDadosERP.ObterDbValor<string>(row["codigoOrigemProduto"]);
			result.valorBaseReducaoSemFrete = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseReducaoSemFrete"]);
			result.percentualBaseReducaoIcms = BaseDadosERP.ObterDbValor<decimal>(row["percentualBaseReducaoIcms"]);
			result.codigoModalidadeIcms = BaseDadosERP.ObterDbValor<string>(row["codigoModalidadeIcms"]);
			result.tipoIncidenciaIcms = BaseDadosERP.ObterDbValor<string>(row["tipoIncidenciaIcms"]);
			result.tipoIncidenciaIpi = BaseDadosERP.ObterDbValor<string>(row["tipoIncidenciaIpi"]);
			result.tipoIncidenciaPis = BaseDadosERP.ObterDbValor<string>(row["tipoIncidenciaPis"]);
			result.tipoIncidenciaCofins = BaseDadosERP.ObterDbValor<string>(row["tipoIncidenciaCofins"]);
			result.aliquotaPis = BaseDadosERP.ObterDbValor<decimal>(row["aliquotaPis"]);
			result.percentualRetencaoPis = BaseDadosERP.ObterDbValor<decimal>(row["percentualRetencaoPis"]);
			result.valorRetencaoPis = BaseDadosERP.ObterDbValor<decimal>(row["valorRetencaoPis"]);
			result.aliquotaCofins = BaseDadosERP.ObterDbValor<decimal>(row["aliquotaCofins"]);
			result.percentualRetencaoCofins = BaseDadosERP.ObterDbValor<decimal>(row["percentualRetencaoCofins"]);
			result.valorRetencaoCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorRetencaoCofins"]);
			result.codigoPedidoVenda = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoVenda"]);
			result.codigoPedidoVendaItem = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoVendaItem"]);
			result.codigoPedidoCompra = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoCompra"]);
			result.codigoPedidoCompraItem = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoCompraItem"]);
			result.isCsll = BaseDadosERP.ObterDbValor<bool>(row["isCsll"]);
			result.percentualCsll = BaseDadosERP.ObterDbValor<decimal>(row["percentualCsll"]);
			result.valorCsll = BaseDadosERP.ObterDbValor<decimal>(row["valorCsll"]);
			result.isGeraDuplicata = BaseDadosERP.ObterDbValor<bool>(row["isGeraDuplicata"]);
			result.isConsumidorFinal = BaseDadosERP.ObterDbValor<bool>(row["isConsumidorFinal"]);
			result.codigoSerieNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoAuxiliarAtualizacaoNotaFiscal = BaseDadosERP.ObterDbValor<int>(row["codigoAuxiliarAtualizacaoNotaFiscal"]);
			result.descricaoComplementar = BaseDadosERP.ObterDbValor<string>(row["descricaoComplementar"]);
			result.contaContabilAnalitica = BaseDadosERP.ObterDbValor<string>(row["contaContabilAnalitica"]);
			result.codigoPedidoCompraCliente = BaseDadosERP.ObterDbValor<string>(row["codigoPedidoCompraCliente"]);
			result.codigoPedidoCompraItemCliente = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoCompraItemCliente"]);
			result.codigoGrupoEstoqueGPS = BaseDadosERP.ObterDbValor<int>(row["codigoGrupoEstoqueGPS"]);
			result.codigoProdutoGPS = BaseDadosERP.ObterDbValor<string>(row["codigoProdutoGPS"]);
			result.codigoTipoProdutoGPS = BaseDadosERP.ObterDbValor<int>(row["codigoTipoProdutoGPS"]);
			result.valorDimensao01GPS = BaseDadosERP.ObterDbValor<decimal>(row["valorDimensao01GPS"]);
			result.valorDimensao02GPS = BaseDadosERP.ObterDbValor<decimal>(row["valorDimensao02GPS"]);
			result.valorDimensao03GPS = BaseDadosERP.ObterDbValor<decimal>(row["valorDimensao03GPS"]);
			result.codigoClienteEntidadeGPS = BaseDadosERP.ObterDbValor<int>(row["codigoClienteEntidadeGPS"]);
			result.codigoModalidadeICMSST = BaseDadosERP.ObterDbValor<int>(row["codigoModalidadeICMSST"]);
			result.percentualBaseAgragadaICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualBaseAgragadaICMSST"]);
			result.valorBaseAgragadaICMSST = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseAgragadaICMSST"]);
			result.valorICMSSTAgregado = BaseDadosERP.ObterDbValor<decimal>(row["valorICMSSTAgregado"]);
			result.codigoRecebimentoMaterialCliente = BaseDadosERP.ObterDbValor<int>(row["codigoRecebimentoMaterialCliente"]);
			result.percentualICMSSTAgregado = BaseDadosERP.ObterDbValor<decimal>(row["percentualICMSSTAgregado"]);
			result.valorBaseCalculoIpi = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoIpi"]);
			result.valorBaseCalculoPis = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoPis"]);
			result.valorBaseCalculoCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoCofins"]);
			result.valorBaseCalculoImpostoImportacao = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoImpostoImportacao"]);
			result.valorOutros = BaseDadosERP.ObterDbValor<decimal>(row["valorOutros"]);
			result.valorDespesasAduaneiras = BaseDadosERP.ObterDbValor<decimal>(row["valorDespesasAduaneiras"]);
			result.valorImpostoImportacao = BaseDadosERP.ObterDbValor<decimal>(row["valorImpostoImportacao"]);
			result.valorIof = BaseDadosERP.ObterDbValor<decimal>(row["valorIof"]);
			result.contratoCliente = BaseDadosERP.ObterDbValor<string>(row["contratoCliente"]);
			result.contratoClienteItem = BaseDadosERP.ObterDbValor<int>(row["contratoClienteItem"]);
			result.codigoEnquadramentoIPI = BaseDadosERP.ObterDbValor<int>(row["codigoEnquadramentoIPI"]);
			result.codigoEan = BaseDadosERP.ObterDbValor<string>(row["codigoEan"]);
			result.percentualII = BaseDadosERP.ObterDbValor<decimal>(row["percentualII"]);
			result.valorSiscomex = BaseDadosERP.ObterDbValor<decimal>(row["valorSiscomex"]);
			result.valorMarinhaMercante = BaseDadosERP.ObterDbValor<decimal>(row["valorMarinhaMercante"]);
			result.pecasPorEtiqueta = BaseDadosERP.ObterDbValor<int>(row["pecasPorEtiqueta"]);
			result.percentualCreditoIcms = BaseDadosERP.ObterDbValor<decimal>(row["percentualCreditoIcms"]);
			result.valorCreditoIcms = BaseDadosERP.ObterDbValor<decimal>(row["valorCreditoIcms"]);
			result.cest = BaseDadosERP.ObterDbValor<string>(row["cest"]);
			result.isICMSInterestadual = BaseDadosERP.ObterDbValor<bool>(row["isICMSInterestadual"]);
			result.percentualIcmsInterestadualFundoPobreza = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsInterestadualFundoPobreza"]);
			result.valorIcmsInterestadualFundoPobreza = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsInterestadualFundoPobreza"]);
			result.percentualIcmsInterestadualUfDestino = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsInterestadualUfDestino"]);
			result.valorIcmsInterestadualUfDestino = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsInterestadualUfDestino"]);
			result.percentualIcmsInterestadualUfEnvolvidas = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsInterestadualUfEnvolvidas"]);
			result.valorIcmsInterestadualUfEnvolvidas = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsInterestadualUfEnvolvidas"]);
			result.tagXml = BaseDadosERP.ObterDbValor<string>(row["tagXml"]);
			result.codigoEmbalagem = BaseDadosERP.ObterDbValor<string>(row["codigoEmbalagem"]);
			result.quantidadeEmbalagem = BaseDadosERP.ObterDbValor<int>(row["quantidadeEmbalagem"]);
			result.pesoLiquido = BaseDadosERP.ObterDbValor<decimal>(row["pesoLiquido"]);
			result.pesoBruto = BaseDadosERP.ObterDbValor<decimal>(row["pesoBruto"]);
			result.valorDesconto = BaseDadosERP.ObterDbValor<decimal>(row["valorDesconto"]);
			result.valorIcmsDesonerado = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsDesonerado"]);
			result.motivoDesoneracaoIcms = BaseDadosERP.ObterDbValor<int>(row["motivoDesoneracaoIcms"]);
			result.isFreteBaseCalculoIcms = BaseDadosERP.ObterDbValor<bool>(row["isFreteBaseCalculoIcms"]);
			result.codigoExterno = BaseDadosERP.ObterDbValor<string>(row["codigoExterno"]);
			result.percentualReducaoBaseCalculoICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualReducaoBaseCalculoICMSST"]);
			result.codigoControleReajuste = BaseDadosERP.ObterDbValor<int>(row["codigoControleReajuste"]);
			result.codigoFCI = BaseDadosERP.ObterDbValor<string>(row["codigoFCI"]);
			result.valorBaseCalculoFundoCombatePobreza = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoFundoCombatePobreza"]);
			result.percentualFundoCombatePobreza = BaseDadosERP.ObterDbValor<decimal>(row["percentualFundoCombatePobreza"]);
			result.valorFundoCombatePobreza = BaseDadosERP.ObterDbValor<decimal>(row["valorFundoCombatePobreza"]);
			result.valorBaseCalculoFundoCombatePobrezaST = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoFundoCombatePobrezaST"]);
			result.percentualFundoCombatePobrezaST = BaseDadosERP.ObterDbValor<decimal>(row["percentualFundoCombatePobrezaST"]);
			result.valorFundoCombatePobrezaST = BaseDadosERP.ObterDbValor<decimal>(row["valorFundoCombatePobrezaST"]);
			result.isProduzidoEscalaRelevante = BaseDadosERP.ObterDbValor<bool>(row["isProduzidoEscalaRelevante"]);
			result.cnpjFabricante = BaseDadosERP.ObterDbValor<string>(row["cnpjFabricante"]);
			result.codigoBenefícioFiscalUF = BaseDadosERP.ObterDbValor<string>(row["codigoBenefícioFiscalUF"]);
			result.valorBaseCalculoIcmsStRetido = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseCalculoIcmsStRetido"]);
			result.percentualSuportadoConsumidorFinal = BaseDadosERP.ObterDbValor<decimal>(row["percentualSuportadoConsumidorFinal"]);
			result.valorIcmsSubstituto = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsSubstituto"]);
			result.valorIcmsStRetido = BaseDadosERP.ObterDbValor<decimal>(row["valorIcmsStRetido"]);
			result.percentualIcmsStCargaMedia = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsStCargaMedia"]);
			result.quantidadeEmPecas = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeEmPecas"]);
			result.siglaFaturamentoTributario = BaseDadosERP.ObterDbValor<string>(row["siglaFaturamentoTributario"]);
			result.coefienteValorTributario = BaseDadosERP.ObterDbValor<decimal>(row["coefienteValorTributario"]);
			result.extipi = BaseDadosERP.ObterDbValor<int>(row["extipi"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("i.[cd_empresa] as [codigoEmpresa], ");
		stringBuilder.Append("i.[cd_nota_fiscal] as [codigoNotaFiscal], ");
		stringBuilder.Append("i.[vl_ordem] as [ordem], ");
		stringBuilder.Append("i.[cd_produto] as [codigoProduto], ");
		stringBuilder.Append("i.[ds_produto] as [descricaoProduto], ");
		stringBuilder.Append("i.[vl_quantidade] as [quantidade], ");
		stringBuilder.Append("i.[vl_unitario] as [valorUnitario], ");
		stringBuilder.Append("i.[vl_total] as [valorTotal], ");
		stringBuilder.Append("i.[vl_base_icms] as [valorBaseICMS], ");
		stringBuilder.Append("i.[pc_icms] as [aliquotaICMS], ");
		stringBuilder.Append("i.[vl_icms] as [valorICMS], ");
		stringBuilder.Append("i.[pc_ipi] as [aliquotaIPI], ");
		stringBuilder.Append("i.[vl_ipi] as [valorIPI], ");
		stringBuilder.Append("i.[vl_pis] as [valorPIS], ");
		stringBuilder.Append("i.[vl_cofins] as [valorCofins], ");
		stringBuilder.Append("i.[vl_frete] as [valorFrete], ");
		stringBuilder.Append("i.[vl_seguro] as [valorSeguro], ");
		stringBuilder.Append("i.[cd_classificacao_fiscal] as [codigoClassificacaoFiscal], ");
		stringBuilder.Append("i.[cd_situacao_tributaria] as [codigoSituacaoTributaria], ");
		stringBuilder.Append("i.[nm_cfop] as [nomeCfop], ");
		stringBuilder.Append("i.[cd_cfop_interna] as [codigoCFOPInterna], ");
		stringBuilder.Append("i.[cd_ficha_expedicao] as [codigoFichaExpedicao], ");
		stringBuilder.Append("i.[cd_ficha_expedicao_item] as [codigoFichaExpedicaoItem], ");
		stringBuilder.Append("i.[sg_unidade] as [siglaUnidadeFaturamento], ");
		stringBuilder.Append("i.[vl_total_fatura] as [valorFatura], ");
		stringBuilder.Append("i.[cd_origem_produto] as [codigoOrigemProduto], ");
		stringBuilder.Append("i.[vl_base_reducao_sem_frete] as [valorBaseReducaoSemFrete], ");
		stringBuilder.Append("i.[pc_base_reducao_icms] as [percentualBaseReducaoIcms], ");
		stringBuilder.Append("i.[cd_modalidade_icms] as [codigoModalidadeIcms], ");
		stringBuilder.Append("i.[cd_tipo_incidencia_icms] as [tipoIncidenciaIcms], ");
		stringBuilder.Append("i.[cd_tipo_incidencia_ipi] as [tipoIncidenciaIpi], ");
		stringBuilder.Append("i.[cd_tipo_incidencia_pis] as [tipoIncidenciaPis], ");
		stringBuilder.Append("i.[cd_tipo_incidencia_cofins] as [tipoIncidenciaCofins], ");
		stringBuilder.Append("i.[pc_pis] as [aliquotaPis], ");
		stringBuilder.Append("i.[pc_retencao_pis] as [percentualRetencaoPis], ");
		stringBuilder.Append("i.[vl_retencao_pis] as [valorRetencaoPis], ");
		stringBuilder.Append("i.[pc_cofins] as [aliquotaCofins], ");
		stringBuilder.Append("i.[pc_retencao_cofins] as [percentualRetencaoCofins], ");
		stringBuilder.Append("i.[vl_retencao_cofins] as [valorRetencaoCofins], ");
		stringBuilder.Append("i.[cd_pedido_venda] as [codigoPedidoVenda], ");
		stringBuilder.Append("i.[cd_pedido_venda_item] as [codigoPedidoVendaItem], ");
		stringBuilder.Append("i.[cd_pedido_compra] as [codigoPedidoCompra], ");
		stringBuilder.Append("i.[cd_pedido_compra_item] as [codigoPedidoCompraItem], ");
		stringBuilder.Append("i.[ic_csll] as [isCsll], ");
		stringBuilder.Append("i.[pc_csll] as [percentualCsll], ");
		stringBuilder.Append("i.[vl_csll] as [valorCsll], ");
		stringBuilder.Append("i.[ic_gera_duplicata] as [isGeraDuplicata], ");
		stringBuilder.Append("i.[ic_consumidor_final] as [isConsumidorFinal], ");
		stringBuilder.Append("i.[cd_serie_nf] as [codigoSerieNotaFiscal], ");
		stringBuilder.Append("i.[cd_nf_atualizacao] as [codigoAuxiliarAtualizacaoNotaFiscal], ");
		stringBuilder.Append("i.[ds_comentario] as [descricaoComplementar], ");
		stringBuilder.Append("i.[cd_conta_contabil_analitica] as [contaContabilAnalitica], ");
		stringBuilder.Append("i.[nm_pedido_compra_cliente] as [codigoPedidoCompraCliente], ");
		stringBuilder.Append("i.[cd_pedido_compra_item_cliente] as [codigoPedidoCompraItemCliente], ");
		stringBuilder.Append("i.[cd_grupo_estoque_gps] as [codigoGrupoEstoqueGPS], ");
		stringBuilder.Append("i.[nm_codigo_produto_gps] as [codigoProdutoGPS], ");
		stringBuilder.Append("i.[cd_tipo_produto_gps] as [codigoTipoProdutoGPS], ");
		stringBuilder.Append("i.[vl_dimensao_01_gps] as [valorDimensao01GPS], ");
		stringBuilder.Append("i.[vl_dimensao_02_gps] as [valorDimensao02GPS], ");
		stringBuilder.Append("i.[vl_dimensao_03_gps] as [valorDimensao03GPS], ");
		stringBuilder.Append("i.[cd_cliente_estoque_gps] as [codigoClienteEntidadeGPS], ");
		stringBuilder.Append("i.[cd_mod_icms_st] as [codigoModalidadeICMSST], ");
		stringBuilder.Append("i.[pc_base_st_agregada] as [percentualBaseAgragadaICMSST], ");
		stringBuilder.Append("i.[vl_base_st_icms_agragada] as [valorBaseAgragadaICMSST], ");
		stringBuilder.Append("i.[vl_icms_st_agragado] as [valorICMSSTAgregado], ");
		stringBuilder.Append("i.[cd_recebimento_material_cliente] as [codigoRecebimentoMaterialCliente], ");
		stringBuilder.Append("i.[pc_icms_st_agregado] as [percentualICMSSTAgregado], ");
		stringBuilder.Append("i.[vl_base_IPI] as [valorBaseCalculoIpi], ");
		stringBuilder.Append("i.[vl_base_Pis] as [valorBaseCalculoPis], ");
		stringBuilder.Append("i.[vl_base_Cofins] as [valorBaseCalculoCofins], ");
		stringBuilder.Append("i.[vl_base_II] as [valorBaseCalculoImpostoImportacao], ");
		stringBuilder.Append("i.[vl_outros] as [valorOutros], ");
		stringBuilder.Append("i.[vl_despesas_aduaneiras] as [valorDespesasAduaneiras], ");
		stringBuilder.Append("i.[vl_II] as [valorImpostoImportacao], ");
		stringBuilder.Append("i.[vl_IOF] as [valorIof], ");
		stringBuilder.Append("i.[nm_contrato_cliente] as [contratoCliente], ");
		stringBuilder.Append("i.[nm_item_contrato_cliente] as [contratoClienteItem], ");
		stringBuilder.Append("i.[cd_enq_ipi] as [codigoEnquadramentoIPI], ");
		stringBuilder.Append("i.[cd_ean] as [codigoEan], ");
		stringBuilder.Append("i.[pc_II] as [percentualII], ");
		stringBuilder.Append("i.[vl_siscomex] as [valorSiscomex], ");
		stringBuilder.Append("i.[vl_marinha_mercante] as [valorMarinhaMercante], ");
		stringBuilder.Append("i.[nr_pecas_por_etiqueta] as [pecasPorEtiqueta], ");
		stringBuilder.Append("i.[pc_cred_icms] as [percentualCreditoIcms], ");
		stringBuilder.Append("i.[vl_cred_icms] as [valorCreditoIcms], ");
		stringBuilder.Append("i.[cd_cest] as [cest], ");
		stringBuilder.Append("i.[ic_icms_uf_dest] as [isICMSInterestadual], ");
		stringBuilder.Append("i.[vl_base_calculo_icms_interestadual], ");
		stringBuilder.Append("i.[pc_icms_fundo_pobreza] as [percentualIcmsInterestadualFundoPobreza], ");
		stringBuilder.Append("i.[vl_fundo_pobreza_uf_destino] as [valorIcmsInterestadualFundoPobreza], ");
		stringBuilder.Append("i.[pc_icms_aliquota_interna_uf_destino] as [percentualIcmsInterestadualUfDestino], ");
		stringBuilder.Append("i.[vl_icms_interestadual_uf_destino] as [valorIcmsInterestadualUfDestino], ");
		stringBuilder.Append("i.[pc_icms_aliquota_interestadual_uf_envolvidas] as [percentualIcmsInterestadualUfEnvolvidas], ");
		stringBuilder.Append("i.[vl_icms_interestadual_uf_remetente] as [valorIcmsInterestadualUfEnvolvidas], ");
		stringBuilder.Append("i.[nm_tag_xml] as [tagXml], ");
		stringBuilder.Append("i.[nm_codigo_embalagem] as [codigoEmbalagem], ");
		stringBuilder.Append("i.[qd_embalagens] as [quantidadeEmbalagem], ");
		stringBuilder.Append("i.[vl_peso_liquido] as [pesoLiquido], ");
		stringBuilder.Append("i.[vl_peso_bruto] as [pesoBruto], ");
		stringBuilder.Append("i.[vl_desc] as [valorDesconto], ");
		stringBuilder.Append("i.[vl_icms_deson] as [valorIcmsDesonerado], ");
		stringBuilder.Append("i.[vl_mot_icms_deson] as [motivoDesoneracaoIcms], ");
		stringBuilder.Append("i.[ic_frete_base_calculo] as [isFreteBaseCalculoIcms], ");
		stringBuilder.Append("i.[nm_codigo_externo] as [codigoExterno], ");
		stringBuilder.Append("i.[pc_red_bc_st] as [percentualReducaoBaseCalculoICMSST],  ");
		stringBuilder.Append("i.[cd_ctrl_reajuste] as [codigoControleReajuste],");
		stringBuilder.Append("i.[cd_fci] as [codigoFCI], ");
		stringBuilder.Append("i.[ic_escala] as [isProduzidoEscalaRelevante],");
		stringBuilder.Append("i.[cnpj_fab] as [cnpjFabricante],");
		stringBuilder.Append("i.[cd_benef_fiscal] as [codigoBenefícioFiscalUF],");
		stringBuilder.Append("i.[vl_bc_fcp] as [valorBaseCalculoFundoCombatePobreza],");
		stringBuilder.Append("i.[pc_fcp] as [percentualFundoCombatePobreza],");
		stringBuilder.Append("i.[vl_fcp] as [valorFundoCombatePobreza],");
		stringBuilder.Append("i.[vl_bc_fcpst] as [valorBaseCalculoFundoCombatePobrezaST],");
		stringBuilder.Append("i.[pc_fcpst] as [percentualFundoCombatePobrezaST],");
		stringBuilder.Append("i.[vl_fcpst] as [valorFundoCombatePobrezaST], ");
		stringBuilder.Append("i.[vBCSTRet] as [valorBaseCalculoIcmsStRetido], ");
		stringBuilder.Append("i.[pST] as [percentualSuportadoConsumidorFinal], ");
		stringBuilder.Append("i.[vICMSSubstituto] as [valorIcmsSubstituto], ");
		stringBuilder.Append("i.[vICMSSTRet] as [valorIcmsStRetido], ");
		stringBuilder.Append("i.[pICMSSTCargaMedia] as [percentualIcmsStCargaMedia], ");
		stringBuilder.Append("i.[vl_qde_pecas] as [quantidadeEmPecas], ");
		stringBuilder.Append("i.[sg_un_trib] as [siglaFaturamentoTributario], ");
		stringBuilder.Append("i.[vl_coef_un_trib] as [coefienteValorTributario], ");
		stringBuilder.Append("i.[cd_extipi] as [extipi] ");
		stringBuilder.AppendFormat(" from [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] i ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterTodosNotaFiscalNotasFiscaisItens()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotasFiscaisItens> list = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItens(MapTableNotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItens)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItens.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItens.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItens.codigoSerieNotaFiscal));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public int InserirNotaFiscalNotasFiscaisItens(MapTableNotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItens)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Insert into [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] (", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append("[cd_empresa], ");
		stringBuilder.Append("[cd_nota_fiscal], ");
		stringBuilder.Append("[vl_ordem], ");
		stringBuilder.Append("[cd_produto], ");
		stringBuilder.Append("[ds_produto], ");
		stringBuilder.Append("[vl_quantidade], ");
		stringBuilder.Append("[vl_unitario], ");
		stringBuilder.Append("[vl_total], ");
		stringBuilder.Append("[vl_base_icms], ");
		stringBuilder.Append("[pc_icms], ");
		stringBuilder.Append("[vl_icms], ");
		stringBuilder.Append("[pc_ipi], ");
		stringBuilder.Append("[vl_ipi], ");
		stringBuilder.Append("[vl_pis], ");
		stringBuilder.Append("[vl_cofins], ");
		stringBuilder.Append("[vl_frete], ");
		stringBuilder.Append("[vl_seguro], ");
		stringBuilder.Append("[cd_classificacao_fiscal], ");
		stringBuilder.Append("[cd_situacao_tributaria], ");
		stringBuilder.Append("[nm_cfop], ");
		stringBuilder.Append("[cd_cfop_interna], ");
		stringBuilder.Append("[cd_ficha_expedicao], ");
		stringBuilder.Append("[cd_ficha_expedicao_item], ");
		stringBuilder.Append("[sg_unidade], ");
		stringBuilder.Append("[vl_total_fatura], ");
		stringBuilder.Append("[cd_origem_produto], ");
		stringBuilder.Append("[vl_base_reducao_sem_frete], ");
		stringBuilder.Append("[pc_base_reducao_icms], ");
		stringBuilder.Append("[cd_modalidade_icms], ");
		stringBuilder.Append("[cd_tipo_incidencia_icms], ");
		stringBuilder.Append("[cd_tipo_incidencia_ipi], ");
		stringBuilder.Append("[cd_tipo_incidencia_pis], ");
		stringBuilder.Append("[cd_tipo_incidencia_cofins], ");
		stringBuilder.Append("[pc_pis], ");
		stringBuilder.Append("[pc_retencao_pis], ");
		stringBuilder.Append("[vl_retencao_pis], ");
		stringBuilder.Append("[pc_cofins], ");
		stringBuilder.Append("[pc_retencao_cofins], ");
		stringBuilder.Append("[vl_retencao_cofins], ");
		stringBuilder.Append("[cd_pedido_venda], ");
		stringBuilder.Append("[cd_pedido_venda_item], ");
		stringBuilder.Append("[cd_pedido_compra], ");
		stringBuilder.Append("[cd_pedido_compra_item], ");
		stringBuilder.Append("[ic_csll], ");
		stringBuilder.Append("[pc_csll], ");
		stringBuilder.Append("[vl_csll], ");
		stringBuilder.Append("[ic_gera_duplicata], ");
		stringBuilder.Append("[ic_consumidor_final], ");
		stringBuilder.Append("[cd_serie_nf], ");
		stringBuilder.Append("[cd_nf_atualizacao], ");
		stringBuilder.Append("[ds_comentario], ");
		stringBuilder.Append("[cd_conta_contabil_analitica], ");
		stringBuilder.Append("[nm_pedido_compra_cliente], ");
		stringBuilder.Append("[cd_pedido_compra_item_cliente], ");
		stringBuilder.Append("[cd_grupo_estoque_gps], ");
		stringBuilder.Append("[nm_codigo_produto_gps], ");
		stringBuilder.Append("[cd_tipo_produto_gps], ");
		stringBuilder.Append("[vl_dimensao_01_gps], ");
		stringBuilder.Append("[vl_dimensao_02_gps], ");
		stringBuilder.Append("[vl_dimensao_03_gps], ");
		stringBuilder.Append("[cd_cliente_estoque_gps], ");
		stringBuilder.Append("[cd_mod_icms_st], ");
		stringBuilder.Append("[pc_base_st_agregada], ");
		stringBuilder.Append("[vl_base_st_icms_agragada], ");
		stringBuilder.Append("[vl_icms_st_agragado], ");
		stringBuilder.Append("[cd_recebimento_material_cliente], ");
		stringBuilder.Append("[pc_icms_st_agregado], ");
		stringBuilder.Append("[vl_base_IPI], ");
		stringBuilder.Append("[vl_base_Pis], ");
		stringBuilder.Append("[vl_base_Cofins], ");
		stringBuilder.Append("[vl_base_II], ");
		stringBuilder.Append("[vl_outros], ");
		stringBuilder.Append("[vl_despesas_aduaneiras], ");
		stringBuilder.Append("[vl_II], ");
		stringBuilder.Append("[vl_IOF], ");
		stringBuilder.Append("[nm_contrato_cliente], ");
		stringBuilder.Append("[nm_item_contrato_cliente], ");
		stringBuilder.Append("[cd_enq_ipi], ");
		stringBuilder.Append("[cd_ean], ");
		stringBuilder.Append("[pc_II], ");
		stringBuilder.Append("[vl_siscomex], ");
		stringBuilder.Append("[vl_marinha_mercante], ");
		stringBuilder.Append("[nr_pecas_por_etiqueta], ");
		stringBuilder.Append("[pc_cred_icms], ");
		stringBuilder.Append("[vl_cred_icms], ");
		stringBuilder.Append("[cd_cest], ");
		stringBuilder.Append("[ic_icms_uf_dest], ");
		stringBuilder.Append("[pc_icms_fundo_pobreza], ");
		stringBuilder.Append("[vl_fundo_pobreza_uf_destino], ");
		stringBuilder.Append("[pc_icms_aliquota_interna_uf_destino], ");
		stringBuilder.Append("[vl_icms_interestadual_uf_destino], ");
		stringBuilder.Append("[pc_icms_aliquota_interestadual_uf_envolvidas], ");
		stringBuilder.Append("[vl_icms_interestadual_uf_remetente], ");
		stringBuilder.Append("[nm_tag_xml], ");
		stringBuilder.Append("[nm_codigo_embalagem], ");
		stringBuilder.Append("[qd_embalagens], ");
		stringBuilder.Append("[vl_peso_liquido], ");
		stringBuilder.Append("[vl_peso_bruto], ");
		stringBuilder.Append("[vl_desc], ");
		stringBuilder.Append("[vl_icms_deson], ");
		stringBuilder.Append("[vl_mot_icms_deson], ");
		stringBuilder.Append("[ic_frete_base_calculo], ");
		stringBuilder.Append("[nm_codigo_externo], ");
		stringBuilder.Append("[pc_red_bc_st], ");
		stringBuilder.Append("[cd_ctrl_reajuste], ");
		stringBuilder.Append("[cd_fci], ");
		stringBuilder.Append("[vl_bc_fcp], ");
		stringBuilder.Append("[pc_fcp], ");
		stringBuilder.Append("[vl_fcp], ");
		stringBuilder.Append("[vl_bc_fcpst], ");
		stringBuilder.Append("[pc_fcpst], ");
		stringBuilder.Append("[vl_fcpst], ");
		stringBuilder.Append("[ic_escala], ");
		stringBuilder.Append("[cnpj_fab], ");
		stringBuilder.Append("[cd_benef_fiscal], ");
		stringBuilder.Append("[vBCSTRet], ");
		stringBuilder.Append("[pST], ");
		stringBuilder.Append("[vICMSSubstituto], ");
		stringBuilder.Append("[vICMSSTRet], ");
		stringBuilder.Append("[pICMSSTCargaMedia], ");
		stringBuilder.Append("[vl_qde_pecas], ");
		stringBuilder.Append("[sg_un_trib], ");
		stringBuilder.Append("[vl_coef_un_trib], ");
		stringBuilder.Append("[cd_extipi] ");
		stringBuilder.Append(") Values (@cd_empresa,@cd_nota_fiscal,@vl_ordem,@cd_produto,@ds_produto,@vl_quantidade,@vl_unitario,@vl_total,@vl_base_icms,@pc_icms,@vl_icms,@pc_ipi,@vl_ipi,@vl_pis,@vl_cofins,@vl_frete,@vl_seguro,@cd_classificacao_fiscal,@cd_situacao_tributaria,@nm_cfop,@cd_cfop_interna,@cd_ficha_expedicao,@cd_ficha_expedicao_item,@sg_unidade,@vl_total_fatura,@cd_origem_produto,@vl_base_reducao_sem_frete,@pc_base_reducao_icms,@cd_modalidade_icms,@cd_tipo_incidencia_icms,@cd_tipo_incidencia_ipi,@cd_tipo_incidencia_pis,@cd_tipo_incidencia_cofins,@pc_pis,@pc_retencao_pis,@vl_retencao_pis,@pc_cofins,@pc_retencao_cofins,@vl_retencao_cofins,@cd_pedido_venda,@cd_pedido_venda_item,@cd_pedido_compra,@cd_pedido_compra_item,@ic_csll,@pc_csll,@vl_csll,@ic_gera_duplicata,@ic_consumidor_final,@cd_serie_nf,@cd_nf_atualizacao,@ds_comentario,@cd_conta_contabil_analitica,@nm_pedido_compra_cliente,@cd_pedido_compra_item_cliente,@cd_grupo_estoque_gps,@nm_codigo_produto_gps,@cd_tipo_produto_gps,@vl_dimensao_01_gps,@vl_dimensao_02_gps,@vl_dimensao_03_gps,@cd_cliente_estoque_gps,@cd_mod_icms_st,@pc_base_st_agregada,@vl_base_st_icms_agragada,@vl_icms_st_agragado,@cd_recebimento_material_cliente,@pc_icms_st_agregado,@vl_base_IPI,@vl_base_Pis,@vl_base_Cofins,@vl_base_II,@vl_outros,@vl_despesas_aduaneiras,@vl_II,@vl_IOF,@nm_contrato_cliente,@nm_item_contrato_cliente,@cd_enq_ipi,@cd_ean,@pc_II,@vl_siscomex,@vl_marinha_mercante,@nr_pecas_por_etiqueta,@pc_cred_icms,@vl_cred_icms,@cd_cest,@ic_icms_uf_dest,@pc_icms_fundo_pobreza,@vl_fundo_pobreza_uf_destino,@pc_icms_aliquota_interna_uf_destino,@vl_icms_interestadual_uf_destino,@pc_icms_aliquota_interestadual_uf_envolvidas,@vl_icms_interestadual_uf_remetente,@nm_tag_xml,@nm_codigo_embalagem,@qd_embalagens,@vl_peso_liquido,@vl_peso_bruto,@vl_desc,@vl_icms_deson,@vl_mot_icms_deson,@ic_frete_base_calculo,@nm_codigo_externo,@pc_red_bc_st,@cd_ctrl_reajuste,@cd_fci,@vl_bc_fcp,@pc_fcp,@vl_fcp,@vl_bc_fcpst,@pc_fcpst,@vl_fcpst,@ic_escala,@cnpj_fab,@cd_benef_fiscal,@vBCSTRet,@pST,@vICMSSubstituto,@vICMSSTRet,@pICMSSTCargaMedia,@vl_qde_pecas,@sg_un_trib,@vl_coef_un_trib,@cd_extipi) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", NotaFiscalNotasFiscaisItens.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItens.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItens.ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoProduto) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_produto", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.descricaoProduto) ? string.Empty : NotaFiscalNotasFiscaisItens.descricaoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_quantidade", NotaFiscalNotasFiscaisItens.quantidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_unitario", NotaFiscalNotasFiscaisItens.valorUnitario));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total", NotaFiscalNotasFiscaisItens.valorTotal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_icms", NotaFiscalNotasFiscaisItens.valorBaseICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms", NotaFiscalNotasFiscaisItens.aliquotaICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms", NotaFiscalNotasFiscaisItens.valorICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_ipi", NotaFiscalNotasFiscaisItens.aliquotaIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ipi", NotaFiscalNotasFiscaisItens.valorIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_pis", NotaFiscalNotasFiscaisItens.valorPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_cofins", NotaFiscalNotasFiscaisItens.valorCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_frete", NotaFiscalNotasFiscaisItens.valorFrete));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_seguro", NotaFiscalNotasFiscaisItens.valorSeguro));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_classificacao_fiscal", NotaFiscalNotasFiscaisItens.codigoClassificacaoFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_situacao_tributaria", NotaFiscalNotasFiscaisItens.codigoSituacaoTributaria));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cfop", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.nomeCfop) ? string.Empty : NotaFiscalNotasFiscaisItens.nomeCfop));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cfop_interna", NotaFiscalNotasFiscaisItens.codigoCFOPInterna));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ficha_expedicao", NotaFiscalNotasFiscaisItens.codigoFichaExpedicao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ficha_expedicao_item", NotaFiscalNotasFiscaisItens.codigoFichaExpedicaoItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@sg_unidade", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.siglaUnidadeFaturamento) ? string.Empty : NotaFiscalNotasFiscaisItens.siglaUnidadeFaturamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_total_fatura", NotaFiscalNotasFiscaisItens.valorFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_origem_produto", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoOrigemProduto) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoOrigemProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_reducao_sem_frete", NotaFiscalNotasFiscaisItens.valorBaseReducaoSemFrete));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_base_reducao_icms", NotaFiscalNotasFiscaisItens.percentualBaseReducaoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modalidade_icms", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoModalidadeIcms) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoModalidadeIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_incidencia_icms", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.tipoIncidenciaIcms) ? string.Empty : NotaFiscalNotasFiscaisItens.tipoIncidenciaIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_incidencia_ipi", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.tipoIncidenciaIpi) ? string.Empty : NotaFiscalNotasFiscaisItens.tipoIncidenciaIpi));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_incidencia_pis", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.tipoIncidenciaPis) ? string.Empty : NotaFiscalNotasFiscaisItens.tipoIncidenciaPis));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_incidencia_cofins", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.tipoIncidenciaCofins) ? string.Empty : NotaFiscalNotasFiscaisItens.tipoIncidenciaCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_pis", NotaFiscalNotasFiscaisItens.aliquotaPis));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_retencao_pis", NotaFiscalNotasFiscaisItens.percentualRetencaoPis));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_retencao_pis", NotaFiscalNotasFiscaisItens.valorRetencaoPis));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_cofins", NotaFiscalNotasFiscaisItens.aliquotaCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_retencao_cofins", NotaFiscalNotasFiscaisItens.percentualRetencaoCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_retencao_cofins", NotaFiscalNotasFiscaisItens.valorRetencaoCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", NotaFiscalNotasFiscaisItens.codigoPedidoVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda_item", NotaFiscalNotasFiscaisItens.codigoPedidoVendaItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_compra", NotaFiscalNotasFiscaisItens.codigoPedidoCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_compra_item", NotaFiscalNotasFiscaisItens.codigoPedidoCompraItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_csll", NotaFiscalNotasFiscaisItens.isCsll));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_csll", NotaFiscalNotasFiscaisItens.percentualCsll));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_csll", NotaFiscalNotasFiscaisItens.valorCsll));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_gera_duplicata", NotaFiscalNotasFiscaisItens.isGeraDuplicata));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_consumidor_final", NotaFiscalNotasFiscaisItens.isConsumidorFinal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItens.codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nf_atualizacao", NotaFiscalNotasFiscaisItens.codigoAuxiliarAtualizacaoNotaFiscal));
		if (string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.descricaoComplementar))
		{
			NotaFiscalNotasFiscaisItens.descricaoComplementar = string.Empty;
		}
		else if (NotaFiscalNotasFiscaisItens.descricaoComplementar.Length > 500)
		{
			NotaFiscalNotasFiscaisItens.descricaoComplementar = NotaFiscalNotasFiscaisItens.descricaoComplementar.Substring(0, 500);
		}
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_comentario", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.descricaoComplementar) ? string.Empty : NotaFiscalNotasFiscaisItens.descricaoComplementar));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_conta_contabil_analitica", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.contaContabilAnalitica) ? string.Empty : NotaFiscalNotasFiscaisItens.contaContabilAnalitica));
		if (string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente))
		{
			NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente = string.Empty;
		}
		else if (NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente.Length > 15)
		{
			NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente = NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente.Substring(0, 15);
		}
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_pedido_compra_cliente", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_compra_item_cliente", NotaFiscalNotasFiscaisItens.codigoPedidoCompraItemCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_grupo_estoque_gps", NotaFiscalNotasFiscaisItens.codigoGrupoEstoqueGPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_codigo_produto_gps", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoProdutoGPS) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoProdutoGPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_tipo_produto_gps", NotaFiscalNotasFiscaisItens.codigoTipoProdutoGPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_01_gps", NotaFiscalNotasFiscaisItens.valorDimensao01GPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_02_gps", NotaFiscalNotasFiscaisItens.valorDimensao02GPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dimensao_03_gps", NotaFiscalNotasFiscaisItens.valorDimensao03GPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cliente_estoque_gps", NotaFiscalNotasFiscaisItens.codigoClienteEntidadeGPS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_mod_icms_st", NotaFiscalNotasFiscaisItens.codigoModalidadeICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_base_st_agregada", NotaFiscalNotasFiscaisItens.percentualBaseAgragadaICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_st_icms_agragada", NotaFiscalNotasFiscaisItens.valorBaseAgragadaICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms_st_agragado", NotaFiscalNotasFiscaisItens.valorICMSSTAgregado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_recebimento_material_cliente", NotaFiscalNotasFiscaisItens.codigoRecebimentoMaterialCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_st_agregado", NotaFiscalNotasFiscaisItens.percentualICMSSTAgregado));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_IPI", NotaFiscalNotasFiscaisItens.valorBaseCalculoIpi));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_Pis", NotaFiscalNotasFiscaisItens.valorBaseCalculoPis));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_Cofins", NotaFiscalNotasFiscaisItens.valorBaseCalculoCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_base_II", NotaFiscalNotasFiscaisItens.valorBaseCalculoImpostoImportacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_outros", NotaFiscalNotasFiscaisItens.valorOutros));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_despesas_aduaneiras", NotaFiscalNotasFiscaisItens.valorDespesasAduaneiras));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_II", NotaFiscalNotasFiscaisItens.valorImpostoImportacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_IOF", NotaFiscalNotasFiscaisItens.valorIof));
		if (string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.contratoCliente))
		{
			NotaFiscalNotasFiscaisItens.contratoCliente = string.Empty;
		}
		else if (NotaFiscalNotasFiscaisItens.contratoCliente.Length > 15)
		{
			NotaFiscalNotasFiscaisItens.contratoCliente = NotaFiscalNotasFiscaisItens.contratoCliente.Substring(0, 15);
		}
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_contrato_cliente", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.contratoCliente) ? string.Empty : NotaFiscalNotasFiscaisItens.contratoCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_item_contrato_cliente", NotaFiscalNotasFiscaisItens.contratoClienteItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_enq_ipi", NotaFiscalNotasFiscaisItens.codigoEnquadramentoIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ean", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoEan) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoEan));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_II", NotaFiscalNotasFiscaisItens.percentualII));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_siscomex", NotaFiscalNotasFiscaisItens.valorSiscomex));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_marinha_mercante", NotaFiscalNotasFiscaisItens.valorMarinhaMercante));
		list.Add(BaseDadosERP.ObterNovoParametro("@nr_pecas_por_etiqueta", NotaFiscalNotasFiscaisItens.pecasPorEtiqueta));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_cred_icms", NotaFiscalNotasFiscaisItens.percentualCreditoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_cred_icms", NotaFiscalNotasFiscaisItens.valorCreditoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cest", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.cest) ? string.Empty : NotaFiscalNotasFiscaisItens.cest));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_icms_uf_dest", NotaFiscalNotasFiscaisItens.isICMSInterestadual));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_fundo_pobreza", NotaFiscalNotasFiscaisItens.percentualIcmsInterestadualFundoPobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_fundo_pobreza_uf_destino", NotaFiscalNotasFiscaisItens.valorIcmsInterestadualFundoPobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_aliquota_interna_uf_destino", NotaFiscalNotasFiscaisItens.percentualIcmsInterestadualUfDestino));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms_interestadual_uf_destino", NotaFiscalNotasFiscaisItens.valorIcmsInterestadualUfDestino));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_aliquota_interestadual_uf_envolvidas", NotaFiscalNotasFiscaisItens.percentualIcmsInterestadualUfEnvolvidas));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms_interestadual_uf_remetente", NotaFiscalNotasFiscaisItens.valorIcmsInterestadualUfEnvolvidas));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tag_xml", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.tagXml) ? string.Empty : NotaFiscalNotasFiscaisItens.tagXml));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_codigo_embalagem", string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.codigoEmbalagem) ? string.Empty : NotaFiscalNotasFiscaisItens.codigoEmbalagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@qd_embalagens", NotaFiscalNotasFiscaisItens.quantidadeEmbalagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_peso_liquido", NotaFiscalNotasFiscaisItens.pesoLiquido));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_peso_bruto", NotaFiscalNotasFiscaisItens.pesoBruto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_desc", NotaFiscalNotasFiscaisItens.valorDesconto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_icms_deson", NotaFiscalNotasFiscaisItens.valorIcmsDesonerado));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_mot_icms_deson", NotaFiscalNotasFiscaisItens.motivoDesoneracaoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_frete_base_calculo", NotaFiscalNotasFiscaisItens.isFreteBaseCalculoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_codigo_externo", NotaFiscalNotasFiscaisItens.codigoExterno));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_red_bc_st", NotaFiscalNotasFiscaisItens.percentualReducaoBaseCalculoICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ctrl_reajuste", NotaFiscalNotasFiscaisItens.codigoControleReajuste));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_fci", NotaFiscalNotasFiscaisItens.codigoFCI));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_bc_fcp", NotaFiscalNotasFiscaisItens.valorBaseCalculoFundoCombatePobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_fcp", NotaFiscalNotasFiscaisItens.percentualFundoCombatePobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_fcp", NotaFiscalNotasFiscaisItens.valorFundoCombatePobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_bc_fcpst", NotaFiscalNotasFiscaisItens.valorBaseCalculoFundoCombatePobrezaST));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_fcpst", NotaFiscalNotasFiscaisItens.percentualFundoCombatePobrezaST));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_fcpst", NotaFiscalNotasFiscaisItens.valorFundoCombatePobrezaST));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_escala", NotaFiscalNotasFiscaisItens.isProduzidoEscalaRelevante));
		list.Add(BaseDadosERP.ObterNovoParametro("@cnpj_fab", NotaFiscalNotasFiscaisItens.cnpjFabricante));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_benef_fiscal", NotaFiscalNotasFiscaisItens.codigoBenefícioFiscalUF));
		list.Add(BaseDadosERP.ObterNovoParametro("@vBCSTRet", NotaFiscalNotasFiscaisItens.valorBaseCalculoIcmsStRetido));
		list.Add(BaseDadosERP.ObterNovoParametro("@pST", NotaFiscalNotasFiscaisItens.percentualSuportadoConsumidorFinal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vICMSSubstituto", NotaFiscalNotasFiscaisItens.valorIcmsSubstituto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vICMSSTRet", NotaFiscalNotasFiscaisItens.valorIcmsStRetido));
		list.Add(BaseDadosERP.ObterNovoParametro("@pICMSSTCargaMedia", NotaFiscalNotasFiscaisItens.percentualIcmsStCargaMedia));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_qde_pecas", NotaFiscalNotasFiscaisItens.quantidadeEmPecas));
		list.Add(BaseDadosERP.ObterNovoParametro("@sg_un_trib", NotaFiscalNotasFiscaisItens.siglaFaturamentoTributario));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_coef_un_trib", NotaFiscalNotasFiscaisItens.coefienteValorTributario));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_extipi", NotaFiscalNotasFiscaisItens.extipi));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarNotaFiscalNotasFiscaisItens(MapTableNotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItens, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Update [{0}].[{1}].[NotaFiscal].[NotasFiscaisItens] Set ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmpresa", "cd_empresa", NotaFiscalNotasFiscaisItens.codigoEmpresa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", NotaFiscalNotasFiscaisItens.codigoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoProduto", "ds_produto", NotaFiscalNotasFiscaisItens.descricaoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Quantidade", "vl_quantidade", NotaFiscalNotasFiscaisItens.quantidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorUnitario", "vl_unitario", NotaFiscalNotasFiscaisItens.valorUnitario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorTotal", "vl_total", NotaFiscalNotasFiscaisItens.valorTotal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseICMS", "vl_base_icms", NotaFiscalNotasFiscaisItens.valorBaseICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "AliquotaICMS", "pc_icms", NotaFiscalNotasFiscaisItens.aliquotaICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorICMS", "vl_icms", NotaFiscalNotasFiscaisItens.valorICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "AliquotaIPI", "pc_ipi", NotaFiscalNotasFiscaisItens.aliquotaIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIPI", "vl_ipi", NotaFiscalNotasFiscaisItens.valorIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorPIS", "vl_pis", NotaFiscalNotasFiscaisItens.valorPIS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCofins", "vl_cofins", NotaFiscalNotasFiscaisItens.valorCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFrete", "vl_frete", NotaFiscalNotasFiscaisItens.valorFrete, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorSeguro", "vl_seguro", NotaFiscalNotasFiscaisItens.valorSeguro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoClassificacaoFiscal", "cd_classificacao_fiscal", NotaFiscalNotasFiscaisItens.codigoClassificacaoFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSituacaoTributaria", "cd_situacao_tributaria", NotaFiscalNotasFiscaisItens.codigoSituacaoTributaria, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeCfop", "nm_cfop", NotaFiscalNotasFiscaisItens.nomeCfop, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCFOPInterna", "cd_cfop_interna", NotaFiscalNotasFiscaisItens.codigoCFOPInterna, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFichaExpedicao", "cd_ficha_expedicao", NotaFiscalNotasFiscaisItens.codigoFichaExpedicao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFichaExpedicaoItem", "cd_ficha_expedicao_item", NotaFiscalNotasFiscaisItens.codigoFichaExpedicaoItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SiglaUnidadeFaturamento", "sg_unidade", NotaFiscalNotasFiscaisItens.siglaUnidadeFaturamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFatura", "vl_total_fatura", NotaFiscalNotasFiscaisItens.valorFatura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoOrigemProduto", "cd_origem_produto", NotaFiscalNotasFiscaisItens.codigoOrigemProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseReducaoSemFrete", "vl_base_reducao_sem_frete", NotaFiscalNotasFiscaisItens.valorBaseReducaoSemFrete, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualBaseReducaoIcms", "pc_base_reducao_icms", NotaFiscalNotasFiscaisItens.percentualBaseReducaoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModalidadeIcms", "cd_modalidade_icms", NotaFiscalNotasFiscaisItens.codigoModalidadeIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoIncidenciaIcms", "cd_tipo_incidencia_icms", NotaFiscalNotasFiscaisItens.tipoIncidenciaIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoIncidenciaIpi", "cd_tipo_incidencia_ipi", NotaFiscalNotasFiscaisItens.tipoIncidenciaIpi, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoIncidenciaPis", "cd_tipo_incidencia_pis", NotaFiscalNotasFiscaisItens.tipoIncidenciaPis, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoIncidenciaCofins", "cd_tipo_incidencia_cofins", NotaFiscalNotasFiscaisItens.tipoIncidenciaCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "AliquotaPis", "pc_pis", NotaFiscalNotasFiscaisItens.aliquotaPis, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualRetencaoPis", "pc_retencao_pis", NotaFiscalNotasFiscaisItens.percentualRetencaoPis, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorRetencaoPis", "vl_retencao_pis", NotaFiscalNotasFiscaisItens.valorRetencaoPis, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "AliquotaCofins", "pc_cofins", NotaFiscalNotasFiscaisItens.aliquotaCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualRetencaoCofins", "pc_retencao_cofins", NotaFiscalNotasFiscaisItens.percentualRetencaoCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorRetencaoCofins", "vl_retencao_cofins", NotaFiscalNotasFiscaisItens.valorRetencaoCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoVenda", "cd_pedido_venda", NotaFiscalNotasFiscaisItens.codigoPedidoVenda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoVendaItem", "cd_pedido_venda_item", NotaFiscalNotasFiscaisItens.codigoPedidoVendaItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoCompra", "cd_pedido_compra", NotaFiscalNotasFiscaisItens.codigoPedidoCompra, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoCompraItem", "cd_pedido_compra_item", NotaFiscalNotasFiscaisItens.codigoPedidoCompraItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsCsll", "ic_csll", NotaFiscalNotasFiscaisItens.isCsll, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualCsll", "pc_csll", NotaFiscalNotasFiscaisItens.percentualCsll, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCsll", "vl_csll", NotaFiscalNotasFiscaisItens.valorCsll, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsGeraDuplicata", "ic_gera_duplicata", NotaFiscalNotasFiscaisItens.isGeraDuplicata, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsConsumidorFinal", "ic_consumidor_final", NotaFiscalNotasFiscaisItens.isConsumidorFinal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoAuxiliarAtualizacaoNotaFiscal", "cd_nf_atualizacao", NotaFiscalNotasFiscaisItens.codigoAuxiliarAtualizacaoNotaFiscal, camposAlterados));
			if (string.IsNullOrWhiteSpace(NotaFiscalNotasFiscaisItens.descricaoComplementar))
			{
				NotaFiscalNotasFiscaisItens.descricaoComplementar = string.Empty;
			}
			else if (NotaFiscalNotasFiscaisItens.descricaoComplementar.Length > 500)
			{
				NotaFiscalNotasFiscaisItens.descricaoComplementar = NotaFiscalNotasFiscaisItens.descricaoComplementar.Substring(0, 500);
			}
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoComplementar", "ds_comentario", NotaFiscalNotasFiscaisItens.descricaoComplementar, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ContaContabilAnalitica", "cd_conta_contabil_analitica", NotaFiscalNotasFiscaisItens.contaContabilAnalitica, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoCompraCliente", "nm_pedido_compra_cliente", NotaFiscalNotasFiscaisItens.codigoPedidoCompraCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoCompraItemCliente", "cd_pedido_compra_item_cliente", NotaFiscalNotasFiscaisItens.codigoPedidoCompraItemCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoGrupoEstoqueGPS", "cd_grupo_estoque_gps", NotaFiscalNotasFiscaisItens.codigoGrupoEstoqueGPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProdutoGPS", "nm_codigo_produto_gps", NotaFiscalNotasFiscaisItens.codigoProdutoGPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoProdutoGPS", "cd_tipo_produto_gps", NotaFiscalNotasFiscaisItens.codigoTipoProdutoGPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDimensao01GPS", "vl_dimensao_01_gps", NotaFiscalNotasFiscaisItens.valorDimensao01GPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDimensao02GPS", "vl_dimensao_02_gps", NotaFiscalNotasFiscaisItens.valorDimensao02GPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDimensao03GPS", "vl_dimensao_03_gps", NotaFiscalNotasFiscaisItens.valorDimensao03GPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoClienteEntidadeGPS", "cd_cliente_estoque_gps", NotaFiscalNotasFiscaisItens.codigoClienteEntidadeGPS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModalidadeICMSST", "cd_mod_icms_st", NotaFiscalNotasFiscaisItens.codigoModalidadeICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualBaseAgragadaICMSST", "pc_base_st_agregada", NotaFiscalNotasFiscaisItens.percentualBaseAgragadaICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseAgragadaICMSST", "vl_base_st_icms_agragada", NotaFiscalNotasFiscaisItens.valorBaseAgragadaICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorICMSSTAgregado", "vl_icms_st_agragado", NotaFiscalNotasFiscaisItens.valorICMSSTAgregado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRecebimentoMaterialCliente", "cd_recebimento_material_cliente", NotaFiscalNotasFiscaisItens.codigoRecebimentoMaterialCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualICMSSTAgregado", "pc_icms_st_agregado", NotaFiscalNotasFiscaisItens.percentualICMSSTAgregado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoIpi", "vl_base_IPI", NotaFiscalNotasFiscaisItens.valorBaseCalculoIpi, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoPis", "vl_base_Pis", NotaFiscalNotasFiscaisItens.valorBaseCalculoPis, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoCofins", "vl_base_Cofins", NotaFiscalNotasFiscaisItens.valorBaseCalculoCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoImpostoImportacao", "vl_base_II", NotaFiscalNotasFiscaisItens.valorBaseCalculoImpostoImportacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorOutros", "vl_outros", NotaFiscalNotasFiscaisItens.valorOutros, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDespesasAduaneiras", "vl_despesas_aduaneiras", NotaFiscalNotasFiscaisItens.valorDespesasAduaneiras, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorImpostoImportacao", "vl_II", NotaFiscalNotasFiscaisItens.valorImpostoImportacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIof", "vl_IOF", NotaFiscalNotasFiscaisItens.valorIof, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ContratoCliente", "nm_contrato_cliente", NotaFiscalNotasFiscaisItens.contratoCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ContratoClienteItem", "nm_item_contrato_cliente", NotaFiscalNotasFiscaisItens.contratoClienteItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEnquadramentoIPI", "cd_enq_ipi", NotaFiscalNotasFiscaisItens.codigoEnquadramentoIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEan", "cd_ean", NotaFiscalNotasFiscaisItens.codigoEan, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualII", "pc_II", NotaFiscalNotasFiscaisItens.percentualII, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorSiscomex", "vl_siscomex", NotaFiscalNotasFiscaisItens.valorSiscomex, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorMarinhaMercante", "vl_marinha_mercante", NotaFiscalNotasFiscaisItens.valorMarinhaMercante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PecasPorEtiqueta", "nr_pecas_por_etiqueta", NotaFiscalNotasFiscaisItens.pecasPorEtiqueta, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualCreditoIcms", "pc_cred_icms", NotaFiscalNotasFiscaisItens.percentualCreditoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCreditoIcms", "vl_cred_icms", NotaFiscalNotasFiscaisItens.valorCreditoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cest", "vl_cest", NotaFiscalNotasFiscaisItens.cest, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsICMSInterestadual", "ic_icms_uf_dest", NotaFiscalNotasFiscaisItens.isICMSInterestadual, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsInterestadualFundoPobreza", "pc_icms_fundo_pobreza", NotaFiscalNotasFiscaisItens.percentualIcmsInterestadualFundoPobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsInterestadualFundoPobreza", "vl_fundo_pobreza_uf_destino", NotaFiscalNotasFiscaisItens.valorIcmsInterestadualFundoPobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsInterestadualUfDestino", "pc_icms_aliquota_interna_uf_destino", NotaFiscalNotasFiscaisItens.percentualIcmsInterestadualUfDestino, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsInterestadualUfDestino", "vl_icms_interestadual_uf_destino", NotaFiscalNotasFiscaisItens.valorIcmsInterestadualUfDestino, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsInterestadualUfEnvolvidas", "pc_icms_aliquota_interestadual_uf_envolvidas", NotaFiscalNotasFiscaisItens.percentualIcmsInterestadualUfEnvolvidas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsInterestadualUfEnvolvidas", "vl_icms_interestadual_uf_remetente", NotaFiscalNotasFiscaisItens.valorIcmsInterestadualUfEnvolvidas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TagXml", "nm_tag_xml", NotaFiscalNotasFiscaisItens.tagXml, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmbalagem", "nm_codigo_embalagem", NotaFiscalNotasFiscaisItens.codigoEmbalagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeEmbalagem", "qd_embalagens", NotaFiscalNotasFiscaisItens.quantidadeEmbalagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PesoLiquido", "vl_peso_liquido", NotaFiscalNotasFiscaisItens.pesoLiquido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PesoBruto", "vl_peso_bruto", NotaFiscalNotasFiscaisItens.pesoBruto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorDesconto", "vl_desc", NotaFiscalNotasFiscaisItens.valorDesconto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsDesonerado", "vl_icms_deson", NotaFiscalNotasFiscaisItens.valorIcmsDesonerado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "MotivoDesoneracaoIcms", "vl_mot_icms_deson", NotaFiscalNotasFiscaisItens.motivoDesoneracaoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFreteBaseCalculoIcms", "ic_frete_base_calculo", NotaFiscalNotasFiscaisItens.isFreteBaseCalculoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoExterno", "nm_codigo_externo", NotaFiscalNotasFiscaisItens.codigoExterno, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualReducaoBaseCalculoICMSST", "pc_red_bc_st", NotaFiscalNotasFiscaisItens.percentualReducaoBaseCalculoICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoControleReajuste", "cd_ctrl_reajuste", NotaFiscalNotasFiscaisItens.codigoControleReajuste, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFci", "cd_fci", NotaFiscalNotasFiscaisItens.codigoFCI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsProduzidoEscalaRelevante", "ic_escala", NotaFiscalNotasFiscaisItens.isProduzidoEscalaRelevante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CnpjFabricante", "cnpj_fab", NotaFiscalNotasFiscaisItens.cnpjFabricante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoBenefícioFiscalUF", "cd_benef_fiscal", NotaFiscalNotasFiscaisItens.codigoBenefícioFiscalUF, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoFundoCombatePobreza", "vl_bc_fcp", NotaFiscalNotasFiscaisItens.valorBaseCalculoFundoCombatePobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualFundoCombatePobreza", "pc_fcp", NotaFiscalNotasFiscaisItens.percentualFundoCombatePobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFundoCombatePobreza", "vl_fcp", NotaFiscalNotasFiscaisItens.valorFundoCombatePobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoFundoCombatePobrezaST", "vl_bc_fcpst", NotaFiscalNotasFiscaisItens.valorBaseCalculoFundoCombatePobrezaST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualFundoCombatePobrezaST", "pc_fcpst", NotaFiscalNotasFiscaisItens.percentualFundoCombatePobrezaST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFundoCombatePobrezaST", "vl_fcpst", NotaFiscalNotasFiscaisItens.valorFundoCombatePobrezaST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorBaseCalculoIcmsStRetido", "vBCSTRet", NotaFiscalNotasFiscaisItens.valorBaseCalculoIcmsStRetido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualSuportadoConsumidorFinal", "pST", NotaFiscalNotasFiscaisItens.percentualSuportadoConsumidorFinal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsSubstituto", "vICMSSubstituto", NotaFiscalNotasFiscaisItens.valorIcmsSubstituto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIcmsStRetido", "vICMSSTRet", NotaFiscalNotasFiscaisItens.valorIcmsStRetido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsStCargaMedia", "pICMSSTCargaMedia", NotaFiscalNotasFiscaisItens.percentualIcmsStCargaMedia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeEmPecas", "vl_qde_pecas", NotaFiscalNotasFiscaisItens.quantidadeEmPecas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SiglaFaturamentoTributario", "sg_un_trib", NotaFiscalNotasFiscaisItens.siglaFaturamentoTributario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CoefienteValorTributario", "vl_coef_un_trib", NotaFiscalNotasFiscaisItens.coefienteValorTributario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Extipi", "cd_extipi", NotaFiscalNotasFiscaisItens.extipi, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_nota_fiscal = @cd_nota_fiscal and ");
			stringBuilder.Append("vl_ordem = @vl_ordem and ");
			stringBuilder.Append("cd_serie_nf = @cd_serie_nf");
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", NotaFiscalNotasFiscaisItens.codigoNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", NotaFiscalNotasFiscaisItens.ordem));
			list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", NotaFiscalNotasFiscaisItens.codigoSerieNotaFiscal));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisItens] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int ordem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscaisItens] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int ordem, int codigoSerieNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_empresa] = @cd_empresa and");
		stringBuilder.Append(" [cd_nota_fiscal] = @cd_nota_fiscal and");
		stringBuilder.Append(" [cd_serie_nf] = @cd_serie_nf and");
		stringBuilder.Append(" [vl_ordem] = @vl_ordem");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_empresa", codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_serie_nf", codigoSerieNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_ordem", ordem));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensFE(int codigoFichaExpedicao)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_ficha_expedicao] = @cd_ficha_expedicao");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ficha_expedicao", codigoFichaExpedicao));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItensFE(int codigoFichaExpedicao, int codigoFichaExpedicaoItem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_ficha_expedicao] = @cd_ficha_expedicao and");
		stringBuilder.Append(" [cd_ficha_expedicao_item] = @cd_ficha_expedicao_item ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ficha_expedicao", codigoFichaExpedicao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ficha_expedicao_item", codigoFichaExpedicaoItem));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoCompra(int codigoPedidoCompra)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_pedido_compra] = @cd_pedido_compra");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_compra", codigoPedidoCompra));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItensPedidoCompra(int codigoPedidoCompra, int codigoPedidoCompraItem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_pedido_compra] = @cd_pedido_compra and");
		stringBuilder.Append(" [cd_pedido_compra_item] = @cd_pedido_compra_item ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_compra", codigoPedidoCompra));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_compra_item", codigoPedidoCompraItem));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_pedido_venda] = @cd_pedido_venda");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", codigoPedidoVenda));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda, int codigoPedidoVendaItem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_pedido_venda] = @cd_pedido_venda and");
		stringBuilder.Append(" [cd_pedido_venda_item] = @cd_pedido_venda_item ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", codigoPedidoVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda_item", codigoPedidoVendaItem));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda, int codigoPedidoVendaItem, int codigoNotaCorte)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.AppendFormat(" inner join [{0}].[{1}].[NotaFiscal].[NotasFiscais] n ", BaseDadosERP.NomeServidor, BaseDadosERP.NomeBaseDados);
		stringBuilder.Append(" on i.cd_empresa = n.cd_empresa and i.cd_nota_fiscal = n.cd_nota_fiscal ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" i.[cd_pedido_venda] = @cd_pedido_venda and");
		stringBuilder.Append(" i.[cd_pedido_venda_item] = @cd_pedido_venda_item and");
		stringBuilder.Append(" i.[cd_nota_fiscal] > @cd_nota_fiscal and ");
		stringBuilder.Append(" n.ds_situacao_nfe != 'Cancelada' ");
		stringBuilder.Append(" order by i.cd_nota_fiscal");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", codigoPedidoVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda_item", codigoPedidoVendaItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_nota_fiscal", codigoNotaCorte));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(int codigoRecebimentoMaterialCliente)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_recebimento_material_cliente] = @cd_recebimento_material_cliente ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_recebimento_material_cliente", codigoRecebimentoMaterialCliente));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(string codigoMaterialCliente)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_recebimento_material_cliente] = @cd_recebimento_material_cliente ");
		stringBuilder.Append(" and [cd_produto] = @cd_produto");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_recebimento_material_cliente", 0));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", codigoMaterialCliente));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterTodosNotaFiscalNotasFiscaisItens(DateTime DataPeriodoInicial, DateTime DataPeriodoFinal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append($" inner join [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[NotasFiscais] n");
		stringBuilder.Append(" on i.[cd_empresa] = n.[cd_empresa] and");
		stringBuilder.Append(" i.[cd_nota_fiscal] = n.[cd_nota_fiscal] and");
		stringBuilder.Append(" i.[cd_serie_nf] = n.[cd_serie_nota_fiscal] ");
		stringBuilder.Append(" Where ");
		stringBuilder.Append(" n.[dt_emissao] between @dataInicio and @dataFim");
		stringBuilder.Append(" and n.[ds_situacao_nfe] in ('Sucesso','SucessoContingencia','SistemaLegado')");
		list.Add(BaseDadosERP.ObterNovoParametro("@dataInicio", DataPeriodoInicial));
		list.Add(BaseDadosERP.ObterNovoParametro("@dataFim", DataPeriodoFinal.AddDays(1.0).AddSeconds(-1.0)));
		using DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalNotasFiscaisItens> list2 = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}
}
