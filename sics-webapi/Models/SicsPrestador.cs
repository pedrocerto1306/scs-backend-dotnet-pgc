using sics_webapi.Models.Enums;

namespace sics_webapi.Models;

public class SicsPrestador() : SicsPessoa
{
    public string? Especialidade { get; set; }
    public bool IdentidadeConfirmada { get; set; } = false;
    public EnumSicsNotas Nota { get; set; } = EnumSicsNotas.Regular;
}