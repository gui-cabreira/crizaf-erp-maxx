using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialVendasPedidosItensCadencia : IComercialVendasPedidosItensCadencia
{
	private MapTableComercialVendasPedidosItensCadencia MapearClasse(DataRow row)
	{
		MapTableComercialVendasPedidosItensCadencia result = default(MapTableComercialVendasPedidosItensCadencia);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoPedidoItem = BaseDadosGPS.ObterDbValor<int>(row["codigoPedidoItem"]);
			result.dataEntrega = BaseDadosGPS.ObterDbValor<DateTime>(row["dataEntrega"]);
			result.dataLiberacaoProducao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataLiberacaoProducao"]);
			result.isFirme = BaseDadosGPS.ObterDbValor<bool>(row["isFirme"]);
			result.quantidadePedida = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadePedida"]);
			result.quantidadeEntrega = BaseDadosGPS.ObterDbValor<decimal>(row["quantidadeEntrega"]);
			result.comentarioCadencia = BaseDadosGPS.ObterDbValor<string>(row["comentarioCadencia"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("cd_pedido_item as codigoPedidoItem, ");
		stringBuilder.Append("dt_entrega as dataEntrega, ");
		stringBuilder.Append("dt_liberacao as dataLiberacaoProducao, ");
		stringBuilder.Append("ic_firme as isFirme, ");
		stringBuilder.Append("qt_pedida as quantidadePedida, ");
		stringBuilder.Append("dt_entregue as quantidadeEntrega, ");
		stringBuilder.Append("ds_comentario as comentarioCadencia");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.PedidosItensCadencia ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasPedidosItensCadencia> ObterTodosComercialVendasPedidosItensCadencia()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" cd_pedido_item = ?");
		list.Add(BaseDadosERP.ObterNovoParametro("cd_pedido_item", codigoPedidoItem));
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialVendasPedidosItensCadencia ObterComercialVendasPedidosItensCadencia(MapTableComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasPedidosItensCadencia.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasPedidosItensCadencia(MapTableComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadencia)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.PedidosItensCadencia (");
		stringBuilder.Append("cd_pedido_item, ");
		stringBuilder.Append("dt_entrega, ");
		stringBuilder.Append("dt_liberacao, ");
		stringBuilder.Append("ic_firme, ");
		stringBuilder.Append("qt_pedida, ");
		stringBuilder.Append("dt_entregue, ");
		stringBuilder.Append("ds_comentario) Values (?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_pedido_item", ComercialVendasPedidosItensCadencia.codigoPedidoItem));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_entrega", ComercialVendasPedidosItensCadencia.dataEntrega));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_liberacao", ComercialVendasPedidosItensCadencia.dataLiberacaoProducao));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_firme", ComercialVendasPedidosItensCadencia.isFirme));
		list.Add(BaseDadosGPS.ObterNovoParametro("qt_pedida", ComercialVendasPedidosItensCadencia.quantidadePedida));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_entregue", ComercialVendasPedidosItensCadencia.quantidadeEntrega));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_comentario", ComercialVendasPedidosItensCadencia.comentarioCadencia));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasPedidosItensCadencia(MapTableComercialVendasPedidosItensCadencia ComercialVendasPedidosItensCadencia, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.PedidosItensCadencia Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoPedidoItem", "cd_pedido_item", ComercialVendasPedidosItensCadencia.codigoPedidoItem, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataEntrega", "dt_entrega", ComercialVendasPedidosItensCadencia.dataEntrega, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataLiberacaoProducao", "dt_liberacao", ComercialVendasPedidosItensCadencia.dataLiberacaoProducao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "IsFirme", "ic_firme", ComercialVendasPedidosItensCadencia.isFirme, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadePedida", "qt_pedida", ComercialVendasPedidosItensCadencia.quantidadePedida, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "QuantidadeEntrega", "dt_entregue", ComercialVendasPedidosItensCadencia.quantidadeEntrega, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ComentarioCadencia", "ds_comentario", ComercialVendasPedidosItensCadencia.comentarioCadencia, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasPedidosItensCadencia.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasPedidosItensCadencia(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.PedidosItensCadencia ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
