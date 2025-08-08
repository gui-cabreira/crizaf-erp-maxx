using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableCampos
{
	public int id;

	public string nomeEsquema;

	public string nomeColuna;

	public string tipoDado;

	public int quantidadeCaracteres;
}
