using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Behaviors;
public partial class BehaviorFirstViewModel : ObservableObject
{
    [ObservableProperty]
    private string _message;

    [RelayCommand]
    private void Click() => Message = "눌렀다";
}
