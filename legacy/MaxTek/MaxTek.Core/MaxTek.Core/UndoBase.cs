using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace MaxTek.Core;

[Serializable]
public abstract class UndoBase : BindableBase, IUndoableObject
{
	[NotUndoable]
	private Stack<byte[]> _stateStack = new Stack<byte[]>();

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected int EditLevel => _stateStack.Count;

	void IUndoableObject.CopyState()
	{
		CopyState();
	}

	void IUndoableObject.UndoChanges()
	{
		UndoChanges();
	}

	void IUndoableObject.AcceptChanges()
	{
		AcceptChanges();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void CopyStateComplete()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected internal void CopyState()
	{
		Type type = GetType();
		HybridDictionary hybridDictionary = new HybridDictionary();
		do
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				if (!(fieldInfo.DeclaringType == type) || NotUndoableField(fieldInfo))
				{
					continue;
				}
				object value = fieldInfo.GetValue(this);
				if (typeof(IUndoableObject).IsAssignableFrom(fieldInfo.FieldType))
				{
					if (value == null)
					{
						hybridDictionary.Add(GetFieldName(fieldInfo), null);
					}
					else
					{
						((IUndoableObject)value).CopyState();
					}
				}
				else
				{
					hybridDictionary.Add(GetFieldName(fieldInfo), value);
				}
			}
			type = type.BaseType;
		}
		while (type != typeof(UndoBase));
		using (MemoryStream memoryStream = new MemoryStream())
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, hybridDictionary);
			_stateStack.Push(memoryStream.ToArray());
		}
		CopyStateComplete();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void UndoChangesComplete()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected internal void UndoChanges()
	{
		if (EditLevel > 0)
		{
			HybridDictionary hybridDictionary;
			using (MemoryStream memoryStream = new MemoryStream(_stateStack.Pop()))
			{
				memoryStream.Position = 0L;
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				hybridDictionary = (HybridDictionary)binaryFormatter.Deserialize(memoryStream);
			}
			Type type = GetType();
			do
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				FieldInfo[] array = fields;
				foreach (FieldInfo fieldInfo in array)
				{
					if (!(fieldInfo.DeclaringType == type) || NotUndoableField(fieldInfo))
					{
						continue;
					}
					object value = fieldInfo.GetValue(this);
					if (typeof(IUndoableObject).IsAssignableFrom(fieldInfo.FieldType))
					{
						if (hybridDictionary.Contains(GetFieldName(fieldInfo)))
						{
							fieldInfo.SetValue(this, null);
						}
						else if (value != null)
						{
							((IUndoableObject)value).UndoChanges();
						}
					}
					else
					{
						fieldInfo.SetValue(this, hybridDictionary[GetFieldName(fieldInfo)]);
					}
				}
				type = type.BaseType;
			}
			while (type != typeof(UndoBase));
		}
		UndoChangesComplete();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void AcceptChangesComplete()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected internal void AcceptChanges()
	{
		if (EditLevel > 0)
		{
			_stateStack.Pop();
			Type type = GetType();
			do
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				FieldInfo[] array = fields;
				foreach (FieldInfo fieldInfo in array)
				{
					if (fieldInfo.DeclaringType == type && !NotUndoableField(fieldInfo) && typeof(IUndoableObject).IsAssignableFrom(fieldInfo.FieldType))
					{
						object value = fieldInfo.GetValue(this);
						if (value != null)
						{
							((IUndoableObject)value).AcceptChanges();
						}
					}
				}
				type = type.BaseType;
			}
			while (type != typeof(UndoBase));
		}
		AcceptChangesComplete();
	}

	private static bool NotUndoableField(FieldInfo field)
	{
		return Attribute.IsDefined(field, typeof(NotUndoableAttribute));
	}

	private static string GetFieldName(FieldInfo field)
	{
		return field.DeclaringType.Name + "!" + field.Name;
	}
}
