using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


class ReverseDeque<T> : IDeque<T>, IList<T>
{
	private readonly Deque<T> _deque;
	private ulong Version => _deque.Version;

	public ReverseDeque(Deque<T> deque)
	{
		_deque = deque;
	}

	public IEnumerator<T> GetEnumerator()
	{
		ulong version = Version;
		for (int i = 0; i < Count; ++i)
		{
			yield return this[i];
			if (Version != version)
			{
				throw new InvalidOperationException();
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void PushBack(T item)
	{
		_deque.PushFront(item);
	}

	public void PushFront(T item)
	{
		_deque.PushBack(item);
	}

	public void PopBack()
	{
		_deque.PopFront();
	}

	public void PopFront()
	{
		_deque.PopBack();
	}

	public IDeque<T> GetReverseView()
	{
		return _deque;
	}

	public void Add(T item)
	{
		_deque.PushFront(item);
	}

	public void Clear()
	{
		_deque.Clear();
	}

	public bool Contains(T item)
	{
		return _deque.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		for (int i = 0; i < Count; ++i)
		{
			array[arrayIndex + i] = this[i];
		}
	}

	public bool Remove(T item)
	{
		int index = IndexOf(item);
		if (index < 0)
		{
			return false;
		}

		RemoveAt(index);
		return true;
	}

	public int Count => _deque.Count;
	public bool IsReadOnly => false;
	public int IndexOf(T item)
	{
		for (int i = 0; i < Count; ++i)
		{
			if (Equals(this[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public void Insert(int index, T item)
	{
		_deque.Insert(ReverseIndex(index) + 1, item); //inserting just AFTER the element, not before like normally
	}

	public void RemoveAt(int index)
	{
		_deque.RemoveAt(ReverseIndex(index));
	}

	public T this[int index]
	{
		get => _deque[ReverseIndex(index)];
		set => _deque[ReverseIndex(index)] = value;
	}

	private int ReverseIndex(int index)
	{
		return Count - index - 1;
	}


}

