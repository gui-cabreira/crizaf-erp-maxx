using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class WorkFlowTarefa : BusinessObjectBase
{
	private MapTableWorkFlowTarefa _dados;

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

	public DateTime DataSolicitacao
	{
		get
		{
			return _dados.dataSolicitacao;
		}
		set
		{
			if (_dados.dataSolicitacao != value)
			{
				_dados.dataSolicitacao = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsConcluido
	{
		get
		{
			return _dados.isConcluido;
		}
		set
		{
			if (_dados.isConcluido != value)
			{
				_dados.isConcluido = value;
				PropertyHasChanged();
			}
		}
	}

	public EnumStatusTarefas Status
	{
		get
		{
			return (EnumStatusTarefas)_dados.status;
		}
		set
		{
			if (_dados.status != (int)value)
			{
				_dados.status = (int)value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSolicitante
	{
		get
		{
			return _dados.codigoSolicitante;
		}
		set
		{
			if (_dados.codigoSolicitante != value)
			{
				_dados.codigoSolicitante = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSolicitado
	{
		get
		{
			return _dados.codigoSolicitado;
		}
		set
		{
			if (_dados.codigoSolicitado != value)
			{
				_dados.codigoSolicitado = value;
				PropertyHasChanged();
			}
		}
	}

	public string Assunto
	{
		get
		{
			return _dados.assunto;
		}
		set
		{
			if (_dados.assunto != value)
			{
				_dados.assunto = value;
				PropertyHasChanged();
			}
		}
	}

	public string Solicitacao
	{
		get
		{
			return _dados.solicitacao;
		}
		set
		{
			if (_dados.solicitacao != value)
			{
				_dados.solicitacao = value;
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

	public DateTime DataConclusao
	{
		get
		{
			return _dados.dataConclusao;
		}
		set
		{
			if (_dados.dataConclusao != value)
			{
				_dados.dataConclusao = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoDepartamentoSolicitante
	{
		get
		{
			return _dados.codigoDepartamentoSolicitante;
		}
		set
		{
			if (_dados.codigoDepartamentoSolicitante != value)
			{
				_dados.codigoDepartamentoSolicitante = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoDepartamentoSolicitado
	{
		get
		{
			return _dados.codigoDepartamentoSolicitado;
		}
		set
		{
			if (_dados.codigoDepartamentoSolicitado != value)
			{
				_dados.codigoDepartamentoSolicitado = value;
				PropertyHasChanged();
			}
		}
	}

	public EnumPrioridade Prioridade
	{
		get
		{
			return (EnumPrioridade)_dados.prioridade;
		}
		set
		{
			if (_dados.prioridade != (int)value)
			{
				_dados.prioridade = (int)value;
				PropertyHasChanged();
			}
		}
	}

	public int PercentualConcluido
	{
		get
		{
			return _dados.percentualConcluido;
		}
		set
		{
			if (_dados.percentualConcluido != value)
			{
				_dados.percentualConcluido = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableWorkFlowTarefa);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public WorkFlowTarefa()
	{
		IniciarVariaveis(isNovo: true);
	}

	public WorkFlowTarefa(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableWorkFlowTarefa)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
