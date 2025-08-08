using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalCFOPs : INotaFiscalCFOPs
{
	private MapTableNotaFiscalCFOPs MapearClasse(DataRow row)
	{
		MapTableNotaFiscalCFOPs result = default(MapTableNotaFiscalCFOPs);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.numeracaoCFOP = BaseDadosERP.ObterDbValor<string>(row["numeracaoCFOP"]);
			result.seqCFOP = BaseDadosERP.ObterDbValor<string>(row["seqCFOP"]);
			result.exibirComo = BaseDadosERP.ObterDbValor<string>(row["exibirComo"]);
			result.nfe = BaseDadosERP.ObterDbValor<string>(row["nfe"]);
			result.isEntrada = BaseDadosERP.ObterDbValor<bool>(row["isEntrada"]);
			result.incideICMS = BaseDadosERP.ObterDbValor<int>(row["incideICMS"]);
			result.retemICMS = BaseDadosERP.ObterDbValor<int>(row["retemICMS"]);
			result.modalidadeICMS = BaseDadosERP.ObterDbValor<int>(row["modalidadeICMS"]);
			result.padraoICMS = BaseDadosERP.ObterDbValor<decimal>(row["padraoICMS"]);
			result.reducaoICMS = BaseDadosERP.ObterDbValor<decimal>(row["reducaoICMS"]);
			result.codigoModalidadeICMSST = BaseDadosERP.ObterDbValor<int>(row["codigoModalidadeICMSST"]);
			result.percentualBaseAgragadaICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualBaseAgragadaICMSST"]);
			result.percentualICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualICMSST"]);
			result.percentualReducaoBaseAgregadaICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualReducaoBaseAgregadaICMSST"]);
			result.incideIPI = BaseDadosERP.ObterDbValor<int>(row["incideIPI"]);
			result.retemIPI = BaseDadosERP.ObterDbValor<int>(row["retemIPI"]);
			result.modalidadeIPI = BaseDadosERP.ObterDbValor<int>(row["modalidadeIPI"]);
			result.padraoIPI = BaseDadosERP.ObterDbValor<decimal>(row["padraoIPI"]);
			result.incidePIS = BaseDadosERP.ObterDbValor<int>(row["incidePIS"]);
			result.retemPIS = BaseDadosERP.ObterDbValor<int>(row["retemPIS"]);
			result.modalidadePIS = BaseDadosERP.ObterDbValor<int>(row["modalidadePIS"]);
			result.padraoPIS = BaseDadosERP.ObterDbValor<decimal>(row["padraoPIS"]);
			result.incideCofins = BaseDadosERP.ObterDbValor<int>(row["incideCofins"]);
			result.retemCofins = BaseDadosERP.ObterDbValor<int>(row["retemCofins"]);
			result.modalidadeCofins = BaseDadosERP.ObterDbValor<int>(row["modalidadeCofins"]);
			result.valorCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorCofins"]);
			result.isCSLL = BaseDadosERP.ObterDbValor<bool>(row["isCSLL"]);
			result.valorCSLL = BaseDadosERP.ObterDbValor<decimal>(row["valorCSLL"]);
			result.isIR = BaseDadosERP.ObterDbValor<bool>(row["isIR"]);
			result.modalidadeIR = BaseDadosERP.ObterDbValor<int>(row["modalidadeIR"]);
			result.valorIR = BaseDadosERP.ObterDbValor<decimal>(row["valorIR"]);
			result.isISSQN = BaseDadosERP.ObterDbValor<bool>(row["isISSQN"]);
			result.modalidadeISSQN = BaseDadosERP.ObterDbValor<int>(row["modalidadeISSQN"]);
			result.valorISS = BaseDadosERP.ObterDbValor<decimal>(row["valorISS"]);
			result.isINSS = BaseDadosERP.ObterDbValor<bool>(row["isINSS"]);
			result.modalidadeINSS = BaseDadosERP.ObterDbValor<int>(row["modalidadeINSS"]);
			result.valorINSS = BaseDadosERP.ObterDbValor<decimal>(row["valorINSS"]);
			result.percINSS = BaseDadosERP.ObterDbValor<decimal>(row["percINSS"]);
			result.origemProduto = BaseDadosERP.ObterDbValor<int>(row["origemProduto"]);
			result.cfopAssociado = BaseDadosERP.ObterDbValor<int>(row["cfopAssociado"]);
			result.codigoTexto1 = BaseDadosERP.ObterDbValor<int>(row["codigoTexto1"]);
			result.codigoTexto2 = BaseDadosERP.ObterDbValor<int>(row["codigoTexto2"]);
			result.isGeraDuplicata = BaseDadosERP.ObterDbValor<bool>(row["isGeraDuplicata"]);
			result.isAtivo = BaseDadosERP.ObterDbValor<bool>(row["isAtivo"]);
			result.isEnviaConsignado = BaseDadosERP.ObterDbValor<bool>(row["isEnviaConsignado"]);
			result.isFaturaConsignado = BaseDadosERP.ObterDbValor<bool>(row["isFaturaConsignado"]);
			result.percentualRetencaoCofins = BaseDadosERP.ObterDbValor<decimal>(row["percentualRetencaoCofins"]);
			result.percentualRetencaoPis = BaseDadosERP.ObterDbValor<decimal>(row["percentualRetencaoPis"]);
			result.isConsumidorFinal = BaseDadosERP.ObterDbValor<bool>(row["isConsumidorFinal"]);
			result.usarIpiTabelaProduto = BaseDadosERP.ObterDbValor<bool>(row["usarIpiTabelaProduto"]);
			result.usarIcmsEstadoFederacao = BaseDadosERP.ObterDbValor<bool>(row["usarIcmsEstadoFederacao"]);
			result.codigoEnquadramentoIPI = BaseDadosERP.ObterDbValor<int>(row["codigoEnquadramentoIPI"]);
			result.percentualII = BaseDadosERP.ObterDbValor<decimal>(row["percentualII"]);
			result.percentualCreditoIcms = BaseDadosERP.ObterDbValor<decimal>(row["percentualCreditoIcms"]);
			result.isICMSInterestadual = BaseDadosERP.ObterDbValor<bool>(row["isICMSInterestadual"]);
			result.percentualIcmsInterestadualFundoPobreza = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsInterestadualFundoPobreza"]);
			result.percentualIcmsInterestadualUfDestino = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsInterestadualUfDestino"]);
			result.percentualIcmsInterestadualUfEnvolvidas = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsInterestadualUfEnvolvidas"]);
			result.isDevolucaoMaterialCliente = BaseDadosERP.ObterDbValor<bool>(row["isDevolucaoMaterialCliente"]);
			result.isUsarTabelaCest = BaseDadosERP.ObterDbValor<bool>(row["isUsarTabelaCest"]);
			result.percentualReducaoBaseCalculoICMSST = BaseDadosERP.ObterDbValor<decimal>(row["percentualReducaoBaseCalculoICMSST"]);
			result.isPrefeitura = BaseDadosERP.ObterDbValor<bool>(row["isPrefeitura"]);
			result.percentualFundoCombatePobreza = BaseDadosERP.ObterDbValor<decimal>(row["percentualFundoCombatePobreza"]);
			result.percentualFundoCombatePobrezaST = BaseDadosERP.ObterDbValor<decimal>(row["percentualFundoCombatePobrezaST"]);
			result.percentualIcmsStCargaMedia = BaseDadosERP.ObterDbValor<decimal>(row["percentualIcmsStCargaMedia"]);
			result.isEntregaFutura = BaseDadosERP.ObterDbValor<bool>(row["isEntregaFutura"]);
			result.isContaOrdem = BaseDadosERP.ObterDbValor<bool>(row["isContaOrdem"]);
			result.isSimplesRemessa = BaseDadosERP.ObterDbValor<bool>(row["isSimplesRemessa"]);
			result.extipi = BaseDadosERP.ObterDbValor<int>(row["extipi"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_cfop_numerico] as [numeracaoCFOP], ");
		stringBuilder.Append("[nm_cfop_numerico_seq] as [seqCFOP], ");
		stringBuilder.Append("[nm_cfop_exibicao] as [exibirComo], ");
		stringBuilder.Append("[nm_cfop_nfe] as [nfe], ");
		stringBuilder.Append("[ic_entrada] as [isEntrada], ");
		stringBuilder.Append("[cd_icms_incide] as [incideICMS], ");
		stringBuilder.Append("[cd_icms_retem] as [retemICMS], ");
		stringBuilder.Append("[cd_icms_modalidade] as [modalidadeICMS], ");
		stringBuilder.Append("cd_modBCCST as codigoModalidadeICMSST, ");
		stringBuilder.Append("pc_valor_adicionado_bc_st as percentualBaseAgragadaICMSST, ");
		stringBuilder.Append("pc_red_bc_icms_st as percentualReducaoBaseAgregadaICMSST, ");
		stringBuilder.Append("pc_icms_st as percentualICMSST, ");
		stringBuilder.Append("[pc_icms_st] as [percentualICMSST], ");
		stringBuilder.Append("[pc_red_bc_icms_st] as [percentualReducaoBaseAgregadaICMSST], ");
		stringBuilder.Append("[pc_icms_padrao] as [padraoICMS], ");
		stringBuilder.Append("[pc_icms_reduz] as [reducaoICMS], ");
		stringBuilder.Append("[cd_ipi_incide] as [incideIPI], ");
		stringBuilder.Append("[cd_ipi_retem] as [retemIPI], ");
		stringBuilder.Append("[cd_ipi_modalidade] as [modalidadeIPI], ");
		stringBuilder.Append("[pc_ipi_padrao] as [padraoIPI], ");
		stringBuilder.Append("[cd_pis_incide] as [incidePIS], ");
		stringBuilder.Append("[cd_pis_retem] as [retemPIS], ");
		stringBuilder.Append("[cd_pis_modalidade] as [modalidadePIS], ");
		stringBuilder.Append("[pc_pis] as [padraoPIS], ");
		stringBuilder.Append("[cd_cofins_incide] as [incideCofins], ");
		stringBuilder.Append("[cd_cofins_retem] as [retemCofins], ");
		stringBuilder.Append("[cd_cofins_modalidade] as [modalidadeCofins], ");
		stringBuilder.Append("[pc_cofins] as [valorCofins], ");
		stringBuilder.Append("[ic_csll] as [isCSLL], ");
		stringBuilder.Append("[pc_csll] as [valorCSLL], ");
		stringBuilder.Append("[ic_ir] as [isIR], ");
		stringBuilder.Append("[cd_ir_modalidade] as [modalidadeIR], ");
		stringBuilder.Append("[pc_ir] as [valorIR], ");
		stringBuilder.Append("[ic_issqn] as [isISSQN], ");
		stringBuilder.Append("[cd_issqn_modalidade] as [modalidadeISSQN], ");
		stringBuilder.Append("[pc_iss] as [valorISS], ");
		stringBuilder.Append("[ic_inss] as [isINSS], ");
		stringBuilder.Append("[cd_inss_modalidade] as [modalidadeINSS], ");
		stringBuilder.Append("[vl_inss] as [valorINSS], ");
		stringBuilder.Append("[pc_inss] as [percINSS], ");
		stringBuilder.Append("[cd_origem_produto] as [origemProduto], ");
		stringBuilder.Append("[cd_cfop_associado] as [cfopAssociado], ");
		stringBuilder.Append("[cd_texto_legal1] as [codigoTexto1], ");
		stringBuilder.Append("[cd_texto_legal2] as [codigoTexto2], ");
		stringBuilder.Append("[ic_gera_duplicata] as [isGeraDuplicata], ");
		stringBuilder.Append("[ic_ativo] as [isAtivo], ");
		stringBuilder.Append("[ic_envia_consignado] as [isEnviaConsignado], ");
		stringBuilder.Append("[ic_fatura_consignado] as [isFaturaConsignado], ");
		stringBuilder.Append("[pc_pis_retencao] as [percentualRetencaoPis], ");
		stringBuilder.Append("[pc_cofins_retencao] as [percentualRetencaoCofins], ");
		stringBuilder.Append("[ic_consumidor_final] as [isConsumidorFinal], ");
		stringBuilder.Append("[ic_ipi_tabela] as [usarIpiTabelaProduto], ");
		stringBuilder.Append("[ic_icms_uf] as [usarIcmsEstadoFederacao], ");
		stringBuilder.Append("[cd_enq_ipi] as [codigoEnquadramentoIPI], ");
		stringBuilder.Append("[pc_II] as [percentualII], ");
		stringBuilder.Append("[pc_cred_icms] as [percentualCreditoIcms], ");
		stringBuilder.Append("[ic_icms_uf_dest] as [isICMSInterestadual], ");
		stringBuilder.Append("[pc_icms_fundo_pobreza] as [percentualIcmsInterestadualFundoPobreza], ");
		stringBuilder.Append("[pc_icms_aliquota_interna_uf_destino] as [percentualIcmsInterestadualUfDestino], ");
		stringBuilder.Append("[pc_icms_aliquota_interestadual_uf_envolvidas] as [percentualIcmsInterestadualUfEnvolvidas], ");
		stringBuilder.Append("[ic_devolucao_mat_cli] as [isDevolucaoMaterialCliente], ");
		stringBuilder.Append("[ic_usar_tabela_cest] as [isUsarTabelaCest], ");
		stringBuilder.Append("[pc_red_bc_st] as [percentualReducaoBaseCalculoICMSST], ");
		stringBuilder.Append("[ic_prefeitura] as [isPrefeitura],");
		stringBuilder.Append("[pc_fcp] as [percentualFundoCombatePobreza],");
		stringBuilder.Append("[pc_fcpst] as [percentualFundoCombatePobrezaST], ");
		stringBuilder.Append("[pICMSSTCargaMedia] as [percentualIcmsStCargaMedia], ");
		stringBuilder.Append("[ic_entrega_futura] as [isEntregaFutura], ");
		stringBuilder.Append("[ic_conta_ordem] as [isContaOrdem], ");
		stringBuilder.Append("[ic_simples_remessa] as [isSimplesRemessa], ");
		stringBuilder.Append("[cd_extipi] as [extipi] ");
		stringBuilder.Append($" from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[CFOPs] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalCFOPs> list = new List<MapTableNotaFiscalCFOPs>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs(bool Prefeitura)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [ic_prefeitura] = @ic_prefeitura");
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_prefeitura", true));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalCFOPs> list2 = new List<MapTableNotaFiscalCFOPs>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsAtivos()
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [ic_ativo] = @ic_ativo");
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ativo", true));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalCFOPs> list2 = new List<MapTableNotaFiscalCFOPs>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsDevolucaoMaterialCliente()
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [ic_ativo] = @ic_ativo and ");
		stringBuilder.Append(" [ic_devolucao_mat_cli] = @ic_devolucao_mat_cli");
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ativo", true));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_devolucao_mat_cli", true));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalCFOPs> list2 = new List<MapTableNotaFiscalCFOPs>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableNotaFiscalCFOPs ObterNotaFiscalCFOPs(int codigoCFOP)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigoCFOP));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCFOPs ObterNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalCFOPs.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Insert into [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[CFOPs] (");
		stringBuilder.Append("[nm_cfop_numerico], ");
		stringBuilder.Append("[nm_cfop_numerico_seq], ");
		stringBuilder.Append("[nm_cfop_exibicao], ");
		stringBuilder.Append("[nm_cfop_nfe], ");
		stringBuilder.Append("[ic_entrada], ");
		stringBuilder.Append("[cd_icms_incide], ");
		stringBuilder.Append("[cd_icms_retem], ");
		stringBuilder.Append("[cd_icms_modalidade], ");
		stringBuilder.Append("[pc_icms_padrao], ");
		stringBuilder.Append("[pc_icms_reduz], ");
		stringBuilder.Append("[cd_ipi_incide], ");
		stringBuilder.Append("[cd_ipi_retem], ");
		stringBuilder.Append("[cd_ipi_modalidade], ");
		stringBuilder.Append("[pc_ipi_padrao], ");
		stringBuilder.Append("[cd_pis_incide], ");
		stringBuilder.Append("[cd_pis_retem], ");
		stringBuilder.Append("[cd_pis_modalidade], ");
		stringBuilder.Append("[pc_pis], ");
		stringBuilder.Append("[cd_cofins_incide], ");
		stringBuilder.Append("[cd_cofins_retem], ");
		stringBuilder.Append("[cd_cofins_modalidade], ");
		stringBuilder.Append("[pc_cofins], ");
		stringBuilder.Append("[ic_csll], ");
		stringBuilder.Append("[pc_csll], ");
		stringBuilder.Append("[ic_ir], ");
		stringBuilder.Append("[cd_ir_modalidade], ");
		stringBuilder.Append("[pc_ir], ");
		stringBuilder.Append("[ic_issqn], ");
		stringBuilder.Append("[cd_issqn_modalidade], ");
		stringBuilder.Append("[pc_iss], ");
		stringBuilder.Append("[ic_inss], ");
		stringBuilder.Append("[cd_inss_modalidade], ");
		stringBuilder.Append("[vl_inss], ");
		stringBuilder.Append("[pc_inss], ");
		stringBuilder.Append("[cd_origem_produto], ");
		stringBuilder.Append("[cd_cfop_associado], ");
		stringBuilder.Append("[cd_texto_legal1], ");
		stringBuilder.Append("[cd_texto_legal2], ");
		stringBuilder.Append("[ic_gera_duplicata], ");
		stringBuilder.Append("[ic_ativo], ");
		stringBuilder.Append("[ic_envia_consignado], ");
		stringBuilder.Append("[ic_fatura_consignado], ");
		stringBuilder.Append("[pc_pis_retencao], ");
		stringBuilder.Append("[pc_cofins_retencao], ");
		stringBuilder.Append("[ic_consumidor_final], ");
		stringBuilder.Append("[ic_ipi_tabela], ");
		stringBuilder.Append("[ic_icms_uf], ");
		stringBuilder.Append("[cd_modBCCST], ");
		stringBuilder.Append("[pc_valor_adicionado_bc_st], ");
		stringBuilder.Append("[pc_icms_st], ");
		stringBuilder.Append("[pc_red_bc_icms_st], ");
		stringBuilder.Append("[cd_enq_ipi], ");
		stringBuilder.Append("[pc_II], ");
		stringBuilder.Append("[pc_cred_icms], ");
		stringBuilder.Append("[ic_icms_uf_dest], ");
		stringBuilder.Append("[pc_icms_fundo_pobreza], ");
		stringBuilder.Append("[pc_icms_aliquota_interna_uf_destino], ");
		stringBuilder.Append("[pc_icms_aliquota_interestadual_uf_envolvidas], ");
		stringBuilder.Append("[ic_devolucao_mat_cli], ");
		stringBuilder.Append("[ic_usar_tabela_cest], ");
		stringBuilder.Append("[pc_red_bc_st], ");
		stringBuilder.Append("[ic_prefeitura], ");
		stringBuilder.Append("[pc_fcp], ");
		stringBuilder.Append("[pc_fcpst], ");
		stringBuilder.Append("[pICMSSTCargaMedia], ");
		stringBuilder.Append("[ic_entrega_futura], ");
		stringBuilder.Append("[ic_conta_ordem], ");
		stringBuilder.Append("[ic_simples_remessa], ");
		stringBuilder.Append("[cd_extipi] ");
		stringBuilder.Append(") Values (@nm_cfop_numerico,@nm_cfop_numerico_seq,@nm_cfop_exibicao,@nm_cfop_nfe,@ic_entrada,@cd_icms_incide,@cd_icms_retem,@cd_icms_modalidade,@pc_icms_padrao,@pc_icms_reduz,@cd_ipi_incide,@cd_ipi_retem,@cd_ipi_modalidade,@pc_ipi_padrao,@cd_pis_incide,@cd_pis_retem,@cd_pis_modalidade,@pc_pis,@cd_cofins_incide,@cd_cofins_retem,@cd_cofins_modalidade,@pc_cofins,@ic_csll,@pc_csll,@ic_ir,@cd_ir_modalidade,@pc_ir,@ic_issqn,@cd_issqn_modalidade,@pc_iss,@ic_inss,@cd_inss_modalidade,@vl_inss,@pc_inss,@cd_origem_produto,@cd_cfop_associado,@cd_texto_legal1,@cd_texto_legal2,@ic_gera_duplicata,@ic_ativo,@ic_envia_consignado,@ic_fatura_consignado,@pc_pis_retencao,@pc_cofins_retencao,@ic_consumidor_final,@ic_ipi_tabela,@ic_icms_uf,@cd_modBCCST,@pc_valor_adicionado_bc_st,@pc_icms_st,@pc_red_bc_icms_st,@cd_enq_ipi,@pc_II,@pc_cred_icms,@ic_icms_uf_dest,@pc_icms_fundo_pobreza,@pc_icms_aliquota_interna_uf_destino,@pc_icms_aliquota_interestadual_uf_envolvidas,@ic_devolucao_mat_cli,@ic_usar_tabela_cest,@pc_red_bc_st,@ic_prefeitura,@pc_fcp,@pc_fcpst,@pICMSSTCargaMedia,@ic_entrega_futura,@ic_conta_ordem,@ic_simples_remessa,@cd_extipi) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cfop_numerico", NotaFiscalCFOPs.numeracaoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cfop_numerico_seq", NotaFiscalCFOPs.seqCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cfop_exibicao", NotaFiscalCFOPs.exibirComo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cfop_nfe", NotaFiscalCFOPs.nfe));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_entrada", NotaFiscalCFOPs.isEntrada));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_icms_incide", NotaFiscalCFOPs.incideICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_icms_retem", NotaFiscalCFOPs.retemICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_icms_modalidade", NotaFiscalCFOPs.modalidadeICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_padrao", NotaFiscalCFOPs.padraoICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_reduz", NotaFiscalCFOPs.reducaoICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ipi_incide", NotaFiscalCFOPs.incideIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ipi_retem", NotaFiscalCFOPs.retemIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ipi_modalidade", NotaFiscalCFOPs.modalidadeIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_ipi_padrao", NotaFiscalCFOPs.padraoIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pis_incide", NotaFiscalCFOPs.incidePIS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pis_retem", NotaFiscalCFOPs.retemPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pis_modalidade", NotaFiscalCFOPs.modalidadePIS));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_pis", NotaFiscalCFOPs.padraoPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cofins_incide", NotaFiscalCFOPs.incideCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cofins_retem", NotaFiscalCFOPs.retemCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cofins_modalidade", NotaFiscalCFOPs.modalidadeCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_cofins", NotaFiscalCFOPs.valorCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_csll", NotaFiscalCFOPs.isCSLL));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_csll", NotaFiscalCFOPs.valorCSLL));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ir", NotaFiscalCFOPs.isIR));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_ir_modalidade", NotaFiscalCFOPs.modalidadeIR));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_ir", NotaFiscalCFOPs.valorIR));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_issqn", NotaFiscalCFOPs.isISSQN));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_issqn_modalidade", NotaFiscalCFOPs.modalidadeISSQN));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_iss", NotaFiscalCFOPs.valorISS));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_inss", NotaFiscalCFOPs.isINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_inss_modalidade", NotaFiscalCFOPs.modalidadeINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_inss", NotaFiscalCFOPs.valorINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_inss", NotaFiscalCFOPs.percINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_origem_produto", NotaFiscalCFOPs.origemProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cfop_associado", NotaFiscalCFOPs.cfopAssociado));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_texto_legal1", NotaFiscalCFOPs.codigoTexto1));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_texto_legal2", NotaFiscalCFOPs.codigoTexto2));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_gera_duplicata", NotaFiscalCFOPs.isGeraDuplicata));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ativo", NotaFiscalCFOPs.isAtivo));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_envia_consignado", NotaFiscalCFOPs.isEnviaConsignado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_fatura_consignado", NotaFiscalCFOPs.isFaturaConsignado));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_pis_retencao", NotaFiscalCFOPs.percentualRetencaoPis));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_cofins_retencao", NotaFiscalCFOPs.percentualRetencaoCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_consumidor_final", NotaFiscalCFOPs.isConsumidorFinal));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_ipi_tabela", NotaFiscalCFOPs.usarIpiTabelaProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_icms_uf", NotaFiscalCFOPs.usarIcmsEstadoFederacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modBCCST", NotaFiscalCFOPs.codigoModalidadeICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_valor_adicionado_bc_st", NotaFiscalCFOPs.percentualBaseAgragadaICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_st", NotaFiscalCFOPs.percentualICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_red_bc_icms_st", NotaFiscalCFOPs.percentualReducaoBaseAgregadaICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_enq_ipi", NotaFiscalCFOPs.codigoEnquadramentoIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_II", NotaFiscalCFOPs.percentualII));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_cred_icms", NotaFiscalCFOPs.percentualCreditoIcms));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_icms_uf_dest", NotaFiscalCFOPs.isICMSInterestadual));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_fundo_pobreza", NotaFiscalCFOPs.percentualIcmsInterestadualFundoPobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_aliquota_interna_uf_destino", NotaFiscalCFOPs.percentualIcmsInterestadualUfDestino));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_icms_aliquota_interestadual_uf_envolvidas", NotaFiscalCFOPs.percentualIcmsInterestadualUfEnvolvidas));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_devolucao_mat_cli", NotaFiscalCFOPs.isDevolucaoMaterialCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_usar_tabela_cest", NotaFiscalCFOPs.isUsarTabelaCest));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_red_bc_st", NotaFiscalCFOPs.percentualReducaoBaseCalculoICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_prefeitura", NotaFiscalCFOPs.isPrefeitura));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_fcp", NotaFiscalCFOPs.percentualFundoCombatePobreza));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_fcpst", NotaFiscalCFOPs.percentualFundoCombatePobrezaST));
		list.Add(BaseDadosERP.ObterNovoParametro("@pICMSSTCargaMedia", NotaFiscalCFOPs.percentualIcmsStCargaMedia));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_entrega_futura", NotaFiscalCFOPs.isEntregaFutura));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_conta_ordem", NotaFiscalCFOPs.isContaOrdem));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_simples_remessa", NotaFiscalCFOPs.isSimplesRemessa));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_extipi", NotaFiscalCFOPs.extipi));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append($"Update [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[CFOPs] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeracaoCFOP", "nm_cfop_numerico", NotaFiscalCFOPs.numeracaoCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "SeqCFOP", "nm_cfop_numerico_seq", NotaFiscalCFOPs.seqCFOP, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ExibirComo", "nm_cfop_exibicao", NotaFiscalCFOPs.exibirComo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nfe", "nm_cfop_nfe", NotaFiscalCFOPs.nfe, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsEntrada", "ic_entrada", NotaFiscalCFOPs.isEntrada, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IncideICMS", "cd_icms_incide", NotaFiscalCFOPs.incideICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RetemICMS", "cd_icms_retem", NotaFiscalCFOPs.retemICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeICMS", "cd_icms_modalidade", NotaFiscalCFOPs.modalidadeICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PadraoICMS", "pc_icms_padrao", NotaFiscalCFOPs.padraoICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ReducaoICMS", "pc_icms_reduz", NotaFiscalCFOPs.reducaoICMS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IncideIPI", "cd_ipi_incide", NotaFiscalCFOPs.incideIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RetemIPI", "cd_ipi_retem", NotaFiscalCFOPs.retemIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeIPI", "cd_ipi_modalidade", NotaFiscalCFOPs.modalidadeIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PadraoIPI", "pc_ipi_padrao", NotaFiscalCFOPs.padraoIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IncidePIS", "cd_pis_incide", NotaFiscalCFOPs.incidePIS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RetemPIS", "cd_pis_retem", NotaFiscalCFOPs.retemPIS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadePIS", "cd_pis_modalidade", NotaFiscalCFOPs.modalidadePIS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PadraoPIS", "pc_pis", NotaFiscalCFOPs.padraoPIS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IncideCofins", "cd_cofins_incide", NotaFiscalCFOPs.incideCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RetemCofins", "cd_cofins_retem", NotaFiscalCFOPs.retemCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeCofins", "cd_cofins_modalidade", NotaFiscalCFOPs.modalidadeCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCofins", "pc_cofins", NotaFiscalCFOPs.valorCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsCSLL", "ic_csll", NotaFiscalCFOPs.isCSLL, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCSLL", "pc_csll", NotaFiscalCFOPs.valorCSLL, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsIR", "ic_ir", NotaFiscalCFOPs.isIR, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeIR", "cd_ir_modalidade", NotaFiscalCFOPs.modalidadeIR, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorIR", "pc_ir", NotaFiscalCFOPs.valorIR, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsISSQN", "ic_issqn", NotaFiscalCFOPs.isISSQN, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeISSQN", "cd_issqn_modalidade", NotaFiscalCFOPs.modalidadeISSQN, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorISS", "pc_iss", NotaFiscalCFOPs.valorISS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsINSS", "ic_inss", NotaFiscalCFOPs.isINSS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeINSS", "cd_inss_modalidade", NotaFiscalCFOPs.modalidadeINSS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorINSS", "vl_inss", NotaFiscalCFOPs.valorINSS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercINSS", "pc_inss", NotaFiscalCFOPs.percINSS, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "OrigemProduto", "cd_origem_produto", NotaFiscalCFOPs.origemProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CfopAssociado", "cd_cfop_associado", NotaFiscalCFOPs.cfopAssociado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTexto1", "cd_texto_legal1", NotaFiscalCFOPs.codigoTexto1, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTexto2", "cd_texto_legal2", NotaFiscalCFOPs.codigoTexto2, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsGeraDuplicata", "ic_gera_duplicata", NotaFiscalCFOPs.isGeraDuplicata, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsAtivo", "ic_ativo", NotaFiscalCFOPs.isAtivo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsEnviaConsignado", "ic_envia_consignado", NotaFiscalCFOPs.isEnviaConsignado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFaturaConsignado", "ic_fatura_consignado", NotaFiscalCFOPs.isFaturaConsignado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualRetencaoPis", "pc_pis_retencao", NotaFiscalCFOPs.percentualRetencaoPis, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualRetencaoCofins", "pc_cofins_retencao", NotaFiscalCFOPs.percentualRetencaoCofins, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsConsumidorFinal", "ic_consumidor_final", NotaFiscalCFOPs.isConsumidorFinal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "UsarIpiTabelaProduto", "ic_ipi_tabela", NotaFiscalCFOPs.usarIpiTabelaProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "UsarIcmsEstadoFederacao", "ic_icms_uf", NotaFiscalCFOPs.usarIcmsEstadoFederacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModalidadeICMSST", "cd_modBCCST", NotaFiscalCFOPs.codigoModalidadeICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualBaseAgragadaICMSST", "pc_valor_adicionado_bc_st", NotaFiscalCFOPs.percentualBaseAgragadaICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualICMSST", "pc_icms_st", NotaFiscalCFOPs.percentualICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualReducaoBaseAgregadaICMSST", "pc_red_bc_icms_st", NotaFiscalCFOPs.percentualReducaoBaseAgregadaICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEnquadramentoIPI", "cd_enq_ipi", NotaFiscalCFOPs.codigoEnquadramentoIPI, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualII", "pc_II", NotaFiscalCFOPs.percentualII, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualCreditoIcms", "pc_cred_icms", NotaFiscalCFOPs.percentualCreditoIcms, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsICMSInterestadual", "ic_icms_uf_dest", NotaFiscalCFOPs.isICMSInterestadual, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsInterestadualFundoPobreza", "pc_icms_fundo_pobreza", NotaFiscalCFOPs.percentualIcmsInterestadualFundoPobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsInterestadualUfDestino", "pc_icms_aliquota_interna_uf_destino", NotaFiscalCFOPs.percentualIcmsInterestadualUfDestino, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsInterestadualUfEnvolvidas", "pc_icms_aliquota_interestadual_uf_envolvidas", NotaFiscalCFOPs.percentualIcmsInterestadualUfEnvolvidas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsDevolucaoMaterialCliente", "ic_devolucao_mat_cli", NotaFiscalCFOPs.isDevolucaoMaterialCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsUsarTabelaCest", "ic_usar_tabela_cest", NotaFiscalCFOPs.isUsarTabelaCest, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualReducaoBaseCalculoICMSST", "pc_red_bc_st", NotaFiscalCFOPs.percentualReducaoBaseCalculoICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsPrefeitura", "ic_prefeitura", NotaFiscalCFOPs.isPrefeitura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualFundoCombatePobreza", "pc_fcp", NotaFiscalCFOPs.percentualFundoCombatePobreza, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualFundoCombatePobrezaST", "pc_fcpst", NotaFiscalCFOPs.percentualFundoCombatePobrezaST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualIcmsStCargaMedia", "pICMSSTCargaMedia", NotaFiscalCFOPs.percentualIcmsStCargaMedia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsEntregaFutura", "ic_entrega_futura", NotaFiscalCFOPs.isEntregaFutura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsContaOrdem", "ic_conta_ordem", NotaFiscalCFOPs.isContaOrdem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsSimplesRemessa", "ic_simples_remessa", NotaFiscalCFOPs.isSimplesRemessa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Extipi", "cd_extipi", NotaFiscalCFOPs.extipi, camposAlterados));
			if (BaseDadosERP.TestaParametrosUpdade(list))
			{
				stringBuilder.Append(" Where ");
				stringBuilder.Append("id = @id");
				list.Add(BaseDadosERP.ObterNovoParametro("@id", NotaFiscalCFOPs.id));
				result = BaseDadosERP.Update(stringBuilder.ToString(), list);
			}
		}
		return result;
	}

	public int ExcluirNotaFiscalCFOPs(int codigoCFOP)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Delete from [{BaseDadosERP.NomeServidor}].[{BaseDadosERP.NomeBaseDados}].[NotaFiscal].[CFOPs] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigoCFOP));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
