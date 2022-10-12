using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void ConfigureApplication(this IServiceCollection provider)
    {

        provider.AddMediatR(Assembly.GetExecutingAssembly());
    }
    
}