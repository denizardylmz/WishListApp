using Application.Interfaces;
using Domain.Identity;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{

    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection provider, IConfiguration configuration)
    {
        provider.AddDbContext<AppDbContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


        provider.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();
        provider.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        provider.AddScoped<IIdentityService, IdentityService>();

        return provider;
    }
    
}