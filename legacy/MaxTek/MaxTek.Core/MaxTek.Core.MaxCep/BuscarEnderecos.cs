using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace MaxTek.Core.MaxCep;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "BuscarEnderecos", Namespace = "http://schemas.datacontract.org/2004/07/BuscaEndereco")]
public class BuscarEnderecos : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private string BairroField;

	[OptionalField]
	private string CepField;

	[OptionalField]
	private string CidadeField;

	[OptionalField]
	private int? CodigoIBGEField;

	[OptionalField]
	private int? CodigoUFField;

	[OptionalField]
	private string EnderecoField;

	[OptionalField]
	private string UfField;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return extensionDataField;
		}
		set
		{
			extensionDataField = value;
		}
	}

	[DataMember]
	public string Bairro
	{
		get
		{
			return BairroField;
		}
		set
		{
			if ((object)BairroField != value)
			{
				BairroField = value;
				RaisePropertyChanged("Bairro");
			}
		}
	}

	[DataMember]
	public string Cep
	{
		get
		{
			return CepField;
		}
		set
		{
			if ((object)CepField != value)
			{
				CepField = value;
				RaisePropertyChanged("Cep");
			}
		}
	}

	[DataMember]
	public string Cidade
	{
		get
		{
			return CidadeField;
		}
		set
		{
			if ((object)CidadeField != value)
			{
				CidadeField = value;
				RaisePropertyChanged("Cidade");
			}
		}
	}

	[DataMember]
	public int? CodigoIBGE
	{
		get
		{
			return CodigoIBGEField;
		}
		set
		{
			if (!CodigoIBGEField.Equals(value))
			{
				CodigoIBGEField = value;
				RaisePropertyChanged("CodigoIBGE");
			}
		}
	}

	[DataMember]
	public int? CodigoUF
	{
		get
		{
			return CodigoUFField;
		}
		set
		{
			if (!CodigoUFField.Equals(value))
			{
				CodigoUFField = value;
				RaisePropertyChanged("CodigoUF");
			}
		}
	}

	[DataMember]
	public string Endereco
	{
		get
		{
			return EnderecoField;
		}
		set
		{
			if ((object)EnderecoField != value)
			{
				EnderecoField = value;
				RaisePropertyChanged("Endereco");
			}
		}
	}

	[DataMember]
	public string Uf
	{
		get
		{
			return UfField;
		}
		set
		{
			if ((object)UfField != value)
			{
				UfField = value;
				RaisePropertyChanged("Uf");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
