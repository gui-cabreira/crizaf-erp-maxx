using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class SQLServerNotaFiscalResumoFaturamento : INotaFiscalResumoFaturamento
{
	private MapTableNotaFiscalResumoFaturamento MapearClasse(DataRow row)
	{
		MapTableNotaFiscalResumoFaturamento result = default(MapTableNotaFiscalResumoFaturamento);
		if (row != null)
		{
			result.ano = BaseDadosERP.ObterDbValor<int>(row["ano"]);
			result.mes = BaseDadosERP.ObterDbValor<int>(row["mes"]);
			result.contaContabil = BaseDadosERP.ObterDbValor<string>(row["contaContabil"]);
			result.cfop = BaseDadosERP.ObterDbValor<string>(row["cfop"]);
			result.codigoEntidade = BaseDadosERP.ObterDbValor<int>(row["codigoEntidade"]);
			result.valorTotal = BaseDadosERP.ObterDbValor<decimal>(row["valorTotal"]);
			result.valorBaseICMS = BaseDadosERP.ObterDbValor<decimal>(row["valorBaseICMS"]);
			result.valorIcms = BaseDadosERP.ObterDbValor<decimal>(row["valorIcms"]);
			result.valorIpi = BaseDadosERP.ObterDbValor<decimal>(row["valorIpi"]);
			result.valorPis = BaseDadosERP.ObterDbValor<decimal>(row["valorPis"]);
			result.valorCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorCofins"]);
			result.valorFrete = BaseDadosERP.ObterDbValor<decimal>(row["valorFrete"]);
			result.valorSeguro = BaseDadosERP.ObterDbValor<decimal>(row["valorSeguro"]);
			result.valorFatura = BaseDadosERP.ObterDbValor<decimal>(row["valorFatura"]);
			result.valorRetencaoPis = BaseDadosERP.ObterDbValor<decimal>(row["valorRetencaoPis"]);
			result.valorRetencaoCofins = BaseDadosERP.ObterDbValor<decimal>(row["valorRetencaoCofins"]);
			result.valorCsll = BaseDadosERP.ObterDbValor<decimal>(row["valorCsll"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("[Ano] as [ano], ");
		stringBuilder.Append("[Mes] as [mes], ");
		stringBuilder.Append("[ContaContabil] as [contaContabil], ");
		stringBuilder.Append("[CFOP] as [cfop], ");
		stringBuilder.Append("[Entidade] as [codigoEntidade], ");
		stringBuilder.Append("[ValorTotal] as [valorTotal], ");
		stringBuilder.Append("[baseICMS] as [valorBaseICMS], ");
		stringBuilder.Append("[ICMS] as [valorIcms], ");
		stringBuilder.Append("[IPI] as [valorIpi], ");
		stringBuilder.Append("[PIS] as [valorPis], ");
		stringBuilder.Append("[Cofins] as [valorCofins], ");
		stringBuilder.Append("[Frete] as [valorFrete], ");
		stringBuilder.Append("[Segura] as [valorSeguro], ");
		stringBuilder.Append("[Fatura] as [valorFatura], ");
		stringBuilder.Append("[RetencaoPis] as [valorRetencaoPis], ");
		stringBuilder.Append("[RetencaoCofins] as [valorRetencaoCofins], ");
		stringBuilder.Append("[CSLL] as [valorCsll]");
		stringBuilder.Append(" from [" + BaseDadosERP.NomeServidor + "].[" + BaseDadosERP.NomeBaseDados + "].[NotaFiscal].[ResumoFaturamento] ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalResumoFaturamento> list = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes and");
		stringBuilder.Append(" [ContaContabil] = @ContaContabil ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		list.Add(BaseDadosERP.ObterNovoParametro("@ContaContabil", contaContabil));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes and");
		stringBuilder.Append(" [ContaContabil] = @ContaContabil and");
		stringBuilder.Append(" [CFOP] = @CFOP ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		list.Add(BaseDadosERP.ObterNovoParametro("@ContaContabil", contaContabil));
		list.Add(BaseDadosERP.ObterNovoParametro("@CFOP", cfop));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop, int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes and");
		stringBuilder.Append(" [ContaContabil] = @ContaContabil and");
		stringBuilder.Append(" [CFOP] = @CFOP and");
		stringBuilder.Append(" [Entidade] = @Entidade");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		list.Add(BaseDadosERP.ObterNovoParametro("@ContaContabil", contaContabil));
		list.Add(BaseDadosERP.ObterNovoParametro("@CFOP", cfop));
		list.Add(BaseDadosERP.ObterNovoParametro("@Entidade", codigoEntidade));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int mes, int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes and");
		stringBuilder.Append(" [Entidade] = @Entidade");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		list.Add(BaseDadosERP.ObterNovoParametro("@Entidade", codigoEntidade));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Entidade] = @Entidade");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Entidade", codigoEntidade));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int codigoEntidade)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Entidade] = @Entidade");
		list.Add(BaseDadosERP.ObterNovoParametro("@Entidade", codigoEntidade));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, int mes, string contaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes and");
		stringBuilder.Append(" [ContaContabil] = @ContaContabil ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		list.Add(BaseDadosERP.ObterNovoParametro("@ContaContabil", contaContabil));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, string contaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [ContaContabil] = @ContaContabil ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@ContaContabil", contaContabil));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(string contaContabil)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [ContaContabil] = @ContaContabil ");
		list.Add(BaseDadosERP.ObterNovoParametro("@ContaContabil", contaContabil));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, int mes, string cfop)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [Mes] = @Mes and");
		stringBuilder.Append(" [CFOP] = @CFOP ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@Mes", mes));
		list.Add(BaseDadosERP.ObterNovoParametro("@CFOP", cfop));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, string cfop)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [Ano] = @Ano and");
		stringBuilder.Append(" [CFOP] = @CFOP ");
		list.Add(BaseDadosERP.ObterNovoParametro("@Ano", ano));
		list.Add(BaseDadosERP.ObterNovoParametro("@CFOP", cfop));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(string cfop)
	{
		IList<DbParameter> list = new List<DbParameter>();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		stringBuilder.Append("Where ");
		stringBuilder.Append(" [CFOP] = @CFOP ");
		list.Add(BaseDadosERP.ObterNovoParametro("@CFOP", cfop));
		DataTable dataTable = BaseDadosERP.ObterDataTable(stringBuilder.ToString(), list);
		IList<MapTableNotaFiscalResumoFaturamento> list2 = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list2.Add(MapearClasse(row));
		}
		return list2;
	}
}
