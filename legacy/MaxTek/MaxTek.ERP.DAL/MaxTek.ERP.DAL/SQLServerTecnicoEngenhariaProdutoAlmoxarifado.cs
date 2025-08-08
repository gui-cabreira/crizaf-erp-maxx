using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProdutoAlmoxarifado : ITecnicoEngenhariaProdutoAlmoxarifado
{
	private MapTableTecnicoEngenhariaProdutoAlmoxarifado MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoAlmoxarifado result = default(MapTableTecnicoEngenhariaProdutoAlmoxarifado);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoAlmoxarifado = BaseDadosERP.ObterDbValor<string>(row["codigoAlmoxarifado"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[nm_almoxarifado] as [codigoAlmoxarifado], ");
		stringBuilder.Append("[ds_almoxarifado] as [descricao]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifado] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoAlmoxarifado> ObterTodosTecnicoEngenhariaProdutoAlmoxarifado()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProdutoAlmoxarifado ObterTecnicoEngenhariaProdutoAlmoxarifado(MapTableTecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoAlmoxarifado.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoAlmoxarifado(MapTableTecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifado] (");
		stringBuilder.Append("[nm_almoxarifado], ");
		stringBuilder.Append("[ds_almoxarifado]) Values (@nm_almoxarifado,@ds_almoxarifado) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.codigoAlmoxarifado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.descricao));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoAlmoxarifado(MapTableTecnicoEngenhariaProdutoAlmoxarifado TecnicoEngenhariaProdutoAlmoxarifado, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifado] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoAlmoxarifado", "nm_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.codigoAlmoxarifado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifado.descricao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoAlmoxarifado.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoAlmoxarifado(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifado] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
