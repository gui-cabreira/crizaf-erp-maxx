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
public class chancelaMaster : INotifyPropertyChanged
{
	private byte[] chancelaField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private string descricaoField;

	private long idField;

	private servicoSigep[] servicosSigepField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 0)]
	public byte[] chancela
	{
		get
		{
			return chancelaField;
		}
		set
		{
			chancelaField = value;
			RaisePropertyChanged("chancela");
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
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

	[XmlElement("servicosSigep", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 4)]
	public servicoSigep[] servicosSigep
	{
		get
		{
			return servicosSigepField;
		}
		set
		{
			servicosSigepField = value;
			RaisePropertyChanged("servicosSigep");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
