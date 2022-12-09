using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.Xaml.RelativeBindings;

public partial class MainPage : ContentPage
{
	public DefaultViewModel DefaultViewModel { get; set; }
	public MainPage()
	{
		InitializeComponent();
		DefaultViewModel = new DefaultViewModel();

    }
}

public class DefaultViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

	public DefaultViewModel()
	{
		_employees ??= new()
		{
			"Tompson", 
            "Curry",
            "Green_Bad_Man",
            "Wiggins",
            "Poole",
        };
	}

	public ObservableCollection<string> _employees;
	public ObservableCollection<string> Employees
	{
		get { return _employees; }
		set
		{
            _employees = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Employees"));
        }
	}
}
