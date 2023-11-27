using System.ComponentModel.DataAnnotations;
namespace FilmeAPI.Models.DTOs.CinemaDTO;

public class UpdateCinemaDTO
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

}