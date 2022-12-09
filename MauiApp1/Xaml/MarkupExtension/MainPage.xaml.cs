using System.Diagnostics;

namespace MauiApp1.Xaml.MarkupExtension;

public partial class MainPage : ContentPage
{
    public const double MyFontSize = 28;
    public MainPage()
    {
        InitializeComponent();
    }
}

public class GlobalFontSizeExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return MainPage.MyFontSize;
    }
}
