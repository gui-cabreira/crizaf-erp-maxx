using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoProducaoApontamento
{
	public int id;

	public DateTime data;

	public int tipoApontamento;

	public int codigoOperador;

	public int codigoRecurso;

	public int codigoImprodutivo;

	public decimal tempoPrevistoSetup;

	public decimal tempoPrevistoProducao;

	public decimal tempoPrevistoControle;

	public decimal tempoRealizadoSetup;

	public decimal tempoRealizadoProducao;

	public decimal tempoRealizadoControle;

	public decimal tempoRealizadoImprodutivo;

	public decimal quantidadeTerminada;

	public decimal quantidadeRuim;

	public decimal quantidadeBoa;

	public int codigoFichaProducao;

	public int codigoProjeto;

	public int codigoOrdemFabricacao;

	public string nomeProduto;

	public int idProdutoOf;

	public int fase;

	public int codigoTipoProduto;

	public decimal potencialRecurso;

	public decimal custoHoraSetup;

	public decimal custoHoraProducao;

	public decimal custoHoraControle;

	public decimal custoHoraOperador;
}
