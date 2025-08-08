using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialVendasPedidos : IComercialVendasPedidos
{
	private MapTableComercialVendasPedidos MapearClasse(DataRow row)
	{
		MapTableComercialVendasPedidos result = default(MapTableComercialVendasPedidos);
		if (row != null)
		{
			result.id = BaseDadosGPS.ObterDbValor<int>(row["id"]);
			result.codigoStatus = BaseDadosGPS.ObterDbValor<int>(row["codigoStatus"]);
			result.dataCadastro = BaseDadosGPS.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.dataAtualizacao = BaseDadosGPS.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoEntidadeContato = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidadeContato"]);
			result.referenciaPedido = BaseDadosGPS.ObterDbValor<string>(row["referenciaPedido"]);
			result.codigoModoPagamento = BaseDadosGPS.ObterDbValor<int>(row["codigoModoPagamento"]);
			result.codigoCondicaoPagamento = BaseDadosGPS.ObterDbValor<int>(row["codigoCondicaoPagamento"]);
			result.codigoTransportadora = BaseDadosGPS.ObterDbValor<int>(row["codigoTransportadora"]);
			result.codigoVendedor = BaseDadosGPS.ObterDbValor<int>(row["codigoVendedor"]);
			result.codigoRepresentante = BaseDadosGPS.ObterDbValor<int>(row["codigoRepresentante"]);
			result.codigoEntidadeEntrega = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidadeEntrega"]);
			result.codigoEntidadeFatura = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidadeFatura"]);
			result.codigoCfop = BaseDadosGPS.ObterDbValor<int>(row["codigoCfop"]);
			result.codigoMoeda = BaseDadosGPS.ObterDbValor<int>(row["codigoMoeda"]);
			result.descricaoPedido = BaseDadosGPS.ObterDbValor<string>(row["descricaoPedido"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as id, ");
		stringBuilder.Append("dt_cadastro as dataCadastro, ");
		stringBuilder.Append("dt_atualizacao as dataAtualizacao, ");
		stringBuilder.Append("cd_entidade as codigoEntidade, ");
		stringBuilder.Append("cd_entidade_contato as codigoEntidadeContato, ");
		stringBuilder.Append("nm_referencia_pedido as referenciaPedido, ");
		stringBuilder.Append("cd_modo_pagamento as codigoModoPagamento, ");
		stringBuilder.Append("cd_condicao_pagament as codigoCondicaoPagamento, ");
		stringBuilder.Append("cd_transportadora as codigoTransportadora, ");
		stringBuilder.Append("cd_vendedor as codigoVendedor, ");
		stringBuilder.Append("cd_representante as codigoRepresentante, ");
		stringBuilder.Append("cd_entidade_entrega as codigoEntidadeEntrega, ");
		stringBuilder.Append("cd_entidade_fatura as codigoEntidadeFatura, ");
		stringBuilder.Append("cd_cfopi as codigoCfop, ");
		stringBuilder.Append("cd_moeda as codigoMoeda, ");
		stringBuilder.Append("ds_pedido as descricaoPedido, ");
		stringBuilder.Append("cd_status as codigoStatus");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidos ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasPedidos> ObterTodosComercialVendasPedidos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialVendasPedidos> list = new List<MapTableComercialVendasPedidos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableComercialVendasPedidos> ObterTodosComercialVendasPedidosPorDataCadastro(DateTime dataInicio, DateTime dataFim)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where dt_cadastro between " + BaseDadosERP.Escape(dataInicio.ToString("yyyy-MM-dd")));
		stringBuilder.Append(" and " + BaseDadosERP.Escape(dataFim.ToString("yyyy-MM-dd")));
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialVendasPedidos> list = new List<MapTableComercialVendasPedidos>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialVendasPedidos ObterComercialVendasPedidos(int id)
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

	public MapTableComercialVendasPedidos ObterComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasPedidos.id));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidos (");
		stringBuilder.Append("dt_cadastro, ");
		stringBuilder.Append("dt_atualizacao, ");
		stringBuilder.Append("cd_entidade, ");
		stringBuilder.Append("cd_entidade_contato, ");
		stringBuilder.Append("nm_referencia_pedido, ");
		stringBuilder.Append("dt_entrega, ");
		stringBuilder.Append("cd_modo_pagamento, ");
		stringBuilder.Append("cd_condicao_pagament, ");
		stringBuilder.Append("cd_transportadora, ");
		stringBuilder.Append("cd_vendedor, ");
		stringBuilder.Append("cd_representante, ");
		stringBuilder.Append("cd_entidade_entrega, ");
		stringBuilder.Append("cd_entidade_fatura, ");
		stringBuilder.Append("cd_cfopi, ");
		stringBuilder.Append("cd_moeda, ");
		stringBuilder.Append("ds_pedido, ");
		stringBuilder.Append("cd_status) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_cadastro", ComercialVendasPedidos.dataCadastro));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_atualizacao", ComercialVendasPedidos.dataAtualizacao));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_entidade", ComercialVendasPedidos.codigoEntidade));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_entidade_contato", ComercialVendasPedidos.codigoEntidadeContato));
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_referencia_pedido", ComercialVendasPedidos.referenciaPedido));
		list.Add(BaseDadosGPS.ObterNovoParametro("dt_entrega", ComercialVendasPedidos.dataEntrega));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_modo_pagamento", ComercialVendasPedidos.codigoModoPagamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_condicao_pagament", ComercialVendasPedidos.codigoCondicaoPagamento));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_transportadora", ComercialVendasPedidos.codigoTransportadora));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_vendedor", ComercialVendasPedidos.codigoVendedor));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_representante", ComercialVendasPedidos.codigoRepresentante));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_entidade_entrega", ComercialVendasPedidos.codigoEntidadeEntrega));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_entidade_fatura", ComercialVendasPedidos.codigoEntidadeFatura));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_cfopi", ComercialVendasPedidos.codigoCfop));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_moeda", ComercialVendasPedidos.codigoMoeda));
		list.Add(BaseDadosGPS.ObterNovoParametro("ds_pedido", ComercialVendasPedidos.descricaoPedido));
		list.Add(BaseDadosGPS.ObterNovoParametro("cd_status", ComercialVendasPedidos.codigoStatus));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidos Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_cadastro", ComercialVendasPedidos.dataCadastro, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", ComercialVendasPedidos.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "cd_entidade", ComercialVendasPedidos.codigoEntidade, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeContato", "cd_entidade_contato", ComercialVendasPedidos.codigoEntidadeContato, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "ReferenciaPedido", "nm_referencia_pedido", ComercialVendasPedidos.referenciaPedido, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DataEntrega", "dt_entrega", ComercialVendasPedidos.dataEntrega, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoModoPagamento", "cd_modo_pagamento", ComercialVendasPedidos.codigoModoPagamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCondicaoPagamento", "cd_condicao_pagament", ComercialVendasPedidos.codigoCondicaoPagamento, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoTransportadora", "cd_transportadora", ComercialVendasPedidos.codigoTransportadora, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoVendedor", "cd_vendedor", ComercialVendasPedidos.codigoVendedor, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoRepresentante", "cd_representante", ComercialVendasPedidos.codigoRepresentante, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeEntrega", "cd_entidade_entrega", ComercialVendasPedidos.codigoEntidadeEntrega, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeFatura", "cd_entidade_fatura", ComercialVendasPedidos.codigoEntidadeFatura, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoCfop", "cd_cfopi", ComercialVendasPedidos.codigoCfop, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoMoeda", "cd_moeda", ComercialVendasPedidos.codigoMoeda, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "DescricaoPedido", "ds_pedido", ComercialVendasPedidos.descricaoPedido, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CodigoStatus", "cd_status", ComercialVendasPedidos.codigoStatus, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialVendasPedidos.id));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasPedidos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.VendasPedidos ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", id));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
