using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveTecnicoEngenhariaProdutoAlmoxarifado : ITecnicoEngenhariaProdutoAlmoxarifado
{
	private MapTableTecnicoEngenhariaProdutoAlmoxarifado MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoAlmoxarifado result = default(MapTableTecnicoEngenhariaProdutoAlmoxarifado);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoAlmoxarifado = BaseDadosGPS.ObterDbValor<string>(row["codigoAlmoxarifado"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_almoxarifado as codigoAlmoxarifado, ");
		stringBuilder.Append("ds_almoxarifado as descricao");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoAlmoxarifado ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoAlmoxarifado> ObterTodosTecnicoEngenhariaProdutoAlmoxarifado()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProdutoAlmoxarifado> list = new List<MapTableTecnicoEngenhariaProdutoAlmoxarifado>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProdutoAlmoxarifado ObterTecnicoEngenhariaProdutoAlmoxarifado(int id)
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

	public MapTableTecnicoEngenhariaProdutoAlmoxarifado ObterTecnicoEngenhariaProdutoAlmoxarifado(MapTableTecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoAlmoxarifado.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoAlmoxarifado(MapTableTecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoAlmoxarifado (");
		stringBuilder.Append("nm_almoxarifado, ");
		stringBuilder.Append("ds_almoxarifado) Values (?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.codigoAlmoxarifado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.descricao));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoAlmoxarifado(MapTableTecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifado, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoAlmoxarifado Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoAlmoxarifado", "nm_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.codigoAlmoxarifado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.descricao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", TecnicoEngenhariaProdutoAlmoxarifado.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoAlmoxarifado(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.ProdutoAlmoxarifado ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
