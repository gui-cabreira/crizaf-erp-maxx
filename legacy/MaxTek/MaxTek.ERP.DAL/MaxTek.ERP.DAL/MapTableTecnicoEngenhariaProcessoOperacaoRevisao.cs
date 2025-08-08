using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcessoOperacaoRevisao
{
	public int id;

	public int idProcessoOperacao;

	public int revisao;

	public string descricao;

	public DateTime data;

	public int codigoFuncionarioRevisor;

	public string nomeUsuarioConectado;

	public string sqlUtilizado;
}
