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

    // i dont think we even need this check

    //public void IsJson(string text)
    //{
    //    string input = text.Trim();
    //    if (input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]"))
    //    {
    //        Console.WriteLine("This is JSON.");
    //    }
    //    else
    //    {
    //        Console.WriteLine("This is XML.");
    //    }
    //}

    //public static bool TextFormatIsJson(string text)
    //{
    //    if (text.StartsWith("{") && text.EndsWith("}"))
    //        return true;
    //    else
    //        return false;
    //}

    private static string JsonFormatStrip(string jsonString)
    {
        string strippedString = jsonString.Remove(0, 10);
        int index = strippedString.Length;
        strippedString = strippedString.Remove(index - 3, 3);
        return strippedString;
    }
}
