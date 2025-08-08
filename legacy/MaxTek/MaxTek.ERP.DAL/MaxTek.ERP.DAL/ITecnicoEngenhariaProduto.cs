using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface ITecnicoEngenhariaProduto
{
	IList<MapTableTecnicoEngenhariaProduto> ObterTodosTecnicoEngenhariaProduto();

	MapTableTecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(int id);

	MapTableTecnicoEngenhariaProduto ObterTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto tecnicoEngenhariaProduto);

	int InserirTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto tecnicoEngenhariaProduto);

	int AlterarTecnicoEngenhariaProduto(MapTableTecnicoEngenhariaProduto tecnicoEngenhariaProduto, Hashtable camposAlterados);

	int ExcluirTecnicoEngenhariaProduto(int id);
}
