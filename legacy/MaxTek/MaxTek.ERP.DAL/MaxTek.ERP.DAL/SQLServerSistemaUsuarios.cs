using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerSistemaUsuarios : ISistemaUsuarios
{
	private MapTableSistemaUsuarios MapearClasse(DataRow row)
	{
		MapTableSistemaUsuarios result = default(MapTableSistemaUsuarios);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.nomeLogon = BaseDadosERP.ObterDbValor<string>(row["nomeLogon"]);
			result.codigoFuncionario = BaseDadosERP.ObterDbValor<int>(row["codigoFuncionario"]);
			result.email = BaseDadosERP.ObterDbValor<string>(row["email"]);
			result.codigoEmpresa = BaseDadosERP.ObterDbValor<int>(row["codigoEmpresa"]);
			result.senha = BaseDadosERP.ObterDbValor<string>(row["senha"]);
			result.dicaSenha = BaseDadosERP.ObterDbValor<string>(row["dicaSenha"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_usuario] as [nomeLogon], ");
		stringBuilder.Append("[cd_funcionario] as [codigoFuncionario], ");
		stringBuilder.Append("[nm_email] as [email], ");
		stringBuilder.Append("[cd_base_dados] as [codigoEmpresa], ");
		stringBuilder.Append("[nm_senha] as [senha], ");
		stringBuilder.Append("[nm_dica_senha] as [dicaSenha]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Sistema].[Usuarios] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableSistemaUsuarios> ObterTodosSistemaUsuarios()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableSistemaUsuarios> list = new List<MapTableSistemaUsuarios>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableSistemaUsuarios ObterSistemaUsuarios(string nomeLogon)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_usuario] = @nm_usuario");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario", nomeLogon));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableSistemaUsuarios ObterSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_usuario] = @nm_usuario");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario", SistemaUsuarios.nomeLogon));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Sistema].[Usuarios] (");
		stringBuilder.Append("[nm_usuario], ");
		stringBuilder.Append("[cd_funcionario], ");
		stringBuilder.Append("[nm_email], ");
		stringBuilder.Append("[cd_base_dados], ");
		stringBuilder.Append("[nm_senha], ");
		stringBuilder.Append("[nm_dica_senha]) Values (@nm_usuario,@cd_funcionario,@nm_email,@cd_base_dados,@nm_senha,@nm_dica_senha) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario", SistemaUsuarios.nomeLogon));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_funcionario", SistemaUsuarios.codigoFuncionario));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_email", SistemaUsuarios.email));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_base_dados", SistemaUsuarios.codigoEmpresa));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_senha", SistemaUsuarios.senha));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_dica_senha", SistemaUsuarios.dicaSenha));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Sistema].[Usuarios] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Id", "id", SistemaUsuarios.id, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeLogon", "nm_usuario", SistemaUsuarios.nomeLogon, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "cd_funcionario", SistemaUsuarios.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", SistemaUsuarios.email, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmpresa", "cd_base_dados", SistemaUsuarios.codigoEmpresa, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Senha", "nm_senha", SistemaUsuarios.senha, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DicaSenha", "nm_dica_senha", SistemaUsuarios.dicaSenha, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", SistemaUsuarios.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirSistemaUsuarios(string nomeLogon)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Sistema].[Usuarios] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [nm_usuario] = @nm_usuario");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_usuario", nomeLogon));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirSistemaUsuarios(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Sistema].[Usuarios] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
