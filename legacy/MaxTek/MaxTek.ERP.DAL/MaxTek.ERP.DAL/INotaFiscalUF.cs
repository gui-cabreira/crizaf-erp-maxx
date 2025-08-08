using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalUF
{
	IList<MapTableNotaFiscalUF> ObterTodosNotaFiscalUF();

	MapTableNotaFiscalUF ObterNotaFiscalUF(int id);

	MapTableNotaFiscalUF ObterNotaFiscalUF(string uf);

	MapTableNotaFiscalUF ObterNotaFiscalUF(MapTableNotaFiscalUF NotaFiscalUF);

	int InserirNotaFiscalUF(MapTableNotaFiscalUF NotaFiscalUF);

	int AlterarNotaFiscalUF(MapTableNotaFiscalUF NotaFiscalUF, Hashtable camposAlterados);

	int ExcluirNotaFiscalUF(int id);
}
