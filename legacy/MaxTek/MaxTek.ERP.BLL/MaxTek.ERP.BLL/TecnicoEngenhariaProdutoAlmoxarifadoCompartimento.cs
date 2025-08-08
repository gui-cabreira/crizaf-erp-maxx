using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProdutoAlmoxarifadoCompartimento : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento _dados;

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

	public int CodigoAlmoxarifado
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

	public string Compartimento
	{
		get
		{
			return _dados.compartimento;
		}
		set
		{
			if (_dados.compartimento != value)
			{
				_dados.compartimento = value;
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

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProdutoAlmoxarifadoCompartimento()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProdutoAlmoxarifadoCompartimento(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProdutoAlmoxarifadoCompartimento)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
