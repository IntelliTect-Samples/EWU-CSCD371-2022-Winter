namespace CanHazFunny;

public class DisplayService : IConsoleDisplay
{
    public void Display(string message)
    {
        Console.WriteLine(message);
    }
}

