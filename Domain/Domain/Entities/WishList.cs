using Domain.Common;

namespace Domain.Entities;

public class WishList : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public ICollection<Wish> Wishes { get; set; }
    
}