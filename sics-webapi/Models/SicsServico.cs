using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using sics_webapi.Models.Enums;

namespace sics_webapi.Models;

public class SicsServico()
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    public int IdPrestador { get; set; }
    public float Valor { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnumSicsCotacoes Cotacao {get;set;}
    public string? LinkImagem { get; set; } = "https://sics-assets.s3.sa-east-1.amazonaws.com/images/icone_generico_servico_generico.png";
}

/*
public record SicsServicos(EnumSicsCotacoes? cotacao, float precoCotacaoOriginal, string? nome)
{
    public float precoReal = cotacao switch
    {
        EnumSicsCotacoes.Euro => precoCotacaoOriginal * 7,
        EnumSicsCotacoes.Dolar => precoCotacaoOriginal * 6,
        EnumSicsCotacoes.Real => precoCotacaoOriginal,
        _ => throw new NotImplementedException("Cotacao aplicada não existe no sistema sics.")
    };
}
*/