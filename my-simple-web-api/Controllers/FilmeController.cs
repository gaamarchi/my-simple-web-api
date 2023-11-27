using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using FilmeAPI.Data;
using System.Threading.Tasks;
using FilmeAPI.Models;
using FilmeAPI.Models.DTOs.FilmeDTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;



namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IActionResult RecuperaFilme([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var filmes = _context.Filmes.Skip(skip).Take(take).ToList();
        var readFilmeDTOs = _mapper.Map<List<ReadFilmeDTO>>(filmes);
        return Ok(readFilmeDTOs);
    }
    [HttpGet]
    [Route("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {

        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filme);
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch]
    [Route("{id}")]
    public IActionResult AtualizaFilmePatch(int id, JsonPatchDocument<UpdateFilmeDTO> patchFilme)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        var filmeDTO = _mapper.Map<UpdateFilmeDTO>(filme);

        patchFilme.ApplyTo(filmeDTO, ModelState);

        if (!TryValidateModel(filmeDTO))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}

