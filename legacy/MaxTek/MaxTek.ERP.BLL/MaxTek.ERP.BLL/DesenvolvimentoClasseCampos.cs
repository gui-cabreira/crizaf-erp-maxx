using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class DesenvolvimentoClasseCampos : BusinessObjectBase
{
	private MapTableDesenvolvimentoClasseCampos _dados;

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

	public int IdClasse
	{
		get
		{
			return _dados.idClasse;
		}
		set
		{
			if (_dados.idClasse != value)
			{
				_dados.idClasse = value;
				PropertyHasChanged();
			}
		}
	}

	public int IdCampo
	{
		get
		{
			return _dados.idCampo;
		}
		set
		{
			if (_dados.idCampo != value)
			{
				_dados.idCampo = value;
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

	public string NomeCampoPervasive
	{
		get
		{
			return _dados.nomeCampoPervasive;
		}
		set
		{
			if (_dados.nomeCampoPervasive != value)
			{
				_dados.nomeCampoPervasive = value;
				PropertyHasChanged();
			}
		}
	}

	public int IdTipoDado
	{
		get
		{
			return _dados.idTipoDado;
		}
		set
		{
			if (_dados.idTipoDado != value)
			{
				_dados.idTipoDado = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeTipoDado
	{
		get
		{
			return _dados.nomeTipoDado;
		}
		set
		{
			if (_dados.nomeTipoDado != value)
			{
				_dados.nomeTipoDado = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroCasas
	{
		get
		{
			return _dados.numeroCasas;
		}
		set
		{
			if (_dados.numeroCasas != value)
			{
				_dados.numeroCasas = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeTipoCampo
	{
		get
		{
			return _dados.nomeTipoCampo;
		}
		set
		{
			if (_dados.nomeTipoCampo != value)
			{
				_dados.nomeTipoCampo = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeCampoClasse
	{
		get
		{
			return _dados.nomeCampoClasse;
		}
		set
		{
			if (_dados.nomeCampoClasse != value)
			{
				_dados.nomeCampoClasse = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomePropriedade
	{
		get
		{
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

	public bool IsPk
	{
		get
		{
			return _dados.isPk;
		}
		set
		{
			if (_dados.isPk != value)
			{
				_dados.isPk = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableDesenvolvimentoClasseCampos);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public DesenvolvimentoClasseCampos()
	{
		IniciarVariaveis(isNovo: true);
	}

	public DesenvolvimentoClasseCampos(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableDesenvolvimentoClasseCampos)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
