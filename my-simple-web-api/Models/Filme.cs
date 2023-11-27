using System.ComponentModel.DataAnnotations;
// Purpose: Model for Filme


namespace FilmeAPI.Models;

public class Filme
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Titulo { get; set; }
    [Required]
    [MaxLength(30)]
    public string Genero { get; set; }
    [Required]
    [Range(70, 600)]
    public int Duracao { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }
}
