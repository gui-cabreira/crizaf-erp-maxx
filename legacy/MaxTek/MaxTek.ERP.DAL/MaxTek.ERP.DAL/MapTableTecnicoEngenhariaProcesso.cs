using System;
using System.Drawing;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcesso
{
	public int id;

	public bool isAtivo;

	public int codigoTipoProcesso;

	public string codigoProcesso;

	public int codigoProcessoRevisao;

	public string codigoDesenho;

	public string codigoDesenhoRevisao;

	public DateTime dataDesenho;

	public int codigoFamilia;

	public int codigoSubFamilia;

	public Image imagem;

	public DateTime dataCriacao;

	public DateTime dataAtualizacao;

	public int codigoFuncionarioCriacao;

	public int codigoFuncionarioModificacao;

	public int codigoFuncionarioAprovacao;

	public DateTime dataAprovacao;

	public bool isAprovado;

	public bool isPpap;

	public DateTime dataAprocacaoPpap;

	public int codigoPpap;

	public string nomeCliente;

	public string nomeUsuárioConectado;

	public string comentario;
}
