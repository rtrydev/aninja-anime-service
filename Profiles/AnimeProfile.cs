using aninja_browse_service.Commands;
using aninja_browse_service.Dtos;
using aninja_browse_service.Models;
using AutoMapper;

namespace aninja_browse_service.Profiles;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<Anime, AnimeDetailsDto>();
        CreateMap<Anime, AnimeDto>();
        CreateMap<AnimeWriteDto, Anime>();
        CreateMap<AnimeWriteDto, AddAnimeCommand>();
        CreateMap<AddAnimeCommand, Anime>();
        CreateMap<AnimeWriteDto, UpdateAnimeCommand>();
        CreateMap<UpdateAnimeCommand, Anime>();
        CreateMap<Anime, GrpcAnimeModel>();
        CreateMap<Anime, AnimePublishedDto>();
    }
}