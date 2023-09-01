using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Pessoa
{
  [Key]
  public int Id { get; set; }
  public string? Nome { get; set; } = string.Empty; // Inicialização automática de propriedade
  public string? EstadoCivil { get; set; } = string.Empty; // Inicialização automática de propriedade
  public string? Idade { get; set; } = string.Empty; // Inicialização automática de propriedade
  public string? CPF { get; set; } = string.Empty; // Inicialização automática de propriedade
  public string? Cidade { get; set; } = string.Empty; // Inicialização automática de propriedade
  public string? Estado { get; set; } = string.Empty; // Inicialização automática de propriedade
}
;