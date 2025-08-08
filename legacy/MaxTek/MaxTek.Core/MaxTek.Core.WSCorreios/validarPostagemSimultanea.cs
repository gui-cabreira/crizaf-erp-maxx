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
[MessageContract(WrapperName = "validarPostagemSimultanea", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class validarPostagemSimultanea
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public int codAdministrativo;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public int codigoServico;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string idCartaoPostagem;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string cepDestinatario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 4)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public coletaSimultanea coleta;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 5)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 6)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	public validarPostagemSimultanea()
	{
	}

	public validarPostagemSimultanea(int codAdministrativo, int codigoServico, string idCartaoPostagem, string cepDestinatario, coletaSimultanea coleta, string usuario, string senha)
	{
		this.codAdministrativo = codAdministrativo;
		this.codigoServico = codigoServico;
		this.idCartaoPostagem = idCartaoPostagem;
		this.cepDestinatario = cepDestinatario;
		this.coleta = coleta;
		this.usuario = usuario;
		this.senha = senha;
	}
}
