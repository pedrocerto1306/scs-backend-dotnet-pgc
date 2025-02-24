using System.ComponentModel.DataAnnotations;

namespace sics_webapi;

public class SicsServico()
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    public int IdPrestador { get; set; }
    public float Valor { get; set; }
    public EnumSicsCotacoes Cotacao {get;set;}
    public float valorReal => Cotacao switch
    {
        EnumSicsCotacoes.Euro => Valor * 7,
        EnumSicsCotacoes.Dolar => Valor * 6,
        EnumSicsCotacoes.Real => Valor,
        _ => throw new NotImplementedException("Cotacao aplicada não existe no sistema sics.")
    };
    
}

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

public enum EnumSicsCotacoes
{
    Real,
    Dolar,
    Euro
}