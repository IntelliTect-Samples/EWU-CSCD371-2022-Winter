namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            Jester jester = new Jester(new JokeService(), new PrintService());

            jester.TellJoke();
        }
    }
}
