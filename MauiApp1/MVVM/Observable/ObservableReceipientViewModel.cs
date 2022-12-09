using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.MVVM.Observable;
public partial class ObservableReceipientViewModel : ObservableRecipient, IRecipient<ChangeNameMessage>
{
    public ObservableReceipientViewModel()
    {
        Name = "My Name is Yogingang";
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public ObservablReceipienteUser User { get; } = new();

    [RelayCommand]
    private void ChangeName() => Name = $"{DateTime.Now} Change New Name";
    
    //protected override void OnActivated()
    //{
    //    Messenger.Register<ObservableReceipientViewModel, ChangeNameMessage>(this, (r, m) => (r as IRecipient<ChangeNameMessage>).Receive(m));
    //}

    void IRecipient<ChangeNameMessage>.Receive(ChangeNameMessage message)
    {
        Name = $"newName = {message.Name}";
    }
}


public partial class ObservablReceipienteUser : ObservableRecipient, IRecipient<ChangeNameMessage>
{
    private readonly User user;

    //public ObservableUser(User user) => this.user = user;
    public ObservablReceipienteUser()
    {
        user ??= new()
        {
            Name= "My User Name is Yogingang"
        };
    }

    public string Name
    {
        get => user.Name;
        set => SetProperty(user.Name, value, user, (u, n) => u.Name = n);
    }

    //protected override void OnActivated()
    //{
    //    Messenger.Register<ObservablReceipienteUser, ChangeNameMessage>(this, (r, m) => r.Receive(m));
    //}

    void IRecipient<ChangeNameMessage>.Receive(ChangeNameMessage message)
    {
        Name = $"newName = {message.Name}";
    }

    [RelayCommand]
    private void ChangeName()
    {
        Name = $"{DateTime.Now} Change User Name";
        Messenger.Send(new ChangeNameMessage(Name));

    }
}

public static partial class ViewLocator
{
    public static ObservableReceipientViewModel ReceiptentModel = new ObservableReceipientViewModel();
    public static ObservablReceipienteUser ReceipientUser = new ObservablReceipienteUser();
}