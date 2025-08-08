using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialFinanceiroCondicaoPagamento : BusinessObjectBase
{
	private MapTableComercialFinanceiroCondicaoPagamento _dados;

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

	public string Nome
	{
		get
		{
			return _dados.nome;
		}
		set
		{
			if (_dados.nome != value)
			{
				_dados.nome = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroDiasPrimeiraParcela
	{
		get
		{
			return _dados.numeroDiasPrimeiraParcela;
		}
		set
		{
			if (_dados.numeroDiasPrimeiraParcela != value)
			{
				_dados.numeroDiasPrimeiraParcela = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroDiasDemaisParcelas
	{
		get
		{
			return _dados.numeroDiasDemaisParcelas;
		}
		set
		{
			if (_dados.numeroDiasDemaisParcelas != value)
			{
				_dados.numeroDiasDemaisParcelas = value;
				PropertyHasChanged();
			}
		}
	}

	public int NumeroParcelas
	{
		get
		{
			return _dados.numeroParcelas;
		}
		set
		{
			if (_dados.numeroParcelas != value)
			{
				_dados.numeroParcelas = value;
				PropertyHasChanged();
			}
		}
	}

	public bool CalculoManualData
	{
		get
		{
			return _dados.calculoManualData;
		}
		set
		{
			if (_dados.calculoManualData != value)
			{
				_dados.calculoManualData = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialFinanceiroCondicaoPagamento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialFinanceiroCondicaoPagamento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialFinanceiroCondicaoPagamento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialFinanceiroCondicaoPagamento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
