using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MaxTek.Core.WSCorreios;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "buscaServicosXServicosAdicionaisResponse", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class buscaServicosXServicosAdicionaisResponse
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement("return", Form = XmlSchemaForm.Unqualified)]
	public string[] @return;

	public buscaServicosXServicosAdicionaisResponse()
	{
	}

	public buscaServicosXServicosAdicionaisResponse(string[] @return)
	{
		this.@return = @return;
	}
}
