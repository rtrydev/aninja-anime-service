using aninja_anime_service.Enums;
using aninja_anime_service.Models;
using MediatR;

namespace aninja_anime_service.Queries;

public class GetAllAnimesQuery : IRequest<IEnumerable<Anime>>
{
    public OrderByAnimesOptions OrderBy { get; set; }
    public IEnumerable<string>? Demographics { get; set; }
    public IEnumerable<string>? Statuses { get; set; }
    public string? Name { get; set; }
}