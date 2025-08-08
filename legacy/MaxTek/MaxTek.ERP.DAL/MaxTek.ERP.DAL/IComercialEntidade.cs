using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IComercialEntidade
{
	IList<MapTableComercialEntidade> ObterTodosComercialEntidade();

	IList<MapTableComercialEntidade> ObterTodosComercialEntidadeCliente();

	IList<MapTableComercialEntidade> ObterTodosComercialEntidadeFornecedor();

	IList<MapTableComercialEntidade> ObterTodosComercialEntidadeSubContratado();

	IList<MapTableComercialEntidade> ObterTodosComercialEntidadeRepresentante();

	IList<MapTableComercialEntidade> ObterTodosComercialEntidadeTransportadora();

	MapTableComercialEntidade ObterComercialEntidade(int codigo);

	MapTableComercialEntidade ObterComercialEntidade(MapTableComercialEntidade ComercialEntidade);

	int InserirComercialEntidade(MapTableComercialEntidade ComercialEntidade);

	int AlterarComercialEntidade(MapTableComercialEntidade ComercialEntidade, Hashtable camposAlterados);

	int ExcluirComercialEntidade(int codigo);
}
