namespace MauiApp1.InjectableServices;
public interface IInjectableService { }
public interface ITransientService : IInjectableService { }
public interface IScopedService : IInjectableService { }
public interface ISingletonService : IInjectableService { }
