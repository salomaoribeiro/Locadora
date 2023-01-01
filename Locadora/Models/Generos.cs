using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
  public class Generos
  {
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
  }
}
