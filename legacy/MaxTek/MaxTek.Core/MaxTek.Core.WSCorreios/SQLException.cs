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
public class SQLException : INotifyPropertyChanged
{
	private int errorCodeField;

	private bool errorCodeFieldSpecified;

	private string sQLStateField;

	private string messageField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public int errorCode
	{
		get
		{
			return errorCodeField;
		}
		set
		{
			errorCodeField = value;
			RaisePropertyChanged("errorCode");
		}
	}

	[XmlIgnore]
	public bool errorCodeSpecified
	{
		get
		{
			return errorCodeFieldSpecified;
		}
		set
		{
			errorCodeFieldSpecified = value;
			RaisePropertyChanged("errorCodeSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string sQLState
	{
		get
		{
			return sQLStateField;
		}
		set
		{
			sQLStateField = value;
			RaisePropertyChanged("sQLState");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string message
	{
		get
		{
			return messageField;
		}
		set
		{
			messageField = value;
			RaisePropertyChanged("message");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
