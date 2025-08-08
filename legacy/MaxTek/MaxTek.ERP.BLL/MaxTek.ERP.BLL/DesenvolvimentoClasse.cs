using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class DesenvolvimentoClasse : BusinessObjectBase
{
	private MapTableDesenvolvimentoClasse _dados;

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

	public string NomeBaseDados
	{
		get
		{
			return _dados.nomeBaseDados;
		}
		set
		{
			if (_dados.nomeBaseDados != value)
			{
				_dados.nomeBaseDados = value;
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

	public int IdEsquema
	{
		get
		{
			return _dados.idEsquema;
		}
		set
		{
			if (_dados.idEsquema != value)
			{
				_dados.idEsquema = value;
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

	public int IdTabela
	{
		get
		{
			return _dados.idTabela;
		}
		set
		{
			if (_dados.idTabela != value)
			{
				_dados.idTabela = value;
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

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableDesenvolvimentoClasse);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public DesenvolvimentoClasse()
	{
		IniciarVariaveis(isNovo: true);
	}

	public DesenvolvimentoClasse(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableDesenvolvimentoClasse)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
