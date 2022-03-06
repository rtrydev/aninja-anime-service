using aninja_anime_service.Configurations;
using aninja_anime_service.Models;
using aninja_anime_service.Enums;
using Microsoft.EntityFrameworkCore;

namespace aninja_anime_service.Data;

public class AppDbContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AnimeConfiguration());
        
        modelBuilder.Entity<Anime>()
            .Property(x => x.Demographic)
            .HasConversion<string>();
        
        modelBuilder.Entity<Anime>()
            .Property(x => x.Status)
            .HasConversion<string>();
    }
}