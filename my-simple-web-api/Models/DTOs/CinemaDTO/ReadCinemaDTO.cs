namespace FilmeAPI.Models.DTOs.CinemaDTO;
using  FilmeAPI.Models.DTOs.EnderecoDTO;
using FilmeAPI.Models.DTOs.SessaoDTO;
public class ReadCinemaDTO
{
    public int Id { get; set; }    
    public string Name { get; set; }
    
    public ReadEnderecoDTO Endereco { get; set; }

    public ICollection<ReadSessaoDTO> Sessoes { get; set; }

}