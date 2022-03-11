using aninja_anime_service.Configurations;
using aninja_anime_service.Models;
using aninja_anime_service.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace aninja_anime_service.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Anime> Animes { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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