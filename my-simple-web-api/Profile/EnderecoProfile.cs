using AutoMapper;
using FilmeAPI.Models.DTOs.EnderecoDTO;
using FilmeAPI.Models;
namespace  FilmesAPI.Profile
{
    public class EnderecoProfile : AutoMapper.Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
        }
    }
}