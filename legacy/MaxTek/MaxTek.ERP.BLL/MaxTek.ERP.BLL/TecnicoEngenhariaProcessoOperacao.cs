using System;
using System.Collections.Generic;
using System.Drawing;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProcessoOperacao : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProcessoOperacao _dados;

	private IList<TecnicoEngenhariaProcessoOperacaoFerramenta> _ferramentas;

	private IList<TecnicoEngenhariaProcessoOperacaoRevisao> _revisoes;

	private bool _ckFerramentas;

	private bool _ckRevisoes;

	public int Id
	{
		get
		{
			return _dados.id;
		}
		set
		{
			if (_dados.id != value)
			{
				_dados.id = value;
				PropertyHasChanged();
			}
		}
	}

	public int RevisaoOperacao
	{
		get
		{
			return _dados.revisaoOperacao;
		}
		set
		{
			if (_dados.revisaoOperacao != value)
			{
				_dados.revisaoOperacao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataCriacao
	{
		get
		{
			return _dados.dataCriacao;
		}
		set
		{
			if (_dados.dataCriacao != value)
			{
				_dados.dataCriacao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataAtualizacao
	{
		get
		{
			return _dados.dataAtualizacao;
		}
		set
		{
			if (_dados.dataAtualizacao != value)
			{
				_dados.dataAtualizacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionarioCriador
	{
		get
		{
			return _dados.codigoFuncionarioCriador;
		}
		set
		{
			if (_dados.codigoFuncionarioCriador != value)
			{
				_dados.codigoFuncionarioCriador = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoFuncionarioAtualizacao
	{
		get
		{
			return _dados.codigoFuncionarioAtualizacao;
		}
		set
		{
			if (_dados.codigoFuncionarioAtualizacao != value)
			{
				_dados.codigoFuncionarioAtualizacao = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsAprovado
	{
		get
		{
			return _dados.isAprovado;
		}
		set
		{
			if (_dados.isAprovado != value)
			{
				_dados.isAprovado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionarioAprovacao
	{
		get
		{
			return _dados.codigoFuncionarioAprovacao;
		}
		set
		{
			if (_dados.codigoFuncionarioAprovacao != value)
			{
				_dados.codigoFuncionarioAprovacao = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeUsuarioConectado
	{
		get
		{
			return _dados.nomeUsuarioConectado;
		}
		set
		{
			if (_dados.nomeUsuarioConectado != value)
			{
				_dados.nomeUsuarioConectado = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeUsuarioConectadoAprovacao
	{
		get
		{
			return _dados.nomeUsuarioConectadoAprovacao;
		}
		set
		{
			if (_dados.nomeUsuarioConectadoAprovacao != value)
			{
				_dados.nomeUsuarioConectadoAprovacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int IdProcesso
	{
		get
		{
			return _dados.idProcesso;
		}
		set
		{
			if (_dados.idProcesso != value)
			{
				_dados.idProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoProcesso
	{
		get
		{
			return _dados.codigoTipoProcesso;
		}
		set
		{
			if (_dados.codigoTipoProcesso != value)
			{
				_dados.codigoTipoProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoRecurso
	{
		get
		{
			return _dados.codigoTipoRecurso;
		}
		set
		{
			if (_dados.codigoTipoRecurso != value)
			{
				_dados.codigoTipoRecurso = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoRecurso
	{
		get
		{
			return _dados.codigoRecurso;
		}
		set
		{
			if (_dados.codigoRecurso != value)
			{
				_dados.codigoRecurso = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoSetUp
	{
		get
		{
			return _dados.tempoSetUp;
		}
		set
		{
			if (_dados.tempoSetUp != value)
			{
				_dados.tempoSetUp = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoProducao
	{
		get
		{
			return _dados.tempoProducao;
		}
		set
		{
			if (_dados.tempoProducao != value)
			{
				_dados.tempoProducao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoControle
	{
		get
		{
			return _dados.tempoControle;
		}
		set
		{
			if (_dados.tempoControle != value)
			{
				_dados.tempoControle = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoTransito
	{
		get
		{
			return _dados.tempoTransito;
		}
		set
		{
			if (_dados.tempoTransito != value)
			{
				_dados.tempoTransito = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidadeTempo
	{
		get
		{
			return _dados.codigoUnidadeTempo;
		}
		set
		{
			if (_dados.codigoUnidadeTempo != value)
			{
				_dados.codigoUnidadeTempo = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorRendimentoMinimo
	{
		get
		{
			return _dados.valorRendimentoMinimo;
		}
		set
		{
			if (_dados.valorRendimentoMinimo != value)
			{
				_dados.valorRendimentoMinimo = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorRendimentoMaximo
	{
		get
		{
			return _dados.valorRendimentoMaximo;
		}
		set
		{
			if (_dados.valorRendimentoMaximo != value)
			{
				_dados.valorRendimentoMaximo = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeOperador
	{
		get
		{
			return _dados.quantidadeOperador;
		}
		set
		{
			if (_dados.quantidadeOperador != value)
			{
				_dados.quantidadeOperador = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoOperador
	{
		get
		{
			return _dados.codigoTipoOperador;
		}
		set
		{
			if (_dados.codigoTipoOperador != value)
			{
				_dados.codigoTipoOperador = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoSubContratacao
	{
		get
		{
			return _dados.codigoTipoSubContratacao;
		}
		set
		{
			if (_dados.codigoTipoSubContratacao != value)
			{
				_dados.codigoTipoSubContratacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEntidadeSubContratada
	{
		get
		{
			return _dados.codigoEntidadeSubContratada;
		}
		set
		{
			if (_dados.codigoEntidadeSubContratada != value)
			{
				_dados.codigoEntidadeSubContratada = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoSubContratacao
	{
		get
		{
			return _dados.tempoSubContratacao;
		}
		set
		{
			if (_dados.tempoSubContratacao != value)
			{
				_dados.tempoSubContratacao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTeorico
	{
		get
		{
			return _dados.valorTeorico;
		}
		set
		{
			if (_dados.valorTeorico != value)
			{
				_dados.valorTeorico = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorNecessidade
	{
		get
		{
			return _dados.valorNecessidade;
		}
		set
		{
			if (_dados.valorNecessidade != value)
			{
				_dados.valorNecessidade = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoUnidadeSubContratacao
	{
		get
		{
			return _dados.codigoUnidadeSubContratacao;
		}
		set
		{
			if (_dados.codigoUnidadeSubContratacao != value)
			{
				_dados.codigoUnidadeSubContratacao = value;
				PropertyHasChanged();
			}
		}
	}

	public Image Imagem
	{
		get
		{
			return _dados.imagem;
		}
		set
		{
			if (_dados.imagem != value)
			{
				_dados.imagem = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica01Recurso01
	{
		get
		{
			return _dados.nomeInformacaoEspecifica01Recurso01;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica01Recurso01 != value)
			{
				_dados.nomeInformacaoEspecifica01Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica01Recurso01
	{
		get
		{
			return _dados.valorInformacaoEspecifica01Recurso01;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica01Recurso01 != value)
			{
				_dados.valorInformacaoEspecifica01Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica02Recurso01
	{
		get
		{
			return _dados.nomeInformacaoEspecifica02Recurso01;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica02Recurso01 != value)
			{
				_dados.nomeInformacaoEspecifica02Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica02Recurso01
	{
		get
		{
			return _dados.valorInformacaoEspecifica02Recurso01;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica02Recurso01 != value)
			{
				_dados.valorInformacaoEspecifica02Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica03Recurso01
	{
		get
		{
			return _dados.nomeInformacaoEspecifica03Recurso01;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica03Recurso01 != value)
			{
				_dados.nomeInformacaoEspecifica03Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica03Recurso01
	{
		get
		{
			return _dados.valorInformacaoEspecifica03Recurso01;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica03Recurso01 != value)
			{
				_dados.valorInformacaoEspecifica03Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica04Recurso01
	{
		get
		{
			return _dados.nomeInformacaoEspecifica04Recurso01;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica04Recurso01 != value)
			{
				_dados.nomeInformacaoEspecifica04Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica04Recurso01
	{
		get
		{
			return _dados.valorInformacaoEspecifica04Recurso01;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica04Recurso01 != value)
			{
				_dados.valorInformacaoEspecifica04Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica05Recurso01
	{
		get
		{
			return _dados.nomeInformacaoEspecifica05Recurso01;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica05Recurso01 != value)
			{
				_dados.nomeInformacaoEspecifica05Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica05Recurso01
	{
		get
		{
			return _dados.valorInformacaoEspecifica05Recurso01;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica05Recurso01 != value)
			{
				_dados.valorInformacaoEspecifica05Recurso01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica01Recurso02
	{
		get
		{
			return _dados.nomeInformacaoEspecifica01Recurso02;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica01Recurso02 != value)
			{
				_dados.nomeInformacaoEspecifica01Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica01Recurso02
	{
		get
		{
			return _dados.valorInformacaoEspecifica01Recurso02;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica01Recurso02 != value)
			{
				_dados.valorInformacaoEspecifica01Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica02Recurso02
	{
		get
		{
			return _dados.nomeInformacaoEspecifica02Recurso02;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica02Recurso02 != value)
			{
				_dados.nomeInformacaoEspecifica02Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica02Recurso02
	{
		get
		{
			return _dados.valorInformacaoEspecifica02Recurso02;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica02Recurso02 != value)
			{
				_dados.valorInformacaoEspecifica02Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica03Recurso02
	{
		get
		{
			return _dados.nomeInformacaoEspecifica03Recurso02;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica03Recurso02 != value)
			{
				_dados.nomeInformacaoEspecifica03Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica03Recurso02
	{
		get
		{
			return _dados.valorInformacaoEspecifica03Recurso02;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica03Recurso02 != value)
			{
				_dados.valorInformacaoEspecifica03Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica04Recurso02
	{
		get
		{
			return _dados.nomeInformacaoEspecifica04Recurso02;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica04Recurso02 != value)
			{
				_dados.nomeInformacaoEspecifica04Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica04Recurso02
	{
		get
		{
			return _dados.valorInformacaoEspecifica04Recurso02;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica04Recurso02 != value)
			{
				_dados.valorInformacaoEspecifica04Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica05Recurso02
	{
		get
		{
			return _dados.nomeInformacaoEspecifica05Recurso02;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica05Recurso02 != value)
			{
				_dados.nomeInformacaoEspecifica05Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica05Recurso02
	{
		get
		{
			return _dados.valorInformacaoEspecifica05Recurso02;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica05Recurso02 != value)
			{
				_dados.valorInformacaoEspecifica05Recurso02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica01Recurso03
	{
		get
		{
			return _dados.nomeInformacaoEspecifica01Recurso03;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica01Recurso03 != value)
			{
				_dados.nomeInformacaoEspecifica01Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica01Recurso03
	{
		get
		{
			return _dados.valorInformacaoEspecifica01Recurso03;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica01Recurso03 != value)
			{
				_dados.valorInformacaoEspecifica01Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica02Recurso03
	{
		get
		{
			return _dados.nomeInformacaoEspecifica02Recurso03;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica02Recurso03 != value)
			{
				_dados.nomeInformacaoEspecifica02Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica02Recurso03
	{
		get
		{
			return _dados.valorInformacaoEspecifica02Recurso03;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica02Recurso03 != value)
			{
				_dados.valorInformacaoEspecifica02Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica03Recurso03
	{
		get
		{
			return _dados.nomeInformacaoEspecifica03Recurso03;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica03Recurso03 != value)
			{
				_dados.nomeInformacaoEspecifica03Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica03Recurso03
	{
		get
		{
			return _dados.valorInformacaoEspecifica03Recurso03;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica03Recurso03 != value)
			{
				_dados.valorInformacaoEspecifica03Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica04Recurso03
	{
		get
		{
			return _dados.nomeInformacaoEspecifica04Recurso03;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica04Recurso03 != value)
			{
				_dados.nomeInformacaoEspecifica04Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica04Recurso03
	{
		get
		{
			return _dados.valorInformacaoEspecifica04Recurso03;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica04Recurso03 != value)
			{
				_dados.valorInformacaoEspecifica04Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoEspecifica05Recurso03
	{
		get
		{
			return _dados.nomeInformacaoEspecifica05Recurso03;
		}
		set
		{
			if (_dados.nomeInformacaoEspecifica05Recurso03 != value)
			{
				_dados.nomeInformacaoEspecifica05Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoEspecifica05Recurso03
	{
		get
		{
			return _dados.valorInformacaoEspecifica05Recurso03;
		}
		set
		{
			if (_dados.valorInformacaoEspecifica05Recurso03 != value)
			{
				_dados.valorInformacaoEspecifica05Recurso03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoAdicional01
	{
		get
		{
			return _dados.nomeInformacaoAdicional01;
		}
		set
		{
			if (_dados.nomeInformacaoAdicional01 != value)
			{
				_dados.nomeInformacaoAdicional01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoAdicional01
	{
		get
		{
			return _dados.valorInformacaoAdicional01;
		}
		set
		{
			if (_dados.valorInformacaoAdicional01 != value)
			{
				_dados.valorInformacaoAdicional01 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoAdicional02
	{
		get
		{
			return _dados.nomeInformacaoAdicional02;
		}
		set
		{
			if (_dados.nomeInformacaoAdicional02 != value)
			{
				_dados.nomeInformacaoAdicional02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoAdicional02
	{
		get
		{
			return _dados.valorInformacaoAdicional02;
		}
		set
		{
			if (_dados.valorInformacaoAdicional02 != value)
			{
				_dados.valorInformacaoAdicional02 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoAdicional03
	{
		get
		{
			return _dados.nomeInformacaoAdicional03;
		}
		set
		{
			if (_dados.nomeInformacaoAdicional03 != value)
			{
				_dados.nomeInformacaoAdicional03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoAdicional03
	{
		get
		{
			return _dados.valorInformacaoAdicional03;
		}
		set
		{
			if (_dados.valorInformacaoAdicional03 != value)
			{
				_dados.valorInformacaoAdicional03 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoAdicional04
	{
		get
		{
			return _dados.nomeInformacaoAdicional04;
		}
		set
		{
			if (_dados.nomeInformacaoAdicional04 != value)
			{
				_dados.nomeInformacaoAdicional04 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoAdicional04
	{
		get
		{
			return _dados.valorInformacaoAdicional04;
		}
		set
		{
			if (_dados.valorInformacaoAdicional04 != value)
			{
				_dados.valorInformacaoAdicional04 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoAdicional05
	{
		get
		{
			return _dados.nomeInformacaoAdicional05;
		}
		set
		{
			if (_dados.nomeInformacaoAdicional05 != value)
			{
				_dados.nomeInformacaoAdicional05 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoAdicional05
	{
		get
		{
			return _dados.valorInformacaoAdicional05;
		}
		set
		{
			if (_dados.valorInformacaoAdicional05 != value)
			{
				_dados.valorInformacaoAdicional05 = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeInformacaoAdicional06
	{
		get
		{
			return _dados.nomeInformacaoAdicional06;
		}
		set
		{
			if (_dados.nomeInformacaoAdicional06 != value)
			{
				_dados.nomeInformacaoAdicional06 = value;
				PropertyHasChanged();
			}
		}
	}

	public string ValorInformacaoAdicional06
	{
		get
		{
			return _dados.valorInformacaoAdicional06;
		}
		set
		{
			if (_dados.valorInformacaoAdicional06 != value)
			{
				_dados.valorInformacaoAdicional06 = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoSequenciaTrabalho
	{
		get
		{
			return _dados.descricaoSequenciaTrabalho;
		}
		set
		{
			if (_dados.descricaoSequenciaTrabalho != value)
			{
				_dados.descricaoSequenciaTrabalho = value;
				PropertyHasChanged();
			}
		}
	}

	public string Observacoes
	{
		get
		{
			return _dados.observacoes;
		}
		set
		{
			if (_dados.observacoes != value)
			{
				_dados.observacoes = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI01
	{
		get
		{
			return _dados.codigoEPI01;
		}
		set
		{
			if (_dados.codigoEPI01 != value)
			{
				_dados.codigoEPI01 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI02
	{
		get
		{
			return _dados.codigoEPI02;
		}
		set
		{
			if (_dados.codigoEPI02 != value)
			{
				_dados.codigoEPI02 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI03
	{
		get
		{
			return _dados.codigoEPI03;
		}
		set
		{
			if (_dados.codigoEPI03 != value)
			{
				_dados.codigoEPI03 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI04
	{
		get
		{
			return _dados.codigoEPI04;
		}
		set
		{
			if (_dados.codigoEPI04 != value)
			{
				_dados.codigoEPI04 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI05
	{
		get
		{
			return _dados.codigoEPI05;
		}
		set
		{
			if (_dados.codigoEPI05 != value)
			{
				_dados.codigoEPI05 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI06
	{
		get
		{
			return _dados.codigoEPI06;
		}
		set
		{
			if (_dados.codigoEPI06 != value)
			{
				_dados.codigoEPI06 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI07
	{
		get
		{
			return _dados.codigoEPI07;
		}
		set
		{
			if (_dados.codigoEPI07 != value)
			{
				_dados.codigoEPI07 = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEPI08
	{
		get
		{
			return _dados.codigoEPI08;
		}
		set
		{
			if (_dados.codigoEPI08 != value)
			{
				_dados.codigoEPI08 = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<TecnicoEngenhariaProcessoOperacaoFerramenta> Ferramentas
	{
		get
		{
			if (!_ckFerramentas && _ferramentas == null)
			{
				_ferramentas = ModuloTecnicoEngenhariaProcesso.ObterTodosTecnicoEngenhariaProcessoOperacaoFerramenta(_dados.id);
				_ckFerramentas = true;
			}
			return _ferramentas;
		}
		set
		{
			if (_ferramentas != value)
			{
				_ferramentas = value;
				RevisaoOperacao++;
			}
		}
	}

	public IList<TecnicoEngenhariaProcessoOperacaoRevisao> Revisoes
	{
		get
		{
			if (!_ckRevisoes && _revisoes == null)
			{
				_revisoes = ModuloTecnicoEngenhariaProcesso.ObterTodosTecnicoEngenhariaProcessoOperacaoRevisao(_dados.id);
			}
			return _revisoes;
		}
		set
		{
			if (_revisoes != value)
			{
				_revisoes = value;
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProcessoOperacao);
		_ferramentas = null;
		_revisoes = null;
		_ckFerramentas = false;
		_ckRevisoes = false;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProcessoOperacao()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProcessoOperacao(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProcessoOperacao)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
