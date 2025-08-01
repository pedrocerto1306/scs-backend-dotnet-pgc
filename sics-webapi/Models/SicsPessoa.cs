using System.ComponentModel.DataAnnotations;
using sics_webapi.Models.Enums;

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
    public EnumSicsGeneros Genero { get; set; }
    public string? LinkImagem { get; set; } = "https://sics-assets.s3.sa-east-1.amazonaws.com/images/icone_generico_cliente_homem.png";
}