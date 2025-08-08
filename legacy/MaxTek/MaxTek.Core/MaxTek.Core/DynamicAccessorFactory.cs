using System;

namespace MaxTek.Core;

public static class DynamicAccessorFactory
{
	private static readonly HybridCollection<Type, IDynamicAccessor> _DynamicAccessors = new HybridCollection<Type, IDynamicAccessor>();

	public static IDynamicAccessor GetDynamicAccessor(Type type)
	{
		if (!_DynamicAccessors.Contains(type))
		{
			_DynamicAccessors.Add(type, new DynamicAccessor(type));
		}
		return _DynamicAccessors[type];
	}
}
