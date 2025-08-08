using System;
using System.Collections.Generic;
using System.Drawing;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProcesso : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProcesso _dados;

	private IList<TecnicoEngenhariaProcessoMateria> _materias;

	private IList<TecnicoEngenhariaProcessoRevisao> _revisoes;

	private IList<TecnicoEngenhariaProcessoOperacao> _operacoes;

	private bool _ckMateria;

	private bool _ckRevisoes;

	private bool _ckOperacoes;

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

	public bool IsAtivo
	{
		get
		{
			return _dados.isAtivo;
		}
		set
		{
			if (_dados.isAtivo != value)
			{
				_dados.isAtivo = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoTipoProcesso
	{
		get
		{
			return _dados.codigoTipoProcesso;
		}
		set
		{
			if (_dados.codigoTipoProcesso != value)
			{
				_dados.codigoTipoProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoProcesso
	{
		get
		{
			return _dados.codigoProcesso;
		}
		set
		{
			if (_dados.codigoProcesso != value)
			{
				_dados.codigoProcesso = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoProcessoRevisao
	{
		get
		{
			return _dados.codigoProcessoRevisao;
		}
		set
		{
			if (_dados.codigoProcessoRevisao != value)
			{
				_dados.codigoProcessoRevisao = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoDesenho
	{
		get
		{
			return _dados.codigoDesenho;
		}
		set
		{
			if (_dados.codigoDesenho != value)
			{
				_dados.codigoDesenho = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoDesenhoRevisao
	{
		get
		{
			return _dados.codigoDesenhoRevisao;
		}
		set
		{
			if (_dados.codigoDesenhoRevisao != value)
			{
				_dados.codigoDesenhoRevisao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataDesenho
	{
		get
		{
			return _dados.dataDesenho;
		}
		set
		{
			if (_dados.dataDesenho != value)
			{
				_dados.dataDesenho = value;
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

	public int CodigoSubFamilia
	{
		get
		{
			return _dados.codigoSubFamilia;
		}
		set
		{
			if (_dados.codigoSubFamilia != value)
			{
				_dados.codigoSubFamilia = value;
				PropertyHasChanged();
			}
		}
	}

	public Image Imagem
	{
		get
		{
			return _dados.imagem;
		}
		set
		{
			if (_dados.imagem != value)
			{
				_dados.imagem = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataCriacao
	{
		get
		{
			return _dados.dataCriacao;
		}
		set
		{
			if (_dados.dataCriacao != value)
			{
				_dados.dataCriacao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataAtualizacao
	{
		get
		{
			return _dados.dataAtualizacao;
		}
		set
		{
			if (_dados.dataAtualizacao != value)
			{
				_dados.dataAtualizacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionarioCriacao
	{
		get
		{
			return _dados.codigoFuncionarioCriacao;
		}
		set
		{
			if (_dados.codigoFuncionarioCriacao != value)
			{
				_dados.codigoFuncionarioCriacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionarioModificacao
	{
		get
		{
			return _dados.codigoFuncionarioModificacao;
		}
		set
		{
			if (_dados.codigoFuncionarioModificacao != value)
			{
				_dados.codigoFuncionarioModificacao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionarioAprovacao
	{
		get
		{
			return _dados.codigoFuncionarioAprovacao;
		}
		set
		{
			if (_dados.codigoFuncionarioAprovacao != value)
			{
				_dados.codigoFuncionarioAprovacao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataAprovacao
	{
		get
		{
			return _dados.dataAprovacao;
		}
		set
		{
			if (_dados.dataAprovacao != value)
			{
				_dados.dataAprovacao = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsAprovado
	{
		get
		{
			return _dados.isAprovado;
		}
		set
		{
			if (_dados.isAprovado != value)
			{
				_dados.isAprovado = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsPpap
	{
		get
		{
			return _dados.isPpap;
		}
		set
		{
			if (_dados.isPpap != value)
			{
				_dados.isPpap = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataAprocacaoPpap
	{
		get
		{
			return _dados.dataAprocacaoPpap;
		}
		set
		{
			if (_dados.dataAprocacaoPpap != value)
			{
				_dados.dataAprocacaoPpap = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoPpap
	{
		get
		{
			return _dados.codigoPpap;
		}
		set
		{
			if (_dados.codigoPpap != value)
			{
				_dados.codigoPpap = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeCliente
	{
		get
		{
			return _dados.nomeCliente;
		}
		set
		{
			if (_dados.nomeCliente != value)
			{
				_dados.nomeCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeUsuárioConectado
	{
		get
		{
			return _dados.nomeUsuárioConectado;
		}
		set
		{
			if (_dados.nomeUsuárioConectado != value)
			{
				_dados.nomeUsuárioConectado = value;
				PropertyHasChanged();
			}
		}
	}

	public string Comentario
	{
		get
		{
			return _dados.comentario;
		}
		set
		{
			if (_dados.comentario != value)
			{
				_dados.comentario = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<TecnicoEngenhariaProcessoMateria> Materias
	{
		get
		{
			if (!_ckMateria && _materias == null)
			{
				_materias = ModuloTecnicoEngenhariaProcesso.ObterTodosTecnicoEngenhariaProcessoMateria(_dados.id);
				_ckMateria = true;
			}
			return _materias;
		}
		set
		{
			if (_materias != value)
			{
				_materias = value;
				CodigoProcessoRevisao++;
			}
		}
	}

	public IList<TecnicoEngenhariaProcessoRevisao> Revisoes
	{
		get
		{
			if (!_ckRevisoes && _revisoes == null)
			{
				_revisoes = ModuloTecnicoEngenhariaProcesso.ObterTodosTecnicoEngenhariaProcessoRevisao(_dados.id);
				_ckRevisoes = true;
			}
			return _revisoes;
		}
		set
		{
			if (_revisoes != value)
			{
				_revisoes = value;
			}
		}
	}

	public IList<TecnicoEngenhariaProcessoOperacao> Operacoes
	{
		get
		{
			if (!_ckOperacoes && _operacoes == null)
			{
				_operacoes = ModuloTecnicoEngenhariaProcesso.ObterTodosTecnicoEngenhariaProcessoOperacao(_dados.id);
				_ckOperacoes = true;
			}
			return _operacoes;
		}
		set
		{
			if (_operacoes != value)
			{
				_operacoes = value;
				CodigoProcessoRevisao++;
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProcesso);
		_materias = null;
		_revisoes = null;
		_operacoes = null;
		_ckMateria = false;
		_ckOperacoes = false;
		_ckRevisoes = false;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProcesso()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProcesso(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProcesso)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
