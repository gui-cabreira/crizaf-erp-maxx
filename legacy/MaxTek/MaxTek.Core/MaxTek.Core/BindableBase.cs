using System;
using System.ComponentModel;

namespace MaxTek.Core;

[Serializable]
public abstract class BindableBase : INotifyPropertyChanged
{
	[NonSerialized]
	private PropertyChangedEventHandler _nonSerializableHandlers;

	private PropertyChangedEventHandler _serializableHandlers;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			try
			{
				if (value.Method.IsPublic && (value.Method.DeclaringType.IsSerializable || value.Method.IsStatic))
				{
					_serializableHandlers = (PropertyChangedEventHandler)Delegate.Combine(_serializableHandlers, value);
				}
				else
				{
					_nonSerializableHandlers = (PropertyChangedEventHandler)Delegate.Combine(_nonSerializableHandlers, value);
				}
			}
			catch
			{
			}
		}
		remove
		{
			try
			{
				if (value.Method.IsPublic && (value.Method.DeclaringType.IsSerializable || value.Method.IsStatic))
				{
					_serializableHandlers = (PropertyChangedEventHandler)Delegate.Remove(_serializableHandlers, value);
				}
				else
				{
					_nonSerializableHandlers = (PropertyChangedEventHandler)Delegate.Remove(_nonSerializableHandlers, value);
				}
			}
			catch
			{
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnUnknownPropertyChanged()
	{
		OnPropertyChanged(string.Empty);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (_nonSerializableHandlers != null)
		{
			_nonSerializableHandlers(this, new PropertyChangedEventArgs(propertyName));
		}
		if (_serializableHandlers != null)
		{
			_serializableHandlers(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
