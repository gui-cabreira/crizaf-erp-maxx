using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IFinanceiroTitulos
{
	IList<MapTableFinanceiroTitulos> ObterTodosFinanceiroTitulos();

	MapTableFinanceiroTitulos ObterFinanceiroTitulos(int id);

	MapTableFinanceiroTitulos ObterFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos);

	int InserirFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos);

	int AlterarFinanceiroTitulos(MapTableFinanceiroTitulos FinanceiroTitulos, Hashtable camposAlterados);

	int ExcluirFinanceiroTitulos(int id);
}
