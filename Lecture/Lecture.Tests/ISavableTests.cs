using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lecture.Tests;

[TestClass]
public class ISavableTests
{
    [TestMethod]
    public void SimpleSave_GivenPerson_PersonString()
    {
        ISavable person = new Person("Inigo");
        Assert.AreEqual<string?>("Name: Inigo; DateOfBirth: 1/1/0001", person.ToText());
    }

    [TestMethod]
    public void SimpleSave_GivenAThing_ThingString()
    {
        ISavable thing = new MockThing("Thing 1");
        Assert.AreEqual<string?>("Name: Thing 1", thing.ToText());
    }

    [TestMethod]
    public void SimpleSave_GivenADocument_DocumentString()
    {
        Document thing = new ("Thing 1");
        Assert.AreEqual<string?>("Name: Thing 1, Content: ", ((ISavable)thing).ToText());
    }



#pragma warning disable CA1806 // This is intentionally demonstrating a less than great API.
    [TestMethod]
    public void APIDesignExampleWithToUpper()
    {
        string text = "Inigo Montoya";
        text.ToUpper();
        Assert.AreEqual<string>("Inigo Montoya", text);
        Assert.AreEqual<string>("INIGO MONTOYA", text.ToUpper());
    }
#pragma warning restore CA1806 // Do not ignore method results
}

