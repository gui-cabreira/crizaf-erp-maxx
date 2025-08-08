using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalCFOPs : INotaFiscalCFOPs
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
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigoCFOP, ");
		stringBuilder.Append("nm_cfop_numerico as numeracaoCFOP, ");
		stringBuilder.Append("nm_cfop_numerico_seq as seqCFOP, ");
		stringBuilder.Append("nm_cfop_exibicao as exibirComo, ");
		stringBuilder.Append("nm_cfop_nfe as nfe, ");
		stringBuilder.Append("ic_entrada as isEntrada, ");
		stringBuilder.Append("cd_icms_incide as incideICMS, ");
		stringBuilder.Append("cd_icms_retem as retemICMS, ");
		stringBuilder.Append("cd_icms_modalidade as modalidadeICMS, ");
		stringBuilder.Append("pc_icms_padrao as padraoICMS, ");
		stringBuilder.Append("pc_icms_reduz as reducaoICMS, ");
		stringBuilder.Append("cd_modBCCST as modalidadeICMSSTBaseCalculo, ");
		stringBuilder.Append("pc_valor_adicionado_bc_st as percentualAcrescimoBaseCalculoST, ");
		stringBuilder.Append("cd_ipi_incide as incideIPI, ");
		stringBuilder.Append("cd_ipi_retem as retemIPI, ");
		stringBuilder.Append("cd_ipi_modalidade as modalidadeIPI, ");
		stringBuilder.Append("pc_ipi_padrao as padraoIPI, ");
		stringBuilder.Append("cd_pis_incide as incidePIS, ");
		stringBuilder.Append("cd_pis_retem as retemPIS, ");
		stringBuilder.Append("cd_pis_modalidade as modalidadePIS, ");
		stringBuilder.Append("pc_pis as padraoPIS, ");
		stringBuilder.Append("cd_cofins_incide as incideCofins, ");
		stringBuilder.Append("cd_cofins_retem as retemCofins, ");
		stringBuilder.Append("cd_cofins_modalidade as modalidadeCofins, ");
		stringBuilder.Append("pc_cofins as valorCofins, ");
		stringBuilder.Append("ic_csll as isCSLL, ");
		stringBuilder.Append("pc_csll as valorCSLL, ");
		stringBuilder.Append("ic_ir as isIR, ");
		stringBuilder.Append("cd_ir_modalidade as modalidadeIR, ");
		stringBuilder.Append("pc_ir as valorIR, ");
		stringBuilder.Append("ic_issqn as isISSQN, ");
		stringBuilder.Append("cd_issqn_modalidade as modalidadeISSQN, ");
		stringBuilder.Append("pc_iss as valorISS, ");
		stringBuilder.Append("ic_inss as isINSS, ");
		stringBuilder.Append("cd_inss_modalidade as modalidadeINSS, ");
		stringBuilder.Append("vl_inss as valorINSS, ");
		stringBuilder.Append("pc_inss as percINSS, ");
		stringBuilder.Append("cd_origem_produto as origemProduto, ");
		stringBuilder.Append("cd_cfop_associado as cfopAssociado, ");
		stringBuilder.Append("cd_texto_legal1 as codigoTexto1, ");
		stringBuilder.Append("cd_texto_legal2 as codigoTexto2, ");
		stringBuilder.Append("ic_gera_duplicata as isGeraDuplicata, ");
		stringBuilder.Append("ic_ativo as isAtivo");
		stringBuilder.Append(" from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCFOPs ");
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

	public MapTableNotaFiscalCFOPs ObterNotaFiscalCFOPs(int codigoCFOP)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", codigoCFOP));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableNotaFiscalCFOPs ObterNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalCFOPs.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCFOPs (");
		stringBuilder.Append("nm_cfop_numerico, ");
		stringBuilder.Append("nm_cfop_numerico_seq, ");
		stringBuilder.Append("nm_cfop_exibicao, ");
		stringBuilder.Append("nm_cfop_nfe, ");
		stringBuilder.Append("ic_entrada, ");
		stringBuilder.Append("cd_icms_incide, ");
		stringBuilder.Append("cd_icms_retem, ");
		stringBuilder.Append("cd_icms_modalidade, ");
		stringBuilder.Append("pc_icms_padrao, ");
		stringBuilder.Append("pc_icms_reduz, ");
		stringBuilder.Append("cd_ipi_incide, ");
		stringBuilder.Append("cd_ipi_retem, ");
		stringBuilder.Append("cd_ipi_modalidade, ");
		stringBuilder.Append("pc_ipi_padrao, ");
		stringBuilder.Append("cd_pis_incide, ");
		stringBuilder.Append("cd_pis_retem, ");
		stringBuilder.Append("cd_pis_modalidade, ");
		stringBuilder.Append("pc_pis, ");
		stringBuilder.Append("cd_cofins_incide, ");
		stringBuilder.Append("cd_cofins_retem, ");
		stringBuilder.Append("cd_cofins_modalidade, ");
		stringBuilder.Append("pc_cofins, ");
		stringBuilder.Append("ic_csll, ");
		stringBuilder.Append("pc_csll, ");
		stringBuilder.Append("ic_ir, ");
		stringBuilder.Append("cd_ir_modalidade, ");
		stringBuilder.Append("pc_ir, ");
		stringBuilder.Append("ic_issqn, ");
		stringBuilder.Append("cd_issqn_modalidade, ");
		stringBuilder.Append("pc_iss, ");
		stringBuilder.Append("ic_inss, ");
		stringBuilder.Append("cd_inss_modalidade, ");
		stringBuilder.Append("vl_inss, ");
		stringBuilder.Append("pc_inss, ");
		stringBuilder.Append("cd_origem_produto, ");
		stringBuilder.Append("cd_cfop_associado, ");
		stringBuilder.Append("cd_texto_legal1, ");
		stringBuilder.Append("cd_texto_legal2, ");
		stringBuilder.Append("ic_gera_duplicata, ");
		stringBuilder.Append("ic_ativo, ");
		stringBuilder.Append("cd_modBCCST, ");
		stringBuilder.Append("pc_valor_adicionado_bc_st) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosERP.ObterNovoParametro("nm_cfop_numerico", NotaFiscalCFOPs.numeracaoCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_cfop_numerico_seq", NotaFiscalCFOPs.seqCFOP));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_cfop_exibicao", NotaFiscalCFOPs.exibirComo));
		list.Add(BaseDadosERP.ObterNovoParametro("nm_cfop_nfe", NotaFiscalCFOPs.nfe));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_entrada", NotaFiscalCFOPs.isEntrada));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_icms_incide", NotaFiscalCFOPs.incideICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_icms_retem", NotaFiscalCFOPs.retemICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_icms_modalidade", NotaFiscalCFOPs.modalidadeICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_icms_padrao", NotaFiscalCFOPs.padraoICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_icms_reduz", NotaFiscalCFOPs.reducaoICMS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_ipi_incide", NotaFiscalCFOPs.incideIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_ipi_retem", NotaFiscalCFOPs.retemIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_ipi_modalidade", NotaFiscalCFOPs.modalidadeIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_ipi_padrao", NotaFiscalCFOPs.padraoIPI));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_pis_incide", NotaFiscalCFOPs.incidePIS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_pis_retem", NotaFiscalCFOPs.retemPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_pis_modalidade", NotaFiscalCFOPs.modalidadePIS));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_pis", NotaFiscalCFOPs.padraoPIS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cofins_incide", NotaFiscalCFOPs.incideCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cofins_retem", NotaFiscalCFOPs.retemCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cofins_modalidade", NotaFiscalCFOPs.modalidadeCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_cofins", NotaFiscalCFOPs.valorCofins));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_csll", NotaFiscalCFOPs.isCSLL));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_csll", NotaFiscalCFOPs.valorCSLL));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_ir", NotaFiscalCFOPs.isIR));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_ir_modalidade", NotaFiscalCFOPs.modalidadeIR));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_ir", NotaFiscalCFOPs.valorIR));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_issqn", NotaFiscalCFOPs.isISSQN));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_issqn_modalidade", NotaFiscalCFOPs.modalidadeISSQN));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_iss", NotaFiscalCFOPs.valorISS));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_inss", NotaFiscalCFOPs.isINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_inss_modalidade", NotaFiscalCFOPs.modalidadeINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("vl_inss", NotaFiscalCFOPs.valorINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_inss", NotaFiscalCFOPs.percINSS));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_origem_produto", NotaFiscalCFOPs.origemProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_cfop_associado", NotaFiscalCFOPs.cfopAssociado));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_texto_legal1", NotaFiscalCFOPs.codigoTexto1));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_texto_legal2", NotaFiscalCFOPs.codigoTexto2));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_gera_duplicata", NotaFiscalCFOPs.isGeraDuplicata));
		list.Add(BaseDadosERP.ObterNovoParametro("ic_ativo", NotaFiscalCFOPs.isAtivo));
		list.Add(BaseDadosERP.ObterNovoParametro("cd_modBCCST", NotaFiscalCFOPs.codigoModalidadeICMSST));
		list.Add(BaseDadosERP.ObterNovoParametro("pc_valor_adicionado_bc_st", NotaFiscalCFOPs.percentualBaseAgragadaICMSST));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCFOPs Set ");
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
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ModalidadeICMSSTBaseCalculo", "cd_modBCCST", NotaFiscalCFOPs.codigoModalidadeICMSST, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualAcrescimoBaseCalculoST", "pc_valor_adicionado_bc_st", NotaFiscalCFOPs.percentualBaseAgragadaICMSST, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosERP.ObterNovoParametro("id", NotaFiscalCFOPs.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirNotaFiscalCFOPs(int codigoCFOP)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosERP.NomeBaseDados + "Erp.NotaFiscalCFOPs ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("id", codigoCFOP));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsAtivos()
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsDevolucaoMaterialCliente()
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs(bool Prefeitura)
	{
		throw new NotImplementedException();
	}
}
