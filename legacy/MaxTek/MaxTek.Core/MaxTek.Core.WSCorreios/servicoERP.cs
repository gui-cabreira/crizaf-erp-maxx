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
public class servicoERP : INotifyPropertyChanged
{
	private string codigoField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private int datajAtualizacaoField;

	private bool datajAtualizacaoFieldSpecified;

	private string descricaoField;

	private int horajAtualizacaoField;

	private bool horajAtualizacaoFieldSpecified;

	private long idField;

	private servicoSigep servicoSigepField;

	private servicoAdicionalERP[] servicosAdicionaisField;

	private string tipo1CodigoField;

	private string tipo1DescricaoField;

	private string tipo2CodigoField;

	private string tipo2DescricaoField;

	private vigenciaERP vigenciaField;

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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public servicoSigep servicoSigep
	{
		get
		{
			return servicoSigepField;
		}
		set
		{
			servicoSigepField = value;
			RaisePropertyChanged("servicoSigep");
		}
	}

	[XmlElement("servicosAdicionais", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 7)]
	public servicoAdicionalERP[] servicosAdicionais
	{
		get
		{
			return servicosAdicionaisField;
		}
		set
		{
			servicosAdicionaisField = value;
			RaisePropertyChanged("servicosAdicionais");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string tipo1Codigo
	{
		get
		{
			return tipo1CodigoField;
		}
		set
		{
			tipo1CodigoField = value;
			RaisePropertyChanged("tipo1Codigo");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public string tipo1Descricao
	{
		get
		{
			return tipo1DescricaoField;
		}
		set
		{
			tipo1DescricaoField = value;
			RaisePropertyChanged("tipo1Descricao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
	public string tipo2Codigo
	{
		get
		{
			return tipo2CodigoField;
		}
		set
		{
			tipo2CodigoField = value;
			RaisePropertyChanged("tipo2Codigo");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
	public string tipo2Descricao
	{
		get
		{
			return tipo2DescricaoField;
		}
		set
		{
			tipo2DescricaoField = value;
			RaisePropertyChanged("tipo2Descricao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 12)]
	public vigenciaERP vigencia
	{
		get
		{
			return vigenciaField;
		}
		set
		{
			vigenciaField = value;
			RaisePropertyChanged("vigencia");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
