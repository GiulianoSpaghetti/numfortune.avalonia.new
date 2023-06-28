using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using System;

namespace numfortune.avalonia.Views;

public partial class MainView : UserControl
{
    HttpResponseMessage httpResponse;
    HttpClient client;
    public MainView()
    {
        InitializeComponent();
        client = new HttpClient();
        tick();
    }

    private async void tick()
    {
        try
        {
            httpResponse = await client.GetAsync("https://api.justyy.workers.dev/api/fortune");
        }
        catch (Exception ex)
        {
            cookie.Text = ex.Message;
            return;
        }

        if (httpResponse.IsSuccessStatusCode)
        {
            String s = await httpResponse.Content.ReadAsStringAsync();
            s = s.Substring(1, s.Length - 2);
            s = s.Replace("\\n", System.Environment.NewLine);
            s = s.Replace("\\t", "	");
            s = s.Replace("\\\"", "\"");
            cookie.Text = s;
        }
        else
        {
            cookie.Text = $"The HTTP status code is ${httpResponse.StatusCode}";
        }

    }

    public void OnTick_Click(Object obj, RoutedEventArgs args)
    {
        tick();
    }
}
