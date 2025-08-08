using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

public class Classe : BusinessObjectBase
{
	private MapTableClasse _dados;

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

	public string BancoDados
	{
		get
		{
			return _dados.bancoDados;
		}
		set
		{
			if (_dados.bancoDados != value)
			{
				_dados.bancoDados = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeClasse
	{
		get
		{
			return _dados.nomeClasse;
		}
		set
		{
			if (_dados.nomeClasse != value)
			{
				_dados.nomeClasse = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeEsquema
	{
		get
		{
			return _dados.nomeEsquema;
		}
		set
		{
			if (_dados.nomeEsquema != value)
			{
				_dados.nomeEsquema = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeTabela
	{
		get
		{
			return _dados.nomeTabela;
		}
		set
		{
			if (_dados.nomeTabela != value)
			{
				_dados.nomeTabela = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeTabelaPervasive
	{
		get
		{
			return _dados.nomeTabelaPervasive;
		}
		set
		{
			if (_dados.nomeTabelaPervasive != value)
			{
				_dados.nomeTabelaPervasive = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeCampoDados
	{
		get
		{
			return _dados.nomeCampoDados;
		}
		set
		{
			if (_dados.nomeCampoDados != value)
			{
				_dados.nomeCampoDados = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeCampoDadosPervasive
	{
		get
		{
			return _dados.nomeCampoDadosPervasive;
		}
		set
		{
			if (_dados.nomeCampoDadosPervasive != value)
			{
				_dados.nomeCampoDadosPervasive = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoDadoBanco
	{
		get
		{
			return _dados.tipoDadoBanco;
		}
		set
		{
			if (_dados.tipoDadoBanco != value)
			{
				_dados.tipoDadoBanco = value;
				PropertyHasChanged();
			}
		}
	}

	public int QuantidadeCaracteres
	{
		get
		{
			return _dados.quantidadeCaracteres;
		}
		set
		{
			if (_dados.quantidadeCaracteres != value)
			{
				_dados.quantidadeCaracteres = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoDado
	{
		get
		{
			return _dados.tipoDado;
		}
		set
		{
			if (_dados.tipoDado != value)
			{
				_dados.tipoDado = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeCampo
	{
		get
		{
			return _dados.nomeCampo;
		}
		set
		{
			if (_dados.nomeCampo != value)
			{
				_dados.nomeCampo = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomePropriedade
	{
		get
		{
			if (NomeCampo.Length > 0 && _dados.nomePropriedade.Length == 0)
			{
				_dados.nomePropriedade = NomeCampo.Substring(0, 1).ToUpper() + NomeCampo.Substring(1, NomeCampo.Length - 1);
			}
			return _dados.nomePropriedade;
		}
		set
		{
			if (_dados.nomePropriedade != value)
			{
				_dados.nomePropriedade = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsChavePrimaria
	{
		get
		{
			return _dados.isChavePrimaria;
		}
		set
		{
			if (_dados.isChavePrimaria != value)
			{
				_dados.isChavePrimaria = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsDesconsidera
	{
		get
		{
			return _dados.isDesconsidera;
		}
		set
		{
			if (_dados.isDesconsidera != value)
			{
				_dados.isDesconsidera = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroChaveUnica
	{
		get
		{
			return _dados.numeroChaveUnica;
		}
		set
		{
			if (_dados.numeroChaveUnica != value)
			{
				_dados.numeroChaveUnica = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroChaveEstrangeira
	{
		get
		{
			return _dados.numeroChaveEstrangeira;
		}
		set
		{
			if (_dados.numeroChaveEstrangeira != value)
			{
				_dados.numeroChaveEstrangeira = value;
				PropertyHasChanged();
			}
		}
	}

	internal void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableClasse);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public Classe()
	{
		IniciarVariaveis(isNovo: true);
	}

	public Classe(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableClasse)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
