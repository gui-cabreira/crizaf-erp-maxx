using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialVendasPedidosItensCadencia : IComercialVendasPedidosItensCadencia
{
	private MapTableComercialVendasPedidosItensCadencia MapearClasse(DataRow row)
	{
		MapTableComercialVendasPedidosItensCadencia result = default(MapTableComercialVendasPedidosItensCadencia);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoPedidoItem = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoItem"]);
			result.dataEntrega = BaseDadosERP.ObterDbValor<DateTime>(row["dataEntrega"]);
			result.dataLiberacaoProducao = BaseDadosERP.ObterDbValor<DateTime>(row["dataLiberacaoProducao"]);
			result.isFirme = BaseDadosERP.ObterDbValor<bool>(row["isFirme"]);
			result.quantidadePedida = BaseDadosERP.ObterDbValor<decimal>(row["quantidadePedida"]);
			result.quantidadeEntrega = BaseDadosERP.ObterDbValor<decimal>(row["quantidadeEntrega"]);
			result.comentarioCadencia = BaseDadosERP.ObterDbValor<string>(row["comentarioCadencia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_pedido_item] as [codigoPedidoItem], ");
		stringBuilder.Append("[dt_entrega] as [dataEntrega], ");
		stringBuilder.Append("[dt_liberacao] as [dataLiberacaoProducao], ");
		stringBuilder.Append("[ic_firme] as [isFirme], ");
		stringBuilder.Append("[qt_pedida] as [quantidadePedida], ");
		stringBuilder.Append("[qt_entregue] as [quantidadeEntrega], ");
		stringBuilder.Append("[ds_comentario] as [comentarioCadencia]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItensCadencia] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasPedidosItensCadencia> ObterTodosComercialVendasPedidosItensCadencia()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialVendasPedidosItensCadencia> list = new List<MapTableComercialVendasPedidosItensCadencia>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialVendasPedidosItensCadencia> ObterTodosComercialVendasPedidosItensCadencia(int codigoPedidoItem)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [cd_pedido_item] = @cd_pedido_item");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_item", codigoPedidoItem));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableComercialVendasPedidosItensCadencia> list2 = new List<MapTableComercialVendasPedidosItensCadencia>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableComercialVendasPedidosItensCadencia ObterComercialVendasPedidosItensCadencia(int id)
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

	public MapTableComercialVendasPedidosItensCadencia ObterComercialVendasPedidosItensCadencia(MapTableComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasPedidosItensCadencia.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasPedidosItensCadencia(MapTableComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItensCadencia] (");
		stringBuilder.Append("[cd_pedido_item], ");
		stringBuilder.Append("[dt_entrega], ");
		stringBuilder.Append("[dt_liberacao], ");
		stringBuilder.Append("[ic_firme], ");
		stringBuilder.Append("[qt_pedida], ");
		stringBuilder.Append("[qt_entregue], ");
		stringBuilder.Append("[ds_comentario]) Values (@cd_pedido_item,@dt_entrega,@dt_liberacao,@ic_firme,@qt_pedida,@qt_entregue,@ds_comentario) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_item", ComercialVendasPedidosItensCadencia.codigoPedidoItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_entrega", ComercialVendasPedidosItensCadencia.dataEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_liberacao", ComercialVendasPedidosItensCadencia.dataLiberacaoProducao));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_firme", ComercialVendasPedidosItensCadencia.isFirme));
		list.Add(BaseDadosERP.ObterNovoParametro("@qt_pedida", ComercialVendasPedidosItensCadencia.quantidadePedida));
		list.Add(BaseDadosERP.ObterNovoParametro("@qt_entregue", ComercialVendasPedidosItensCadencia.quantidadeEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_comentario", ComercialVendasPedidosItensCadencia.comentarioCadencia));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasPedidosItensCadencia(MapTableComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadencia, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItensCadencia] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoItem", "cd_pedido_item", ComercialVendasPedidosItensCadencia.codigoPedidoItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEntrega", "dt_entrega", ComercialVendasPedidosItensCadencia.dataEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataLiberacaoProducao", "dt_liberacao", ComercialVendasPedidosItensCadencia.dataLiberacaoProducao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsFirme", "ic_firme", ComercialVendasPedidosItensCadencia.isFirme, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadePedida", "qt_pedida", ComercialVendasPedidosItensCadencia.quantidadePedida, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "QuantidadeEntrega", "qt_entregue", ComercialVendasPedidosItensCadencia.quantidadeEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ComentarioCadencia", "ds_comentario", ComercialVendasPedidosItensCadencia.comentarioCadencia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasPedidosItensCadencia.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasPedidosItensCadencia(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItensCadencia] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
