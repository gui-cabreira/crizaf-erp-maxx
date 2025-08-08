using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialFinanceiroModoPagamento : IComercialFinanceiroModoPagamento
{
	private MapTableComercialFinanceiroModoPagamento MapearClasse(DataRow row)
	{
		MapTableComercialFinanceiroModoPagamento result = default(MapTableComercialFinanceiroModoPagamento);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.sigla = BaseDadosERP.ObterDbValor<string>(row["sigla"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
			result.gerarBoleto = BaseDadosERP.ObterDbValor<bool>(row["gerarBoleto"]);
			result.codigoContaContabil = BaseDadosERP.ObterDbValor<int>(row["codigoContaContabil"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[nm_sigla] as [sigla], ");
		stringBuilder.Append("[nm_modo_pagamento] as [nome], ");
		stringBuilder.Append("[ic_gera_boleto] as [gerarBoleto], ");
		stringBuilder.Append("[id_conta_contabil] as [codigoContaContabil]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroModoPagamento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFinanceiroModoPagamento> ObterTodosComercialFinanceiroModoPagamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialFinanceiroModoPagamento> list = new List<MapTableComercialFinanceiroModoPagamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialFinanceiroModoPagamento ObterComercialFinanceiroModoPagamento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialFinanceiroModoPagamento ObterComercialFinanceiroModoPagamento(MapTableComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFinanceiroModoPagamento.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFinanceiroModoPagamento(MapTableComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroModoPagamento] (");
		stringBuilder.Append("nm_sigla, ");
		stringBuilder.Append("nm_modo_pagamento, ");
		stringBuilder.Append("ic_gera_boleto, ");
		stringBuilder.Append("id_conta_contabil) Values (@nm_sigla,@nm_modo_pagamento,@ic_gera_boleto,@id_conta_contabil) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_sigla", ComercialFinanceiroModoPagamento.sigla));
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_modo_pagamento", ComercialFinanceiroModoPagamento.nome));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_gera_boleto", ComercialFinanceiroModoPagamento.gerarBoleto));
		list.Add(BaseDadosERP.ObterNovoParametro("@id_conta_contabil", ComercialFinanceiroModoPagamento.codigoContaContabil));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFinanceiroModoPagamento(MapTableComercialFinanceiroModoPagamento ComercialFinanceiroModoPagamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroModoPagamento] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Sigla", "nm_sigla", ComercialFinanceiroModoPagamento.sigla, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_modo_pagamento", ComercialFinanceiroModoPagamento.nome, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "GerarBoleto", "ic_gera_boleto", ComercialFinanceiroModoPagamento.gerarBoleto, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CodigoContaContabil", "id_conta_contabil", ComercialFinanceiroModoPagamento.codigoContaContabil, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFinanceiroModoPagamento.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFinanceiroModoPagamento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroModoPagamento] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
