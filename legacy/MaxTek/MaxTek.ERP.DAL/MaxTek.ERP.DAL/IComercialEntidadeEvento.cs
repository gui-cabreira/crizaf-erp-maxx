using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IComercialEntidadeEvento
{
	IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEvento();

	IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEventoAcompanhar();

	IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEventoPorPeriodo(DateTime dataInicio, DateTime dataFim);

	IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEvento(int codigoEntidade);

	IList<MapTableComercialEntidadeEvento> ObterTodosComercialEntidadeEventoContato(int codigoContato);

	MapTableComercialEntidadeEvento ObterComercialEntidadeEvento(int codigo);

	MapTableComercialEntidadeEvento ObterComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento);

	int InserirComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento);

	int AlterarComercialEntidadeEvento(MapTableComercialEntidadeEvento ComercialEntidadeEvento, Hashtable camposAlterados);
}
