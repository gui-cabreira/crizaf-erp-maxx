using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableWorkFlowTarefa
{
	public int id;

	public DateTime dataSolicitacao;

	public bool isConcluido;

	public int status;

	public int codigoSolicitante;

	public int codigoSolicitado;

	public string assunto;

	public string solicitacao;

	public string comentario;

	public DateTime dataConclusao;

	public int codigoDepartamentoSolicitante;

	public string codigoDepartamentoSolicitado;

	public int prioridade;

	public int percentualConcluido;
}
