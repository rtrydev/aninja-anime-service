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
        return await _context.Animes.Include(x => x.Genres).ToListAsync();
    }

    public async Task<Anime?> GetById(int id)
    {
        return await _context.Animes.Include(x => x.Genres).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(Anime anime)
    {
        if (anime.Genres is not null)
        {
            var genres = _context.Genres.Where(x => anime.Genres.Contains(x)).ToArray();
            anime.Genres = genres;
        }
        await _context.Animes.AddAsync(anime);
    }

    public void Update(Anime anime)
    {
        _context.Update(anime);
    }

    public void Delete(Anime anime)
    {
        _context.Animes.Remove(anime);
    }
}