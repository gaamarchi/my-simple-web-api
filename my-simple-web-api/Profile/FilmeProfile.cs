using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.DTOs.FilmeDTO;

namespace FilmeAPI.Profile
{
    public class FilmeProfile : AutoMapper.Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<Filme,UpdateFilmeDTO>();
            CreateMap<Filme,ReadFilmeDTO>();
        }
    }
}