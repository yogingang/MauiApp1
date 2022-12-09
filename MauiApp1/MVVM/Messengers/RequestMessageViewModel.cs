using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.Messengers;
public partial class RequestMessageViewModel : ObservableObject
{
    public RequestMessageViewModel()
    {
        Name = "My Name is Yogingang";
        WeakReferenceMessenger.Default.Register<ChangeNameRequestMessage>(this, (r,m) =>
        {
            Receive(m); 
            
        });
    }

    [RelayCommand]
    private void Register()
    {
        if (StrongReferenceMessenger.Default.IsRegistered<ChangeNameRequestMessage>(this)) return;
        StrongReferenceMessenger.Default.Register<ChangeNameRequestMessage>(this, (r, m) =>
        {
            ReceiveStrong(m);
            
        });
    }

    [RelayCommand]
    private void UnRegister()
    {
        StrongReferenceMessenger.Default.Unregister<ChangeNameRequestMessage>(this);
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public RequestMessageUser User { get; } = new();

    [RelayCommand]
    private void ChangeName() => Name = $"{DateTime.Now} Change New Name";
    
  
    void Receive(ChangeNameRequestMessage message)
    {
        Name = $"(Weak) newName = {message.Name}";
        message.Reply("(Weak)내가 해냈다");
    }

    void ReceiveStrong(ChangeNameRequestMessage message)
    {
        Name = $"(Strong) newName = {message.Name}";
        message.Reply("(Strong)내가 해냈다");
    }
}


public partial class RequestMessageUser : ObservableObject
{
    private readonly User user;

    public RequestMessageUser()
    {
        user ??= new()
        {
            Name = "My User Name is Yogingang"
        };
    }

    public string Name
    {
        get => user.Name;
        set => SetProperty(user.Name, value, user, (u, n) => u.Name = n);
    }

    [RelayCommand]
    private void ChangeName()
    {
        Name = $"{DateTime.Now} Change User Name";
        var response = WeakReferenceMessenger.Default.Send(new ChangeNameRequestMessage(Name));
        Name = response.Response;
    }

    [RelayCommand]
    private void StrongChangeName()
    {
        Name = $"{DateTime.Now} Change User Name";
        var response = StrongReferenceMessenger.Default.Send(new ChangeNameRequestMessage(Name));
        // error 처리를 위해 다음 과 같은 방식도 가능 하다. 구독한 사람이 없다면 아래와 같이 처리한다. 
        if(response.HasReceivedResponse)
            Name = response.Response;
    }
}
