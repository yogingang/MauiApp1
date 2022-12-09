namespace MauiApp1.Xaml.StackNavigation.Data;
public interface ILatLongService
{
    Task<(double Latitude, double Longitude)> GetLatLong();
}
