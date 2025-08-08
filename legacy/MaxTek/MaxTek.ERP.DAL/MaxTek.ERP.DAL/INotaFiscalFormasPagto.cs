using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalFormasPagto
{
	IList<MapTableNotaFiscalFormasPagto> ObterTodosNotaFiscalFormasPagto();

	MapTableNotaFiscalFormasPagto ObterNotaFiscalFormasPagto(int id);

	MapTableNotaFiscalFormasPagto ObterNotaFiscalFormasPagto(MapTableNotaFiscalFormasPagto NotaFiscalFormasPagto);

	int InserirNotaFiscalFormasPagto(MapTableNotaFiscalFormasPagto NotaFiscalFormasPagto);

	int AlterarNotaFiscalFormasPagto(MapTableNotaFiscalFormasPagto NotaFiscalFormasPagto, Hashtable camposAlterados);

	int ExcluirNotaFiscalFormasPagto(int id);
}
