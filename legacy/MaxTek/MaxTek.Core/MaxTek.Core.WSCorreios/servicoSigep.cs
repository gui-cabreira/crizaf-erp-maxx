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
public class servicoSigep : INotifyPropertyChanged
{
	private categoriaServico categoriaServicoField;

	private bool categoriaServicoFieldSpecified;

	private chancelaMaster chancelaField;

	private bool exigeDimensoesField;

	private bool exigeDimensoesFieldSpecified;

	private bool exigeValorCobrarField;

	private bool exigeValorCobrarFieldSpecified;

	private long imitmField;

	private string pagamentoEntregaField;

	private string remessaAgrupadaField;

	private long servicoField;

	private servicoERP servicoERPField;

	private string ssiCoCodigoPostalField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public categoriaServico categoriaServico
	{
		get
		{
			return categoriaServicoField;
		}
		set
		{
			categoriaServicoField = value;
			RaisePropertyChanged("categoriaServico");
		}
	}

	[XmlIgnore]
	public bool categoriaServicoSpecified
	{
		get
		{
			return categoriaServicoFieldSpecified;
		}
		set
		{
			categoriaServicoFieldSpecified = value;
			RaisePropertyChanged("categoriaServicoSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public chancelaMaster chancela
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

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public bool exigeDimensoes
	{
		get
		{
			return exigeDimensoesField;
		}
		set
		{
			exigeDimensoesField = value;
			RaisePropertyChanged("exigeDimensoes");
		}
	}

	[XmlIgnore]
	public bool exigeDimensoesSpecified
	{
		get
		{
			return exigeDimensoesFieldSpecified;
		}
		set
		{
			exigeDimensoesFieldSpecified = value;
			RaisePropertyChanged("exigeDimensoesSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public bool exigeValorCobrar
	{
		get
		{
			return exigeValorCobrarField;
		}
		set
		{
			exigeValorCobrarField = value;
			RaisePropertyChanged("exigeValorCobrar");
		}
	}

	[XmlIgnore]
	public bool exigeValorCobrarSpecified
	{
		get
		{
			return exigeValorCobrarFieldSpecified;
		}
		set
		{
			exigeValorCobrarFieldSpecified = value;
			RaisePropertyChanged("exigeValorCobrarSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 4)]
	public long imitm
	{
		get
		{
			return imitmField;
		}
		set
		{
			imitmField = value;
			RaisePropertyChanged("imitm");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public string pagamentoEntrega
	{
		get
		{
			return pagamentoEntregaField;
		}
		set
		{
			pagamentoEntregaField = value;
			RaisePropertyChanged("pagamentoEntrega");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public string remessaAgrupada
	{
		get
		{
			return remessaAgrupadaField;
		}
		set
		{
			remessaAgrupadaField = value;
			RaisePropertyChanged("remessaAgrupada");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public long servico
	{
		get
		{
			return servicoField;
		}
		set
		{
			servicoField = value;
			RaisePropertyChanged("servico");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 8)]
	public servicoERP servicoERP
	{
		get
		{
			return servicoERPField;
		}
		set
		{
			servicoERPField = value;
			RaisePropertyChanged("servicoERP");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 9)]
	public string ssiCoCodigoPostal
	{
		get
		{
			return ssiCoCodigoPostalField;
		}
		set
		{
			ssiCoCodigoPostalField = value;
			RaisePropertyChanged("ssiCoCodigoPostal");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
