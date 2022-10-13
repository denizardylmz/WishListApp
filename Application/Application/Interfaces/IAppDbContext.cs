using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    public DbSet<Domain.Entities.Wish> Wishes { get; set; }
    public DbSet<Domain.Entities.WishList> WishLists { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
}