using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace MaxTek.Core;

internal sealed class DynamicAccessor : IDynamicAccessor
{
	internal delegate object GetHandler(object source);

	internal delegate void SetHandler(object source, object value);

	internal delegate object InstantiateObjectHandler();

	internal sealed class DynamicMethodCompiler
	{
		private DynamicMethodCompiler()
		{
		}

		internal static InstantiateObjectHandler CreateInstantiateObjectHandler(Type type)
		{
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
			if (constructor == null)
			{
				throw new ApplicationException($"The type {type} must declare an empty constructor (the constructor may be private, internal, protected, protected internal, or public).");
			}
			DynamicMethod dynamicMethod = new DynamicMethod("InstantiateObject", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(object), null, type, skipVisibility: true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Newobj, constructor);
			iLGenerator.Emit(OpCodes.Ret);
			return (InstantiateObjectHandler)dynamicMethod.CreateDelegate(typeof(InstantiateObjectHandler));
		}

		internal static GetHandler CreateGetHandler(Type type, PropertyInfo propertyInfo)
		{
			MethodInfo getMethod = propertyInfo.GetGetMethod(nonPublic: true);
			DynamicMethod dynamicMethod = CreateGetDynamicMethod(type);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Call, getMethod);
			BoxIfNeeded(getMethod.ReturnType, iLGenerator);
			iLGenerator.Emit(OpCodes.Ret);
			return (GetHandler)dynamicMethod.CreateDelegate(typeof(GetHandler));
		}

		internal static GetHandler CreateGetHandler(Type type, FieldInfo Season)
		{
			DynamicMethod dynamicMethod = CreateGetDynamicMethod(type);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldfld, Season);
			BoxIfNeeded(Season.FieldType, iLGenerator);
			iLGenerator.Emit(OpCodes.Ret);
			return (GetHandler)dynamicMethod.CreateDelegate(typeof(GetHandler));
		}

		internal static SetHandler CreateSetHandler(Type type, PropertyInfo propertyInfo)
		{
			MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
			DynamicMethod dynamicMethod = CreateSetDynamicMethod(type);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			UnboxIfNeeded(setMethod.GetParameters()[0].ParameterType, iLGenerator);
			iLGenerator.Emit(OpCodes.Call, setMethod);
			iLGenerator.Emit(OpCodes.Ret);
			return (SetHandler)dynamicMethod.CreateDelegate(typeof(SetHandler));
		}

		internal static SetHandler CreateSetHandler(Type type, FieldInfo Season)
		{
			DynamicMethod dynamicMethod = CreateSetDynamicMethod(type);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			UnboxIfNeeded(Season.FieldType, iLGenerator);
			iLGenerator.Emit(OpCodes.Stfld, Season);
			iLGenerator.Emit(OpCodes.Ret);
			return (SetHandler)dynamicMethod.CreateDelegate(typeof(SetHandler));
		}

		private static DynamicMethod CreateGetDynamicMethod(Type type)
		{
			return new DynamicMethod("DynamicGet", typeof(object), new Type[1] { typeof(object) }, type, skipVisibility: true);
		}

		private static DynamicMethod CreateSetDynamicMethod(Type type)
		{
			return new DynamicMethod("DynamicSet", typeof(void), new Type[2]
			{
				typeof(object),
				typeof(object)
			}, type, skipVisibility: true);
		}

		private static void BoxIfNeeded(Type type, ILGenerator generator)
		{
			if (type.IsValueType)
			{
				generator.Emit(OpCodes.Box, type);
			}
		}

		private static void UnboxIfNeeded(Type type, ILGenerator generator)
		{
			if (type.IsValueType)
			{
				generator.Emit(OpCodes.Unbox_Any, type);
			}
		}
	}

	private readonly Type _type;

	private readonly Dictionary<string, GetHandler> _propertyGetters;

	private readonly Dictionary<string, SetHandler> _propertySetters;

	private readonly Dictionary<string, GetHandler> _fieldGetters;

	private readonly Dictionary<string, SetHandler> _fieldSetters;

	public object this[object target, string propertyName]
	{
		get
		{
			ValidatePropertyGetter(propertyName);
			return _propertyGetters[propertyName](target);
		}
		set
		{
			ValidatePropertySetter(propertyName);
			_propertySetters[propertyName](target, value);
		}
	}

	internal DynamicAccessor(Type type)
	{
		_type = type;
		_propertyGetters = new Dictionary<string, GetHandler>();
		_propertySetters = new Dictionary<string, SetHandler>();
		_fieldGetters = new Dictionary<string, GetHandler>();
		_fieldSetters = new Dictionary<string, SetHandler>();
	}

	public void SetPropertyValue(object target, string propertyName, object value)
	{
		ValidatePropertySetter(propertyName);
		_propertySetters[propertyName](target, value);
	}

	public object GetPropertyValue(object target, string propertyName)
	{
		ValidatePropertyGetter(propertyName);
		return _propertyGetters[propertyName](target);
	}

	public void SetFieldValue(object target, string fieldName, object value)
	{
		ValidateFieldSetter(fieldName);
		_fieldSetters[fieldName](target, value);
	}

	public object GetFieldValue(object target, string fieldName)
	{
		ValidateFieldGetter(fieldName);
		return _fieldGetters[fieldName](target);
	}

	private void ValidateFieldSetter(string fieldName)
	{
		if (!_fieldSetters.ContainsKey(fieldName))
		{
			FieldInfo field = _type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				throw new ArgumentOutOfRangeException(fieldName, "Unable to find fieldname");
			}
			_fieldSetters.Add(fieldName, DynamicMethodCompiler.CreateSetHandler(_type, field));
		}
	}

	private void ValidatePropertySetter(string propertyName)
	{
		if (!_propertySetters.ContainsKey(propertyName))
		{
			_propertySetters.Add(propertyName, DynamicMethodCompiler.CreateSetHandler(_type, _type.GetProperty(propertyName)));
		}
	}

	private void ValidatePropertyGetter(string propertyName)
	{
		if (!_propertyGetters.ContainsKey(propertyName))
		{
			_propertyGetters.Add(propertyName, DynamicMethodCompiler.CreateGetHandler(_type, _type.GetProperty(propertyName)));
		}
	}

	private void ValidateFieldGetter(string fieldName)
	{
		if (!_fieldGetters.ContainsKey(fieldName))
		{
			FieldInfo field = _type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				throw new ArgumentOutOfRangeException(fieldName, "Unable to find fieldname");
			}
			_fieldGetters.Add(fieldName, DynamicMethodCompiler.CreateGetHandler(_type, field));
		}
	}
}
