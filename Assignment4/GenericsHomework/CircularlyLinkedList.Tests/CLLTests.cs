using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class CLLTests
    {
        int[] IntData = { 1, 2, 3, 4 };
        string[] StringData = { "These", "are", "strings" };
        string?[] NullData = { "will", "send", "data" , null };

        [TestMethod]
        public void AddData_DataInStoredOrder()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(2022);
            circularlylinkedlist.AddData(testIntData);

            for (int i = 0; i < testIntData.Length; i++)
            {
                Assert.AreEqual<int>(testIntData[i], circularlylinkedlist[i + 1]);
            }
        }

        [TestMethod]
        public void GetIndex_ReturnsObject()
        {
            Object[] themock = new Mock<Object>[3];

            for (int i = 0; i < themock.Length; i++)
            {
                themock[i] = new Mock<Object>();

            }

            CircularlyLinkedList<Object> circularlylinkedlist = new();
            circularlylinkedlist.AddData(themock);

            for (int i = 0; i < circularlylinkedlist.Count; i++)
            {
                Assert.AreEqual<string>(themock[i].ToString()!, circularlylinkedlist.GetStringOfIndex(i));
            }

        }

        [TestMethod]
        public void SetOrigin_MovesCursor()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            circularlylinkedlist.SetOrigin(2);
            Assert.AreEqual<int>(testIntData[2], circularlylinkedlist[0]);
        }

        [TestMethod]
        public void SetOrigin_HandlesNegatives()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            circularlylinkedlist.SetOrigin(-1);
            Assert.AreEqual<int>(testIntData[3], circularlylinkedlist[0]);
        }

        [TestMethod]
        public void Clear_DeleteAllNodes_ExceptCursor()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            circularlylinkedlist.SetOrigin(-1);
            circularlylinkedlist.Clear();
            Assert.AreEqual<int>(testIntData[3], circularlylinkedlist[0]);
            Assert.AreEqual<int>(1, circularlylinkedlist.Count);
            Assert.AreEqual<int>(circularlylinkedlist[0], circularlylinkedlist[1]);
        }

        [TestMethod]
        public void Clear_GarbageCollects()
        {
            CLLTest<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            WeakReference? outRef;
            outRef = circularlylinkedlist.Clear();
            Assert.IsNotNull(outRef);
            GC.Collect();
            Assert.IsFalse(outRef.IsAlive);
        }

        [TestMethod]
        public void Exists_DataDoesNotExist_ReturnsFalse()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            Assert.IsFalse(circularlylinkedlist.Exists(4));
        }

        [TestMethod]
        public void Exists_DataExist_ReturnTrue()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            Assert.IsTrue(circularlylinkedlist.Exists(testIntData[2]));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddData_DuplicateDataException()
        {
            CircularlyLinkedList<string> circularlylinkedlist = new();
            circularlylinkedlist.AddData("gavenelder");
            circularlylinkedlist.AddData("gavenelder");
        }
        [TestMethod]
        public void AddData_Increments()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);
            Assert.AreEqual<int>(testIntData.Length, circularlylinkedlist.Count);
        }

        [TestMethod]
        public void AddData_AddsData()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);

            foreach (int element in testIntData)
            {
                Assert.IsTrue(circularlylinkedlist.Exists(element));
            }
        }

        [TestMethod]
        public void AddData_IfNullReject()
        {
            CircularlyLinkedList<string?> circularlylinkedlist = new();

            circularlylinkedlist.AddData(testNullData);

            foreach (string? element in testNullData)
            {
                if (element is not null)
                {
                    Assert.IsTrue(circularlylinkedlist.Exists(element));
                }
            }

            Assert.AreEqual<int>(3, circularlylinkedlist.Count);

        }
        [TestMethod]
        public void AddData_NullCursor_DataInStoredOrder()
        {
            CircularlyLinkedList<int> circularlylinkedlist = new();
            circularlylinkedlist.AddData(testIntData);

            for (int i = 0; i < circularlylinkedlist.Count; i++)
            {
                Assert.AreEqual<int>(testIntData[i], circularlylinkedlist[i]);
            }
        }

    }
    internal class CircularlyLinkedListTest<T> : GenericsHomework.CircularlyLinkedList<T>
    {
        new public WeakReference? Clear()
        {
            if (_Cursor is not null)
            {
                WeakReference referencenode = new(_Cursor.Next);
                _Cursor.SetNext(_Cursor);
                return referencenode;

            }
            else return null;
        }
    }
} 