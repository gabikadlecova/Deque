using System.Collections.Generic;

namespace Deque
{
	interface IDeque<T> : IEnumerable<T>
	{
		/// <summary>
		/// Pushes a new element to the end of the queue.
		/// </summary>
		/// <param name="element">Element to be pushed.</param>
		void PushBack(T element);
		/// <summary>
		/// Pushes a new element to the beginning of the queue.
		/// </summary>
		/// <param name="element">Element to be pushed</param>
		void PushFront(T element);
		/// <summary>
		/// Pops the last element of the queue.
		/// </summary>
		void PopBack();
		/// <summary>
		/// Pops the first element of the queue
		/// </summary>
		void PopFront();
	}
}
