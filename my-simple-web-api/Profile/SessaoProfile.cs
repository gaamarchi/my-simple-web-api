using AutoMapper;
using FilmeAPI.Models.DTOs.SessaoDTO;
using FilmeAPI.Models;
namespace FilmeAPI.Profile{
    public class SessaoProfile : AutoMapper.Profile{
        public SessaoProfile(){
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>();
        }
    }
}