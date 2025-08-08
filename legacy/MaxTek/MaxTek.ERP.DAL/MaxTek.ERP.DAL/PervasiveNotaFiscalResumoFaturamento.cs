using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MaxTek.DataBase;

namespace MaxTek.ERP.DAL;

internal class PervasiveNotaFiscalResumoFaturamento : INotaFiscalResumoFaturamento
{
	private MapTableNotaFiscalResumoFaturamento MapearClasse(DataRow row)
	{
		MapTableNotaFiscalResumoFaturamento result = default(MapTableNotaFiscalResumoFaturamento);
		if (row != null)
		{
			result.ano = BaseDadosGPS.ObterDbValor<int>(row["ano"]);
			result.mes = BaseDadosGPS.ObterDbValor<int>(row["mes"]);
			result.contaContabil = BaseDadosGPS.ObterDbValor<string>(row["contaContabil"]);
			result.cfop = BaseDadosGPS.ObterDbValor<string>(row["cfop"]);
			result.codigoEntidade = BaseDadosGPS.ObterDbValor<int>(row["codigoEntidade"]);
			result.valorTotal = BaseDadosGPS.ObterDbValor<decimal>(row["valorTotal"]);
			result.valorBaseICMS = BaseDadosGPS.ObterDbValor<decimal>(row["valorBaseICMS"]);
			result.valorIcms = BaseDadosGPS.ObterDbValor<decimal>(row["valorIcms"]);
			result.valorIpi = BaseDadosGPS.ObterDbValor<decimal>(row["valorIpi"]);
			result.valorPis = BaseDadosGPS.ObterDbValor<decimal>(row["valorPis"]);
			result.valorCofins = BaseDadosGPS.ObterDbValor<decimal>(row["valorCofins"]);
			result.valorFrete = BaseDadosGPS.ObterDbValor<decimal>(row["valorFrete"]);
			result.valorSeguro = BaseDadosGPS.ObterDbValor<decimal>(row["valorSeguro"]);
			result.valorFatura = BaseDadosGPS.ObterDbValor<decimal>(row["valorFatura"]);
			result.valorRetencaoPis = BaseDadosGPS.ObterDbValor<decimal>(row["valorRetencaoPis"]);
			result.valorRetencaoCofins = BaseDadosGPS.ObterDbValor<decimal>(row["valorRetencaoCofins"]);
			result.valorCsll = BaseDadosGPS.ObterDbValor<decimal>(row["valorCsll"]);
		}
		return result;
	}

	private string ObterSql()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Select ");
		stringBuilder.Append("Ano as ano, ");
		stringBuilder.Append("Mes as mes, ");
		stringBuilder.Append("ContaContabil as contaContabil, ");
		stringBuilder.Append("CFOP as cfop, ");
		stringBuilder.Append("Entidade as codigoEntidade, ");
		stringBuilder.Append("ValorTotal as valorTotal, ");
		stringBuilder.Append("baseICMS as valorBaseICMS, ");
		stringBuilder.Append("ICMS as valorIcms, ");
		stringBuilder.Append("IPI as valorIpi, ");
		stringBuilder.Append("PIS as valorPis, ");
		stringBuilder.Append("Cofins as valorCofins, ");
		stringBuilder.Append("Frete as valorFrete, ");
		stringBuilder.Append("Segura as valorSeguro, ");
		stringBuilder.Append("Fatura as valorFatura, ");
		stringBuilder.Append("RetencaoPis as valorRetencaoPis, ");
		stringBuilder.Append("RetencaoCofins as valorRetencaoCofins, ");
		stringBuilder.Append("CSLL as valorCsll");
		stringBuilder.Append(" from " + BaseDadosGPS.NomeBaseDados + "ERP.calResumoFaturamento ");
		return stringBuilder.ToString();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ObterSql());
		DataTable dataTable = BaseDadosGPS.ObterDataTable(stringBuilder.ToString());
		IList<MapTableNotaFiscalResumoFaturamento> list = new List<MapTableNotaFiscalResumoFaturamento>();
		foreach (DataRow row in dataTable.Rows)
		{
			list.Add(MapearClasse(row));
		}
		return list;
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop, int codigoEntidade)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int mes, int codigoEntidade)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int codigoEntidade)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int codigoEntidade)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, int mes, string contaContabil)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, string contaContabil)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(string contaContabil)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, int mes, string cfop)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, string cfop)
	{
		throw new NotImplementedException();
	}

	public IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(string cfop)
	{
		throw new NotImplementedException();
	}
}
