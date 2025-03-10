using Microsoft.AspNetCore.Mvc;
using sics_webapi.Models;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsServicosController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Pintura", "Mecânica", "Faxina", "Motorista", "Babá", "Cuidador(a)", "Contador(a)"
    };


    private readonly ILogger<SicsServicosController> _logger;

    public SicsServicosController(ILogger<SicsServicosController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSicsServicos")]
    public IEnumerable<SicsServicos> Get()
    {
        var servicos =  Enumerable.Range(1, 5).Select(index =>
            new SicsServicos
            (
                index % 3 == 0 ? EnumSicsCotacoes.Euro : index % 2 == 0 ? EnumSicsCotacoes.Dolar : EnumSicsCotacoes.Real,
                index % 3 == 1 ? 100 : index % 2 == 0 ? 150 : 300,
                Summaries[index]
            ))
            .ToArray();
        return servicos;
    }
}
