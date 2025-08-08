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
[MessageContract(WrapperName = "buscaServicosResponse", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class buscaServicosResponse
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement("return", Form = XmlSchemaForm.Unqualified)]
	public servicoERP[] @return;

	public buscaServicosResponse()
	{
	}

	public buscaServicosResponse(servicoERP[] @return)
	{
		this.@return = @return;
	}
}
