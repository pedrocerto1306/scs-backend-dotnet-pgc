using Microsoft.AspNetCore.Identity;

namespace sics_webapi.Models;

public class SicsUsuario : IdentityUser
{
    public TipoUsuario tipoUsuario { get; set; }
}

public enum TipoUsuario
{
    Cliente,
    Prestador,
}