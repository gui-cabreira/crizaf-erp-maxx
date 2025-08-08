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
public class usuarioInstalacao : INotifyPropertyChanged
{
	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private DateTime dataInclusaoField;

	private bool dataInclusaoFieldSpecified;

	private DateTime dataSenhaField;

	private bool dataSenhaFieldSpecified;

	private gerenteConta gerenteMasterField;

	private string hashSenhaField;

	private long idField;

	private bool idFieldSpecified;

	private string loginField;

	private string nomeField;

	private parametroMaster[] parametrosField;

	private string senhaField;

	private statusUsuario statusField;

	private bool statusFieldSpecified;

	private string validadeField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public DateTime dataAtualizacao
	{
		get
		{
			return dataAtualizacaoField;
		}
		set
		{
			dataAtualizacaoField = value;
			RaisePropertyChanged("dataAtualizacao");
		}
	}

	[XmlIgnore]
	public bool dataAtualizacaoSpecified
	{
		get
		{
			return dataAtualizacaoFieldSpecified;
		}
		set
		{
			dataAtualizacaoFieldSpecified = value;
			RaisePropertyChanged("dataAtualizacaoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public DateTime dataInclusao
	{
		get
		{
			return dataInclusaoField;
		}
		set
		{
			dataInclusaoField = value;
			RaisePropertyChanged("dataInclusao");
		}
	}

	[XmlIgnore]
	public bool dataInclusaoSpecified
	{
		get
		{
			return dataInclusaoFieldSpecified;
		}
		set
		{
			dataInclusaoFieldSpecified = value;
			RaisePropertyChanged("dataInclusaoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public DateTime dataSenha
	{
		get
		{
			return dataSenhaField;
		}
		set
		{
			dataSenhaField = value;
			RaisePropertyChanged("dataSenha");
		}
	}

	[XmlIgnore]
	public bool dataSenhaSpecified
	{
		get
		{
			return dataSenhaFieldSpecified;
		}
		set
		{
			dataSenhaFieldSpecified = value;
			RaisePropertyChanged("dataSenhaSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public gerenteConta gerenteMaster
	{
		get
		{
			return gerenteMasterField;
		}
		set
		{
			gerenteMasterField = value;
			RaisePropertyChanged("gerenteMaster");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string hashSenha
	{
		get
		{
			return hashSenhaField;
		}
		set
		{
			hashSenhaField = value;
			RaisePropertyChanged("hashSenha");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public long id
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

	[XmlIgnore]
	public bool idSpecified
	{
		get
		{
			return idFieldSpecified;
		}
		set
		{
			idFieldSpecified = value;
			RaisePropertyChanged("idSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public string login
	{
		get
		{
			return loginField;
		}
		set
		{
			loginField = value;
			RaisePropertyChanged("login");
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

	[XmlElement("parametros", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 8)]
	public parametroMaster[] parametros
	{
		get
		{
			return parametrosField;
		}
		set
		{
			parametrosField = value;
			RaisePropertyChanged("parametros");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public string senha
	{
		get
		{
			return senhaField;
		}
		set
		{
			senhaField = value;
			RaisePropertyChanged("senha");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
	public statusUsuario status
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

	[XmlIgnore]
	public bool statusSpecified
	{
		get
		{
			return statusFieldSpecified;
		}
		set
		{
			statusFieldSpecified = value;
			RaisePropertyChanged("statusSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
	public string validade
	{
		get
		{
			return validadeField;
		}
		set
		{
			validadeField = value;
			RaisePropertyChanged("validade");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
