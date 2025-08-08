using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialVendasCatalogosCodigos : IComercialVendasCatalogosCodigos
{
	private MapTableComercialVendasCatalogosCodigos MapearClasse(DataRow row)
	{
		MapTableComercialVendasCatalogosCodigos result = default(MapTableComercialVendasCatalogosCodigos);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoCatalogo = BaseDadosGPS.ObterDbValor<int>(row["codigoCatalogo"]);
			result.codigoCatalogoProduto = BaseDadosGPS.ObterDbValor<string>(row["codigoCatalogoProduto"]);
			result.descricaoCatalogoProduto = BaseDadosGPS.ObterDbValor<string>(row["descricaoCatalogoProduto"]);
			result.codigoProduto = BaseDadosGPS.ObterDbValor<int>(row["codigoProduto"]);
			result.preco = BaseDadosGPS.ObterDbValor<decimal>(row["preco"]);
			result.desconto = BaseDadosGPS.ObterDbValor<decimal>(row["desconto"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_catalogo as codigoCatalogo, ");
		stringBuilder.Append("cd_produto as codigoProduto, ");
		stringBuilder.Append("vl_preco as preco, ");
		stringBuilder.Append("pc_desconto as desconto, ");
		stringBuilder.Append("nm_produto_catalogo as codigoCatalogoProduto, ");
		stringBuilder.Append("ds_produto_catalogo as descricaoCatalogoProduto");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.CatalogosCodigos ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasCatalogosCodigos> ObterTodosComercialVendasCatalogosCodigos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("cd_catalogo = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_catalogo", codigoCatalogo));
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialVendasCatalogosCodigos ObterComercialVendasCatalogosCodigos(MapTableComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasCatalogosCodigos.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasCatalogosCodigos(MapTableComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.CatalogosCodigos (");
		stringBuilder.Append("cd_catalogo, ");
		stringBuilder.Append("cd_produto, ");
		stringBuilder.Append("vl_preco, ");
		stringBuilder.Append("pc_desconto, ");
		stringBuilder.Append("nm_produto_catalogo, ");
		stringBuilder.Append("ds_produto_catalogo) Values (?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogo));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_produto", ComercialVendasCatalogosCodigos.codigoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_preco", ComercialVendasCatalogosCodigos.preco));
		list.Add(BaseDadosGPS.ObterNovoParametro("pc_desconto", ComercialVendasCatalogosCodigos.desconto));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_produto_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_produto_catalogo", ComercialVendasCatalogosCodigos.descricaoCatalogoProduto));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasCatalogosCodigos(MapTableComercialVendasCatalogosCodigos ComercialVendasCatalogosCodigos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.CatalogosCodigos Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCatalogo", "cd_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogo, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", ComercialVendasCatalogosCodigos.codigoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Preco", "vl_preco", ComercialVendasCatalogosCodigos.preco, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Desconto", "pc_desconto", ComercialVendasCatalogosCodigos.desconto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCatalogoProduto", "nm_produto_catalogo", ComercialVendasCatalogosCodigos.codigoCatalogoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DescricaoCatalogoProduto", "ds_produto_catalogo", ComercialVendasCatalogosCodigos.descricaoCatalogoProduto, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasCatalogosCodigos.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasCatalogosCodigos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.CatalogosCodigos ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
