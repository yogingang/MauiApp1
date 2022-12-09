using MauiApp1.InjectableServices;

namespace MauiApp1.RestAPI;
public interface IUserService : ITransientService
{
    Task<string> Execute();
}

public class UserService : IUserService
{
    public async Task<string> Execute()
    {
        using HttpClient httpClient = new HttpClient();
        var response = await httpClient
            .GetAsync("https://my.api.mockaroo.com/users.json?key=8d630ff0");

        return await response.Content.ReadAsStringAsync();
    }
}


public class User
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string gender { get; set; }
    public string ip_address { get; set; }
}