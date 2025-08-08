using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IFinanceiroBancos
{
	IList<MapTableFinanceiroBancos> ObterTodosFinanceiroBancos();

	MapTableFinanceiroBancos ObterFinanceiroBancos(int id);

	MapTableFinanceiroBancos ObterFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos);

	int InserirFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos);

	int AlterarFinanceiroBancos(MapTableFinanceiroBancos FinanceiroBancos, Hashtable camposAlterados);

	int ExcluirFinanceiroBancos(int id);
}
