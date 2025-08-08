using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using MaxTek.Core.Design;

namespace MaxTek.Core.Windows.Controls;

[ToolboxBitmap(typeof(ResFinder), "MaxTek.Core.Windows.Controls.BusinessObjectBindingSource")]
public class BusinessObjectBindingSource : BindingSource, IBindableControl
{
	private readonly BindingList<BindableProperty> _bindableProperties = new BindingList<BindableProperty>();

	private readonly List<PropertyDescriptor> _propertyDescriptors = new List<PropertyDescriptor>();

	private bool _createProperties = true;

	private bool _autoCreateObjects = false;

	[Category("Data")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("MaxTek.Core.Design.BindablePropertyTypeEditor", typeof(UITypeEditor))]
	public BindingList<BindableProperty> BindableProperties => _bindableProperties;

	[Category("Data")]
	public bool AutoCreateObjects
	{
		get
		{
			return _autoCreateObjects;
		}
		set
		{
			_autoCreateObjects = value;
		}
	}

	public BusinessObjectBindingSource()
	{
		((ISupportInitializeNotification)this).Initialized += ObjectBindingSource_Initialized;
	}

	public BusinessObjectBindingSource(IContainer container)
	{
		container.Add(this);
		((ISupportInitializeNotification)this).Initialized += ObjectBindingSource_Initialized;
	}

	private void CreatePropertyDescriptors()
	{
		_propertyDescriptors.Clear();
		Type listItemType = ListBindingHelper.GetListItemType(base.DataSource, base.DataMember);
		PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(listItemType);
		if (BindableProperties.Count == 0)
		{
			foreach (PropertyDescriptor item in properties.Sort())
			{
				Attribute[] array = new Attribute[item.Attributes.Count];
				item.Attributes.CopyTo(array, 0);
				_propertyDescriptors.Add(new CustomPropertyDescriptor(item.Name, ReflectionHelper.GetPropertyDescriptorFromPath(listItemType, item.Name), array, autoCreateObjects: false));
			}
		}
		else
		{
			try
			{
				foreach (BindableProperty bindableProperty in _bindableProperties)
				{
					PropertyDescriptor propertyDescriptorFromPath = ReflectionHelper.GetPropertyDescriptorFromPath(listItemType, bindableProperty.Name);
					Attribute[] array2 = new Attribute[propertyDescriptorFromPath.Attributes.Count + 1];
					propertyDescriptorFromPath.Attributes.CopyTo(array2, 0);
					array2[array2.Length - 1] = new CustomPropertyAttribute(listItemType, bindableProperty.Name, propertyDescriptorFromPath);
					_propertyDescriptors.Add(new CustomPropertyDescriptor(bindableProperty.Name, propertyDescriptorFromPath, array2, autoCreateObjects: false));
				}
			}
			catch (Exception ex)
			{
				if (base.DataSource != null)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		_createProperties = false;
		try
		{
			if (base.DataSource != null)
			{
				ResetBindings(metadataChanged: true);
			}
		}
		catch
		{
		}
	}

	private void ObjectBindingSource_Initialized(object sender, EventArgs e)
	{
		_bindableProperties.ListChanged += _bindableProperties_ListChanged;
		_createProperties = true;
	}

	private void _bindableProperties_ListChanged(object sender, ListChangedEventArgs e)
	{
		_createProperties = true;
	}

	protected override void OnDataMemberChanged(EventArgs e)
	{
		base.OnDataMemberChanged(e);
		_createProperties = true;
		ResetBindings(metadataChanged: true);
	}

	protected override void OnDataSourceChanged(EventArgs e)
	{
		base.OnDataSourceChanged(e);
		_createProperties = true;
		ResetBindings(metadataChanged: true);
	}

	public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
	{
		if (_createProperties)
		{
			CreatePropertyDescriptors();
		}
		if (_propertyDescriptors.Count > 0)
		{
			return new PropertyDescriptorCollection(_propertyDescriptors.ToArray());
		}
		return base.GetItemProperties(listAccessors);
	}

	public BindingList<BindableProperty> ObterBindableProperties()
	{
		return BindableProperties;
	}

	public Type ObterTipoDados()
	{
		return (Type)base.DataSource;
	}
}
