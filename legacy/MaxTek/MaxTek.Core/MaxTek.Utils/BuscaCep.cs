using System.Data;
using MaxTek.Core.MaxCep;

namespace MaxTek.Utils;

public sealed class BuscaCep
{
	public class Endereco
	{
		private string _tipoLogradouro;

		private string _logradouro;

		private string _bairro;

		private string _uf;

		private string _cidade;

		private string _IBGE;

		private string _ibgeUF;

		private int _Resul;

		public string TipoLogradouro
		{
			get
			{
				return _tipoLogradouro;
			}
			set
			{
				_tipoLogradouro = value;
			}
		}

		public string Logradouro
		{
			get
			{
				return _logradouro;
			}
			set
			{
				_logradouro = value;
			}
		}

		public string Bairro
		{
			get
			{
				return _bairro;
			}
			set
			{
				_bairro = value;
			}
		}

		public string UF
		{
			get
			{
				return _uf;
			}
			set
			{
				_uf = value;
			}
		}

		public string Cidade
		{
			get
			{
				return _cidade;
			}
			set
			{
				_cidade = value;
			}
		}

		public string IBGE
		{
			get
			{
				return _IBGE;
			}
			set
			{
				_IBGE = value;
			}
		}

		public string IbgeUF
		{
			get
			{
				return _ibgeUF;
			}
			set
			{
				_ibgeUF = value;
			}
		}

		public int Resul
		{
			get
			{
				return _Resul;
			}
			set
			{
				_Resul = value;
			}
		}
	}

	public static Endereco BuscarCep(string cep, string chave, out string erro)
	{
		erro = string.Empty;
		Endereco endereco = new Endereco();
		if (!string.IsNullOrWhiteSpace(cep) && !string.IsNullOrWhiteSpace(chave))
		{
			DataSet dataSet = new DataSet();
			try
			{
				dataSet.ReadXml("http://www.buscarcep.com.br/?cep=" + cep + "&formato=xml&chave=" + chave);
				DataRow dataRow = dataSet.Tables["retorno"].Rows[0];
				endereco.Resul = int.Parse(dataRow["resultado"].ToString());
				if (endereco.Resul == 1)
				{
					endereco.TipoLogradouro = dataRow["tipo_logradouro"].ToString();
					endereco.Logradouro = dataRow["logradouro"].ToString();
					endereco.Bairro = dataRow["bairro"].ToString();
					endereco.Cidade = dataRow["cidade"].ToString();
					endereco.UF = dataRow["uf"].ToString();
					endereco.IBGE = dataRow["ibge_municipio_verificador"].ToString();
					endereco.IbgeUF = dataRow["ibge_uf"].ToString();
				}
				else if (endereco.Resul == -1)
				{
					erro = "Cep não encontrado !";
				}
				else if (endereco.Resul == -2)
				{
					erro = "Formato de CEP inválido !";
				}
				else if (endereco.Resul == -3)
				{
					erro = "Busca de CEP congestionada. \n Aguarde alguns segundos e tente novamente. !";
				}
				else if (endereco.Resul == -4)
				{
					erro = "IP Banido. \n contate o administrador !";
				}
				else if (endereco.Resul == -5)
				{
					erro = "Chave banida. contate o administrador !";
				}
				else if (endereco.Resul == -6)
				{
					erro = "entre 0 e 6 horas da madrugada todas as buscas são limitadas a 5 buscas por minuto !";
				}
				else if (endereco.Resul == -7)
				{
					erro = "chave inválida. cadastre-se para continuar utilizando o serviço !";
				}
				else
				{
					erro = "Erro na busca de CEP !";
				}
			}
			catch
			{
				erro = "Não foi possível encontrar o WebService do site: www.buscarcep.com.br. \n\n Verifique sua Conexão de Internet.";
			}
		}
		else
		{
			erro = "Não foi possível encontrar o WebService do site: www.buscarcep.com.br. \n\n Verifique parametros utilizados.";
		}
		return endereco;
	}

	public static BuscarEnderecos Cep(string cep)
	{
		BuscaCepClient buscaCepClient = new BuscaCepClient();
		BuscarEnderecos buscarEnderecos = new BuscarEnderecos();
		try
		{
			buscarEnderecos = buscaCepClient.ObterEnderecos(cep);
		}
		catch
		{
			EnviaEmail enviaEmail = new EnviaEmail($"O Cep: {cep} não foi encontrado", "Erro Procura de CEP");
		}
		buscaCepClient.Close();
		if (buscarEnderecos == null || string.IsNullOrWhiteSpace(buscarEnderecos.Endereco))
		{
			try
			{
				buscarEnderecos = ConsultaCepCorreios.ConsultarCepCorreios(cep);
			}
			catch
			{
			}
			EnviaEmail enviaEmail2 = new EnviaEmail($"O Cep: {cep} não foi encontrado", "Erro Procura de CEP");
		}
		return buscarEnderecos;
	}
}
