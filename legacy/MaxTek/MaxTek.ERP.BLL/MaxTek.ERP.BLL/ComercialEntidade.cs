using System;
using System.Collections.Generic;
using System.Drawing;
using MaxTek.Core;
using MaxTek.ERP.DAL;

namespace MaxTek.ERP.BLL;

[Serializable]
public class ComercialEntidade : BusinessObjectBase
{
	private MapTableComercialEntidade _dados;

	private ComercialEntidadeEspecialidade _especialidade;

	private QualidadeCertificacao _certificacao;

	private ComercialEntidade _representante;

	private RHFuncionario _funcionario;

	private ComercialFinanceiroModoPagamento _modoPagamento;

	private ComercialFinanceiroCondicaoPagamento _condicaoPagamento;

	private IList<ComercialEntidadeContato> _contatos;

	private IList<ComercialEntidadeLigacaoEndereco> _enderecos;

	private IList<ComercialEntidadeEvento> _eventos;

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

	public int CodigoGpsCliente
	{
		get
		{
			return _dados.codigoGpsCliente;
		}
		set
		{
			if (_dados.codigoGpsCliente != value)
			{
				_dados.codigoGpsCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoGpsFornecedor
	{
		get
		{
			return _dados.CodigoGpsFornecedor;
		}
		set
		{
			if (_dados.CodigoGpsFornecedor != value)
			{
				_dados.CodigoGpsFornecedor = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsCliente
	{
		get
		{
			return _dados.IsCliente;
		}
		set
		{
			if (_dados.IsCliente != value)
			{
				_dados.IsCliente = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsFornecedor
	{
		get
		{
			return _dados.isFornecedor;
		}
		set
		{
			if (_dados.isFornecedor != value)
			{
				_dados.isFornecedor = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsRepresentante
	{
		get
		{
			return _dados.isRepresentante;
		}
		set
		{
			if (_dados.isRepresentante != value)
			{
				_dados.isRepresentante = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsSubContratado
	{
		get
		{
			return _dados.isSubContratado;
		}
		set
		{
			if (_dados.isSubContratado != value)
			{
				_dados.isSubContratado = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsTransportadora
	{
		get
		{
			return _dados.isTransportadora;
		}
		set
		{
			if (_dados.isTransportadora != value)
			{
				_dados.isTransportadora = value;
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

	public string InscricaoMunicipal
	{
		get
		{
			return _dados.inscricaoMunicipal;
		}
		set
		{
			if (_dados.inscricaoMunicipal != value)
			{
				_dados.inscricaoMunicipal = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoEspecialidade
	{
		get
		{
			return _dados.codigoEspecialidade;
		}
		set
		{
			if (_dados.codigoEspecialidade != value)
			{
				_dados.codigoEspecialidade = value;
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

	public string Complemento
	{
		get
		{
			return _dados.complemento;
		}
		set
		{
			if (_dados.complemento != value)
			{
				_dados.complemento = value;
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

	public string Cep
	{
		get
		{
			return _dados.cep;
		}
		set
		{
			if (_dados.cep != value)
			{
				_dados.cep = value;
				PropertyHasChanged();
			}
		}
	}

	public string Cidade
	{
		get
		{
			return _dados.cidade;
		}
		set
		{
			if (_dados.cidade != value)
			{
				_dados.cidade = value;
				PropertyHasChanged();
			}
		}
	}

	public string Pais
	{
		get
		{
			return _dados.pais;
		}
		set
		{
			if (_dados.pais != value)
			{
				_dados.pais = value;
				PropertyHasChanged();
			}
		}
	}

	public string Uf
	{
		get
		{
			return _dados.uf;
		}
		set
		{
			if (_dados.uf != value)
			{
				_dados.uf = value;
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

	public string Fax
	{
		get
		{
			return _dados.fax;
		}
		set
		{
			if (_dados.fax != value)
			{
				_dados.fax = value;
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

	public bool IsProspecto
	{
		get
		{
			return _dados.isProspecto;
		}
		set
		{
			if (_dados.isProspecto != value)
			{
				_dados.isProspecto = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCertificacao
	{
		get
		{
			return _dados.codigoCertificacao;
		}
		set
		{
			if (_dados.codigoCertificacao != value)
			{
				_dados.codigoCertificacao = value;
				PropertyHasChanged();
			}
		}
	}

	public DateTime DataValidadeCertificacao
	{
		get
		{
			return _dados.dataValidadeCertificacao;
		}
		set
		{
			if (_dados.dataValidadeCertificacao != value)
			{
				_dados.dataValidadeCertificacao = value;
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

	public int CodigoRepresentante
	{
		get
		{
			return _dados.codigoRepresentante;
		}
		set
		{
			if (_dados.codigoRepresentante != value)
			{
				_dados.codigoRepresentante = value;
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

	public int CodigoTipoPagamento
	{
		get
		{
			return _dados.codigoTipoPagamento;
		}
		set
		{
			if (_dados.codigoTipoPagamento != value)
			{
				_dados.codigoTipoPagamento = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoModoPagamento
	{
		get
		{
			return _dados.codigoModoPagamento;
		}
		set
		{
			if (_dados.codigoModoPagamento != value)
			{
				_dados.codigoModoPagamento = value;
				PropertyHasChanged();
			}
		}
	}

	public decimal ValorCredito
	{
		get
		{
			return _dados.valorCredito;
		}
		set
		{
			if (_dados.valorCredito != value)
			{
				_dados.valorCredito = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsBloqueado
	{
		get
		{
			return _dados.isBloqueado;
		}
		set
		{
			if (_dados.isBloqueado != value)
			{
				_dados.isBloqueado = value;
				PropertyHasChanged();
			}
		}
	}

	public bool IsQualificado
	{
		get
		{
			return _dados.IsQualificado;
		}
		set
		{
			if (_dados.IsQualificado != value)
			{
				_dados.IsQualificado = value;
				PropertyHasChanged();
			}
		}
	}

	public string NotaIqf
	{
		get
		{
			return _dados.notaIqf;
		}
		set
		{
			if (_dados.notaIqf != value)
			{
				_dados.notaIqf = value;
				PropertyHasChanged();
			}
		}
	}

	public int CodigoCfopPadrao
	{
		get
		{
			return _dados.codigoCfopPadrao;
		}
		set
		{
			if (_dados.codigoCfopPadrao != value)
			{
				_dados.codigoCfopPadrao = value;
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

	public ComercialEntidadeEspecialidade Especialidade
	{
		get
		{
			if (CodigoEspecialidade > 0 && _especialidade == null)
			{
				_especialidade = ModuloComercialEntidade.ObterComercialEntidadeEspecialidade(_dados.codigoEspecialidade);
			}
			return _especialidade;
		}
		set
		{
			if (_especialidade != value)
			{
				_especialidade = value;
				PropertyHasChanged();
				if (_especialidade == null)
				{
					CodigoEspecialidade = 0;
				}
				else
				{
					CodigoEspecialidade = _especialidade.Codigo;
				}
			}
		}
	}

	public QualidadeCertificacao Certificacao
	{
		get
		{
			if (CodigoCertificacao > 0 && _certificacao == null)
			{
				_certificacao = ModuloQualidade.ObterQualidadeCertificacao(_dados.codigoCertificacao);
			}
			return _certificacao;
		}
		set
		{
			if (_certificacao != value)
			{
				_certificacao = value;
				PropertyHasChanged();
				if (_certificacao == null)
				{
					CodigoCertificacao = 0;
				}
				else
				{
					CodigoCertificacao = _certificacao.Codigo;
				}
			}
		}
	}

	public ComercialEntidade Representante
	{
		get
		{
			if (CodigoRepresentante > 0 && _representante == null)
			{
				_representante = ModuloComercialEntidade.ObterComercialEntidade(_dados.codigoRepresentante);
			}
			return _representante;
		}
		set
		{
			if (_representante != value)
			{
				_representante = value;
				PropertyHasChanged();
				if (_representante == null)
				{
					CodigoRepresentante = 0;
				}
				else
				{
					CodigoRepresentante = _representante.Codigo;
				}
			}
		}
	}

	public RHFuncionario Funcionario
	{
		get
		{
			if (CodigoFuncionario > 0 && _funcionario == null)
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
				PropertyHasChanged();
				if (_funcionario == null)
				{
					CodigoFuncionario = 0;
				}
				else
				{
					CodigoFuncionario = _funcionario.Codigo;
				}
			}
		}
	}

	public ComercialFinanceiroCondicaoPagamento CondicaoPagamento
	{
		get
		{
			if (CodigoTipoPagamento > 0 && _condicaoPagamento == null)
			{
				_condicaoPagamento = ModuloComercialFinanceiro.ObterComercialFinanceiroCondicaoPagamento(_dados.codigoTipoPagamento);
			}
			return _condicaoPagamento;
		}
		set
		{
			if (_condicaoPagamento != value)
			{
				_condicaoPagamento = value;
				PropertyHasChanged();
				if (_condicaoPagamento == null)
				{
					CodigoTipoPagamento = 0;
				}
				else
				{
					CodigoTipoPagamento = _condicaoPagamento.Codigo;
				}
			}
		}
	}

	public ComercialFinanceiroModoPagamento ModoPagamento
	{
		get
		{
			if (CodigoModoPagamento > 0 && _modoPagamento == null)
			{
				_modoPagamento = ModuloComercialFinanceiro.ObterComercialFinanceiroModoPagamento(_dados.codigoTipoPagamento);
			}
			return _modoPagamento;
		}
		set
		{
			if (_modoPagamento != value)
			{
				_modoPagamento = value;
				PropertyHasChanged();
				if (_modoPagamento == null)
				{
					CodigoModoPagamento = 0;
				}
				else
				{
					CodigoModoPagamento = _modoPagamento.Codigo;
				}
			}
		}
	}

	public IList<ComercialEntidadeContato> Contatos
	{
		get
		{
			if (_contatos == null)
			{
				_contatos = ModuloComercialEntidade.ObterTodosComercialEntidadeContato(_dados.codigo);
			}
			return _contatos;
		}
		set
		{
			if (_contatos != value)
			{
				_contatos = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<ComercialEntidadeLigacaoEndereco> Enderecos
	{
		get
		{
			if (_enderecos == null)
			{
				_enderecos = ModuloComercialEntidade.ObterTodosComercialEntidadeLigacaoEndereco(_dados.codigo);
			}
			return _enderecos;
		}
		set
		{
			if (_enderecos != value)
			{
				_enderecos = value;
				PropertyHasChanged();
			}
		}
	}

	public IList<ComercialEntidadeEvento> Eventos
	{
		get
		{
			if (_eventos == null)
			{
				_eventos = ModuloComercialEntidade.ObterTodosComercialEntidadeEvento(_dados.codigo);
			}
			return _eventos;
		}
		set
		{
			if (_eventos != value)
			{
				_eventos = value;
				PropertyHasChanged();
			}
		}
	}

	private void IniciarVariaveis(bool isNovo)
	{
		_dados = default(MapTableComercialEntidade);
		_especialidade = null;
		_certificacao = null;
		_representante = null;
		_funcionario = null;
		_modoPagamento = null;
		_condicaoPagamento = null;
		_contatos = null;
		_enderecos = null;
		_eventos = null;
		if (isNovo)
		{
			MarcarNovo();
		}
		else
		{
			MarcarExistente();
		}
	}

	public ComercialEntidade()
	{
		IniciarVariaveis(isNovo: true);
	}

	public ComercialEntidade(bool isNovo)
	{
		IniciarVariaveis(isNovo);
	}

	public override void MapearDados(object dados)
	{
		_dados = (MapTableComercialEntidade)dados;
	}

	public override object ObterDadosMapeados()
	{
		return _dados;
	}
}
