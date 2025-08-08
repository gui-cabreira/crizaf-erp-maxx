using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProcessoOperacaoFerramenta : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProcessoOperacaoFerramenta _dados;

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

	public int IdProcessoOperacao
	{
		get
		{
			return _dados.idProcessoOperacao;
		}
		set
		{
			if (_dados.idProcessoOperacao != value)
			{
				_dados.idProcessoOperacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int IdFerramenta
	{
		get
		{
			return _dados.idFerramenta;
		}
		set
		{
			if (_dados.idFerramenta != value)
			{
				_dados.idFerramenta = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoFerramenta
	{
		get
		{
			return _dados.codigoTipoFerramenta;
		}
		set
		{
			if (_dados.codigoTipoFerramenta != value)
			{
				_dados.codigoTipoFerramenta = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal Necessidade
	{
		get
		{
			return _dados.necessidade;
		}
		set
		{
			if (_dados.necessidade != value)
			{
				_dados.necessidade = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProcessoOperacaoFerramenta);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProcessoOperacaoFerramenta()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProcessoOperacaoFerramenta(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProcessoOperacaoFerramenta)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
