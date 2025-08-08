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
[MessageContract(WrapperName = "buscaTarifaVale", WrapperNamespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", IsWrapped = true)]
public class buscaTarifaVale
{
	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 0)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string codAdministrativo;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 1)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string usuario;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 2)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string senha;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 3)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string codServico;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 4)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string cepOrigem;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 5)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string cepDestino;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 6)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string peso;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 7)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public int codFormato;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 8)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public double comprimento;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 9)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public double altura;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 10)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public double largura;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 11)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public double valorDeclarado;

	[MessageBodyMember(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/", Order = 12)]
	[XmlElement(Form = XmlSchemaForm.Unqualified)]
	public string servicoAdicional;

	public buscaTarifaVale()
	{
	}

	public buscaTarifaVale(string codAdministrativo, string usuario, string senha, string codServico, string cepOrigem, string cepDestino, string peso, int codFormato, double comprimento, double altura, double largura, double valorDeclarado, string servicoAdicional)
	{
		this.codAdministrativo = codAdministrativo;
		this.usuario = usuario;
		this.senha = senha;
		this.codServico = codServico;
		this.cepOrigem = cepOrigem;
		this.cepDestino = cepDestino;
		this.peso = peso;
		this.codFormato = codFormato;
		this.comprimento = comprimento;
		this.altura = altura;
		this.largura = largura;
		this.valorDeclarado = valorDeclarado;
		this.servicoAdicional = servicoAdicional;
	}
}
