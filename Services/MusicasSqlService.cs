using Locadora.Data;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Services
{
    public class MusicasSqlService : IMusicasService
    {
        LocadoraContext _context;
        public MusicasSqlService(LocadoraContext context)
        {
            this._context = context;
        }
        public List<Musicas> GetAll(string Buscar = null, bool ordenar = false)
        {
            return _context.Musicas.Include(m => m.temFilme).ToList();
            //List<Filmes> filme = _context.Filmes.ToList();
            //if (Buscar != null)
            //{
            //    return filme.FindAll(f => f.Nome.ToLower().Contains(Buscar.ToLower()));
            //}
            //if (ordenar)
            //{
            //    filme = filme.OrderBy(f => f.Nome).ToList();
            //    return filme;
            //}
            //return filme;
        }
        public bool Create(Musicas musica)
        {
            try
            {
                _context.Musicas.Add(musica);
                _context.SaveChanges();
                return true; 
            }
            catch
            {
                return false;
            }
        }
        public Musicas Get(int? Id)
        {
            return _context.Musicas.Include(m => m.temFilme).FirstOrDefault(m => m.Id == Id);
        }
        public bool Update(Musicas musica)
        {
            try
            {
                _context.Update(musica);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int? Id)
        {
            try
            {
                var musica = Get(Id);
                _context.Musicas.Remove(musica);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
