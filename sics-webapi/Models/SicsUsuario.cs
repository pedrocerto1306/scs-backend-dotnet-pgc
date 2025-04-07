using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using sics_webapi.Models.Enums;

namespace sics_webapi.Models;

public class SicsUsuario : IdentityUser
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnumSicsTipoUsuarios tipoUsuario { get; set; }
}
