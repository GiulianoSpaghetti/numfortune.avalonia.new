using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace numfortune.avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static Task<HttpResponseMessage> httpResponse;
    private static HttpClient client= new HttpClient();
    private static Task<string> sTask;
    private static string s;
    public static string Tick()
    {
        s = "";
        try
        {
            httpResponse = client.GetAsync("https://api.justyy.workers.dev/api/fortune");
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        if (httpResponse.Result.IsSuccessStatusCode)
        {
             
            sTask = httpResponse.Result.Content.ReadAsStringAsync();
            s=sTask.Result;
            s = s.Substring(1, s.Length - 2);
            s = s.Replace("\\n", System.Environment.NewLine);
            s = s.Replace("\\t", "	");
            s = s.Replace("\\\"", "\"");
        }
        else
        {
            s = $"The HTTP status code is ${httpResponse.Result.StatusCode}";
        }
        return s;

    }
}
