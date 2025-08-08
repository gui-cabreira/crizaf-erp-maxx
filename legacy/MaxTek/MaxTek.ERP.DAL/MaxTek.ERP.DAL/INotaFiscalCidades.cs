using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalCidades
{
	IList<MapTableNotaFiscalCidades> ObterTodosNotaFiscalCidades();

	MapTableNotaFiscalCidades ObterNotaFiscalCidades(int id);

	MapTableNotaFiscalCidades ObterNotaFiscalCidades(string cidade);

	MapTableNotaFiscalCidades ObterNotaFiscalCidades(int codigoEstado, string cidade);

	IList<MapTableNotaFiscalCidades> ObterNotaFiscalCidadesEstado(int codigoEstado);

	MapTableNotaFiscalCidades ObterNotaFiscalCidades(MapTableNotaFiscalCidades NotaFiscalCidades);

	int InserirNotaFiscalCidades(MapTableNotaFiscalCidades NotaFiscalCidades);

	int AlterarNotaFiscalCidades(MapTableNotaFiscalCidades NotaFiscalCidades, Hashtable camposAlterados);

	int ExcluirNotaFiscalCidades(int id);
}
