using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage =new AppShell();
	}
    protected override void OnStart()
    {
        Debug.Print("OnStart");
        base.OnStart();
    }

    protected override void OnResume()
    {
        Debug.Print("OnResume");
        base.OnResume();
    }

    protected override void OnSleep()
    {
        Debug.Print("OnSleep");
        base.OnSleep();
    }
}
