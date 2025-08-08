using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface ITecnicoProducaoApontamento
{
	IList<MapTableTecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento();

	IList<MapTableTecnicoProducaoApontamento> ObterTodosTecnicoProducaoApontamento(DateTime dataInicio, DateTime dataFim);

	MapTableTecnicoProducaoApontamento ObterTecnicoProducaoApontamento(int id);

	MapTableTecnicoProducaoApontamento ObterTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento tecnicoProducaoApontamento);

	int InserirTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento tecnicoProducaoApontamento);

	int AlterarTecnicoProducaoApontamento(MapTableTecnicoProducaoApontamento tecnicoProducaoApontamento, Hashtable camposAlterados);

	int ExcluirTecnicoProducaoApontamento(int id);
}
