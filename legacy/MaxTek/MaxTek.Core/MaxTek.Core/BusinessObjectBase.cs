#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MaxTek.Core;

[Serializable]
public class BusinessObjectBase : UndoBase, IDataErrorInfo, IEditableObject
{
	private List<Regra> _regras;

	private bool _excluir = false;

	private bool _isNovo = true;

	private Hashtable _propriedadesModificadas = new Hashtable();

	private bool _selecionar = false;

	[NotUndoable]
	private bool _bindingEdit;

	private bool _neverCommitted = true;

	[NotBindable]
	public virtual bool IsValido => Error == null;

	[NotBindable]
	public virtual string Error
	{
		get
		{
			string text = this[string.Empty];
			if (text != null && text.Trim().Length == 0)
			{
				text = null;
			}
			return text;
		}
	}

	[NotBindable]
	public virtual string this[string nomePropriedade]
	{
		get
		{
			string text = string.Empty;
			nomePropriedade = LimparString(nomePropriedade);
			foreach (Regra item in ObterRegrasQuebradas(nomePropriedade))
			{
				if (nomePropriedade == string.Empty || item.NomePropriedade == nomePropriedade)
				{
					text += item.Descricao;
					text += Environment.NewLine;
				}
			}
			text = text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			return text;
		}
	}

	[Browsable(true)]
	public bool IsExcluir
	{
		get
		{
			return _excluir;
		}
		set
		{
			_excluir = value;
		}
	}

	[Browsable(false)]
	[NotBindable]
	public bool IsNovo => _isNovo;

	[Browsable(false)]
	[NotBindable]
	public bool FoiModificado => _propriedadesModificadas.Count > 0;

	[NotBindable]
	public Hashtable PropriedadesModificadas => _propriedadesModificadas;

	[Browsable(true)]
	public bool IsSelecionar
	{
		get
		{
			return _selecionar;
		}
		set
		{
			_selecionar = value;
		}
	}

	public decimal vCampoAuxDec_01 { get; set; }

	public decimal vCampoAuxDec_02 { get; set; }

	public decimal vCampoAuxDec_03 { get; set; }

	public int vCampoAuxInt_01 { get; set; }

	public int vCampoAuxInt_02 { get; set; }

	public int vCampoAuxInt_03 { get; set; }

	public string vCampoAuxStr_01 { get; set; }

	public string vCampoAuxStr_02 { get; set; }

	public string vCampoAuxStr_03 { get; set; }

	public bool vCampoAuxBol_01 { get; set; }

	public bool vCampoAuxBol_02 { get; set; }

	public bool vCampoAuxBol_03 { get; set; }

	public object vCampoAuxObj01 { get; set; }

	public DateTime vCampoAuxData01 { get; set; }

	public DateTime vCampoAuxData02 { get; set; }

	public DateTime vCampoAuxData03 { get; set; }

	public new event PropertyChangedEventHandler PropertyChanged;

	public virtual ReadOnlyCollection<Regra> ObterRegrasQuebradas()
	{
		return ObterRegrasQuebradas(string.Empty);
	}

	public virtual ReadOnlyCollection<Regra> ObterRegrasQuebradas(string propriedade)
	{
		propriedade = LimparString(propriedade);
		if (_regras == null)
		{
			_regras = new List<Regra>();
			_regras.AddRange(CriarRegras());
		}
		List<Regra> list = new List<Regra>();
		foreach (Regra regra in _regras)
		{
			if (regra.NomePropriedade == propriedade || propriedade == string.Empty)
			{
				bool flag = !regra.ValidarRegra(this);
				Debug.WriteLine(DateTime.Now.ToLongTimeString() + ": Validando a regra: '" + regra.ToString() + "' no objeto '" + ToString() + "'. Resultado = " + ((!flag) ? "Valida" : "Quebrada"));
				if (flag)
				{
					list.Add(regra);
				}
			}
		}
		return list.AsReadOnly();
	}

	protected virtual List<Regra> CriarRegras()
	{
		return new List<Regra>();
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}

	protected virtual void NotifyChanged(params string[] nomesPropriedades)
	{
		foreach (string propertyName in nomesPropriedades)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		OnPropertyChanged(new PropertyChangedEventArgs("IsValido"));
	}

	protected string LimparString(string s)
	{
		return (s ?? string.Empty).Trim();
	}

	public virtual void Excluir()
	{
		_excluir = true;
	}

	public virtual void MarcarNovo()
	{
		_isNovo = true;
	}

	public void MarcarExistente()
	{
		MarcarExistente(suppressEvent: false);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected void MarcarExistente(bool suppressEvent)
	{
		_isNovo = false;
		_propriedadesModificadas.Clear();
		if (!suppressEvent)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(string.Empty));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void PropertyHasChanged()
	{
		string nomePropriedade = new StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
		PropertyHasChanged(nomePropriedade);
	}

	protected virtual void PropertyHasChanged(string nomePropriedade)
	{
		if (!_propriedadesModificadas.ContainsKey(nomePropriedade))
		{
			_propriedadesModificadas.Add(nomePropriedade, null);
		}
		OnPropertyChanged(new PropertyChangedEventArgs(nomePropriedade));
	}

	public bool PropriedadeModificada(string nomePropriedade)
	{
		return _propriedadesModificadas.ContainsKey(nomePropriedade);
	}

	public virtual void Selecionar()
	{
		_selecionar = true;
	}

	void IEditableObject.BeginEdit()
	{
		if (!_bindingEdit)
		{
			_bindingEdit = true;
			CopyState();
		}
	}

	void IEditableObject.CancelEdit()
	{
		if (_bindingEdit)
		{
			UndoChanges();
			if (IsNovo && !_neverCommitted)
			{
			}
		}
	}

	void IEditableObject.EndEdit()
	{
		if (_bindingEdit)
		{
			_bindingEdit = false;
			_neverCommitted = false;
			AcceptChanges();
		}
	}

	public virtual void MapearDados(object dados)
	{
		throw new Exception("MapearDados Não implementado");
	}

	public virtual object ObterDadosMapeados()
	{
		throw new Exception("ObterDadosMapeados Não implementado");
	}
}
