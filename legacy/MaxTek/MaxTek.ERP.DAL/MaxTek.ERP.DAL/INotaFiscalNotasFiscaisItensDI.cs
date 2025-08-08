using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalNotasFiscaisItensDI
{
	IList<MapTableNotaFiscalNotasFiscaisItensDI> ObterTodosNotaFiscalNotasFiscaisItensDI();

	MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI);

	MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem);

	MapTableNotaFiscalNotasFiscaisItensDI ObterNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI);

	int InserirNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI);

	int AlterarNotaFiscalNotasFiscaisItensDI(MapTableNotaFiscalNotasFiscaisItensDI NotaFiscalNotasFiscaisItensDI, Hashtable camposAlterados);

	int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal, int ordem, string numeroDI);

	int ExcluirNotaFiscalNotasFiscaisItensDI(int codigoEmpresa, int codigoSerieNotaFiscal, int codigoNotaFiscal);
}
