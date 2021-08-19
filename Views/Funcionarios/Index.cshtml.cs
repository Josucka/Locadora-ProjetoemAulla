using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Views.Funcionarios
{
    public class IndexModel : PageModel
    {
        private readonly Locadora.Data.LocadoraContext _context;

        public IndexModel(Locadora.Data.LocadoraContext context)
        {
            _context = context;
        }

        public IList<Filmes> Filmes { get;set; }

        public async Task OnGetAsync()
        {
            Filmes = await _context.Filmes.ToListAsync();
        }
    }
}
