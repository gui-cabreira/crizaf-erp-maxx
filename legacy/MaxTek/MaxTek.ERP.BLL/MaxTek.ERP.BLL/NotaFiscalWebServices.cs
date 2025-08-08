using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalWebServices : BusinessObjectBase
{
	private MapTableNotaFiscalWebServices _dados;

	public string Uf
	{
		get
		{
			return _dados.uf;
		}
		set
		{
			if (_dados.uf != value)
			{
				_dados.uf = value;
				PropertyHasChanged();
			}
		}
	}

	public string Ambiente
	{
		get
		{
			return _dados.ambiente;
		}
		set
		{
			if (_dados.ambiente != value)
			{
				_dados.ambiente = value;
				PropertyHasChanged();
			}
		}
	}

	public string Servico
	{
		get
		{
			return _dados.servico;
		}
		set
		{
			if (_dados.servico != value)
			{
				_dados.servico = value;
				PropertyHasChanged();
			}
		}
	}

	public string Webservice
	{
		get
		{
			return _dados.webservice;
		}
		set
		{
			if (_dados.webservice != value)
			{
				_dados.webservice = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalWebServices);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalWebServices()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalWebServices(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalWebServices)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
