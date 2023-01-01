namespace Locadora.Models
{
  public class Assinaturas
  {
    public byte Id { get; set; }
    public string Nome { get; set; }
    public short TipoDaAssinatura { get; set; }
    public short DuracaoEmMeses { get; set; }
    public byte TaxaDesconto { get; set; }
  }
}
