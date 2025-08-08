using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialVendasCatalogosCodigos : IComercialVendasCatalogosCodigos
{
	private MapTableComercialVendasCatalogosCodigos MapearClasse(DataRow row)
	{
		MapTableComercialVendasCatalogosCodigos result = default(MapTableComercialVendasCatalogosCodigos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoCatalogo = BaseDadosERP.ObterDbValor<int>(row["codigoCatalogo"]);
			result.codigoCatalogoProduto = BaseDadosERP.ObterDbValor<string>(row["codigoCatalogoProduto"]);
			result.descricaoCatalogoProduto = BaseDadosERP.ObterDbValor<string>(row["descricaoCatalogoProduto"]);
			result.codigoProduto = BaseDadosERP.ObterDbValor<int>(row["codigoProduto"]);
			result.preco = BaseDadosERP.ObterDbValor<decimal>(row["preco"]);
			result.desconto = BaseDadosERP.ObterDbValor<decimal>(row["desconto"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_catalogo] as [codigoCatalogo], ");
		stringBuilder.Append("[nm_produto_catalogo] as [codigoCatalogoProduto], ");
		stringBuilder.Append("[ds_produto_catalogo] as [descricaoCatalogoProduto], ");
		stringBuilder.Append("[cd_produto] as [codigoProduto], ");
		stringBuilder.Append("[vl_preco] as [preco], ");
		stringBuilder.Append("[pc_desconto] as [desconto]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogosCodigos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasCatalogosCodigos> ObterTodosComercialVendasCatalogosCodigos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialVendasCatalogosCodigos> list = new List<MapTableComercialVendasCatalogosCodigos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialVendasCatalogosCodigos> ObterTodosComercialVendasCatalogosCodigos(int codigoCatalogo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_catalogo] = @cd_catalogo");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_catalogo", codigoCatalogo));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableComercialVendasCatalogosCodigos> list2 = new List<MapTableComercialVendasCatalogosCodigos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableComercialVendasCatalogosCodigos ObterComercialVendasCatalogosCodigos(int id)
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

	public MapTableComercialVendasCatalogosCodigos ObterComercialVendasCatalogosCodigos(MapTableComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasCatalogosCodigos.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasCatalogosCodigos(MapTableComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogosCodigos] (");
		stringBuilder.Append("[cd_catalogo], ");
		stringBuilder.Append("[cd_produto], ");
		stringBuilder.Append("[vl_preco], ");
		stringBuilder.Append("[pc_desconto], ");
		stringBuilder.Append("[nm_produto_catalogo], ");
		stringBuilder.Append("[ds_produto_catalogo]) Values (@cd_catalogo,@cd_produto,@vl_preco,@pc_desconto,@nm_produto_catalogo,@ds_produto_catalogo) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogo));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", ComercialVendasCatalogosCodigos.codigoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_preco", ComercialVendasCatalogosCodigos.preco));
		list.Add(BaseDadosERP.ObterNovoParametro("@pc_desconto", ComercialVendasCatalogosCodigos.desconto));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_produto_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_produto_catalogo", ComercialVendasCatalogosCodigos.descricaoCatalogoProduto));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasCatalogosCodigos(MapTableComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogosCodigos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCatalogo", "cd_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogo, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", ComercialVendasCatalogosCodigos.codigoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Preco", "vl_preco", ComercialVendasCatalogosCodigos.preco, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Desconto", "pc_desconto", ComercialVendasCatalogosCodigos.desconto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCatalogoProduto", "nm_produto_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoCatalogoProduto", "ds_produto_catalogo", ComercialVendasCatalogosCodigos.descricaoCatalogoProduto, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasCatalogosCodigos.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasCatalogosCodigos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasCatalogosCodigos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
