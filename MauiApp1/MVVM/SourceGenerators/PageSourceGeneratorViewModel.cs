using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System.ComponentModel.DataAnnotations;

namespace MauiApp1.MVVM.SourceGenerators;

public partial class PageSourceGeneratorViewModel : ObservableValidator
{
    public PageSourceGeneratorViewModel()
    {
        Name = "My Name is Yogingang";
        WeakReferenceMessenger.Default.Register<ChangeNameMessage>(this, (r, m) =>
        {
            Receive(m);
        });
        WeakReferenceMessenger.Default.Register<PropertyChangedMessage<string>>(this, (r, m) =>
        {
            ReceivePropertyChangedMessage(m);
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

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string _name;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    [MinLength(5)]
    private string _editName;

    public string FullName
    {
        get => $"FullName {_name} Kim";
    }

    public PageSourceGeneratorViewModelUser User { get; } = new();

    [RelayCommand]
    private void ChangeName()
    {
        if (HasErrors)
        {
            Name = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
        }
        else
        {
            Name = $"{DateTime.Now} Change New Name";
        }
    }

    [ObservableProperty]
    private string _propertyDescription;

    void Receive(ChangeNameMessage message)
    {
        Name = $"(Weak) newName = {message.Name}";
    }

    void ReceiveStrong(ChangeNameMessage message)
    {
        Name = $"(Strong) newName = {message.Name}";
    }

    void ReceivePropertyChangedMessage(PropertyChangedMessage<string> message)
    {
        PropertyDescription = $"propertyName={message.PropertyName} oldName = {message.OldValue}, newName ={message.NewValue}";
    }
}

public class PageSourceGeneratorUser
{
    public string Name { get; set; }

}

public partial class PageSourceGeneratorViewModelUser : ObservableRecipient
{
    private readonly PageSourceGeneratorUser user;

    public PageSourceGeneratorViewModelUser()
    {
        user ??= new()
        {
            Name = "My User Name is Yogingang"
        };
        SendName = "Init";
    }

    [ObservableProperty]
    [NotifyPropertyChangedRecipients]
    private string _sendName;
    
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
        SendName = $"{DateTime.Now}";
    }

    [RelayCommand]
    private void StrongChangeName()
    {
        Name = $"{DateTime.Now} Change User Name";
        StrongReferenceMessenger.Default.Send(new ChangeNameMessage(Name));
        SendName = $"{DateTime.Now}";
    }
}
