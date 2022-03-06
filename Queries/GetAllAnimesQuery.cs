using aninja_anime_service.Enums;
using aninja_anime_service.Models;
using MediatR;

namespace aninja_anime_service.Queries;

public class GetAllAnimesQuery : IRequest<IEnumerable<Anime>>
{
    public OrderByAnimesOptions OrderBy { get; set; }
}