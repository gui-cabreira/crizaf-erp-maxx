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
[MessageContract(WrapperName = "consultaSRO_NEW", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class consultaSRO_NEW
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement("listaObjetos", Form = XmlSchemaForm.Unqualified)]
	public string[] listaObjetos;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string tipoResultado;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuarioSro;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senhaSro;

	public consultaSRO_NEW()
	{
	}

	public consultaSRO_NEW(string[] listaObjetos, string tipoResultado, string usuarioSro, string senhaSro)
	{
		this.listaObjetos = listaObjetos;
		this.tipoResultado = tipoResultado;
		this.usuarioSro = usuarioSro;
		this.senhaSro = senhaSro;
	}
}
