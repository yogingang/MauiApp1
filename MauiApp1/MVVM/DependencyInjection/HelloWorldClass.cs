namespace MauiApp1.MVVM.DependencyInjection;
public interface IHelloWorldClass
{
    string Execute();
}
public class HelloWorldClass : IHelloWorldClass
{
    public string Execute() => $"{DateTime.Now} Hello World!";
}
