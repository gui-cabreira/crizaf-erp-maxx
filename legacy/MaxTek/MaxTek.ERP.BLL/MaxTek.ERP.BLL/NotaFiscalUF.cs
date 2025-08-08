using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalUF : BusinessObjectBase
{
	private MapTableNotaFiscalUF _dados;

	private IList<NotaFiscalCidades> _cidades;

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

	public string SiglaUF
	{
		get
		{
			return _dados.siglaUF;
		}
		set
		{
			if (_dados.siglaUF != value)
			{
				_dados.siglaUF = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeUF
	{
		get
		{
			return _dados.nomeUF;
		}
		set
		{
			if (_dados.nomeUF != value)
			{
				_dados.nomeUF = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Icms
	{
		get
		{
			return _dados.icms;
		}
		set
		{
			if (_dados.icms != value)
			{
				_dados.icms = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<NotaFiscalCidades> Cidades
	{
		get
		{
			if (_cidades == null)
			{
				_cidades = ModuloNotaFiscal.ObterNotaFiscalCidadesEstado(_dados.id);
			}
			return _cidades;
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalUF);
		_cidades = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalUF()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalUF(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalUF)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
