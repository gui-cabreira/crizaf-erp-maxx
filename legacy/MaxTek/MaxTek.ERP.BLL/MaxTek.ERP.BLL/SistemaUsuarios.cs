using System;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class SistemaUsuarios : BusinessObjectBase
{
	private MapTableSistemaUsuarios _dados;

	private RHFuncionario _funcionario;

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

	public string NomeLogon
	{
		get
		{
			return Seguranca.Decriptografar(_dados.nomeLogon);
		}
		set
		{
			if (_dados.nomeLogon != Seguranca.Criptografar(value))
			{
				_dados.nomeLogon = Seguranca.Criptografar(value);
				PropertyHasChanged();
			}
		}
	}

	public int CodigoFuncionario
	{
		get
		{
			return _dados.codigoFuncionario;
		}
		set
		{
			if (_dados.codigoFuncionario != value)
			{
				_dados.codigoFuncionario = value;
				PropertyHasChanged();
			}
		}
	}

	public string Email
	{
		get
		{
			return Seguranca.Decriptografar(_dados.email);
		}
		set
		{
			if (_dados.email != Seguranca.Criptografar(value))
			{
				_dados.email = Seguranca.Criptografar(value);
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEmpresa
	{
		get
		{
			return _dados.codigoEmpresa;
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

	public string Senha
	{
		get
		{
			return Seguranca.Decriptografar(_dados.senha);
		}
		set
		{
			if (_dados.senha != Seguranca.Criptografar(value))
			{
				_dados.senha = Seguranca.Criptografar(value);
				PropertyHasChanged();
			}
		}
	}

	public string DicaSenha
	{
		get
		{
			return Seguranca.Decriptografar(_dados.dicaSenha);
		}
		set
		{
			if (_dados.dicaSenha != Seguranca.Criptografar(value))
			{
				_dados.dicaSenha = Seguranca.Criptografar(value);
				PropertyHasChanged();
			}
		}
	}

	public RHFuncionario Funcionario
	{
		get
		{
			if (_funcionario == null && _dados.codigoFuncionario > 0)
			{
				_funcionario = ModuloRH.ObterRHFuncionario(_dados.codigoFuncionario);
			}
			return _funcionario;
		}
		set
		{
			if (_funcionario != value)
			{
				_funcionario = value;
				_dados.codigoFuncionario = _funcionario.Codigo;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableSistemaUsuarios);
		_funcionario = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public SistemaUsuarios()
	{
		IniciarVariaveis(isNovo: true);
	}

	public SistemaUsuarios(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableSistemaUsuarios)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
