using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using DequeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DequeTest
{
	[TestClass]
	public class DequeTest
	{
		[TestMethod]
		public void EnumerateDeque()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			foreach (int num in deque)
			{
				Assert.AreEqual(num, coll[index]);
				++index;
			}
		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_Add()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.Add(4);
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_Remove()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.Remove(4);
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_RemoveAt()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.RemoveAt(0);
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_Insert()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.Insert(5, 2);
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_Clear()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.Clear();
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_PopBack()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.PopBack();
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_PopFront()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.PopFront();
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_PushBack()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.PushBack(4);
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_Invalidation_PushFront()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			int index = 0;
			try
			{
				foreach (int num in deque)
				{
					deque.PushFront(4);
					Assert.AreEqual(num, coll[index]);
					++index;
				}

				Assert.Fail();
			}
			catch (InvalidOperationException)
			{
			}

		}

		[TestMethod]
		public void EnumerateDeque_without_MoveNext()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add
			
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
		public void EnumerateDeque_afterEnumeration_Current()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add
			
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
		public void EnumerateDeque_afterEnumeration_MoveNext()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2 };
			Deque<int> deque = new Deque<int>(coll); //tests add
;

			using (var en = deque.GetEnumerator())
			{
				while (en.MoveNext())
				{
				}

				Assert.IsFalse(en.MoveNext());
			}
		}




		[TestMethod]
		public void Deque_Add_BackExtension()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7};
			Deque<int> deque = new Deque<int>(coll); //tests add

			coll.Add(5);
			deque.Add(5);

			Assert.AreEqual(coll.Count, deque.Count);


			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_Add_FrontExtension()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			coll.Insert(0, 5);
			deque.PushFront(5);

			Assert.AreEqual(coll.Count, deque.Count);


			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_Insert_FirstHalf()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			coll.Insert(2, 5);
			deque.Insert(2, 5);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_Insert_SecondHalf()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			coll.Insert(5, 5);
			deque.Insert(5, 5);

			Assert.AreEqual(coll.Count, deque.Count);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}


		[TestMethod]
		public void Deque_Insert_Front()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			coll.Insert(0, 5);
			deque.Insert(0, 5);

			Assert.AreEqual(coll.Count, deque.Count);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_Insert_End()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deque = new Deque<int>(coll); //tests add

			Assert.AreEqual(coll.Count, deque.Count);

			coll.Insert(coll.Count, 5);
			deque.Insert(deque.Count, 5);

			Assert.AreEqual(coll.Count, deque.Count);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_ExtendRight()
		{
			List<int> coll = new List<int>();
			Deque<int> deque = new Deque<int>(); //tests add

			for (int i = 0; i < 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.Add(i);
			}

			deque.Add(50);
			coll.Add(50);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_ExtendRight_Multiple()
		{
			List<int> coll = new List<int>();
			Deque<int> deque = new Deque<int>(); //tests add

			for (int i = 0; i < 3 * 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.Add(i);
			}

			deque.Add(50);
			coll.Add(50);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_ExtendLeft()
		{
			List<int> coll = new List<int>();
			Deque<int> deque = new Deque<int>(); //tests add

			for (int i = 0; i < 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.Add(i);
			}

			deque.PushFront(50);
			coll.Insert(0,50);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_ExtendRight_thenLeft()
		{
			List<int> coll = new List<int>();
			Deque<int> deque = new Deque<int>(); //tests add

			for (int i = 0; i < 3 * 56; i++) //see default sizes; might have changed
			{
				coll.Add(i);
				deque.Add(i);
			}

			deque.PushFront(50);
			coll.Insert(0, 50);

			int index = 0;
			foreach (int a in deque)
			{
				Assert.AreEqual(coll[index], a);
				++index;
			}
		}

		[TestMethod]
		public void Deque_For()
		{
			List<int> coll = new List<int>() { 4, 5, 8, 10, 2, 5, 6, 7 };
			Deque<int> deque = new Deque<int>(coll);

			for (int i = 0; i < deque.Count; i++)
			{
				Assert.AreEqual(coll[i], deque[i]);
			}
		}

	}
}

