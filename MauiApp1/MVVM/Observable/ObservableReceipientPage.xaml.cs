using CommunityToolkit.Mvvm.DependencyInjection;

namespace MauiApp1.MVVM.Observable;

public partial class ObservableReceipientPage : ContentPage
{
	public ObservableReceipientPage()
	{
		InitializeComponent();
        //BindingContext = Ioc.Default.GetRequiredService<ObservableReceipientViewModel>();
    }

    public ObservableReceipientViewModel ViewModel => (ObservableReceipientViewModel)BindingContext;

    protected override void OnAppearing()
    {
        base.OnAppearing();

        
        ViewModel.IsActive = true;
        ViewModel.User.IsActive = true;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        ViewModel.IsActive = false;
        ViewModel.User.IsActive = false;
    }
}