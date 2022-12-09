using System.Diagnostics;

namespace MauiApp1.Xaml.AddBehavior;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Save Button Clicked !");
    }
    void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Delete Button Clicked !");
    }
}