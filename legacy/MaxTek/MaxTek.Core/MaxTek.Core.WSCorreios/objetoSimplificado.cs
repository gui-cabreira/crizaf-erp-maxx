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
public class objetoSimplificado : INotifyPropertyChanged
{
	private string datahora_cancelamentoField;

	private int numero_pedidoField;

	private bool numero_pedidoFieldSpecified;

	private string status_pedidoField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string datahora_cancelamento
	{
		get
		{
			return datahora_cancelamentoField;
		}
		set
		{
			datahora_cancelamentoField = value;
			RaisePropertyChanged("datahora_cancelamento");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public int numero_pedido
	{
		get
		{
			return numero_pedidoField;
		}
		set
		{
			numero_pedidoField = value;
			RaisePropertyChanged("numero_pedido");
		}
	}

	[XmlIgnore]
	public bool numero_pedidoSpecified
	{
		get
		{
			return numero_pedidoFieldSpecified;
		}
		set
		{
			numero_pedidoFieldSpecified = value;
			RaisePropertyChanged("numero_pedidoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string status_pedido
	{
		get
		{
			return status_pedidoField;
		}
		set
		{
			status_pedidoField = value;
			RaisePropertyChanged("status_pedido");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
