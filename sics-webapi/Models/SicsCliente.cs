using System.ComponentModel.DataAnnotations;

namespace sics_webapi.Models;

public class SicsCliente()
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Contato { get; set; }
}