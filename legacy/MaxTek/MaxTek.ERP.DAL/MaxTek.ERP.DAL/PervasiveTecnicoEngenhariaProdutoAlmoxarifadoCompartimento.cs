using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProdutoAlmoxarifadoCompartimento : ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento
{
	private MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento result = default(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoAlmoxarifado = BaseDadosGPS.ObterDbValor<int>(row["codigoAlmoxarifado"]);
			result.compartimento = BaseDadosGPS.ObterDbValor<string>(row["compartimento"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_almoxarifado as codigoAlmoxarifado, ");
		stringBuilder.Append("nm_compartimento as compartimento, ");
		stringBuilder.Append("ds_compartimento as descricao");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.Compartimento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento> ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento> list = new List<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento> ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int codigoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_almoxarifado = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_almoxarifado", codigoAlmoxarifado));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento> list2 = new List<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int id)
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

	public MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.Compartimento (");
		stringBuilder.Append("cd_almoxarifado, ");
		stringBuilder.Append("nm_compartimento, ");
		stringBuilder.Append("ds_compartimento) Values (?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.codigoAlmoxarifado));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.compartimento));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.descricao));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.Compartimento Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoAlmoxarifado", "cd_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.codigoAlmoxarifado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Compartimento", "nm_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.compartimento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.descricao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.Compartimento ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int codigoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.Compartimento ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_almoxarifado = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_almoxarifado", codigoAlmoxarifado));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
