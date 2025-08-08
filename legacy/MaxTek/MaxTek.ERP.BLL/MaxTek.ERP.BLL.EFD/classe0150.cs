using MaxTek.GPS.BLL;
using MaxTek.Utils;

namespace MaxTek.ERP.BLL.EFD;

public class classe0150
{
	private string identificacao;

	private string razaoSocial;

	private string codigoPais;

	private string cnpj;

	private string cpf;

	private string inscricaoEstadual;

	private string codigoMunicipio;

	private string suframa;

	private string endereco;

	private string numero;

	private string complemento;

	private string bairro;

	public string Identificacao
	{
		get
		{
			return identificacao;
		}
		set
		{
			if (!(identificacao == value))
			{
				identificacao = value;
			}
		}
	}

	public string RazaoSocial
	{
		get
		{
			return razaoSocial;
		}
		set
		{
			if (!(razaoSocial == value))
			{
				razaoSocial = value;
			}
		}
	}

	public string CodigoPais
	{
		get
		{
			return codigoPais;
		}
		set
		{
			if (!(codigoPais == value))
			{
				codigoPais = value;
			}
		}
	}

	public string Cnpj
	{
		get
		{
			return cnpj;
		}
		set
		{
			if (!(cnpj == value))
			{
				cnpj = value;
			}
		}
	}

	public string Cpf
	{
		get
		{
			return cpf;
		}
		set
		{
			if (!(cpf == value))
			{
				cpf = value;
			}
		}
	}

	public string InscricaoEstadual
	{
		get
		{
			return inscricaoEstadual;
		}
		set
		{
			if (!(inscricaoEstadual == value))
			{
				inscricaoEstadual = value;
			}
		}
	}

	public string CodigoMunicipio
	{
		get
		{
			return codigoMunicipio;
		}
		set
		{
			if (!(codigoMunicipio == value))
			{
				codigoMunicipio = value;
			}
		}
	}

	public string Suframa
	{
		get
		{
			return suframa;
		}
		set
		{
			if (!(suframa == value))
			{
				suframa = value;
			}
		}
	}

	public string Endereco
	{
		get
		{
			return endereco;
		}
		set
		{
			if (!(endereco == value))
			{
				endereco = value;
			}
		}
	}

	public string Numero
	{
		get
		{
			return numero;
		}
		set
		{
			if (!(numero == value))
			{
				numero = value;
			}
		}
	}

	public string Complemento
	{
		get
		{
			return complemento;
		}
		set
		{
			if (!(complemento == value))
			{
				complemento = value;
			}
		}
	}

	public string Bairro
	{
		get
		{
			return bairro;
		}
		set
		{
			if (!(bairro == value))
			{
				bairro = value;
			}
		}
	}

	public classe0150(XmlEntidade xmlEntidade)
	{
		identificacao = FuncoesUteis.LimparNro(xmlEntidade.Cnpj);
		razaoSocial = xmlEntidade.RazaoSocial;
		codigoPais = xmlEntidade.CodigoPais.ToString();
		cnpj = FuncoesUteis.LimparNro(xmlEntidade.Cnpj);
		inscricaoEstadual = FuncoesUteis.LimparNro(xmlEntidade.InscricaoEstadual);
		codigoMunicipio = xmlEntidade.CodigoMunicipio.ToString();
		suframa = xmlEntidade.InscricaoSuframa;
		endereco = xmlEntidade.Endereco;
		numero = xmlEntidade.EnderecoNumero;
		complemento = xmlEntidade.EnderecoComplemento;
		bairro = xmlEntidade.Bairro;
	}

	public classe0150(EntidadeGPS destinatario)
	{
		identificacao = destinatario.CNPJLimpo;
		razaoSocial = destinatario.RazaoSocial;
		codigoPais = destinatario.CodigoPais.ToString();
		cnpj = destinatario.CNPJLimpo;
		inscricaoEstadual = FuncoesUteis.LimparNro(destinatario.InscricaoEstadual);
		codigoMunicipio = destinatario.CodigoCidade.ToString();
		suframa = destinatario.CodigoSuframa;
		endereco = destinatario.AuxEndereco;
		numero = destinatario.AuxEnderecoNumero;
		complemento = destinatario.AuxEnderecoComplemento;
		bairro = destinatario.AuxBairro;
	}
}
