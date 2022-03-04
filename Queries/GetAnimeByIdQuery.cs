using aninja_browse_service.Dtos;
using MediatR;

namespace aninja_browse_service.Queries;

public class GetAnimeByIdQuery : IRequest<AnimeReadDto>
{
    public int Id { get; set; }
}