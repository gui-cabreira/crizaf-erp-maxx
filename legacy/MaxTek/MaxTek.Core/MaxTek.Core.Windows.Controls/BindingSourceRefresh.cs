using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MaxTek.Core.Windows.Controls;

[DesignerCategory("")]
[ProvideProperty("ReadValuesOnChange", typeof(BindingSource))]
public class BindingSourceRefresh : Component, IExtenderProvider
{
	private Dictionary<BindingSource, bool> _sources = new Dictionary<BindingSource, bool>();

	public BindingSourceRefresh(IContainer container)
	{
		container.Add(this);
	}

	public bool CanExtend(object extendee)
	{
		if (extendee is BindingSource)
		{
			return true;
		}
		return false;
	}

	public bool GetReadValuesOnChange(BindingSource source)
	{
		if (_sources.ContainsKey(source))
		{
			return _sources[source];
		}
		return false;
	}

	public void SetReadValuesOnChange(BindingSource source, bool value)
	{
		if (_sources.ContainsKey(source))
		{
			_sources[source] = value;
		}
		else
		{
			_sources.Add(source, value);
		}
		if (value)
		{
			source.BindingComplete += Source_BindingComplete;
		}
		else
		{
			source.BindingComplete -= Source_BindingComplete;
		}
	}

	private void Source_BindingComplete(object sender, BindingCompleteEventArgs e)
	{
		e.Binding.ReadValue();
	}
}
