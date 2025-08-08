using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalModalidadeBaseCalculo : BusinessObjectBase
{
	private MapTableNotaFiscalModalidadeBaseCalculo _dados;

	public int CodigoModalidade
	{
		get
		{
			return _dados.codigoModalidade;
		}
		set
		{
			if (_dados.codigoModalidade != value)
			{
				_dados.codigoModalidade = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoModalidade
	{
		get
		{
			return _dados.descricaoModalidade;
		}
		set
		{
			if (_dados.descricaoModalidade != value)
			{
				_dados.descricaoModalidade = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalModalidadeBaseCalculo);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalModalidadeBaseCalculo()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalModalidadeBaseCalculo(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalModalidadeBaseCalculo)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
