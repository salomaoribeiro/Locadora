using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
  public class Clientes
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "O {0} é obrigatório.")]
    [Display(Name = "Nome do Cliente")]
    public string Nome { get; set; }
    
    [Display(Name = "Receber as novidades por E-mail")]
    public bool EhSubscritoNewsLetter { get; set; }
    
    [Display(Name = "Tipo de assinatura")]
    public byte AssinaturasId { get; set; }
    
    public Assinaturas Assinaturas { get; set; }
    
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }
  }
}
