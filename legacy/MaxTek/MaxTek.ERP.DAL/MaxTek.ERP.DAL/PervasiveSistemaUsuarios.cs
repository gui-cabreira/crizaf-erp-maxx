using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveSistemaUsuarios : ISistemaUsuarios
{
	private MapTableSistemaUsuarios MapearClasse(DataRow row)
	{
		MapTableSistemaUsuarios result = default(MapTableSistemaUsuarios);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.nomeLogon = BaseDadosGPS.ObterDbValor<string>(row["nomeLogon"]);
			result.codigoFuncionario = BaseDadosGPS.ObterDbValor<int>(row["codigoFuncionario"]);
			result.email = BaseDadosGPS.ObterDbValor<string>(row["email"]);
			result.codigoEmpresa = BaseDadosGPS.ObterDbValor<int>(row["codigoEmpresa"]);
			result.senha = BaseDadosGPS.ObterDbValor<string>(row["senha"]);
			result.dicaSenha = BaseDadosGPS.ObterDbValor<string>(row["dicaSenha"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_usuario as nomeLogon, ");
		stringBuilder.Append("cd_funcionario as codigoFuncionario, ");
		stringBuilder.Append("nm_email as email, ");
		stringBuilder.Append("cd_base_dados as codigoEmpresa, ");
		stringBuilder.Append("nm_senha as senha, ");
		stringBuilder.Append("nm_dica_senha as dicaSenha");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.SistemaUsuarios ");
		return stringBuilder.ToString();
	}

	public IList<MapTableSistemaUsuarios> ObterTodosSistemaUsuarios()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" nm_usuario = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_usuario", nomeLogon));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableSistemaUsuarios ObterSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_usuario = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_usuario", SistemaUsuarios.nomeLogon));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.SistemaUsuarios (");
		stringBuilder.Append("nm_usuario, ");
		stringBuilder.Append("cd_funcionario, ");
		stringBuilder.Append("nm_email, ");
		stringBuilder.Append("cd_base_dados, ");
		stringBuilder.Append("nm_senha, ");
		stringBuilder.Append("nm_dica_senha) Values (?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_usuario", SistemaUsuarios.nomeLogon));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_funcionario", SistemaUsuarios.codigoFuncionario));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_email", SistemaUsuarios.email));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_base_dados", SistemaUsuarios.codigoEmpresa));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_senha", SistemaUsuarios.senha));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_dica_senha", SistemaUsuarios.dicaSenha));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarSistemaUsuarios(MapTableSistemaUsuarios SistemaUsuarios, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.SistemaUsuarios Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NomeLogon", "nm_usuario", SistemaUsuarios.nomeLogon, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFuncionario", "cd_funcionario", SistemaUsuarios.codigoFuncionario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", SistemaUsuarios.email, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEmpresa", "cd_base_dados", SistemaUsuarios.codigoEmpresa, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Senha", "nm_senha", SistemaUsuarios.senha, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DicaSenha", "nm_dica_senha", SistemaUsuarios.dicaSenha, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", SistemaUsuarios.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirSistemaUsuarios(string nomeLogon)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.SistemaUsuarios ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" nm_usuario = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_usuario", nomeLogon));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirSistemaUsuarios(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.SistemaUsuarios ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
