using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Behaviors;
public partial class BehaviorSecondViewModel : ObservableObject
{
    public BehaviorSecondViewModel()
    {
        Progress = 0.0d;
    }
    [ObservableProperty]
    private string _message;

    [RelayCommand]
    private void MaxLengthReached() => Message = "최대길이에 도달하였다";

    [ObservableProperty]
    private double _progress;

    [RelayCommand]
    private async void Execute()
    {
        Progress = 0.0d;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
        await Task.Delay(500);
        Progress += 0.1;
    }
}
