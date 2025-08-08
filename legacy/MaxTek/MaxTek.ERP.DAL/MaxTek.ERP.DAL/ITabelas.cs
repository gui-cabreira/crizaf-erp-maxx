using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface ITabelas
{
	IList<MapTableTabelas> ObterTabelas(string nomeServidor, string nomeBaseDados);

	MapTableTabelas ObterTabela(string nomeServidor, string nomeBaseDados, string nomeEsquema, string nomeTabela);
}
