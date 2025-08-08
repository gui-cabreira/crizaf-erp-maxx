using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalOrigemProduto : BusinessObjectBase
{
	private MapTableNotaFiscalOrigemProduto _dados;

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

	public string OrigemProduto
	{
		get
		{
			return _dados.origemProduto;
		}
		set
		{
			if (_dados.origemProduto != value)
			{
				_dados.origemProduto = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalOrigemProduto);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalOrigemProduto()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalOrigemProduto(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalOrigemProduto)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
