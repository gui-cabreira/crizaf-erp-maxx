using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableDesenvolvimentoClasseCampos
{
	public int id;

	public int idClasse;

	public int idCampo;

	public string nomeCampo;

	public string nomeCampoPervasive;

	public int idTipoDado;

	public string nomeTipoDado;

	public int numeroCasas;

	public string nomeTipoCampo;

	public string nomeCampoClasse;

	public string nomePropriedade;

	public bool isPk;
}
