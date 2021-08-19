using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Views.Funcionarios
{
    public class DetailsModel : PageModel
    {
        private readonly Locadora.Data.LocadoraContext _context;

        public DetailsModel(Locadora.Data.LocadoraContext context)
        {
            _context = context;
        }

        public Filmes Filmes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filmes = await _context.Filmes.FirstOrDefaultAsync(m => m.Id == id);

            if (Filmes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
