using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProdutoFamilia : ITecnicoEngenhariaProdutoFamilia
{
	private MapTableTecnicoEngenhariaProdutoFamilia MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoFamilia result = default(MapTableTecnicoEngenhariaProdutoFamilia);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.familia = BaseDadosGPS.ObterDbValor<string>(row["familia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_familia as familia");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoFamilia ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoFamilia> ObterTodosTecnicoEngenhariaProdutoFamilia()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProdutoFamilia> list = new List<MapTableTecnicoEngenhariaProdutoFamilia>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProdutoFamilia ObterTecnicoEngenhariaProdutoFamilia(int id)
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

	public MapTableTecnicoEngenhariaProdutoFamilia ObterTecnicoEngenhariaProdutoFamilia(MapTableTecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamilia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoFamilia.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoFamilia(MapTableTecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamilia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoFamilia (");
		stringBuilder.Append("nm_familia) Values (?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_familia", TecnicoEngenhariaProdutoFamilia.familia));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoFamilia(MapTableTecnicoEngenhariaProdutoFamilia TecnicoEngenhariaProdutoFamilia, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoFamilia Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Familia", "nm_familia", TecnicoEngenhariaProdutoFamilia.familia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoFamilia.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoFamilia(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoFamilia ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
