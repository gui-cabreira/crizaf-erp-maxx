using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MaxTek.Core.WSCorreios;

[Serializable]
[XmlInclude(typeof(coletaReversa))]
[XmlInclude(typeof(coletaSimultanea))]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://cliente.bean.master.sigep.bsb.correios.com.br/")]
public class coleta : INotifyPropertyChanged
{
	private string cklistField;

	private string descricaoField;

	private string[] documentoField;

	private string id_clienteField;

	private produto[] produtoField;

	private remetente remetenteField;

	private string tipoField;

	private string valor_declaradoField;

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
	public string cklist
	{
		get
		{
			return cklistField;
		}
		set
		{
			cklistField = value;
			RaisePropertyChanged("cklist");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
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

	[XmlElement("documento", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 2)]
	public string[] documento
	{
		get
		{
			return documentoField;
		}
		set
		{
			documentoField = value;
			RaisePropertyChanged("documento");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 3)]
	public string id_cliente
	{
		get
		{
			return id_clienteField;
		}
		set
		{
			id_clienteField = value;
			RaisePropertyChanged("id_cliente");
		}
	}

	[XmlElement("produto", Form = XmlSchemaForm.Unqualified, IsNullable = true, Order = 4)]
	public produto[] produto
	{
		get
		{
			return produtoField;
		}
		set
		{
			produtoField = value;
			RaisePropertyChanged("produto");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 5)]
	public remetente remetente
	{
		get
		{
			return remetenteField;
		}
		set
		{
			remetenteField = value;
			RaisePropertyChanged("remetente");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 6)]
	public string tipo
	{
		get
		{
			return tipoField;
		}
		set
		{
			tipoField = value;
			RaisePropertyChanged("tipo");
		}
	}

	[XmlElement(Form = XmlSchemaForm.Unqualified, Order = 7)]
	public string valor_declarado
	{
		get
		{
			return valor_declaradoField;
		}
		set
		{
			valor_declaradoField = value;
			RaisePropertyChanged("valor_declarado");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
