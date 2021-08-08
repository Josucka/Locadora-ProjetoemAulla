using Locadora.Models;
using System.Collections.Generic;

namespace Locadora.Services
{
    public interface IFilmesService
    {
        bool Create(Filmes filmes);
        bool Delete(int? Id);
        Filmes Get(int? Id);
        List<Filmes> GetAll(string Buscar = null, bool ordenar = false);
        bool Update(Filmes filmes);
    }
}
