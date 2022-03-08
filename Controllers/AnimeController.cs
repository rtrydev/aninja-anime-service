using aninja_anime_service.AsyncDataServices;
using aninja_anime_service.Commands;
using aninja_anime_service.Dtos;
using aninja_anime_service.Enums;
using aninja_anime_service.Queries;
using aninja_anime_service.Models;
using aninja_anime_service.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace aninja_anime_service.Controllers;

[Route("api/anime")]
[ApiController]
public class AnimeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private IMessageBusClient _messageBusClient;

    public AnimeController(IMediator mediator, IMapper mapper, IMessageBusClient messageBusClient)
    {
        _mediator = mediator;
        _mapper = mapper;
        _messageBusClient = messageBusClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimeDto>>> GetAnimes(string? orderBy)
    {
        Enum.TryParse(orderBy, out OrderByAnimesOptions option);
        var query = new GetAllAnimesQuery()
        {
            OrderBy = option
        };
        var result = await _mediator.Send(query);
        return Ok(_mapper.Map<IEnumerable<AnimeDto>>(result));
    }

    [HttpGet("{id}", Name = "GetAnimeById")]
    public async Task<ActionResult<AnimeDetailsDto>> GetAnimeById(int id)
    {
        var query = new GetAnimeByIdQuery()
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        if (result is null) return NotFound();
        return Ok(_mapper.Map<AnimeDetailsDto>(result));
    }

    [HttpPost]
    public async Task<ActionResult<AnimeDetailsDto>> AddAnime(AnimeWriteDto anime)
    {
        var command = _mapper.Map<AddAnimeCommand>(anime);
        var result = await _mediator.Send(command);

        var animePublished = _mapper.Map<AnimePublishedDto>(result);
        animePublished.Event = "Anime_Published";
        _messageBusClient.PublishNewAnime(animePublished);
        
        return Ok(_mapper.Map<AnimeDetailsDto>(result));
    }

    [HttpPut]
    public async Task<ActionResult<AnimeDetailsDto>> UpdateAnime(AnimeWriteDto anime)
    {
        var command = _mapper.Map<UpdateAnimeCommand>(anime);
        var result = await _mediator.Send(command);
        
        var animePublished = _mapper.Map<AnimePublishedDto>(result);
        animePublished.Event = "Anime_Updated";
        _messageBusClient.PublishAnimeUpdate(animePublished);
        
        return Ok(_mapper.Map<AnimeDetailsDto>(result));
    }

}