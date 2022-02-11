using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void NodeReturning()
        {
            Node<string> node = new("node");
            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void ValueAppend()
        {
            Node<string> node = new("Testing1");
            node.Append("Testing2");
            node.Append("Testing3");
            node.Append("Testing4");
            node.Append("Testing5");
            Assert.AreEqual<string>("Testing1", node.ToString()!);
            Assert.AreEqual<string>("Testing2", node.Next.ToString()!);
            Assert.AreEqual<string>("Testing3", node.Next.Next.ToString()!);
            Assert.AreEqual<string>("Testing4", node.Next.Next.Next.ToString()!);
            Assert.AreEqual<string>("Testing5", node.Next.Next.Next.Next.ToString()!);
            Assert.AreEqual<string>("Testing1", node.Next.Next.Next.Next.Next.ToString()!);
        }

        [TestMethod]
        public void ExistingValueAppend()
        {
            Node<string> node = new("value");
            node.Append("value");
        }

        [TestMethod]
        public void ListClear()
        {
            Node<string> node = new("Testing1");
            node.Append("Testing2");
            node.Append("Testing3");
            node.Clear();
            Assert.AreEqual(node, node.Next);
        }

    }
}