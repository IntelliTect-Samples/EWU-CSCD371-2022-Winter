namespace Lecture.Tests;

[TestClass]
public class Lecture1UnitTestingTests
{
    Person Person { get; set; } = null!; // Assined in TestInitialize
    string UserName { get; set; } = "";
    string Password { get; set; } = "";

    [TestInitialize]
    public void Initialize()
    {
        Person = new("Inigo Montoya");
        UserName = "Inigo.Montoya";
        Password = "YouKilledMyF@ther!";
    }

    [TestMethod]
    public void Login_GivenInvalidPassword_Failure()
    {
        Password = "InvalidPwd";
        bool result = Person.Login(UserName, Password);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Login_GivenValidUserNameAndPassword_Success()
    {
        bool success = Person.Login(UserName, Password);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void Login_GivenInvalidUsername_Failure()
    {
        UserName = "MarkMichaelis";
        bool result = Person.Login(UserName, "Bad Password");
        Assert.IsFalse(result);
    }

}