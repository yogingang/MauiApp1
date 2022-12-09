using MauiApp1.InjectableServices;

namespace MauiApp1.MVVM.AutoScan;

public interface IHelloWorldClass : ITransientService
{
    string Execute();
}
public class HelloWorldClass : IHelloWorldClass
{
    public string Execute() => $"{DateTime.Now} Hello World!";
}

