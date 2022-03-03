using aninja_browse_service.Enums;
using aninja_browse_service.Models;
using Microsoft.EntityFrameworkCore;

namespace aninja_browse_service.Data;

public class AppDbContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}