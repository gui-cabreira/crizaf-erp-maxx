using System;

namespace MaxTek.Core;

[Serializable]
public abstract class Regra
{
	private string _descricao;

	private string _nomePropriedade;

	public virtual string Descricao
	{
		get
		{
			return _descricao;
		}
		protected set
		{
			_descricao = value;
		}
	}

	public virtual string NomePropriedade
	{
		get
		{
			return (_nomePropriedade ?? string.Empty).Trim();
		}
		protected set
		{
			_nomePropriedade = value;
		}
	}

	public Regra(string nomePropriedade, string descricaoErro)
	{
		Descricao = descricaoErro;
		NomePropriedade = nomePropriedade;
	}

	public abstract bool ValidarRegra(BusinessObjectBase businessObjectBase);

	public override string ToString()
	{
		return Descricao;
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}
}
