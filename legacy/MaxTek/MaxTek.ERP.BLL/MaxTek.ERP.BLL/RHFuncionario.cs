using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class RHFuncionario : BusinessObjectBase
{
	private MapTableRHFuncionario _dados;

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

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableRHFuncionario);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public RHFuncionario()
	{
		IniciarVariaveis(isNovo: true);
	}

	public RHFuncionario(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableRHFuncionario)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
