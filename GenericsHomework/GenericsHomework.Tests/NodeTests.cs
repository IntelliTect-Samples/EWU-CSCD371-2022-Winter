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
    public void TestToStringReturnsCorrectly()
    {
        Assert.AreEqual<object>(_Node!.ToString(), "1");
    }
}
