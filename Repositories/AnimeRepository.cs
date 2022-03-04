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
        return await _context.Animes.Select(x => new
            Anime() {
                Id = x.Id,
                OriginalTitle = x.OriginalTitle,
                TranslatedTitle = x.TranslatedTitle,
                ImgUrl = x.ImgUrl,
                Description = x.Description,
                Genres = x.Genres.Select(y => new Genre() {Id = y.Id, Name = y.Name}),
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                EpisodeCount = x.EpisodeCount,
                Status = x.Status,
                Demographic = x.Demographic
            }).ToListAsync();
    }

    public async Task<Anime?> GetById(int id)
    {
        return await _context.Animes.Select(x => new
        Anime() {
            Id = x.Id,
            OriginalTitle = x.OriginalTitle,
            TranslatedTitle = x.TranslatedTitle,
            ImgUrl = x.ImgUrl,
            Description = x.Description,
            Genres = x.Genres.Select(y => new Genre() {Id = y.Id, Name = y.Name}),
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            EpisodeCount = x.EpisodeCount,
            Status = x.Status,
            Demographic = x.Demographic
        }).FirstOrDefaultAsync(x => x.Id == id);
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

    public async Task Update(Anime anime)
    {
        
        _context.Update(anime);
    }

    public async Task Delete(Anime anime)
    {
        _context.Animes.Remove(anime);
    }
}