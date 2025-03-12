using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Data;
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
    private readonly DataContext _dbContext;

    public SicsServicosController(ILogger<SicsServicosController> logger, DataContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetSicsServicos")]
    public IEnumerable<SicsServico> Get()
    {
        return _dbContext.SicsServicos;
    }

    [HttpGet("{id}")]
    public async IAsyncEnumerable<SicsServico> GetById([FromRoute] int id)
    {
        yield return await _dbContext.SicsServicos.FirstOrDefaultAsync(servico => servico.Id == id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] SicsServico servico)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(servico);

            SicsServico? servicoAntigo = await _dbContext.SicsServicos.FirstOrDefaultAsync(s => s.Id == servico.Id);

            if(servicoAntigo == null) return BadRequest($"Serviço nao encontrado: {servico.Id}");

            servicoAntigo = servico;
            _dbContext.Update(servicoAntigo);
            await _dbContext.SaveChangesAsync();

            return StatusCode(200);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
