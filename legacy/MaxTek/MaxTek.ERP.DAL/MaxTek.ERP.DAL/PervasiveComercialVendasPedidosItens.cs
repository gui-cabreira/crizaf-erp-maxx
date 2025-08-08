using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialVendasPedidosItens : IComercialVendasPedidosItens
{
	private MapTableComercialVendasPedidosItens MapearClasse(DataRow row)
	{
		MapTableComercialVendasPedidosItens result = default(MapTableComercialVendasPedidosItens);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoPedidoVenda = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoVenda"]);
			result.codigoPedidoVendaItem = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoVendaItem"]);
			result.codigoProduto = BaseDadosGPS.ObterDbValor<int>(row["codigoProduto"]);
			result.valorUnitario = BaseDadosGPS.ObterDbValor<decimal>(row["valorUnitario"]);
			result.valorPercentualDesconto = BaseDadosGPS.ObterDbValor<decimal>(row["valorPercentualDesconto"]);
			result.valorCustosDiversos = BaseDadosGPS.ObterDbValor<decimal>(row["valorCustosDiversos"]);
			result.codigoUnidade = BaseDadosGPS.ObterDbValor<int>(row["codigoUnidade"]);
			result.codigoEmbalagem = BaseDadosGPS.ObterDbValor<int>(row["codigoEmbalagem"]);
			result.isReserva = BaseDadosGPS.ObterDbValor<bool>(row["isReserva"]);
			result.isCancelado = BaseDadosGPS.ObterDbValor<bool>(row["isCancelado"]);
			result.comentarioItem = BaseDadosGPS.ObterDbValor<string>(row["comentarioItem"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_pedido_venda as codigoPedidoVenda, ");
		stringBuilder.Append("cd_pedido_venda_item as codigoPedidoVendaItem, ");
		stringBuilder.Append("cd_produto as codigoProduto, ");
		stringBuilder.Append("vl_unitario as valorUnitario, ");
		stringBuilder.Append("vl_percentual_descon as valorPercentualDesconto, ");
		stringBuilder.Append("vl_custos_diversos as valorCustosDiversos, ");
		stringBuilder.Append("cd_unidade as codigoUnidade, ");
		stringBuilder.Append("cd_embalagem as codigoEmbalagem, ");
		stringBuilder.Append("ic_reserva as isReserva, ");
		stringBuilder.Append("ic_cancelado as isCancelado, ");
		stringBuilder.Append("ds_comentario_item as comentarioItem");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidosItens ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialVendasPedidosItens> list = new List<MapTableComercialVendasPedidosItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens(int codigoPedido)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" cd_pedido_venda = ? ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_pedido_venda", codigoPedido));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableComercialVendasPedidosItens> list2 = new List<MapTableComercialVendasPedidosItens>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public MapTableComercialVendasPedidosItens ObterComercialVendasPedidosItens(int id)
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

	public MapTableComercialVendasPedidosItens ObterComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasPedidosItens.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidosItens (");
		stringBuilder.Append("cd_pedido_venda, ");
		stringBuilder.Append("cd_pedido_venda_item, ");
		stringBuilder.Append("cd_produto, ");
		stringBuilder.Append("vl_unitario, ");
		stringBuilder.Append("vl_percentual_descon, ");
		stringBuilder.Append("vl_custos_diversos, ");
		stringBuilder.Append("cd_unidade, ");
		stringBuilder.Append("dt_entrega, ");
		stringBuilder.Append("cd_embalagem, ");
		stringBuilder.Append("ic_reserva, ");
		stringBuilder.Append("ic_cancelado, ");
		stringBuilder.Append("ds_comentario_item) Values (?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_pedido_venda", ComercialVendasPedidosItens.codigoPedidoVenda));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_pedido_venda_item", ComercialVendasPedidosItens.codigoPedidoVendaItem));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_produto", ComercialVendasPedidosItens.codigoProduto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_unitario", ComercialVendasPedidosItens.valorUnitario));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_percentual_descon", ComercialVendasPedidosItens.valorPercentualDesconto));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_custos_diversos", ComercialVendasPedidosItens.valorCustosDiversos));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_unidade", ComercialVendasPedidosItens.codigoUnidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_entrega", ComercialVendasPedidosItens.dataEntrega));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_embalagem", ComercialVendasPedidosItens.codigoEmbalagem));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_reserva", ComercialVendasPedidosItens.isReserva));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_cancelado", ComercialVendasPedidosItens.isCancelado));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_comentario_item", ComercialVendasPedidosItens.comentarioItem));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidosItens Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoVenda", "cd_pedido_venda", ComercialVendasPedidosItens.codigoPedidoVenda, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoVendaItem", "cd_pedido_venda_item", ComercialVendasPedidosItens.codigoPedidoVendaItem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", ComercialVendasPedidosItens.codigoProduto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorUnitario", "vl_unitario", ComercialVendasPedidosItens.valorUnitario, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorPercentualDesconto", "vl_percentual_descon", ComercialVendasPedidosItens.valorPercentualDesconto, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ValorCustosDiversos", "vl_custos_diversos", ComercialVendasPedidosItens.valorCustosDiversos, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoUnidade", "cd_unidade", ComercialVendasPedidosItens.codigoUnidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataEntrega", "dt_entrega", ComercialVendasPedidosItens.dataEntrega, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEmbalagem", "cd_embalagem", ComercialVendasPedidosItens.codigoEmbalagem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsReserva", "ic_reserva", ComercialVendasPedidosItens.isReserva, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsCancelado", "ic_cancelado", ComercialVendasPedidosItens.isCancelado, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ComentarioItem", "ds_comentario_item", ComercialVendasPedidosItens.comentarioItem, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasPedidosItens.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasPedidosItens(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidosItens ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
