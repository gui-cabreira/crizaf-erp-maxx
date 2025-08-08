using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoProducaoEstatisticasApontamento : BusinessObjectBase
{
	private MapTableTecnicoProducaoEstatisticasApontamento _dados;

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

	public DateTime DataInicio
	{
		get
		{
			return _dados.dataInicio;
		}
		set
		{
			if (_dados.dataInicio != value)
			{
				_dados.dataInicio = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataFim
	{
		get
		{
			return _dados.dataFim;
		}
		set
		{
			if (_dados.dataFim != value)
			{
				_dados.dataFim = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoApontamento
	{
		get
		{
			return _dados.tipoApontamento;
		}
		set
		{
			if (_dados.tipoApontamento != value)
			{
				_dados.tipoApontamento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionario
	{
		get
		{
			return _dados.codigoFuncionario;
		}
		set
		{
			if (_dados.codigoFuncionario != value)
			{
				_dados.codigoFuncionario = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeFuncionario
	{
		get
		{
			return _dados.nomeFuncionario;
		}
		set
		{
			if (_dados.nomeFuncionario != value)
			{
				_dados.nomeFuncionario = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFichaProducao
	{
		get
		{
			return _dados.codigoFichaProducao;
		}
		set
		{
			if (_dados.codigoFichaProducao != value)
			{
				_dados.codigoFichaProducao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoProjeto
	{
		get
		{
			return _dados.codigoProjeto;
		}
		set
		{
			if (_dados.codigoProjeto != value)
			{
				_dados.codigoProjeto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoOrdemFabricacao
	{
		get
		{
			return _dados.codigoOrdemFabricacao;
		}
		set
		{
			if (_dados.codigoOrdemFabricacao != value)
			{
				_dados.codigoOrdemFabricacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoIdPeca
	{
		get
		{
			return _dados.codigoIdPeca;
		}
		set
		{
			if (_dados.codigoIdPeca != value)
			{
				_dados.codigoIdPeca = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeProduto
	{
		get
		{
			return _dados.nomeProduto;
		}
		set
		{
			if (_dados.nomeProduto != value)
			{
				_dados.nomeProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public int Fase
	{
		get
		{
			return _dados.fase;
		}
		set
		{
			if (_dados.fase != value)
			{
				_dados.fase = value;
				PropertyHasChanged();
			}
		}
	}

	public int TipoRecursoApontado
	{
		get
		{
			return _dados.tipoRecursoApontado;
		}
		set
		{
			if (_dados.tipoRecursoApontado != value)
			{
				_dados.tipoRecursoApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoRecursoApontado
	{
		get
		{
			return _dados.codigoRecursoApontado;
		}
		set
		{
			if (_dados.codigoRecursoApontado != value)
			{
				_dados.codigoRecursoApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeRecursoApontado
	{
		get
		{
			return _dados.nomeRecursoApontado;
		}
		set
		{
			if (_dados.nomeRecursoApontado != value)
			{
				_dados.nomeRecursoApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoParada
	{
		get
		{
			return _dados.codigoParada;
		}
		set
		{
			if (_dados.codigoParada != value)
			{
				_dados.codigoParada = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeParada
	{
		get
		{
			return _dados.nomeParada;
		}
		set
		{
			if (_dados.nomeParada != value)
			{
				_dados.nomeParada = value;
				PropertyHasChanged();
			}
		}
	}

	public int TipoRecurosProcesso
	{
		get
		{
			return _dados.tipoRecurosProcesso;
		}
		set
		{
			if (_dados.tipoRecurosProcesso != value)
			{
				_dados.tipoRecurosProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoRecursoProcesso
	{
		get
		{
			return _dados.codigoRecursoProcesso;
		}
		set
		{
			if (_dados.codigoRecursoProcesso != value)
			{
				_dados.codigoRecursoProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeRecursoProcesso
	{
		get
		{
			return _dados.nomeRecursoProcesso;
		}
		set
		{
			if (_dados.nomeRecursoProcesso != value)
			{
				_dados.nomeRecursoProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoPreparacaoPrevisto
	{
		get
		{
			return _dados.tempoPreparacaoPrevisto;
		}
		set
		{
			if (_dados.tempoPreparacaoPrevisto != value)
			{
				_dados.tempoPreparacaoPrevisto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoPreparacaoApontado
	{
		get
		{
			return _dados.tempoPreparacaoApontado;
		}
		set
		{
			if (_dados.tempoPreparacaoApontado != value)
			{
				_dados.tempoPreparacaoApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoProducaoPrevisto
	{
		get
		{
			return _dados.tempoProducaoPrevisto;
		}
		set
		{
			if (_dados.tempoProducaoPrevisto != value)
			{
				_dados.tempoProducaoPrevisto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoProducaoApontado
	{
		get
		{
			return _dados.tempoProducaoApontado;
		}
		set
		{
			if (_dados.tempoProducaoApontado != value)
			{
				_dados.tempoProducaoApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoControlePrevisto
	{
		get
		{
			return _dados.tempoControlePrevisto;
		}
		set
		{
			if (_dados.tempoControlePrevisto != value)
			{
				_dados.tempoControlePrevisto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoControleApontado
	{
		get
		{
			return _dados.tempoControleApontado;
		}
		set
		{
			if (_dados.tempoControleApontado != value)
			{
				_dados.tempoControleApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoParada
	{
		get
		{
			return _dados.tempoParada;
		}
		set
		{
			if (_dados.tempoParada != value)
			{
				_dados.tempoParada = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoTotalPrevisto
	{
		get
		{
			return _dados.tempoTotalPrevisto;
		}
		set
		{
			if (_dados.tempoTotalPrevisto != value)
			{
				_dados.tempoTotalPrevisto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoTotalApontado
	{
		get
		{
			return _dados.tempoTotalApontado;
		}
		set
		{
			if (_dados.tempoTotalApontado != value)
			{
				_dados.tempoTotalApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public int PecasHoraProcesso
	{
		get
		{
			return _dados.pecasHoraProcesso;
		}
		set
		{
			if (_dados.pecasHoraProcesso != value)
			{
				_dados.pecasHoraProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public int PecasHoraApontado
	{
		get
		{
			return _dados.pecasHoraApontado;
		}
		set
		{
			if (_dados.pecasHoraApontado != value)
			{
				_dados.pecasHoraApontado = value;
				PropertyHasChanged();
			}
		}
	}

	public int PecasHoraMedia => _dados.pecasHoraMedia;

	public int PecasHoraMaxima => _dados.pecasHoraMaximo;

	public int PecasHoraMinimo => _dados.pecasHoraMinimo;

	public int QuantidadeProduzida
	{
		get
		{
			return _dados.quantidadeProduzida;
		}
		set
		{
			if (_dados.quantidadeProduzida != value)
			{
				_dados.quantidadeProduzida = value;
				PropertyHasChanged();
			}
		}
	}

	public int QuantidadeRuim
	{
		get
		{
			return _dados.quantidadeRuim;
		}
		set
		{
			if (_dados.quantidadeRuim != value)
			{
				_dados.quantidadeRuim = value;
				PropertyHasChanged();
			}
		}
	}

	public int QuantidadeBoa
	{
		get
		{
			return _dados.quantidadeBoa;
		}
		set
		{
			if (_dados.quantidadeBoa != value)
			{
				_dados.quantidadeBoa = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoPrevisto
	{
		get
		{
			return _dados.custoPrevisto;
		}
		set
		{
			if (_dados.custoPrevisto != value)
			{
				_dados.custoPrevisto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoRealizado
	{
		get
		{
			return _dados.custoRealizado;
		}
		set
		{
			if (_dados.custoRealizado != value)
			{
				_dados.custoRealizado = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoDivergencia
	{
		get
		{
			return _dados.custoDivergencia;
		}
		set
		{
			if (_dados.custoDivergencia != value)
			{
				_dados.custoDivergencia = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroSetup => _dados.quantidadeSetup;

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoProducaoEstatisticasApontamento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoProducaoEstatisticasApontamento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoProducaoEstatisticasApontamento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoProducaoEstatisticasApontamento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
