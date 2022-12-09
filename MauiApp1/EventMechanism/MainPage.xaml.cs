using MauiApp1.InjectableServices;

namespace MauiApp1.EventMechanism;
public partial class MainPage : ContentPage, ITransientService
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}