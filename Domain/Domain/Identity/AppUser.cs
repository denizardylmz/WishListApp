using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Domain.Identity;

public class AppUser : IdentityUser
{
    public ICollection<WishList> WishLists { get; set; }
}