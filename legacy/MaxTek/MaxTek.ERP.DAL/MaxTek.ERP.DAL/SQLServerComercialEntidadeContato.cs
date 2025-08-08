using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialEntidadeContato : IComercialEntidadeContato
{
	private MapTableComercialEntidadeContato MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeContato result = default(MapTableComercialEntidadeContato);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
			result.funcao = BaseDadosERP.ObterDbValor<string>(row["funcao"]);
			result.cargo = BaseDadosERP.ObterDbValor<string>(row["cargo"]);
			result.telefone = BaseDadosERP.ObterDbValor<string>(row["telefone"]);
			result.celular = BaseDadosERP.ObterDbValor<string>(row["celular"]);
			result.email = BaseDadosERP.ObterDbValor<string>(row["email"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[id_entidade] as [codigoEntidade], ");
		stringBuilder.Append("[nm_contato] as [nome], ");
		stringBuilder.Append("[nm_funcao] as [funcao], ");
		stringBuilder.Append("[nm_cargo] as [cargo], ");
		stringBuilder.Append("[nm_telefone] as [telefone], ");
		stringBuilder.Append("[nm_celular] as [celular], ");
		stringBuilder.Append("[nm_email] as [email]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeContato] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeContato> ObterTodosComercialEntidadeContato()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where [id_entidade] = " + codigoEntidade);
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeContato ObterComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeContato.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeContato] (");
		stringBuilder.Append("id_entidade, ");
		stringBuilder.Append("nm_contato, ");
		stringBuilder.Append("nm_funcao, ");
		stringBuilder.Append("nm_cargo, ");
		stringBuilder.Append("nm_telefone, ");
		stringBuilder.Append("nm_celular, ");
		stringBuilder.Append("nm_email) Values (@id_entidade,@nm_contato,@nm_funcao,@nm_cargo,@nm_telefone,@nm_celular,@nm_email) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade", ComercialEntidadeContato.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_contato", ComercialEntidadeContato.nome));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_funcao", ComercialEntidadeContato.funcao));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_cargo", ComercialEntidadeContato.cargo));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_telefone", ComercialEntidadeContato.telefone));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_celular", ComercialEntidadeContato.celular));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_email", ComercialEntidadeContato.email));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeContato] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "id_entidade", ComercialEntidadeContato.codigoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_contato", ComercialEntidadeContato.nome, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Funcao", "nm_funcao", ComercialEntidadeContato.funcao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Cargo", "nm_cargo", ComercialEntidadeContato.cargo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Telefone", "nm_telefone", ComercialEntidadeContato.telefone, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Celular", "nm_celular", ComercialEntidadeContato.celular, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Email", "nm_email", ComercialEntidadeContato.email, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeContato.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidadeContato(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeContato] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirTodosComercialEntidadeContato(int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeContato] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id_entidade] = @id_entidade");
		list.Add(BaseDadosERP.ObterNovoParametro("@id_entidade", codigoEntidade));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
