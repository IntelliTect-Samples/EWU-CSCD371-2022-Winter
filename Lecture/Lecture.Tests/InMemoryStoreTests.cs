using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Lecture.Tests;
[TestClass]
public class InMemoryStorageTests
{
    [TestMethod]
    public void Save_GivenMockSavable_Success()
    {
        InMemoryStore? store = new();
        MockThing mockThing = new("Inigo Montoya");
        store.Save(mockThing);
        Assert.AreEqual<string?>("Inigo Montoya", (store.Item as MockThing)?.Name);
        Assert.AreEqual<string?>("Name: Inigo Montoya", store.Item?.ToText());
        Assert.AreEqual<ISavable?>(mockThing, store.Item);  // Use This Way
    }
}
