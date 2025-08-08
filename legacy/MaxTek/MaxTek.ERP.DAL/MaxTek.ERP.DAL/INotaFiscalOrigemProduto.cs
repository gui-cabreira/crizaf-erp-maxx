using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalOrigemProduto
{
	IList<MapTableNotaFiscalOrigemProduto> ObterTodosNotaFiscalOrigemProduto();

	MapTableNotaFiscalOrigemProduto ObterNotaFiscalOrigemProduto(int id);

	MapTableNotaFiscalOrigemProduto ObterNotaFiscalOrigemProduto(MapTableNotaFiscalOrigemProduto NotaFiscalOrigemProduto);

	int InserirNotaFiscalOrigemProduto(MapTableNotaFiscalOrigemProduto NotaFiscalOrigemProduto);

	int AlterarNotaFiscalOrigemProduto(MapTableNotaFiscalOrigemProduto NotaFiscalOrigemProduto, Hashtable camposAlterados);

	int ExcluirNotaFiscalOrigemProduto(int id);
}
