using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalNotasFiscaisItensDIAdicoes : BusinessObjectBase
{
	private MapTableNotaFiscalNotasFiscaisItensDIAdicoes _dados;

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

	public int CodigoSerieNotaFiscal
	{
		get
		{
			return _dados.codigoSerieNotaFiscal;
		}
		set
		{
			if (_dados.codigoSerieNotaFiscal != value)
			{
				_dados.codigoSerieNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoNotaFiscal
	{
		get
		{
			return _dados.codigoNotaFiscal;
		}
		set
		{
			if (_dados.codigoNotaFiscal != value)
			{
				_dados.codigoNotaFiscal = value;
				PropertyHasChanged();
			}
		}
	}

	public int Ordem
	{
		get
		{
			return _dados.ordem;
		}
		set
		{
			if (_dados.ordem != value)
			{
				_dados.ordem = value;
				PropertyHasChanged();
			}
		}
	}

	public string NumeroDI
	{
		get
		{
			return _dados.numeroDI;
		}
		set
		{
			if (_dados.numeroDI != value)
			{
				_dados.numeroDI = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroAdicao
	{
		get
		{
			return _dados.numeroAdicao;
		}
		set
		{
			if (_dados.numeroAdicao != value)
			{
				_dados.numeroAdicao = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroSequenciaAdicao
	{
		get
		{
			return _dados.numeroSequenciaAdicao;
		}
		set
		{
			if (_dados.numeroSequenciaAdicao != value)
			{
				_dados.numeroSequenciaAdicao = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoFabricante
	{
		get
		{
			return _dados.codigoFabricante;
		}
		set
		{
			if (_dados.codigoFabricante != value)
			{
				_dados.codigoFabricante = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorDescontoDI
	{
		get
		{
			return _dados.valorDescontoDI;
		}
		set
		{
			if (_dados.valorDescontoDI != value)
			{
				_dados.valorDescontoDI = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoDrawBack
	{
		get
		{
			return _dados.codigoDrawBack;
		}
		set
		{
			if (_dados.codigoDrawBack != value)
			{
				_dados.codigoDrawBack = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalNotasFiscaisItensDIAdicoes);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalNotasFiscaisItensDIAdicoes()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalNotasFiscaisItensDIAdicoes(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalNotasFiscaisItensDIAdicoes)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
