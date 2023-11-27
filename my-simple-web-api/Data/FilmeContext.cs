using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder Builder){
        Builder.Entity<Sessao>()
            .HasKey(sessao =>new {sessao.FilmeId, sessao.CinemaId});

        Builder.Entity<Sessao>()
        .HasOne(sessao => sessao.Cinema)
        .WithMany(cinema => cinema.Sessoes)
        .HasForeignKey(cinema => cinema.CinemaId);

         Builder.Entity<Sessao>()
        .HasOne(sessao => sessao.Filme)
        .WithMany(filme => filme.Sessoes)
        .HasForeignKey(cinema => cinema.FilmeId);
    }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<Sessao> Sessoes {get;set;}
}
