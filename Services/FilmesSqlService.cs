using Locadora.Data;
using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Services
{
    public class FilmesSqlService : IFilmesService
    {
        LocadoraContext _context;
        public FilmesSqlService(LocadoraContext context)
        {
            this._context = context;
        }
        public List<Filmes> GetAll(string Buscar = null, bool ordenar = false)
        {
            List<Filmes> filme = _context.Filmes.Include(f => f.Musicas).ToList();
            if (Buscar != null)
            {
                return filme.FindAll(f => f.Nome.ToLower().Contains(Buscar.ToLower()));
            }
            if (ordenar)
            {
                filme = filme.OrderBy(f => f.Nome).ToList();
                return filme;
            }
            return filme;
        }
        public bool Create(Filmes filme)
        {
            try
            {
                _context.Filmes.Add(filme);
                _context.SaveChanges();
                return true; 
            }
            catch
            {
                return false;
            }
        }
        public Filmes Get(int? Id)
        {
            return _context.Filmes.Include(f => f.Musicas).FirstOrDefault(f => f.Id == Id);
        }
        public bool Update(Filmes filme)
        {
            try
            {
                _context.Update(filme);
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
                var filme = Get(Id);
                _context.Filmes.Remove(filme);
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
