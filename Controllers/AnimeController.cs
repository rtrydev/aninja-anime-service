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

[Route("api/[controller]")]
[ApiController]
public class AnimeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnimeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimeReadDto>>> GetAnimes()
    {
        var query = new GetAllAnimesQuery()
        {
            OrderBy = OrderByAnimesOptions.ByTitle
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetAnimeById")]
    public async Task<ActionResult<AnimeReadDto>> GetAnimeById(int id)
    {
        var query = new GetAnimeByIdQuery()
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AnimeReadDto>> AddAnime(AnimeWriteDto anime)
    {
        var command = new AddAnimeCommand()
        {
            AnimeToAdd = anime
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}