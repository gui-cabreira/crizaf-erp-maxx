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
public class retornoCancelamento : INotifyPropertyChanged
{
	private string cod_erroField;

	private string codigo_administrativoField;

	private string dataField;

	private string horaField;

	private string msg_erroField;

	private objetoSimplificado objeto_postalField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string cod_erro
	{
		get
		{
			return cod_erroField;
		}
		set
		{
			cod_erroField = value;
			RaisePropertyChanged("cod_erro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string codigo_administrativo
	{
		get
		{
			return codigo_administrativoField;
		}
		set
		{
			codigo_administrativoField = value;
			RaisePropertyChanged("codigo_administrativo");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string data
	{
		get
		{
			return dataField;
		}
		set
		{
			dataField = value;
			RaisePropertyChanged("data");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string hora
	{
		get
		{
			return horaField;
		}
		set
		{
			horaField = value;
			RaisePropertyChanged("hora");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string msg_erro
	{
		get
		{
			return msg_erroField;
		}
		set
		{
			msg_erroField = value;
			RaisePropertyChanged("msg_erro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public objetoSimplificado objeto_postal
	{
		get
		{
			return objeto_postalField;
		}
		set
		{
			objeto_postalField = value;
			RaisePropertyChanged("objeto_postal");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
