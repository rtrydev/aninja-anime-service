using aninja_browse_service.Commands;
using aninja_browse_service.Models;
using aninja_browse_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_browse_service.Handlers;

public class AddAnimeCommandHandler : IRequestHandler<AddAnimeCommand, Anime>
{
    private IMapper _mapper;
    private IAnimeRepository _animeRepository;

    public AddAnimeCommandHandler(IMapper mapper, IAnimeRepository animeRepository)
    {
        _mapper = mapper;
        _animeRepository = animeRepository;
    }

    public async Task<Anime> Handle(AddAnimeCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Anime>(request);
        var anime = await _animeRepository.Create(item);
        await _animeRepository.SaveChangesAsync();
        return anime;
    }
}