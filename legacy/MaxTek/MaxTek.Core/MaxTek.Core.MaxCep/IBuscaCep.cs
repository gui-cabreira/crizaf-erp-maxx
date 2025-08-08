using System.CodeDom.Compiler;
using System.ServiceModel;

namespace MaxTek.Core.MaxCep;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "MaxCep.IBuscaCep")]
public interface IBuscaCep
{
	[OperationContract(Action = "http://tempuri.org/IBuscaCep/ObterEnderecos", ReplyAction = "http://tempuri.org/IBuscaCep/ObterEnderecosResponse")]
	BuscarEnderecos ObterEnderecos(string cep);
}
