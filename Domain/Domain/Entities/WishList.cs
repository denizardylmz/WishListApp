using System.Globalization;
using Domain.Common;
using Domain.Identity;

namespace Domain.Entities;

public class WishList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    
    public ICollection<AppUser> User { get; set; }
    public ICollection<Wish> Wishes { get; set; }
    
}