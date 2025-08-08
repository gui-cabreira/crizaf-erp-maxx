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
public class objetoPostal : INotifyPropertyChanged
{
	private string codigoEtiquetaField;

	private DateTime dataAtualizacaoClienteField;

	private bool dataAtualizacaoClienteFieldSpecified;

	private DateTime dataBloqueioObjetoField;

	private bool dataBloqueioObjetoFieldSpecified;

	private DateTime dataCancelamentoEtiquetaField;

	private bool dataCancelamentoEtiquetaFieldSpecified;

	private DateTime dataInclusaoField;

	private bool dataInclusaoFieldSpecified;

	private objetoPostalPK objetoPostalPKField;

	private long plpNuField;

	private bool plpNuFieldSpecified;

	private preListaPostagem preListaPostagemField;

	private string statusBloqueioField;

	private statusObjetoPostal statusEtiquetaField;

	private bool statusEtiquetaFieldSpecified;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string codigoEtiqueta
	{
		get
		{
			return codigoEtiquetaField;
		}
		set
		{
			codigoEtiquetaField = value;
			RaisePropertyChanged("codigoEtiqueta");
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
	public DateTime dataBloqueioObjeto
	{
		get
		{
			return dataBloqueioObjetoField;
		}
		set
		{
			dataBloqueioObjetoField = value;
			RaisePropertyChanged("dataBloqueioObjeto");
		}
	}

	[XmlIgnore]
	public bool dataBloqueioObjetoSpecified
	{
		get
		{
			return dataBloqueioObjetoFieldSpecified;
		}
		set
		{
			dataBloqueioObjetoFieldSpecified = value;
			RaisePropertyChanged("dataBloqueioObjetoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public DateTime dataCancelamentoEtiqueta
	{
		get
		{
			return dataCancelamentoEtiquetaField;
		}
		set
		{
			dataCancelamentoEtiquetaField = value;
			RaisePropertyChanged("dataCancelamentoEtiqueta");
		}
	}

	[XmlIgnore]
	public bool dataCancelamentoEtiquetaSpecified
	{
		get
		{
			return dataCancelamentoEtiquetaFieldSpecified;
		}
		set
		{
			dataCancelamentoEtiquetaFieldSpecified = value;
			RaisePropertyChanged("dataCancelamentoEtiquetaSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public objetoPostalPK objetoPostalPK
	{
		get
		{
			return objetoPostalPKField;
		}
		set
		{
			objetoPostalPKField = value;
			RaisePropertyChanged("objetoPostalPK");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
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

	[XmlIgnore]
	public bool plpNuSpecified
	{
		get
		{
			return plpNuFieldSpecified;
		}
		set
		{
			plpNuFieldSpecified = value;
			RaisePropertyChanged("plpNuSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public preListaPostagem preListaPostagem
	{
		get
		{
			return preListaPostagemField;
		}
		set
		{
			preListaPostagemField = value;
			RaisePropertyChanged("preListaPostagem");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string statusBloqueio
	{
		get
		{
			return statusBloqueioField;
		}
		set
		{
			statusBloqueioField = value;
			RaisePropertyChanged("statusBloqueio");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public statusObjetoPostal statusEtiqueta
	{
		get
		{
			return statusEtiquetaField;
		}
		set
		{
			statusEtiquetaField = value;
			RaisePropertyChanged("statusEtiqueta");
		}
	}

	[XmlIgnore]
	public bool statusEtiquetaSpecified
	{
		get
		{
			return statusEtiquetaFieldSpecified;
		}
		set
		{
			statusEtiquetaFieldSpecified = value;
			RaisePropertyChanged("statusEtiquetaSpecified");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
