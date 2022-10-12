using System.Security.Claims;
using Application.Interfaces;
using Domain.Identity;

namespace WebAPI.Services;

public class CurrentUserService : ICurrentUser
{
    private IHttpContextAccessor _accessor;


    public CurrentUserService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    public string UserName => _accessor.HttpContext?.User?.Identity.Name;
}