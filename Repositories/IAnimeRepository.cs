using aninja_browse_service.Models;

namespace aninja_browse_service.Repositories;

public interface IAnimeRepository
{
    Task<bool> SaveChangesAsync();

    Task<IEnumerable<Anime>> GetAll();
    Task<Anime?> GetById(int id);
    Task<Anime> Create(Anime anime);
    Anime Update(Anime anime);
    void Delete(Anime anime);
}