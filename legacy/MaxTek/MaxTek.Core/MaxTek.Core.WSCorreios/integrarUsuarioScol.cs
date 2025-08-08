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
[MessageContract(WrapperName = "integrarUsuarioScol", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class integrarUsuarioScol
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public int codAdministrativo;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	public integrarUsuarioScol()
	{
	}

	public integrarUsuarioScol(int codAdministrativo, string usuario, string senha)
	{
		this.codAdministrativo = codAdministrativo;
		this.usuario = usuario;
		this.senha = senha;
	}
}
