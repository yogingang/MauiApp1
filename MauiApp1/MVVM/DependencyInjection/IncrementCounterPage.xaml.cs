namespace MauiApp1.MVVM.DependencyInjection;

public partial class IncrementCounterPage : ContentPage
{
    public IncrementCounterPage(IncrementCounterViewModel incrementCounterViewModel)
	{
		InitializeComponent();
		BindingContext = incrementCounterViewModel;
	}
}