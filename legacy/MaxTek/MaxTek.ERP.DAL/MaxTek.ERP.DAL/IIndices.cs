using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface IIndices
{
	IList<MapTableListaIndices> ObterListaIndices(string schema, string tabela);

	IList<MapTableIndices> ObterIndices(int objectId, int indexId);
}
