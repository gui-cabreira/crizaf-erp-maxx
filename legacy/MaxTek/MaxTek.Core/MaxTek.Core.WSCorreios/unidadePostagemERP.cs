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
public class unidadePostagemERP : INotifyPropertyChanged
{
	private string diretoriaRegionalField;

	private enderecoERP enderecoField;

	private string idField;

	private string nomeField;

	private string statusField;

	private string tipoField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string diretoriaRegional
	{
		get
		{
			return diretoriaRegionalField;
		}
		set
		{
			diretoriaRegionalField = value;
			RaisePropertyChanged("diretoriaRegional");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public enderecoERP endereco
	{
		get
		{
			return enderecoField;
		}
		set
		{
			enderecoField = value;
			RaisePropertyChanged("endereco");
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
	public string nome
	{
		get
		{
			return nomeField;
		}
		set
		{
			nomeField = value;
			RaisePropertyChanged("nome");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string status
	{
		get
		{
			return statusField;
		}
		set
		{
			statusField = value;
			RaisePropertyChanged("status");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
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
