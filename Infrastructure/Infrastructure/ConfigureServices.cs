using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{

    public static void ConfigureInfrastructure(this IServiceCollection provider, IConfiguration configuration)
    {
        provider.AddDbContext<AppDbContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


    }
    
}