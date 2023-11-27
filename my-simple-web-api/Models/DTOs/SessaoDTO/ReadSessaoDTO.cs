using FilmeAPI.Models.DTOs.FilmeDTO;
namespace FilmeAPI.Models.DTOs.SessaoDTO
{
    public class ReadSessaoDTO
    {
        public int FilmeId { get; set; }

        public int CinemaId { get; set; }
    }
}