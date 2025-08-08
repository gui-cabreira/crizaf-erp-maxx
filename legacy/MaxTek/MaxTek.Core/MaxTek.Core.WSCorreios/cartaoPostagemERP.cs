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
public class cartaoPostagemERP : INotifyPropertyChanged
{
	private string codigoAdministrativoField;

	private contratoERP[] contratosField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private DateTime dataVigenciaFimField;

	private bool dataVigenciaFimFieldSpecified;

	private DateTime dataVigenciaInicioField;

	private bool dataVigenciaInicioFieldSpecified;

	private int datajAtualizacaoField;

	private bool datajAtualizacaoFieldSpecified;

	private int datajVigenciaFimField;

	private bool datajVigenciaFimFieldSpecified;

	private int datajVigenciaInicioField;

	private bool datajVigenciaInicioFieldSpecified;

	private string descricaoStatusCartaoField;

	private string descricaoUnidadePostagemGenericaField;

	private int horajAtualizacaoField;

	private bool horajAtualizacaoFieldSpecified;

	private string numeroField;

	private servicoERP[] servicosField;

	private string statusCartaoPostagemField;

	private string statusCodigoField;

	private string unidadeGenericaField;

	private unidadePostagemERP[] unidadesPostagemField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string codigoAdministrativo
	{
		get
		{
			return codigoAdministrativoField;
		}
		set
		{
			codigoAdministrativoField = value;
			RaisePropertyChanged("codigoAdministrativo");
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
	public DateTime dataVigenciaFim
	{
		get
		{
			return dataVigenciaFimField;
		}
		set
		{
			dataVigenciaFimField = value;
			RaisePropertyChanged("dataVigenciaFim");
		}
	}

	[XmlIgnore]
	public bool dataVigenciaFimSpecified
	{
		get
		{
			return dataVigenciaFimFieldSpecified;
		}
		set
		{
			dataVigenciaFimFieldSpecified = value;
			RaisePropertyChanged("dataVigenciaFimSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public DateTime dataVigenciaInicio
	{
		get
		{
			return dataVigenciaInicioField;
		}
		set
		{
			dataVigenciaInicioField = value;
			RaisePropertyChanged("dataVigenciaInicio");
		}
	}

	[XmlIgnore]
	public bool dataVigenciaInicioSpecified
	{
		get
		{
			return dataVigenciaInicioFieldSpecified;
		}
		set
		{
			dataVigenciaInicioFieldSpecified = value;
			RaisePropertyChanged("dataVigenciaInicioSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public int datajVigenciaFim
	{
		get
		{
			return datajVigenciaFimField;
		}
		set
		{
			datajVigenciaFimField = value;
			RaisePropertyChanged("datajVigenciaFim");
		}
	}

	[XmlIgnore]
	public bool datajVigenciaFimSpecified
	{
		get
		{
			return datajVigenciaFimFieldSpecified;
		}
		set
		{
			datajVigenciaFimFieldSpecified = value;
			RaisePropertyChanged("datajVigenciaFimSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public int datajVigenciaInicio
	{
		get
		{
			return datajVigenciaInicioField;
		}
		set
		{
			datajVigenciaInicioField = value;
			RaisePropertyChanged("datajVigenciaInicio");
		}
	}

	[XmlIgnore]
	public bool datajVigenciaInicioSpecified
	{
		get
		{
			return datajVigenciaInicioFieldSpecified;
		}
		set
		{
			datajVigenciaInicioFieldSpecified = value;
			RaisePropertyChanged("datajVigenciaInicioSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string descricaoStatusCartao
	{
		get
		{
			return descricaoStatusCartaoField;
		}
		set
		{
			descricaoStatusCartaoField = value;
			RaisePropertyChanged("descricaoStatusCartao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public string descricaoUnidadePostagemGenerica
	{
		get
		{
			return descricaoUnidadePostagemGenericaField;
		}
		set
		{
			descricaoUnidadePostagemGenericaField = value;
			RaisePropertyChanged("descricaoUnidadePostagemGenerica");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
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

	[XmlElement("servicos", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 12)]
	public servicoERP[] servicos
	{
		get
		{
			return servicosField;
		}
		set
		{
			servicosField = value;
			RaisePropertyChanged("servicos");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 13)]
	public string statusCartaoPostagem
	{
		get
		{
			return statusCartaoPostagemField;
		}
		set
		{
			statusCartaoPostagemField = value;
			RaisePropertyChanged("statusCartaoPostagem");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 14)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 15)]
	public string unidadeGenerica
	{
		get
		{
			return unidadeGenericaField;
		}
		set
		{
			unidadeGenericaField = value;
			RaisePropertyChanged("unidadeGenerica");
		}
	}

	[XmlElement("unidadesPostagem", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 16)]
	public unidadePostagemERP[] unidadesPostagem
	{
		get
		{
			return unidadesPostagemField;
		}
		set
		{
			unidadesPostagemField = value;
			RaisePropertyChanged("unidadesPostagem");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
