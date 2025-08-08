using System;
using System.ComponentModel;
using System.Reflection;

namespace MaxTek.Core;

public static class ReflectionHelper
{
	public static PropertyInfo GetPropertyFromPath(Type rootType, string propertyPath)
	{
		if (rootType == null)
		{
			throw new ArgumentNullException("rootType");
		}
		Type type = rootType;
		PropertyInfo propertyInfo = null;
		string[] array = propertyPath.Split('.');
		for (int i = 0; i < array.Length; i++)
		{
			propertyInfo = type.GetProperty(array[i], BindingFlags.Instance | BindingFlags.Public);
			if (propertyInfo != null)
			{
				type = propertyInfo.PropertyType;
				continue;
			}
			throw new ArgumentOutOfRangeException("propertyPath", propertyPath, "Invalid property path");
		}
		return propertyInfo;
	}

	public static PropertyDescriptor GetPropertyDescriptorFromPath(Type rootType, string propertyPath)
	{
		bool flag = false;
		if (rootType == null)
		{
			throw new ArgumentNullException("rootType");
		}
		string name;
		if (propertyPath.Contains("."))
		{
			name = propertyPath.Substring(0, propertyPath.IndexOf("."));
		}
		else
		{
			name = propertyPath;
			flag = true;
		}
		PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(rootType)[name];
		if (propertyDescriptor == null)
		{
			throw new ArgumentOutOfRangeException("propertyPath", propertyPath, $"Invalid property path for type '{rootType.Name}' ");
		}
		if (!flag)
		{
			return GetPropertyDescriptorFromPath(propertyDescriptor.PropertyType, propertyPath.Substring(propertyPath.IndexOf(".") + 1));
		}
		return propertyDescriptor;
	}
}
