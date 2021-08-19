using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Views.Funcionarios
{
    public class EditModel : PageModel
    {
        private readonly Locadora.Data.LocadoraContext _context;

        public EditModel(Locadora.Data.LocadoraContext context)
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

        // Para proteger contra ataques de sobrepostagem, habilite as propriedades específicas a que deseja vincular.
        // Para obter mais detalhes, consulte https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Filmes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmesExists(Filmes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
