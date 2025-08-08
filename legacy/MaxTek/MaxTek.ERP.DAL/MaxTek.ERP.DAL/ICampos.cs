using System.Collections.Generic;

namespace MaxTek.ERP.DAL;

public interface ICampos
{
	IList<MapTableCampos> ObterCampos(string nomeServidor, string bancoDados, string nomeEsquema, string nomeTabela);
}
