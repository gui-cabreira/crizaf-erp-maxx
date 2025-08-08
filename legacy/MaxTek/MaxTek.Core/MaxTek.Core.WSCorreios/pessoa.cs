using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MaxTek.Core.WSCorreios;

[Serializable]
[XmlInclude(typeof(remetente))]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/")]
public class pessoa : INotifyPropertyChanged
{
	private string bairroField;

	private string cepField;

	private string cidadeField;

	private string complementoField;

	private string dddField;

	private string emailField;

	private string logradouroField;

	private string nomeField;

	private string numeroField;

	private string referenciaField;

	private string telefoneField;

	private string ufField;

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
	public string complemento
	{
		get
		{
			return complementoField;
		}
		set
		{
			complementoField = value;
			RaisePropertyChanged("complemento");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string ddd
	{
		get
		{
			return dddField;
		}
		set
		{
			dddField = value;
			RaisePropertyChanged("ddd");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public string email
	{
		get
		{
			return emailField;
		}
		set
		{
			emailField = value;
			RaisePropertyChanged("email");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public string logradouro
	{
		get
		{
			return logradouroField;
		}
		set
		{
			logradouroField = value;
			RaisePropertyChanged("logradouro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string numero
	{
		get
		{
			return numeroField;
		}
		set
		{
			numeroField = value;
			RaisePropertyChanged("numero");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public string referencia
	{
		get
		{
			return referenciaField;
		}
		set
		{
			referenciaField = value;
			RaisePropertyChanged("referencia");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
	public string telefone
	{
		get
		{
			return telefoneField;
		}
		set
		{
			telefoneField = value;
			RaisePropertyChanged("telefone");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
