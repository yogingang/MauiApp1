using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.Messengers;
public partial class MessengerViewModel : ObservableObject
{
    public MessengerViewModel()
    {
        Name = "My Name is Yogingang";
        WeakReferenceMessenger.Default.Register<ChangeNameMessage>(this, (r,m) =>
        {
            Receive(m);
        });
    }

    [RelayCommand]
    private void Register()
    {
        if (StrongReferenceMessenger.Default.IsRegistered<ChangeNameMessage>(this)) return;
        StrongReferenceMessenger.Default.Register<ChangeNameMessage>(this, (r, m) =>
        {
            ReceiveStrong(m);
        });
    }

    [RelayCommand]
    private void UnRegister()
    {
        StrongReferenceMessenger.Default.Unregister<ChangeNameMessage>(this);
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public MessengerUser User { get; } = new();

    [RelayCommand]
    private void ChangeName() => Name = $"{DateTime.Now} Change New Name";
    
  
    void Receive(ChangeNameMessage message)
    {
        Name = $"(Weak) newName = {message.Name}";
    }

    void ReceiveStrong(ChangeNameMessage message)
    {
        Name = $"(Strong) newName = {message.Name}";
    }
}

public class User
{
    public string Name { get; set; }

}

public partial class MessengerUser : ObservableObject
{
    private readonly User user;

    public MessengerUser()
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
        WeakReferenceMessenger.Default.Send(new ChangeNameMessage(Name));
    }

    [RelayCommand]
    private void StrongChangeName()
    {
        Name = $"{DateTime.Now} Change User Name";
        StrongReferenceMessenger.Default.Send(new ChangeNameMessage(Name));
    }
}
