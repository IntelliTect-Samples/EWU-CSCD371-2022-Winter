namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Constructor_ValidParameters_NodeIsNotNull()
    {
        //Arrange
        Node<int> headNode = new(42);
        //Assert
        Assert.IsNotNull(headNode);
    }

    //maybe find a better name that is shorter 
    [TestMethod]
    public void Constructor_ValidParameters_NodePointsToItselfOnCreation()
    {
        //Arrange
        Node<int> headNode = new(42);
        //Assert
        Assert.AreEqual(headNode, headNode.Next);
    }

    [TestMethod]
    [DataRow(42)]
    [DataRow(23)]
    public void Constructor_ValidParameters_NodeSucessfullyStoresValue(int value)
    {
        //Arrange
        Node<int> headNode = new(value);
        //Assert
        Assert.AreEqual(headNode.Value, value);
    }

    [TestMethod]
    public void Exists_ValidParameters_ChecksHeadReturnsTrue()
    {
        //Arrange
        Node<int> headNode = new(42);
        //Assert
        Assert.IsTrue(headNode.Exists(42));
    }

    [TestMethod]
    public void Exists_ValidParameters_ReturnsTrueAllValuesExists()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);
        headNode.Append(20);
        headNode.Append(19);
        headNode.Append(18);

        //Assert
        Assert.IsTrue(headNode.Exists(19));
        Assert.IsTrue(headNode.Exists(18));
        Assert.IsTrue(headNode.Exists(21));
        Assert.IsTrue(headNode.Exists(22));
        Assert.IsTrue(headNode.Exists(20));
    }

    [TestMethod]
    public void Exists_ValidParameters_ReturnsFalseValuesDoNotExists()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);
        headNode.Append(20);
        headNode.Append(19);
        headNode.Append(18);

        //Assert
        Assert.IsFalse(headNode.Exists(999));
        Assert.IsFalse(headNode.Exists(888));
        Assert.IsFalse(headNode.Exists(777));
        Assert.IsFalse(headNode.Exists(666));
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_DuplicateNodeValue_ThrowsException()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);
        headNode.Append(22);
    }

    
    [TestMethod]
    public void Append_ValidParameters_SuccessfullyInsertsNode()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(24);
        headNode.Append(43);

        //Assert
        Assert.AreEqual(24, headNode.Next.Value);
        Assert.AreEqual(43, headNode.Next.Next.Value);
        //Check if last node will point back to head.
        Assert.AreEqual(42, headNode.Next.Next.Next.Value);
    }

    [TestMethod]
    public void ToSting_ValuesAsAString_SuccessfullyReturnsMatching()
    {
        //Arrange
        Node<string> testNode = new("42");

        //Act


        //Assert
        Assert.AreEqual("42", testNode.ToString()!);
    }
    [TestMethod]
    public void ToSting_ValuesAsAnInt_SuccessfullyReturnsMatching()
    {
        //Arrange
        Node<int> testNode = new(42);

        //Act


        //Assert
        Assert.AreEqual(42, int.Parse(testNode.ToString()!));
    }

    [TestMethod]
    public void Clear_WithSingleNode_ConfirmClearedWithExists()
    {
        //Arrange
        Node<int> testNode = new(42);

        //Act
        testNode.Clear();

        //Assert
        Assert.IsTrue(testNode.Exists(42));
    }

    [TestMethod]
    public void Clear_WithMultipleNode_ConfirmClearedWithExists()
    {
        //Arrange
        Node<int> testNode = new(42);
        testNode.Append(22);
        testNode.Append(21);
        testNode.Append(20);
        testNode.Append(19);
        testNode.Append(18);
        //Act
        testNode.Clear();

        //Assert
        Assert.IsTrue(testNode.Exists(42));
        Assert.IsFalse(testNode.Exists(22));
        Assert.IsFalse(testNode.Exists(21));
        Assert.IsFalse(testNode.Exists(20));
        Assert.IsFalse(testNode.Exists(19));
        Assert.IsFalse(testNode.Exists(18));
    }
}
