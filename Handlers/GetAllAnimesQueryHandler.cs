using aninja_browse_service.Dtos;
using aninja_browse_service.Enums;
using aninja_browse_service.Models;
using aninja_browse_service.Queries;
using aninja_browse_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_browse_service.Handlers;

public class GetAllAnimesQueryHandler : IRequestHandler<GetAllAnimesQuery, IEnumerable<Anime>>
{
    private IAnimeRepository _animeRepository;

    public GetAllAnimesQueryHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<IEnumerable<Anime>> Handle(GetAllAnimesQuery request, CancellationToken cancellationToken)
    {
        var items = await _animeRepository.GetAll();
        var result = request.OrderBy switch
        {
            OrderByAnimesOptions.None => items,
            OrderByAnimesOptions.ByTitle => items.OrderBy(x => x.TranslatedTitle),
            OrderByAnimesOptions.ByEpisodesCount => items.OrderBy(x => x.EpisodeCount),
            _ => throw new ArgumentException()
        };

        return result;
    }
}