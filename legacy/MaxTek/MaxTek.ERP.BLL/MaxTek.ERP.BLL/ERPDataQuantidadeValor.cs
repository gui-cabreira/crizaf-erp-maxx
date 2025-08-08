using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ERPDataQuantidadeValor : BusinessObjectBase
{
	private MapTableDataQuantidadeValor _dados;

	public DateTime Data
	{
		get
		{
			return _dados.data;
		}
		set
		{
			if (_dados.data != value)
			{
				_dados.data = value;
			}
		}
	}

	public int Quantidade
	{
		get
		{
			return (int)_dados.quantidade;
		}
		set
		{
			if (_dados.quantidade != (decimal)value)
			{
				_dados.quantidade = value;
			}
		}
	}

	public decimal Valor
	{
		get
		{
			return _dados.valor;
		}
		set
		{
			if (_dados.valor != value)
			{
				_dados.valor = value;
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableDataQuantidadeValor);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ERPDataQuantidadeValor()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ERPDataQuantidadeValor(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableDataQuantidadeValor)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
