using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalNotasFiscaisItensDI : BusinessObjectBase
{
	private MapTableNotaFiscalNotasFiscaisItensDI _dados;

	private IList<NotaFiscalNotasFiscaisItensDIAdicoes> _notaFiscalNotasFiscaisItensDIAdicoes;

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

	public DateTime DatasDI
	{
		get
		{
			return _dados.datasDI;
		}
		set
		{
			if (_dados.datasDI != value)
			{
				_dados.datasDI = value;
				PropertyHasChanged();
			}
		}
	}

	public string LocalDesembarque
	{
		get
		{
			return _dados.localDesembarque;
		}
		set
		{
			if (_dados.localDesembarque != value)
			{
				_dados.localDesembarque = value;
				PropertyHasChanged();
			}
		}
	}

	public string UfDesembarque
	{
		get
		{
			return _dados.ufDesembarque;
		}
		set
		{
			if (_dados.ufDesembarque != value)
			{
				_dados.ufDesembarque = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataDesembarque
	{
		get
		{
			return _dados.dataDesembarque;
		}
		set
		{
			if (_dados.dataDesembarque != value)
			{
				_dados.dataDesembarque = value;
				PropertyHasChanged();
			}
		}
	}

	public int TipoViaTransporte
	{
		get
		{
			return _dados.tipoViaTransporte;
		}
		set
		{
			if (_dados.tipoViaTransporte != value)
			{
				_dados.tipoViaTransporte = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Vafrmm
	{
		get
		{
			return _dados.vafrmm;
		}
		set
		{
			if (_dados.vafrmm != value)
			{
				_dados.vafrmm = value;
				PropertyHasChanged();
			}
		}
	}

	public int TipoIntermedio
	{
		get
		{
			return _dados.tipoIntermedio;
		}
		set
		{
			if (_dados.tipoIntermedio != value)
			{
				_dados.tipoIntermedio = value;
				PropertyHasChanged();
			}
		}
	}

	public string Cnpja
	{
		get
		{
			return _dados.cnpja;
		}
		set
		{
			if (_dados.cnpja != value)
			{
				_dados.cnpja = value;
				PropertyHasChanged();
			}
		}
	}

	public string UfTerceiro
	{
		get
		{
			return _dados.ufTerceiro;
		}
		set
		{
			if (_dados.ufTerceiro != value)
			{
				_dados.ufTerceiro = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoExportador
	{
		get
		{
			return _dados.codigoExportador;
		}
		set
		{
			if (_dados.codigoExportador != value)
			{
				_dados.codigoExportador = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<NotaFiscalNotasFiscaisItensDIAdicoes> NotaFiscalNotasFiscaisItensDIAdicoes
	{
		get
		{
			if (_notaFiscalNotasFiscaisItensDIAdicoes == null)
			{
				_notaFiscalNotasFiscaisItensDIAdicoes = ModuloNotaFiscal.ObterTodosNotaFiscalNotasFiscaisItensDIAdicoes(CodigoEmpresa, CodigoSerieNotaFiscal, CodigoNotaFiscal, Ordem, NumeroDI);
			}
			return _notaFiscalNotasFiscaisItensDIAdicoes;
		}
		set
		{
			if (_notaFiscalNotasFiscaisItensDIAdicoes != value)
			{
				_notaFiscalNotasFiscaisItensDIAdicoes = value;
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalNotasFiscaisItensDI);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalNotasFiscaisItensDI()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalNotasFiscaisItensDI(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalNotasFiscaisItensDI)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
