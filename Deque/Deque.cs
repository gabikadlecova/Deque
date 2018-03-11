using System;
using System.Collections;
using System.Collections.Generic;

namespace Deque
{
	class Deque<T> : IDeque<T>, IList<T>
	{
		private const int ChunkSize = 8;
		private const int DefaultCapacity = 7;
		private const float CapacityMultiplier = 1.5F;

		private T[][] elems_;
		private DequeIndex begin_;
		private DequeIndex end_;

		// TODO "begin and end" variables (indices)

		public Deque()
		{
			elems_ = new T[DefaultCapacity][];
			elems_[DefaultCapacity / 2] = new T[ChunkSize];
			begin_ = new DequeIndex(DefaultCapacity / 2, 0);
			end_ = begin_;
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
			if (capacity <= 0)
			{
				throw new ArgumentException("Capacity must be a positive integer!");
			}

			int mapSize = (int)Math.Ceiling((float)capacity / ChunkSize);
			elems_ = new T[mapSize][];
			for (int i = 0; i < elems_.Length; ++i)
			{
				elems_[i] = new T[ChunkSize];
			}

			begin_ = new DequeIndex(mapSize / 2, 0);
			end_ = begin_;
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

		public int Count
		{
			get
			{

			}
		}
		public bool IsReadOnly => false;
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

		public void PushBack(T element)
		{
			throw new NotImplementedException();
		}

		public void PushFront(T elem)
		{
			throw new NotImplementedException();
		}

		public void PopBack()
		{
			throw new NotImplementedException();
		}

		public void PopFront()
		{
			throw new NotImplementedException();
		}

		private void IncreaseCapacity()
		{
			T[][] nextArr = new T[(int)(elems_.Length * CapacityMultiplier)][];

			int nextBegin = nextArr.Length / 2 - ChunkCount / 2;
			for (int i = begin_.ChunkIndex; i < end_.ChunkIndex; ++i)
			{
				nextArr[nextBegin + i - begin_.ChunkIndex] = elems_[i];
			}

			end_ = new DequeIndex(end_.ChunkIndex - begin_.ChunkIndex + nextBegin, end_.InnerIndex);
			begin_ = new DequeIndex(nextBegin, begin_.InnerIndex);

			elems_ = nextArr;
		}

		private int ChunkCount => end_.ChunkIndex - begin_.ChunkIndex;

		private int ConvertIndex(DequeIndex deqIndex)
		{
			if (deqIndex < begin_)
			{
				throw new ArgumentException("Argument is not a valid index in the deque.");     //might return -1 instead
			}

			if (deqIndex.ChunkIndex == begin_.ChunkIndex)
			{
				return deqIndex.InnerIndex - begin_.InnerIndex;
			}

			int edges = ChunkSize - begin_.InnerIndex + deqIndex.InnerIndex + 1;                //one is added to fix zero indexing shift
			int between = ChunkSize * (deqIndex.ChunkIndex - begin_.ChunkIndex - 1);

			return edges + between;
		}

		private DequeIndex ConvertIndex(int index)
		{
			if (index < 0)
			{
				throw new ArgumentException("Index cannot be a negative number.");
			}

			if (index < ChunkSize - begin_.InnerIndex)
			{
				return new DequeIndex(begin_.ChunkIndex, begin_.InnerIndex + index);
			}

			index -= ChunkSize - begin_.InnerIndex;
			int chunks = index / ChunkSize;
			int inner = index % ChunkSize;

			return new DequeIndex(chunks, inner);
		}

		private struct DequeIndex : IComparable<DequeIndex>
		{
			public int ChunkIndex { get; }
			public int InnerIndex { get; }

			public DequeIndex(int chunk, int inner)
			{
				ChunkIndex = chunk;
				InnerIndex = inner;
			}

			public int CompareTo(DequeIndex other)
			{
				int chunkComparison = ChunkIndex.CompareTo(other.ChunkIndex);
				if (chunkComparison != 0)
				{
					return chunkComparison;
				}

				return InnerIndex.CompareTo(other.InnerIndex);
			}

			public static bool operator <(DequeIndex left, DequeIndex right)
			{
				return left.CompareTo(right) < 0;
			}

			public static bool operator >(DequeIndex left, DequeIndex right)
			{
				return left.CompareTo(right) > 0;
			}

			public static bool operator <=(DequeIndex left, DequeIndex right)
			{
				return left.CompareTo(right) <= 0;
			}

			public static bool operator >=(DequeIndex left, DequeIndex right)
			{
				return left.CompareTo(right) >= 0;
			}
		}
	}
}
