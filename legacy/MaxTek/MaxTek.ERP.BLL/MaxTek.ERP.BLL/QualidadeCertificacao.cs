using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class QualidadeCertificacao : BusinessObjectBase
{
	private MapTableQualidadeCertificacao _dados;

	public int Codigo
	{
		get
		{
			return _dados.codigo;
		}
		set
		{
			if (_dados.codigo != value)
			{
				_dados.codigo = value;
				PropertyHasChanged();
			}
		}
	}

	public string Nome
	{
		get
		{
			return _dados.nome;
		}
		set
		{
			if (_dados.nome != value)
			{
				_dados.nome = value;
				PropertyHasChanged();
			}
		}
	}

	public string Versao
	{
		get
		{
			return _dados.versao;
		}
		set
		{
			if (_dados.versao != value)
			{
				_dados.versao = value;
				PropertyHasChanged();
			}
		}
	}

	public int NotaSistema
	{
		get
		{
			return _dados.notaSistema;
		}
		set
		{
			if (_dados.notaSistema != value)
			{
				_dados.notaSistema = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableQualidadeCertificacao);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public QualidadeCertificacao()
	{
		IniciarVariaveis(isNovo: true);
	}

	public QualidadeCertificacao(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableQualidadeCertificacao)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
