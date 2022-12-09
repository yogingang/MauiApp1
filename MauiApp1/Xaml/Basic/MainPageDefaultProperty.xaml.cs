using System.Diagnostics;

namespace MauiApp1.Xaml.Basic;

public partial class MainPageDefaultProperty : ContentPage
{
    private int _tabCount = 0;
	public MainPageDefaultProperty()
	{
		InitializeComponent();
	}
    void OnTapGestureRecognizerTapped(object sender, EventArgs args)
    {
        ++_tabCount;
        var lblSender = (Label)sender;
        // watch the monkey go from color to black&white!
        if (_tabCount % 2 == 0)
        {
            lblSender.TextColor = Colors.Blue;
        }
        else
        {
            lblSender.TextColor = Colors.Red;
        }
    }
}