using System.Diagnostics;

namespace MauiApp1.Xaml.XamlCode;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    void LoginButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Clicked !");
    }
}