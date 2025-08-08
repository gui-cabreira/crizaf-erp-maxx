using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProdutoAlmoxarifado : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProdutoAlmoxarifado _dados;

	private IList<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento> _compartimentos;

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

	public string CodigoAlmoxarifado
	{
		get
		{
			return _dados.codigoAlmoxarifado;
		}
		set
		{
			if (_dados.codigoAlmoxarifado != value)
			{
				_dados.codigoAlmoxarifado = value;
				PropertyHasChanged();
			}
		}
	}

	public string Descricao
	{
		get
		{
			return _dados.descricao;
		}
		set
		{
			if (_dados.descricao != value)
			{
				_dados.descricao = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<TecnicoEngenhariaProdutoAlmoxarifadoCompartimento> Compartimentos
	{
		get
		{
			if (_compartimentos == null)
			{
				_compartimentos = ModuloTecnicoEngenhariaProduto.ObterTodosTecnicoEngenhariaProdutoAlmoxarifadoCompartimento(_dados.id);
			}
			return _compartimentos;
		}
		set
		{
			if (_compartimentos != value)
			{
				_compartimentos = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProdutoAlmoxarifado);
		_compartimentos = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProdutoAlmoxarifado()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProdutoAlmoxarifado(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProdutoAlmoxarifado)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
