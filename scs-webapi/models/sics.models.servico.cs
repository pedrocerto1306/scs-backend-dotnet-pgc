using System.ComponentModel.DataAnnotations;

namespace Sics.Models;

public class SicsServico()
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    public int IdPrestador { get; set; }
    public float Valor { get; set; }
    public EnumSicsCotacoes Cotacao { get; set; }
}