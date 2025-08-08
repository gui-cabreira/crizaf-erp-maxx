using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProdutoUnidade : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProdutoUnidade _dados;

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

	public string Unidade
	{
		get
		{
			return _dados.unidade;
		}
		set
		{
			if (_dados.unidade != value)
			{
				_dados.unidade = value;
				PropertyHasChanged();
			}
		}
	}

	public enumUnidade Grupo
	{
		get
		{
			return (enumUnidade)_dados.grupo;
		}
		set
		{
			if (_dados.grupo != (int)value)
			{
				_dados.grupo = (int)value;
				PropertyHasChanged();
			}
		}
	}

	public decimal CoeficienteGrupo
	{
		get
		{
			return _dados.coeficienteGrupo;
		}
		set
		{
			if (_dados.coeficienteGrupo != value)
			{
				_dados.coeficienteGrupo = value;
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

	public int CodigoGPS
	{
		get
		{
			return _dados.codigoGPS;
		}
		set
		{
			if (_dados.codigoGPS != value)
			{
				_dados.codigoGPS = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProdutoUnidade);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProdutoUnidade()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProdutoUnidade(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProdutoUnidade)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
