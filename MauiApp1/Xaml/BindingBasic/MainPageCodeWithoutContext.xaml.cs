namespace MauiApp1.Xaml.BindingBasic;

public partial class MainPageCodeWithoutContext : ContentPage
{
	public MainPageCodeWithoutContext()
	{
		InitializeComponent();

        label.SetBinding(Label.RotationProperty, new Binding("Value", source: slider));
    }
}