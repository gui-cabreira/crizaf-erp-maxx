using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalCFOPs
{
	IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs();

	IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPs(bool Prefeitura);

	IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsAtivos();

	IList<MapTableNotaFiscalCFOPs> ObterTodosNotaFiscalCFOPsDevolucaoMaterialCliente();

	MapTableNotaFiscalCFOPs ObterNotaFiscalCFOPs(int codigoCFOP);

	MapTableNotaFiscalCFOPs ObterNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs);

	int InserirNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs);

	int AlterarNotaFiscalCFOPs(MapTableNotaFiscalCFOPs NotaFiscalCFOPs, Hashtable camposAlterados);

	int ExcluirNotaFiscalCFOPs(int codigoCFOP);
}
