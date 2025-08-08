using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalTextosLegais : BusinessObjectBase
{
	private MapTableNotaFiscalTextosLegais _dados;

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

	public string TextoLegal
	{
		get
		{
			return _dados.textoLegal;
		}
		set
		{
			if (_dados.textoLegal != value)
			{
				_dados.textoLegal = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalTextosLegais);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalTextosLegais()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalTextosLegais(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalTextosLegais)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
