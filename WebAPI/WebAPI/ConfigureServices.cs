using Application.Interfaces;
using WebAPI.Services;

namespace WebAPI;

public static class ConfigureServices
{
    public static void ConfigureApi(this IServiceCollection provider)
    {
        provider.AddScoped<ICurrentUser, CurrentUserService>();
    }
}