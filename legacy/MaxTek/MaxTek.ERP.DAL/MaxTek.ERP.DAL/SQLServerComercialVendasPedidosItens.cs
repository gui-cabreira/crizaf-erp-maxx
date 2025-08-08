using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialVendasPedidosItens : IComercialVendasPedidosItens
{
	private MapTableComercialVendasPedidosItens MapearClasse(DataRow row)
	{
		MapTableComercialVendasPedidosItens result = default(MapTableComercialVendasPedidosItens);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoPedidoVenda = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoVenda"]);
			result.codigoPedidoVendaItem = BaseDadosERP.ObterDbValor<int>(row["codigoPedidoVendaItem"]);
			result.codigoProduto = BaseDadosERP.ObterDbValor<int>(row["codigoProduto"]);
			result.valorUnitario = BaseDadosERP.ObterDbValor<decimal>(row["valorUnitario"]);
			result.valorPercentualDesconto = BaseDadosERP.ObterDbValor<decimal>(row["valorPercentualDesconto"]);
			result.valorCustosDiversos = BaseDadosERP.ObterDbValor<decimal>(row["valorCustosDiversos"]);
			result.codigoUnidade = BaseDadosERP.ObterDbValor<int>(row["codigoUnidade"]);
			result.codigoEmbalagem = BaseDadosERP.ObterDbValor<int>(row["codigoEmbalagem"]);
			result.isReserva = BaseDadosERP.ObterDbValor<bool>(row["isReserva"]);
			result.isCancelado = BaseDadosERP.ObterDbValor<bool>(row["isCancelado"]);
			result.comentarioItem = BaseDadosERP.ObterDbValor<string>(row["comentarioItem"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[cd_pedido_venda] as [codigoPedidoVenda], ");
		stringBuilder.Append("[cd_pedido_venda_item] as [codigoPedidoVendaItem], ");
		stringBuilder.Append("[cd_produto] as [codigoProduto], ");
		stringBuilder.Append("[vl_unitario] as [valorUnitario], ");
		stringBuilder.Append("[vl_percentual_desconto] as [valorPercentualDesconto], ");
		stringBuilder.Append("[vl_custos_diversos] as [valorCustosDiversos], ");
		stringBuilder.Append("[cd_unidade] as [codigoUnidade], ");
		stringBuilder.Append("[cd_embalagem] as [codigoEmbalagem], ");
		stringBuilder.Append("[ic_reserva] as [isReserva], ");
		stringBuilder.Append("[ic_cancelado] as [isCancelado], ");
		stringBuilder.Append("[ds_comentario_item] as [comentarioItem]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItens] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasPedidosItens> ObterTodosComercialVendasPedidosItens()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("[cd_pedido_venda] = @cd_pedido_venda");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", codigoPedido));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialVendasPedidosItens ObterComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasPedidosItens.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItens] (");
		stringBuilder.Append("[cd_pedido_venda], ");
		stringBuilder.Append("[cd_pedido_venda_item], ");
		stringBuilder.Append("[cd_produto], ");
		stringBuilder.Append("[vl_unitario], ");
		stringBuilder.Append("[vl_percentual_desconto], ");
		stringBuilder.Append("[vl_custos_diversos], ");
		stringBuilder.Append("[cd_unidade], ");
		stringBuilder.Append("[dt_entrega], ");
		stringBuilder.Append("[cd_embalagem], ");
		stringBuilder.Append("[ic_reserva], ");
		stringBuilder.Append("[ic_cancelado], ");
		stringBuilder.Append("[ds_comentario_item]) Values (@cd_pedido_venda,@cd_pedido_venda_item,@cd_produto,@vl_unitario,@vl_percentual_desconto,@vl_custos_diversos,@cd_unidade,@dt_entrega,@cd_embalagem,@ic_reserva,@ic_cancelado,@ds_comentario_item) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda", ComercialVendasPedidosItens.codigoPedidoVenda));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_pedido_venda_item", ComercialVendasPedidosItens.codigoPedidoVendaItem));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_produto", ComercialVendasPedidosItens.codigoProduto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_unitario", ComercialVendasPedidosItens.valorUnitario));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_percentual_desconto", ComercialVendasPedidosItens.valorPercentualDesconto));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_custos_diversos", ComercialVendasPedidosItens.valorCustosDiversos));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_unidade", ComercialVendasPedidosItens.codigoUnidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_entrega", ComercialVendasPedidosItens.dataEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_embalagem", ComercialVendasPedidosItens.codigoEmbalagem));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_reserva", ComercialVendasPedidosItens.isReserva));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_cancelado", ComercialVendasPedidosItens.isCancelado));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_comentario_item", ComercialVendasPedidosItens.comentarioItem));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasPedidosItens(MapTableComercialVendasPedidosItens ComercialVendasPedidosItens, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItens] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoVenda", "cd_pedido_venda", ComercialVendasPedidosItens.codigoPedidoVenda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoVendaItem", "cd_pedido_venda_item", ComercialVendasPedidosItens.codigoPedidoVendaItem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoProduto", "cd_produto", ComercialVendasPedidosItens.codigoProduto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorUnitario", "vl_unitario", ComercialVendasPedidosItens.valorUnitario, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorPercentualDesconto", "vl_percentual_desconto", ComercialVendasPedidosItens.valorPercentualDesconto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ValorCustosDiversos", "vl_custos_diversos", ComercialVendasPedidosItens.valorCustosDiversos, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoUnidade", "cd_unidade", ComercialVendasPedidosItens.codigoUnidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEntrega", "dt_entrega", ComercialVendasPedidosItens.dataEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEmbalagem", "cd_embalagem", ComercialVendasPedidosItens.codigoEmbalagem, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsReserva", "ic_reserva", ComercialVendasPedidosItens.isReserva, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "IsCancelado", "ic_cancelado", ComercialVendasPedidosItens.isCancelado, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ComentarioItem", "ds_comentario_item", ComercialVendasPedidosItens.comentarioItem, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasPedidosItens.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasPedidosItens(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidosItens] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
