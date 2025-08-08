using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialVendasPedidos : IComercialVendasPedidos
{
	private MapTableComercialVendasPedidos MapearClasse(DataRow row)
	{
		MapTableComercialVendasPedidos result = default(MapTableComercialVendasPedidos);
		if (row != null)
		{
			result.id = BaseDadosERP.ObterDbValor<int>(row["id"]);
			result.codigoStatus = BaseDadosERP.ObterDbValor<int>(row["codigoStatus"]);
			result.dataCadastro = BaseDadosERP.ObterDbValor<DateTime>(row["dataCadastro"]);
			result.dataAtualizacao = BaseDadosERP.ObterDbValor<DateTime>(row["dataAtualizacao"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.codigoEntidadeContato = BaseDadosERP.ObterDbValor<int>(row["codigoEntidadeContato"]);
			result.referenciaPedido = BaseDadosERP.ObterDbValor<string>(row["referenciaPedido"]);
			result.codigoModoPagamento = BaseDadosERP.ObterDbValor<int>(row["codigoModoPagamento"]);
			result.codigoCondicaoPagamento = BaseDadosERP.ObterDbValor<int>(row["codigoCondicaoPagamento"]);
			result.codigoTransportadora = BaseDadosERP.ObterDbValor<int>(row["codigoTransportadora"]);
			result.codigoVendedor = BaseDadosERP.ObterDbValor<int>(row["codigoVendedor"]);
			result.codigoRepresentante = BaseDadosERP.ObterDbValor<int>(row["codigoRepresentante"]);
			result.codigoEntidadeEntrega = BaseDadosERP.ObterDbValor<int>(row["codigoEntidadeEntrega"]);
			result.codigoEntidadeFatura = BaseDadosERP.ObterDbValor<int>(row["codigoEntidadeFatura"]);
			result.codigoCfop = BaseDadosERP.ObterDbValor<int>(row["codigoCfop"]);
			result.codigoMoeda = BaseDadosERP.ObterDbValor<int>(row["codigoMoeda"]);
			result.descricaoPedido = BaseDadosERP.ObterDbValor<string>(row["descricaoPedido"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [id], ");
		stringBuilder.Append("[dt_cadastro] as [dataCadastro], ");
		stringBuilder.Append("[dt_atualizacao] as [dataAtualizacao], ");
		stringBuilder.Append("[cd_entidade] as [codigoEntidade], ");
		stringBuilder.Append("[cd_entidade_contato] as [codigoEntidadeContato], ");
		stringBuilder.Append("[nm_referencia_pedido] as [referenciaPedido], ");
		stringBuilder.Append("[cd_modo_pagamento] as [codigoModoPagamento], ");
		stringBuilder.Append("[cd_condicao_pagamento] as [codigoCondicaoPagamento], ");
		stringBuilder.Append("[cd_transportadora] as [codigoTransportadora], ");
		stringBuilder.Append("[cd_vendedor] as [codigoVendedor], ");
		stringBuilder.Append("[cd_representante] as [codigoRepresentante], ");
		stringBuilder.Append("[cd_entidade_entrega] as [codigoEntidadeEntrega], ");
		stringBuilder.Append("[cd_entidade_fatura] as [codigoEntidadeFatura], ");
		stringBuilder.Append("[cd_cfopi] as [codigoCfop], ");
		stringBuilder.Append("[cd_moeda] as [codigoMoeda], ");
		stringBuilder.Append("[ds_pedido] as [descricaoPedido], ");
		stringBuilder.Append("[cd_status] as [codigoStatus]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidos] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialVendasPedidos> ObterTodosComercialVendasPedidos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append("Where [dt_cadastro] between " + BaseDadosERP.Escape(dataInicio.ToString("yyyy-MM-dd")));
		stringBuilder.Append(" and " + BaseDadosERP.Escape(dataFim.ToString("yyyy-MM-dd")));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialVendasPedidos ObterComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasPedidos.id));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidos] (");
		stringBuilder.Append("[dt_cadastro], ");
		stringBuilder.Append("[dt_atualizacao], ");
		stringBuilder.Append("[cd_entidade], ");
		stringBuilder.Append("[cd_entidade_contato], ");
		stringBuilder.Append("[nm_referencia_pedido], ");
		stringBuilder.Append("[dt_entrega], ");
		stringBuilder.Append("[cd_modo_pagamento], ");
		stringBuilder.Append("[cd_condicao_pagamento], ");
		stringBuilder.Append("[cd_transportadora], ");
		stringBuilder.Append("[cd_vendedor], ");
		stringBuilder.Append("[cd_representante], ");
		stringBuilder.Append("[cd_entidade_entrega], ");
		stringBuilder.Append("[cd_entidade_fatura], ");
		stringBuilder.Append("[cd_cfopi], ");
		stringBuilder.Append("[cd_moeda], ");
		stringBuilder.Append("[ds_pedido], ");
		stringBuilder.Append("[cd_status]) Values (@dt_cadastro,@dt_atualizacao,@cd_entidade,@cd_entidade_contato,@nm_referencia_pedido,@dt_entrega,@cd_modo_pagamento,@cd_condicao_pagamento,@cd_transportadora,@cd_vendedor,@cd_representante,@cd_entidade_entrega,@cd_entidade_fatura,@cd_cfopi,@cd_moeda,@ds_pedido,@cd_status) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_cadastro", ComercialVendasPedidos.dataCadastro));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_atualizacao", ComercialVendasPedidos.dataAtualizacao));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade", ComercialVendasPedidos.codigoEntidade));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade_contato", ComercialVendasPedidos.codigoEntidadeContato));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_referencia_pedido", ComercialVendasPedidos.referenciaPedido));
		list.Add(BaseDadosERP.ObterNovoParametro("@dt_entrega", ComercialVendasPedidos.dataEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_modo_pagamento", ComercialVendasPedidos.codigoModoPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_condicao_pagamento", ComercialVendasPedidos.codigoCondicaoPagamento));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_transportadora", ComercialVendasPedidos.codigoTransportadora));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_vendedor", ComercialVendasPedidos.codigoVendedor));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_representante", ComercialVendasPedidos.codigoRepresentante));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade_entrega", ComercialVendasPedidos.codigoEntidadeEntrega));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_entidade_fatura", ComercialVendasPedidos.codigoEntidadeFatura));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_cfopi", ComercialVendasPedidos.codigoCfop));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_moeda", ComercialVendasPedidos.codigoMoeda));
		list.Add(BaseDadosERP.ObterNovoParametro("@ds_pedido", ComercialVendasPedidos.descricaoPedido));
		list.Add(BaseDadosERP.ObterNovoParametro("@cd_status", ComercialVendasPedidos.codigoStatus));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialVendasPedidos(MapTableComercialVendasPedidos ComercialVendasPedidos, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidos] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataCadastro", "dt_cadastro", ComercialVendasPedidos.dataCadastro, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataAtualizacao", "dt_atualizacao", ComercialVendasPedidos.dataAtualizacao, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidade", "cd_entidade", ComercialVendasPedidos.codigoEntidade, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeContato", "cd_entidade_contato", ComercialVendasPedidos.codigoEntidadeContato, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "ReferenciaPedido", "nm_referencia_pedido", ComercialVendasPedidos.referenciaPedido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DataEntrega", "dt_entrega", ComercialVendasPedidos.dataEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoModoPagamento", "cd_modo_pagamento", ComercialVendasPedidos.codigoModoPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCondicaoPagamento", "cd_condicao_pagamento", ComercialVendasPedidos.codigoCondicaoPagamento, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoTransportadora", "cd_transportadora", ComercialVendasPedidos.codigoTransportadora, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoVendedor", "cd_vendedor", ComercialVendasPedidos.codigoVendedor, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoRepresentante", "cd_representante", ComercialVendasPedidos.codigoRepresentante, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeEntrega", "cd_entidade_entrega", ComercialVendasPedidos.codigoEntidadeEntrega, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoEntidadeFatura", "cd_entidade_fatura", ComercialVendasPedidos.codigoEntidadeFatura, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoCfop", "cd_cfopi", ComercialVendasPedidos.codigoCfop, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoMoeda", "cd_moeda", ComercialVendasPedidos.codigoMoeda, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "DescricaoPedido", "ds_pedido", ComercialVendasPedidos.descricaoPedido, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoStatus", "cd_status", ComercialVendasPedidos.codigoStatus, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialVendasPedidos.id));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialVendasPedidos(int id)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[VendasPedidos] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", id));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
