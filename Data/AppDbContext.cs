using aninja_browse_service.Enums;
using aninja_browse_service.Models;
using Microsoft.EntityFrameworkCore;

namespace aninja_browse_service.Data;

public class AppDbContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>()
            .Property(x => x.Demographic)
            .HasConversion<string>();
        
        modelBuilder.Entity<Anime>()
            .Property(x => x.Status)
            .HasConversion<string>();
    }
}