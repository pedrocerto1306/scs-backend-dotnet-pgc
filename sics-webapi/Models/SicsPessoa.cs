using System.ComponentModel.DataAnnotations;

namespace sics_webapi.Models;

public class SicsPessoa()
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Contato { get; set; }
    public string? Documento { get; set; }
    public string? LinkImagem { get; set; }
}