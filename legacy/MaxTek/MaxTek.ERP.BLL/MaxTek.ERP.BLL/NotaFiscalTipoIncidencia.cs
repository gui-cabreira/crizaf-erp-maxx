using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalTipoIncidencia : BusinessObjectBase
{
	private MapTableNotaFiscalTipoIncidencia _dados;

	public int CodigoTipoIncidencia
	{
		get
		{
			return _dados.codigoTipoIncidencia;
		}
		set
		{
			if (_dados.codigoTipoIncidencia != value)
			{
				_dados.codigoTipoIncidencia = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoIncidencia
	{
		get
		{
			return _dados.tipoIncidencia;
		}
		set
		{
			if (_dados.tipoIncidencia != value)
			{
				_dados.tipoIncidencia = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoIncidencia
	{
		get
		{
			return _dados.descricaoIncidencia;
		}
		set
		{
			if (_dados.descricaoIncidencia != value)
			{
				_dados.descricaoIncidencia = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalTipoIncidencia);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalTipoIncidencia()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalTipoIncidencia(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalTipoIncidencia)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
