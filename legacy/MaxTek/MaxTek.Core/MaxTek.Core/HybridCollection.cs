using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxTek.Core;

[Serializable]
public class HybridCollection<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IEnumerable<TValue>
{
	private Dictionary<TKey, TValue> _dictionary;

	public TValue this[TKey key]
	{
		get
		{
			if (_dictionary.ContainsKey(key))
			{
				return _dictionary[key];
			}
			return default(TValue);
		}
		set
		{
			if (_dictionary.ContainsKey(key))
			{
				_dictionary[key] = value;
			}
			else
			{
				_dictionary.Add(key, value);
			}
		}
	}

	public int Count => _dictionary.Count;

	public ICollection<TKey> Keys => _dictionary.Keys;

	public ICollection<TValue> Values => _dictionary.Values;

	public bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).IsReadOnly;

	public HybridCollection()
	{
		_dictionary = new Dictionary<TKey, TValue>();
	}

	private HybridCollection(Dictionary<TKey, TValue> dictionary)
	{
		_dictionary = dictionary;
	}

	public HybridCollection<TKey, TValue> Clone()
	{
		return new HybridCollection<TKey, TValue>(_dictionary);
	}

	public bool Contains(TKey key)
	{
		return _dictionary.ContainsKey(key);
	}

	public bool Contains<T>(T value) where T : TValue, IKeyProvider<TKey>
	{
		return Contains(value.Key);
	}

	public void Add(TKey key, TValue value)
	{
		if (!_dictionary.ContainsKey(key))
		{
			_dictionary.Add(key, value);
		}
	}

	public void Add(object item)
	{
		if (!typeof(IKeyProvider<TKey>).IsAssignableFrom(item.GetType()))
		{
			throw new ArgumentException("Object has to implement IKeyProvider<TKey>", "item");
		}
		if (!_dictionary.ContainsKey(((IKeyProvider<TKey>)item).Key))
		{
			_dictionary.Add(((IKeyProvider<TKey>)item).Key, (TValue)item);
		}
	}

	public void Add<T>(T value) where T : TValue, IKeyProvider<TKey>
	{
		Add(value.Key, (TValue)(object)value);
	}

	public void Remove(TKey key)
	{
		if (_dictionary.ContainsKey(key))
		{
			_dictionary.Remove(key);
		}
	}

	public void Remove<T>(T value) where T : TValue, IKeyProvider<TKey>
	{
		Remove(value.Key);
	}

	public void Clear()
	{
		_dictionary.Clear();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _dictionary.Values.GetEnumerator();
	}

	public bool ContainsKey(TKey key)
	{
		return _dictionary.ContainsKey(key);
	}

	bool IDictionary<TKey, TValue>.Remove(TKey key)
	{
		return _dictionary.Remove(key);
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		return _dictionary.TryGetValue(key, out value);
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Add(item);
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Contains(item);
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		return ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Remove(item);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		return ((IEnumerable<KeyValuePair<TKey, TValue>>)_dictionary).GetEnumerator();
	}

	public IEnumerator<TValue> GetEnumerator()
	{
		return _dictionary.Values.GetEnumerator();
	}
}
