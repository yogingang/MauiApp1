using MauiApp1.InjectableServices;
using CommunityToolkit.Maui;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MediatR;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        using var stream = Assembly.GetExecutingAssembly()
                                   .GetManifestResourceStream("MauiApp1.appsettings.json");
        var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
        builder.Configuration.AddConfiguration(config);       

        builder.Services.Scan(scan => scan
                            .FromAssemblyOf<ITransientService>()
                            //.FromAssemblies(Helper.AssemblyHelper.GetAllAssemblies(SearchOption.AllDirectories))
                            .AddClasses(classes => classes.AssignableTo<ITransientService>())
                            .AsSelfWithInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo<IScopedService>())
                            .AsSelfWithInterfaces()
                            .WithScopedLifetime()
                            .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                            .AsSelfWithInterfaces()
                            .WithSingletonLifetime()
                            );

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        return builder.Build();

    }
}
