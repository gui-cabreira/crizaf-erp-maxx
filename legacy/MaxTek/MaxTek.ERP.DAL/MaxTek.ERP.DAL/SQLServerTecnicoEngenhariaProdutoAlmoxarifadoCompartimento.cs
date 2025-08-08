using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerTecnicoEngenhariaProdutoAlmoxarifadoCompartimento : ITecnicoEngenhariaProdutoAlmoxarifadoCompartimento
{
	private MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento MapearClasse(DataRow row)
	{
		MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento result = default(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoAlmoxarifado = BaseDadosERP.ObterDbValor<int>(row["codigoAlmoxarifado"]);
			result.compartimento = BaseDadosERP.ObterDbValor<string>(row["compartimento"]);
			result.descricao = BaseDadosERP.ObterDbValor<string>(row["descricao"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_almoxarifado] as [codigoAlmoxarifado], ");
		stringBuilder.Append("[nm_compartimento] as [compartimento], ");
		stringBuilder.Append("[ds_compartimento] as [descricao]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifadoCompartimento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento> ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [cd_almoxarifado] = @cd_almoxarifado");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_almoxarifado", codigoAlmoxarifado));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento ObterTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifadoCompartimento] (");
		stringBuilder.Append("[cd_almoxarifado], ");
		stringBuilder.Append("[nm_compartimento], ");
		stringBuilder.Append("[ds_compartimento]) Values (@cd_almoxarifado,@nm_compartimento,@ds_compartimento) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.codigoAlmoxarifado));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.compartimento));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.descricao));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento TecnicoEngenhariaProdutoAlmoxarifadoCompartimento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifadoCompartimento] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoAlmoxarifado", "cd_almoxarifado", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.codigoAlmoxarifado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Compartimento", "nm_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.compartimento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Descricao", "ds_compartimento", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.descricao, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", TecnicoEngenhariaProdutoAlmoxarifadoCompartimento.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifadoCompartimento] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}

	public int ExcluirTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(int codigoAlmoxarifado)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[TecnicoEngenharia].[ProdutoAlmoxarifadoCompartimento] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_almoxarifado] = @cd_almoxarifado");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_almoxarifado", codigoAlmoxarifado));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
