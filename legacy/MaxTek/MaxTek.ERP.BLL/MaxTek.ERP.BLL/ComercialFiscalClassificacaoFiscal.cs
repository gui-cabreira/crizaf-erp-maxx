using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialFiscalClassificacaoFiscal : BusinessObjectBase
{
	private MapTableComercialFiscalClassificacaoFiscal _dados;

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

	public string ClassificacaiFiscal
	{
		get
		{
			return _dados.classificacaiFiscal;
		}
		set
		{
			if (_dados.classificacaiFiscal != value)
			{
				_dados.classificacaiFiscal = value;
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

	public decimal ValorIpi
	{
		get
		{
			return _dados.valorIpi;
		}
		set
		{
			if (_dados.valorIpi != value)
			{
				_dados.valorIpi = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialFiscalClassificacaoFiscal);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialFiscalClassificacaoFiscal()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialFiscalClassificacaoFiscal(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialFiscalClassificacaoFiscal)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
