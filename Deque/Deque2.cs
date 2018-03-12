using System;
using System.Collections;
using System.Collections.Generic;


public static class DequeTest
{
	public static IList<T> GetReverseView<T>(Deque<T> d)
	{
		return (IList<T>)d.GetReverseView();
	}
}
public class Deque<T> : IDeque<T>, IList<T>
{
	private const int ChunkSize = 8;
	private const int DefaultCapacity = 7;
	private const float CapacityMultiplier = 1.5F;

	private T[][] _elems;
	private int _beginIndex;
	private int _endIndex;

	internal ulong Version { get; private set; }

	public Deque() : this(DefaultCapacity)
	{
	}

	public Deque(IEnumerable<T> en) : this()
	{
		foreach (T elem in en)
		{
			Add(elem);
		}
	}

	public Deque(int capacity)
	{
		_elems = new T[capacity][];
		_beginIndex = ChunkSize * capacity / 2;
		_endIndex = _beginIndex;
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

	public void Add(T item)
	{
		++Version;
		PushBack(item);
	}

	public void Clear()
	{
		++Version;

		for (int i = 0; i < Count; ++i)
		{
			this[i] = default(T);
		}
		_beginIndex = (_elems.Length / 2) * ChunkSize;
		_endIndex = _beginIndex;
	}

	public bool Contains(T item)
	{
		return IndexOf(item) >= 0;
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
			++Version; //version is also incremented in RemoveAt()
			return false;
		}

		RemoveAt(index);
		return true;
	}

	public int Count => _endIndex - _beginIndex;
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
		++Version;

		if (index < 0 || index > Count)
		{
			throw new ArgumentOutOfRangeException();
		}

		T temp;
		if (index > Count / 2)
		{
			for (int i = index; i < Count; ++i)
			{
				temp = this[i];
				this[i] = item;
				item = temp;
			}
			PushBack(item);
		}
		else
		{
			for (int i = index - 1; i >= 0; --i)
			{
				temp = this[i];
				this[i] = item;
				item = temp;
			}
			PushFront(item);
		}
	}

	public void RemoveAt(int index)
	{
		++Version;

		if (index > Count / 2)
		{
			for (int i = index; i < Count - 1; ++i)
			{
				this[i] = this[i + 1];
			}
			this[Count - 1] = default(T);
			--_endIndex;
		}
		else
		{
			for (int i = index; i > 0; --i)
			{
				this[i] = this[i - 1];
			}
			this[0] = default(T);
			++_beginIndex;
		}
	}

	public T this[int index]
	{
		get
		{
			if (index < 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			int arrIndex = _beginIndex + index;
			return _elems[arrIndex / ChunkSize][arrIndex % ChunkSize];
		}
		set
		{
			++Version;
			if (index < 0 || index > Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			int arrIndex = _beginIndex + index;
			_elems[arrIndex / ChunkSize][arrIndex % ChunkSize] = value;
		}
	}

	public void PushBack(T item)
	{
		++Version;

		if (_endIndex / ChunkSize >= _elems.Length)
		{
			ExtendRight();
		}
		int endChunk = _endIndex / ChunkSize;
		int endInner = _endIndex % ChunkSize;

		if (_elems[endChunk] == null)
		{
			_elems[endChunk] = new T[ChunkSize];
		}

		_elems[endChunk][endInner] = item;
		++_endIndex;
	}

	public void PushFront(T item)
	{
		++Version;

		if (_beginIndex == 0)
		{
			ExtendLeft();
		}

		int beginChunk = (_beginIndex - 1) / ChunkSize;
		int beginInner = (_beginIndex - 1) % ChunkSize;

		if (_elems[beginChunk] == null)
		{
			_elems[beginChunk] = new T[ChunkSize];
		}

		_elems[beginChunk][beginInner] = item;
		--_beginIndex;
	}

	public void PopBack()
	{
		++Version;

		if (Count == 0)
		{
			throw new InvalidOperationException("Deque is empty.");
		}

		int endChunk = (_endIndex - 1) / ChunkSize;
		int endInner = (_endIndex - 1) % ChunkSize;

		_elems[endChunk][endInner] = default(T);
		--_endIndex;
	}

	public void PopFront()
	{
		++Version;

		if (Count == 0)
		{
			throw new InvalidOperationException("Deque is empty.");
		}

		int beginChunk = _beginIndex / ChunkSize;
		int beginInner = _beginIndex % ChunkSize;

		_elems[beginChunk][beginInner] = default(T);
		++_beginIndex;
	}

	public IDeque<T> GetReverseView()
	{
		return new ReverseDeque<T>(this);
	}

	private void ExtendRight()
	{
		++Version;

		int nextSize = (int)Math.Ceiling(_elems.Length * CapacityMultiplier);
		T[][] nextArr = new T[nextSize][];


		int beginChunk = _beginIndex / ChunkSize;
		int endChunk = _endIndex / ChunkSize;
		endChunk = _endIndex % ChunkSize == 0 ? endChunk - 1 : endChunk; //end might point out of array bounds, but it could be also in the midlle of a chunk

		Array.Copy(_elems, beginChunk, nextArr, beginChunk, endChunk - beginChunk + 1);

		_elems = nextArr;
	}

	private void ExtendLeft()
	{
		++Version;

		int nextSize = (int)Math.Ceiling(_elems.Length * CapacityMultiplier);
		T[][] nextArr = new T[nextSize][];

		int beginChunk = _beginIndex / ChunkSize;
		int endChunk = _endIndex / ChunkSize;

		Array.Copy(_elems, beginChunk, nextArr, nextArr.Length - _elems.Length + beginChunk, endChunk - beginChunk + 1);
		//TODO check

		_beginIndex += (nextArr.Length - _elems.Length) * ChunkSize;
		_endIndex += (nextArr.Length - _elems.Length) * ChunkSize;

		_elems = nextArr;
	}
	
}

