using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DequeTest
{
	[TestClass]
	public class ReverseDequeTest
	{

		[TestMethod]
		public void EnumerateReverseDeque()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add

			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			foreach (int num in deque)
			{
				Assert.AreEqual(num, coll[index]);
				--index;
			}
		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_Add()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.Add(4);
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_Remove()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.Remove(4);
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_RemoveAt()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.RemoveAt(0);
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_Insert()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.Insert(5, 2);
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_Clear()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.Clear();
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_PopBack()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.PopBack();
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_PopFront()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.PopFront();
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_PushBack()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.PushBack(4);
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_Invalidation_PushFront()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			int index = coll.Count - 1;
			try
			{
				foreach (int num in deque)
				{
					deque.PushFront(4);
					Assert.AreEqual(num, coll[index]);
					--index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_without_MoveNext()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			try
			{
				using (var en = deque.GetEnumerator())
				{
					int a = en.Current;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_afterEnumeration_Current()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			try
			{
				using (var en = deque.GetEnumerator())
				{
					while (en.MoveNext())
					{
					}

					int a = en.Current;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateReverseReverseDeque_afterEnumeration_MoveNext()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			using (var en = deque.GetEnumerator())
			{
				while (en.MoveNext())
				{
				}

				Assert.IsFalse(en.MoveNext());
			}
		}




		[TestMethod]
		public void ReverseDeque_Add_BackExtension()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			coll.Add(5);
			deque.PushFront(5);

			Assert.AreEqual(coll.Count, deque.Count);


			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_Add_FrontExtension()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			coll.Insert(0, 5);
			deque.PushBack(5);

			Assert.AreEqual(coll.Count, deque.Count);


			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_Insert_FirstHalf()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			coll.Insert(2, 5);
			deque.Insert(coll.Count - 2, 5);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_Insert_SecondHalf()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);
			
			deque.Insert(coll.Count - 5, 90);
			coll.Insert(5, 90);

			Assert.AreEqual(coll.Count, deque.Count);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}


		[TestMethod]
		public void ReverseDeque_Insert_Front()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			coll.Insert(coll.Count, 5);
			deque.Insert(0, 5);

			Assert.AreEqual(coll.Count, deque.Count);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_Insert_End()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			Assert.AreEqual(coll.Count, deque.Count);

			coll.Insert(0, 5);
			deque.Insert(deque.Count, 5);

			Assert.AreEqual(coll.Count, deque.Count);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_ExtendRight()
		{
			List<int> coll = new List<int>();
			Deque<int> deq = new Deque<int>(); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			for (int i = 0; i < 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.PushFront(i);
			}

			deque.PushFront(50);
			coll.Add(50);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_ExtendRight_Multiple()
		{
			List<int> coll = new List<int>();
			Deque<int> deq = new Deque<int>(); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			for (int i = 0; i < 3 * 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.PushFront(i);
			}

			deque.PushFront(50);
			coll.Add(50);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_ExtendLeft()
		{
			List<int> coll = new List<int>();
			Deque<int> deq = new Deque<int>(); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			for (int i = 0; i < 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.PushFront(i);
			}

			deque.PushBack(50);
			coll.Insert(0, 50);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_ExtendRight_thenLeft()
		{
			List<int> coll = new List<int>();
			Deque<int> deq = new Deque<int>(); //tests add
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			for (int i = 0; i < 3 * 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.PushFront(i);
			}

			deque.PushBack(50);
			coll.Insert(0, 50);

			int index = coll.Count - 1;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				--index;
			}
		}

		[TestMethod]
		public void ReverseDeque_For()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deq = new Deque<int>(coll);
			ReverseDeque<int> deque = new ReverseDeque<int>(deq);

			for (int i = 0; i < deque.Count; i++)
			{
				Assert.AreEqual(coll[coll.Count - 1 - i], deque[i]);
			}
		}

	}
}
