using System;
using System.Collections;
using System.Collections.Generic;

namespace Deque
{
	class Deque<T> : IDeque<T>, IList<T>
	{
		private const int ChunkSize = 5;
		private const int DefaultCapacity = 7;

		private T[][] elems_;



		public Deque()
		{
			elems_ = new T[DefaultCapacity][];
			elems_[DefaultCapacity / 2] = new T[ChunkSize];
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		public int Count { get => throw new NotImplementedException(); }
		public bool IsReadOnly { get => throw new NotImplementedException(); }
		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public T this[int index]
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public void PushBack(T elem)
		{
			throw new NotImplementedException();
		}

		public void PushFront(T elem)
		{
			throw new NotImplementedException();
		}

		public void PopBack(T elem)
		{
			throw new NotImplementedException();
		}

		public void PopFront(T elem)
		{
			throw new NotImplementedException();
		}
	}
}
