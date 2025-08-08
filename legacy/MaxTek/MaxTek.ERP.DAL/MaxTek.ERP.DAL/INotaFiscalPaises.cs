using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalPaises
{
	IList<MapTableNotaFiscalPaises> ObterTodosNotaFiscalPaises();

	MapTableNotaFiscalPaises ObterNotaFiscalPaises(string pais);

	MapTableNotaFiscalPaises ObterNotaFiscalPaises(int codigoPais);

	MapTableNotaFiscalPaises ObterNotaFiscalPaises(MapTableNotaFiscalPaises NotaFiscalPaises);

	int InserirNotaFiscalPaises(MapTableNotaFiscalPaises NotaFiscalPaises);

	int AlterarNotaFiscalPaises(MapTableNotaFiscalPaises NotaFiscalPaises, Hashtable camposAlterados);

	int ExcluirNotaFiscalPaises(string pais);
}
