using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sics_webapi.Models;

public class SicsTransacao()
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Prestador")]
    public int PrestadorId { get; set; }
    public SicsPrestador? Prestador { get; set; }
    [ForeignKey("Servico")]
    public int ServicoId { get; set; }
    public SicsServico? Servico { get; set; }
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public SicsCliente? Cliente { get; set; }
    public bool Efetivado { get; set; } = false;
    public DateTime Data { get; set; }
    public bool Cancelado { get; set; } = false;
    public string? MotivoCancelamento { get; set; }
}