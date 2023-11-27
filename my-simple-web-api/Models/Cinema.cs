using System.ComponentModel.DataAnnotations;
namespace FilmeAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public virtual Endereco Endereco { get; set; }
    
    public int EnderecoId { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }
    

}