using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalWebServices
{
	IList<MapTableNotaFiscalWebServices> ObterTodosNotaFiscalWebServices();

	MapTableNotaFiscalWebServices ObterNotaFiscalWebServices(string uf, string ambiente, string servico);

	MapTableNotaFiscalWebServices ObterNotaFiscalWebServices(MapTableNotaFiscalWebServices NotaFiscalWebServices);

	int InserirNotaFiscalWebServices(MapTableNotaFiscalWebServices NotaFiscalWebServices);

	int AlterarNotaFiscalWebServices(MapTableNotaFiscalWebServices NotaFiscalWebServices, Hashtable camposAlterados);

	int ExcluirNotaFiscalWebServices(string uf, string ambiente, string servico);
}
