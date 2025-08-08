using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class QualidadeEmbarqueControlado : BusinessObjectBase
{
	private MapTableQualidadeEmbarqueControlado _dados;

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

	public string CodigoProduto
	{
		get
		{
			return _dados.codigoProduto;
		}
		set
		{
			if (_dados.codigoProduto != value)
			{
				_dados.codigoProduto = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoProdutoCliente
	{
		get
		{
			return _dados.codigoProdutoCliente;
		}
		set
		{
			if (_dados.codigoProdutoCliente != value)
			{
				_dados.codigoProdutoCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataInicioEmbarqueControlado
	{
		get
		{
			return _dados.dataInicioEmbarqueControlado;
		}
		set
		{
			if (_dados.dataInicioEmbarqueControlado != value)
			{
				_dados.dataInicioEmbarqueControlado = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataPrevisaoTerminoEmbarqueControlado
	{
		get
		{
			return _dados.dataPrevisaoTerminoEmbarqueControlado;
		}
		set
		{
			if (_dados.dataPrevisaoTerminoEmbarqueControlado != value)
			{
				_dados.dataPrevisaoTerminoEmbarqueControlado = value;
				PropertyHasChanged();
			}
		}
	}

	public int NivelEmbarqueControlado
	{
		get
		{
			return _dados.nivelEmbarqueControlado;
		}
		set
		{
			if (_dados.nivelEmbarqueControlado != value)
			{
				_dados.nivelEmbarqueControlado = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoDefeito
	{
		get
		{
			return _dados.descricaoDefeito;
		}
		set
		{
			if (_dados.descricaoDefeito != value)
			{
				_dados.descricaoDefeito = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsFechado
	{
		get
		{
			return _dados.isFechado;
		}
		set
		{
			if (_dados.isFechado != value)
			{
				_dados.isFechado = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableQualidadeEmbarqueControlado);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public QualidadeEmbarqueControlado()
	{
		IniciarVariaveis(isNovo: true);
	}

	public QualidadeEmbarqueControlado(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableQualidadeEmbarqueControlado)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
