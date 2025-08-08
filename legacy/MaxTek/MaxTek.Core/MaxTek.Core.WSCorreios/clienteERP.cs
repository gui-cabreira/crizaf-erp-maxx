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
public class clienteERP : INotifyPropertyChanged
{
	private string cnpjField;

	private contratoERP[] contratosField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private int datajAtualizacaoField;

	private bool datajAtualizacaoFieldSpecified;

	private string descricaoStatusClienteField;

	private gerenteConta[] gerenteContaField;

	private long horajAtualizacaoField;

	private bool horajAtualizacaoFieldSpecified;

	private long idField;

	private string inscricaoEstadualField;

	private string nomeField;

	private string statusCodigoField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string cnpj
	{
		get
		{
			return cnpjField;
		}
		set
		{
			cnpjField = value;
			RaisePropertyChanged("cnpj");
		}
	}

	[XmlElement("contratos", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 1)]
	public contratoERP[] contratos
	{
		get
		{
			return contratosField;
		}
		set
		{
			contratosField = value;
			RaisePropertyChanged("contratos");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public int datajAtualizacao
	{
		get
		{
			return datajAtualizacaoField;
		}
		set
		{
			datajAtualizacaoField = value;
			RaisePropertyChanged("datajAtualizacao");
		}
	}

	[XmlIgnore]
	public bool datajAtualizacaoSpecified
	{
		get
		{
			return datajAtualizacaoFieldSpecified;
		}
		set
		{
			datajAtualizacaoFieldSpecified = value;
			RaisePropertyChanged("datajAtualizacaoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string descricaoStatusCliente
	{
		get
		{
			return descricaoStatusClienteField;
		}
		set
		{
			descricaoStatusClienteField = value;
			RaisePropertyChanged("descricaoStatusCliente");
		}
	}

	[XmlElement("gerenteConta", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 5)]
	public gerenteConta[] gerenteConta
	{
		get
		{
			return gerenteContaField;
		}
		set
		{
			gerenteContaField = value;
			RaisePropertyChanged("gerenteConta");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public long horajAtualizacao
	{
		get
		{
			return horajAtualizacaoField;
		}
		set
		{
			horajAtualizacaoField = value;
			RaisePropertyChanged("horajAtualizacao");
		}
	}

	[XmlIgnore]
	public bool horajAtualizacaoSpecified
	{
		get
		{
			return horajAtualizacaoFieldSpecified;
		}
		set
		{
			horajAtualizacaoFieldSpecified = value;
			RaisePropertyChanged("horajAtualizacaoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string inscricaoEstadual
	{
		get
		{
			return inscricaoEstadualField;
		}
		set
		{
			inscricaoEstadualField = value;
			RaisePropertyChanged("inscricaoEstadual");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
	public string statusCodigo
	{
		get
		{
			return statusCodigoField;
		}
		set
		{
			statusCodigoField = value;
			RaisePropertyChanged("statusCodigo");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
