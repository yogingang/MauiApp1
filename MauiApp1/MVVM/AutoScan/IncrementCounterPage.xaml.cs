using MauiApp1.InjectableServices;

namespace MauiApp1.MVVM.AutoScan;
//[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class IncrementCounterPage : ContentPage, ITransientService
{
	public IncrementCounterPage(IncrementCounterViewModel incrementCounterViewModel)
	{
		InitializeComponent();
		BindingContext = incrementCounterViewModel;
	}
}