using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface INotaFiscalInutilizacao
{
	IList<MapTableNotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao();

	IList<MapTableNotaFiscalInutilizacao> ObterTodosNotaFiscalInutilizacao(int codigoEmpresa);

	MapTableNotaFiscalInutilizacao ObterNotaFiscalInutilizacao(int id);

	MapTableNotaFiscalInutilizacao ObterNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao);

	int InserirNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao);

	int AlterarNotaFiscalInutilizacao(MapTableNotaFiscalInutilizacao NotaFiscalInutilizacao, Hashtable camposAlterados);

	int ExcluirNotaFiscalInutilizacao(int id);
}
