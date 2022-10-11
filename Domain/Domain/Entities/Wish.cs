using Domain.Common;

namespace Domain.Entities;

public class Wish : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    
    public int WishListId { get; set; }
    public WishList WishList { get; set; }
}