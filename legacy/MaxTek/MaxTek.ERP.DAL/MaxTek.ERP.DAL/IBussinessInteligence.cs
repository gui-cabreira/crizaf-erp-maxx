using System;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IBussinessInteligence
{
	IList<MapTableDataQuantidadeValor> ObterBI_NF_Data_Quantidade_Valor(DateTime dataInicio, DateTime dataFim);
}
