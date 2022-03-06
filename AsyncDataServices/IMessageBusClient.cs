using aninja_anime_service.Dtos;

namespace aninja_anime_service.AsyncDataServices;

public interface IMessageBusClient
{
    void PublishNewAnime(AnimePublishedDto animePublishedDto);
}