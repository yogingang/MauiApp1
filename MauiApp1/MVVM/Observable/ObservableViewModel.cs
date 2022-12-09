using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.MVVM.Observable;
public partial class ObservableViewModel : ObservableObject
{
    public ObservableViewModel()
    {
        Name = "My Name is Yogingang";
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    [RelayCommand]
    private void ChangeName() => Name = $"{DateTime.Now} Change New Name";
}

public class User
{
    public string Name { get; set; }
   
}

public partial class ObservableUser : ObservableObject
{
    private readonly User user;

    //public ObservableUser(User user) => this.user = user;
    public ObservableUser()
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

    [RelayCommand]
    private void ChangeName() => Name = $"{DateTime.Now} Change User Name";
}

public partial class ObservableTask : ObservableObject
{
    private TaskNotifier requestTask;
    private bool isProcessing = false;

    public Task RequestTask
    {
        get => requestTask;
        set => SetPropertyAndNotifyOnCompletion(ref requestTask, value);
    }

    [RelayCommand]
    private void DelayTask() => RequestTask = Task.Delay(3000);

    [RelayCommand]
    private async void Move() 
    {
        if (isProcessing) return;

        isProcessing = true;
        await Shell.Current.GoToAsync("SourceGenerator");
        await Task.Delay(500);
        isProcessing = false;
    }

    private bool CanExecuteCommand()
    {
        
        return !isProcessing;
    }
}

public static partial class ViewLocator
{
    public static ObservableViewModel Model = new ObservableViewModel();
    public static ObservableUser User = new ObservableUser();
    public static ObservableTask Task = new ObservableTask();

}