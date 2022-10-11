using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Domain.Identity;

public class AppUser : IdentityUser<int>
{
    public List<WishList> WishLists { get; set; }
}