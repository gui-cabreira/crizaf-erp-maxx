using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MaxTek.Core.MaxCep;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class BuscaCepClient : ClientBase<IBuscaCep>, IBuscaCep
{
	public BuscaCepClient()
	{
	}

	public BuscaCepClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public BuscaCepClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public BuscaCepClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public BuscaCepClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public BuscarEnderecos ObterEnderecos(string cep)
	{
		return base.Channel.ObterEnderecos(cep);
	}
}
