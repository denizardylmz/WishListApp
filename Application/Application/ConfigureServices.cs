using System.Diagnostics;
using System.Reflection;
using Application.Common.Behaviors;
using Application.WishList.Commands.CreateWishList;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection provider)
    {
        provider.AddScoped<IValidator<CreateWishListCommand>, CreateWishListValidator>();
        provider.AddMediatR(Assembly.GetExecutingAssembly());
        
        provider.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

        return provider;
    }
    
}