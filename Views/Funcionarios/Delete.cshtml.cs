using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Views.Funcionarios
{
    public class DeleteModel : PageModel
    {
        private readonly Locadora.Data.LocadoraContext _context;

        public DeleteModel(Locadora.Data.LocadoraContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filmes = await _context.Filmes.FindAsync(id);

            if (Filmes != null)
            {
                _context.Filmes.Remove(Filmes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
