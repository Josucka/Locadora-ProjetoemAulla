using Locadora.Models;
using System.Collections.Generic;

namespace Locadora.Services
{
    public interface IMusicasService
    {
        bool Create(Musicas musica);
        bool Delete(int? Id);
        Musicas Get(int? Id);
        List<Musicas> GetAll();
        bool Update(Musicas musica);
    }
}
