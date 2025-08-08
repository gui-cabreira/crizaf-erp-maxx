using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalCest
{
	IList<MapTableNotaFiscalCest> ObterTodosNotaFiscalCest();

	MapTableNotaFiscalCest ObterNotaFiscalCest(string codigoCest, int codigoEstado);

	MapTableNotaFiscalCest ObterNotaFiscalCest(string codigoCest, string ncm, int codigoEstado);

	MapTableNotaFiscalCest ObterNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest);

	int InserirNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest);

	int AlterarNotaFiscalCest(MapTableNotaFiscalCest NotaFiscalCest, Hashtable camposAlterados);

	int ExcluirNotaFiscalCest(int id);
}
