using aninja_anime_service.Enums;
using aninja_anime_service.Models;
using aninja_anime_service.Queries;
using aninja_anime_service.Repositories;
using aninja_anime_service.Dtos;
using aninja_anime_service.SyncDataServices;
using AutoMapper;
using MediatR;

namespace aninja_anime_service.Handlers;

public class GetAllAnimesQueryHandler : IRequestHandler<GetAllAnimesQuery, IEnumerable<Anime>>
{
    private IAnimeRepository _animeRepository;
    private IAnimeTagDataClient _animeTagDataClient;

    public GetAllAnimesQueryHandler(IAnimeRepository animeRepository, IAnimeTagDataClient animeTagDataClient)
    {
        _animeRepository = animeRepository;
        _animeTagDataClient = animeTagDataClient;
    }

    public async Task<IEnumerable<Anime>> Handle(GetAllAnimesQuery request, CancellationToken cancellationToken)
    {
        var items = await _animeRepository.GetAll();

        if (request.Demographics is not null && request.Demographics.Any())
        {
            var demographics = request.Demographics.Select(Enum.Parse<Demographic>);
            items = items.Where(x => demographics.Contains(x.Demographic));
        }

        if (request.Statuses is not null && request.Statuses.Any())
        {
            var statuses = request.Statuses.Select(Enum.Parse<Status>);
            items = items.Where(x => statuses.Contains(x.Status));
        }

        if (request.Name is not null)
        {
            request.Name = request.Name.Trim();
            var foundItems = items.Where(x => x.TranslatedTitle.ToUpper().Contains(request.Name.ToUpper()));
            if (foundItems is null || !foundItems.Any())
            {
                items = items.Where(x => x.OriginalTitle.Contains(request.Name));
            }
            else
            {
                items = foundItems;
            }
            
        }

        if (request.TagIds is not null && request.TagIds.Any())
        {
            var anime = _animeTagDataClient.ReturnAllAnimeWithTags(request.TagIds);
            items = items.Where(x => anime.Any(y => x.Id == y.Id));
        }
        
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