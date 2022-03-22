using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;


namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess pingProcess { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        pingProcess = new();
    }

    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void Run_BasicRun_Success()
    {
        int exitCode = pingProcess.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }

}
