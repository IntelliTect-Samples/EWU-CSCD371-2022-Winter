using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Lecture.Tests;

[TestClass]
public class PersonTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_ConstructorNameIsNull_ThrowException()
    {
        new Person(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_GivenNameIsNull_ThrowException()
    {
        Person person = new ("Inigo Montoya");
        person.Name = null!;
    }

    [TestMethod]
    public void Equality_TwoStrings_AreEqual()
    {
        string datetime = DateTime.Now.ToString();
        
        Assert.IsTrue($"Inigo Montoya { datetime} " == $"Inigo Montoya { datetime} ");
    }

    [TestMethod]
    public void Equality_TwoEqualPersons_AreEqual()
    {
        string datetime = DateTime.Now.ToString();
        Person person1 = new($"Inigo Montoya { datetime} ");
        Person person2 = new(person1.Name);
        Person person3 = 
            new($"Inigo Montoya { DateTime.Now.AddDays(1) } ");
        Assert.IsTrue(person1 == person2);
        Assert.IsTrue(person1 != person3);
    }
}

