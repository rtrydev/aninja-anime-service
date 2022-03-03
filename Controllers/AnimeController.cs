using aninja_browse_service.Dtos;
using aninja_browse_service.Models;
using aninja_browse_service.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aninja_browse_service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimeController : ControllerBase
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IMapper _mapper;

    public AnimeController(IAnimeRepository animeRepository, IMapper mapper)
    {
        _animeRepository = animeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimeReadDto>>> GetAnimes()
    {
        var items = await _animeRepository.GetAll();
        var result = _mapper.Map<IEnumerable<AnimeReadDto>>(items);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetAnimeById")]
    public async Task<ActionResult<AnimeReadDto>> GetAnimeById(int id)
    {
        var item = await _animeRepository.GetById(id);
        if (item is null) return NotFound();
        return Ok(item);
    }

}