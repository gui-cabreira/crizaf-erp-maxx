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
public class contratoERP : INotifyPropertyChanged
{
	private cartaoPostagemERP[] cartoesPostagemField;

	private clienteERP clienteField;

	private long codigoClienteField;

	private string codigoDiretoriaField;

	private contratoERPPK contratoPKField;

	private DateTime dataAtualizacaoField;

	private bool dataAtualizacaoFieldSpecified;

	private string dataAtualizacaoDDMMYYYYField;

	private DateTime dataVigenciaFimField;

	private bool dataVigenciaFimFieldSpecified;

	private string dataVigenciaFimDDMMYYYYField;

	private DateTime dataVigenciaInicioField;

	private bool dataVigenciaInicioFieldSpecified;

	private string dataVigenciaInicioDDMMYYYYField;

	private int datajAtualizacaoField;

	private bool datajAtualizacaoFieldSpecified;

	private int datajVigenciaFimField;

	private bool datajVigenciaFimFieldSpecified;

	private int datajVigenciaInicioField;

	private bool datajVigenciaInicioFieldSpecified;

	private string descricaoDiretoriaRegionalField;

	private string descricaoStatusField;

	private unidadePostagemERP diretoriaRegionalField;

	private int horajAtualizacaoField;

	private bool horajAtualizacaoFieldSpecified;

	private string statusCodigoField;

	[XmlElement("cartoesPostagem", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 0)]
	public cartaoPostagemERP[] cartoesPostagem
	{
		get
		{
			return cartoesPostagemField;
		}
		set
		{
			cartoesPostagemField = value;
			RaisePropertyChanged("cartoesPostagem");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public clienteERP cliente
	{
		get
		{
			return clienteField;
		}
		set
		{
			clienteField = value;
			RaisePropertyChanged("cliente");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public long codigoCliente
	{
		get
		{
			return codigoClienteField;
		}
		set
		{
			codigoClienteField = value;
			RaisePropertyChanged("codigoCliente");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string codigoDiretoria
	{
		get
		{
			return codigoDiretoriaField;
		}
		set
		{
			codigoDiretoriaField = value;
			RaisePropertyChanged("codigoDiretoria");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public contratoERPPK contratoPK
	{
		get
		{
			return contratoPKField;
		}
		set
		{
			contratoPKField = value;
			RaisePropertyChanged("contratoPK");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public string dataAtualizacaoDDMMYYYY
	{
		get
		{
			return dataAtualizacaoDDMMYYYYField;
		}
		set
		{
			dataAtualizacaoDDMMYYYYField = value;
			RaisePropertyChanged("dataAtualizacaoDDMMYYYY");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string dataVigenciaFimDDMMYYYY
	{
		get
		{
			return dataVigenciaFimDDMMYYYYField;
		}
		set
		{
			dataVigenciaFimDDMMYYYYField = value;
			RaisePropertyChanged("dataVigenciaFimDDMMYYYY");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
	public string dataVigenciaInicioDDMMYYYY
	{
		get
		{
			return dataVigenciaInicioDDMMYYYYField;
		}
		set
		{
			dataVigenciaInicioDDMMYYYYField = value;
			RaisePropertyChanged("dataVigenciaInicioDDMMYYYY");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 12)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 13)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 14)]
	public string descricaoDiretoriaRegional
	{
		get
		{
			return descricaoDiretoriaRegionalField;
		}
		set
		{
			descricaoDiretoriaRegionalField = value;
			RaisePropertyChanged("descricaoDiretoriaRegional");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 15)]
	public string descricaoStatus
	{
		get
		{
			return descricaoStatusField;
		}
		set
		{
			descricaoStatusField = value;
			RaisePropertyChanged("descricaoStatus");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 16)]
	public unidadePostagemERP diretoriaRegional
	{
		get
		{
			return diretoriaRegionalField;
		}
		set
		{
			diretoriaRegionalField = value;
			RaisePropertyChanged("diretoriaRegional");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 17)]
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 18)]
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
