using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialEntidadeEspecialidade : IComercialEntidadeEspecialidade
{
	private MapTableComercialEntidadeEspecialidade MapearClasse(DataRow row)
	{
		MapTableComercialEntidadeEspecialidade result = default(MapTableComercialEntidadeEspecialidade);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosGPS.ObterDbValor<string>(row["nome"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("nm_especialidade as nome, ");
		stringBuilder.Append("ds_especialidade as descricao");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.Especialidade ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialEntidadeEspecialidade> ObterTodosComercialEntidadeEspecialidade()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialEntidadeEspecialidade ObterComercialEntidadeEspecialidade(MapTableComercialEntidadeEspecialidade ComercialEntidadeEspecialidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeEspecialidade.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialEntidadeEspecialidade(MapTableComercialEntidadeEspecialidade ComercialEntidadeEspecialidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.Especialidade (");
		stringBuilder.Append("nm_especialidade, ");
		stringBuilder.Append("ds_especialidade) Values (?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_especialidade", ComercialEntidadeEspecialidade.nome));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_especialidade", ComercialEntidadeEspecialidade.descricao));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialEntidadeEspecialidade(MapTableComercialEntidadeEspecialidade ComercialEntidadeEspecialidade, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.Especialidade Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_especialidade", ComercialEntidadeEspecialidade.nome, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_especialidade", ComercialEntidadeEspecialidade.descricao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialEntidadeEspecialidade.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialEntidadeEspecialidade(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.Especialidade ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
