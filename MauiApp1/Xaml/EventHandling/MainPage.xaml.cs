using System.Diagnostics;

namespace MauiApp1.Xaml.EventHandling;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        LogOutBtn.Clicked += LogoutButton_Clicked;

    }
    void LoginButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Login Clicked !");
    }

    void LogoutButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Logout Clicked !");
    }
}