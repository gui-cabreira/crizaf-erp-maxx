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
[MessageContract(WrapperName = "VerificaSeTodosObjetosCancelados", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class VerificaSeTodosObjetosCancelados
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement("arg0", Form = XmlSchemaForm.Unqualified)]
	public objetoPostal[] arg0;

	public VerificaSeTodosObjetosCancelados()
	{
	}

	public VerificaSeTodosObjetosCancelados(objetoPostal[] arg0)
	{
		this.arg0 = arg0;
	}
}
