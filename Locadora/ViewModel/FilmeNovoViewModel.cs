using Locadora.Models;

namespace Locadora.ViewModel
{
  public class FilmeNovoViewModel
  {
    public Filmes Filme { get; set; }
    public IEnumerable<Generos> Generos { get; set; }
  }
}
