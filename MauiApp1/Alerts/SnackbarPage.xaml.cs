using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiApp1.InjectableServices;
using Font = Microsoft.Maui.Font;

namespace MauiApp1.Alerts;

public partial class SnackbarPage : ContentPage, ITransientService
{
    public SnackbarPage(SnackbarViewModel snackbarViewModel)
    {
        InitializeComponent();
        //BindingContext = new SnackbarViewModel(new HelloWorldClass());
        BindingContext = snackbarViewModel;
    }

    private async void OnClickedSnackbar(object sender, EventArgs e)
    {
        await this.DisplaySnackbar("SnackBar");
    }

    private async void OnClickedCustomizeSnackbar(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.Green,
            ActionButtonTextColor = Colors.Blue,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(14),
            ActionButtonFont = Font.SystemFontOfSize(14),
            CharacterSpacing = 0.5
        };

        var snackbar = Snackbar.Make(
            "This is a Snackbar",
            async () => await DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK"),
            "Close",
            TimeSpan.FromSeconds(3),
            snackbarOptions);

        await snackbar.Show(cancellationTokenSource.Token);
    }
}