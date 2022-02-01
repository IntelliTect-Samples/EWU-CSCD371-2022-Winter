using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class ConsoleOutputTests
    {


       [TestMethod]
       public void Output_PrintsString()
        {
            StringWriter consoleOut = new();
            Console.SetOut(consoleOut);

            ConsoleOutput stringOut = new();

            string printString = "Hello, World!";

            stringOut.Output(printString);

            Assert.AreEqual<string>(consoleOut.ToString(), (printString + Environment.NewLine));
            


        }
    }
}
