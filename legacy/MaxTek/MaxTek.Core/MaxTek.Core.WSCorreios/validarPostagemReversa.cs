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
[MessageContract(WrapperName = "validarPostagemReversa", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class validarPostagemReversa
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string codAdministrativo;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string codigoServico;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string cepDestinatario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string idCartaoPostagem;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 4)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public coletaReversa coleta;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 5)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 6)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	public validarPostagemReversa()
	{
	}

	public validarPostagemReversa(string codAdministrativo, string codigoServico, string cepDestinatario, string idCartaoPostagem, coletaReversa coleta, string usuario, string senha)
	{
		this.codAdministrativo = codAdministrativo;
		this.codigoServico = codigoServico;
		this.cepDestinatario = cepDestinatario;
		this.idCartaoPostagem = idCartaoPostagem;
		this.coleta = coleta;
		this.usuario = usuario;
		this.senha = senha;
	}
}
