using Application.Common.Models;
using Application.Interfaces;
using Domain.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAppDbContext _context;
    private IUserClaimsPrincipalFactory<AppUser> _userClaimsPrincipalFactory;
    private IAuthorizationService _authorizationService;

    public IdentityService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
         IAppDbContext context, IUserClaimsPrincipalFactory<AppUser> userClaimsPrincipalFactory, IAuthorizationService authenticationService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authenticationService;
    }
    
    public async Task<(Result result, string userId)> CreateUserAsync(string userName, string mail, string password)
    {
        var result = await _userManager.CreateAsync(new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = userName,
            Email = mail,
        }, password);
        
        return (result.ToApplicationResult(), _userManager.FindByNameAsync(userName).Result.Id);
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        var user =  await  _userManager.FindByIdAsync(userId);

        return user.UserName;
    }

    public async Task<bool> IsUserInRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user != null && _userManager.IsInRoleAsync(user, role).Result;
    }

    
    
    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<Result> AddRoleToUserAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user != null)
        {
            var res = await _userManager.AddToRoleAsync(user, role);
            return res.ToApplicationResult();
        }

        return Result.FailureResult(new[] {"User not found"});
    }

    public async Task<AppUser> LogInAsync(string name, string password)
    {
        var user = await _userManager.FindByNameAsync(name);
        
        
        if (user != null)
        {
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        }

        return user;
    }
    
    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }
}