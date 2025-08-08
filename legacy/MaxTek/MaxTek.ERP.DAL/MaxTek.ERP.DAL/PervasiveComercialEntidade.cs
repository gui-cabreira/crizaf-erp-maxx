using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialEntidade : IComercialEntidade
{
	private MapTableComercialEntidade MapearClasse(DataRow row)
	{
		MapTableComercialEntidade result = default(MapTableComercialEntidade);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.codigoGpsCliente = BaseDadosGPS.ObterDbValor<int>(row["codigoGpsCliente"]);
			result.CodigoGpsFornecedor = BaseDadosGPS.ObterDbValor<int>(row["CodigoGpsFornecedor"]);
			result.IsCliente = BaseDadosGPS.ObterDbValor<bool>(row["IsCliente"]);
			result.isFornecedor = BaseDadosGPS.ObterDbValor<bool>(row["isFornecedor"]);
			result.isRepresentante = BaseDadosGPS.ObterDbValor<bool>(row["isRepresentante"]);
			result.isSubContratado = BaseDadosGPS.ObterDbValor<bool>(row["isSubContratado"]);
			result.isTransportadora = BaseDadosGPS.ObterDbValor<bool>(row["isTransportadora"]);
			result.nomeFantasia = BaseDadosGPS.ObterDbValor<string>(row["nomeFantasia"]);
			result.razaoSocial = BaseDadosGPS.ObterDbValor<string>(row["razaoSocial"]);
			result.cnpj = BaseDadosGPS.ObterDbValor<string>(row["cnpj"]);
			result.inscricaoEstadual = BaseDadosGPS.ObterDbValor<string>(row["inscricaoEstadual"]);
			result.inscricaoMunicipal = BaseDadosGPS.ObterDbValor<string>(row["inscricaoMunicipal"]);
			result.codigoEspecialidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEspecialidade"]);
			result.endereco = BaseDadosGPS.ObterDbValor<string>(row["endereco"]);
			result.complemento = BaseDadosGPS.ObterDbValor<string>(row["complemento"]);
			result.bairro = BaseDadosGPS.ObterDbValor<string>(row["bairro"]);
			result.cep = BaseDadosGPS.ObterDbValor<string>(row["cep"]);
			result.cidade = BaseDadosGPS.ObterDbValor<string>(row["cidade"]);
			result.pais = BaseDadosGPS.ObterDbValor<string>(row["pais"]);
			result.uf = BaseDadosGPS.ObterDbValor<string>(row["uf"]);
			result.telefone = BaseDadosGPS.ObterDbValor<string>(row["telefone"]);
			result.fax = BaseDadosGPS.ObterDbValor<string>(row["fax"]);
			result.site = BaseDadosGPS.ObterDbValor<string>(row["site"]);
			result.email = BaseDadosGPS.ObterDbValor<string>(row["email"]);
			result.isProspecto = BaseDadosGPS.ObterDbValor<bool>(row["isProspecto"]);
			result.codigoCertificacao = BaseDadosGPS.ObterDbValor<int>(row["codigoCertificacao"]);
			result.dataValidadeCertificacao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataValidadeCertificacao"]);
			result.dataCadastro = BaseDadosGPS.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.dataAtualizacao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoRepresentante = BaseDadosGPS.ObterDbValor<int>(row["codigoRepresentante"]);
			result.codigoFuncionario = BaseDadosGPS.ObterDbValor<int>(row["codigoFuncionario"]);
			result.codigoTipoPagamento = BaseDadosGPS.ObterDbValor<int>(row["codigoTipoPagamento"]);
			result.codigoModoPagamento = BaseDadosGPS.ObterDbValor<int>(row["codigoModoPagamento"]);
			result.valorCredito = BaseDadosGPS.ObterDbValor<decimal>(row["valorCredito"]);
			result.isBloqueado = BaseDadosGPS.ObterDbValor<bool>(row["isBloqueado"]);
			result.IsQualificado = BaseDadosGPS.ObterDbValor<bool>(row["IsQualificado"]);
			result.notaIqf = BaseDadosGPS.ObterDbValor<string>(row["notaIqf"]);
			result.codigoCfopPadrao = BaseDadosGPS.ObterDbValor<int>(row["codigoCfopPadrao"]);
			result.logo = BaseDadosGPS.ObterDbValor<Image>(row["logo"]);
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
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("cd_gps_cli as codigoGpsCliente, ");
		stringBuilder.Append("cd_gps_for as CodigoGpsFornecedor, ");
		stringBuilder.Append("ic_cliente as IsCliente, ");
		stringBuilder.Append("ic_fornecedor as isFornecedor, ");
		stringBuilder.Append("ic_representante as isRepresentante, ");
		stringBuilder.Append("ic_subcontratado as isSubContratado, ");
		stringBuilder.Append("ic_transportadora as isTransportadora, ");
		stringBuilder.Append("nm_fantasia as nomeFantasia, ");
		stringBuilder.Append("nm_razao_social as razaoSocial, ");
		stringBuilder.Append("cd_cnpj as cnpj, ");
		stringBuilder.Append("cd_inscricao_estadua as inscricaoEstadual, ");
		stringBuilder.Append("cd_inscricao_municip as inscricaoMunicipal, ");
		stringBuilder.Append("cd_especialidade as codigoEspecialidade, ");
		stringBuilder.Append("nm_endereco as endereco, ");
		stringBuilder.Append("nm_complemento as complemento, ");
		stringBuilder.Append("nm_bairro as bairro, ");
		stringBuilder.Append("nm_cep as cep, ");
		stringBuilder.Append("nm_cidade as cidade, ");
		stringBuilder.Append("nm_pais as pais, ");
		stringBuilder.Append("nm_uf as uf, ");
		stringBuilder.Append("nm_telefone as telefone, ");
		stringBuilder.Append("nm_fax as fax, ");
		stringBuilder.Append("nm_site as site, ");
		stringBuilder.Append("nm_email as email, ");
		stringBuilder.Append("ic_prospecto as isProspecto, ");
		stringBuilder.Append("cd_certificacao as codigoCertificacao, ");
		stringBuilder.Append("dt_validade_certific as dataValidadeCertificacao, ");
		stringBuilder.Append("dt_cadastro as dataCadastro, ");
		stringBuilder.Append("dt_atualizacao as dataAtualizacao, ");
		stringBuilder.Append("cd_representante as codigoRepresentante, ");
		stringBuilder.Append("cd_funcionario as codigoFuncionario, ");
		stringBuilder.Append("cd_condicao_pagament as codigoTipoPagamento, ");
		stringBuilder.Append("cd_modo_pagamento as codigoModoPagamento, ");
		stringBuilder.Append("vl_credito as valorCredito, ");
		stringBuilder.Append("ic_bloqueado as isBloqueado, ");
		stringBuilder.Append("ic_qualificado as IsQualificado, ");
		stringBuilder.Append("vl_iqf as notaIqf, ");
		stringBuilder.Append("cd_cfopi_padrao as codigoCfopPadrao, ");
		stringBuilder.Append("im_logo as logo");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ComercialEntidade ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidade> ObterTodosComercialEntidade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where ic_cliente = 1");
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where ic_subcontratado = 1");
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where ic_representante = 1");
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where ic_transportadora = 1");
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidade ObterComercialEntidade(MapTableComercialEntidade ComercialEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidade.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidade(MapTableComercialEntidade ComercialEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ComercialEntidade (");
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
		stringBuilder.Append("cd_inscricao_estadua, ");
		stringBuilder.Append("cd_inscricao_municip, ");
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
		stringBuilder.Append("dt_validade_certific, ");
		stringBuilder.Append("dt_cadastro, ");
		stringBuilder.Append("dt_atualizacao, ");
		stringBuilder.Append("cd_representante, ");
		stringBuilder.Append("cd_funcionario, ");
		stringBuilder.Append("cd_condicao_pagament, ");
		stringBuilder.Append("cd_modo_pagamento, ");
		stringBuilder.Append("vl_credito, ");
		stringBuilder.Append("ic_bloqueado, ");
		stringBuilder.Append("ic_qualificado, ");
		stringBuilder.Append("vl_iqf, ");
		stringBuilder.Append("cd_cfopi_padrao, ");
		stringBuilder.Append("im_logo) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_gps_cli", ComercialEntidade.codigoGpsCliente));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_gps_for", ComercialEntidade.CodigoGpsFornecedor));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_cliente", ComercialEntidade.IsCliente));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_fornecedor", ComercialEntidade.isFornecedor));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_representante", ComercialEntidade.isRepresentante));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_subcontratado", ComercialEntidade.isSubContratado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_transportadora", ComercialEntidade.isTransportadora));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_fantasia", ComercialEntidade.nomeFantasia));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_razao_social", ComercialEntidade.razaoSocial));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cnpj", ComercialEntidade.cnpj));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_inscricao_estadua", ComercialEntidade.inscricaoEstadual));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_inscricao_municip", ComercialEntidade.inscricaoMunicipal));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_especialidade", ComercialEntidade.codigoEspecialidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_endereco", ComercialEntidade.endereco));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_complemento", ComercialEntidade.complemento));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_bairro", ComercialEntidade.bairro));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_cep", ComercialEntidade.cep));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_cidade", ComercialEntidade.cidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_pais", ComercialEntidade.pais));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_uf", ComercialEntidade.uf));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_telefone", ComercialEntidade.telefone));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_fax", ComercialEntidade.fax));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_site", ComercialEntidade.site));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_email", ComercialEntidade.email));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_prospecto", ComercialEntidade.isProspecto));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_certificacao", ComercialEntidade.codigoCertificacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_validade_certific", ComercialEntidade.dataValidadeCertificacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_cadastro", ComercialEntidade.dataCadastro));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_atualizacao", ComercialEntidade.dataAtualizacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_representante", ComercialEntidade.codigoRepresentante));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_funcionario", ComercialEntidade.codigoFuncionario));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_condicao_pagament", ComercialEntidade.codigoTipoPagamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_modo_pagamento", ComercialEntidade.codigoModoPagamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_credito", ComercialEntidade.valorCredito));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_bloqueado", ComercialEntidade.isBloqueado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_qualificado", ComercialEntidade.IsQualificado));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_iqf", ComercialEntidade.notaIqf));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cfopi_padrao", ComercialEntidade.codigoCfopPadrao));
		list.Add(BaseDadosGPS.ObterNovoParametro("im_logo", ComercialEntidade.logo));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidade(MapTableComercialEntidade ComercialEntidade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ComercialEntidade Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoGpsCliente", "cd_gps_cli", ComercialEntidade.codigoGpsCliente, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoGpsFornecedor", "cd_gps_for", ComercialEntidade.CodigoGpsFornecedor, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsCliente", "ic_cliente", ComercialEntidade.IsCliente, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsFornecedor", "ic_fornecedor", ComercialEntidade.isFornecedor, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsRepresentante", "ic_representante", ComercialEntidade.isRepresentante, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsSubContratado", "ic_subcontratado", ComercialEntidade.isSubContratado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsTransportadora", "ic_transportadora", ComercialEntidade.isTransportadora, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NomeFantasia", "nm_fantasia", ComercialEntidade.nomeFantasia, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "RazaoSocial", "nm_razao_social", ComercialEntidade.razaoSocial, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Cnpj", "cd_cnpj", ComercialEntidade.cnpj, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "InscricaoEstadual", "cd_inscricao_estadua", ComercialEntidade.inscricaoEstadual, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "InscricaoMunicipal", "cd_inscricao_municip", ComercialEntidade.inscricaoMunicipal, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEspecialidade", "cd_especialidade", ComercialEntidade.codigoEspecialidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Endereco", "nm_endereco", ComercialEntidade.endereco, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Complemento", "nm_complemento", ComercialEntidade.complemento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Bairro", "nm_bairro", ComercialEntidade.bairro, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Cep", "nm_cep", ComercialEntidade.cep, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Cidade", "nm_cidade", ComercialEntidade.cidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Pais", "nm_pais", ComercialEntidade.pais, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Uf", "nm_uf", ComercialEntidade.uf, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Telefone", "nm_telefone", ComercialEntidade.telefone, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Fax", "nm_fax", ComercialEntidade.fax, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Site", "nm_site", ComercialEntidade.site, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", ComercialEntidade.email, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsProspecto", "ic_prospecto", ComercialEntidade.isProspecto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCertificacao", "cd_certificacao", ComercialEntidade.codigoCertificacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataValidadeCertificacao", "dt_validade_certific", ComercialEntidade.dataValidadeCertificacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_cadastro", ComercialEntidade.dataCadastro, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", ComercialEntidade.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoRepresentante", "cd_representante", ComercialEntidade.codigoRepresentante, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "cd_funcionario", ComercialEntidade.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTipoPagamento", "cd_condicao_pagament", ComercialEntidade.codigoTipoPagamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoModoPagamento", "cd_modo_pagamento", ComercialEntidade.codigoModoPagamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorCredito", "vl_credito", ComercialEntidade.valorCredito, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsBloqueado", "ic_bloqueado", ComercialEntidade.isBloqueado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsQualificado", "ic_qualificado", ComercialEntidade.IsQualificado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NotaIqf", "vl_iqf", ComercialEntidade.notaIqf, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCfopPadrao", "cd_cfopi_padrao", ComercialEntidade.codigoCfopPadrao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Logo", "im_logo", ComercialEntidade.logo, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidade.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidade(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ComercialEntidade ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
