using System;
using System.ComponentModel;

namespace MaxTek.Core;

public class CustomPropertyDescriptor : PropertyDescriptor
{
	private readonly PropertyDescriptor _originalPropertyDescriptor;

	private readonly string _propertyPath;

	private bool _autoCreateObjects;

	public override Type ComponentType => _originalPropertyDescriptor.ComponentType;

	public override bool IsReadOnly => _originalPropertyDescriptor.IsReadOnly;

	public override Type PropertyType => _originalPropertyDescriptor.PropertyType;

	public CustomPropertyDescriptor(string propertyPath, PropertyDescriptor originalPropertyDescriptor, Attribute[] attrs, bool autoCreateObjects)
		: base(propertyPath.Replace(".", "_"), attrs)
	{
		_propertyPath = propertyPath;
		_originalPropertyDescriptor = originalPropertyDescriptor;
		_autoCreateObjects = autoCreateObjects;
	}

	public override bool CanResetValue(object component)
	{
		object nestedObjectInstance = GetNestedObjectInstance(component, _propertyPath, autoCreate: false);
		if (nestedObjectInstance != null)
		{
			return _originalPropertyDescriptor.CanResetValue(nestedObjectInstance);
		}
		return false;
	}

	public override object GetValue(object component)
	{
		object nestedObjectInstance = GetNestedObjectInstance(component, _propertyPath, autoCreate: false);
		if (nestedObjectInstance != null)
		{
			return DynamicAccessorFactory.GetDynamicAccessor(nestedObjectInstance.GetType()).GetPropertyValue(nestedObjectInstance, _originalPropertyDescriptor.Name);
		}
		return null;
	}

	public override void SetValue(object component, object value)
	{
		object nestedObjectInstance = GetNestedObjectInstance(component, _propertyPath, _autoCreateObjects);
		if (nestedObjectInstance != null)
		{
			DynamicAccessorFactory.GetDynamicAccessor(nestedObjectInstance.GetType()).SetPropertyValue(nestedObjectInstance, _originalPropertyDescriptor.Name, value);
		}
	}

	private static object GetNestedObjectInstance(object component, string propertyPath, bool autoCreate)
	{
		if (propertyPath.Contains("."))
		{
			string text = propertyPath.Substring(0, propertyPath.IndexOf("."));
			IDynamicAccessor dynamicAccessor = DynamicAccessorFactory.GetDynamicAccessor(component.GetType());
			object obj = dynamicAccessor.GetPropertyValue(component, text);
			if (obj == null)
			{
				if (!autoCreate)
				{
					return obj;
				}
				PropertyDescriptor propertyDescriptorFromPath = ReflectionHelper.GetPropertyDescriptorFromPath(component.GetType(), text);
				obj = Activator.CreateInstance(propertyDescriptorFromPath.PropertyType);
				dynamicAccessor.SetPropertyValue(component, text, obj);
			}
			return GetNestedObjectInstance(obj, propertyPath.Substring(propertyPath.IndexOf(".") + 1), autoCreate);
		}
		return component;
	}

	public override void ResetValue(object component)
	{
		object nestedObjectInstance = GetNestedObjectInstance(component, _propertyPath, autoCreate: false);
		if (nestedObjectInstance != null)
		{
			_originalPropertyDescriptor.ResetValue(nestedObjectInstance);
		}
	}

	public override bool ShouldSerializeValue(object component)
	{
		return false;
	}
}
