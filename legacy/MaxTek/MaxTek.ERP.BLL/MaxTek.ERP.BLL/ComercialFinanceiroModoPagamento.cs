using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialFinanceiroModoPagamento : BusinessObjectBase
{
	private MapTableComercialFinanceiroModoPagamento _dados;

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

	public string Sigla
	{
		get
		{
			return _dados.sigla;
		}
		set
		{
			if (_dados.sigla != value)
			{
				_dados.sigla = value;
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

	public bool GerarBoleto
	{
		get
		{
			return _dados.gerarBoleto;
		}
		set
		{
			if (_dados.gerarBoleto != value)
			{
				_dados.gerarBoleto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoContaContabil
	{
		get
		{
			return _dados.codigoContaContabil;
		}
		set
		{
			if (_dados.codigoContaContabil != value)
			{
				_dados.codigoContaContabil = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialFinanceiroModoPagamento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialFinanceiroModoPagamento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialFinanceiroModoPagamento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialFinanceiroModoPagamento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
