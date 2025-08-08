using System;
using System.Collections.Generic;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalInutilizacao : BusinessObjectBase
{
	private MapTableNotaFiscalInutilizacao _dados;

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

	public int CodigoEmpresa
	{
		get
		{
			return (_dados.codigoEmpresa == 0) ? 1 : _dados.codigoEmpresa;
		}
		set
		{
			if (_dados.codigoEmpresa != value)
			{
				_dados.codigoEmpresa = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoModelo
	{
		get
		{
			return _dados.codigoModelo;
		}
		set
		{
			if (_dados.codigoModelo != value)
			{
				_dados.codigoModelo = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoSerie
	{
		get
		{
			return _dados.codigoSerie;
		}
		set
		{
			if (_dados.codigoSerie != value)
			{
				_dados.codigoSerie = value;
				PropertyHasChanged();
			}
		}
	}

	public int Ano
	{
		get
		{
			return _dados.ano;
		}
		set
		{
			if (_dados.ano != value)
			{
				_dados.ano = value;
				PropertyHasChanged();
			}
		}
	}

	public int NotaInicial
	{
		get
		{
			return _dados.notaInicial;
		}
		set
		{
			if (_dados.notaInicial != value)
			{
				_dados.notaInicial = value;
				PropertyHasChanged();
			}
		}
	}

	public int NotaFinal
	{
		get
		{
			return _dados.notaFinal;
		}
		set
		{
			if (_dados.notaFinal != value)
			{
				_dados.notaFinal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoStatus
	{
		get
		{
			return _dados.codigoStatus;
		}
		set
		{
			if (_dados.codigoStatus != value)
			{
				_dados.codigoStatus = value;
				PropertyHasChanged();
			}
		}
	}

	public string Status
	{
		get
		{
			return _dados.status;
		}
		set
		{
			if (_dados.status != value)
			{
				_dados.status = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataRecibo
	{
		get
		{
			return _dados.dataRecibo;
		}
		set
		{
			if (_dados.dataRecibo != value)
			{
				_dados.dataRecibo = value;
				PropertyHasChanged();
			}
		}
	}

	public string Protocolo
	{
		get
		{
			return _dados.protocolo;
		}
		set
		{
			if (_dados.protocolo != value)
			{
				_dados.protocolo = value;
				PropertyHasChanged();
			}
		}
	}

	public string Usuario
	{
		get
		{
			return _dados.usuario;
		}
		set
		{
			if (_dados.usuario != value)
			{
				_dados.usuario = value;
				PropertyHasChanged();
			}
		}
	}

	public string Justificativa
	{
		get
		{
			return _dados.justificativa;
		}
		set
		{
			if (_dados.justificativa != value)
			{
				_dados.justificativa = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalInutilizacao);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalInutilizacao()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalInutilizacao(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalInutilizacao)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}

	protected override List<Regra> CriarRegras()
	{
		List<Regra> list = base.CriarRegras();
		list.Add(new RegraSimples("NotaFinal", "A Nota Final não pode ser menor que a nota inicial.", () => NotaInicial <= NotaFinal));
		list.Add(new RegraSimples("CodigoModelo", "Favor Escolher o Modelo da Nota", () => CodigoModelo > 0));
		list.Add(new RegraSimples("Ano", "Favor definir o ano", () => Ano > 10));
		list.Add(new RegraSimples("Justificativa", "A Justificativa tem de possuir pelo menos 15 letras", () => Justificativa != null && Justificativa.Length > 15));
		return list;
	}
}
