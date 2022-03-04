using aninja_browse_service.Enums;

namespace aninja_browse_service.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Anime> Animes { get; set; }
}