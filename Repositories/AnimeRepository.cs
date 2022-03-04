using aninja_browse_service.Data;
using aninja_browse_service.Models;
using Microsoft.EntityFrameworkCore;

namespace aninja_browse_service.Repositories;

public class AnimeRepository : IAnimeRepository
{
    private AppDbContext _context;

    public AnimeRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<IEnumerable<Anime>> GetAll()
    {
        return await _context.Animes.ToListAsync();
    }

    public async Task<Anime?> GetById(int id)
    {
        return await _context.Animes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(Anime anime)
    {
        await _context.Animes.AddAsync(anime);
    }

    public async Task Update(Anime anime)
    {
        
        _context.Update(anime);
    }

    public async Task Delete(Anime anime)
    {
        _context.Animes.Remove(anime);
    }
}