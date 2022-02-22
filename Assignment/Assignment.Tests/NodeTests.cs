using System;
using System.Linq;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asssignmet.Tests;

[TestClass]
public class NodeTests
{
    public Node<object>? _Node;


    [TestInitialize]
    public void Initialize()
    {
        Node<object> newNode = new(1);
        _Node = newNode;
    }

    [TestMethod]
    public void ToString_ReturnsExpectedString()
    {
        Assert.AreEqual<string>(_Node!.ToString()!, "1");
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
        _Node!.Append(3.14);
        Assert.IsTrue(_Node!.Exists("2"));
        Assert.IsTrue(_Node!.Exists(3.14));
        Assert.IsTrue(_Node!.Exists(1));
    }

    [TestMethod]
    public void Clear_RemoveAllExceptCurrentNode_WorksAsExpected()
    {
        _Node!.Append(3);
        _Node!.Append("egg");
        _Node!.Clear();
        Assert.IsFalse(_Node!.Exists(3));
        Assert.IsFalse(_Node!.Exists("egg"));
        Assert.IsTrue(_Node!.Exists(1));
    }

}