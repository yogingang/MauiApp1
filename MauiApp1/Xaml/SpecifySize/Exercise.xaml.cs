namespace MauiApp1.Xaml.SpecifySize;

public partial class Exercise : ContentPage
{
	public Exercise()
	{
		InitializeComponent();
        target.HorizontalOptions = LayoutOptions.Center;
        target.VerticalOptions = LayoutOptions.Center;

    }

    void OnHorizontalStartClicked(object sender, EventArgs e) 
    { target.HorizontalOptions = LayoutOptions.Start; }
    void OnHorizontalCenterClicked(object sender, EventArgs e) 
    { target.HorizontalOptions = LayoutOptions.Center; }
    void OnHorizontalEndClicked(object sender, EventArgs e) 
    { target.HorizontalOptions = LayoutOptions.End; }
    void OnHorizontalFillClicked(object sender, EventArgs e) 
    { target.HorizontalOptions = LayoutOptions.Fill; }

    void OnVerticalStartClicked(object sender, EventArgs e) 
    { target.VerticalOptions = LayoutOptions.Start; }
    void OnVerticalCenterClicked(object sender, EventArgs e) 
    { target.VerticalOptions = LayoutOptions.Center; }
    void OnVerticalEndClicked(object sender, EventArgs e) 
    { target.VerticalOptions = LayoutOptions.End; }
    void OnVerticalFillClicked(object sender, EventArgs e) 
    { target.VerticalOptions = LayoutOptions.Fill; }
}