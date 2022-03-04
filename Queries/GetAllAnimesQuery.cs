using aninja_browse_service.Dtos;
using aninja_browse_service.Enums;
using MediatR;

namespace aninja_browse_service.Queries;

public class GetAllAnimesQuery : IRequest<IEnumerable<AnimeReadDto>>
{
    public OrderByAnimesOptions OrderBy { get; set; }
}