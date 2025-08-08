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
public class objeto : INotifyPropertyChanged
{
	private string descField;

	private string entregaField;

	private string idField;

	private string itemField;

	private string numField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string desc
	{
		get
		{
			return descField;
		}
		set
		{
			descField = value;
			RaisePropertyChanged("desc");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string entrega
	{
		get
		{
			return entregaField;
		}
		set
		{
			entregaField = value;
			RaisePropertyChanged("entrega");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string id
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
			RaisePropertyChanged("id");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string item
	{
		get
		{
			return itemField;
		}
		set
		{
			itemField = value;
			RaisePropertyChanged("item");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string num
	{
		get
		{
			return numField;
		}
		set
		{
			numField = value;
			RaisePropertyChanged("num");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
