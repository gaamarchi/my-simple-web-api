using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using FilmeAPI.Data;
using System.Threading.Tasks;
using FilmeAPI.Models;
using FilmeAPI.Models.DTOs.CinemaDTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;



namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { id = cinema.Id }, cinema);
    }

    [HttpGet]
    public IActionResult RecuperaCinema([FromQuery] int skip = 0, [FromQuery] int take = 5,[FromQuery] int? EnderecoId = null)
    {
        if(EnderecoId != null)
        {
            var cinemas = _context.Cinemas.Where(cinema => cinema.EnderecoId == EnderecoId).ToList();
            var readCinemaDTOs = _mapper.Map<List<ReadCinemaDTO>>(cinemas);
            return Ok(readCinemaDTOs);
        }
        return Ok(_mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.Where(cinema => cinema.EnderecoId == EnderecoId).ToList()));


    }
    [HttpGet]
    [Route("{id}")]
    public IActionResult RecuperaCinemaPorId(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
        return Ok(cinemaDto);
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDTO, cinema);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch]
    [Route("{id}")]
    public IActionResult AtualizaCinemaPatch(int id, JsonPatchDocument<UpdateCinemaDTO> patchCinema)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }

        var cinemaDTO = _mapper.Map<UpdateCinemaDTO>(cinema);

        patchCinema.ApplyTo(cinemaDTO, ModelState);

        if (!TryValidateModel(cinemaDTO))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaDTO, cinema);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}

