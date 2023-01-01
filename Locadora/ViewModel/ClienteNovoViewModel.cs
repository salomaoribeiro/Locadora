using Locadora.Models;

namespace Locadora.ViewModel
{
  public class ClienteNovoViewModel
  {
    public IEnumerable<Assinaturas>? Assinaturas { get ; set; }
    public Clientes? Cliente { get; set; }
  }
}
