using aninja_anime_service.Commands;
using aninja_anime_service.Dtos;
using aninja_anime_service.Models;
using AutoMapper;

namespace aninja_anime_service.Profiles;

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
        CreateMap<Anime, GrpcAnimeModel>()
            .ForMember(dest => dest.AnimeId, opt => opt.MapFrom(src => src.Id));
        CreateMap<Anime, AnimePublishedDto>();
    }
}