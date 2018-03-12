using System;
using System.Collections;
using System.Collections.Generic;



namespace Deque
{


	public class Deque<T> : IDeque<T>, IList<T>
	{
		private const int ChunkSize = 8;
		private const int DefaultCapacity = 7;
		private const float CapacityMultiplier = 1.5F;

		private T[][] _elems;

		/* the deque is indexed as if all chunks formed an uniform array; chunk number/inner chunk indices are obtained by division/modulo */
		private int _beginIndex;	//points to the first element (its index)
		private int _endIndex;		//points just after the last element

		internal ulong Version { get; private set; }

		/// <summary>
		/// Constructs a deque with default initial capacity.
		/// </summary>
		public Deque() : this(DefaultCapacity)
		{
		}

		/// <summary>
		/// Construct a deque by adding the elements of the enumeration.
		/// </summary>
		/// <param name="en">IEnumerable which represents the elements which will be added to the deque.</param>
		public Deque(IEnumerable<T> en) : this()
		{
			foreach (T elem in en)
			{
				Add(elem);
			}
		}

		/// <summary>
		/// Inicializes a deque with given initial capacity. The capacity is distributed evenly to both sides of the deque
		/// as to provide room for both PushBack() and PushFront()
		/// </summary>
		/// <param name="capacity">Initial capacity.</param>
		public Deque(int capacity)
		{
			_elems = new T[capacity][];
			_beginIndex = ChunkSize * capacity / 2;
			_endIndex = _beginIndex;
		}


		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
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
			_beginIndex = _elems.Length / 2 * ChunkSize;		//begin and end indices point now to the middle
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
				++Version;	 //version is also incremented in RemoveAt()
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

			//only the smaller part of the deque needs to be moved
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

			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			//only the smaller part of the deque needs to be moved
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
				return _elems[arrIndex / ChunkSize][arrIndex % ChunkSize];   //converts absolute indices to chunk and inner indices
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

			//the deque needs more space on the right
			if (_endIndex / ChunkSize >= _elems.Length)
			{
				ExtendRight();
			}

			//indices !!!need to be computed here, as ExtendRight might change chunk indices.
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

			//the deque needs more space on the left
			if (_beginIndex == 0)
			{
				ExtendLeft();
			}

			//indices !!!need to be computed here, as ExtendLeft will change chunk indices.
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

			//Ceiling is necessary, because for smaller capacities the sizeup would be too small (or none at all)
			int nextSize = (int)Math.Ceiling(_elems.Length * CapacityMultiplier);
			T[][] nextArr = new T[nextSize][];


			int beginChunk = _beginIndex / ChunkSize;
			int endChunk = _endIndex / ChunkSize;
			endChunk = _endIndex % ChunkSize == 0
				? endChunk - 1
				: endChunk; //end might point out of array bounds, but it could be also in the middle of a chunk

			//the old chunks are copied to the same offset from the start as they were positioned in the old array
			Array.Copy(_elems, beginChunk, nextArr, beginChunk, endChunk - beginChunk + 1);

			_elems = nextArr;
		}

		private void ExtendLeft()
		{
			++Version;

			//Ceiling is necessary, because for smaller capacities the sizeup would be too small (or none at all)
			int nextSize = (int)Math.Ceiling(_elems.Length * CapacityMultiplier);
			T[][] nextArr = new T[nextSize][];

			int beginChunk = _beginIndex / ChunkSize;
			int endChunk = _endIndex / ChunkSize;

			//the chunks maintain the offset from the end of the array
			Array.Copy(_elems, beginChunk, nextArr, nextArr.Length - _elems.Length + beginChunk, endChunk - beginChunk + 1);

			_beginIndex += (nextArr.Length - _elems.Length) * ChunkSize; //begin and end indices have been moved to the right by extension size
			_endIndex += (nextArr.Length - _elems.Length) * ChunkSize;

			_elems = nextArr;
		}

		private class Enumerator : IEnumerator<T>
		{
			private int _index;
			private readonly Deque<T> _deque;

			private readonly ulong _version;	//version number of the deque at enumerator construction time

			public Enumerator(Deque<T> deque)
			{
				_deque = deque;
				_index = -1;
				_version = deque.Version;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				//modifications are not allowed while enumerating
				if (_version != _deque.Version)
				{
					throw new InvalidOperationException();
				}

				++_index;
				return _index < _deque.Count;
			}

			public void Reset()
			{
				throw new NotSupportedException();
			}

			public T Current
			{
				get
				{
					//modifications are not allowed while enumerating
					if (_version != _deque.Version || _index == -1 || _index >= _deque.Count)
					{
						throw new InvalidOperationException();
					}
					return _deque[_index];
				}
			}

			object IEnumerator.Current => Current;
		}
	}

}