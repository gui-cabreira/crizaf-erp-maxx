using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialVendasCatalogos : IComercialVendasCatalogos
{
	private MapTableComercialVendasCatalogos MapearClasse(DataRow row)
	{
		MapTableComercialVendasCatalogos result = default(MapTableComercialVendasCatalogos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
			result.isPercentualPrecoBase = BaseDadosERP.ObterDbValor<bool>(row["isPercentualPrecoBase"]);
			result.percentualPrecoBase = BaseDadosERP.ObterDbValor<decimal>(row["percentualPrecoBase"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_catalogo] as [nome], ");
		stringBuilder.Append("[ds_catalogo] as [descricao], ");
		stringBuilder.Append("[ic_percentual_desconto] as [isPercentualPrecoBase], ");
		stringBuilder.Append("[pc_desconto] as [percentualPrecoBase]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasCatalogos> ObterTodosComercialVendasCatalogos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialVendasCatalogos ObterComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasCatalogos.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogos] (");
		stringBuilder.Append("[nm_catalogo], ");
		stringBuilder.Append("[ds_catalogo], ");
		stringBuilder.Append("[ic_percentual_desconto], ");
		stringBuilder.Append("[pc_desconto]) Values (@nm_catalogo,@ds_catalogo,@ic_percentual_desconto,@pc_desconto) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_catalogo", ComercialVendasCatalogos.nome));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_catalogo", ComercialVendasCatalogos.descricao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_percentual_desconto", ComercialVendasCatalogos.isPercentualPrecoBase));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_desconto", ComercialVendasCatalogos.percentualPrecoBase));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasCatalogos(MapTableComercialVendasCatalogos ComercialVendasCatalogos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_catalogo", ComercialVendasCatalogos.nome, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_catalogo", ComercialVendasCatalogos.descricao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsPercentualPrecoBase", "ic_percentual_desconto", ComercialVendasCatalogos.isPercentualPrecoBase, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "PercentualPrecoBase", "pc_desconto", ComercialVendasCatalogos.percentualPrecoBase, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasCatalogos.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasCatalogos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
