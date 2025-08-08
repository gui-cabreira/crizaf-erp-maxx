using System;

namespace MaxTek.Core;

[Serializable]
public class RegraSimples : Regra
{
	private RegraSimplesDelegate _regraDelegate;

	protected virtual RegraSimplesDelegate RegraDelegate
	{
		get
		{
			return _regraDelegate;
		}
		set
		{
			_regraDelegate = value;
		}
	}

	public RegraSimples(string nomePropriedade, string descricaoErro, RegraSimplesDelegate regraDelegate)
		: base(nomePropriedade, descricaoErro)
	{
		RegraDelegate = regraDelegate;
	}

	public override bool ValidarRegra(BusinessObjectBase businessObjectBase)
	{
		return RegraDelegate();
	}
}
