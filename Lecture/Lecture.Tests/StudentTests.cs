using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Lecture.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Student_AssignGradeA_Success()
    {
        Student student = new("Pricess Buttercup");
        student.Grade = Grade.A;
        Assert.AreEqual<Grade>(Grade.A, student.Grade);
    }

    [TestMethod]
    public void Student_AssignInteger42_Success()
    {
        Student student = new("Pricess Buttercup");
        student.Grade = (Grade)5;
        Assert.AreEqual<Grade>(Grade.A, student.Grade);
    }
}
