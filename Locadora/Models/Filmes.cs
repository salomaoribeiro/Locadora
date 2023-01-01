using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
  public class Filmes
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome do Filme é obrigatório.")]
    [StringLength(255)]
    [Display(Name = "Nome do Filme")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Gênero é obrigatório.")]
    [Display(Name = "Gênero")]
    public int GenerosId { get; set; }

    public Generos Generos { get; set; }

    [Display(Name = "Data de Lançamento")]
    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "A Data de Compra é obrigatória.")]
    [Display(Name = "Data de Compra")]
    public DateTime DataDaCompra { get; set; }

    [Required(ErrorMessage = "A quantidade em Estoque é obrigatório.")]
    [Range(1, 20, ErrorMessage = "É necessário um valor entre 1 e 20.")]
    [Display(Name = "Estoque")]
    public byte Estoque { get; set; }
  }
}
