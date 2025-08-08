using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalTipoIncidencia
{
	IList<MapTableNotaFiscalTipoIncidencia> ObterTodosNotaFiscalTipoIncidencia();

	MapTableNotaFiscalTipoIncidencia ObterNotaFiscalTipoIncidencia(int codigoTipoIncidencia);

	MapTableNotaFiscalTipoIncidencia ObterNotaFiscalTipoIncidencia(MapTableNotaFiscalTipoIncidencia NotaFiscalTipoIncidencia);

	int InserirNotaFiscalTipoIncidencia(MapTableNotaFiscalTipoIncidencia NotaFiscalTipoIncidencia);

	int AlterarNotaFiscalTipoIncidencia(MapTableNotaFiscalTipoIncidencia NotaFiscalTipoIncidencia, Hashtable camposAlterados);

	int ExcluirNotaFiscalTipoIncidencia(int codigoTipoIncidencia);
}
