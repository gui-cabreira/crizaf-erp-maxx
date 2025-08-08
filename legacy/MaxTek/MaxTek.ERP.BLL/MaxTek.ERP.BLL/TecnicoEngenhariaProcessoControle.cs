using System;
using System.Drawing;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class TecnicoEngenhariaProcessoControle : BusinessObjectBase
{
	private MapTableTecnicoEngenhariaProcessoControle _dados;

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

	public string CodigoProcessoControle
	{
		get
		{
			return _dados.codigoProcessoControle;
		}
		set
		{
			if (_dados.codigoProcessoControle != value)
			{
				_dados.codigoProcessoControle = value;
				PropertyHasChanged();
			}
		}
	}

	public string DescricaoProcessoControle
	{
		get
		{
			return _dados.descricaoProcessoControle;
		}
		set
		{
			if (_dados.descricaoProcessoControle != value)
			{
				_dados.descricaoProcessoControle = value;
				PropertyHasChanged();
			}
		}
	}

	public string Desenho
	{
		get
		{
			return _dados.desenho;
		}
		set
		{
			if (_dados.desenho != value)
			{
				_dados.desenho = value;
				PropertyHasChanged();
			}
		}
	}

	public string Revisao
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

	public DateTime DataCadastro
	{
		get
		{
			return _dados.dataCadastro;
		}
		set
		{
			if (_dados.dataCadastro != value)
			{
				_dados.dataCadastro = value;
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

	public int CodigoUsuario
	{
		get
		{
			return _dados.codigoUsuario;
		}
		set
		{
			if (_dados.codigoUsuario != value)
			{
				_dados.codigoUsuario = value;
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

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableTecnicoEngenhariaProcessoControle);
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public TecnicoEngenhariaProcessoControle()
	{
		IniciarVariaveis(isNovo: true);
	}

	public TecnicoEngenhariaProcessoControle(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableTecnicoEngenhariaProcessoControle)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
