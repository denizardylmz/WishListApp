using System.Globalization;
using Domain.Common;
using Domain.Identity;

namespace Domain.Entities;

public class WishList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    
    public List<AppUser> User { get; set; }
    public List<Wish> Wishes { get; set; }
    
}