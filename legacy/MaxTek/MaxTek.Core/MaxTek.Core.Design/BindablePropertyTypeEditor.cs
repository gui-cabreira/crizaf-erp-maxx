using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace MaxTek.Core.Design;

public class BindablePropertyTypeEditor : UITypeEditor
{
	private IWindowsFormsEditorService service;

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context != null && context.Instance != null && provider != null)
		{
			service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (service != null)
			{
				Type type = context.Instance.GetType();
				if (type.GetInterface(typeof(IBindableControl).FullName) == typeof(IBindableControl))
				{
					IBindableControl bindableControl = context.Instance as IBindableControl;
					BindablePropertyEditor.Execute(bindableControl.ObterBindableProperties(), bindableControl.ObterTipoDados());
				}
				context.OnComponentChanged();
			}
			return value;
		}
		return base.EditValue(context, provider, value);
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		if (context != null && context.Instance != null)
		{
			return UITypeEditorEditStyle.Modal;
		}
		return base.GetEditStyle(context);
	}
}
