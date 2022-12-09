using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MauiApp1.MVVM.Commanding;
public class IncrementCounterViewModel : ObservableObject
{
    public IncrementCounterViewModel()
    {
        IncrementCounterCommand = new RelayCommand(IncrementCounter);
        IncrementCounterCommandAsync = new AsyncRelayCommand(IncrementCounterAsync);
    }

    private int counter;

    public int Counter
    {
        get => counter;
        private set => SetProperty(ref counter, value);
    }

    public ICommand IncrementCounterCommand { get; }

    public IAsyncRelayCommand IncrementCounterCommandAsync { get; }

    private void IncrementCounter() => Counter++;

    private async Task IncrementCounterAsync()
    {
        await Task.Delay(3000);
        Counter++;
    }
}
