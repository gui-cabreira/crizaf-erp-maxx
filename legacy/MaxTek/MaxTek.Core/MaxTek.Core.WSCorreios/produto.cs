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
public class produto : INotifyPropertyChanged
{
	private string codigoField;

	private string qtdField;

	private string tipoField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string codigo
	{
		get
		{
			return codigoField;
		}
		set
		{
			codigoField = value;
			RaisePropertyChanged("codigo");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string qtd
	{
		get
		{
			return qtdField;
		}
		set
		{
			qtdField = value;
			RaisePropertyChanged("qtd");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string tipo
	{
		get
		{
			return tipoField;
		}
		set
		{
			tipoField = value;
			RaisePropertyChanged("tipo");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
