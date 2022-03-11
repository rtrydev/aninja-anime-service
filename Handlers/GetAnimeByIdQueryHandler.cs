using aninja_anime_service.Models;
using aninja_anime_service.Queries;
using aninja_anime_service.Repositories;
using aninja_anime_service.Dtos;
using AutoMapper;
using MediatR;

namespace aninja_anime_service.Handlers;

public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, Anime?>
{
    private IAnimeRepository _animeRepository;

    public GetAnimeByIdQueryHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<Anime?> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _animeRepository.GetById(request.Id);
        return item;
    }
}