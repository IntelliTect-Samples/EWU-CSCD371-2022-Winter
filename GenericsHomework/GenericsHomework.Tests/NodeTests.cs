using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    public Node<object>? _Node;


    [TestInitialize]
    public void Init()
    {
        Node<object> nn = new Node<object>(1);
        _Node = nn;
    }

    [TestMethod]
    public void ToString_ReturnsExpectedValue()
    {
        Assert.AreEqual<object>(_Node!.ToString(), "1");
    }

    [TestMethod]
    public void Exists_GivenIncludedValue_ReturnsTrue()
    {
        Assert.IsTrue(_Node.Exists(1));
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void AppendDuplicateValue_ThrowsException()
    {
        _Node!.Append(1);
    }
}
