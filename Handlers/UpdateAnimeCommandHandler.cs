using aninja_anime_service.Commands;
using aninja_anime_service.Models;
using aninja_anime_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_anime_service.Handlers;

public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, Anime>
{
    private IMapper _mapper;
    private IAnimeRepository _animeRepository;

    public UpdateAnimeCommandHandler(IMapper mapper, IAnimeRepository animeRepository)
    {
        _mapper = mapper;
        _animeRepository = animeRepository;
    }
    
    public async Task<Anime> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Anime>(request);
        var result = await _animeRepository.Update(item);
        await _animeRepository.SaveChangesAsync();
        return await Task.FromResult(result);
    }
}