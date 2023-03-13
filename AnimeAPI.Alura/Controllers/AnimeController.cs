using AnimeAPI.Alura.Data;
using AnimeAPI.Alura.Data.Dtos;
using AnimeAPI.Alura.Models;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Alura.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private AnimeContext _context;
    private IMapper _mapper;

    public AnimeController(AnimeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaAnime([FromBody] CreateAnimeDto animeDto)
    {
        Anime anime = _mapper.Map<Anime>(animeDto);
        _context.Animes.Add(anime);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAnimesPorId), new { id = anime.Id }, anime);
    }

    [HttpGet]
    public IEnumerable<ReadAnimeDto> RecuperaAnimes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadAnimeDto>>(_context.Animes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaAnimesPorId(int id)
    {
        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);

        if (anime == null)
            return NotFound();

        var animeDto = _mapper.Map<ReadAnimeDto>(anime);
        return Ok(animeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateAnimeDto animeDto)
    {
        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);

        if (anime == null)
            return NotFound();

        _mapper.Map(animeDto, anime);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateAnimeDto> patch)
    {
        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);
        if (anime == null)
            return NotFound();

        var atualizacaoAnime = _mapper.Map<UpdateAnimeDto>(anime);
        patch.ApplyTo(atualizacaoAnime, ModelState);

        if (!TryValidateModel(atualizacaoAnime))
            return ValidationProblem(ModelState);            

        _mapper.Map(atualizacaoAnime, anime);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);
        if (anime == null)
            return NotFound();

        _context.Remove(anime);
        _context.SaveChanges();
        return NoContent();
    }
}
