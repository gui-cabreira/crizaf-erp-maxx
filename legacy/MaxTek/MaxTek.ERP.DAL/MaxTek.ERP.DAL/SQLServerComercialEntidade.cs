using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialEntidade : IComercialEntidade
{
	private MapTableComercialEntidade MapearClasse(DataRow row)
	{
		MapTableComercialEntidade result = default(MapTableComercialEntidade);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.codigoGpsCliente = BaseDadosERP.ObterDbValor<int>(row["codigoGpsCliente"]);
			result.CodigoGpsFornecedor = BaseDadosERP.ObterDbValor<int>(row["CodigoGpsFornecedor"]);
			result.IsCliente = BaseDadosERP.ObterDbValor<bool>(row["IsCliente"]);
			result.isFornecedor = BaseDadosERP.ObterDbValor<bool>(row["isFornecedor"]);
			result.isRepresentante = BaseDadosERP.ObterDbValor<bool>(row["isRepresentante"]);
			result.isSubContratado = BaseDadosERP.ObterDbValor<bool>(row["isSubContratado"]);
			result.isTransportadora = BaseDadosERP.ObterDbValor<bool>(row["isTransportadora"]);
			result.nomeFantasia = BaseDadosERP.ObterDbValor<string>(row["nomeFantasia"]);
			result.razaoSocial = BaseDadosERP.ObterDbValor<string>(row["razaoSocial"]);
			result.cnpj = BaseDadosERP.ObterDbValor<string>(row["cnpj"]);
			result.inscricaoEstadual = BaseDadosERP.ObterDbValor<string>(row["inscricaoEstadual"]);
			result.inscricaoMunicipal = BaseDadosERP.ObterDbValor<string>(row["inscricaoMunicipal"]);
			result.codigoEspecialidade = BaseDadosERP.ObterDbValor<int>(row["codigoEspecialidade"]);
			result.endereco = BaseDadosERP.ObterDbValor<string>(row["endereco"]);
			result.complemento = BaseDadosERP.ObterDbValor<string>(row["complemento"]);
			result.bairro = BaseDadosERP.ObterDbValor<string>(row["bairro"]);
			result.cep = BaseDadosERP.ObterDbValor<string>(row["cep"]);
			result.cidade = BaseDadosERP.ObterDbValor<string>(row["cidade"]);
			result.pais = BaseDadosERP.ObterDbValor<string>(row["pais"]);
			result.uf = BaseDadosERP.ObterDbValor<string>(row["uf"]);
			result.telefone = BaseDadosERP.ObterDbValor<string>(row["telefone"]);
			result.fax = BaseDadosERP.ObterDbValor<string>(row["fax"]);
			result.site = BaseDadosERP.ObterDbValor<string>(row["site"]);
			result.email = BaseDadosERP.ObterDbValor<string>(row["email"]);
			result.isProspecto = BaseDadosERP.ObterDbValor<bool>(row["isProspecto"]);
			result.codigoCertificacao = BaseDadosERP.ObterDbValor<int>(row["codigoCertificacao"]);
			result.dataValidadeCertificacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataValidadeCertificacao"]);
			result.dataCadastro = BaseDadosERP.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.dataAtualizacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoRepresentante = BaseDadosERP.ObterDbValor<int>(row["codigoRepresentante"]);
			result.codigoFuncionario = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionario"]);
			result.codigoTipoPagamento = BaseDadosERP.ObterDbValor<int>(row["codigoTipoPagamento"]);
			result.codigoModoPagamento = BaseDadosERP.ObterDbValor<int>(row["codigoModoPagamento"]);
			result.valorCredito = BaseDadosERP.ObterDbValor<decimal>(row["valorCredito"]);
			result.isBloqueado = BaseDadosERP.ObterDbValor<bool>(row["isBloqueado"]);
			result.IsQualificado = BaseDadosERP.ObterDbValor<bool>(row["IsQualificado"]);
			result.notaIqf = BaseDadosERP.ObterDbValor<string>(row["notaIqf"]);
			result.codigoCfopPadrao = BaseDadosERP.ObterDbValor<int>(row["codigoCfopPadrao"]);
			result.logo = BaseDadosERP.ObterDbValor<Image>(row["logo"]);
			if (result.cnpj == "IE")
			{
				result.cnpj = result.inscricaoEstadual;
			}
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[cd_gps_cli] as [codigoGpsCliente], ");
		stringBuilder.Append("[cd_gps_for] as [CodigoGpsFornecedor], ");
		stringBuilder.Append("[ic_cliente] as [IsCliente], ");
		stringBuilder.Append("[ic_fornecedor] as [isFornecedor], ");
		stringBuilder.Append("[ic_representante] as [isRepresentante], ");
		stringBuilder.Append("[ic_subcontratado] as [isSubContratado], ");
		stringBuilder.Append("[ic_transportadora] as [isTransportadora], ");
		stringBuilder.Append("[nm_fantasia] as [nomeFantasia], ");
		stringBuilder.Append("[nm_razao_social] as [razaoSocial], ");
		stringBuilder.Append("[cd_cnpj] as [cnpj], ");
		stringBuilder.Append("[cd_inscricao_estadual] as [inscricaoEstadual], ");
		stringBuilder.Append("[cd_inscricao_municipal] as [inscricaoMunicipal], ");
		stringBuilder.Append("[cd_especialidade] as [codigoEspecialidade], ");
		stringBuilder.Append("[nm_endereco] as [endereco], ");
		stringBuilder.Append("[nm_complemento] as [complemento], ");
		stringBuilder.Append("[nm_bairro] as [bairro], ");
		stringBuilder.Append("[nm_cep] as [cep], ");
		stringBuilder.Append("[nm_cidade] as [cidade], ");
		stringBuilder.Append("[nm_pais] as [pais], ");
		stringBuilder.Append("[nm_uf] as [uf], ");
		stringBuilder.Append("[nm_telefone] as [telefone], ");
		stringBuilder.Append("[nm_fax] as [fax], ");
		stringBuilder.Append("[nm_site] as [site], ");
		stringBuilder.Append("[nm_email] as [email], ");
		stringBuilder.Append("[ic_prospecto] as [isProspecto], ");
		stringBuilder.Append("[cd_certificacao] as [codigoCertificacao], ");
		stringBuilder.Append("[dt_validade_certificacao] as [dataValidadeCertificacao], ");
		stringBuilder.Append("[dt_cadastro] as [dataCadastro], ");
		stringBuilder.Append("[dt_atualizacao] as [dataAtualizacao], ");
		stringBuilder.Append("[cd_representante] as [codigoRepresentante], ");
		stringBuilder.Append("[cd_funcionario] as [codigoFuncionario], ");
		stringBuilder.Append("[cd_condicao_pagamento] as [codigoTipoPagamento], ");
		stringBuilder.Append("[cd_modo_pagamento] as [codigoModoPagamento], ");
		stringBuilder.Append("[vl_credito] as [valorCredito], ");
		stringBuilder.Append("[ic_bloqueado] as [isBloqueado], ");
		stringBuilder.Append("[ic_qualificado] as [IsQualificado], ");
		stringBuilder.Append("[vl_iqf] as [notaIqf], ");
		stringBuilder.Append("[cd_cfopi_padrao] as [codigoCfopPadrao], ");
		stringBuilder.Append("[im_logo] as [logo]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[Entidade] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidade> list = new List<MapTableComercialEntidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidadeCliente()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [ic_cliente] = 1");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidade> list = new List<MapTableComercialEntidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidadeFornecedor()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ic_fornecedor = 1");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidade> list = new List<MapTableComercialEntidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidadeSubContratado()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [ic_subcontratado] = 1");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidade> list = new List<MapTableComercialEntidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidadeRepresentante()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [ic_representante] = 1");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidade> list = new List<MapTableComercialEntidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidadeTransportadora()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where [ic_transportadora] = 1");
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidade> list = new List<MapTableComercialEntidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialEntidade ObterComercialEntidade(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidade ObterComercialEntidade(MapTableComercialEntidade ComercialEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidade.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidade(MapTableComercialEntidade ComercialEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[Entidade] (");
		stringBuilder.Append("cd_gps_cli, ");
		stringBuilder.Append("cd_gps_for, ");
		stringBuilder.Append("ic_cliente, ");
		stringBuilder.Append("ic_fornecedor, ");
		stringBuilder.Append("ic_representante, ");
		stringBuilder.Append("ic_subcontratado, ");
		stringBuilder.Append("ic_transportadora, ");
		stringBuilder.Append("nm_fantasia, ");
		stringBuilder.Append("nm_razao_social, ");
		stringBuilder.Append("cd_cnpj, ");
		stringBuilder.Append("cd_inscricao_estadual, ");
		stringBuilder.Append("cd_inscricao_municipal, ");
		stringBuilder.Append("cd_especialidade, ");
		stringBuilder.Append("nm_endereco, ");
		stringBuilder.Append("nm_complemento, ");
		stringBuilder.Append("nm_bairro, ");
		stringBuilder.Append("nm_cep, ");
		stringBuilder.Append("nm_cidade, ");
		stringBuilder.Append("nm_pais, ");
		stringBuilder.Append("nm_uf, ");
		stringBuilder.Append("nm_telefone, ");
		stringBuilder.Append("nm_fax, ");
		stringBuilder.Append("nm_site, ");
		stringBuilder.Append("nm_email, ");
		stringBuilder.Append("ic_prospecto, ");
		stringBuilder.Append("cd_certificacao, ");
		stringBuilder.Append("dt_validade_certificacao, ");
		stringBuilder.Append("dt_cadastro, ");
		stringBuilder.Append("dt_atualizacao, ");
		stringBuilder.Append("cd_representante, ");
		stringBuilder.Append("cd_funcionario, ");
		stringBuilder.Append("cd_condicao_pagamento, ");
		stringBuilder.Append("cd_modo_pagamento, ");
		stringBuilder.Append("vl_credito, ");
		stringBuilder.Append("ic_bloqueado, ");
		stringBuilder.Append("ic_qualificado, ");
		stringBuilder.Append("vl_iqf, ");
		stringBuilder.Append("cd_cfopi_padrao, ");
		stringBuilder.Append("im_logo ) ");
		stringBuilder.Append(" Values (@cd_gps_cli,@cd_gps_for,@ic_cliente,@ic_fornecedor,@ic_representante,@ic_subcontratado,@ic_transportadora,@nm_fantasia,@nm_razao_social,@cd_cnpj,@cd_inscricao_estadual,@cd_inscricao_municipal,@cd_especialidade,@nm_endereco,@nm_complemento,@nm_bairro,@nm_cep,@nm_cidade,@nm_pais,@nm_uf,@nm_telefone,@nm_fax,@nm_site,@nm_email,@ic_prospecto,@cd_certificacao,@dt_validade_certificacao,@dt_cadastro,@dt_atualizacao,@cd_representante,@cd_funcionario,@cd_condicao_pagamento,@cd_modo_pagamento,@vl_credito,@ic_bloqueado,@ic_qualificado,@vl_iqf,@cd_cfopi_padrao,@im_logo) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_gps_cli", ComercialEntidade.codigoGpsCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_gps_for", ComercialEntidade.CodigoGpsFornecedor));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_cliente", ComercialEntidade.IsCliente));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_fornecedor", ComercialEntidade.isFornecedor));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_representante", ComercialEntidade.isRepresentante));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_subcontratado", ComercialEntidade.isSubContratado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_transportadora", ComercialEntidade.isTransportadora));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fantasia", ComercialEntidade.nomeFantasia));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_razao_social", ComercialEntidade.razaoSocial));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cnpj", ComercialEntidade.cnpj));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_inscricao_estadual", ComercialEntidade.inscricaoEstadual));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_inscricao_municipal", ComercialEntidade.inscricaoMunicipal));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_especialidade", ComercialEntidade.codigoEspecialidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_endereco", ComercialEntidade.endereco));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_complemento", ComercialEntidade.complemento));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_bairro", ComercialEntidade.bairro));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cep", ComercialEntidade.cep));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cidade", ComercialEntidade.cidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_pais", ComercialEntidade.pais));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_uf", ComercialEntidade.uf));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_telefone", ComercialEntidade.telefone));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_fax", ComercialEntidade.fax));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_site", ComercialEntidade.site));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_email", ComercialEntidade.email));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_prospecto", ComercialEntidade.isProspecto));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_certificacao", ComercialEntidade.codigoCertificacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_validade_certificacao", ComercialEntidade.dataValidadeCertificacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_cadastro", ComercialEntidade.dataCadastro));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_atualizacao", ComercialEntidade.dataAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_representante", ComercialEntidade.codigoRepresentante));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario", ComercialEntidade.codigoFuncionario));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_condicao_pagamento", ComercialEntidade.codigoTipoPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modo_pagamento", ComercialEntidade.codigoModoPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_credito", ComercialEntidade.valorCredito));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_bloqueado", ComercialEntidade.isBloqueado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_qualificado", ComercialEntidade.IsQualificado));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_iqf", ComercialEntidade.notaIqf));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cfopi_padrao", ComercialEntidade.codigoCfopPadrao));
		list.Add(BaseDadosERP.ObterNovoParametro("@im_logo", ComercialEntidade.logo));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidade(MapTableComercialEntidade ComercialEntidade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[Entidade] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoGpsCliente", "cd_gps_cli", ComercialEntidade.codigoGpsCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoGpsFornecedor", "cd_gps_for", ComercialEntidade.CodigoGpsFornecedor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsCliente", "ic_cliente", ComercialEntidade.IsCliente, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFornecedor", "ic_fornecedor", ComercialEntidade.isFornecedor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsRepresentante", "ic_representante", ComercialEntidade.isRepresentante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsSubContratado", "ic_subcontratado", ComercialEntidade.isSubContratado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsTransportadora", "ic_transportadora", ComercialEntidade.isTransportadora, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeFantasia", "nm_fantasia", ComercialEntidade.nomeFantasia, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "RazaoSocial", "nm_razao_social", ComercialEntidade.razaoSocial, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cnpj", "cd_cnpj", ComercialEntidade.cnpj, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "InscricaoEstadual", "cd_inscricao_estadual", ComercialEntidade.inscricaoEstadual, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "InscricaoMunicipal", "cd_inscricao_municipal", ComercialEntidade.inscricaoMunicipal, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEspecialidade", "cd_especialidade", ComercialEntidade.codigoEspecialidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Endereco", "nm_endereco", ComercialEntidade.endereco, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Complemento", "nm_complemento", ComercialEntidade.complemento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Bairro", "nm_bairro", ComercialEntidade.bairro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cep", "nm_cep", ComercialEntidade.cep, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cidade", "nm_cidade", ComercialEntidade.cidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Pais", "nm_pais", ComercialEntidade.pais, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Uf", "nm_uf", ComercialEntidade.uf, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Telefone", "nm_telefone", ComercialEntidade.telefone, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Fax", "nm_fax", ComercialEntidade.fax, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Site", "nm_site", ComercialEntidade.site, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", ComercialEntidade.email, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsProspecto", "ic_prospecto", ComercialEntidade.isProspecto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCertificacao", "cd_certificacao", ComercialEntidade.codigoCertificacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataValidadeCertificacao", "dt_validade_certificacao", ComercialEntidade.dataValidadeCertificacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_cadastro", ComercialEntidade.dataCadastro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", ComercialEntidade.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRepresentante", "cd_representante", ComercialEntidade.codigoRepresentante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "cd_funcionario", ComercialEntidade.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTipoPagamento", "cd_condicao_pagamento", ComercialEntidade.codigoTipoPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModoPagamento", "cd_modo_pagamento", ComercialEntidade.codigoModoPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCredito", "vl_credito", ComercialEntidade.valorCredito, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsBloqueado", "ic_bloqueado", ComercialEntidade.isBloqueado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsQualificado", "ic_qualificado", ComercialEntidade.IsQualificado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NotaIqf", "vl_iqf", ComercialEntidade.notaIqf, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCfopPadrao", "cd_cfopi_padrao", ComercialEntidade.codigoCfopPadrao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Logo", "im_logo", ComercialEntidade.logo, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidade.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidade(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[Entidade] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
