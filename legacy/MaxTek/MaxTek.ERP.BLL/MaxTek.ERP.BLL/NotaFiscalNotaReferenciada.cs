using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalNotaReferenciada : BusinessObjectBase
{
	private MapTableNotaFiscalNotaReferenciada _dados;

	public int CodigoEmpresa
	{
		get
		{
			return _dados.codigoEmpresa;
		}
		set
		{
			if (_dados.codigoEmpresa != value)
			{
				_dados.codigoEmpresa = value;
				PropertyHasChanged("CodigoEmpresa");
			}
		}
	}

	public int NumeroNotaFiscal
	{
		get
		{
			return _dados.numeroNotaFiscal;
		}
		set
		{
			if (_dados.numeroNotaFiscal != value)
			{
				_dados.numeroNotaFiscal = value;
				PropertyHasChanged("NumeroNotaFiscal");
			}
		}
	}

	public int CodigoSerieNF
	{
		get
		{
			return _dados.codigoSerieNF;
		}
		set
		{
			if (_dados.codigoSerieNF != value)
			{
				_dados.codigoSerieNF = value;
				PropertyHasChanged("CodigoSerieNF");
			}
		}
	}

	public string NotaReferenciada
	{
		get
		{
			return _dados.notaReferenciada;
		}
		set
		{
			if (_dados.notaReferenciada != value)
			{
				_dados.notaReferenciada = value;
				PropertyHasChanged("NotaReferenciada");
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalNotaReferenciada);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalNotaReferenciada()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalNotaReferenciada(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalNotaReferenciada)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
