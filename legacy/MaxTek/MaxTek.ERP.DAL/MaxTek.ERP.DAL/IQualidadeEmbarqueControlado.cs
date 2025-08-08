using System.Collections;
using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IQualidadeEmbarqueControlado
{
	IList<MapTableQualidadeEmbarqueControlado> ObterTodosQualidadeEmbarqueControlado();

	MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(int id);

	MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(string peca);

	MapTableQualidadeEmbarqueControlado ObterQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado);

	int InserirQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado);

	int AlterarQualidadeEmbarqueControlado(MapTableQualidadeEmbarqueControlado QualidadeEmbarqueControlado, Hashtable camposAlterados);

	int ExcluirQualidadeEmbarqueControlado(int id);
}
