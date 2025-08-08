using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveComercialFinanceiroCondicaoPagamento : IComercialFinanceiroCondicaoPagamento
{
	private MapTableComercialFinanceiroCondicaoPagamento MapearClasse(DataRow row)
	{
		MapTableComercialFinanceiroCondicaoPagamento result = default(MapTableComercialFinanceiroCondicaoPagamento);
		if (row != null)
		{
			result.codigo = BaseDadosGPS.ObterDbValor<int>(row["codigo"]);
			result.nome = BaseDadosGPS.ObterDbValor<string>(row["nome"]);
			result.numeroDiasPrimeiraParcela = BaseDadosGPS.ObterDbValor<int>(row["numeroDiasPrimeiraParcela"]);
			result.numeroDiasDemaisParcelas = BaseDadosGPS.ObterDbValor<int>(row["numeroDiasDemaisParcelas"]);
			result.numeroParcelas = BaseDadosGPS.ObterDbValor<int>(row["numeroParcelas"]);
			result.calculoManualData = BaseDadosGPS.ObterDbValor<bool>(row["calculoManualData"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("id as codigo, ");
		stringBuilder.Append("nm_condicao_pgto as nome, ");
		stringBuilder.Append("vl_dias_primeira_par as numeroDiasPrimeiraParcela, ");
		stringBuilder.Append("vl_dias_demais_par as numeroDiasDemaisParcelas, ");
		stringBuilder.Append("vl_numero_parcelas as numeroParcelas, ");
		stringBuilder.Append("ic_calculo_manual as calculoManualData");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.CondicaoPagamento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableComercialFinanceiroCondicaoPagamento> ObterTodosComercialFinanceiroCondicaoPagamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
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
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public MapTableComercialFinanceiroCondicaoPagamento ObterComercialFinanceiroCondicaoPagamento(MapTableComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFinanceiroCondicaoPagamento.codigo));
		DataRow row = BaseDadosGPS.ObterDataRow(stringBuilder.ToString(), list);
		return MapearClasse(row);
	}

	public int InserirComercialFinanceiroCondicaoPagamento(MapTableComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamento)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Insert into " + BaseDadosGPS.NomeBaseDados + "ERP.CondicaoPagamento (");
		stringBuilder.Append("nm_condicao_pgto, ");
		stringBuilder.Append("vl_dias_primeira_par, ");
		stringBuilder.Append("vl_dias_demais_par, ");
		stringBuilder.Append("vl_numero_parcelas, ");
		stringBuilder.Append("ic_calculo_manual) Values (?,?,?,?,?) ");
		list.Add(BaseDadosGPS.ObterNovoParametro("nm_condicao_pgto", ComercialFinanceiroCondicaoPagamento.nome));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_dias_primeira_par", ComercialFinanceiroCondicaoPagamento.numeroDiasPrimeiraParcela));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_dias_demais_par", ComercialFinanceiroCondicaoPagamento.numeroDiasDemaisParcelas));
		list.Add(BaseDadosGPS.ObterNovoParametro("vl_numero_parcelas", ComercialFinanceiroCondicaoPagamento.numeroParcelas));
		list.Add(BaseDadosGPS.ObterNovoParametro("ic_calculo_manual", ComercialFinanceiroCondicaoPagamento.calculoManualData));
		return BaseDadosGPS.Insert(stringBuilder.ToString(), getId: true, list);
	}

	public int AlterarComercialFinanceiroCondicaoPagamento(MapTableComercialFinanceiroCondicaoPagamento ComercialFinanceiroCondicaoPagamento, Hashtable camposAlterados)
	{
		int result = 0;
		if (camposAlterados.Count > 0)
		{
			IList<DbParameter> list = new List<DbParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Update " + BaseDadosGPS.NomeBaseDados + "ERP.CondicaoPagamento Set ");
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "Nome", "nm_condicao_pgto", ComercialFinanceiroCondicaoPagamento.nome, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NumeroDiasPrimeiraParcela", "vl_dias_primeira_par", ComercialFinanceiroCondicaoPagamento.numeroDiasPrimeiraParcela, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NumeroDiasDemaisParcelas", "vl_dias_demais_par", ComercialFinanceiroCondicaoPagamento.numeroDiasDemaisParcelas, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "NumeroParcelas", "vl_numero_parcelas", ComercialFinanceiroCondicaoPagamento.numeroParcelas, camposAlterados));
			list.Add(BaseDadosGPS.AddSQLSmartUpdate(stringBuilder, "CalculoManualData", "ic_calculo_manual", ComercialFinanceiroCondicaoPagamento.calculoManualData, camposAlterados));
			stringBuilder.Append(" Where ");
			stringBuilder.Append("id = ?");
			list.Add(BaseDadosGPS.ObterNovoParametro("id", ComercialFinanceiroCondicaoPagamento.codigo));
			result = BaseDadosGPS.Update(stringBuilder.ToString(), list);
		}
		return result;
	}

	public int ExcluirComercialFinanceiroCondicaoPagamento(int codigo)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delete from " + BaseDadosGPS.NomeBaseDados + "ERP.CondicaoPagamento ");
		stringBuilder.Append("Where ");
		stringBuilder.Append(" id = ?");
		list.Add(BaseDadosGPS.ObterNovoParametro("id", codigo));
		return BaseDadosGPS.Update(stringBuilder.ToString(), list);
	}
}
