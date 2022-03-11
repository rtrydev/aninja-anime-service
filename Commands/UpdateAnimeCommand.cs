using aninja_anime_service.Models;
using MediatR;

namespace aninja_anime_service.Commands;

public class UpdateAnimeCommand : IRequest<Anime?>
{
    public int Id { get; set; }
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