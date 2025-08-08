using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalResumoFaturamento
{
	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento();

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamento(int ano, int mes, string contaContabil, string cfop, int codigoEntidade);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int mes, int codigoEntidade);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int ano, int codigoEntidade);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoEntidade(int codigoEntidade);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, int mes, string contaContabil);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(int ano, string contaContabil);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoContaContabil(string contaContabil);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, int mes, string cfop);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(int ano, string cfop);

	IList<MapTableNotaFiscalResumoFaturamento> ObterTodosNotaFiscalResumoFaturamentoCfop(string cfop);
}
