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
[MessageContract(WrapperName = "validaPlp", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class validaPlp
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public long cliente;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string numero;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public long diretoria;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string cartao;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 4)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string unidadePostagem;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 5)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public long servico;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 6)]
	[XmlElement("servicosAdicionais", Form = XmlSchemaForm.Unqualified)]
	public string[] servicosAdicionais;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 7)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 8)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	public validaPlp()
	{
	}

	public validaPlp(long cliente, string numero, long diretoria, string cartao, string unidadePostagem, long servico, string[] servicosAdicionais, string usuario, string senha)
	{
		this.cliente = cliente;
		this.numero = numero;
		this.diretoria = diretoria;
		this.cartao = cartao;
		this.unidadePostagem = unidadePostagem;
		this.servico = servico;
		this.servicosAdicionais = servicosAdicionais;
		this.usuario = usuario;
		this.senha = senha;
	}
}
