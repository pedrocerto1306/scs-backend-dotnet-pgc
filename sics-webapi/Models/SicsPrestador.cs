using System.ComponentModel.DataAnnotations;

namespace sics_webapi.Models;

public class SicsPrestador()
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    public string? Especialidade { get; set; }
    [Required]
    public string? Contato { get; set; }
}