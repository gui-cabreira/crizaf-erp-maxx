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
public class enderecoERP : INotifyPropertyChanged
{
	private string bairroField;

	private string cepField;

	private string cidadeField;

	private string complemento2Field;

	private string endField;

	private string ufField;

	private unidadePostagemERP[] unidadesPostagemField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string bairro
	{
		get
		{
			return bairroField;
		}
		set
		{
			bairroField = value;
			RaisePropertyChanged("bairro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string cep
	{
		get
		{
			return cepField;
		}
		set
		{
			cepField = value;
			RaisePropertyChanged("cep");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string cidade
	{
		get
		{
			return cidadeField;
		}
		set
		{
			cidadeField = value;
			RaisePropertyChanged("cidade");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string complemento2
	{
		get
		{
			return complemento2Field;
		}
		set
		{
			complemento2Field = value;
			RaisePropertyChanged("complemento2");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string end
	{
		get
		{
			return endField;
		}
		set
		{
			endField = value;
			RaisePropertyChanged("end");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public string uf
	{
		get
		{
			return ufField;
		}
		set
		{
			ufField = value;
			RaisePropertyChanged("uf");
		}
	}

	[XmlElement("unidadesPostagem", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 6)]
	public unidadePostagemERP[] unidadesPostagem
	{
		get
		{
			return unidadesPostagemField;
		}
		set
		{
			unidadesPostagemField = value;
			RaisePropertyChanged("unidadesPostagem");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
