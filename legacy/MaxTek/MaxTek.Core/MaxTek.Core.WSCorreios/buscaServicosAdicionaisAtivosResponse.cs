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
[MessageContract(WrapperName = "buscaServicosAdicionaisAtivosResponse", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class buscaServicosAdicionaisAtivosResponse
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement("return", Form = XmlSchemaForm.Unqualified)]
	public servicoAdicionalXML[] @return;

	public buscaServicosAdicionaisAtivosResponse()
	{
	}

	public buscaServicosAdicionaisAtivosResponse(servicoAdicionalXML[] @return)
	{
		this.@return = @return;
	}
}
