using CommunityToolkit.Mvvm.DependencyInjection;

namespace MauiApp1.MVVM.Messengers;

public partial class RequestMessagePage : ContentPage
{
	public RequestMessagePage()
	{
		InitializeComponent();
        //BindingContext = Ioc.Default.GetRequiredService<ObservableReceipientViewModel>();
    }

    public RequestMessageViewModel ViewModel => (RequestMessageViewModel)BindingContext;

    protected override void OnAppearing()
    {
        base.OnAppearing();

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

     
    }
}