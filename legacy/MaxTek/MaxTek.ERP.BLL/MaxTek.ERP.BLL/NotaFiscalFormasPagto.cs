using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalFormasPagto : BusinessObjectBase
{
	private MapTableNotaFiscalFormasPagto _dados;

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

	public string DescricaoFormaPagamento
	{
		get
		{
			return _dados.descricaoFormaPagamento;
		}
		set
		{
			if (_dados.descricaoFormaPagamento != value)
			{
				_dados.descricaoFormaPagamento = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalFormasPagto);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalFormasPagto()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalFormasPagto(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalFormasPagto)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
