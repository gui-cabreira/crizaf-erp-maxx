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
public class servicoAdicionalERP : INotifyPropertyChanged
{
	private string codigoField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private int datajAtualizacaoField;

	private bool datajAtualizacaoFieldSpecified;

	private string descricaoField;

	private int horajAtualizacaoField;

	private bool horajAtualizacaoFieldSpecified;

	private int idField;

	private bool idFieldSpecified;

	private string siglaField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string codigo
	{
		get
		{
			return codigoField;
		}
		set
		{
			codigoField = value;
			RaisePropertyChanged("codigo");
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string descricao
	{
		get
		{
			return descricaoField;
		}
		set
		{
			descricaoField = value;
			RaisePropertyChanged("descricao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public int horajAtualizacao
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public int id
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
	public string sigla
	{
		get
		{
			return siglaField;
		}
		set
		{
			siglaField = value;
			RaisePropertyChanged("sigla");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
