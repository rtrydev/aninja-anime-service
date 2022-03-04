using aninja_browse_service.Dtos;
using aninja_browse_service.Queries;
using aninja_browse_service.Repositories;
using AutoMapper;
using MediatR;

namespace aninja_browse_service.Handlers;

public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, AnimeReadDto>
{
    private IMapper _mapper;
    private IAnimeRepository _animeRepository;

    public GetAnimeByIdQueryHandler(IMapper mapper, IAnimeRepository animeRepository)
    {
        _mapper = mapper;
        _animeRepository = animeRepository;
    }

    public async Task<AnimeReadDto> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _animeRepository.GetById(request.Id);
        return _mapper.Map<AnimeReadDto>(item);
    }
}