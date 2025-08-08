using MaxTek.Core.MaxCep;
using MaxTek.Core.WSCorreios;

namespace MaxTek.Utils;

public sealed class ConsultaCepCorreios
{
	public static BuscarEnderecos ConsultarCepCorreios(string cep)
	{
		BuscarEnderecos buscarEnderecos = new BuscarEnderecos();
		try
		{
			AtendeClienteClient atendeClienteClient = new AtendeClienteClient();
			enderecoERP enderecoERP = atendeClienteClient.consultaCEP(cep);
			buscarEnderecos.Bairro = enderecoERP.bairro;
			buscarEnderecos.Cep = enderecoERP.cep;
			buscarEnderecos.Cidade = enderecoERP.cidade;
			buscarEnderecos.Endereco = enderecoERP.end;
			buscarEnderecos.Uf = enderecoERP.uf;
		}
		catch
		{
		}
		return buscarEnderecos;
	}
}
