using aninja_anime_service.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aninja_anime_service.Dtos;

public class AnimeWriteDto
{
    [Required]
    [StringLength(100)]
    public string OriginalTitle { get; set; } = "";
    [Required]
    [StringLength(100)]
    public string TranslatedTitle { get; set; } = "";
    [StringLength(150)]
    public string? ImgUrl { get; set; }
    [StringLength(1000)]
    public string? Description { get; set; }
    [Range(typeof(DateTime), "1/1/1970", "1/1/2025")]
    public DateTime StartDate { get; set; }
    [Range(typeof(DateTime), "1/1/1970", "1/1/2025")]
    public DateTime EndDate { get; set; }
    [Range(0, 10000)]
    public int EpisodeCount { get; set; }
    [DefaultValue("NotYetAired")]
    public string? Status { get; set; }
    [DefaultValue("Seinen")]
    public string? Demographic { get; set; }
}