using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IParametrosSociedade
{
	IList<MapTableParametrosSociedade> ObterTodosParametrosSociedade();

	MapTableParametrosSociedade ObterParametrosSociedade(int id);

	MapTableParametrosSociedade ObterParametrosSociedade(MapTableParametrosSociedade ParametrosSociedade);

	int InserirParametrosSociedade(MapTableParametrosSociedade ParametrosSociedade);

	int AlterarParametrosSociedade(MapTableParametrosSociedade ParametrosSociedade, Hashtable camposAlterados);

	int ExcluirParametrosSociedade(int id);
}
