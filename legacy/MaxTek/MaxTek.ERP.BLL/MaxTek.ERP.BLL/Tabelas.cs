using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

public class Tabelas : BusinessObjectBase
{
	private MapTableTabelas _dados;

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

	public string NomeEsquema
	{
		get
		{
			return _dados.nomeEsquema;
		}
		set
		{
			if (_dados.nomeEsquema != value)
			{
				_dados.nomeEsquema = value;
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

	public string NomeBtr
	{
		get
		{
			return _dados.nomeBtr;
		}
		set
		{
			if (_dados.nomeBtr != value)
			{
				_dados.nomeBtr = value;
				PropertyHasChanged();
			}
		}
	}

	internal void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTabelas);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public Tabelas()
	{
		IniciarVariaveis(isNovo: true);
	}

	public Tabelas(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTabelas)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
