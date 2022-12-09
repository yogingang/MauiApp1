using MauiApp1.InjectableServices;

namespace MauiApp1.Configuration;

public partial class MainPage : ContentPage, ITransientService
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
    }
}