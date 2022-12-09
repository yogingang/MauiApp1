using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Behaviors;
public partial class BehaviorThirdViewModel : ObservableObject
{
    [ObservableProperty]
    private string _message;

    [RelayCommand]
    private void Search() => Message = $"{DateTime.Now} Search 결과입니다.";
}
