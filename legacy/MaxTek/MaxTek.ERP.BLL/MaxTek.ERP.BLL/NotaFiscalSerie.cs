using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalSerie : BusinessObjectBase
{
	private MapTableNotaFiscalSerie _dados;

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

	public int CodigoEmpresa
	{
		get
		{
			return (_dados.codigoEmpresa == 0) ? 1 : _dados.codigoEmpresa;
		}
		set
		{
			if (_dados.codigoEmpresa != value)
			{
				_dados.codigoEmpresa = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSerie
	{
		get
		{
			return _dados.codigoSerie;
		}
		set
		{
			if (_dados.codigoSerie != value)
			{
				_dados.codigoSerie = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeSerie
	{
		get
		{
			return _dados.nomeSerie;
		}
		set
		{
			if (_dados.nomeSerie != value)
			{
				_dados.nomeSerie = value;
				PropertyHasChanged();
			}
		}
	}

	public int ProximoNumero
	{
		get
		{
			return _dados.proximoNumero;
		}
		set
		{
			if (_dados.proximoNumero != value)
			{
				_dados.proximoNumero = value;
				PropertyHasChanged();
			}
		}
	}

	public int Indice
	{
		get
		{
			return _dados.indice;
		}
		set
		{
			if (_dados.indice != value)
			{
				_dados.indice = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalSerie);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalSerie()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalSerie(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalSerie)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
