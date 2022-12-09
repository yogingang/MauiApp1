using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.InjectableServices;
using MauiApp1.Request;
using MauiApp1.Services;
using MediatR;
using System.Collections.ObjectModel;

namespace MauiApp1.EventMechanism;
public partial class MainViewModel : ObservableObject, ITransientService
{
    public MainViewModel(IMediator mediator)
    {
        UserModels ??= new ObservableCollection<UserModel>();
        _mediator = mediator;
    }

    [ObservableProperty]
    private int _counter;

    [ObservableProperty]
    private string _message;

    private readonly IMediator _mediator;

    [RelayCommand]
    private void IncrementCounter() => Counter++;

    [RelayCommand]
    private async void CallAPI()
    {
        Message = await _mediator.Send(new GetUserCommand());


        var users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(Message);

        foreach (var user in users)
        {
            UserModels.Add(new UserModel
            {
                id = user.id,
                firstName = user.first_name,
                lastName = user.last_name,
                email = user.email,
                gender = user.gender,
                ipAddress = user.ip_address,
            });
        }
    }

    public ObservableCollection<UserModel> UserModels
    {
        get;
        set;
    }
}

public partial class UserModel : ObservableObject
{
    [ObservableProperty]
    public int id;
    [ObservableProperty]
    public string firstName;
    [ObservableProperty]
    public string lastName;
    [ObservableProperty]
    public string email;
    [ObservableProperty]
    public string gender;
    [ObservableProperty]
    public string ipAddress;
}


