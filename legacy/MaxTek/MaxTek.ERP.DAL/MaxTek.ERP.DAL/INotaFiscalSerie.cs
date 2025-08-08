using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalSerie
{
	IList<MapTableNotaFiscalSerie> ObterTodosNotaFiscalSerie();

	IList<MapTableNotaFiscalSerie> ObterTodosNotaFiscalSerie(int codigoEmpresa);

	MapTableNotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa);

	MapTableNotaFiscalSerie ObterNotaFiscalSerie(int codigoEmpresa, int codigoSerie);

	MapTableNotaFiscalSerie ObterNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie);

	int InserirNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie);

	int AlterarNotaFiscalSerie(MapTableNotaFiscalSerie NotaFiscalSerie, Hashtable camposAlterados);

	int ExcluirNotaFiscalSerie(int id);
}
