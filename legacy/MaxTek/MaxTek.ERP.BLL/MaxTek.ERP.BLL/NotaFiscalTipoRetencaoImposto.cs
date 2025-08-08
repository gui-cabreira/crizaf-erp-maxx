using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalTipoRetencaoImposto : BusinessObjectBase
{
	private MapTableNotaFiscalTipoRetencaoImposto _dados;

	public int CodigoRetencao
	{
		get
		{
			return _dados.codigoRetencao;
		}
		set
		{
			if (_dados.codigoRetencao != value)
			{
				_dados.codigoRetencao = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoRetencao
	{
		get
		{
			return _dados.descricaoRetencao;
		}
		set
		{
			if (_dados.descricaoRetencao != value)
			{
				_dados.descricaoRetencao = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalTipoRetencaoImposto);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalTipoRetencaoImposto()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalTipoRetencaoImposto(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalTipoRetencaoImposto)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
