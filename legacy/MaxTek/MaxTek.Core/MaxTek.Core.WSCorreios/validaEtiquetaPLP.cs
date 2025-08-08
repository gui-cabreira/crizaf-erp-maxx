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
[MessageContract(WrapperName = "validaEtiquetaPLP", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class validaEtiquetaPLP
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string numeroEtiqueta;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public long idPlp;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	public validaEtiquetaPLP()
	{
	}

	public validaEtiquetaPLP(string numeroEtiqueta, long idPlp, string usuario, string senha)
	{
		this.numeroEtiqueta = numeroEtiqueta;
		this.idPlp = idPlp;
		this.usuario = usuario;
		this.senha = senha;
	}
}
