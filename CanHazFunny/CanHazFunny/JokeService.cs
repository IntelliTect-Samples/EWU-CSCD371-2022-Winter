using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;
public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        try
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
            return JsonFormatStrip(joke);
        }
        catch (Exception)
        {


        }
        return "An Error Occured";
    }

    public void IsJson(string text)
    {
        string input = text.Trim();
        if (input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]"))
        {
            Console.WriteLine("This is JSON.");
        }
        else
        {
            Console.WriteLine("This is XML.");
        }
    }


    //take json and remove the formatting
    private static string JsonFormatStrip(string jsonString)
    {
        //{"joke": "windows isn\u2019t a virus atleast viruses do something."}
        string strippedstring = jsonString.Remove(0, 10);
        int index = strippedstring.Length;
        strippedstring = strippedstring.Remove(index - 3, 3);
        return strippedstring;
    }
}
