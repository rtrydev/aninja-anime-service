using aninja_anime_service.Repositories;
using AutoMapper;
using Grpc.Core;

namespace aninja_anime_service.SyncDataServices;

public class GrpcAnimeService : GrpcAnime.GrpcAnimeBase
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IMapper _mapper;

    public GrpcAnimeService(IAnimeRepository animeRepository, IMapper mapper)
    {
        _animeRepository = animeRepository;
        _mapper = mapper;
    }

    public override async Task<AnimeResponse> GetAllAnime(GetAllRequest request, ServerCallContext context)
    {
        var response = new AnimeResponse();
        var animes = await _animeRepository.GetAll();
        foreach (var anime in animes)
        {
            response.Anime.Add(_mapper.Map<GrpcAnimeModel>(anime));
        }

        return await Task.FromResult(response);
    }
}