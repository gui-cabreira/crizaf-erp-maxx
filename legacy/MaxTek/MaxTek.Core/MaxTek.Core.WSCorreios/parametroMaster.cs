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
public class parametroMaster : INotifyPropertyChanged
{
	private long prmCoParametroField;

	private string prmTxParametroField;

	private string prmTxValorField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public long prmCoParametro
	{
		get
		{
			return prmCoParametroField;
		}
		set
		{
			prmCoParametroField = value;
			RaisePropertyChanged("prmCoParametro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string prmTxParametro
	{
		get
		{
			return prmTxParametroField;
		}
		set
		{
			prmTxParametroField = value;
			RaisePropertyChanged("prmTxParametro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string prmTxValor
	{
		get
		{
			return prmTxValorField;
		}
		set
		{
			prmTxValorField = value;
			RaisePropertyChanged("prmTxValor");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
