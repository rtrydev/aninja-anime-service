using aninja_browse_service.Enums;
using aninja_browse_service.Models;

namespace aninja_browse_service.Dtos;

public class AnimeReadDto
{
    public string? OriginalTitle { get; set; }
    public string? TranslatedTitle { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Genre>? Genres { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EpisodeCount { get; set; }
    public string? Status { get; set; }
    public string? Demographic { get; set; }
}