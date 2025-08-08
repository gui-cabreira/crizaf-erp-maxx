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
public class coletaReversa : coleta
{
	private string agField;

	private int arField;

	private bool arFieldSpecified;

	private string cartaoField;

	private int numeroField;

	private bool numeroFieldSpecified;

	private objeto[] obj_colField;

	private string servico_adicionalField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string ag
	{
		get
		{
			return agField;
		}
		set
		{
			agField = value;
			RaisePropertyChanged("ag");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
	public int ar
	{
		get
		{
			return arField;
		}
		set
		{
			arField = value;
			RaisePropertyChanged("ar");
		}
	}

	[XmlIgnore]
	public bool arSpecified
	{
		get
		{
			return arFieldSpecified;
		}
		set
		{
			arFieldSpecified = value;
			RaisePropertyChanged("arSpecified");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
	public string cartao
	{
		get
		{
			return cartaoField;
		}
		set
		{
			cartaoField = value;
			RaisePropertyChanged("cartao");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public int numero
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

	[XmlIgnore]
	public bool numeroSpecified
	{
		get
		{
			return numeroFieldSpecified;
		}
		set
		{
			numeroFieldSpecified = value;
			RaisePropertyChanged("numeroSpecified");
		}
	}

	[XmlElement("obj_col", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 4)]
	public objeto[] obj_col
	{
		get
		{
			return obj_colField;
		}
		set
		{
			obj_colField = value;
			RaisePropertyChanged("obj_col");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public string servico_adicional
	{
		get
		{
			return servico_adicionalField;
		}
		set
		{
			servico_adicionalField = value;
			RaisePropertyChanged("servico_adicional");
		}
	}
}
