using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace GenericsHomework.Tests
{
    [TestClass]
    public class CircularlyLinkedListTests
    {
        int[] testIntData = { 1, 7, 22, 48 };
        string[] testStringData = { "Diego", "Karolyn", "Meatball Supreme" };
        string?[] testNullData = { "The", "Data", null, "Big" };


        [TestMethod]
        public void Exists_IfDataNotInList_ReturnsFalse()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);
            Assert.IsFalse(cll.Exists(42));
        }

        [TestMethod]
        public void Exists_IfDataInList_ReturnsTrue()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);
            Assert.IsTrue(cll.Exists(testIntData[2]));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddData_IfDuplicateData_ThrowsException()
        {
            CircularlyLinkedList<string> cll = new();
            cll.AddData("fred");
            cll.AddData("fred");
        }
        [TestMethod]
        public void AddData_IncrementsCoundt()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);
            Assert.AreEqual<int>(testIntData.Length, cll.Count);
        }

        [TestMethod]
        public void AddData_AddsData()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);

            foreach (int element in testIntData)
            {
                Assert.IsTrue(cll.Exists(element));
            }
        }

        [TestMethod]

        public void AddData_RejectsNull()
        {
            CircularlyLinkedList<string?> cll = new();

            cll.AddData(testNullData);

            foreach (string? element in testNullData)
            {
                if (element is not null)
                {
                    Assert.IsTrue(cll.Exists(element));
                }
            }

            Assert.AreEqual<int>(3, cll.Count);

        }
        [TestMethod]
        public void AddData_IfCursorIsNull_AddsDataInStoredOrder()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);

            for (int i = 0; i < cll.Count; i++)
            {
                Assert.AreEqual<int>(testIntData[i], cll[i]);
            }
        }
        [TestMethod]
        public void AddData_IfCursorExists_AddsDataInStoredOrder()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(2022);
            cll.AddData(testIntData);

            for (int i = 0; i < testIntData.Length; i++)
            {
                Assert.AreEqual<int>(testIntData[i], cll[i + 1]);
            }
        }
        [TestMethod]

        public void GetStringOfIndex_ReturnsBaseObjectToString()
        {
            Object[] mockData = new Mock<Object>[3];

            for (int i = 0; i < mockData.Length; i++)
            {
                mockData[i] = new Mock<Object>();

            }

            CircularlyLinkedList<Object> cll = new();
            cll.AddData(mockData);

            for (int i = 0; i < cll.Count; i++)
            {
                Assert.AreEqual<string>(mockData[i].ToString()!, cll.GetStringOfIndex(i));
            }

        }

        [TestMethod]
        public void SetOrigin_ChangesCursorPosition()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);
            cll.SetOrigin(2);
            Assert.AreEqual<int>(testIntData[2], cll[0]);
        }

        [TestMethod]
        public void SetOrigin_ChangesCursorPosition_HandlesNegatives()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);
            cll.SetOrigin(-1);
            Assert.AreEqual<int>(testIntData[3], cll[0]);
        }

        [TestMethod]
        public void Clear_RemovesAllNodesButCursor()
        {
            CircularlyLinkedList<int> cll = new();
            cll.AddData(testIntData);
            cll.SetOrigin(-1);
            cll.Clear();
            Assert.AreEqual<int>(testIntData[3], cll[0]);
            Assert.AreEqual<int>(1, cll.Count);
            Assert.AreEqual<int>(cll[0], cll[1]); //If cll has a single node, cll[1] still represents the adjacent node, which would be itself
        }

        [TestMethod]
        public void Clear_ProperlyGarbageCollects()
        {
            CLLTest<int> cll = new();
            cll.AddData(testIntData);
            WeakReference? outRef;
            outRef = cll.Clear();
            Assert.IsNotNull(outRef);
            GC.Collect();
            Assert.IsFalse(outRef.IsAlive);
        }

    }

    //Summary:
    //
    //An extension of CircularlyLinkedLists to test garbage collection of Clear().

    internal class CLLTest<T> : GenericsHomework.CircularlyLinkedList<T>
    {
        //Summary:
        //
        //Performs operations on a linked list identical to CircularlyLinkedList.Clear()
        //Returns a weak reference to a node that should theoretically be garbage collected after Clear()
        new public WeakReference? Clear()
        {
            if (_Cursor is not null)
            {

                WeakReference nodeRef = new(_Cursor.Next);
                _Cursor.ClearFrom();
                return nodeRef;

            }
            else return null;
        }

    }
}