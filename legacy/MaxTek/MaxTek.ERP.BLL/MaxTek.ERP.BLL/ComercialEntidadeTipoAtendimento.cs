using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialEntidadeTipoAtendimento : BusinessObjectBase
{
	private MapTableComercialEntidadeTipoAtendimento _dados;

	public int Codigo
	{
		get
		{
			return _dados.codigo;
		}
		set
		{
			if (_dados.codigo != value)
			{
				_dados.codigo = value;
				PropertyHasChanged();
			}
		}
	}

	public string TipoAtendimento
	{
		get
		{
			return _dados.tipoAtendimento;
		}
		set
		{
			if (_dados.tipoAtendimento != value)
			{
				_dados.tipoAtendimento = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialEntidadeTipoAtendimento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialEntidadeTipoAtendimento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialEntidadeTipoAtendimento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialEntidadeTipoAtendimento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
