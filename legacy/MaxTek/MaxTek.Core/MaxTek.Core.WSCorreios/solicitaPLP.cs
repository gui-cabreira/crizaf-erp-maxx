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
[MessageContract(WrapperName = "solicitaPLP", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class solicitaPLP
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public long idPlpMaster;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string numEtiqueta;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	public solicitaPLP()
	{
	}

	public solicitaPLP(long idPlpMaster, string numEtiqueta, string usuario, string senha)
	{
		this.idPlpMaster = idPlpMaster;
		this.numEtiqueta = numEtiqueta;
		this.usuario = usuario;
		this.senha = senha;
	}
}
