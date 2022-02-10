using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void SimpleTest_CreateNode_Success()
        {
            Node<String> node = new("Hello");
            Assert.AreEqual(node.Size, 1);
        }

        [TestMethod]
        public void SimpleTest_CreateNewNode_ValueReturnsCorrectValue()
        {
            Node<String> node = new("Hello");
            Assert.AreEqual(node.Value, "Hello");
        }

        [TestMethod]
        public void NodeListIsNull_AppendNode_Success()
        {
            Node<String> node = new("Node 1");
            Assert.AreEqual(node.Size, 1);
            node.Append("Pie");
            Assert.AreEqual(node.Size, 2);
        }

        [Ignore]
        [TestMethod]
        public void SimpleTest_ClearNode_Success()
        {
            Node<String> node = new("Node 1");
            Assert.AreEqual(node.Size, 1);
            node.Append("Pie");
            Assert.AreEqual(node.Size, 2);
        }

        [Ignore]
        [TestMethod]
        public void SimpleTest_NodeExists_ReturnsTrue()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");

            Assert.IsTrue(node.Exists("Moon")); //Only works for the final amended 
        }

        [TestMethod]
        public void SimpleTest_NodeDoesntExists_ReturnsFalse()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");

            Assert.IsFalse(node.Exists("Justin")); //Only works for the final amended 
        }


        [TestMethod]
        public void SimpleTest_CreateLinkedNodes_NextReturnsValueOfSecondNode()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");

            Assert.AreEqual("Pie", node.Next.Value);
        }
    }
}