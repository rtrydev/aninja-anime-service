using aninja_anime_service.Models;

namespace aninja_anime_service.SyncDataServices;

public interface IAnimeTagDataClient
{
    IEnumerable<Anime> ReturnAllAnimeWithTags(IEnumerable<int> tagIds);
}