using MauiApp1.MVVM;
using MauiApp1.Xaml.StackNavigation.Pages;
using MauiApp1.Xaml.StaticResource;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("SourceGenerator", typeof(SourceGenerator));
    }
}
