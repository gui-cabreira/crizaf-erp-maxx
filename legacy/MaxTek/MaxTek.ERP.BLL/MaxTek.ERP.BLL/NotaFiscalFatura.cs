using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalFatura : BusinessObjectBase
{
	private MapTableNotaFiscalFatura _dados;

	public int CodigoEmpresa
	{
		get
		{
			if (_dados.codigoEmpresa == 0)
			{
				CodigoEmpresa = 1;
			}
			return _dados.codigoEmpresa;
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

	public string CodigoFatura
	{
		get
		{
			return _dados.codigoFatura;
		}
		set
		{
			if (_dados.codigoFatura != value)
			{
				_dados.codigoFatura = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFatura
	{
		get
		{
			return _dados.valorFatura;
		}
		set
		{
			if (_dados.valorFatura != value)
			{
				_dados.valorFatura = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime Vencimento
	{
		get
		{
			return _dados.vencimento;
		}
		set
		{
			if (_dados.vencimento != value)
			{
				_dados.vencimento = value;
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

	public bool IsNaoGerarTitulo
	{
		get
		{
			return _dados.isNaoGerarTitulo;
		}
		set
		{
			if (_dados.isNaoGerarTitulo != value)
			{
				_dados.isNaoGerarTitulo = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalFatura);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalFatura()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalFatura(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalFatura)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
