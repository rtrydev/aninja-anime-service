namespace aninja_anime_service.Dtos;

public class AnimeSearchResultDto
{
    public IEnumerable<AnimeDto> Animes { get; set; }
    public int AllCount { get; set; }
}