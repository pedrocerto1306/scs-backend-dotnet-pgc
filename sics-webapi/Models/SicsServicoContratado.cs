using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sics_webapi.Models;

public class SicsServicoContratado()
{
    [Key]
    [Required]
    public int ClienteId { get; set; }
    
    [ForeignKey("ServicoId")]
    [Required]
    public int ServicoId { get; set; }
}