using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalResumoFaturamento : BusinessObjectBase
{
	private MapTableNotaFiscalResumoFaturamento _dados;

	public int Ano
	{
		get
		{
			return _dados.ano;
		}
		set
		{
			if (_dados.ano != value)
			{
				_dados.ano = value;
				PropertyHasChanged();
			}
		}
	}

	public int Mes
	{
		get
		{
			return _dados.mes;
		}
		set
		{
			if (_dados.mes != value)
			{
				_dados.mes = value;
				PropertyHasChanged();
			}
		}
	}

	public string ContaContabil
	{
		get
		{
			return _dados.contaContabil;
		}
		set
		{
			if (_dados.contaContabil != value)
			{
				_dados.contaContabil = value;
				PropertyHasChanged();
			}
		}
	}

	public string Cfop
	{
		get
		{
			return _dados.cfop;
		}
		set
		{
			if (_dados.cfop != value)
			{
				_dados.cfop = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEntidade
	{
		get
		{
			return _dados.codigoEntidade;
		}
		set
		{
			if (_dados.codigoEntidade != value)
			{
				_dados.codigoEntidade = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorTotal
	{
		get
		{
			return _dados.valorTotal;
		}
		set
		{
			if (_dados.valorTotal != value)
			{
				_dados.valorTotal = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorBaseICMS
	{
		get
		{
			return _dados.valorBaseICMS;
		}
		set
		{
			if (_dados.valorBaseICMS != value)
			{
				_dados.valorBaseICMS = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIcms
	{
		get
		{
			return _dados.valorIcms;
		}
		set
		{
			if (_dados.valorIcms != value)
			{
				_dados.valorIcms = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorIpi
	{
		get
		{
			return _dados.valorIpi;
		}
		set
		{
			if (_dados.valorIpi != value)
			{
				_dados.valorIpi = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorPis
	{
		get
		{
			return _dados.valorPis;
		}
		set
		{
			if (_dados.valorPis != value)
			{
				_dados.valorPis = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCofins
	{
		get
		{
			return _dados.valorCofins;
		}
		set
		{
			if (_dados.valorCofins != value)
			{
				_dados.valorCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFrete
	{
		get
		{
			return _dados.valorFrete;
		}
		set
		{
			if (_dados.valorFrete != value)
			{
				_dados.valorFrete = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorSeguro
	{
		get
		{
			return _dados.valorSeguro;
		}
		set
		{
			if (_dados.valorSeguro != value)
			{
				_dados.valorSeguro = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorFatura
	{
		get
		{
			return _dados.valorFatura;
		}
		set
		{
			if (_dados.valorFatura != value)
			{
				_dados.valorFatura = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorRetencaoPis
	{
		get
		{
			return _dados.valorRetencaoPis;
		}
		set
		{
			if (_dados.valorRetencaoPis != value)
			{
				_dados.valorRetencaoPis = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorRetencaoCofins
	{
		get
		{
			return _dados.valorRetencaoCofins;
		}
		set
		{
			if (_dados.valorRetencaoCofins != value)
			{
				_dados.valorRetencaoCofins = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCsll
	{
		get
		{
			return _dados.valorCsll;
		}
		set
		{
			if (_dados.valorCsll != value)
			{
				_dados.valorCsll = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalResumoFaturamento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalResumoFaturamento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalResumoFaturamento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalResumoFaturamento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
