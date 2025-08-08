using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerComercialFinanceiroCondicaoPagamento : IComercialFinanceiroCondicaoPagamento
{
	private MapTableComercialFinanceiroCondicaoPagamento MapearClasse(DataRow row)
	{
		MapTableComercialFinanceiroCondicaoPagamento result = default(MapTableComercialFinanceiroCondicaoPagamento);
		if (row != null)
		{
			result.codigo = BaseDadosERP.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosERP.ObterDbValor<string>(row["nome"]);
			result.numeroDiasPrimeiraParcela = BaseDadosERP.ObterDbValor<int>(row["numeroDiasPrimeiraParcela"]);
			result.numeroDiasDemaisParcelas = BaseDadosERP.ObterDbValor<int>(row["numeroDiasDemaisParcelas"]);
			result.numeroParcelas = BaseDadosERP.ObterDbValor<int>(row["numeroParcelas"]);
			result.calculoManualData = BaseDadosERP.ObterDbValor<bool>(row["calculoManualData"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[id] as [codigo], ");
		stringBuilder.Append("[nm_condicao_pagamento] as [nome], ");
		stringBuilder.Append("[vl_dias_primeira_parcela] as [numeroDiasPrimeiraParcela], ");
		stringBuilder.Append("[vl_dias_demais_parcelas] as [numeroDiasDemaisParcelas], ");
		stringBuilder.Append("[vl_numero_parcelas] as [numeroParcelas], ");
		stringBuilder.Append("[ic_calculo_manual_data] as [calculoManualData]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroCondicaoPagamento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFinanceiroCondicaoPagamento> ObterTodosComercialFinanceiroCondicaoPagamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableComercialFinanceiroCondicaoPagamento> list = new List<MapTableComercialFinanceiroCondicaoPagamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public MapTableComercialFinanceiroCondicaoPagamento ObterComercialFinanceiroCondicaoPagamento(int codigo)
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

	public MapTableComercialFinanceiroCondicaoPagamento ObterComercialFinanceiroCondicaoPagamento(MapTableComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFinanceiroCondicaoPagamento.codigo));
		DataRow row = BaseDadosERP.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFinanceiroCondicaoPagamento(MapTableComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroCondicaoPagamento] (");
		stringBuilder.Append("nm_condicao_pagamento, ");
		stringBuilder.Append("vl_dias_primeira_parcela, ");
		stringBuilder.Append("vl_dias_demais_parcelas, ");
		stringBuilder.Append("vl_numero_parcelas, ");
		stringBuilder.Append("ic_calculo_manual_data) Values (@nm_condicao_pagamento,@vl_dias_primeira_parcela,@vl_dias_demais_parcelas,@vl_numero_parcelas,@ic_calculo_manual_data) ");
		list.Add(BaseDadosERP.ObterNovoParametro("@nm_condicao_pagamento", ComercialFinanceiroCondicaoPagamento.nome));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dias_primeira_parcela", ComercialFinanceiroCondicaoPagamento.numeroDiasPrimeiraParcela));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_dias_demais_parcelas", ComercialFinanceiroCondicaoPagamento.numeroDiasDemaisParcelas));
		list.Add(BaseDadosERP.ObterNovoParametro("@vl_numero_parcelas", ComercialFinanceiroCondicaoPagamento.numeroParcelas));
		list.Add(BaseDadosERP.ObterNovoParametro("@ic_calculo_manual_data", ComercialFinanceiroCondicaoPagamento.calculoManualData));
		return BaseDadosERP.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFinanceiroCondicaoPagamento(MapTableComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroCondicaoPagamento] Set ");
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_condicao_pagamento", ComercialFinanceiroCondicaoPagamento.nome, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeroDiasPrimeiraParcela", "vl_dias_primeira_parcela", ComercialFinanceiroCondicaoPagamento.numeroDiasPrimeiraParcela, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeroDiasDemaisParcelas", "vl_dias_demais_parcelas", ComercialFinanceiroCondicaoPagamento.numeroDiasDemaisParcelas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "NumeroParcelas", "vl_numero_parcelas", ComercialFinanceiroCondicaoPagamento.numeroParcelas, camposAlterados));
			list.Add(BaseDadosERP.AddSQLSmartUpdate(stringBuilder, "CalculoManualData", "ic_calculo_manual_data", ComercialFinanceiroCondicaoPagamento.calculoManualData, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = @id");
			list.Add(BaseDadosERP.ObterNovoParametro("@id", ComercialFinanceiroCondicaoPagamento.codigo));
			result = BaseDadosERP.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFinanceiroCondicaoPagamento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[Comercial].[FinanceiroCondicaoPagamento] ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [id] = @id");
		list.Add(BaseDadosERP.ObterNovoParametro("@id", codigo));
		return BaseDadosERP.Update(stringBuilder.ToString(), list);
	}
}
