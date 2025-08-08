using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcessoOperacaoFerramenta
{
	public int id;

	public int idProcessoOperacao;

	public int idFerramenta;

	public int codigoTipoFerramenta;

	public decimal necessidade;
}
