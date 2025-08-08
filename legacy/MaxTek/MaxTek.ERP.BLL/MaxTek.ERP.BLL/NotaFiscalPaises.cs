using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalPaises : BusinessObjectBase
{
	private MapTableNotaFiscalPaises _dados;

	public string Pais
	{
		get
		{
			return _dados.pais;
		}
		set
		{
			if (_dados.pais != value)
			{
				_dados.pais = value;
				PropertyHasChanged();
			}
		}
	}

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

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalPaises);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalPaises()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalPaises(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalPaises)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
