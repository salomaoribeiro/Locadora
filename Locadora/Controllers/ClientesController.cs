using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
  public class ClientesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ClientesController(ApplicationDbContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var clientes = _context.Clientes.Include(cliente => cliente.Assinaturas).ToList();

      return View(clientes);
    }

    public IActionResult Details(int id)
    {
      var customer = _context.Clientes.Include(cliente => cliente.Assinaturas).SingleOrDefault(c => c.Id == id);

      return View(customer);
    }

    [HttpPost]
    public IActionResult Novo()
    {
      var assinaturas = _context.Assinaturas.ToList();
      ClienteNovoViewModel novoCliente = new ClienteNovoViewModel
      {
        Assinaturas = assinaturas
      };

      return View(novoCliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CriarUsuario(Clientes cliente)
    {
      if (!ModelState.IsValid)
      {
        ClienteNovoViewModel clienteNovo = new ClienteNovoViewModel
        {
          Cliente = cliente,
          Assinaturas = _context.Assinaturas.ToList()
        };

        return View("Novo", clienteNovo);
      }

      _context.Clientes.Add(cliente);
      _context.SaveChanges();

      return RedirectToAction("Index", "Clientes");
    }

    public async Task<IActionResult> Editar(int id)
    {
      Clientes? cliente = await _context.Clientes.FindAsync(id);
      IEnumerable<Assinaturas> assinaturas = _context.Assinaturas.ToList();

      ClienteNovoViewModel clienteViewModel = new ClienteNovoViewModel
      {
        Cliente = cliente ?? new Clientes(),
        Assinaturas = assinaturas
      };

      return View(clienteViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Salvar(Clientes cliente)
    {
      if (!ModelState.IsValid)
      {
        ClienteNovoViewModel clienteNovoViewModel = new ClienteNovoViewModel
        {
          Cliente = cliente,
          Assinaturas = _context.Assinaturas.ToList()
        };

        return View("Editar", clienteNovoViewModel);
      }

      _context.Update(cliente);
      _context.SaveChanges();

      return RedirectToAction("Index", "Clientes");
    }

    public IActionResult Excluir(int id)
    {
      Clientes? cliente = _context.Clientes.Find(id);

      if (cliente != null)
      {
        _context.Remove(cliente);
        _context.SaveChanges();
      }
      return RedirectToAction("Index", "Clientes");
    }
  }
}
