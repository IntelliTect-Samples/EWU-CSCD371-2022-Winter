
class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Hello, World!");
            GetNumberFromConsole();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    private static void GetNumberFromConsole()
    {
        int? number = null;
        while (number is null)
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();
            if (input is not null)
            {
                if (input.ToLower() == "stop")
                {
                    throw new InvalidOperationException("User is quiting");
                }

                try
                {
                    number=EnterNumber(input);
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("Quit");
                    return;
                }
                catch (ArgumentException) 
                {
                    Console.WriteLine($"Hey.... {input} is not a number (stupid)!!");
                }
                catch(Exception)
                {
                    // Never have an empty Exception block
                }
            }
        }
    }

    private static int? EnterNumber(string input)
    {
        int number;
        try
        {
            number = int.Parse(input); // Replace with int.TryParse()
            Console.WriteLine($"The value is: {number} ");
        }
        catch (FormatException exception) // Need to change this exception type.
        {
            throw new ArgumentException(
                message:"Input is not a valid integer.", 
                paramName:nameof(input),
                innerException: exception);
        }


        return number;
    }
}