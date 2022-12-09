namespace MauiApp1.Xaml.FlyoutNavigation.Data;
public interface ILatLongService
{
    Task<(double Latitude, double Longitude)> GetLatLong();
}
