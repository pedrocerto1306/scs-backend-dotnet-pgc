using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using sics_webapi.Models.Enums;

namespace sics_webapi.Models;

public class SicsAvaliacao()
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Prestador")]
    public int PrestadorID { get; set; }
    [ForeignKey("Servico")]
    public int ServicoID { get; set; }
    [ForeignKey("Cliente")]
    public int ClienteID { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnumSicsNotas Nota { get; set; }
    public string? Avaliacao { get; set; }
    public string? LinksImagens { get; set; } = "https://sics-assets.s3.sa-east-1.amazonaws.com/images/icone_generico_servico_prestado.png";
}