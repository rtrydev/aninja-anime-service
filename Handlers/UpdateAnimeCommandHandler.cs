using aninja_anime_service.Commands;
using aninja_anime_service.Models;
using aninja_anime_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_anime_service.Handlers;

public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, Unit>
{
    private IMapper _mapper;
    private IAnimeRepository _animeRepository;

    public UpdateAnimeCommandHandler(IMapper mapper, IAnimeRepository animeRepository)
    {
        _mapper = mapper;
        _animeRepository = animeRepository;
    }
    
    public async Task<Unit> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Anime>(request);
        await _animeRepository.Update(item);
        await _animeRepository.SaveChangesAsync();
        return await Task.FromResult(Unit.Value);
    }
}