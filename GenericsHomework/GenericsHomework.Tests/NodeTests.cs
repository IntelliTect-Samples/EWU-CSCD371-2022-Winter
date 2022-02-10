using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void InitializeNodeClass_Success()
        {
            string item = "Item";
            Node<string> node = new(item);

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Item, item);
        }

        [TestMethod]
        public void AppendToLinkedList_Success()
        {
            Node<string> node = new("item");

            string itemToAppend = "this is data";

            node.Append(itemToAppend);
            
            Assert.AreNotEqual(node, node.Next);

            Node<string> nodeAfter = node.Next;
            Assert.AreEqual(nodeAfter.Item, itemToAppend);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AppendToLinkedList_WithExistingValue_Fail()
        {
            Node<string> node = new("item");
            node.Append("item");
        }

        [TestMethod]
        public void ClearLinkedList_Success()
        {
            Node<string> node = new("value");
            node.Append("value 2");
            Assert.AreNotEqual(node, node.Next);

            node.Clear();
            Assert.AreEqual(node, node.Next);
        }

        /* [TestMethod]
         public void ClearLinkedList_AreOldNodesDeleted_Success()
         {
             Node<string> node = new("hey there");
             node.Append("sup");
             node.Append("hello");

             Node<string> current = node.Next;
             while(current != node)
             {
                 current = current.Next;
             }

             Assert.AreNotEqual(current, node);
             node.Clear();
             Assert.IsNull(current);
         }*/

        [TestMethod]
        public void DoesValueExist_WithOneNode_Failure()
        {
            Node<string> node = new("this Node");
            Assert.IsFalse(node.Exists("hey there"));
        }

        [TestMethod]
        public void DoesValueExist_WithMultipleNodes_Failure()
        {
            Node<string> node = new("1");
            node.Append("2");
            node.Append("3");
            node.Append("4");

            Assert.IsFalse(node.Exists("my name is Nate Nelson"));

        }

        [TestMethod]
        public void DoesValueExist_WhenCurrentNode_Success()
        {
            Node<string> node = new("1");
            node.Append("2");
            node.Append("3");
            node.Append("4");

            Assert.IsTrue(node.Exists("1"));
        }

        [TestMethod]
        public void DoesValueExist_NotCurrentNode_SuccessWithTwoNodes()
        {
            Node<string> node = new("1");
            node.Append("2");

            bool result = node.Exists("2");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesValueExist_NotCurrentNode_WithMultipleNodes_Success()
        {
            Node<string> node = new("1");
            node.Append("2");
            node.Append("3");
            node.Append("4");

            Assert.IsTrue(node.Exists("2"));
            Assert.IsTrue(node.Exists("3"));
            Assert.IsTrue(node.Exists("4"));
        }
    }
}