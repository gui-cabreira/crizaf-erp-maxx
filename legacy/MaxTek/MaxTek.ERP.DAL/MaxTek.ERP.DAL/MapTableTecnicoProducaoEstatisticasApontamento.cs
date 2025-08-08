using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoProducaoEstatisticasApontamento
{
	public int id;

	public DateTime dataInicio;

	public DateTime dataFim;

	public string tipoApontamento;

	public int codigoFuncionario;

	public string nomeFuncionario;

	public int codigoFichaProducao;

	public int codigoProjeto;

	public int codigoOrdemFabricacao;

	public int codigoIdPeca;

	public string nomeProduto;

	public int fase;

	public int tipoRecursoApontado;

	public int codigoRecursoApontado;

	public string nomeRecursoApontado;

	public int codigoParada;

	public string nomeParada;

	public int tipoRecurosProcesso;

	public int codigoRecursoProcesso;

	public string nomeRecursoProcesso;

	public decimal tempoPreparacaoPrevisto;

	public decimal tempoPreparacaoApontado;

	public decimal tempoProducaoPrevisto;

	public decimal tempoProducaoApontado;

	public decimal tempoControlePrevisto;

	public decimal tempoControleApontado;

	public decimal tempoParada;

	public decimal tempoTotalPrevisto;

	public decimal tempoTotalApontado;

	public int pecasHoraProcesso;

	public int pecasHoraApontado;

	public int pecasHoraMedia;

	public int pecasHoraMaximo;

	public int pecasHoraMinimo;

	public int quantidadeProduzida;

	public int quantidadeRuim;

	public int quantidadeBoa;

	public int quantidadeSetup;

	public decimal custoPrevisto;

	public decimal custoRealizado;

	public decimal custoDivergencia;
}
