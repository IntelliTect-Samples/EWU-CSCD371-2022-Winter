using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;
[TestClass]
public class DisplayServiceTests
{
    [TestMethod]
    public void DisplayService_VerifyDisplay_OutputIsString()
    {
        var display = new Mock<IConsoleDisplay>();
        display.Setup(x => x.Display(It.IsAny<string>()));

        Jester jester = new(display.Object, new JokeService());
        jester.TellJoke();
        display.Verify(x => x.Display(It.IsAny<string>()), Times.Once);
    }
}


