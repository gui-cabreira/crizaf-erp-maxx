using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class NotaFiscalCidades : BusinessObjectBase
{
	private MapTableNotaFiscalCidades _dados;

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

	public int CodigoUF
	{
		get
		{
			return _dados.codigoUF;
		}
		set
		{
			if (_dados.codigoUF != value)
			{
				_dados.codigoUF = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeCidade
	{
		get
		{
			return _dados.nomeCidade;
		}
		set
		{
			if (_dados.nomeCidade != value)
			{
				_dados.nomeCidade = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableNotaFiscalCidades);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public NotaFiscalCidades()
	{
		IniciarVariaveis(isNovo: true);
	}

	public NotaFiscalCidades(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableNotaFiscalCidades)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
