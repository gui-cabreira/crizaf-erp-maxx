using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProdutoSubfamilia : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProdutoSubfamilia _dados;

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

	public int CodigoFamilia
	{
		get
		{
			return _dados.codigoFamilia;
		}
		set
		{
			if (_dados.codigoFamilia != value)
			{
				_dados.codigoFamilia = value;
				PropertyHasChanged();
			}
		}
	}

	public string Subfamilia
	{
		get
		{
			return _dados.subfamilia;
		}
		set
		{
			if (_dados.subfamilia != value)
			{
				_dados.subfamilia = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProdutoSubfamilia);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProdutoSubfamilia()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProdutoSubfamilia(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProdutoSubfamilia)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
