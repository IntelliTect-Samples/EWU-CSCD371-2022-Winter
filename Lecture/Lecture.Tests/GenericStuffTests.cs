using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Lecture.Tests;

[TestClass]
public class GenericStuffTests
{
    [TestMethod]
    public void GivenList()
    {
        List<string> list = new();
        list.Add("Inigo Montoya");
        list.Add("Princess Buttercup");

        // list.Add(42); // This won't compile because the list is of strings!
        _ = list[1].ToUpper();   // The data type coming out is guarenteed to be a string!

        Assert.AreEqual<int>(42 /*.ToString()*/, list.Count + 40);
    }
}
