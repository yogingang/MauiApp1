using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiApp1.InjectableServices;
using Font = Microsoft.Maui.Font;

namespace MauiApp1.Alerts;

public partial class ToastPage : ContentPage, ITransientService
{
    public ToastPage(SnackbarViewModel snackbarViewModel)
    {
        InitializeComponent();
        //BindingContext = new SnackbarViewModel(new HelloWorldClass());
        BindingContext = snackbarViewModel;
    }

    private async void OnClickedToast(object sender, EventArgs e)
    {
        var toast = Toast.Make("Toast");
        await toast.Show();
    }

    private async void OnClickedCustomizeToast(object sender, EventArgs e)
    {
        var toast = Toast.Make("Big Toast.", ToastDuration.Long, 30d);
        await toast.Show();
    }
}