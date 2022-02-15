using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lecture.Tests;

[TestClass]
public class StorageServiceTests
{
    [TestMethod]
    public void ToText_UsingMock_Success()
    {
        Mock<ISavable> mock = new();
        mock.SetupSequence(
            savable => savable.ToText()).Returns("Something").Returns("SomethingElse");

        Assert.AreEqual<string?>("Something", mock.Object.ToText());
        Assert.AreEqual<string?>("SomethingElse", mock.Object.ToText());

        mock.Verify<string?>(savable => savable.ToText(), Times.Exactly(2));
    }

    [TestMethod]
    public void Save_GiveMockThing_Success()
    {
        MockThing mockSavable = new("Inigo Montoya");
        //StorageService storageService = new(mockSavable);
    }


    [TestMethod]
    public void StorageService_GivenInMemoryStore_Success()
    {
        Mock<ISavable> mock = new();
        InMemoryStore store = new();
        mock.Setup<string?>(savable => savable.ToText()).Returns("mockToText");
        StorageService storageService = new(store);

        //storageService.Save(mock.Object);

        //mock.Verify()

    }
}
