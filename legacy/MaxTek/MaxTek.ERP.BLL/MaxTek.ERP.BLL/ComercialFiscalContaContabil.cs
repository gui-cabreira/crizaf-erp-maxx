using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialFiscalContaContabil : BusinessObjectBase
{
	private MapTableComercialFiscalContaContabil _dados;

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

	public string Descricao
	{
		get
		{
			return _dados.descricao;
		}
		set
		{
			if (_dados.descricao != value)
			{
				_dados.descricao = value;
				PropertyHasChanged();
			}
		}
	}

	public int Classe
	{
		get
		{
			return _dados.classe;
		}
		set
		{
			if (_dados.classe != value)
			{
				_dados.classe = value;
				PropertyHasChanged();
			}
		}
	}

	public int SubClasse
	{
		get
		{
			return _dados.subClasse;
		}
		set
		{
			if (_dados.subClasse != value)
			{
				_dados.subClasse = value;
				PropertyHasChanged();
			}
		}
	}

	public string ContaAnalitica
	{
		get
		{
			return _dados.contaAnalitica;
		}
		set
		{
			if (_dados.contaAnalitica != value)
			{
				_dados.contaAnalitica = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialFiscalContaContabil);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialFiscalContaContabil()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialFiscalContaContabil(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialFiscalContaContabil)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
