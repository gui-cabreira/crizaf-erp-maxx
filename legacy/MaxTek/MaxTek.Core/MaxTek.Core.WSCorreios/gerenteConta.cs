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
public class gerenteConta : INotifyPropertyChanged
{
	private clienteERP[] clientesVisiveisField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private DateTime dataInclusaoField;

	private bool dataInclusaoFieldSpecified;

	private DateTime dataSenhaField;

	private bool dataSenhaFieldSpecified;

	private string loginField;

	private string matriculaField;

	private string senhaField;

	private statusGerente statusField;

	private bool statusFieldSpecified;

	private tipoGerente tipoGerenteField;

	private bool tipoGerenteFieldSpecified;

	private usuarioInstalacao[] usuariosInstalacaoField;

	private string validadeField;

	[XmlElement("clientesVisiveis", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 0)]
	public clienteERP[] clientesVisiveis
	{
		get
		{
			return clientesVisiveisField;
		}
		set
		{
			clientesVisiveisField = value;
			RaisePropertyChanged("clientesVisiveis");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public string matricula
	{
		get
		{
			return matriculaField;
		}
		set
		{
			matriculaField = value;
			RaisePropertyChanged("matricula");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public statusGerente status
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public tipoGerente tipoGerente
	{
		get
		{
			return tipoGerenteField;
		}
		set
		{
			tipoGerenteField = value;
			RaisePropertyChanged("tipoGerente");
		}
	}

	[XmlIgnore]
	public bool tipoGerenteSpecified
	{
		get
		{
			return tipoGerenteFieldSpecified;
		}
		set
		{
			tipoGerenteFieldSpecified = value;
			RaisePropertyChanged("tipoGerenteSpecified");
		}
	}

	[XmlElement("usuariosInstalacao", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 9)]
	public usuarioInstalacao[] usuariosInstalacao
	{
		get
		{
			return usuariosInstalacaoField;
		}
		set
		{
			usuariosInstalacaoField = value;
			RaisePropertyChanged("usuariosInstalacao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
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
