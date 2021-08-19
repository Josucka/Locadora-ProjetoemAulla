using Locadora.Models;
using Locadora.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Locadora.Controllers
{
    [Authorize]
    public class MusicasController : Controller
    {
        IMusicasService service;
        IFilmesService _filmesService; 
        public MusicasController(IMusicasService _service, IFilmesService filmesService)
        {
            this.service = _service;
            this._filmesService = filmesService;
        }

        public IActionResult Index(string Buscar, bool ordenar=false)
        {
            ViewBag.ordenar = ordenar;
            return View(service.GetAll());
        }
        public IActionResult Create()
        {
            var filmes = _filmesService.GetAll();
            ViewBag.listaFilmes = new SelectList(filmes, "Id", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Musicas musica)
        {
            var filmes = _filmesService.GetAll();
            if (!ModelState.IsValid) return View(musica);

            if (service.Create(musica))
            {

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(musica);
            }
        }
        public IActionResult Read(int? Id)
        {
            Musicas musica = service.Get(Id);
            return musica != null ? View(musica) : RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? Id)
        {
            var filme = service.GetAll();
            ViewBag.listaFilmes = new SelectList(filme, "Id", "Nome");
            return filme != null ? View(filme) : NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Musicas musica)
        {
            var filme = service.GetAll();
            ViewBag.listaFilmes = new SelectList(filme, "Id", "Nome");

            if (!ModelState.IsValid) return View(musica);
            service.Update(musica);
            if (service.Update(musica))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(musica);
            }
        }
        public IActionResult Delete(int? Id)
        {
            var musica = service.Get(Id);
            if(musica != null)
            {
                service.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Confirm(int? Id)
        {
            try
            {
                return View(service.Get(Id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
