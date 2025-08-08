using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

public class ListaIndices : BusinessObjectBase
{
	private MapTableListaIndices _dados;

	private IList<Indices> _indices;

	public string NomeSchema
	{
		get
		{
			return _dados.nomeSchema;
		}
		set
		{
			if (_dados.nomeSchema != value)
			{
				_dados.nomeSchema = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeTabela
	{
		get
		{
			return _dados.nomeTabela;
		}
		set
		{
			if (_dados.nomeTabela != value)
			{
				_dados.nomeTabela = value;
				PropertyHasChanged();
			}
		}
	}

	public int IdTabela
	{
		get
		{
			return _dados.idTabela;
		}
		set
		{
			if (_dados.idTabela != value)
			{
				_dados.idTabela = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeIndex
	{
		get
		{
			return _dados.nomeIndex;
		}
		set
		{
			if (_dados.nomeIndex != value)
			{
				_dados.nomeIndex = value;
				PropertyHasChanged();
			}
		}
	}

	public int Index_id
	{
		get
		{
			return _dados.index_id;
		}
		set
		{
			if (_dados.index_id != value)
			{
				_dados.index_id = value;
				PropertyHasChanged();
			}
		}
	}

	public int Tipo
	{
		get
		{
			return _dados.tipo;
		}
		set
		{
			if (_dados.tipo != value)
			{
				_dados.tipo = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsUnico
	{
		get
		{
			return _dados.isUnico;
		}
		set
		{
			if (_dados.isUnico != value)
			{
				_dados.isUnico = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsPrimarykey
	{
		get
		{
			return _dados.isPk;
		}
		set
		{
			if (_dados.isPk != value)
			{
				_dados.isPk = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<Indices> Indices
	{
		get
		{
			if (_indices == null)
			{
				_indices = ModuloSistema.ObterIndices(_dados.idTabela, _dados.index_id);
			}
			return _indices;
		}
	}

	internal void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableListaIndices);
		_indices = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ListaIndices()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ListaIndices(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableListaIndices)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
