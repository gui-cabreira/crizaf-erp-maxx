using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalFatura
{
	IList<MapTableNotaFiscalFatura> ObterTodosNotaFiscalFatura();

	IList<MapTableNotaFiscalFatura> ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal);

	MapTableNotaFiscalFatura ObterNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura);

	MapTableNotaFiscalFatura ObterNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura);

	int InserirNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura);

	int AlterarNotaFiscalFatura(MapTableNotaFiscalFatura NotaFiscalFatura, Hashtable camposAlterados);

	int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal, string codigoFatura);

	int ExcluirNotaFiscalFatura(int codigoEmpresa, int codigoNotaFiscal, int codigoSerieNotaFiscal);
}
