using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MaxTek.Core;

public static class ObjectDataMapper
{
	public static T MapObject<T>(object MapTable)
	{
		Type type = MapTable.GetType();
		object obj = Activator.CreateInstance(type);
		T val = default(T);
		if (!MapTable.Equals(obj))
		{
			val = (T)Activator.CreateInstance(typeof(T));
			typeof(T).InvokeMember("MarcarExistente", BindingFlags.InvokeMethod, null, val, null);
			object[] args = new object[1] { MapTable };
			typeof(T).InvokeMember("MapearDados", BindingFlags.InvokeMethod, null, val, args);
		}
		return val;
	}

	public static IList<T> MapObjectList<T>(IList mapTableObjectList)
	{
		IList<T> list = new List<T>();
		foreach (object mapTableObject in mapTableObjectList)
		{
			T val = (T)Activator.CreateInstance(typeof(T));
			typeof(T).InvokeMember("MarcarExistente", BindingFlags.InvokeMethod, null, val, null);
			object[] args = new object[1] { mapTableObject };
			typeof(T).InvokeMember("MapearDados", BindingFlags.InvokeMethod, null, val, args);
			list.Add(val);
		}
		return list;
	}
}
