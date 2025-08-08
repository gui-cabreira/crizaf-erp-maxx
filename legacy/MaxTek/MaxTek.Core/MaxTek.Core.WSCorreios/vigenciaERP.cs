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
public class vigenciaERP : INotifyPropertyChanged
{
	private DateTime dataFinalField;

	private bool dataFinalFieldSpecified;

	private DateTime dataInicialField;

	private bool dataInicialFieldSpecified;

	private int datajFimField;

	private bool datajFimFieldSpecified;

	private int datajIniField;

	private bool datajIniFieldSpecified;

	private long idField;

	private bool idFieldSpecified;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public DateTime dataFinal
	{
		get
		{
			return dataFinalField;
		}
		set
		{
			dataFinalField = value;
			RaisePropertyChanged("dataFinal");
		}
	}

	[XmlIgnore]
	public bool dataFinalSpecified
	{
		get
		{
			return dataFinalFieldSpecified;
		}
		set
		{
			dataFinalFieldSpecified = value;
			RaisePropertyChanged("dataFinalSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public DateTime dataInicial
	{
		get
		{
			return dataInicialField;
		}
		set
		{
			dataInicialField = value;
			RaisePropertyChanged("dataInicial");
		}
	}

	[XmlIgnore]
	public bool dataInicialSpecified
	{
		get
		{
			return dataInicialFieldSpecified;
		}
		set
		{
			dataInicialFieldSpecified = value;
			RaisePropertyChanged("dataInicialSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public int datajFim
	{
		get
		{
			return datajFimField;
		}
		set
		{
			datajFimField = value;
			RaisePropertyChanged("datajFim");
		}
	}

	[XmlIgnore]
	public bool datajFimSpecified
	{
		get
		{
			return datajFimFieldSpecified;
		}
		set
		{
			datajFimFieldSpecified = value;
			RaisePropertyChanged("datajFimSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public int datajIni
	{
		get
		{
			return datajIniField;
		}
		set
		{
			datajIniField = value;
			RaisePropertyChanged("datajIni");
		}
	}

	[XmlIgnore]
	public bool datajIniSpecified
	{
		get
		{
			return datajIniFieldSpecified;
		}
		set
		{
			datajIniFieldSpecified = value;
			RaisePropertyChanged("datajIniSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
