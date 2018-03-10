namespace Deque
{
	interface IDeque<in T>
	{
		void PushBack(T elem);
		void PushFront(T elem);
		void PopBack(T elem);
		void PopFront(T elem);
	}
}
