using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalTextosLegais
{
	IList<MapTableNotaFiscalTextosLegais> ObterTodosNotaFiscalTextosLegais();

	MapTableNotaFiscalTextosLegais ObterNotaFiscalTextosLegais(int id);

	MapTableNotaFiscalTextosLegais ObterNotaFiscalTextosLegais(MapTableNotaFiscalTextosLegais NotaFiscalTextosLegais);

	int InserirNotaFiscalTextosLegais(MapTableNotaFiscalTextosLegais NotaFiscalTextosLegais);

	int AlterarNotaFiscalTextosLegais(MapTableNotaFiscalTextosLegais NotaFiscalTextosLegais, Hashtable camposAlterados);

	int ExcluirNotaFiscalTextosLegais(int id);
}
