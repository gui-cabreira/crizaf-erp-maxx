using System;
using System.ComponentModel;

namespace MaxTek.Core.Design;

public interface IBindableControl
{
	BindingList<BindableProperty> ObterBindableProperties();

	Type ObterTipoDados();
}
