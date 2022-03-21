using System;

class Program
{
    static void Main()
    {
        string text = "Inigo Montoya";
        Guid guid = Guid.NewGuid();

        Console.WriteLine("Hello, World!");
        Console.WriteLine("Inigo Montoya: " + text);
        Console.WriteLine(guid.ToString());
    }


}

