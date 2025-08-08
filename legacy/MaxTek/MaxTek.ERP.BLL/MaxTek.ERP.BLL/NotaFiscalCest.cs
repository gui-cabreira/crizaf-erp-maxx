using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalCest : BusinessObjectBase
{
	private MapTableNotaFiscalCest _dados;

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

	public string CodigoCest
	{
		get
		{
			return _dados.codigoCest;
		}
		set
		{
			if (_dados.codigoCest != value)
			{
				_dados.codigoCest = value;
				PropertyHasChanged();
			}
		}
	}

	public string Ncm
	{
		get
		{
			return _dados.ncm;
		}
		set
		{
			if (_dados.ncm != value)
			{
				_dados.ncm = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEstado
	{
		get
		{
			return _dados.codigoEstado;
		}
		set
		{
			if (_dados.codigoEstado != value)
			{
				_dados.codigoEstado = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorMva
	{
		get
		{
			return _dados.valorMva;
		}
		set
		{
			if (_dados.valorMva != value)
			{
				_dados.valorMva = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualIcmsSt
	{
		get
		{
			return _dados.percentualIcmsSt;
		}
		set
		{
			if (_dados.percentualIcmsSt != value)
			{
				_dados.percentualIcmsSt = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal PercentualReducaoBaseCalculoICMSST
	{
		get
		{
			return _dados.percentualReducaoBaseCalculoICMSST;
		}
		set
		{
			if (_dados.percentualReducaoBaseCalculoICMSST != value)
			{
				_dados.percentualReducaoBaseCalculoICMSST = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalCest);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalCest()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalCest(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalCest)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
