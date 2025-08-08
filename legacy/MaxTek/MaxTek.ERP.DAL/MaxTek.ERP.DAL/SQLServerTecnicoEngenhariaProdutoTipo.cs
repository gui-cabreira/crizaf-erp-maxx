using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProdutoTipo : ITecnicoEngenhariaProdutoTipo
{
	private MapTableTecnicoEngenhariaProdutoTipo MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoTipo result = default(MapTableTecnicoEngenhariaProdutoTipo);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.tipoProduto = BaseDadosERP.ObterDbValor<string>(row["tipoProduto"]);
			result.nomeDimensao01 = BaseDadosERP.ObterDbValor<string>(row["nomeDimensao01"]);
			result.nomeDimensao02 = BaseDadosERP.ObterDbValor<string>(row["nomeDimensao02"]);
			result.nomeDimensao03 = BaseDadosERP.ObterDbValor<string>(row["nomeDimensao03"]);
			result.nomeDimensao04 = BaseDadosERP.ObterDbValor<string>(row["nomeDimensao04"]);
			result.codigoUnidadeEstoque = BaseDadosERP.ObterDbValor<int>(row["codigoUnidadeEstoque"]);
			result.codigoUnidadeCompra = BaseDadosERP.ObterDbValor<int>(row["codigoUnidadeCompra"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_tipo_produto] as [tipoProduto], ");
		stringBuilder.Append("[nm_dimensao_01] as [nomeDimensao01], ");
		stringBuilder.Append("[nm_dimensao_02] as [nomeDimensao02], ");
		stringBuilder.Append("[nm_dimensao_03] as [nomeDimensao03], ");
		stringBuilder.Append("[nm_dimensao_04] as [nomeDimensao04], ");
		stringBuilder.Append("[cd_unidade_estoque] as [codigoUnidadeEstoque], ");
		stringBuilder.Append("[cd_unidade_compra] as [codigoUnidadeCompra]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoTipo] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoTipo> ObterTodosTecnicoEngenhariaProdutoTipo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableTecnicoEngenhariaProdutoTipo> list = new List<MapTableTecnicoEngenhariaProdutoTipo>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableTecnicoEngenhariaProdutoTipo ObterTecnicoEngenhariaProdutoTipo(int id)
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

	public MapTableTecnicoEngenhariaProdutoTipo ObterTecnicoEngenhariaProdutoTipo(MapTableTecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoTipo.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoTipo(MapTableTecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoTipo] (");
		stringBuilder.Append("[nm_tipo_produto], ");
		stringBuilder.Append("[nm_dimensao_01], ");
		stringBuilder.Append("[nm_dimensao_02], ");
		stringBuilder.Append("[nm_dimensao_03], ");
		stringBuilder.Append("[nm_dimensao_04], ");
		stringBuilder.Append("[cd_unidade_estoque], ");
		stringBuilder.Append("[cd_unidade_compra]) Values (@nm_tipo_produto,@nm_dimensao_01,@nm_dimensao_02,@nm_dimensao_03,@nm_dimensao_04,@cd_unidade_estoque,@cd_unidade_compra) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_tipo_produto", TecnicoEngenhariaProdutoTipo.tipoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_dimensao_01", TecnicoEngenhariaProdutoTipo.nomeDimensao01));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_dimensao_02", TecnicoEngenhariaProdutoTipo.nomeDimensao02));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_dimensao_03", TecnicoEngenhariaProdutoTipo.nomeDimensao03));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_dimensao_04", TecnicoEngenhariaProdutoTipo.nomeDimensao04));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade_estoque", TecnicoEngenhariaProdutoTipo.codigoUnidadeEstoque));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade_compra", TecnicoEngenhariaProdutoTipo.codigoUnidadeCompra));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoTipo(MapTableTecnicoEngenhariaProdutoTipo TecnicoEngenhariaProdutoTipo, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoTipo] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "TipoProduto", "nm_tipo_produto", TecnicoEngenhariaProdutoTipo.tipoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeDimensao01", "nm_dimensao_01", TecnicoEngenhariaProdutoTipo.nomeDimensao01, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeDimensao02", "nm_dimensao_02", TecnicoEngenhariaProdutoTipo.nomeDimensao02, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeDimensao03", "nm_dimensao_03", TecnicoEngenhariaProdutoTipo.nomeDimensao03, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NomeDimensao04", "nm_dimensao_04", TecnicoEngenhariaProdutoTipo.nomeDimensao04, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeEstoque", "cd_unidade_estoque", TecnicoEngenhariaProdutoTipo.codigoUnidadeEstoque, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidadeCompra", "cd_unidade_compra", TecnicoEngenhariaProdutoTipo.codigoUnidadeCompra, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoTipo.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoTipo(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoTipo] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
