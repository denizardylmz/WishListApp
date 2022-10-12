using Application.Common.Models;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces;

public interface IIdentityService
{
    public Task<(Result result, string userId)> CreateUserAsync(string userName, string email, string password);
    
    public Task<string> GetUserNameAsync(string userName);
    
    public Task<bool> IsUserInRoleAsync(string userId, string role);
    
    public Task<Result> DeleteUserAsync(string userId);
    
    public Task<Result> AddRoleToUserAsync(string userId, string role);

    public Task<AppUser> LogInAsync(string userName, string password);
    public Task<bool> AuthorizeAsync(string userId, string policyName);
}