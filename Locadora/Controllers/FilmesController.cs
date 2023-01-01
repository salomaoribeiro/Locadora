using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
  public class FilmesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public FilmesController(ApplicationDbContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var movies = _context.Filmes.Include(filmes => filmes.Generos).ToList();
      return View(movies);
    }

    public IActionResult Details(int id)
    {
      var movie = _context.Filmes.Include(filmes => filmes.Generos).SingleOrDefault(movies => movies.Id == id);
      return View(movie);
    }

    public async Task<IActionResult> EditarAsync(int id)
    {
      Filmes? filme = await _context.Filmes.FindAsync(id);

      if (filme == null)
        return NotFound();

      FilmeNovoViewModel filmeNovoViewModel = new FilmeNovoViewModel
      {
        Filme = filme,
        Generos = _context.Generos.ToList()
      };

      return View(filmeNovoViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Salvar(FilmeNovoViewModel filmeNovo)
    {
      _context.Update(filmeNovo.Filme);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    public IActionResult Excluir(int id)
    {
      var filme = _context.Filmes.Find(id);

      if (filme == null)
        return NotFound();

      _context.Remove(filme);
      _context.SaveChanges();

      return View("Index");
    }

    public IActionResult Novo()
    {
      FilmeNovoViewModel filmeNovo = new FilmeNovoViewModel
      {
        Filme = new Filmes(),
        Generos = _context.Generos.ToList()
      };

      return View(filmeNovo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CriarFilme(Filmes filme)
    {
      if (!ModelState.IsValid)
      {
        FilmeNovoViewModel filmeNovo = new FilmeNovoViewModel
        {
          Filme = filme,
          Generos = _context.Generos.ToList()
        };

        return View("Novo", filmeNovo);
      }

      if (filme == null)
        return NotFound();

      _context.Add(filme);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}
