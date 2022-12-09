using MauiApp1.InjectableServices;

namespace MauiApp1.Alerts;
public interface IHelloWorldClass:ITransientService
{
    string Execute();
}
public class HelloWorldClass : IHelloWorldClass
{
    public string Execute() => $"{DateTime.Now} Hello World!";
}
