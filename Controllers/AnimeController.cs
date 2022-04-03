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
using Microsoft.AspNetCore.Authorization;

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
    public async Task<ActionResult<AnimeSearchResultDto>> GetAnimes(
        [FromQuery] string? orderBy, 
        [FromQuery] IEnumerable<string>? demographics, 
        [FromQuery] IEnumerable<string>? statuses, 
        [FromQuery] string? name, 
        [FromQuery] IEnumerable<int>? tagIds,
        [FromQuery] int page = 1,
        [FromQuery] int resultsPerPage = 10)
    {
        Enum.TryParse(orderBy, out OrderByAnimesOptions option);
        var query = new GetAllAnimesQuery()
        {
            OrderBy = option,
            Statuses = statuses,
            Demographics = demographics,
            Name = name,
            TagIds = tagIds
        };
        var result = await _mediator.Send(query);
        var animes = _mapper.Map<IEnumerable<AnimeDto>>(result);
        if (page > Math.Ceiling((double) animes.Count() / resultsPerPage)) return NotFound();
        var animeChunk = animes.Count() > resultsPerPage
            ? animes.Skip((page - 1) * resultsPerPage).Take(resultsPerPage)
            : animes;
        var searchResult = new AnimeSearchResultDto()
        {
            Animes = animeChunk,
            AllCount = animes.Count()
        };
        return Ok(searchResult);
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
        if (result is null) return NotFound();
        
        var animePublished = _mapper.Map<AnimePublishedDto>(result);
        animePublished.Event = "Anime_Updated";
        _messageBusClient.PublishAnimeUpdate(animePublished);
        
        return Ok(_mapper.Map<AnimeDetailsDto>(result));
    }

}