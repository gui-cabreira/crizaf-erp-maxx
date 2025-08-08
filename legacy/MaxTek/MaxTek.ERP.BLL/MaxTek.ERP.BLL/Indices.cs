using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

public class Indices : BusinessObjectBase
{
	private MapTableIndices _dados;

	public int Object_id
	{
		get
		{
			return _dados.object_id;
		}
		set
		{
			if (_dados.object_id != value)
			{
				_dados.object_id = value;
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

	public int Column_id
	{
		get
		{
			return _dados.column_id;
		}
		set
		{
			if (_dados.column_id != value)
			{
				_dados.column_id = value;
				PropertyHasChanged();
			}
		}
	}

	public int Key_ordinal
	{
		get
		{
			return _dados.key_ordinal;
		}
		set
		{
			if (_dados.key_ordinal != value)
			{
				_dados.key_ordinal = value;
				PropertyHasChanged();
			}
		}
	}

	public int Index_column_id
	{
		get
		{
			return _dados.index_column_id;
		}
		set
		{
			if (_dados.index_column_id != value)
			{
				_dados.index_column_id = value;
				PropertyHasChanged();
			}
		}
	}

	public string Coluna
	{
		get
		{
			return _dados.coluna;
		}
		set
		{
			if (_dados.coluna != value)
			{
				_dados.coluna = value;
				PropertyHasChanged();
			}
		}
	}

	public string Tipo
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

	internal void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableIndices);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public Indices()
	{
		IniciarVariaveis(isNovo: true);
	}

	public Indices(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableIndices)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
