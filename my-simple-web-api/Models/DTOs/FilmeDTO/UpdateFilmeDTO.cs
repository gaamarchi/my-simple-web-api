using System.ComponentModel.DataAnnotations;
namespace FilmeAPI.Models.DTOs.FilmeDTO
{
    public class UpdateFilmeDTO
    {
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(30)]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600)]
        public int Duracao { get; set; }
    }
}