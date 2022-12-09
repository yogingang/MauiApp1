using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.InjectableServices;
using Microsoft.Extensions.Configuration;

namespace MauiApp1.Configuration;
public partial class MainViewModel : ObservableObject, ITransientService
{
    private readonly IConfiguration _configuration;
    public MainViewModel(IConfiguration configuration)
    {
        Name = "My Name is Yogingang";
        _configuration = configuration;
    }

    [ObservableProperty]
    private string name;


    [RelayCommand]
    private void ChangeName() => Name = DateTime.UtcNow + " " + 
                                _configuration
                                .GetSection("Settings")
                                .GetSection("KeyThree")
                                .GetValue<string>("Message");
}
