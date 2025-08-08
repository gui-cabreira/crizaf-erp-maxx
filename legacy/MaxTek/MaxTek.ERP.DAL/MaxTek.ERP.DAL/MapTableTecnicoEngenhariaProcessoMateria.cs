using System;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcessoMateria
{
	public int id;

	public int idProcesso;

	public int idProcessoOperacao;

	public int idMateriaPrima;

	public string nomeMateriaPrima;

	public int codigoTipoMateriaPrima;

	public decimal dimensao01;

	public decimal dimensao02;

	public decimal dimensao03;

	public int valorQuantidadeNecessaria;

	public decimal valorTamanhoNecessidade;

	public bool isLoteada;

	public decimal percentualPerda;

	public int indiceMateria;

	public string posicaoDesenho;
}
