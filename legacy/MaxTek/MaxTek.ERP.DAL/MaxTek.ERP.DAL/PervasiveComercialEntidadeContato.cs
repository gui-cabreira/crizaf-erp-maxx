using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialEntidadeContato : IComercialEntidadeContato
{
	private MapTableComercialEntidadeContato MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeContato result = default(MapTableComercialEntidadeContato);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.codigoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidade"]);
			result.nome = BaseDadosGPS.ObterDbValor<string>(row["nome"]);
			result.funcao = BaseDadosGPS.ObterDbValor<string>(row["funcao"]);
			result.cargo = BaseDadosGPS.ObterDbValor<string>(row["cargo"]);
			result.telefone = BaseDadosGPS.ObterDbValor<string>(row["telefone"]);
			result.celular = BaseDadosGPS.ObterDbValor<string>(row["celular"]);
			result.email = BaseDadosGPS.ObterDbValor<string>(row["email"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("id_entidade as codigoEntidade, ");
		stringBuilder.Append("nm_contato as nome, ");
		stringBuilder.Append("nm_funcao as funcao, ");
		stringBuilder.Append("nm_cargo as cargo, ");
		stringBuilder.Append("nm_telefone as telefone, ");
		stringBuilder.Append("nm_celular as celular, ");
		stringBuilder.Append("nm_email as email");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeContato ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeContato> ObterTodosComercialEntidadeContato()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeContato> list = new List<MapTableComercialEntidadeContato>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialEntidadeContato> ObterTodosComercialEntidadeContato(int codigoEntidade)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where id_entidade = " + codigoEntidade);
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeContato> list = new List<MapTableComercialEntidadeContato>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialEntidadeContato ObterComercialEntidadeContato(int codigo)
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

	public MapTableComercialEntidadeContato ObterComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeContato.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeContato (");
		stringBuilder.Append("id_entidade, ");
		stringBuilder.Append("nm_contato, ");
		stringBuilder.Append("nm_funcao, ");
		stringBuilder.Append("nm_cargo, ");
		stringBuilder.Append("nm_telefone, ");
		stringBuilder.Append("nm_celular, ");
		stringBuilder.Append("nm_email) Values (?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade", ComercialEntidadeContato.codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_contato", ComercialEntidadeContato.nome));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_funcao", ComercialEntidadeContato.funcao));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_cargo", ComercialEntidadeContato.cargo));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_telefone", ComercialEntidadeContato.telefone));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_celular", ComercialEntidadeContato.celular));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_email", ComercialEntidadeContato.email));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeContato Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "id_entidade", ComercialEntidadeContato.codigoEntidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_contato", ComercialEntidadeContato.nome, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Funcao", "nm_funcao", ComercialEntidadeContato.funcao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Cargo", "nm_cargo", ComercialEntidadeContato.cargo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Telefone", "nm_telefone", ComercialEntidadeContato.telefone, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Celular", "nm_celular", ComercialEntidadeContato.celular, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", ComercialEntidadeContato.email, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeContato.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidadeContato(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeContato ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirTodosComercialEntidadeContato(int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.EntidadeContato ");
		stringBuilder.Append("Where ");
		stringBuilder.Append("id_entidade  = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id_entidade", codigoEntidade));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
