using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotasFiscaisEventos
{
	IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos();

	IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal);

	IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(DateTime dataInicio, DateTime dataFim);

	IList<MapTableNotasFiscaisEventos> ObterTodosNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento);

	MapTableNotasFiscaisEventos ObterNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento);

	MapTableNotasFiscaisEventos ObterNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos);

	int InserirNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos);

	int AlterarNotasFiscaisEventos(MapTableNotasFiscaisEventos NotasFiscaisEventos, Hashtable camposAlterados);

	int ExcluirNotasFiscaisEventos(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, int codigoEvento, int codigoSequenciaEvento);
}
