using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProcessoMateria : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProcessoMateria _dados;

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

	public int IdProcessoOperacao
	{
		get
		{
			return _dados.idProcessoOperacao;
		}
		set
		{
			if (_dados.idProcessoOperacao != value)
			{
				_dados.idProcessoOperacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int IdMateriaPrima
	{
		get
		{
			return _dados.idMateriaPrima;
		}
		set
		{
			if (_dados.idMateriaPrima != value)
			{
				_dados.idMateriaPrima = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeMateriaPrima
	{
		get
		{
			return _dados.nomeMateriaPrima;
		}
		set
		{
			if (_dados.nomeMateriaPrima != value)
			{
				_dados.nomeMateriaPrima = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoMateriaPrima
	{
		get
		{
			return _dados.codigoTipoMateriaPrima;
		}
		set
		{
			if (_dados.codigoTipoMateriaPrima != value)
			{
				_dados.codigoTipoMateriaPrima = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao01
	{
		get
		{
			return _dados.dimensao01;
		}
		set
		{
			if (_dados.dimensao01 != value)
			{
				_dados.dimensao01 = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao02
	{
		get
		{
			return _dados.dimensao02;
		}
		set
		{
			if (_dados.dimensao02 != value)
			{
				_dados.dimensao02 = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Dimensao03
	{
		get
		{
			return _dados.dimensao03;
		}
		set
		{
			if (_dados.dimensao03 != value)
			{
				_dados.dimensao03 = value;
				PropertyHasChanged();
			}
		}
	}

	public int ValorQuantidadeNecessaria
	{
		get
		{
			return _dados.valorQuantidadeNecessaria;
		}
		set
		{
			if (_dados.valorQuantidadeNecessaria != value)
			{
				_dados.valorQuantidadeNecessaria = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTamanhoNecessidade
	{
		get
		{
			return _dados.valorTamanhoNecessidade;
		}
		set
		{
			if (_dados.valorTamanhoNecessidade != value)
			{
				_dados.valorTamanhoNecessidade = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsLoteada
	{
		get
		{
			return _dados.isLoteada;
		}
		set
		{
			if (_dados.isLoteada != value)
			{
				_dados.isLoteada = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualPerda
	{
		get
		{
			return _dados.percentualPerda;
		}
		set
		{
			if (_dados.percentualPerda != value)
			{
				_dados.percentualPerda = value;
				PropertyHasChanged();
			}
		}
	}

	public int IndiceMateria
	{
		get
		{
			return _dados.indiceMateria;
		}
		set
		{
			if (_dados.indiceMateria != value)
			{
				_dados.indiceMateria = value;
				PropertyHasChanged();
			}
		}
	}

	public string PosicaoDesenho
	{
		get
		{
			return _dados.posicaoDesenho;
		}
		set
		{
			if (_dados.posicaoDesenho != value)
			{
				_dados.posicaoDesenho = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProcessoMateria);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProcessoMateria()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProcessoMateria(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProcessoMateria)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
