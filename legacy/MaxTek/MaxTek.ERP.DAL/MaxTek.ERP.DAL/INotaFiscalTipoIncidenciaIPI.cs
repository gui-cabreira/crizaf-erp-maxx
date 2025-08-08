using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalTipoIncidenciaIPI
{
	IList<MapTableNotaFiscalTipoIncidenciaIPI> ObterTodosNotaFiscalTipoIncidenciaIPI();

	MapTableNotaFiscalTipoIncidenciaIPI ObterNotaFiscalTipoIncidenciaIPI(int id);

	MapTableNotaFiscalTipoIncidenciaIPI ObterNotaFiscalTipoIncidenciaIPI(MapTableNotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPI);

	int InserirNotaFiscalTipoIncidenciaIPI(MapTableNotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPI);

	int AlterarNotaFiscalTipoIncidenciaIPI(MapTableNotaFiscalTipoIncidenciaIPI NotaFiscalTipoIncidenciaIPI, Hashtable camposAlterados);

	int ExcluirNotaFiscalTipoIncidenciaIPI(int id);
}
