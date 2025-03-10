using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sics_webapi.Models;

public class SicsServicoOferecido()
{
    [Key]
    [Required]
    public int PrestadorId { get; set; }
    
    [ForeignKey("ServicoId")]
    [Required]
    public int ServicoId { get; set; }
}