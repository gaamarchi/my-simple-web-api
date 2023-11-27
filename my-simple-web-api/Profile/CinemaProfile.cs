using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.DTOs.CinemaDTO;

namespace FilmesAPI.Profile
{
    public class CinemaProfile : AutoMapper.Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
            CreateMap<Cinema,UpdateCinemaDTO>();
            CreateMap<Cinema,ReadCinemaDTO>();
        }
    }
}