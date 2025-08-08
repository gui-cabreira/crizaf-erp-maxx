using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IComercialEntidadeContato
{
	IList<MapTableComercialEntidadeContato> ObterTodosComercialEntidadeContato();

	IList<MapTableComercialEntidadeContato> ObterTodosComercialEntidadeContato(int codigoEntidade);

	MapTableComercialEntidadeContato ObterComercialEntidadeContato(int codigo);

	MapTableComercialEntidadeContato ObterComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato);

	int InserirComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato);

	int AlterarComercialEntidadeContato(MapTableComercialEntidadeContato ComercialEntidadeContato, Hashtable camposAlterados);

	int ExcluirComercialEntidadeContato(int codigo);

	int ExcluirTodosComercialEntidadeContato(int codigoEntidade);
}
