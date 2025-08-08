using System;
using System.Drawing;

namespace MaxTek.ERP.DAL;

[Serializable]
public struct MapTableTecnicoEngenhariaProcessoOperacao
{
	public int id;

	public int revisaoOperacao;

	public DateTime dataCriacao;

	public DateTime dataAtualizacao;

	public int codigoFuncionarioCriador;

	public string codigoFuncionarioAtualizacao;

	public bool isAprovado;

	public int codigoFuncionarioAprovacao;

	public string nomeUsuarioConectado;

	public string nomeUsuarioConectadoAprovacao;

	public int idProcesso;

	public int codigoTipoProcesso;

	public int codigoTipoRecurso;

	public int codigoRecurso;

	public decimal tempoSetUp;

	public decimal tempoProducao;

	public decimal tempoControle;

	public decimal tempoTransito;

	public int codigoUnidadeTempo;

	public decimal valorRendimentoMinimo;

	public decimal valorRendimentoMaximo;

	public decimal quantidadeOperador;

	public int codigoTipoOperador;

	public int codigoTipoSubContratacao;

	public int codigoEntidadeSubContratada;

	public decimal tempoSubContratacao;

	public decimal valorTeorico;

	public decimal valorNecessidade;

	public int codigoUnidadeSubContratacao;

	public Image imagem;

	public string nomeInformacaoEspecifica01Recurso01;

	public string valorInformacaoEspecifica01Recurso01;

	public string nomeInformacaoEspecifica02Recurso01;

	public string valorInformacaoEspecifica02Recurso01;

	public string nomeInformacaoEspecifica03Recurso01;

	public string valorInformacaoEspecifica03Recurso01;

	public string nomeInformacaoEspecifica04Recurso01;

	public string valorInformacaoEspecifica04Recurso01;

	public string nomeInformacaoEspecifica05Recurso01;

	public string valorInformacaoEspecifica05Recurso01;

	public string nomeInformacaoEspecifica01Recurso02;

	public string valorInformacaoEspecifica01Recurso02;

	public string nomeInformacaoEspecifica02Recurso02;

	public string valorInformacaoEspecifica02Recurso02;

	public string nomeInformacaoEspecifica03Recurso02;

	public string valorInformacaoEspecifica03Recurso02;

	public string nomeInformacaoEspecifica04Recurso02;

	public string valorInformacaoEspecifica04Recurso02;

	public string nomeInformacaoEspecifica05Recurso02;

	public string valorInformacaoEspecifica05Recurso02;

	public string nomeInformacaoEspecifica01Recurso03;

	public string valorInformacaoEspecifica01Recurso03;

	public string nomeInformacaoEspecifica02Recurso03;

	public string valorInformacaoEspecifica02Recurso03;

	public string nomeInformacaoEspecifica03Recurso03;

	public string valorInformacaoEspecifica03Recurso03;

	public string nomeInformacaoEspecifica04Recurso03;

	public string valorInformacaoEspecifica04Recurso03;

	public string nomeInformacaoEspecifica05Recurso03;

	public string valorInformacaoEspecifica05Recurso03;

	public string nomeInformacaoAdicional01;

	public string valorInformacaoAdicional01;

	public string nomeInformacaoAdicional02;

	public string valorInformacaoAdicional02;

	public string nomeInformacaoAdicional03;

	public string valorInformacaoAdicional03;

	public string nomeInformacaoAdicional04;

	public string valorInformacaoAdicional04;

	public string nomeInformacaoAdicional05;

	public string valorInformacaoAdicional05;

	public string nomeInformacaoAdicional06;

	public string valorInformacaoAdicional06;

	public string descricaoSequenciaTrabalho;

	public string observacoes;

	public int codigoEPI01;

	public int codigoEPI02;

	public int codigoEPI03;

	public int codigoEPI04;

	public int codigoEPI05;

	public int codigoEPI06;

	public int codigoEPI07;

	public int codigoEPI08;
}
