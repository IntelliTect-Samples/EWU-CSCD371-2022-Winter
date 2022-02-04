using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;
public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {

        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        return JsonFormatStrip(joke);

    }

    private static string JsonFormatStrip(string jsonString)
    {
        string strippedString = jsonString.Remove(0, 10);
        int index = strippedString.Length;
        strippedString = strippedString.Remove(index - 3, 3);
        return strippedString;
    }
}
