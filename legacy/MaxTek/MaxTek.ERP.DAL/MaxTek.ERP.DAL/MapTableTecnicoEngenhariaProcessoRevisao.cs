using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcessoRevisao
{
	public int id;

	public int idProcesso;

	public int revisao;

	public string descricao;

	public DateTime data;

	public int codigoFuncionarioRevisor;

	public string nomeUsuarioConectado;

	public string sqlUtilizado;
}
