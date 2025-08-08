using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialVendasCatalogos : IComercialVendasCatalogos
{
	private MapTableComercialVendasCatalogos MapearClasse(DataRow row)
	{
		MapTableComercialVendasCatalogos result = default(MapTableComercialVendasCatalogos);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.nome = BaseDadosGPS.ObterDbValor<string>(row["nome"]);
			result.descricao = BaseDadosGPS.ObterDbValor<string>(row["descricao"]);
			result.isPercentualPrecoBase = BaseDadosGPS.ObterDbValor<bool>(row["isPercentualPrecoBase"]);
			result.percentualPrecoBase = BaseDadosGPS.ObterDbValor<decimal>(row["percentualPrecoBase"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("nm_catalogo as nome, ");
		stringBuilder.Append("ds_catalogo as descricao, ");
		stringBuilder.Append("ic_percentual_descon as isPercentualPrecoBase, ");
		stringBuilder.Append("pc_desconto as percentualPrecoBase");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.VendasCatalogos ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasCatalogos> ObterTodosComercialVendasCatalogos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialVendasCatalogos> list = new List<MapTableComercialVendasCatalogos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialVendasCatalogos ObterComercialVendasCatalogos(int id)
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

	public MapTableComercialVendasCatalogos ObterComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasCatalogos.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.VendasCatalogos (");
		stringBuilder.Append("nm_catalogo, ");
		stringBuilder.Append("ds_catalogo, ");
		stringBuilder.Append("ic_percentual_descon, ");
		stringBuilder.Append("pc_desconto) Values (?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_catalogo", ComercialVendasCatalogos.nome));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_catalogo", ComercialVendasCatalogos.descricao));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_percentual_descon", ComercialVendasCatalogos.isPercentualPrecoBase));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_desconto", ComercialVendasCatalogos.percentualPrecoBase));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.VendasCatalogos Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_catalogo", ComercialVendasCatalogos.nome, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_catalogo", ComercialVendasCatalogos.descricao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsPercentualPrecoBase", "ic_percentual_descon", ComercialVendasCatalogos.isPercentualPrecoBase, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "PercentualPrecoBase", "pc_desconto", ComercialVendasCatalogos.percentualPrecoBase, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasCatalogos.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasCatalogos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.VendasCatalogos ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
