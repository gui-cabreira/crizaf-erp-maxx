using System;
using System.Drawing;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ParametrosSociedade : BusinessObjectBase
{
	private MapTableParametrosSociedade _dados;

	private NotaFiscalCidades _cidades;

	private NotaFiscalUF _estado;

	private NotaFiscalPaises _pais;

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

	public string Cnpj
	{
		get
		{
			return _dados.cnpj;
		}
		set
		{
			if (_dados.cnpj != value)
			{
				_dados.cnpj = value;
				PropertyHasChanged();
			}
		}
	}

	public string RazaoSocial
	{
		get
		{
			return _dados.razaoSocial;
		}
		set
		{
			if (_dados.razaoSocial != value)
			{
				_dados.razaoSocial = value;
				PropertyHasChanged();
			}
		}
	}

	public string NomeFantasia
	{
		get
		{
			return _dados.nomeFantasia;
		}
		set
		{
			if (_dados.nomeFantasia != value)
			{
				_dados.nomeFantasia = value;
				PropertyHasChanged();
			}
		}
	}

	public string Endereco
	{
		get
		{
			return _dados.endereco;
		}
		set
		{
			if (_dados.endereco != value)
			{
				_dados.endereco = value;
				PropertyHasChanged();
			}
		}
	}

	public string Bairro
	{
		get
		{
			return _dados.bairro;
		}
		set
		{
			if (_dados.bairro != value)
			{
				_dados.bairro = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCidade
	{
		get
		{
			return _dados.codigoCidade;
		}
		set
		{
			if (_dados.codigoCidade != value)
			{
				_dados.codigoCidade = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEstado
	{
		get
		{
			return _dados.codigoEstado;
		}
		set
		{
			if (_dados.codigoEstado != value)
			{
				_dados.codigoEstado = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoPais
	{
		get
		{
			return _dados.codigoPais;
		}
		set
		{
			if (_dados.codigoPais != value)
			{
				_dados.codigoPais = value;
				PropertyHasChanged();
			}
		}
	}

	public string CodigoPostal
	{
		get
		{
			return _dados.codigoPostal;
		}
		set
		{
			if (_dados.codigoPostal != value)
			{
				_dados.codigoPostal = value;
				PropertyHasChanged();
			}
		}
	}

	public string Telefone
	{
		get
		{
			return _dados.telefone;
		}
		set
		{
			if (_dados.telefone != value)
			{
				_dados.telefone = value;
				PropertyHasChanged();
			}
		}
	}

	public string InscricaoEstadual
	{
		get
		{
			return _dados.inscricaoEstadual;
		}
		set
		{
			if (_dados.inscricaoEstadual != value)
			{
				_dados.inscricaoEstadual = value;
				PropertyHasChanged();
			}
		}
	}

	public string Email
	{
		get
		{
			return _dados.email;
		}
		set
		{
			if (_dados.email != value)
			{
				_dados.email = value;
				PropertyHasChanged();
			}
		}
	}

	public string Site
	{
		get
		{
			return _dados.site;
		}
		set
		{
			if (_dados.site != value)
			{
				_dados.site = value;
				PropertyHasChanged();
			}
		}
	}

	public Image Logo
	{
		get
		{
			return _dados.logo;
		}
		set
		{
			if (_dados.logo != value)
			{
				_dados.logo = value;
				PropertyHasChanged();
			}
		}
	}

	public NotaFiscalPaises Pais
	{
		get
		{
			if (_pais == null && _dados.codigoPais > 0)
			{
				_pais = ModuloNotaFiscal.ObterNotaFiscalPaises(_dados.codigoPais);
			}
			return _pais;
		}
		set
		{
			if (_pais != value)
			{
				_pais = value;
				CodigoPais = _pais.Codigo;
			}
		}
	}

	public NotaFiscalCidades Cidade
	{
		get
		{
			if (_cidades == null && _dados.codigoCidade > 0)
			{
				_cidades = ModuloNotaFiscal.ObterNotaFiscalCidades(_dados.codigoCidade);
			}
			return _cidades;
		}
		set
		{
			if (_cidades != value)
			{
				_cidades = value;
				CodigoCidade = _cidades.Id;
			}
		}
	}

	public NotaFiscalUF Estado
	{
		get
		{
			if (_estado == null && _dados.codigoEstado > 0)
			{
				_estado = ModuloNotaFiscal.ObterNotaFiscalUF(_dados.id);
			}
			return _estado;
		}
		set
		{
			if (_estado != value)
			{
				_estado = value;
				CodigoEstado = _estado.Id;
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableParametrosSociedade);
		_cidades = null;
		_estado = null;
		_pais = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ParametrosSociedade()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ParametrosSociedade(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableParametrosSociedade)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
