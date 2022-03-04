using aninja_browse_service.Dtos;
using aninja_browse_service.Models;
using MediatR;

namespace aninja_browse_service.Commands;

public class AddAnimeCommand : IRequest
{
    public AnimeWriteDto AnimeToAdd { get; set; }
}