using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Locadora.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Filmes> Filmes { get; set; }
    public DbSet<Assinaturas> Assinaturas { get;set; }
    public DbSet<Clientes> Clientes { get; set;}
    public DbSet<Generos> Generos { get; set; }
  }
}