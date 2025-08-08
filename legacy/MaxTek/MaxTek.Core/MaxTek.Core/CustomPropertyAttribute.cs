using System;
using System.ComponentModel;

namespace MaxTek.Core;

public class CustomPropertyAttribute : Attribute
{
	private PropertyDescriptor _propertyDescriptior;

	private string _propertyPath;

	private Type _rootType;

	public PropertyDescriptor PropertyInfo => _propertyDescriptior;

	public string PropertyPath => _propertyPath;

	public Type RootType => _rootType;

	public CustomPropertyAttribute(Type rootType, string propertyPath, PropertyDescriptor propertyDescriptor)
	{
		_rootType = rootType;
		_propertyPath = propertyPath;
		_propertyDescriptior = propertyDescriptor;
	}
}
