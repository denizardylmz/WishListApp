using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public static class ItemConfiguration
{
    public static ModelBuilder ConfigureWishList(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WishList>().Property(p => p.Name).IsRequired();

        return modelBuilder;
    }
    
}