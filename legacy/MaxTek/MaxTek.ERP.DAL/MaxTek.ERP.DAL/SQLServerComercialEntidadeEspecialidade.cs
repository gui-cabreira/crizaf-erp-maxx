using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialEntidadeEspecialidade : IComercialEntidadeEspecialidade
{
	private MapTableComercialEntidadeEspecialidade MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeEspecialidade result = default(MapTableComercialEntidadeEspecialidade);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[nm_especialidade] as [nome], ");
		stringBuilder.Append("[ds_especialidade] as [descricao]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEspecialidade] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeEspecialidade> ObterTodosComercialEntidadeEspecialidade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialEntidadeEspecialidade> list = new List<MapTableComercialEntidadeEspecialidade>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialEntidadeEspecialidade ObterComercialEntidadeEspecialidade(int codigo)
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

	public MapTableComercialEntidadeEspecialidade ObterComercialEntidadeEspecialidade(MapTableComercialEntidadeEspecialidade ComercialEntidadeEspecialidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeEspecialidade.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeEspecialidade(MapTableComercialEntidadeEspecialidade ComercialEntidadeEspecialidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEspecialidade] (");
		stringBuilder.Append("nm_especialidade, ");
		stringBuilder.Append("ds_especialidade) Values (@nm_especialidade,@ds_especialidade) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_especialidade", ComercialEntidadeEspecialidade.nome));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_especialidade", ComercialEntidadeEspecialidade.descricao));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeEspecialidade(MapTableComercialEntidadeEspecialidade ComercialEntidadeEspecialidade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEspecialidade] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_especialidade", ComercialEntidadeEspecialidade.nome, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_especialidade", ComercialEntidadeEspecialidade.descricao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialEntidadeEspecialidade.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidadeEspecialidade(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[EntidadeEspecialidade] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
