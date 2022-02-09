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
        Assert.IsTrue(_Node!.Exists(1));
    }

    [TestMethod]
    public void Exists_GivenExcludedValue_ReturnsFalse()
    {
        Assert.IsFalse(_Node!.Exists("egg"));
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void Append_DuplicateValue_ThrowsException()
    {
        _Node!.Append(1);
    }

    [TestMethod]
    public void Append_NewValue_WorksAsExpected()
    {
        _Node!.Append("2");
        Assert.IsTrue(_Node!.Exists("2"));
        Assert.IsTrue(_Node!.Exists(1));
    }

    [TestMethod]
    public void Clear_RemoveAllExceptCurrentNode_WorksAsExpected()
    {
        _Node!.Append(3);
        _Node!.Clear();
        Assert.IsTrue(_Node.Exists(1));
        Assert.IsFalse(_Node.Exists(3));
    }

}
