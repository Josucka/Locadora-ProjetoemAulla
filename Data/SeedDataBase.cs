using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Locadora.Data
{
    public static class SeedDataBase
    {
        public static void Inicializar(IHost app)
        {
            using(var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<LocadoraContext>();
                context.Database.Migrate();
                if (!context.Filmes.Any())
                {
                    context.Filmes.Add(new Filmes { Nome = "Nome", Sinopse = "Text", Duracao = "Duraçao", Lancamento = new DateTime(), Genero = "Text" });
                }
                context.SaveChanges();
            }
        }
    }
}
