using System.Globalization;

namespace MauiApp1.Trigger;

public partial class StateTrigger : ContentPage
{
	public StateTrigger()
	{
		InitializeComponent();
	}
    void OnCheckedStateIsActiveChanged(object sender, EventArgs e)
    {
        StateTriggerBase stateTrigger = sender as StateTriggerBase;
        Console.WriteLine($"Checked state active: {stateTrigger.IsActive}");
    }

    void OnUncheckedStateIsActiveChanged(object sender, EventArgs e)
    {
        StateTriggerBase stateTrigger = sender as StateTriggerBase;
        Console.WriteLine($"Unchecked state active: {stateTrigger.IsActive}");
    }
}
public class InverseBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !(bool)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class TriggerViewModel : BindableObject
{
    bool isToggled = true;
    public bool IsToggled
    {
        get => isToggled;
        set
        {
            isToggled = value;
            OnPropertyChanged(nameof(IsToggled));
        }
    }
}