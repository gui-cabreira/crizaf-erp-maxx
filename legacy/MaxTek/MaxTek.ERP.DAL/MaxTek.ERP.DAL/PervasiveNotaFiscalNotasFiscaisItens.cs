using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalNotasFiscaisItens : INotaFiscalNotasFiscaisItens
{
	private MapTableNotaFiscalNotasFiscaisItens MapearClasse(DataRow row)
	{
		MapTableNotaFiscalNotasFiscaisItens result = default(MapTableNotaFiscalNotasFiscaisItens);
		if (row != null)
		{
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.codigoNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoNotaFiscal"]);
			result.ordem = BaseDadosGPS.ObterDbValor<int>(row["ordem"]);
			result.codigoProduto = BaseDadosGPS.ObterDbValor<string>(row["codigoProduto"]);
			result.descricaoProduto = BaseDadosGPS.ObterDbValor<string>(row["descricaoProduto"]);
			result.quantidade = BaseDadosGPS.ObterDbValor<decimal>(row["quantidade"]);
			result.valorUnitario = BaseDadosGPS.ObterDbValor<decimal>(row["valorUnitario"]);
			result.valorTotal = BaseDadosGPS.ObterDbValor<decimal>(row["valorTotal"]);
			result.valorBaseICMS = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseICMS"]);
			result.aliquotaICMS = BaseDadosGPS.ObterDbValor<decimal>(row["aliquotaICMS"]);
			result.valorICMS = BaseDadosGPS.ObterDbValor<decimal>(row["valorICMS"]);
			result.aliquotaIPI = BaseDadosGPS.ObterDbValor<decimal>(row["aliquotaIPI"]);
			result.valorIPI = BaseDadosGPS.ObterDbValor<decimal>(row["valorIPI"]);
			result.valorPIS = BaseDadosGPS.ObterDbValor<decimal>(row["valorPIS"]);
			result.valorCofins = BaseDadosGPS.ObterDbValor<decimal>(row["valorCofins"]);
			result.valorFrete = BaseDadosGPS.ObterDbValor<decimal>(row["valorFrete"]);
			result.valorSeguro = BaseDadosGPS.ObterDbValor<decimal>(row["valorSeguro"]);
			result.codigoClassificacaoFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoClassificacaoFiscal"]);
			result.codigoSituacaoTributaria = BaseDadosGPS.ObterDbValor<int>(row["codigoSituacaoTributaria"]);
			result.nomeCfop = BaseDadosGPS.ObterDbValor<string>(row["nomeCfop"]);
			result.codigoCFOPInterna = BaseDadosGPS.ObterDbValor<int>(row["codigoCFOPInterna"]);
			result.codigoFichaExpedicao = BaseDadosGPS.ObterDbValor<int>(row["codigoFichaExpedicao"]);
			result.codigoFichaExpedicaoItem = BaseDadosGPS.ObterDbValor<int>(row["codigoFichaExpedicaoItem"]);
			result.siglaUnidadeFaturamento = BaseDadosGPS.ObterDbValor<string>(row["siglaUnidadeFaturamento"]);
			result.valorFatura = BaseDadosGPS.ObterDbValor<decimal>(row["valorFatura"]);
			result.codigoOrigemProduto = BaseDadosGPS.ObterDbValor<string>(row["codigoOrigemProduto"]);
			result.valorBaseReducaoSemFrete = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseReducaoSemFrete"]);
			result.percentualBaseReducaoIcms = BaseDadosGPS.ObterDbValor<decimal>(row["percentualBaseReducaoIcms"]);
			result.codigoModalidadeIcms = BaseDadosGPS.ObterDbValor<string>(row["codigoModalidadeIcms"]);
			result.tipoIncidenciaIcms = BaseDadosGPS.ObterDbValor<string>(row["tipoIncidenciaIcms"]);
			result.tipoIncidenciaIpi = BaseDadosGPS.ObterDbValor<string>(row["tipoIncidenciaIpi"]);
			result.tipoIncidenciaPis = BaseDadosGPS.ObterDbValor<string>(row["tipoIncidenciaPis"]);
			result.tipoIncidenciaCofins = BaseDadosGPS.ObterDbValor<string>(row["tipoIncidenciaCofins"]);
			result.aliquotaPis = BaseDadosGPS.ObterDbValor<decimal>(row["aliquotaPis"]);
			result.percentualRetencaoPis = BaseDadosGPS.ObterDbValor<decimal>(row["percentualRetencaoPis"]);
			result.valorRetencaoPis = BaseDadosGPS.ObterDbValor<decimal>(row["valorRetencaoPis"]);
			result.aliquotaCofins = BaseDadosGPS.ObterDbValor<decimal>(row["aliquotaCofins"]);
			result.percentualRetencaoCofins = BaseDadosGPS.ObterDbValor<decimal>(row["percentualRetencaoCofins"]);
			result.valorRetencaoCofins = BaseDadosGPS.ObterDbValor<decimal>(row["valorRetencaoCofins"]);
			result.codigoPedidoVenda = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoVenda"]);
			result.codigoPedidoVendaItem = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoVendaItem"]);
			result.codigoPedidoCompra = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoCompra"]);
			result.codigoPedidoCompraItem = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoCompraItem"]);
			result.isCsll = BaseDadosGPS.ObterDbValor<bool>(row["isCsll"]);
			result.percentualCsll = BaseDadosGPS.ObterDbValor<decimal>(row["percentualCsll"]);
			result.valorCsll = BaseDadosGPS.ObterDbValor<decimal>(row["valorCsll"]);
			result.isGeraDuplicata = BaseDadosGPS.ObterDbValor<bool>(row["isGeraDuplicata"]);
			result.isConsumidorFinal = BaseDadosGPS.ObterDbValor<bool>(row["isConsumidorFinal"]);
			result.codigoSerieNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoSerieNotaFiscal"]);
			result.codigoAuxiliarAtualizacaoNotaFiscal = BaseDadosGPS.ObterDbValor<int>(row["codigoAuxiliarAtualizacaoNotaFiscal"]);
			result.descricaoComplementar = BaseDadosGPS.ObterDbValor<string>(row["descricaoComplementar"]);
			result.contaContabilAnalitica = BaseDadosGPS.ObterDbValor<string>(row["contaContabilAnalitica"]);
			result.codigoPedidoCompraCliente = BaseDadosGPS.ObterDbValor<string>(row["codigoPedidoCompraCliente"]);
			result.codigoPedidoCompraItemCliente = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoCompraItemCliente"]);
			result.codigoGrupoEstoqueGPS = BaseDadosGPS.ObterDbValor<int>(row["codigoGrupoEstoqueGPS"]);
			result.codigoProdutoGPS = BaseDadosGPS.ObterDbValor<string>(row["codigoProdutoGPS"]);
			result.codigoTipoProdutoGPS = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoProdutoGPS"]);
			result.valorDimensao01GPS = BaseDadosGPS.ObterDbValor<decimal>(row["valorDimensao01GPS"]);
			result.valorDimensao02GPS = BaseDadosGPS.ObterDbValor<decimal>(row["valorDimensao02GPS"]);
			result.valorDimensao03GPS = BaseDadosGPS.ObterDbValor<decimal>(row["valorDimensao03GPS"]);
			result.codigoClienteEntidadeGPS = BaseDadosGPS.ObterDbValor<int>(row["codigoClienteEntidadeGPS"]);
			result.codigoModalidadeICMSST = BaseDadosGPS.ObterDbValor<int>(row["codigoModalidadeICMSST"]);
			result.percentualBaseAgragadaICMSST = BaseDadosGPS.ObterDbValor<decimal>(row["percentualBaseAgragadaICMSST"]);
			result.valorBaseAgragadaICMSST = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseAgragadaICMSST"]);
			result.valorICMSSTAgregado = BaseDadosGPS.ObterDbValor<decimal>(row["valorICMSSTAgregado"]);
			result.codigoRecebimentoMaterialCliente = BaseDadosGPS.ObterDbValor<int>(row["codigoRecebimentoMaterialCliente"]);
			result.percentualICMSSTAgregado = BaseDadosGPS.ObterDbValor<decimal>(row["percentualICMSSTAgregado"]);
			result.valorBaseCalculoIpi = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseCalculoIpi"]);
			result.valorBaseCalculoPis = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseCalculoPis"]);
			result.valorBaseCalculoCofins = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseCalculoCofins"]);
			result.valorBaseCalculoImpostoImportacao = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseCalculoImpostoImportacao"]);
			result.valorOutros = BaseDadosGPS.ObterDbValor<decimal>(row["valorOutros"]);
			result.valorDespesasAduaneiras = BaseDadosGPS.ObterDbValor<decimal>(row["valorDespesasAduaneiras"]);
			result.valorImpostoImportacao = BaseDadosGPS.ObterDbValor<decimal>(row["valorImpostoImportacao"]);
			result.valorIof = BaseDadosGPS.ObterDbValor<decimal>(row["valorIof"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("cd_empresa as codigoEmpresa, ");
		stringBuilder.Append("cd_nota_fiscal as codigoNotaFiscal, ");
		stringBuilder.Append("vl_ordem as ordem, ");
		stringBuilder.Append("cd_produto as codigoProduto, ");
		stringBuilder.Append("ds_produto as descricaoProduto, ");
		stringBuilder.Append("vl_quantidade as quantidade, ");
		stringBuilder.Append("vl_unitario as valorUnitario, ");
		stringBuilder.Append("vl_total as valorTotal, ");
		stringBuilder.Append("vl_base_icms as valorBaseICMS, ");
		stringBuilder.Append("pc_icms as aliquotaICMS, ");
		stringBuilder.Append("vl_icms as valorICMS, ");
		stringBuilder.Append("pc_ipi as aliquotaIPI, ");
		stringBuilder.Append("vl_ipi as valorIPI, ");
		stringBuilder.Append("vl_pis as valorPIS, ");
		stringBuilder.Append("vl_cofins as valorCofins, ");
		stringBuilder.Append("vl_frete as valorFrete, ");
		stringBuilder.Append("vl_seguro as valorSeguro, ");
		stringBuilder.Append("cd_class_fiscal as codigoClassificacaoFiscal, ");
		stringBuilder.Append("cd_sit_tributaria as codigoSituacaoTributaria, ");
		stringBuilder.Append("nm_cfop as nomeCfop, ");
		stringBuilder.Append("cd_cfop_interna as codigoCFOPInterna, ");
		stringBuilder.Append("cd_ficha_expedicao as codigoFichaExpedicao, ");
		stringBuilder.Append("cd_ficha_exped_item as codigoFichaExpedicaoItem, ");
		stringBuilder.Append("sg_unidade as siglaUnidadeFaturamento, ");
		stringBuilder.Append("vl_total_fatura as valorFatura, ");
		stringBuilder.Append("cd_origem_produto as codigoOrigemProduto, ");
		stringBuilder.Append("vl_base_reducao_sem_ as valorBaseReducaoSemFrete, ");
		stringBuilder.Append("pc_base_reducao_icms as percentualBaseReducaoIcms, ");
		stringBuilder.Append("cd_modalidade_icms as codigoModalidadeIcms, ");
		stringBuilder.Append("cd_tipo_incidencia_i as tipoIncidenciaIcms, ");
		stringBuilder.Append("cd_tipo_incidencia_i as tipoIncidenciaIpi, ");
		stringBuilder.Append("cd_tipo_incidencia_p as tipoIncidenciaPis, ");
		stringBuilder.Append("cd_tipo_incidencia_c as tipoIncidenciaCofins, ");
		stringBuilder.Append("pc_pis as aliquotaPis, ");
		stringBuilder.Append("pc_retencao_pis as percentualRetencaoPis, ");
		stringBuilder.Append("vl_retencao_pis as valorRetencaoPis, ");
		stringBuilder.Append("pc_cofins as aliquotaCofins, ");
		stringBuilder.Append("pc_retencao_cofins as percentualRetencaoCofins, ");
		stringBuilder.Append("vl_retencao_cofins as valorRetencaoCofins, ");
		stringBuilder.Append("cd_pedido_venda as codigoPedidoVenda, ");
		stringBuilder.Append("cd_pedido_venda_item as codigoPedidoVendaItem, ");
		stringBuilder.Append("cd_pedido_compra as codigoPedidoCompra, ");
		stringBuilder.Append("cd_pedido_compra_ite as codigoPedidoCompraItem, ");
		stringBuilder.Append("ic_csll as isCsll, ");
		stringBuilder.Append("pc_csll as percentualCsll, ");
		stringBuilder.Append("vl_csll as valorCsll, ");
		stringBuilder.Append("ic_gera_duplicata as isGeraDuplicata, ");
		stringBuilder.Append("ic_consumidor_final as isConsumidorFinal, ");
		stringBuilder.Append("cd_serie_nf as codigoSerieNotaFiscal, ");
		stringBuilder.Append("cd_nf_atualizacao as codigoAuxiliarAtualizacaoNotaFiscal, ");
		stringBuilder.Append("ds_comentario as descricaoComplementar, ");
		stringBuilder.Append("cd_conta_contabil_an as contaContabilAnalitica, ");
		stringBuilder.Append("nm_pedido_compra_cli as codigoPedidoCompraCliente, ");
		stringBuilder.Append("cd_pedido_compra_ite as codigoPedidoCompraItemCliente, ");
		stringBuilder.Append("cd_grupo_estoque_gps as codigoGrupoEstoqueGPS, ");
		stringBuilder.Append("nm_codigo_produto_gp as codigoProdutoGPS, ");
		stringBuilder.Append("cd_tipo_produto_gps as codigoTipoProdutoGPS, ");
		stringBuilder.Append("vl_dimensao_01_gps as valorDimensao01GPS, ");
		stringBuilder.Append("vl_dimensao_02_gps as valorDimensao02GPS, ");
		stringBuilder.Append("vl_dimensao_03_gps as valorDimensao03GPS, ");
		stringBuilder.Append("cd_cliente_estoque_g as codigoClienteEntidadeGPS, ");
		stringBuilder.Append("cd_mod_icms_st as codigoModalidadeICMSST, ");
		stringBuilder.Append("pc_base_st_agregada as percentualBaseAgragadaICMSST, ");
		stringBuilder.Append("vl_base_st_icms_agra as valorBaseAgragadaICMSST, ");
		stringBuilder.Append("vl_icms_st_agragado as valorICMSSTAgregado, ");
		stringBuilder.Append("cd_recebimento_mater as codigoRecebimentoMaterialCliente, ");
		stringBuilder.Append("pc_icms_st_agregado as percentualICMSSTAgregado, ");
		stringBuilder.Append("vl_base_IPI as valorBaseCalculoIpi, ");
		stringBuilder.Append("vl_base_Pis as valorBaseCalculoPis, ");
		stringBuilder.Append("vl_base_Cofins as valorBaseCalculoCofins, ");
		stringBuilder.Append("vl_base_II as valorBaseCalculoImpostoImportacao, ");
		stringBuilder.Append("vl_outros as valorOutros, ");
		stringBuilder.Append("vl_despesas_aduaneir as valorDespesasAduaneiras, ");
		stringBuilder.Append("vl_II as valorImpostoImportacao, ");
		stringBuilder.Append("vl_IOF as valorIof");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.NFItens ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterTodosNotaFiscalNotasFiscaisItens()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalNotasFiscaisItens> list = new List<MapTableNotaFiscalNotasFiscaisItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
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
		stringBuilder.Append(" cd_nota_fiscal = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItens.codigoNotaFiscal));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
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
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscaisItens (");
		stringBuilder.Append("cd_nota_fiscal, ");
		stringBuilder.Append("vl_ordem, ");
		stringBuilder.Append("cd_produto, ");
		stringBuilder.Append("vl_quantidade, ");
		stringBuilder.Append("vl_unitario, ");
		stringBuilder.Append("vl_total, ");
		stringBuilder.Append("vl_base_icms, ");
		stringBuilder.Append("pc_icms, ");
		stringBuilder.Append("vl_icms, ");
		stringBuilder.Append("pc_ipi, ");
		stringBuilder.Append("vl_ipi, ");
		stringBuilder.Append("vl_pis, ");
		stringBuilder.Append("vl_cofins, ");
		stringBuilder.Append("vl_frete, ");
		stringBuilder.Append("vl_seguro, ");
		stringBuilder.Append("cd_classificacao_fis, ");
		stringBuilder.Append("cd_situacao_tributar, ");
		stringBuilder.Append("ds_produto, vl_total_fatura) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItens.codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItens.ordem));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_produto", NotaFiscalNotasFiscaisItens.codigoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_quantidade", NotaFiscalNotasFiscaisItens.quantidade));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_unitario", NotaFiscalNotasFiscaisItens.valorUnitario));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_total", NotaFiscalNotasFiscaisItens.valorTotal));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_base_icms", NotaFiscalNotasFiscaisItens.valorBaseICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_icms", NotaFiscalNotasFiscaisItens.aliquotaICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_icms", NotaFiscalNotasFiscaisItens.valorICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_ipi", NotaFiscalNotasFiscaisItens.aliquotaIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_ipi", NotaFiscalNotasFiscaisItens.valorIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_pis", NotaFiscalNotasFiscaisItens.valorPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_cofins", NotaFiscalNotasFiscaisItens.valorCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_frete", NotaFiscalNotasFiscaisItens.valorFrete));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_seguro", NotaFiscalNotasFiscaisItens.valorSeguro));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_classificacao_fis", NotaFiscalNotasFiscaisItens.codigoClassificacaoFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_situacao_tributar", NotaFiscalNotasFiscaisItens.codigoSituacaoTributaria));
		list.Add(BaseDadosERP.ObterNovoParametro("ds_produto", NotaFiscalNotasFiscaisItens.descricaoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_total_fatura", NotaFiscalNotasFiscaisItens.valorFatura));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalNotasFiscaisItens(MapTableNotaFiscalNotasFiscaisItens NotaFiscalNotasFiscaisItens, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscaisItens Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Ordem", "vl_ordem", NotaFiscalNotasFiscaisItens.ordem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", NotaFiscalNotasFiscaisItens.codigoProduto, camposAlterados));
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
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoClassificacaoFiscal", "cd_classificacao_fis", NotaFiscalNotasFiscaisItens.codigoClassificacaoFiscal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoSituacaoTributaria", "cd_situacao_tributar", NotaFiscalNotasFiscaisItens.codigoSituacaoTributaria, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoProduto", "ds_produto", NotaFiscalNotasFiscaisItens.descricaoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorFatura", "vl_total_fatura", NotaFiscalNotasFiscaisItens.valorFatura, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("cd_nota_fiscal = ? and ");
			stringBuilder.Append("vl_ordem = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", NotaFiscalNotasFiscaisItens.codigoNotaFiscal));
			list.Add(BaseDadosERP.ObterNovoParametro("vl_ordem", NotaFiscalNotasFiscaisItens.ordem));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalNotasFiscaisItens(int codigoNotaFiscal)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscaisItens ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirNotaFiscalNotasFiscaisItens(int codigoNotaFiscal, int ordem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NFNotasFiscaisItens ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_nota_fiscal = ? and");
		stringBuilder.Append(" vl_ordem = ? ");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_nota_fiscal", codigoNotaFiscal));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_ordem", codigoNotaFiscal));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItens(int codigoNotaFiscal, int ordem, int codigoSerieNotaFiscal)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensFE(int codigoFichaExpedicao)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItensFE(int codigoFichaExpedicao, int codigoFichaExpedicaoItem)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoCompra(int codigoPedidoCompra)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItensPedidoCompra(int codigoPedidoCompra, int codigoPedidoCompraItem)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda, int codigoPedidoVendaItem)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalNotasFiscaisItens(int codigoNotaFiscal, int codigoSerieNotaFiscal, int ordem)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(int codigoRecebimentoMaterialCliente)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensDevolucaoMaterialCliente(string codigoMaterialCliente)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterTodosNotaFiscalNotasFiscaisItens(DateTime DataPeriodoInicial, DateTime DataPeriodoFinal)
	{
		throw new NotImplementedException();
	}

	IList<MapTableNotaFiscalNotasFiscaisItens> INotaFiscalNotasFiscaisItens.ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal)
	{
		throw new NotImplementedException();
	}

	public MapTableNotaFiscalNotasFiscaisItens ObterNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int ordem, int codigoSerieNotaFiscal)
	{
		throw new NotImplementedException();
	}

	public int ExcluirNotaFiscalNotasFiscaisItens(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int ordem)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalNotasFiscaisItens> ObterNotaFiscalNotasFiscaisItensPedidoVenda(int codigoPedidoVenda, int codigoPedidoVendaItem, int notaCorte)
	{
		throw new NotImplementedException();
	}
}
