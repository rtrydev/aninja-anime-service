using aninja_anime_service.Models;
using aninja_anime_service.Dtos;
using MediatR;

namespace aninja_anime_service.Commands;

public class AddAnimeCommand : IRequest<Anime>
{
    public string? OriginalTitle { get; set; }
    public string? TranslatedTitle { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EpisodeCount { get; set; }
    public string? Status { get; set; }
    public string? Demographic { get; set; }
}