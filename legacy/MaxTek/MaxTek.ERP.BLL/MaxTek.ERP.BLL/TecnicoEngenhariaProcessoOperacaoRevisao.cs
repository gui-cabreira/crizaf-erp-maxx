using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProcessoOperacaoRevisao : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProcessoOperacaoRevisao _dados;

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

	public int Revisao
	{
		get
		{
			return _dados.revisao;
		}
		set
		{
			if (_dados.revisao != value)
			{
				_dados.revisao = value;
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

	public DateTime Data
	{
		get
		{
			return _dados.data;
		}
		set
		{
			if (_dados.data != value)
			{
				_dados.data = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionarioRevisor
	{
		get
		{
			return _dados.codigoFuncionarioRevisor;
		}
		set
		{
			if (_dados.codigoFuncionarioRevisor != value)
			{
				_dados.codigoFuncionarioRevisor = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeUsuarioConectado
	{
		get
		{
			return _dados.nomeUsuarioConectado;
		}
		set
		{
			if (_dados.nomeUsuarioConectado != value)
			{
				_dados.nomeUsuarioConectado = value;
				PropertyHasChanged();
			}
		}
	}

	public string SqlUtilizado
	{
		get
		{
			return _dados.sqlUtilizado;
		}
		set
		{
			if (_dados.sqlUtilizado != value)
			{
				_dados.sqlUtilizado = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProcessoOperacaoRevisao);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProcessoOperacaoRevisao()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProcessoOperacaoRevisao(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProcessoOperacaoRevisao)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
