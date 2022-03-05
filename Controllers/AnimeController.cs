using aninja_browse_service.AsyncDataServices;
using aninja_browse_service.Commands;
using aninja_browse_service.Dtos;
using aninja_browse_service.Enums;
using aninja_browse_service.Models;
using aninja_browse_service.Queries;
using aninja_browse_service.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace aninja_browse_service.Controllers;

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
    public async Task<ActionResult<IEnumerable<AnimeDto>>> GetAnimes()
    {
        var query = new GetAllAnimesQuery()
        {
            OrderBy = OrderByAnimesOptions.ByTitle
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
    public async Task<ActionResult> AddAnime(AnimeWriteDto anime)
    {
        var command = _mapper.Map<AddAnimeCommand>(anime);
        var result = await _mediator.Send(command);

        var animePublished = _mapper.Map<AnimePublishedDto>(result);
        animePublished.Event = "Anime_Published";
        _messageBusClient.PublishNewAnime(animePublished);
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAnime(AnimeWriteDto anime)
    {
        var command = _mapper.Map<UpdateAnimeCommand>(anime);
        var result = await _mediator.Send(command);
        return Ok();
    }

}