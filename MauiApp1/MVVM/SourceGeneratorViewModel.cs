using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.MVVM;
public partial class SourceGeneratorViewModel : ObservableObject
{
    public SourceGeneratorViewModel()
    {
        Name = "My Name is Yogingang";
    }

    //private string _name;
    //public string Name
    //{
    //    get => _name;
    //    set => SetProperty(ref _name, value);
    //}

    [ObservableProperty]
    private string name;


    //private void ChangeName() => Name = "Change New Name";
    //private IRelayCommand changeNameCommand;
    //public IRelayCommand ChangeNameCommand =>
    //    changeNameCommand ??= new RelayCommand(ChangeName);

    [RelayCommand]
    private void ChangeName() => Name = "Change New Name";

}
