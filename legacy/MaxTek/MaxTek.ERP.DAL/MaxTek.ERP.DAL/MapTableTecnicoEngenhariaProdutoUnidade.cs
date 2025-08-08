using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProdutoUnidade
{
	public int id;

	public string unidade;

	public int grupo;

	public decimal coeficienteGrupo;

	public string sigla;

	public int codigoGPS;
}
