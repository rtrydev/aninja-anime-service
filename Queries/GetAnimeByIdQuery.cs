using aninja_browse_service.Models;
using MediatR;

namespace aninja_browse_service.Queries;

public class GetAnimeByIdQuery : IRequest<Anime>
{
    public int Id { get; set; }
}