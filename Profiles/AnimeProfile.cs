using aninja_browse_service.Dtos;
using aninja_browse_service.Models;
using AutoMapper;

namespace aninja_browse_service.Profiles;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<Anime, AnimeReadDto>();
        CreateMap<AnimeReadDto, Anime>();
        CreateMap<Anime, AnimeWriteDto>();
        CreateMap<AnimeWriteDto, Anime>();
    }
}