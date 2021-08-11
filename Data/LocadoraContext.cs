using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {

        }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Musicas> Musicas { get; set; } 
    }
}
