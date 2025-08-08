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
public class coletaSimultanea : coleta
{
	private string objField;

	private string obsField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string obj
	{
		get
		{
			return objField;
		}
		set
		{
			objField = value;
			RaisePropertyChanged("obj");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string obs
	{
		get
		{
			return obsField;
		}
		set
		{
			obsField = value;
			RaisePropertyChanged("obs");
		}
	}
}
