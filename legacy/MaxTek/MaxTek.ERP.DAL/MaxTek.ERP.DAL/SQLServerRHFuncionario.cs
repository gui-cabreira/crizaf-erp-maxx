using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerRHFuncionario : IRHFuncionario
{
	private MapTableRHFuncionario MapearClasse(DataRow row)
	{
		MapTableRHFuncionario result = default(MapTableRHFuncionario);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[nm_funcionario] as [nome]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Rh].[Funcionario] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableRHFuncionario> ObterTodosRHFuncionario()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableRHFuncionario> list = new List<MapTableRHFuncionario>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableRHFuncionario ObterRHFuncionario(int codigo)
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

	public MapTableRHFuncionario ObterRHFuncionario(MapTableRHFuncionario RHFuncionario)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", RHFuncionario.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirRHFuncionario(MapTableRHFuncionario RHFuncionario)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Rh].[Funcionario] (");
		stringBuilder.Append("id, ");
		stringBuilder.Append("nm_funcionario) Values (@id, @nm_funcionario) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", RHFuncionario.codigo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_funcionario", RHFuncionario.nome));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: false, list);
	}

	public int AlterarRHFuncionario(MapTableRHFuncionario RHFuncionario, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Rh].[Funcionario] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_funcionario", RHFuncionario.nome, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", RHFuncionario.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirRHFuncionario(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Rh].[Funcionario] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
