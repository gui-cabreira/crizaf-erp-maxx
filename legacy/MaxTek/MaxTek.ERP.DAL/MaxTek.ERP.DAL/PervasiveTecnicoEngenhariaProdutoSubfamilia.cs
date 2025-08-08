using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProdutoSubfamilia : ITecnicoEngenhariaProdutoSubfamilia
{
	private MapTableTecnicoEngenhariaProdutoSubfamilia MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoSubfamilia result = default(MapTableTecnicoEngenhariaProdutoSubfamilia);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoFamilia = BaseDadosGPS.ObterDbValor<int>(row["codigoFamilia"]);
			result.subfamilia = BaseDadosGPS.ObterDbValor<string>(row["subfamilia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_familia as codigoFamilia, ");
		stringBuilder.Append("nm_subfamilia as subfamilia");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoSubfamilia ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoSubfamilia> ObterTodosTecnicoEngenhariaProdutoSubfamilia()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProdutoSubfamilia> list = new List<MapTableTecnicoEngenhariaProdutoSubfamilia>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProdutoSubfamilia> ObterTodosTecnicoEngenhariaProdutoSubfamilia(int codigoFamilia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_familia = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_familia", codigoFamilia));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProdutoSubfamilia> list2 = new List<MapTableTecnicoEngenhariaProdutoSubfamilia>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProdutoSubfamilia ObterTecnicoEngenhariaProdutoSubfamilia(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProdutoSubfamilia ObterTecnicoEngenhariaProdutoSubfamilia(MapTableTecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamilia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoSubfamilia.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoSubfamilia(MapTableTecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamilia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoSubfamilia (");
		stringBuilder.Append("cd_familia, ");
		stringBuilder.Append("nm_subfamilia) Values (?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_familia", TecnicoEngenhariaProdutoSubfamilia.codigoFamilia));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_subfamilia", TecnicoEngenhariaProdutoSubfamilia.subfamilia));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoSubfamilia(MapTableTecnicoEngenhariaProdutoSubfamilia TecnicoEngenhariaProdutoSubfamilia, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoSubfamilia Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoFamilia", "cd_familia", TecnicoEngenhariaProdutoSubfamilia.codigoFamilia, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Subfamilia", "nm_subfamilia", TecnicoEngenhariaProdutoSubfamilia.subfamilia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoSubfamilia.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoSubfamilia(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoSubfamilia ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
