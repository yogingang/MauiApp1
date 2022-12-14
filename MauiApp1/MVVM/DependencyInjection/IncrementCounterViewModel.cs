using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.MVVM.DependencyInjection;
public partial class IncrementCounterViewModel : ObservableObject
{
    public IncrementCounterViewModel(IHelloWorldClass helloWorld)
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
