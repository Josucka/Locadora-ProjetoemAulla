using Locadora.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data
{
    public class LocadoraContext : IdentityDbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {

        }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Musicas> Musicas { get; set; } 
    }
}
