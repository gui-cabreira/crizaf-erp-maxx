using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface ITecnicoEngenhariaProcesso
{
	IList<MapTableTecnicoEngenhariaProcesso> ObterTodosTecnicoEngenhariaProcesso();

	MapTableTecnicoEngenhariaProcesso ObterTecnicoEngenhariaProcesso(int id);

	MapTableTecnicoEngenhariaProcesso ObterTecnicoEngenhariaProcesso(MapTableTecnicoEngenhariaProcesso TecnicoEngenhariaProcesso);

	int InserirTecnicoEngenhariaProcesso(MapTableTecnicoEngenhariaProcesso TecnicoEngenhariaProcesso);

	int AlterarTecnicoEngenhariaProcesso(MapTableTecnicoEngenhariaProcesso TecnicoEngenhariaProcesso, Hashtable camposAlterados);

	int ExcluirTecnicoEngenhariaProcesso(int id);
}
