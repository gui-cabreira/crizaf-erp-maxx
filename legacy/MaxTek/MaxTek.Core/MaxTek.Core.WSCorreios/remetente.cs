using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MaxTek.Core.WSCorreios;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/")]
public class remetente : pessoa
{
	private string celularField;

	private string ddd_celularField;

	private string identificacaoField;

	private string smsField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string celular
	{
		get
		{
			return celularField;
		}
		set
		{
			celularField = value;
			RaisePropertyChanged("celular");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string ddd_celular
	{
		get
		{
			return ddd_celularField;
		}
		set
		{
			ddd_celularField = value;
			RaisePropertyChanged("ddd_celular");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string identificacao
	{
		get
		{
			return identificacaoField;
		}
		set
		{
			identificacaoField = value;
			RaisePropertyChanged("identificacao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string sms
	{
		get
		{
			return smsField;
		}
		set
		{
			smsField = value;
			RaisePropertyChanged("sms");
		}
	}
}
