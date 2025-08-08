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
public class objetoPostalPK : INotifyPropertyChanged
{
	private string codigoEtiquetaField;

	private long plpNuField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string codigoEtiqueta
	{
		get
		{
			return codigoEtiquetaField;
		}
		set
		{
			codigoEtiquetaField = value;
			RaisePropertyChanged("codigoEtiqueta");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public long plpNu
	{
		get
		{
			return plpNuField;
		}
		set
		{
			plpNuField = value;
			RaisePropertyChanged("plpNu");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
