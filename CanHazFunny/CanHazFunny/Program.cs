namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int x = 0; x < 50; x++)
            {
                new Jester(new DisplayService(), new JokeService()).TellJoke();
            }
        }
    }
}
