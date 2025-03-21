using Microsoft.AspNetCore.Identity;

namespace sics_webapi.Models;

public class Usuario : IdentityUser
{
    public string Email { get; set;} = string.Empty;
}