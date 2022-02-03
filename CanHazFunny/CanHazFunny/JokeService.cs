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

    public bool TextFormatIsJson(string text)
    {
        if (text.StartsWith("{") && text.EndsWith("}"))
            return true;
        else
            return false;
    }

    private static string JsonFormatStrip(string jsonString)
    {
        string strippedstring = jsonString.Remove(0, 10);
        int index = strippedstring.Length;
        strippedstring = strippedstring.Remove(index - 3, 3);
        return strippedstring;
    }
}
