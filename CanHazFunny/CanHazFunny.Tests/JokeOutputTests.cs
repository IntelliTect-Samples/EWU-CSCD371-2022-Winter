using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;

[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class JokeOutputTests
{
    [TestMethod]
    public void JokeOutput_WritesToConsole_True()
    {
        JokeOutput jokeOutput = new JokeOutput();
        string test = "test";
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);


        jokeOutput.TellJoke(test);
        string trimmedResult = stringWriter.ToString().Trim( new char[] { '{', '}' }).Remove(4);
        stringWriter.Flush();
        stringWriter.Close();

        Assert.AreEqual<string>(test, trimmedResult);

        


    }

}

