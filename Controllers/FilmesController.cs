using Locadora.Models;
using Locadora.Services;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    public class FilmesController : Controller
    {
        IFilmesService _service, _sqlService, _staticService; 
        public FilmesController(IFilmesService service, FilmesSqlService filmesSqlService, FilmesStaticService filmesStaticService)
        {
            _staticService = filmesStaticService;
            _sqlService = filmesSqlService;
            _service = service;
        }

        private void SelectService(string service = "sql")
        {
            switch (service)
            {
                case "sql":
                    this._service = this._sqlService;
                    break;
                case "static":
                    this._service = this._staticService;
                    break;
                default:
                    this._service = this._sqlService;
                    break;
            }
        }
        public IActionResult Index(string Buscar, bool ordenar=false, string service = "sql")
        {
            SelectService(service);
            ViewBag.ordenar = ordenar;
            return View(_service.GetAll(Buscar, ordenar));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Filmes filmes)
        {
            if (!ModelState.IsValid) return View(filmes);
            _service.Create(filmes);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Read(int? Id)
        {
            Filmes filme = _service.Get(Id);
            return filme != null ? View(filme) : RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? Id)
        {
            var filme = _service.Get(Id);
            return filme != null ? View(filme) : NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Filmes filme)
        {
            if (!ModelState.IsValid) return View(filme);
            _service.Update(filme);
            if (_service.Update(filme))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(filme);
            }
        }
        public IActionResult Delete(int? Id)
        {
            if(_service.Delete(Id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Confirm(int? Id)
        {
            try
            {
                return View(_service.Get(Id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
