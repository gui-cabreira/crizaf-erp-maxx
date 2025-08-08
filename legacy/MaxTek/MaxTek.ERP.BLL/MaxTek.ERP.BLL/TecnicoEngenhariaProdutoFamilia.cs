using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProdutoFamilia : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProdutoFamilia _dados;

	private IList<TecnicoEngenhariaProdutoSubfamilia> _subFamilia;

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

	public string Familia
	{
		get
		{
			return _dados.familia;
		}
		set
		{
			if (_dados.familia != value)
			{
				_dados.familia = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<TecnicoEngenhariaProdutoSubfamilia> SubFamilia
	{
		get
		{
			if (_subFamilia == null)
			{
				_subFamilia = ModuloTecnicoEngenhariaProduto.ObterTodosTecnicoEngenhariaProdutoSubfamilia(_dados.id);
			}
			return _subFamilia;
		}
		set
		{
			if (_subFamilia != value)
			{
				_subFamilia = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProdutoFamilia);
		_subFamilia = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProdutoFamilia()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProdutoFamilia(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProdutoFamilia)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
