using aninja_browse_service.Enums;
using aninja_browse_service.Models;
using MediatR;

namespace aninja_browse_service.Queries;

public class GetAllAnimesQuery : IRequest<IEnumerable<Anime>>
{
    public OrderByAnimesOptions OrderBy { get; set; }
}