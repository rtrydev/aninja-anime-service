using aninja_browse_service.Enums;

namespace aninja_browse_service.Models;

public class Anime
{
    public int Id { get; set; }
    public string? OriginalTitle { get; set; }
    public string? TranslatedTitle { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EpisodeCount { get; set; }
    public Status Status { get; set; }
    public Demographic Demographic { get; set; }

}