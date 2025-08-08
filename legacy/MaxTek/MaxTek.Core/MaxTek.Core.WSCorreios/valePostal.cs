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
public class valePostal : INotifyPropertyChanged
{
	private string cidNoCidadeField;

	private string ctcCoAadministrativoField;

	private long ctcNuContratoField;

	private bool ctcNuContratoFieldSpecified;

	private long ctcNuContratoEctField;

	private bool ctcNuContratoEctFieldSpecified;

	private string cvpEdBairroField;

	private string cvpEdClienteField;

	private string cvpEdComplementoField;

	private string cvpEdNumeroField;

	private string cvpNoClienteField;

	private long cvpNuCepField;

	private bool cvpNuCepFieldSpecified;

	private string descricaoErroField;

	private string estSgEstadoField;

	private int monVarTarifaAdicionalField;

	private int monVarTarifaServicoField;

	private int monVarValorDescontosField;

	private int monVarValorImpostoField;

	private long prsCoProdutoServicoField;

	private bool prsCoProdutoServicoFieldSpecified;

	private long pveNuField;

	private bool pveNuFieldSpecified;

	private long pveOrgNuAgenciaField;

	private bool pveOrgNuAgenciaFieldSpecified;

	private long pveOrgNuAgenciaDesField;

	private bool pveOrgNuAgenciaDesFieldSpecified;

	private long pveOrgNuAgenciaOriField;

	private bool pveOrgNuAgenciaOriFieldSpecified;

	private int retornaCodErroField;

	private string sitNoSituacaoField;

	private string tlgTxDescricaoField;

	private DateTime vapDhTransacaoField;

	private bool vapDhTransacaoFieldSpecified;

	private string vapNuEtiquetaEncomendaField;

	private double vapVrCobradoEctField;

	private bool vapVrCobradoEctFieldSpecified;

	private double vapVrNominalField;

	private bool vapVrNominalFieldSpecified;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string cidNoCidade
	{
		get
		{
			return cidNoCidadeField;
		}
		set
		{
			cidNoCidadeField = value;
			RaisePropertyChanged("cidNoCidade");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public string ctcCoAadministrativo
	{
		get
		{
			return ctcCoAadministrativoField;
		}
		set
		{
			ctcCoAadministrativoField = value;
			RaisePropertyChanged("ctcCoAadministrativo");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public long ctcNuContrato
	{
		get
		{
			return ctcNuContratoField;
		}
		set
		{
			ctcNuContratoField = value;
			RaisePropertyChanged("ctcNuContrato");
		}
	}

	[XmlIgnore]
	public bool ctcNuContratoSpecified
	{
		get
		{
			return ctcNuContratoFieldSpecified;
		}
		set
		{
			ctcNuContratoFieldSpecified = value;
			RaisePropertyChanged("ctcNuContratoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public long ctcNuContratoEct
	{
		get
		{
			return ctcNuContratoEctField;
		}
		set
		{
			ctcNuContratoEctField = value;
			RaisePropertyChanged("ctcNuContratoEct");
		}
	}

	[XmlIgnore]
	public bool ctcNuContratoEctSpecified
	{
		get
		{
			return ctcNuContratoEctFieldSpecified;
		}
		set
		{
			ctcNuContratoEctFieldSpecified = value;
			RaisePropertyChanged("ctcNuContratoEctSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public string cvpEdBairro
	{
		get
		{
			return cvpEdBairroField;
		}
		set
		{
			cvpEdBairroField = value;
			RaisePropertyChanged("cvpEdBairro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public string cvpEdCliente
	{
		get
		{
			return cvpEdClienteField;
		}
		set
		{
			cvpEdClienteField = value;
			RaisePropertyChanged("cvpEdCliente");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public string cvpEdComplemento
	{
		get
		{
			return cvpEdComplementoField;
		}
		set
		{
			cvpEdComplementoField = value;
			RaisePropertyChanged("cvpEdComplemento");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public string cvpEdNumero
	{
		get
		{
			return cvpEdNumeroField;
		}
		set
		{
			cvpEdNumeroField = value;
			RaisePropertyChanged("cvpEdNumero");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public string cvpNoCliente
	{
		get
		{
			return cvpNoClienteField;
		}
		set
		{
			cvpNoClienteField = value;
			RaisePropertyChanged("cvpNoCliente");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public long cvpNuCep
	{
		get
		{
			return cvpNuCepField;
		}
		set
		{
			cvpNuCepField = value;
			RaisePropertyChanged("cvpNuCep");
		}
	}

	[XmlIgnore]
	public bool cvpNuCepSpecified
	{
		get
		{
			return cvpNuCepFieldSpecified;
		}
		set
		{
			cvpNuCepFieldSpecified = value;
			RaisePropertyChanged("cvpNuCepSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 10)]
	public string descricaoErro
	{
		get
		{
			return descricaoErroField;
		}
		set
		{
			descricaoErroField = value;
			RaisePropertyChanged("descricaoErro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 11)]
	public string estSgEstado
	{
		get
		{
			return estSgEstadoField;
		}
		set
		{
			estSgEstadoField = value;
			RaisePropertyChanged("estSgEstado");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 12)]
	public int monVarTarifaAdicional
	{
		get
		{
			return monVarTarifaAdicionalField;
		}
		set
		{
			monVarTarifaAdicionalField = value;
			RaisePropertyChanged("monVarTarifaAdicional");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 13)]
	public int monVarTarifaServico
	{
		get
		{
			return monVarTarifaServicoField;
		}
		set
		{
			monVarTarifaServicoField = value;
			RaisePropertyChanged("monVarTarifaServico");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 14)]
	public int monVarValorDescontos
	{
		get
		{
			return monVarValorDescontosField;
		}
		set
		{
			monVarValorDescontosField = value;
			RaisePropertyChanged("monVarValorDescontos");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 15)]
	public int monVarValorImposto
	{
		get
		{
			return monVarValorImpostoField;
		}
		set
		{
			monVarValorImpostoField = value;
			RaisePropertyChanged("monVarValorImposto");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 16)]
	public long prsCoProdutoServico
	{
		get
		{
			return prsCoProdutoServicoField;
		}
		set
		{
			prsCoProdutoServicoField = value;
			RaisePropertyChanged("prsCoProdutoServico");
		}
	}

	[XmlIgnore]
	public bool prsCoProdutoServicoSpecified
	{
		get
		{
			return prsCoProdutoServicoFieldSpecified;
		}
		set
		{
			prsCoProdutoServicoFieldSpecified = value;
			RaisePropertyChanged("prsCoProdutoServicoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 17)]
	public long pveNu
	{
		get
		{
			return pveNuField;
		}
		set
		{
			pveNuField = value;
			RaisePropertyChanged("pveNu");
		}
	}

	[XmlIgnore]
	public bool pveNuSpecified
	{
		get
		{
			return pveNuFieldSpecified;
		}
		set
		{
			pveNuFieldSpecified = value;
			RaisePropertyChanged("pveNuSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 18)]
	public long pveOrgNuAgencia
	{
		get
		{
			return pveOrgNuAgenciaField;
		}
		set
		{
			pveOrgNuAgenciaField = value;
			RaisePropertyChanged("pveOrgNuAgencia");
		}
	}

	[XmlIgnore]
	public bool pveOrgNuAgenciaSpecified
	{
		get
		{
			return pveOrgNuAgenciaFieldSpecified;
		}
		set
		{
			pveOrgNuAgenciaFieldSpecified = value;
			RaisePropertyChanged("pveOrgNuAgenciaSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 19)]
	public long pveOrgNuAgenciaDes
	{
		get
		{
			return pveOrgNuAgenciaDesField;
		}
		set
		{
			pveOrgNuAgenciaDesField = value;
			RaisePropertyChanged("pveOrgNuAgenciaDes");
		}
	}

	[XmlIgnore]
	public bool pveOrgNuAgenciaDesSpecified
	{
		get
		{
			return pveOrgNuAgenciaDesFieldSpecified;
		}
		set
		{
			pveOrgNuAgenciaDesFieldSpecified = value;
			RaisePropertyChanged("pveOrgNuAgenciaDesSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 20)]
	public long pveOrgNuAgenciaOri
	{
		get
		{
			return pveOrgNuAgenciaOriField;
		}
		set
		{
			pveOrgNuAgenciaOriField = value;
			RaisePropertyChanged("pveOrgNuAgenciaOri");
		}
	}

	[XmlIgnore]
	public bool pveOrgNuAgenciaOriSpecified
	{
		get
		{
			return pveOrgNuAgenciaOriFieldSpecified;
		}
		set
		{
			pveOrgNuAgenciaOriFieldSpecified = value;
			RaisePropertyChanged("pveOrgNuAgenciaOriSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 21)]
	public int retornaCodErro
	{
		get
		{
			return retornaCodErroField;
		}
		set
		{
			retornaCodErroField = value;
			RaisePropertyChanged("retornaCodErro");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 22)]
	public string sitNoSituacao
	{
		get
		{
			return sitNoSituacaoField;
		}
		set
		{
			sitNoSituacaoField = value;
			RaisePropertyChanged("sitNoSituacao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 23)]
	public string tlgTxDescricao
	{
		get
		{
			return tlgTxDescricaoField;
		}
		set
		{
			tlgTxDescricaoField = value;
			RaisePropertyChanged("tlgTxDescricao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 24)]
	public DateTime vapDhTransacao
	{
		get
		{
			return vapDhTransacaoField;
		}
		set
		{
			vapDhTransacaoField = value;
			RaisePropertyChanged("vapDhTransacao");
		}
	}

	[XmlIgnore]
	public bool vapDhTransacaoSpecified
	{
		get
		{
			return vapDhTransacaoFieldSpecified;
		}
		set
		{
			vapDhTransacaoFieldSpecified = value;
			RaisePropertyChanged("vapDhTransacaoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 25)]
	public string vapNuEtiquetaEncomenda
	{
		get
		{
			return vapNuEtiquetaEncomendaField;
		}
		set
		{
			vapNuEtiquetaEncomendaField = value;
			RaisePropertyChanged("vapNuEtiquetaEncomenda");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 26)]
	public double vapVrCobradoEct
	{
		get
		{
			return vapVrCobradoEctField;
		}
		set
		{
			vapVrCobradoEctField = value;
			RaisePropertyChanged("vapVrCobradoEct");
		}
	}

	[XmlIgnore]
	public bool vapVrCobradoEctSpecified
	{
		get
		{
			return vapVrCobradoEctFieldSpecified;
		}
		set
		{
			vapVrCobradoEctFieldSpecified = value;
			RaisePropertyChanged("vapVrCobradoEctSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 27)]
	public double vapVrNominal
	{
		get
		{
			return vapVrNominalField;
		}
		set
		{
			vapVrNominalField = value;
			RaisePropertyChanged("vapVrNominal");
		}
	}

	[XmlIgnore]
	public bool vapVrNominalSpecified
	{
		get
		{
			return vapVrNominalFieldSpecified;
		}
		set
		{
			vapVrNominalFieldSpecified = value;
			RaisePropertyChanged("vapVrNominalSpecified");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
