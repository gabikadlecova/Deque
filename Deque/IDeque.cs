using System.Collections.Generic;

public interface IDeque<T> : ICollection<T>
{
	/// <summary>
	/// Pushes a new item to the end of the queue.
	/// </summary>
	/// <param name="item">Element to be pushed.</param>
	void PushBack(T item);
	/// <summary>
	/// Pushes a new item to the beginning of the queue.
	/// </summary>
	/// <param name="item">Element to be pushed</param>
	void PushFront(T item);
	/// <summary>
	/// Pops the last item of the queue.
	/// </summary>
	void PopBack();
	/// <summary>
	/// Pops the first item of the queue
	/// </summary>
	void PopFront();

	/// <summary>
	/// Provides the same deque with reversed front and back view.
	/// </summary>
	/// <returns>Reversed Deque</returns>
	IDeque<T> GetReverseView();
}

