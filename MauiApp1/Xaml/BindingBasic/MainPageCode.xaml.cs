namespace MauiApp1.Xaml.BindingBasic;

public partial class MainPageCode : ContentPage
{
	public MainPageCode()
	{
		InitializeComponent();

        label.BindingContext = slider;
        label.SetBinding(Label.RotationProperty, "Value");
    }
}