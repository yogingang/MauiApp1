using CommunityToolkit.Mvvm.DependencyInjection;

namespace MauiApp1.MVVM.Messengers;

public partial class MessengerPage : ContentPage
{
	public MessengerPage()
	{
		InitializeComponent();
        //BindingContext = Ioc.Default.GetRequiredService<ObservableReceipientViewModel>();
    }

    public SourceGeneratorViewModel ViewModel => (SourceGeneratorViewModel)BindingContext;

    protected override void OnAppearing()
    {
        base.OnAppearing();

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

     
    }
}