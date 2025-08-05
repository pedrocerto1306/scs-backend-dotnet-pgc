using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using sics_webapi.Models.Enums;

namespace sics_webapi.Models;

public class SicsTransacao()
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Prestador")]
    public int PrestadorId { get; set; }
    [ForeignKey("Servico")]
    public int ServicoId { get; set; }
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnumSicsEstadoTransacao? Estado { get; set; } = EnumSicsEstadoTransacao.Pendente_Confirmacao_Prestador;
    public string? Observacoes { get; set; }
}