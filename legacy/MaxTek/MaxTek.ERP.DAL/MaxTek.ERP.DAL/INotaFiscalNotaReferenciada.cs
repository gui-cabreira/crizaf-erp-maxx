using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalNotaReferenciada
{
	IList<MapTableNotaFiscalNotaReferenciada> ObterTodosNotaFiscalNotaReferenciada();

	IList<MapTableNotaFiscalNotaReferenciada> ObterTodosNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF);

	MapTableNotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada);

	MapTableNotaFiscalNotaReferenciada ObterNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada);

	int InserirNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada);

	int AlterarNotaFiscalNotaReferenciada(MapTableNotaFiscalNotaReferenciada NotaFiscalNotaReferenciada, Hashtable camposAlterados);

	int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF, string notaReferenciada);

	int ExcluirNotaFiscalNotaReferenciada(int codigoEmpresa, int numeroNotaFiscal, int codigoSerieNF);
}
