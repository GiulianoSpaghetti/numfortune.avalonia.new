using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using System;
using numfortune.avalonia.ViewModels;

namespace numfortune.avalonia.Views;

public partial class MainView : UserControl
{

    public MainView()
    {
        InitializeComponent();
        cookie.Text = MainViewModel.Tick();
    }



    public void OnTick_Click(Object obj, RoutedEventArgs args) => cookie.Text=MainViewModel.Tick();
}
