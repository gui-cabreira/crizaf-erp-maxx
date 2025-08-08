using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalTipoIncidenciaIPI : BusinessObjectBase
{
	private MapTableNotaFiscalTipoIncidenciaIPI _dados;

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

	public string CodigoIncidencia
	{
		get
		{
			return _dados.codigoIncidencia;
		}
		set
		{
			if (_dados.codigoIncidencia != value)
			{
				_dados.codigoIncidencia = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoInicidencia
	{
		get
		{
			return _dados.descricaoInicidencia;
		}
		set
		{
			if (_dados.descricaoInicidencia != value)
			{
				_dados.descricaoInicidencia = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalTipoIncidenciaIPI);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalTipoIncidenciaIPI()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalTipoIncidenciaIPI(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalTipoIncidenciaIPI)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
