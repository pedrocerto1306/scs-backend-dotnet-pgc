using System.Text.Json.Serialization;
using sics_webapi.Models.Enums;

namespace sics_webapi.Models;

public class SicsCliente() : SicsPessoa
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnumSicsNotas Nota { get; set; } = EnumSicsNotas.Regular;
}