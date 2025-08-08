using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoProducaoApontamento : BusinessObjectBase
{
	private MapTableTecnicoProducaoApontamento _dados;

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

	public DateTime Data
	{
		get
		{
			return _dados.data;
		}
		set
		{
			if (_dados.data != value)
			{
				_dados.data = value;
				PropertyHasChanged();
			}
		}
	}

	public int TipoApontamento
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

	public int CodigoOperador
	{
		get
		{
			return _dados.codigoOperador;
		}
		set
		{
			if (_dados.codigoOperador != value)
			{
				_dados.codigoOperador = value;
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

	public int CodigoImprodutivo
	{
		get
		{
			return _dados.codigoImprodutivo;
		}
		set
		{
			if (_dados.codigoImprodutivo != value)
			{
				_dados.codigoImprodutivo = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoPrevistoSetup
	{
		get
		{
			return _dados.tempoPrevistoSetup;
		}
		set
		{
			if (_dados.tempoPrevistoSetup != value)
			{
				_dados.tempoPrevistoSetup = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoPrevistoProducao
	{
		get
		{
			return _dados.tempoPrevistoProducao;
		}
		set
		{
			if (_dados.tempoPrevistoProducao != value)
			{
				_dados.tempoPrevistoProducao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoPrevistoControle
	{
		get
		{
			return _dados.tempoPrevistoControle;
		}
		set
		{
			if (_dados.tempoPrevistoControle != value)
			{
				_dados.tempoPrevistoControle = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoRealizadoSetup
	{
		get
		{
			return _dados.tempoRealizadoSetup;
		}
		set
		{
			if (_dados.tempoRealizadoSetup != value)
			{
				_dados.tempoRealizadoSetup = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoRealizadoProducao
	{
		get
		{
			return _dados.tempoRealizadoProducao;
		}
		set
		{
			if (_dados.tempoRealizadoProducao != value)
			{
				_dados.tempoRealizadoProducao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoRealizadoControle
	{
		get
		{
			return _dados.tempoRealizadoControle;
		}
		set
		{
			if (_dados.tempoRealizadoControle != value)
			{
				_dados.tempoRealizadoControle = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal TempoRealizadoImprodutivo
	{
		get
		{
			return _dados.tempoRealizadoImprodutivo;
		}
		set
		{
			if (_dados.tempoRealizadoImprodutivo != value)
			{
				_dados.tempoRealizadoImprodutivo = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeTerminada
	{
		get
		{
			return _dados.quantidadeTerminada;
		}
		set
		{
			if (_dados.quantidadeTerminada != value)
			{
				_dados.quantidadeTerminada = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal QuantidadeRuim
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

	public decimal QuantidadeBoa
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

	public int IdProdutoOf
	{
		get
		{
			return _dados.idProdutoOf;
		}
		set
		{
			if (_dados.idProdutoOf != value)
			{
				_dados.idProdutoOf = value;
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

	public int CodigoTipoProduto
	{
		get
		{
			return _dados.codigoTipoProduto;
		}
		set
		{
			if (_dados.codigoTipoProduto != value)
			{
				_dados.codigoTipoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PotencialRecurso
	{
		get
		{
			return _dados.potencialRecurso;
		}
		set
		{
			if (_dados.potencialRecurso != value)
			{
				_dados.potencialRecurso = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoHoraSetup
	{
		get
		{
			return _dados.custoHoraSetup;
		}
		set
		{
			if (_dados.custoHoraSetup != value)
			{
				_dados.custoHoraSetup = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoHoraProducao
	{
		get
		{
			return _dados.custoHoraProducao;
		}
		set
		{
			if (_dados.custoHoraProducao != value)
			{
				_dados.custoHoraProducao = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoHoraControle
	{
		get
		{
			return _dados.custoHoraControle;
		}
		set
		{
			if (_dados.custoHoraControle != value)
			{
				_dados.custoHoraControle = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CustoHoraOperador
	{
		get
		{
			return _dados.custoHoraOperador;
		}
		set
		{
			if (_dados.custoHoraOperador != value)
			{
				_dados.custoHoraOperador = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoProducaoApontamento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoProducaoApontamento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoProducaoApontamento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoProducaoApontamento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
