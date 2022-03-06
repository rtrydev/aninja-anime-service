using aninja_anime_service.Models;
using MediatR;

namespace aninja_anime_service.Queries;

public class GetAnimeByIdQuery : IRequest<Anime>
{
    public int Id { get; set; }
}