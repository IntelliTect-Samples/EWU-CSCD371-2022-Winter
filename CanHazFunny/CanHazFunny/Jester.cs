namespace CanHazFunny
{
    public class Jester
    {
        private readonly IJokeService _jokeService;
        private readonly IConsoleDisplay _consoleDisplay;

        public Jester(IConsoleDisplay? output, IJokeService? service)
        {
            if (service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }
            _consoleDisplay = output;
            _jokeService = service;
        }

        public void TellJoke()
        {
            string validFormat = _jokeService.GetJoke();
            while (
                validFormat.ToLower().Contains("chuck") ||
                validFormat.ToLower().Contains("norris") ||
                validFormat.Contains("\\u"))
            {
                validFormat = _jokeService.GetJoke();
            }
            _consoleDisplay.Display(validFormat);
        }
    }
}
