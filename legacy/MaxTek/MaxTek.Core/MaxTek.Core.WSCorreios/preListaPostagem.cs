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
public class preListaPostagem : INotifyPropertyChanged
{
	private cartaoPostagemERP cartaoPostagemField;

	private DateTime dataAtualizacaoClienteField;

	private bool dataAtualizacaoClienteFieldSpecified;

	private DateTime dataAtualizacaoSaraField;

	private bool dataAtualizacaoSaraFieldSpecified;

	private DateTime dataFechamentoField;

	private bool dataFechamentoFieldSpecified;

	private DateTime dataPostagemField;

	private bool dataPostagemFieldSpecified;

	private DateTime dataPostagemSaraField;

	private bool dataPostagemSaraFieldSpecified;

	private objetoPostal[] objetosPostaisField;

	private long plpClienteField;

	private long plpNuField;

	private ushort?[] plpXmlField;

	private ushort?[] plpXmlRetornoField;

	private statusPlp statusField;

	private bool statusFieldSpecified;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public cartaoPostagemERP cartaoPostagem
	{
		get
		{
			return cartaoPostagemField;
		}
		set
		{
			cartaoPostagemField = value;
			RaisePropertyChanged("cartaoPostagem");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public DateTime dataAtualizacaoCliente
	{
		get
		{
			return dataAtualizacaoClienteField;
		}
		set
		{
			dataAtualizacaoClienteField = value;
			RaisePropertyChanged("dataAtualizacaoCliente");
		}
	}

	[XmlIgnore]
	public bool dataAtualizacaoClienteSpecified
	{
		get
		{
			return dataAtualizacaoClienteFieldSpecified;
		}
		set
		{
			dataAtualizacaoClienteFieldSpecified = value;
			RaisePropertyChanged("dataAtualizacaoClienteSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public DateTime dataAtualizacaoSara
	{
		get
		{
			return dataAtualizacaoSaraField;
		}
		set
		{
			dataAtualizacaoSaraField = value;
			RaisePropertyChanged("dataAtualizacaoSara");
		}
	}

	[XmlIgnore]
	public bool dataAtualizacaoSaraSpecified
	{
		get
		{
			return dataAtualizacaoSaraFieldSpecified;
		}
		set
		{
			dataAtualizacaoSaraFieldSpecified = value;
			RaisePropertyChanged("dataAtualizacaoSaraSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public DateTime dataFechamento
	{
		get
		{
			return dataFechamentoField;
		}
		set
		{
			dataFechamentoField = value;
			RaisePropertyChanged("dataFechamento");
		}
	}

	[XmlIgnore]
	public bool dataFechamentoSpecified
	{
		get
		{
			return dataFechamentoFieldSpecified;
		}
		set
		{
			dataFechamentoFieldSpecified = value;
			RaisePropertyChanged("dataFechamentoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public DateTime dataPostagem
	{
		get
		{
			return dataPostagemField;
		}
		set
		{
			dataPostagemField = value;
			RaisePropertyChanged("dataPostagem");
		}
	}

	[XmlIgnore]
	public bool dataPostagemSpecified
	{
		get
		{
			return dataPostagemFieldSpecified;
		}
		set
		{
			dataPostagemFieldSpecified = value;
			RaisePropertyChanged("dataPostagemSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public DateTime dataPostagemSara
	{
		get
		{
			return dataPostagemSaraField;
		}
		set
		{
			dataPostagemSaraField = value;
			RaisePropertyChanged("dataPostagemSara");
		}
	}

	[XmlIgnore]
	public bool dataPostagemSaraSpecified
	{
		get
		{
			return dataPostagemSaraFieldSpecified;
		}
		set
		{
			dataPostagemSaraFieldSpecified = value;
			RaisePropertyChanged("dataPostagemSaraSpecified");
		}
	}

	[XmlElement("objetosPostais", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 6)]
	public objetoPostal[] objetosPostais
	{
		get
		{
			return objetosPostaisField;
		}
		set
		{
			objetosPostaisField = value;
			RaisePropertyChanged("objetosPostais");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public long plpCliente
	{
		get
		{
			return plpClienteField;
		}
		set
		{
			plpClienteField = value;
			RaisePropertyChanged("plpCliente");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public long plpNu
	{
		get
		{
			return plpNuField;
		}
		set
		{
			plpNuField = value;
			RaisePropertyChanged("plpNu");
		}
	}

	[XmlElement("plpXml", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 9)]
	public ushort?[] plpXml
	{
		get
		{
			return plpXmlField;
		}
		set
		{
			plpXmlField = value;
			RaisePropertyChanged("plpXml");
		}
	}

	[XmlElement("plpXmlRetorno", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 10)]
	public ushort?[] plpXmlRetorno
	{
		get
		{
			return plpXmlRetornoField;
		}
		set
		{
			plpXmlRetornoField = value;
			RaisePropertyChanged("plpXmlRetorno");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
	public statusPlp status
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

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
