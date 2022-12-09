using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.InjectableServices;

namespace MauiApp1.Alerts;
public partial class SnackbarViewModel : ObservableObject, ITransientService
{
    public SnackbarViewModel(IHelloWorldClass helloWorld)
    {
        _helloWorld = helloWorld;
    }

    [ObservableProperty]
    private int _counter;

    [ObservableProperty]
    private string _message;

    private readonly IHelloWorldClass _helloWorld;

    [RelayCommand]
    private void IncrementCounter() => Counter++;

    [RelayCommand]
    private void ChangeMessage()
    {
        Message = _helloWorld.Execute();

    }
}
