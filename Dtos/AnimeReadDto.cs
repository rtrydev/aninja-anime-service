using aninja_browse_service.Enums;

namespace aninja_browse_service.Dtos;

public class AnimeReadDto
{
    public string? OriginalTitle { get; set; }
    public string? TranslatedTitle { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int EpisodeCount { get; set; }
    public Status Status { get; set; }
    public Demographic Demographic { get; set; }
}