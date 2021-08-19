using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Locadora.Models;

namespace Locadora.Views.Funcionarios
{
    public class CreateModel : PageModel
    {
        private readonly Locadora.Data.LocadoraContext _context;

        public CreateModel(Locadora.Data.LocadoraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Filmes Filmes { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Filmes.Add(Filmes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
