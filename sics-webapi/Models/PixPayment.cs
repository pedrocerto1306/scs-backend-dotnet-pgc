using System;

namespace sics_webapi.Models;

public class PixPayment
{
    public int Id { get; set; }
    public string? Mensagem { get; set; }
    public double Valor { get; set; }
    public string? ChaveOrigem { get; set; }
    public string? ChaveDestino { get; set; }
}
