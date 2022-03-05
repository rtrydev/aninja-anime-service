using aninja_browse_service.Dtos;

namespace aninja_browse_service.AsyncDataServices;

public interface IMessageBusClient
{
    void PublishNewAnime(AnimePublishedDto animePublishedDto);
}