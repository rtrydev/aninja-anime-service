using aninja_browse_service.Dtos;
using aninja_browse_service.Models;
using aninja_browse_service.Queries;
using aninja_browse_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_browse_service.Handlers;

public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, Anime>
{
    private IAnimeRepository _animeRepository;

    public GetAnimeByIdQueryHandler(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<Anime> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _animeRepository.GetById(request.Id);
        return item;
    }
}