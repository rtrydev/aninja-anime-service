using aninja_browse_service.Commands;
using aninja_browse_service.Models;
using aninja_browse_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_browse_service.Handlers;

public class AddAnimeCommandHandler : IRequestHandler<AddAnimeCommand, Unit>
{
    private IMapper _mapper;
    private IAnimeRepository _animeRepository;

    public AddAnimeCommandHandler(IMapper mapper, IAnimeRepository animeRepository)
    {
        _mapper = mapper;
        _animeRepository = animeRepository;
    }

    public async Task<Unit> Handle(AddAnimeCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Anime>(request);
        await _animeRepository.Create(item);
        await _animeRepository.SaveChangesAsync();
        return await Task.FromResult(Unit.Value);
    }
}