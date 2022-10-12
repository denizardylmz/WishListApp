using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public static class IdentityResultExtension
{
    public static Result ToApplicationResult(this IdentityResult identityResult)
    {
        if (identityResult.Succeeded)
        {
            return Result.SuccessResult();
        }

        return Result.FailureResult(identityResult.Errors.Select(e => e.Description));
    }
}