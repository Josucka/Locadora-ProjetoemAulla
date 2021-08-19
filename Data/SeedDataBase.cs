using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Locadora.Data
{
    public static class SeedDataBase
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using (var context = new LocadoraContext(serviceProvider.GetRequiredService<DbContextOptions<LocadoraContext>>()))
            {
                if (context.Filmes.Any())
                {
                    return;
                }
                if (!context.Filmes.Any())
                {
                    context.Filmes.Add(new Filmes { Nome = "Nome", Sinopse = "Text", Duracao = "Duraçao", Lancamento = new DateTime(), Genero = "Text" });
                }
                if (!context.Musicas.Any())
                {
                    context.Musicas.Add(new Musicas { Nome = "Nome", Cantor = "Nome", Lancamento = new DateTime(), Genero = "Text" });
                }
                context.SaveChanges();
            }
        }
    }
}
