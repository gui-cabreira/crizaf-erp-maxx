using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalNotasFiscais
{
	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais();

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(DateTime dataInicio, DateTime dataFim);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoEmpresa, DateTime dataInicio, DateTime dataFim);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int codigoCliente);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscais(int tipo, int codigoEntidade);

	MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoNotaFiscalSerie);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoNota(int codigoNota);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoPedidoVenda(int codigoPedidoVenda);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoProduto(string codigoProduto);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisCodigoContrato(string codigoContrato);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalNotasFiscaisSituacao(string situacao);

	MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(string chave);

	MapTableNotaFiscalNotasFiscais ObterNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais);

	int InserirNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais);

	int AlterarNotaFiscalNotasFiscais(MapTableNotaFiscalNotasFiscais NotaFiscalNotasFiscais, Hashtable camposAlterados);

	int ExcluirNotaFiscalNotasFiscais(int codigoEmpresa, int codigoNotaFiscal, int codigoNotaFiscalSerie);

	int ObterUltimaNota(int codigoEmpresa, int serie);

	bool ChecarSeNotaExiste(int codigoEmpresa, int numeroNota, int serie);

	IList<MapTableResumoFaturamentoItem> ObterRelatorioFaturamento(DateTime dataInicio, DateTime dataFim);

	IList<MapTableResumoFaturamentoItem> ObterRelatorioFaturamento(int codigoEmpresa, DateTime dataInicio, DateTime dataFim);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(DateTime dataInicio, DateTime dataFim);

	IList<MapTableNotaFiscalNotasFiscais> ObterTodosNotaFiscalServico(int codigoEmpresa, DateTime dataInicio, DateTime dataFim);
}
