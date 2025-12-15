using Microsoft.EntityFrameworkCore;
using MarketPlace.Domain.Models;

namespace MarketPlace.Persistance;
public class MarketPlaceDbContext : DbContext
{
    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
}