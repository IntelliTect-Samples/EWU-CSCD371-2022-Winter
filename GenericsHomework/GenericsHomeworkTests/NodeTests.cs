using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void SetNextNode_NullNode_ReturnsFalse()
        {
            Node<string> node = new Node<string>("firstNode");

            bool result = node.SetNextNode(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetNextNode_ValidNode_Success()
        {
            Node<string> node = new Node<string>("firstNode");
            Node<string> anotherNode = new Node<string>("another node");
            node.SetNextNode(anotherNode);
            Node<string> nextNode = new Node<string>("secondNode");


            Node<string> priorNextNode = node.Next;
            bool result = node.SetNextNode(nextNode);

            Assert.IsTrue(result);
            Assert.AreEqual<Node<string>>(nextNode, node.Next);
            Assert.AreEqual<Node<string>>(nextNode.Next, priorNextNode);
        }

        [TestMethod]
        public void Append_ValidValue_Success()
        {
            Node<string> node = new Node<string>("firstNode");
            node.AppendNode("append value");

            Node<string> nextNode = node.Next;

            Assert.AreEqual<Node<string>>(nextNode, node.Next);
            Assert.AreEqual<Node<string>>(node.Next.Next, node);
        }

        [ExpectedException(typeof(ArgumentException), "Cannot add duplicate value to list")]
        [TestMethod]
        public void Append_DuplicateValue_ThrowsException()
        {
            Node<string> node = new Node<string>("firstNode");
            Node<string> nextNode = new Node<string>("duplicate value");
            node.SetNextNode(nextNode);

            node.AppendNode("append value");
        }

        [TestMethod]
        public void Clear_OneNode_Success()
        {
            Node<string> node = new Node<string>("firstNode");

            node.Clear();

            Assert.AreEqual<Node<string>>(node, node.Next);
        }

        [TestMethod]
        public void Clear_MutipleNodes_Success()
        {
            Node<string> node = new Node<string>("firstNode");
            Node<string> secondNode = node.AppendNode("secondNode");
            Node<string> thirdNode = node.AppendNode("thirdNode");

            node.Clear();

            Assert.AreEqual<Node<string>>(node, node.Next);
            Assert.AreEqual<Node<string>>(secondNode, secondNode.Next);
            Assert.AreEqual<Node<string>>(thirdNode, thirdNode.Next);
        }

        [TestMethod]
        public void ValueExists_ValuePresent_Success()
        {
            Node<string> node = new Node<string>("firstNode");
            Node<string> secondNode = node.AppendNode("secondNode");

            bool exists = node.ValueExists("secondNode");

            Assert.IsTrue(exists);
        }
           

        [TestMethod]
        public void ValueExists_ValueNotPresent_Success()
        {
            Node<string> node = new Node<string>("firstNode");
            Node<string> secondNode = node.AppendNode("secondNode");

            bool exists = node.ValueExists("random value");

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void ToString_ValidNode_Success()
        {
            Node<string> node = new Node<string>("firstNode");

            string resultString = node.ToString();

            Assert.AreEqual<string>(resultString,"firstNode");
        }
    }
}